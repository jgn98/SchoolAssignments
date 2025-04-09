using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Xaml;
using WPFNavigation.Commands;
using WPFNavigation.Stores;
using WPFNavigation.Service;
using NavigationService = WPFNavigation.Service.NavigationService;

namespace WPFNavigation.ViewModel
{
    public class FirstViewModel : BaseViewModel
    {
        private NavigationStore _navigationStore;
        public ICommand NavigateToHomeViewCommand { get; }

        private readonly NavigationService navigationService;
        public NavigateCommand NavigateCommand { get; }

        public FirstViewModel(NavigationStore navigationStore, NavigationService navigationService)
        {
            this.navigationService = navigationService;
            this._navigationStore = navigationStore;
            NavigateToHomeViewCommand = new NavigateCommand(new NavigationService(navigationStore, () => new HomeViewModel(navigationStore, navigationService)));

        }
    }
}
