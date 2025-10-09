using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFNavigation.Stores;
using WPFNavigation.ViewModel;

namespace WPFNavigation.Service
{
    public class NavigationService
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<BaseViewModel> viewModelCreator;

        public NavigationService(NavigationStore navigationStore, Func<BaseViewModel> viewModelCreator)
        {
            this.navigationStore = navigationStore;
            this.viewModelCreator = viewModelCreator;
        }

        public void Navigate()
        {
            navigationStore.CurrentViewModel = viewModelCreator();
        }
    }
}
