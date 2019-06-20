using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunicationLayer.Controllers
{
    public class CreateWorld
    {
        public static void Init()
        {
            ServiceLayer.SystemInitializtion.InitializationOfTheSystem sys = new ServiceLayer.SystemInitializtion.InitializationOfTheSystem();
            sys.Initalize("c:\\initFile");
        }
    }
}