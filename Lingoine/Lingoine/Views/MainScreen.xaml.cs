using RestSharp;
using SKYPE4COMLib;
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
using Lingoine.Models;
using Lingoine.Utils;

namespace Lingoine.Views
{
    /// <summary>
    /// Interaction logic for MainScreen.xaml
    /// </summary>
    public partial class MainScreen : Page
    {
        public MainScreen()
        {
            InitializeComponent();
            if ((string)App.Current.Properties["UserLevel"] == "0")
            {
                Interact.IsEnabled = false;
                Expert.IsEnabled = false;
                AddLanguage.IsEnabled = false;
                this.UpdateLayout();
            }
            else if ((string)App.Current.Properties["UserLevel"] == "1")
            {
                Expert.IsEnabled = false;
                this.UpdateLayout();
            }
            Models.User currentUser = new Models.User {
                Username = "Guest"
            };
            if (App.Current.Properties["User"] == null)
            {
            }
            else
            {
                currentUser = (Models.User)App.Current.Properties["User"];
            }
            title.Text = "Welcome " + currentUser.Username + "!";
            subtitle.Text = (string)App.Current.Properties["Language"];
        }

        private void Interact_Click(object sender, RoutedEventArgs e)
        {
            Models.User currUser = (Models.User)App.Current.Properties["User"];
            string currUserEmail = currUser.Email;

            int isPremium = 0;
            if (currUser.IsPremium)
            {
                isPremium = 1;
            }

            var client = new RestClient(Constants.requestUrl);
            var request = new RestRequest("api/UserTables/getSkypeInfo/" + currUserEmail + "/" + (string)App.Current.Properties["Language"] + "/"+ isPremium.ToString() + "/", Method.GET);
            var response = client.Execute(request);
            string data = (string)response.Content;
            string[] information = data.Split(',');

            string connectedUser = information[0];
            string connectedUserID = information[1];

            try
            {
                Skype skype = new Skype();
                if (!skype.Client.IsRunning)
                {
                    // start minimized with no splash screen
                    skype.Client.Start(false, false);
                }

                // wait for the client to be connected and ready
                skype.Attach(6, true);

                // do some stuff
                String username = connectedUser;
                skype.Client.OpenMessageDialog(username);

                //Call newCall = skype.PlaceCall(username);
                //do
                //{
                //    System.Threading.Thread.Sleep(1);
                //} while (newCall.Status != TCallStatus.clsInProgress);
                //newCall.StartVideoSend();
                ////newCall.VideoStatus.ToString();

                var request1 = new RestRequest("api/UserTables/" + connectedUserID + "/" + currUserEmail + "/" + (string)App.Current.Properties["Language"] ] + "/", Method.GET);
                client.Execute(request1);

                this.NavigationService.Navigate(new RatingScreen());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void Expert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Explore_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Resources());
        }

        private void AddLanguage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LanguageSelect());
        }

        private void ChooseLanguage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ChooseLanguage());
        }
    }
}
