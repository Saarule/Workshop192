using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceLayer.SystemInitializtion.InitializationOfTheSystem sys = new ServiceLayer.SystemInitializtion.InitializationOfTheSystem();
            sys.Initalize(null);
        }
    }
}
