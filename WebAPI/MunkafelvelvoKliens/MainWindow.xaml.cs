using WebApi_common.DataProviders;
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
using WebApi_common.Models;

namespace MunkafelvelvoKliens
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateOrderListBox();
        }

        private void OrderListBox_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var SelectedOrder = OrderListBox.SelectedItem as Client;

            if (SelectedOrder != null)
            {
                var window = new OrderDetailsWindow(SelectedOrder);
                if (window.ShowDialog() ?? false)
                {
                    UpdateOrderListBox();
                }
                OrderListBox.UnselectAll();
                //UpdateOrderListBox();
            }

        }

        private void AddOrderClicked(object sender, RoutedEventArgs args)
        {
            var window = new OrderDetailsWindow(null);
            if (window.ShowDialog() ?? false)
            {
                UpdateOrderListBox();
            }

        }
        private void UpdateOrderListBox()
        {
            var clients = ClientDataProvider.GetClients().ToList();
            OrderListBox.ItemsSource = clients;

        }

    }
}
