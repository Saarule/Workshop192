using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.SystemInitializtion
{
    public class ResetSystems
    {
        public static void ResetSystem()
        {
            Workshop192.MarketManagment.System.Reset();
            Workshop192.UserManagment.AllRegisteredUsers.Reset();
        }
    }
}
