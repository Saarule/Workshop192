using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;

namespace ServiceLayer.Store_Owner_User
{
    class AssignStoreManager
    {
        public bool AsssignManager(StoreOwner owner, User user)
        {
            if (!owner.GetUser().IsLoggedIn())
                return false;
            foreach (StoreOwner tmp in owner.GetStore().GetCreator().GetStoreOwners())
                if (tmp.GetStore().Equals(owner.GetStore()))
                {
                    bool ans = true;
                    CheckExist(tmp, user, ans);
                    if (!ans)
                        return false;
                }
            return true;
        }

        private static void CheckExist(StoreOwner storeOwner, User user, bool ans)
        {
            if (storeOwner.GetUser().Equals(user))
                ans = true;
            else
                foreach (StoreOwner child in storeOwner.GetChildren())
                    CheckExist(child, user, ans);
        }
    }
}
