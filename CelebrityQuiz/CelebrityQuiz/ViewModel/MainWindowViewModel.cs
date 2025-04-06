using CelebrityQuiz.Model;
using CelebrityQuiz.View;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CelebrityQuiz.ViewModel
{
    public class MainWindowViewModel
    {
        public ICommand StartStandardGameCommand { get; }

        public ICommand StartTimedGameCommand { get; }
        public ICommand ShowLeaderboardCommand { get; }
        public ICommand ActorsDetailsCommand { get; }

        public MainWindowViewModel()
        {
            StartStandardGameCommand = new RelayCommand(StartStandardGame);
            StartTimedGameCommand = new RelayCommand(StartTimedGame);
            ShowLeaderboardCommand = new RelayCommand(ShowLeaderboard);
            ActorsDetailsCommand = new RelayCommand(ActorsDetails);
        }

        private void StartStandardGame()
        {


            var existingWindow = Application.Current.Windows.OfType<RegularQuizWindow>().FirstOrDefault();
            if (existingWindow != null)
            {
                if (!existingWindow.IsActive)
                {
                    existingWindow.Activate();

                    if (existingWindow.WindowState == WindowState.Minimized)
                    {
                        existingWindow.WindowState = WindowState.Normal;
                    }
                }
                existingWindow.Show();
            }
            else
            {

                var regularGameView = new RegularQuizWindow
                {
                    DataContext = new RegularQuizViewModel()
                };
                regularGameView.Show();
            }

        }

        private void StartTimedGame()
        {


            var existingWindow = Application.Current.Windows.OfType<QuizWindow>().FirstOrDefault();
            if (existingWindow != null)
            {
                if (!existingWindow.IsActive)
                {
                    existingWindow.Activate();

                    if (existingWindow.WindowState == WindowState.Minimized)
                    {
                        existingWindow.WindowState = WindowState.Normal;
                    }
                }
                existingWindow.Show();
            }
            else
            {

                var timedGameView = new QuizWindow();
                var newViewModel = new QuizViewModel(timedGameView);
                timedGameView.DataContext = newViewModel;
                timedGameView.Show();

            }

        }
        private void ShowLeaderboard()
        {
            var existingWindow = Application.Current.Windows.OfType<LeaderboardView>().FirstOrDefault();
            if (existingWindow != null)
            {
                if (!existingWindow.IsActive)
                {
                    existingWindow.Activate();

                    if (existingWindow.WindowState == WindowState.Minimized)
                    {
                        existingWindow.WindowState = WindowState.Normal;
                    }
                }
                existingWindow.Show();
            }
            else
            {

                    var leaderboardView = new LeaderboardView
                {
                    DataContext = new LeaderboardViewModel(new AppDbContextFactory().CreateDbContext(null))
                };
                leaderboardView.Show();
            }
        }

        private void ActorsDetails()
        {

            var existingWindow = Application.Current.Windows.OfType<ActorsWindow>().FirstOrDefault();
            if (existingWindow != null)
            {
                if (!existingWindow.IsActive)
                {
                    existingWindow.Activate();

                    if (existingWindow.WindowState == WindowState.Minimized)
                    {
                        existingWindow.WindowState = WindowState.Normal;
                    }
                }
                existingWindow.Show();
            }
            else
            {

                var actorsView = new ActorsWindow
                {
                    DataContext = new ActorsViewModel()
                };
                actorsView.Show();
            }

        }
    }
}