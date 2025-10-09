using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using WPFNavigation.Commands;
using WPFNavigation.Stores;
using NavigationService = WPFNavigation.Service.NavigationService;


namespace WPFNavigation.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        private NavigationService navigationService;
        private NavigationStore navigationStore;

        public ICommand NavigateToFirstViewCommand { get; }
        public ICommand NavigateToSecondViewCommand { get; }



        public HomeViewModel(NavigationStore navigationStore, NavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.navigationStore = navigationStore;

            NavigateToFirstViewCommand = new NavigateCommand(new NavigationService(navigationStore, () => new FirstViewModel(navigationStore,navigationService)));
            NavigateToSecondViewCommand = new NavigateCommand(new NavigationService(navigationStore,() => new SecondViewModel(navigationStore,navigationService)));

        }
    }
}
