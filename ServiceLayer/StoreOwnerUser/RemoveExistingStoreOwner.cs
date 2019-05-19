using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;

namespace ServiceLayer.Store_Owner_User
{
    // use case 4.4 - Remove exisiting store owner
    class RemoveExistingStoreOwner
    {
        public static bool RemoveStoreOwner(StoreOwner Im ,StoreOwner toRemove)
        {
            return Im.RemoveChild(toRemove);
        }
    }
}
