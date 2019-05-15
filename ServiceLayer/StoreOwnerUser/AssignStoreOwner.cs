using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.UserManagment;

namespace ServiceLayer.Store_Owner_User
{
    public class AssignStoreOwner
    {
        public AssignStoreOwner()
        {

        }
        public static bool AssignStOwn(StoreOwner me , User user)
        {
            if (me.GetUser().IsLoggedIn() == false)
                return false;
            else
            {
                for (int i = 0; i < me.GetStore().GetCreator().GetStoreOwners().Count; i++) {
                    if (me.GetStore().GetCreator().GetStoreOwners().ElementAt(i).GetStore().Equals(me.GetStore())) {
                        bool ans = false;
                        CheckExist(me.GetStore().GetCreator().GetStoreOwners().ElementAt(i), user, ans);
                        if (!ans) //true -> exist in tree - not good
                        {
                            return false;
                        }
                    }

                }
                me.AddOwner(user);
                return true;
            }
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
