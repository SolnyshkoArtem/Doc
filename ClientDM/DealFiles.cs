using FDocmanInter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientDM
{
    public class DealFiles
    {     
        public string r;
        ChannelFactory<IDocService> channelFactory;
        IDocService proxy;
        public void Seta(string a)
        {
            r = a;
        }

        public string newLetter(string links, string name)
        {
            channelFactory = new ChannelFactory<IDocService>("DocManServiceEndPoint");
            proxy = channelFactory.CreateChannel();
            int i = 1;
            r = File.ReadAllText(proxy.ReturnPut());
            //string path = string.Concat(r ,$"\\{name}");
            //Directory.CreateDirectory(path);
                File.Copy(links, Path.Combine(r, $"{name}.pdf"));
                i++;
            
            return Path.Combine(r, $"{name}.pdf");
        }
    }
}
