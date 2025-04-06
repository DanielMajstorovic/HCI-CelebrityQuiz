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
    public class QuizViewModel : INotifyPropertyChanged
    {
        private Actor _currentActor;
        private List<Actor> _possibleAnswers;
        private int _score;
        private bool _isDarkTheme;
        private DispatcherTimer _delayTimer;
        private DispatcherTimer _gameTimer;
        private List<string> _answerStates;
        private bool _isAnsweringEnabled;
        private bool _isQuizActive;
        private int _remainingSeconds;
        private HashSet<int> _usedActorIds;
        private List<AnswerRecord> _answerHistory;

        private bool _isEndingQuiz;

        private Window _currentQuizWindow;

        public event PropertyChangedEventHandler PropertyChanged;

        public Actor CurrentActor
        {
            get => _currentActor;
            set { _currentActor = value; OnPropertyChanged(); }
        }

        public List<Actor> PossibleAnswers
        {
            get => _possibleAnswers;
            set { _possibleAnswers = value; OnPropertyChanged(); }
        }

        public List<string> AnswerStates
        {
            get => _answerStates;
            set { _answerStates = value; OnPropertyChanged(); }
        }

        public bool IsAnsweringEnabled
        {
            get => _isAnsweringEnabled;
            set { _isAnsweringEnabled = value; OnPropertyChanged(); }
        }

        public bool IsQuizActive
        {
            get => _isQuizActive;
            set { _isQuizActive = value; OnPropertyChanged(); }
        }

        public int Score
        {
            get => _score;
            set { _score = value; OnPropertyChanged(); }
        }

        public int RemainingSeconds
        {
            get => _remainingSeconds;
            set { _remainingSeconds = value; OnPropertyChanged(); }
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

        // Komande
        public ICommand GenerateQuizCommand { get; }
        public ICommand CheckAnswerCommand { get; }
        public ICommand RestartQuizCommand { get; }       
        public ICommand InnerRestartQuizCommand { get; } 
        public ICommand ToggleThemeCommand { get; }

        public QuizViewModel(Window quizWindow)
        {
            _currentQuizWindow = quizWindow;
            _usedActorIds = new HashSet<int>();
            _answerHistory = new List<AnswerRecord>();

            GenerateQuizCommand = new RelayCommand(GenerateQuiz);
            CheckAnswerCommand = new RelayCommand<Actor>(CheckAnswer);
            RestartQuizCommand = new RelayCommand(RestartQuiz);
            InnerRestartQuizCommand = new RelayCommand(InnerRestartQuiz);
            ToggleThemeCommand = new RelayCommand(ToggleTheme);
            
            _delayTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
            _delayTimer.Tick += DelayTimer_Tick;

            _gameTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _gameTimer.Tick += GameTimer_Tick;

            Score = 0;
            IsDarkTheme = true; 
            AnswerStates = new List<string> { "", "", "", "" };
            IsAnsweringEnabled = true;
            IsQuizActive = true;
            RemainingSeconds = 30;
            _isEndingQuiz = false;

            GenerateQuiz();
            StartTimer();
        }

        private void StartTimer()
        {
            RemainingSeconds = 30;
            _gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (_isEndingQuiz) return;

            if (RemainingSeconds > 0)
            {
                RemainingSeconds--;
                if (RemainingSeconds == 0)
                {
                    EndQuiz();
                }
            }
        }

        private void DelayTimer_Tick(object sender, EventArgs e)
        {
            if (_isEndingQuiz) return;

            _delayTimer.Stop();
            GenerateQuiz();
        }

        private void GenerateQuiz()
        {
            if (!_isQuizActive || _isEndingQuiz) return;

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
                        EndQuiz();
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
            if (!IsAnsweringEnabled || !_isQuizActive || _isEndingQuiz) return;

            IsAnsweringEnabled = false;

            var newStates = new List<string> { "", "", "", "" };
            bool isCorrect = false;

            for (int i = 0; i < PossibleAnswers.Count; i++)
            {
                if (PossibleAnswers[i].Id == CurrentActor.Id)
                {
                    newStates[i] = "Correct";
                    if (selectedActor?.Id == CurrentActor.Id)
                        isCorrect = true;
                }
                else if (PossibleAnswers[i].Id == selectedActor?.Id)
                {
                    newStates[i] = "Incorrect";
                }
            }
            AnswerStates = newStates;

            _answerHistory.Add(new AnswerRecord
            {
                CorrectActor = CurrentActor,
                SelectedActor = selectedActor,
                IsCorrect = isCorrect
            });

            if (isCorrect) Score++;

            _delayTimer.Start();
        }

        public void EndQuiz(bool skipResults = false)
        {
            if (_isEndingQuiz) return;
            _isEndingQuiz = true;

            // Gasimo tajmere
            _gameTimer.Stop();
            _delayTimer.Stop();

            IsQuizActive = false;
            IsAnsweringEnabled = false;

            if (!skipResults && _answerHistory.Count > 0)
            {
                var resultsViewModel = new QuizResultsViewModel(Score, _answerHistory.Count, _answerHistory, GameMode.Timed);
                var resultsWindow = new QuizResultsWindow
                {
                    DataContext = resultsViewModel
                };

                resultsViewModel.PlayAgainRequested += (s, e) =>
                {
                    resultsWindow.Close();
                    RestartQuiz(); // ili InnerRestartQuiz()
                };
                _currentQuizWindow?.Close();
                resultsWindow.ShowDialog();
            }
        }

        private void RestartQuiz()
        {
            _isEndingQuiz = true;

            DisposeTimers();

            _currentQuizWindow?.Close();

            var newWindow = new QuizWindow();
            newWindow.Show();
        }

        private void InnerRestartQuiz()
        {
            _isEndingQuiz = true;
            _isQuizActive = false;
            _isAnsweringEnabled = false;

            DisposeTimers();

            _usedActorIds = new HashSet<int>();
            _answerHistory = new List<AnswerRecord>();
            Score = 0;
            AnswerStates = new List<string> { "", "", "", "" };

            _isEndingQuiz = false;
            _isQuizActive = true;
            _isAnsweringEnabled = true;

            _delayTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
            _delayTimer.Tick += DelayTimer_Tick;

            _gameTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _gameTimer.Tick += GameTimer_Tick;

            RemainingSeconds = 30;

            GenerateQuiz();
            StartTimer();
        }


        public void DisposeTimers()
        {
            if (_delayTimer != null)
            {
                _delayTimer.Stop();
                _delayTimer.Tick -= DelayTimer_Tick;
            }
            if (_gameTimer != null)
            {
                _gameTimer.Stop();
                _gameTimer.Tick -= GameTimer_Tick;
            }
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
