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

namespace WPFSimpleGUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

   

    private void Button_SU(object sender, RoutedEventArgs e)
    {
        string box1 = TB1.Text;
       

        TB1.Text = TB2.Text;
        TB2.Text = TB3.Text;
        TB3.Text = TB4.Text;
        TB4.Text = box1;

    }

    private void Button_Clear(object sender, RoutedEventArgs e)
    {
        TB1.Clear();
        TB2.Clear();
        TB3.Clear();
        TB4.Clear();
    }

    private void Button_SD(object sender, RoutedEventArgs e)
    {

        string box4 = TB4.Text;


        TB4.Text = TB3.Text;
        TB3.Text = TB2.Text;
        TB2.Text = TB1.Text;
        TB1.Text = box4;
    }
}