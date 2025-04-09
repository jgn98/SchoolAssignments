using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFNavigation.ViewModel;
using NavigationService = WPFNavigation.Service.NavigationService;


namespace WPFNavigation.Stores
{
    public class NavigationStore
    {
        private BaseViewModel _currentViewModel;
        private readonly NavigationService _navigationService;

        public event Action CurrentViewModelChanged;


        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        protected virtual void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public NavigationStore()
        {
            
            _currentViewModel = new HomeViewModel(this, _navigationService);
        }
    }
}
    