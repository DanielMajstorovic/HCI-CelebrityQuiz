using CelebrityQuiz.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace CelebrityQuiz.ViewModel
{
    public class LeaderboardViewModel : INotifyPropertyChanged
    {
        private readonly AppDbContext _context;
        private ObservableCollection<LeaderboardItemViewModel> _standardLeaderboard;
        private ObservableCollection<LeaderboardItemViewModel> _timedLeaderboard;
        private bool _isStandardSelected = true;

        public LeaderboardViewModel(AppDbContext context)
        {
            _context = context;
            LoadLeaderboards();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            SelectStandardCommand = new RelayCommand(() => IsStandardSelected = true);
            SelectTimedCommand = new RelayCommand(() => IsStandardSelected = false);
        }

        public ICommand SelectStandardCommand { get; private set; }
        public ICommand SelectTimedCommand { get; private set; }

        public bool IsStandardSelected
        {
            get => _isStandardSelected;
            set
            {
                if (_isStandardSelected != value)
                {
                    _isStandardSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<LeaderboardItemViewModel> StandardLeaderboard
        {
            get => _standardLeaderboard;
            set
            {
                _standardLeaderboard = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<LeaderboardItemViewModel> TimedLeaderboard
        {
            get => _timedLeaderboard;
            set
            {
                _timedLeaderboard = value;
                OnPropertyChanged();
            }
        }

        private async void LoadLeaderboards()
        {
            var standardEntries = await _context.Leaderboards
                .Where(l => l.Mode == GameMode.Standard)
                .OrderByDescending(l => l.Score)
                .ToListAsync();

            var timedEntries = await _context.Leaderboards
                .Where(l => l.Mode == GameMode.Timed)
                .OrderByDescending(l => l.Score)
                .ToListAsync();

            StandardLeaderboard = new ObservableCollection<LeaderboardItemViewModel>(
                standardEntries.Select((entry, index) => new LeaderboardItemViewModel(entry, index + 1)));

            TimedLeaderboard = new ObservableCollection<LeaderboardItemViewModel>(
                timedEntries.Select((entry, index) => new LeaderboardItemViewModel(entry, index + 1)));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class LeaderboardItemViewModel
    {
        public LeaderboardItemViewModel(Leaderboard leaderboard, int rank)
        {
            PlayerName = leaderboard.PlayerName;
            Score = leaderboard.Score;
            Rank = rank;
            IsFirstPlace = rank == 1;
        }

        public string PlayerName { get; }
        public int Score { get; }
        public int Rank { get; }
        public bool IsFirstPlace { get; }
    }
}