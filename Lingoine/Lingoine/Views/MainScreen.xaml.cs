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
                this.UpdateLayout();
            }
            else if ((string)App.Current.Properties["UserLevel"] == "1")
            {
                Expert.IsEnabled = false;
                this.UpdateLayout();
            }
            var client = new RestClient("http://localhost:3257/");
            var request = new RestRequest("api/UserTables/", Method.GET);
            var queryResult = client.Execute<List<Models.User>>(request).Data;
            string username = queryResult[0].Username;
            title.Text = "Welcome " + username + "!";
        }

        private void Interact_Click(object sender, RoutedEventArgs e)
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
            String username = "facebook:welcomenikul";
            skype.Client.OpenMessageDialog(username);

            //Call newCall = skype.PlaceCall(username);
            //do
            //{
            //    System.Threading.Thread.Sleep(1);
            //} while (newCall.Status != TCallStatus.clsInProgress);
            //newCall.StartVideoSend();
            ////newCall.VideoStatus.ToString();

            this.NavigationService.Navigate(new RatingScreen());

        }

        private void Expert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Explore_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
