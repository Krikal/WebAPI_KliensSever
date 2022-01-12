
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace MunkafelvelvoKliens
{
    /// <summary>
    /// Interaction logic for OrderDetailsWindow.xaml
    /// </summary>
    public partial class OrderDetailsWindow : Window
    {
        private readonly Client _client;
        public OrderDetailsWindow(Client client)
        {
            InitializeComponent();
            _client = client;

            if (_client != null)
            {
                

                ClientNameTextBox.Text = _client.ClientName;
                CarTypeTextBox.Text = _client.CarType;
                CarNumberPlateTextBox.Text = _client.CarPlate;
                IssueDetailTextBox.Text = _client.IssueDeatils;
                OrderDatePicker.SelectedDate = _client.OrderDate;
                OrderStatusComboBox.Text = _client.OrderStatus;

                CreateButton.Visibility = Visibility.Collapsed;
                DeleteButton.Visibility = Visibility.Visible;
                UpdateButton.Visibility = Visibility.Visible;
            }
            else
            {
                _client = new Client();

                CreateButton.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Collapsed;
                UpdateButton.Visibility = Visibility.Collapsed;
            }
        }

        private void CreateButtonClick(object sender, RoutedEventArgs args)
        {
            if (ValidateClient())
            {
                _client.ClientName = ClientNameTextBox.Text;
                _client.CarType = CarTypeTextBox.Text;
                _client.CarPlate = CarNumberPlateTextBox.Text;
                _client.IssueDeatils = IssueDetailTextBox.Text;
                _client.OrderDate = OrderDatePicker.SelectedDate.Value;
                _client.OrderStatus = OrderStatusComboBox.Text;
                ClientDataProvider.CreateClient(_client);

                DialogResult = true;

                Close();
            }

            
        }
        private void UpdateButtonClick(object sender, RoutedEventArgs args)
        {
            if (ValidateClient())
            {
                _client.ClientName = ClientNameTextBox.Text;
                _client.CarType = CarTypeTextBox.Text;
                _client.CarPlate = CarNumberPlateTextBox.Text;
                _client.IssueDeatils = IssueDetailTextBox.Text;
                _client.OrderDate = OrderDatePicker.SelectedDate.Value;
                _client.OrderStatus = OrderStatusComboBox.Text;
                ClientDataProvider.UpdateClient(_client);

                DialogResult = true;

                Close();

            }

            

        }
        
        private void DeleteButtonClick(object sender, RoutedEventArgs args)
        {
            if (MessageBox.Show("Do you really want to deletet?","Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ClientDataProvider.DeleteClient(_client.Id);

                DialogResult = true;

                Close();
            }
        }

        private bool ValidateClient()
        {
            var regexSpecialCharacters = new Regex("^[a-zA-Z0-9 ]*$");
            var regexNumberPlate = new Regex("[A-Z]{3}-[0-9]{3}");
            if (string.IsNullOrWhiteSpace(ClientNameTextBox.Text))
            {
                MessageBox.Show("Client name box should not be empty!");
                return false;
                
                
            }
            if (!regexSpecialCharacters.IsMatch(ClientNameTextBox.Text))
            {
                MessageBox.Show("No special characters in client name!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(CarTypeTextBox.Text))
            {
                MessageBox.Show("Car type box should not be empty!");
                return false;
                
            }
            if (!regexSpecialCharacters.IsMatch(CarTypeTextBox.Text))
            {
                MessageBox.Show("No special characters in car type!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(CarNumberPlateTextBox.Text))
            {
                MessageBox.Show("Car number plate box should not be empty!");
                return false;
             
            }
            if (!regexNumberPlate.IsMatch(CarNumberPlateTextBox.Text))
            {
                MessageBox.Show("Valid form is 'XXX-111'");
                return false;
            }
            if (string.IsNullOrWhiteSpace(IssueDetailTextBox.Text))
            {
                MessageBox.Show("Issue detail box should not be empty!");
                return false;
             
            }
            if (!regexSpecialCharacters.IsMatch(IssueDetailTextBox.Text))
            {
                MessageBox.Show("No special characters in issue detail!");
                return false;
            }
            if (!OrderDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select a date of order!");
                return false;
            }

            return true;
        }
    }
}
