using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFNavigation.Stores;

namespace WPFNavigation.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public BaseViewModel CurrentViewModel
        {
            get => Nav.CurrentViewModel;
        }

        public readonly NavigationStore Nav;

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public MainViewModel(NavigationStore nav)
        {
            Nav = nav;
            Nav.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }
    }
}
