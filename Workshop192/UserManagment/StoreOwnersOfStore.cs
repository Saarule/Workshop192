using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.UserManagment
{
    public class StoreOwnersOfStore
    {
        public string store { get; set; }
        public LinkedList<StoreOwner> storeOwners { get; set; }

        public StoreOwnersOfStore(StoreOwner owner)
        {
            store = owner.GetStore();
            storeOwners = new LinkedList<StoreOwner>();
            storeOwners.AddFirst(owner);
        }

        public LinkedList<StoreOwner> GetStoreOwners()
        {
            return storeOwners;
        }
    }
}
