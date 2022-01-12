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
using WebApi_common.DataProviders;
using WebApi_common.Models;

namespace AutoszereloKliens
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

        private void ListBox_OrderSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var selectedOrder = OrderListBox.SelectedItem as Client;

            if (selectedOrder != null)
            {
                var window = new OrderDetails(selectedOrder);
                if (window.ShowDialog() ?? false)
                {
                    UpdateOrderListBox();
                }
            }
        }

        private void UpdateOrderListBox()
        {
            var orders = ClientDataProvider.GetClients().ToList();
            OrderListBox.ItemsSource = orders;
        }
    }
}
