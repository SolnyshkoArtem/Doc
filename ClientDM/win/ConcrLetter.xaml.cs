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
using System.Windows.Shapes;

namespace ClientDM.win
{
    /// <summary>
    /// Логика взаимодействия для ConcrLetter.xaml
    /// </summary>
    public partial class ConcrLetter : Window
    {
        ChannelFactory<IDocService> channelFactory;
        IDocService proxy;
        
        string id;
        public ConcrLetter(string a)
        {
            InitializeComponent();
            channelFactory = new ChannelFactory<IDocService>("DocManServiceEndPoint");
            proxy = channelFactory.CreateChannel();
            id = a;
            var list = proxy.GetConcrLetter(a);
            _1.Text = list[0];
            _2.Text = list[1];
            _3.Text = list[2];
            _4.Text = list[3];
            _5.Text = list[4];
        }

        private void ForPDF_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
