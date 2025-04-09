using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFNavigation.Commands;
using WPFNavigation.Stores;
using NavigationService = WPFNavigation.Service.NavigationService;


namespace WPFNavigation.ViewModel
{
    public class SecondViewModel : BaseViewModel
    {
        private NavigationStore navigationStore;
        public NavigateCommand NavigateCommand { get; }
        private readonly NavigationService navigationService;
        public ICommand NavigateToHomeViewCommand { get; }


        public SecondViewModel(NavigationStore navigationStore, NavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.navigationStore = navigationStore;
            NavigateToHomeViewCommand = new NavigateCommand(new NavigationService(navigationStore, () => new HomeViewModel(navigationStore, navigationService)));


        }
    }
}
