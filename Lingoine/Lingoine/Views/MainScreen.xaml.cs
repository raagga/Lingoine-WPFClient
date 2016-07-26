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
        }

        private void Interact_Click(object sender, RoutedEventArgs e)
        {

            Skype skype = new Skype();
            skype.Client.Start(false, false);

            if (!skype.Client.IsRunning)
            {
                // start minimized with no splash screen
                skype.Client.Start(false, false);
                //skype.Client.Start
            }

            // wait for the client to be connected and ready
            skype.Attach(6, true);
            
            //// access skype objects
            Console.WriteLine("Missed message count: {0}", skype.MissedMessages.Count);

            //// do some stuff
            Console.WriteLine("enter a skype name to search for: ");
            String username = "facebook:welcomenikul";
            skype.Client.OpenMessageDialog(username);

        }

private void Expert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Explore_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
