using FDocmanInter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
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


namespace ClientDM.win
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        ChannelFactory<IDocService> channelFactory;
        IDocService proxy;
        DealFiles a = new DealFiles();
        public Admin()
        {
            InitializeComponent();
            channelFactory = new ChannelFactory<IDocService>("DocManServiceEndPoint");
            proxy = channelFactory.CreateChannel();
            users.ItemsSource = proxy.GetUsers();
            

        }
        string path;
        private void choose(object sender, RoutedEventArgs e)
        {

            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".pdf"; // Default file extension
            dialog.Multiselect= true;

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
                path = filename;
                
            }


            proxy.SetPath(path);
            File.WriteAllText(path, proxy.ReturnPath());
            


            //a.Seta(proxy.ReturnPath());


        }

        private void btnDelete_click(object sender, RoutedEventArgs e)
        {
            if (users.SelectedItem != null) proxy.DeleteUser(users.SelectedItem.ToString());
        }

        private void btnAdd_click(object sender, RoutedEventArgs e)
        {
            NewUser newUser = new NewUser();
            newUser.Show();
        }

        private void btnExit_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new page());
        }
    }
}
