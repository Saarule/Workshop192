using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop192.UserManagment
{
    public class Appointment
    {
        private StoreOwner father;
        private StoreOwner child;

        public Appointment(StoreOwner father, StoreOwner child)
        {
            this.father = father;
            this.child = child;
        }

        public StoreOwner GetFather()
        {
            return father;
        }

        public StoreOwner GetChild()
        {
            return child;
        }
    }
}
