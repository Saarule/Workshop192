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
                        bool ans = CheckExist(me.GetStore().GetCreator().GetStoreOwners().ElementAt(i),user);
                        if (ans) //true -> exist in tree - not good
                        {
                            return false;
                        }
                    }

                }
                me.AddOwner(user);
                return true;
            }
        }

        private static bool CheckExist(StoreOwner sO,User user)
        {
            // todo !!!!!!!!!!!!!!!!!
            return false;
        }
    }
}
