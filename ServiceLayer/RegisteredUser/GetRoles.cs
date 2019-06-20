using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RegisteredUser
{
    public class GetRoles
    {
        public static LinkedList<LinkedList<string>> getRoles(int userID)
        {
            LinkedList<LinkedList<string>> Roles = new LinkedList<LinkedList<string>>();

            if (Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userID).GetInfo().GetStoreOwners() != null)
            {
                for (int i = 0; i < Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userID).GetInfo().GetStoreOwners().Count; i++)
                {
                    LinkedList<string> toAdd = new LinkedList<string>();
                    toAdd.AddLast("Store Owner");
                    toAdd.AddLast(Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userID).GetInfo().GetStoreOwners().ElementAt(i).GetStore());
                    Roles.AddLast(toAdd);
                }
            }
            if (Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userID).GetInfo().GetStoreManagers() != null)
            {
                for (int i = 0; i < Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userID).GetInfo().GetStoreManagers().Count; i++)
                {
                    LinkedList<string> toAdd = new LinkedList<string>();
                    toAdd.AddLast("Store Manager");
                    toAdd.AddLast(Workshop192.UserManagment.AllRegisteredUsers.GetInstance().GetUser(userID).GetInfo().GetStoreManagers().ElementAt(i).GetStore());
                    Roles.AddLast(toAdd);
                }
            }

            return Roles;
        }

    }
}
