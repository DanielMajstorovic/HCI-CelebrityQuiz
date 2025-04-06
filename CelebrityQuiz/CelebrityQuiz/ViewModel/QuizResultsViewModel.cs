using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using CelebrityQuiz.Model;
using CelebrityQuiz.View;

namespace CelebrityQuiz.ViewModel
{
    public class QuizResultsViewModel : INotifyPropertyChanged
    {
        private int _currentAnswerIndex;
        private readonly List<AnswerRecord> _answerHistory;
        private readonly GameMode gameMode;

        public int FinalScore { get; }
        public int QuestionsAnswered { get; }

        public int CurrentAnswerIndex
        {
            get => _currentAnswerIndex;
            set
            {
                if (_currentAnswerIndex != value)
                {
                    _currentAnswerIndex = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(CurrentAnswer));
                    OnPropertyChanged(nameof(CanNavigateLeft));
                    OnPropertyChanged(nameof(CanNavigateRight));
                }
            }
        }

        private string _playerName;
        public string PlayerName
        {
            get => _playerName;
            set
            {
                if (_playerName != value)
                {
                    _playerName = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(CanSaveToLeaderboard));
                }
            }
        }

        public bool CanSaveToLeaderboard => !string.IsNullOrWhiteSpace(PlayerName);

        public ICommand GoToMainMenuCommand { get; }
        public ICommand SaveToLeaderboardCommand { get; }

        public event EventHandler MainMenuRequested;

        public AnswerRecord CurrentAnswer =>
    _answerHistory.Count > 0 ? _answerHistory[CurrentAnswerIndex] : null;
        public bool CanNavigateLeft => CurrentAnswerIndex > 0;
        public bool CanNavigateRight => CurrentAnswerIndex < _answerHistory.Count - 1;

        public ICommand NavigateLeftCommand { get; }
        public ICommand NavigateRightCommand { get; }
        public ICommand PlayAgainCommand { get; }

        public event EventHandler PlayAgainRequested;
        public event PropertyChangedEventHandler PropertyChanged;

        public QuizResultsViewModel(int finalScore, int questionsAnswered, List<AnswerRecord> answerHistory, GameMode gameMode)
        {
            FinalScore = finalScore;
            QuestionsAnswered = questionsAnswered;
            _answerHistory = answerHistory;
            this.gameMode = gameMode;
            NavigateLeftCommand = new RelayCommand(NavigateLeft, () => CanNavigateLeft);
            NavigateRightCommand = new RelayCommand(NavigateRight, () => CanNavigateRight);
            PlayAgainCommand = new RelayCommand(PlayAgain);

            GoToMainMenuCommand = new RelayCommand(GoToMainMenu);
            SaveToLeaderboardCommand = new RelayCommand(SaveToLeaderboard, () => CanSaveToLeaderboard);
        }

        private void GoToMainMenu()
        {
            MainMenuRequested?.Invoke(this, EventArgs.Empty);
            Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x is QuizResultsWindow)?.Close();
        }

        private bool _isScoreSaved;
        public bool IsScoreSaved
        {
            get => _isScoreSaved;
            private set
            {
                if (_isScoreSaved != value)
                {
                    _isScoreSaved = value;
                    OnPropertyChanged();
                }
            }
        }

        private void SaveToLeaderboard()
        {
            if (CanSaveToLeaderboard)
            {
                using (var context = new AppDbContextFactory().CreateDbContext(null))
                {
                    var leaderboardEntry = new Leaderboard
                    {
                        PlayerName = PlayerName,
                        Score = FinalScore,
                        Mode = gameMode
                    };

                    context.Leaderboards.Add(leaderboardEntry);
                    context.SaveChanges();

                    IsScoreSaved = true;
                    OnPropertyChanged(nameof(CanSaveToLeaderboard));
                }
            }
        }

        private void NavigateLeft()
        {
            if (CanNavigateLeft)
                CurrentAnswerIndex--;
        }

        private void NavigateRight()
        {
            if (CanNavigateRight)
                CurrentAnswerIndex++;
        }

        private void PlayAgain()
        {
            PlayAgainRequested?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}