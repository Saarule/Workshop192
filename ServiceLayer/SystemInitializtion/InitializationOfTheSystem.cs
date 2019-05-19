using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192;

namespace ServiceLayer
{
    public class InitializationOfTheSystem
    {
        // use case 1.1 - Initialization of the system
        public void Initalize() {
            Workshop192.System system = Workshop192.System.GetInstance();
            MoneyCollectionSystemReal real = ConnectExternalMoneyCollectionSystems();
            system.ConnectMoneyCollectionSystem(real);
            if (system.GetUser("admin", "admin") == null)
            {
                system.Register("admin", "admin");
                system.GetUser("admin", "admin").SetAdmin();
            }
        }

        private MoneyCollectionSystemReal ConnectExternalMoneyCollectionSystems()
        {
            return new MoneyCollectionSystemReal();
        }
    }
}
