using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.UserManagment
{
    public class StoreOwnersOfStore
    {
        private LinkedList<StoreOwner> storeOwners;

        public StoreOwnersOfStore(StoreOwner owner)
        {
            storeOwners = new LinkedList<StoreOwner>();
            storeOwners.AddFirst(owner);
        }

        public LinkedList<StoreOwner> GetStoreOwners()
        {
            return storeOwners;
        }
    }
}
