using FDocmanInter;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для doc.xaml
    /// </summary>
    public partial class doc : Page
    {
        ChannelFactory<IDocService> channelFactory;
        IDocService proxy;
        List<string> strings= new List<string>();
        public doc()
        {
            InitializeComponent();
            channelFactory = new ChannelFactory<IDocService>("DocManServiceEndPoint");
            proxy = channelFactory.CreateChannel();
            strings = proxy.GetListOfLetters();
            letters.ItemsSource = strings;
        }
        

        private void btnDelete_click(object sender, RoutedEventArgs e)
        {
            if (letters.SelectedItem == null)
            {
                return;
            }
            proxy.DeleteLetter(letters.SelectedItem.ToString());
            letters.ItemsSource = strings;
        }
        private void btnAdd_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new dobav());
        }

        private void btnExit_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new cho());
        }

        private void poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                letters.ItemsSource = strings.Where(item => item == poisk.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void letters_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ConcrLetterPriem concrLetter = new ConcrLetterPriem(letters.SelectedItem.ToString());
            concrLetter.Show();
        }
    }
}
