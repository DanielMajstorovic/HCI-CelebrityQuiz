using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CelebrityQuiz.Model;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace CelebrityQuiz.ViewModel
{
    public class ActorsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Actor> _currentPageActors;
        private int _currentPage = 1;
        private int _totalPages;
        private string _searchText;
        private const int PageSize = 10;
        private CancellationTokenSource _searchCancellationTokenSource;

        public ObservableCollection<Actor> CurrentPageActors
        {
            get => _currentPageActors;
            set
            {
                _currentPageActors = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasActors));
                OnPropertyChanged(nameof(HasNoActors));
            }
        }

        public bool HasActors => CurrentPageActors != null && CurrentPageActors.Any();
        public bool HasNoActors => !HasActors;

        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
                LoadActors();
            }
        }

        public int TotalPages
        {
            get => _totalPages;
            set
            {
                _totalPages = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                DelayedSearch();
            }
        }

        public ICommand NextPageCommand { get; }
        public ICommand PreviousPageCommand { get; }

        public ActorsViewModel()
        {
            NextPageCommand = new RelayCommand(NextPage, CanNextPage);
            PreviousPageCommand = new RelayCommand(PreviousPage, CanPreviousPage);

            CurrentPageActors = new ObservableCollection<Actor>();
            Initialize();
        }

        private async void Initialize()
        {
            await UpdateTotalPages();
            LoadActors();
        }

        // Adds a small delay to avoid excessive database queries while typing
        private async void DelayedSearch()
        {
            // Cancel any previous search task
            _searchCancellationTokenSource?.Cancel();
            _searchCancellationTokenSource = new CancellationTokenSource();

            try
            {
                // Wait a short time before executing search to prevent searching on every keystroke
                await Task.Delay(200, _searchCancellationTokenSource.Token);
                await PerformSearch();
            }
            catch (TaskCanceledException)
            {
                // Search was cancelled by new input, which is expected behavior
            }
        }

        private async Task PerformSearch()
        {
            CurrentPage = 1; // Reset to first page when searching
            await UpdateTotalPages();
            LoadActors();
        }

        private async Task UpdateTotalPages()
        {
            using var context = new AppDbContextFactory().CreateDbContext(null);
            var query = context.Actors.AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                // Case-insensitive search
                var searchText = SearchText.ToLower();
                query = query.Where(a => a.Name.ToLower().Contains(searchText));
            }

            var totalActors = await query.CountAsync();
            TotalPages = (int)Math.Ceiling(totalActors / (double)PageSize);

            // Reset to page 1 if current page is out of bounds
            if (CurrentPage > TotalPages && TotalPages > 0)
            {
                CurrentPage = 1;
            }
        }

        private async void LoadActors()
        {
            using var context = new AppDbContextFactory().CreateDbContext(null);
            var query = context.Actors.AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                // Case-insensitive search
                var searchText = SearchText.ToLower();
                query = query.Where(a => a.Name.ToLower().Contains(searchText));
            }

            var actors = await query
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            CurrentPageActors.Clear();
            foreach (var actor in actors)
            {
                CurrentPageActors.Add(actor);
            }

            // Notify property changes for HasActors and HasNoActors
            OnPropertyChanged(nameof(HasActors));
            OnPropertyChanged(nameof(HasNoActors));
        }

        private void NextPage()
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
            }
        }

        private void PreviousPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
            }
        }

        private bool CanNextPage()
        {
            return CurrentPage < TotalPages;
        }

        private bool CanPreviousPage()
        {
            return CurrentPage > 1;
        }
    }
}