using HurtigBiludlejning.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HurtigBiludlejning
{
    /// <summary>
    /// Interaction logic for CarPoolStatusWindow.xaml
    /// </summary>
    public partial class CarPoolStatusWindow : Page
    {
        private CarViewModel cvm = new CarViewModel();
        public CarPoolStatusWindow()
        {
            InitializeComponent();
            DataContext = cvm;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
       
    }
}
