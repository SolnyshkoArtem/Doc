﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FinalDocMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(ServiceHost host = new ServiceHost(typeof(DocService)))
            {
                host.Open();
                Console.WriteLine("cheers, mate!");
                Console.ReadLine();
            }
        }
    }
}
