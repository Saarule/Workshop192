using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.SystemInitializtion
{
    public class SystemReset
    {
        public static void Reset()
        {
            Workshop192.MarketManagment.System.Reset();
            Workshop192.UserManagment.AllRegisteredUsers.Reset();
        }
    }
}
