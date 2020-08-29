using FriendOrganizer.UI.Event;
using FriendOrganizer.UI.View.Services;
using Prism.Events;
using System;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Func<IFriendDetailViewModel> _friendDetailViewModelCreator;
        private IEventAggregator _eventAggregator;
        private IMessageDialogService _messageDialogService;
        private IFriendDetailViewModel _friendDetailViewModel;

        public INavigationViewModel NavigationViewModel { get; }

        public IFriendDetailViewModel FriendDetailViewModel
        {
            get { return _friendDetailViewModel; }
            private set
            {
                _friendDetailViewModel = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(INavigationViewModel navigationViewModel, Func<IFriendDetailViewModel> friendDetailViewModelCreator, IEventAggregator eventAggregator, IMessageDialogService messageDialogService)
        {
            _friendDetailViewModelCreator = friendDetailViewModelCreator;
            _eventAggregator = eventAggregator;
            _messageDialogService = messageDialogService;

            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(OnOpenFriendDetailView);

            NavigationViewModel = navigationViewModel;
        }

        private async void OnOpenFriendDetailView(int friendId)
        {
            if ((FriendDetailViewModel != null) && (FriendDetailViewModel.HasChanges))
            {
                var result = _messageDialogService.ShowDialog("You've made changes, Navigate away", "Question");
                if (result == MessageDialogResult.Cancel)
                {
                    return;
                }
            }
            FriendDetailViewModel = _friendDetailViewModelCreator();
            await FriendDetailViewModel.LoadAsync(friendId);
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }
    }
}