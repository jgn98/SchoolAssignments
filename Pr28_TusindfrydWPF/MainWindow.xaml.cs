﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<FlowerSort> flowersorts;
        public MainWindow()
        {
            InitializeComponent();
            flowersorts = new List<FlowerSort>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}