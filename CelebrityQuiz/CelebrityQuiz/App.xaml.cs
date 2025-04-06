using System;
using System.Windows;
using MaterialDesignThemes.Wpf;

namespace CelebrityQuiz
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        public void ChangeTheme(bool isDarkTheme)
        {
            var paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();

            theme.SetBaseTheme(isDarkTheme ? BaseTheme.Dark : BaseTheme.Light);
            paletteHelper.SetTheme(theme);
        }
    }
}

