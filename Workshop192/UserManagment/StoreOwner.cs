using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192.MarketManagment;

namespace Workshop192.UserManagment
{
    public class StoreOwner
    {
        private UserInfo user;
        private string store;
        private LinkedList<Appointment> appointedOwners;
        private LinkedList<StoreManager> appointedManagers;
        private Appointment father;

        public StoreOwner(UserInfo user, string store, StoreOwner father)
        {
            this.user = user;
            this.store = store;
            this.father = new Appointment(father, this);
            appointedOwners = new LinkedList<Appointment>();
            appointedManagers = new LinkedList<StoreManager>();
        }

        public void AddProducts(Product product, int amount)
        {
            MarketManagment.System.GetInstance().GetStore(store).AddProducts(product, amount);
        }

        public bool RemoveProductFromInventory(Product product)
        {
            return MarketManagment.System.GetInstance().GetStore(store).RemoveProductFromInventory(product);
        }

        public bool EditProduct(Product product, string name, string category, int price)
        {
            return MarketManagment.System.GetInstance().GetStore(store).EditProduct(product, name, category, price);
        }

        public bool AddOwner(UserInfo user)
        {
            if (CheckUserExists(user))
                return false;
            StoreOwner owner = new StoreOwner(user, store, this);
            user.GetStoreOwners().AddLast(owner);
            appointedOwners.AddLast(new Appointment(this, owner));
            return true;
        }

        public bool AddManager(UserInfo user, bool[] privileges)
        {
            if (CheckUserExists(user))
                return false;
            StoreManager manager = new StoreManager(user, store, privileges);
            user.GetStoreManagers().AddLast(manager);
            appointedManagers.AddLast(manager);
            return true;
        }

        public bool RemoveAppointedOwner(StoreOwner child)
        {
            foreach (Appointment appointment in appointedOwners)
                if (appointment.GetChild().Equals(child))
                    return ForceRemove(child);
            return false;
        }

        public bool ForceRemove(StoreOwner owner)
        {
            bool result = true;
            while (owner.appointedManagers.Count > 0)
            {
                owner.appointedManagers.First.Value.GetUser().GetStoreManagers().Remove(owner.appointedManagers.First.Value);
                owner.appointedManagers.RemoveFirst();
            }
            while (owner.appointedOwners.Count > 0)
                result = result && ForceRemove(owner.appointedOwners.First.Value.GetChild());
            return owner.user.GetStoreOwners().Remove(owner) && owner.father.GetFather().appointedOwners.Remove(owner.father) && result;
        }

        public bool RemoveAppointedManager(StoreManager child)
        {
            foreach (StoreManager manager in appointedManagers)
                if (manager.Equals(child))
                {
                    manager.GetUser().GetStoreManagers().Remove(manager);
                    appointedManagers.Remove(manager);
                    return true;
                }
            return false;
        }

        public void RemoveSelf()
        {
            while (appointedManagers.Count > 0)
            {
                appointedManagers.First.Value.GetUser().GetStoreManagers().Remove(appointedManagers.First.Value);
                appointedManagers.RemoveFirst();
            }
            while (appointedOwners.Count > 0)
            {
                ForceRemove(appointedOwners.First.Value.GetChild());
            }
            user.GetStoreOwners().Remove(this);
            if (father != null)
                foreach (Appointment appointment in father.GetFather().appointedOwners)
                {
                    if (appointment.GetChild().Equals(this))
                    {
                        father.GetFather().appointedOwners.Remove(appointment);
                        break;
                    }
                }
            else
                MarketManagment.System.GetInstance().GetAllStores().Remove(MarketManagment.System.GetInstance().GetStore(store));
        }

        public UserInfo GetUser()
        {
            return user;
        }

        public string GetStore()
        {
            return store;
        }

        public LinkedList<Appointment> GetAppointedOwners()
        {
            return appointedOwners;
        }

        public bool CheckUserExists(UserInfo user)
        {
            StoreOwner storeOwner = this;
            while (storeOwner.father != null)
                storeOwner = storeOwner.father.GetFather();
            return CheckUserExists2(storeOwner, user);
        }

        private bool CheckUserExists2(StoreOwner storeOwner, UserInfo user)
        {
            bool ret = false;
            if (storeOwner.GetUser().Equals(user))
                return true;
            foreach (StoreManager manager in appointedManagers)
                if (manager.GetUser().Equals(user))
                    return true;
            foreach (Appointment appointment in storeOwner.appointedOwners)
                ret = ret || CheckUserExists2(appointment.GetChild(), user);
            return ret;
        }
    }
}
