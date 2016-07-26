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
using Lingoine.Utils;

namespace Lingoine.Views
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Page
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new RestClient(Constants.requestUrl);
            var request = new RestRequest("api/UserTables/"+textBoxUserName.Text, Method.GET);
            var queryResult = client.Execute<Models.User>(request).Data;
            if (queryResult.Password == textBoxPassword.Password)
            {
                App.Current.Properties["User"] = queryResult;
                if (queryResult.IsPremium == true)
                {
                    App.Current.Properties["UserLevel"] = 2;
                }
                else
                {
                    App.Current.Properties["UserLevel"] = 1;
                }
                this.NavigationService.Navigate(new MainScreen());
            }
            else
            {
                Alert.Text = "Wrong Password!";
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WelcomeScreen());
        }
    }
}
