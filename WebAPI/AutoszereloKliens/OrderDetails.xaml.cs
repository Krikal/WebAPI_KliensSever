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
using System.Windows.Shapes;
using WebApi_common.DataProviders;
using WebApi_common.Models;

namespace AutoszereloKliens
{
    /// <summary>
    /// Interaction logic for OrderDetails.xaml
    /// </summary>
    public partial class OrderDetails : Window
    {
        private readonly Client _client;
        public OrderDetails(Client client)
        {
            InitializeComponent();
            _client = client;

            if (_client != null)
            {
                

                OrderStatusComboBox.SelectedItem = _client.OrderStatus;

                SaveButton.Visibility = Visibility.Visible;
                CancelButton.Visibility = Visibility.Visible;
            }
        }

        private void SaveButtonClick( object sender, RoutedEventArgs args)
        {
            _client.OrderStatus = OrderStatusComboBox.Text;
            ClientDataProvider.UpdateClient(_client);

            DialogResult = true;

            Close();

        }
        private void CancelButtonClick(object sender, RoutedEventArgs args)
        {
            DialogResult = true;

            Close();
        }
    }
}
