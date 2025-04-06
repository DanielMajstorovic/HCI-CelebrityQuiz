using System.ComponentModel;
using System.Windows;
using CelebrityQuiz.ViewModel;

namespace CelebrityQuiz.View
{
    public partial class QuizWindow : Window
    {
        public QuizWindow()
        {
            InitializeComponent();
            DataContext = new QuizViewModel(this);

            if (DataContext is QuizViewModel viewModel)
            {
                viewModel.PropertyChanged += ViewModel_PropertyChanged;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (DataContext is QuizViewModel viewModel)
            {
                viewModel.DisposeTimers();

            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(QuizViewModel.IsDarkTheme))
            {
                UpdateTheme();
            }
        }

        private void UpdateTheme()
        {
            if (DataContext is QuizViewModel viewModel)
            {
                var app = Application.Current as App;
                app?.ChangeTheme(viewModel.IsDarkTheme);
            }
        }
    }
}
