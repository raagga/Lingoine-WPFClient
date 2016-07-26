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
            var queryResultList = client.Execute<List<Models.User>>(request).Data;
            Models.User queryResult = new Models.User();
            if (queryResultList.Count == 0)
            {
                Alert.Text = "User Doesn't Exist";
            }
            else
            {
                queryResult = queryResultList[0];
                if (queryResult == null)
                {
                    Alert.Text = "User Doesn't Exist";
                }
                else
                {
                    if (queryResult.Password == textBoxPassword.Password)
                    {
                        App.Current.Properties["User"] = queryResult;
                        if (queryResult.IsPremium == true)
                        {
                            App.Current.Properties["UserLevel"] = "2";
                        }
                        else
                        {
                            App.Current.Properties["UserLevel"] = "1";
                        }
                        this.NavigationService.Navigate(new ChooseLanguage());
                    }
                    else
                    {
                        Alert.Text = "Wrong Password!";
                    }
                }
            }
            
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WelcomeScreen());
        }
    }
}
