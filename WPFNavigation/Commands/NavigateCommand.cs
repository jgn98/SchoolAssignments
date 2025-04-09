using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using WPFNavigation.Stores;
using WPFNavigation.ViewModel;
using WPFNavigation.Service;
using NavigationService = WPFNavigation.Service.NavigationService;

namespace WPFNavigation.Commands
{
    public class NavigateCommand : ICommand
    {
        private readonly NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }

        public event EventHandler? CanExecuteChanged;

        


    }
}
