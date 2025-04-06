using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using CelebrityQuiz.Model;
using CelebrityQuiz.View;
using MaterialDesignThemes.Wpf;

namespace CelebrityQuiz.ViewModel
{
    public class RegularQuizViewModel : INotifyPropertyChanged
    {
        private Actor _currentActor;
        private List<Actor> _possibleAnswers;
        private int _score;
        private bool _isDarkTheme;
        private readonly DispatcherTimer _delayTimer;
        private List<string> _answerStates;
        private bool _isAnsweringEnabled;
        private bool _isQuizActive;
        private int _questionsAnswered;
        private int _totalQuestions = 10;
        private HashSet<int> _usedActorIds;
        private List<AnswerRecord> _answerHistory;

        public Actor CurrentActor
        {
            get => _currentActor;
            set
            {
                _currentActor = value;
                OnPropertyChanged();
            }
        }

        public List<Actor> PossibleAnswers
        {
            get => _possibleAnswers;
            set
            {
                _possibleAnswers = value;
                OnPropertyChanged();
            }
        }

        public List<string> AnswerStates
        {
            get => _answerStates;
            set
            {
                _answerStates = value;
                OnPropertyChanged();
            }
        }

        public bool IsAnsweringEnabled
        {
            get => _isAnsweringEnabled;
            set
            {
                _isAnsweringEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool IsQuizActive
        {
            get => _isQuizActive;
            set
            {
                _isQuizActive = value;
                OnPropertyChanged();
            }
        }

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged();
            }
        }

        public int QuestionsAnswered
        {
            get => _questionsAnswered;
            set
            {
                _questionsAnswered = value;
                OnPropertyChanged();
            }
        }

        public int RemainingQuestions
        {
            get => _totalQuestions - _questionsAnswered;
        }

        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set
            {
                if (_isDarkTheme != value)
                {
                    _isDarkTheme = value;
                    OnPropertyChanged();
                    ApplyTheme();
                }
            }
        }

        public ICommand GenerateQuizCommand { get; }
        public ICommand CheckAnswerCommand { get; }
        public ICommand RestartQuizCommand { get; }

        public ICommand InnerRestartQuizCommand { get; }
        public ICommand ToggleThemeCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public RegularQuizViewModel()
        {
            _usedActorIds = new HashSet<int>();
            _answerHistory = new List<AnswerRecord>();

            GenerateQuizCommand = new RelayCommand(GenerateQuiz);
            CheckAnswerCommand = new RelayCommand<Actor>(CheckAnswer);
            RestartQuizCommand = new RelayCommand(RestartQuiz);
            InnerRestartQuizCommand = new RelayCommand(InnerRestartQuiz);
            ToggleThemeCommand = new RelayCommand(ToggleTheme);

            _delayTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            _delayTimer.Tick += DelayTimer_Tick;

            Score = 0;
            IsDarkTheme = true;
            AnswerStates = new List<string> { "", "", "", "" };
            IsAnsweringEnabled = true;
            IsQuizActive = true;
            QuestionsAnswered = 0;
            GenerateQuiz();
        }

        private void DelayTimer_Tick(object sender, EventArgs e)
        {
            _delayTimer.Stop();
            GenerateQuiz();
        }

        private void GenerateQuiz()
        {
            if (!IsQuizActive || QuestionsAnswered >= _totalQuestions) return;

            try
            {
                using (var context = new AppDbContextFactory().CreateDbContext(null))
                {
                    var availableActors = context.Actors
                        .Where(a => !_usedActorIds.Contains(a.Id))
                        .ToList();

                    if (availableActors.Count > 0)
                    {
                        var random = new Random();
                        CurrentActor = availableActors[random.Next(availableActors.Count)];
                        _usedActorIds.Add(CurrentActor.Id);

                        var sameGenderActors = context.Actors
                            .Where(a => a.Gender == CurrentActor.Gender && a.Id != CurrentActor.Id)
                            .ToList();
                        var randomAnswers = sameGenderActors
                            .OrderBy(_ => Guid.NewGuid())
                            .Take(3)
                            .ToList();

                        randomAnswers.Add(CurrentActor);
                        PossibleAnswers = randomAnswers.OrderBy(_ => Guid.NewGuid()).ToList();

                        AnswerStates = new List<string> { "", "", "", "" };
                        IsAnsweringEnabled = true;
                    }
                    else
                    {
                        ShowQuizResults(); // No more unused actors available
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating quiz: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CheckAnswer(Actor selectedActor)
        {
            if (!IsAnsweringEnabled || !IsQuizActive) return;

            IsAnsweringEnabled = false;
            QuestionsAnswered++;
            OnPropertyChanged(nameof(RemainingQuestions));

            var newStates = new List<string> { "", "", "", "" };
            bool isCorrect = false;

            for (int i = 0; i < PossibleAnswers.Count; i++)
            {
                if (PossibleAnswers[i].Id == CurrentActor.Id)
                {
                    newStates[i] = "Correct";
                    if (selectedActor?.Id == CurrentActor.Id)
                    {
                        isCorrect = true;
                    }
                }
                else if (PossibleAnswers[i].Id == selectedActor?.Id)
                {
                    newStates[i] = "Incorrect";
                }
            }
            AnswerStates = newStates;

            // Record the answer
            _answerHistory.Add(new AnswerRecord
            {
                CorrectActor = CurrentActor,
                SelectedActor = selectedActor,
                IsCorrect = isCorrect
            });

            // Add 1 point for correct answer
            if (isCorrect)
            {
                Score += 1;
            }

            if (QuestionsAnswered >= _totalQuestions)
            {
                ShowQuizResults();
            }
            else
            {
                _delayTimer.Start();
            }
        }

        private void ShowQuizResults()
        {
            Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x is RegularQuizWindow)?.Close();
            IsQuizActive = false;
            var resultsViewModel = new QuizResultsViewModel(Score, _questionsAnswered, _answerHistory, GameMode.Standard);
            var resultsWindow = new QuizResultsWindow
            {
                DataContext = resultsViewModel
            };

            resultsViewModel.PlayAgainRequested += (s, e) =>
            {
                resultsWindow.Close();
                RestartQuiz();
            };

            resultsWindow.ShowDialog();
        }

        private void RestartQuiz()
        {
            var regularGameView = new RegularQuizWindow
            {
                DataContext = this
            };
            regularGameView.Show();
            
            Score = 0;
            QuestionsAnswered = 0;
            IsQuizActive = true;
            _delayTimer.Stop();
            _usedActorIds.Clear();
            _answerHistory.Clear();
            OnPropertyChanged(nameof(RemainingQuestions));
            GenerateQuiz();
        }

        private void InnerRestartQuiz()
        {

            Score = 0;
            QuestionsAnswered = 0;
            IsQuizActive = true;
            _delayTimer.Stop();
            _usedActorIds.Clear();
            _answerHistory.Clear();
            OnPropertyChanged(nameof(RemainingQuestions));
            GenerateQuiz();
        }

        private void ToggleTheme()
        {
            IsDarkTheme = !IsDarkTheme;
        }

        private void ApplyTheme()
        {
            var paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(_isDarkTheme ? BaseTheme.Dark : BaseTheme.Light);
            paletteHelper.SetTheme(theme);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}