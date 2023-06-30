using FDocmanInter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
    /// Логика взаимодействия для ConcrLetterPriem.xaml
    /// </summary>
    public partial class ConcrLetterPriem : Window
    {
        ChannelFactory<IDocService> channelFactory;
        IDocService proxy;
        string id;
        string trueId;
        List<string> list = new List<string>();
        public ConcrLetterPriem(string a)
        {
            InitializeComponent();
            channelFactory = new ChannelFactory<IDocService>("DocManServiceEndPoint");
            proxy = channelFactory.CreateChannel();
            id = a;
            list = proxy.GetConcrLetter(a);
            _1.Text = list[0];
            _2.Text = list[1];
            _3.Text = list[2];
            _4.Text = list[3];
            _5.Text = list[4];
            _7.Text = list[6];
            trueId = list[7];
        }

        private void ForPDF_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(list[5]);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            _1.IsReadOnly = false;
            _2.IsReadOnly = false;
            _3.IsReadOnly = false;
            _4.IsReadOnly = false;
            _5.IsReadOnly = false;
            _7.IsReadOnly = false;
            CultureInfo info = new CultureInfo("ru");
            


            var i = DateTime.Parse(_4.Text, info, DateTimeStyles.AdjustToUniversal);


        }

        private void Savea_Click(object sender, RoutedEventArgs e)
        {
            List<string> lost = new List<string>();
            lost.Add(_1.Text);
            lost.Add(_2.Text);
            lost.Add(_3.Text);
            lost.Add(_7.Text);
            lost.Add(_4.Text);
            lost.Add(_5.Text);
            lost.Add(trueId);
            string _;
            _ = proxy.UpdateLetter(lost);
        }
    }
}
