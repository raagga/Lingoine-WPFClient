using Lingoine.Utils;
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
    /// Interaction logic for RatingScreen.xaml
    /// </summary>
    public partial class RatingScreen : Page
    {
        public RatingScreen()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if(radioButton1.IsChecked.ToString() == "True" ||
                radioButton2.IsChecked.ToString() == "True" ||
                radioButton3.IsChecked.ToString() == "True" ||
                radioButton4.IsChecked.ToString() == "True" ||
                radioButton5.IsChecked.ToString() == "True")
            {
                this.NavigationService.Navigate(new MainScreen());
            }
            else
            {
                Alert.Text = "We appreciate your feedback :) Please choose your response";
            }
            string val = "0";
            if (radioButton1.IsChecked == true)
            {
                val = "1";
            }
            else if (radioButton2.IsChecked == true)
            {
                val = "2";
            }
            else if (radioButton3.IsChecked == true)
            {
                val = "3";
            }
            else if (radioButton4.IsChecked == true)
            {
                val = "4";
            }
            else if (radioButton5.IsChecked == true)
            {
                val = "5";
            }
            else
            {

            }
            Models.User currUser = (Models.User)App.Current.Properties["User"];

            var client = new RestClient(Constants.requestUrl);
            string query = "api/UserTables/" + (string)App.Current.Properties["TeacherID"] + "/" + currUser.Email + "/" + (string)App.Current.Properties["Language"] + "/" + val + "/";
            System.Diagnostics.Debug.WriteLine(query);
            var request = new RestRequest(query, Method.GET);
            var response = client.Execute(request);
        }
    }
}
