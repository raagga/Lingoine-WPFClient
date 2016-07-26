using Lingoine.Models;
using Lingoine.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
            if (textBoxUserName.Text == string.Empty || textBoxEmail.Text == string.Empty || passwordBox1.Password == string.Empty || passwordBoxConfirm.Password == string.Empty || (radioButtonFemale.IsChecked == false && radioButtonMale.IsChecked == false) || textBlockState.Text == string.Empty || textBoxCountry.Text == string.Empty || textBoxSkype.Text == string.Empty)
            {
                ErrorBox.Text = "You missed one or more fields";
            }
            else if (dateOfBirth.DisplayDate == DateTime.Today)
            {
                ErrorBox.Text = "You should be older";
            }
            else if (passwordBox1.Password != passwordBoxConfirm.Password)
            {
                ErrorBox.Text = "Your passwords don't match";
            }
            else
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
                var client = new RestClient(Constants.requestUrl);
                var request = new RestRequest("api/UserTables", Method.POST);
                request.RequestFormat = RestSharp.DataFormat.Json;
                User currUser = new User
                {
                    Username = textBoxUserName.Text,
                    DateOfBirth = dateOfBirth.DisplayDate,
                    State = textBlockState.Text,
                    Country = textBoxCountry.Text,
                    Email = textBoxEmail.Text,
                    Password = passwordBox1.Password,
                    SkypeId = textBoxSkype.Text,
                    IsPremium = false,
                    Gender = gender,
                    IsOnline = false,
                    IsBusy = false
                };

                request.AddBody(currUser);

                App.Current.Properties["UserLevel"] = "1";
                App.Current.Properties["User"] = currUser;

                var response = client.Execute(request);
                System.Diagnostics.Debug.WriteLine(response.Content);

                this.NavigationService.Navigate(new LanguageSelect());
            }
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
            textBlockState.Text = string.Empty;
            textBoxCountry.Text = string.Empty;
            textBoxSkype.Text = string.Empty;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WelcomeScreen());
        }
    }
}
