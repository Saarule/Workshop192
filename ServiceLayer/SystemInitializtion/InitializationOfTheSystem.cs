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
            Workshop192.MarketManagment.System system = Workshop192.MarketManagment.System.GetInstance();
            system.ConnectMoneyCollectionSystem(ConnectExternalMoneyCollectionSystems());
            system.ConnectDeliverySystem(ConnectExternalDeliverySystems());
            if (Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(0) == null)
            {
                Workshop192.UserManagment.AllRegisteredUsers.GetInstance().RegisterUser("admin", "admin");
                Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(0).SetAdmin();
            }
        }

        private MoneyCollectionSystemReal ConnectExternalMoneyCollectionSystems()
        {
            return new MoneyCollectionSystemReal();
        }

        private DeliverySystemReal ConnectExternalDeliverySystems()
        {
            return new DeliverySystemReal();
        }
    }
}
