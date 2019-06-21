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

        public static LinkedList<LinkedList<string>> GetRolesOfStore(string storeName)
        {
            LinkedList<LinkedList<string>> roles = new LinkedList<LinkedList<string>>();
            for (int i=0; i < Workshop192.UserManagment.AllRegisteredUsers.GetInstance().getUserInfo().Count; i++)
            {
                bool toStop1 = false;
                bool toStop2 = false;

                if (Workshop192.UserManagment.AllRegisteredUsers.GetInstance().getUserInfo().ElementAt(i).GetStoreOwners() != null)
                {
                    for (int ii = 0; !toStop1 && ii < Workshop192.UserManagment.AllRegisteredUsers.GetInstance().getUserInfo().ElementAt(i).GetStoreOwners().Count; ii++)
                    {
                        if (Workshop192.UserManagment.AllRegisteredUsers.GetInstance().getUserInfo().ElementAt(i).GetStoreOwners().ElementAt(ii).GetStore().Equals(storeName))
                        {
                            LinkedList<string> toAdd = new LinkedList<string>();
                            toAdd.AddLast(Workshop192.UserManagment.AllRegisteredUsers.GetInstance().getUserInfo().ElementAt(i).GetUserName());
                            toAdd.AddLast("Store Owner");
                            roles.AddLast(toAdd);
                            toStop1 = true;
                        }
                    }
                }

                if (Workshop192.UserManagment.AllRegisteredUsers.GetInstance().getUserInfo().ElementAt(i).GetStoreManagers() != null)
                {
                    for (int ii = 0; !toStop2 && ii < Workshop192.UserManagment.AllRegisteredUsers.GetInstance().getUserInfo().ElementAt(i).GetStoreManagers().Count; ii++)
                    {
                        if (Workshop192.UserManagment.AllRegisteredUsers.GetInstance().getUserInfo().ElementAt(i).GetStoreManagers().ElementAt(ii).GetStore().Equals(storeName))
                        {
                            LinkedList<string> toAdd = new LinkedList<string>();
                            toAdd.AddLast(Workshop192.UserManagment.AllRegisteredUsers.GetInstance().getUserInfo().ElementAt(i).GetUserName());
                            toAdd.AddLast("Store Manager");
                            roles.AddLast(toAdd);
                            toStop2 = true;
                        }
                    }
                }

            }
            return roles;
        }
    }
}