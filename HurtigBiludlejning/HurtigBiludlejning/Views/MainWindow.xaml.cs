using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ReturnCar_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to RentalReturnWindow
            RentalReturnWindow rentalReturnPage = new RentalReturnWindow();
            MainFrame.Content = rentalReturnPage;
        }
        private void CarPoolManagement_Click(object sender, RoutedEventArgs e)
        {
            //Navigate to Car Pool Management
            CarPoolWindow carPoolWindow = new CarPoolWindow();
            MainFrame.Content = carPoolWindow;
        }

        private void Reservations_Click(object sender, RoutedEventArgs e)
        {
            BookingWindow bookingWindow = new BookingWindow();
            MainFrame.Content = bookingWindow;
        }

    }
}