using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CelebrityQuiz.Model;
using Microsoft.EntityFrameworkCore;

namespace CelebrityQuiz.ViewModel
{
    public class ActorViewModel : INotifyPropertyChanged
    {
        private Actor _currentActor;

        public Actor CurrentActor
        {
            get => _currentActor;
            set
            {
                _currentActor = value;
                OnPropertyChanged();
            }
        }

        public ICommand GenerateNewActorCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ActorViewModel()
        {
            GenerateNewActorCommand = new RelayCommand(LoadRandomActor);
            LoadRandomActor();
        }

        private void LoadRandomActor()
        {
            using (var context = new AppDbContextFactory().CreateDbContext(null))
            {

                CurrentActor = context.Actors.OrderBy(a => EF.Functions.Random()).FirstOrDefault();

            }
        }
    }

}
