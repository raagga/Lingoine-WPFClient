using Lingoine.Models;
using RestSharp;
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

namespace Lingoine.Views
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            bool gender = true;
            if (radioButtonMale.IsChecked == true)
            {
                gender = true;
            }
            else if (radioButtonFemale.IsChecked == true)
            {
                gender = false;
            } 
            var client = new RestClient("http://requestb.in/1ced5701");
            var request = new RestRequest("", Method.POST);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(new User
            {
                Username = textBoxUserName.Text,
                DateOfBirth = dateOfBirth.DisplayDate,
                State = "State",
                Country = "Country",
                Email = textBoxEmail.Text,
                Password = passwordBox1.Password,
                SkypeId = "skypeID",
                IsPremium = false,
                Gender = gender,
                IsOnline = false,
                IsBusy = false
            });
            var response = client.Execute(request);
            System.Diagnostics.Debug.WriteLine(response);
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxUserName.Text = string.Empty;
            dateOfBirth.DisplayDate = DateTime.Today;
            textBoxEmail.Text = string.Empty;
            passwordBox1.Password = string.Empty;
            passwordBoxConfirm.Password = string.Empty;
            radioButtonFemale.IsChecked = false;
            radioButtonMale.IsChecked = false;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainScreen());
        }
    }
}
