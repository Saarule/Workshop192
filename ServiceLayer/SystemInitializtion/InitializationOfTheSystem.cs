using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class InitializationOfTheSystem
    {
        bool isInitialized = false;
        private Workshop192.System system;
        public InitializationOfTheSystem()
        {
            Initalize();
        }
        public bool Initalize() {
            if (!isInitialized)
            {
                system = Workshop192.System.GetInstance();
                ConnectExternalSystems();
                CreateAdmin("FirstAdmin", "666666");
                isInitialized = true;
                return true;
            }
            return false;
        }
        private void CreateAdmin(string username, string password) {
            system.Register(username, password);
            system.GetUser(username, password).Register(username);
            system.GetUser(username, password).SetAdmin();
        }
        private void ConnectExternalSystems()
        {
            //TODO...
        }
        public bool IsInitialized()
        {
            return isInitialized;
        }
    }
}
