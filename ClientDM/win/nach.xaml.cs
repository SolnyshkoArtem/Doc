using FDocmanInter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
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
    
    public partial class nach : Page
    {
        ChannelFactory<IDocService> channelFactory;
        IDocService proxy;
        int id;
        List<string> letters = new List<string>();
        public nach(int a)
        {
            InitializeComponent();
            channelFactory = new ChannelFactory<IDocService>("DocManServiceEndPoint");
            proxy = channelFactory.CreateChannel();

            
            letters = proxy.GetAllLetters(a);
            listOfLeters.ItemsSource = letters;
            id = a;
            
        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {
            
        }


        private void btnExit_click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                listOfLeters.ItemsSource = letters.Where(item => item == poisk.Text).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void listOfLeters_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ConcrLetter concrLetter = new ConcrLetter(listOfLeters.SelectedItem.ToString());
            concrLetter.Show();
        }
    }
}
