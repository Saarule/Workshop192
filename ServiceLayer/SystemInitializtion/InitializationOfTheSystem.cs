using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop192;
using ServiceLayer.Admin;
using ServiceLayer.Guest;
using ServiceLayer.RegisteredUser;
using ServiceLayer.Store_Owner_User;
using ServiceLayer.SystemInitializtion;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Specialized;

namespace ServiceLayer.SystemInitializtion
{
    public class InitializationOfTheSystem
    {
        // use case 1.1 - Initialization of the system
        public void Initalize(string Path)
        {
            Workshop192.MarketManagment.System MarketSystem = Workshop192.MarketManagment.System.GetInstance();
            Workshop192.UserManagment.AllRegisteredUsers UserSystem = Workshop192.UserManagment.AllRegisteredUsers.GetInstance();
            string URL = "https://cs-bgu-wsep.herokuapp.com";
            var postContent = new Dictionary<string, string>{
            { "action_type", "handshake" },
            };
            try
            {
                using (var wb = new WebClient())
                {
                    var data = new NameValueCollection();
                    data["action_type"] = "handshake";
                    var response = wb.UploadValues(URL, "POST", data);
                    string responseInString = Encoding.UTF8.GetString(response);
                    if (!responseInString.Equals("OK"))
                    {
                        throw new Exception("Connect to External Systems Faild");
                    }
                }
            }
            catch (Exception)
            {
                throw new ErrorMessageException("Connect to External Systems Faild");
            }
            MarketSystem.ConnectMoneyCollectionSystem(ConnectExternalMoneyCollectionSystems());
            MarketSystem.ConnectDeliverySystem(ConnectExternalDeliverySystems());
            UserSystem.RegisterUser("A1", "123456");
            UserSystem.GetUserInfo("A1", "123456").SetAdmin();

            if (Path != null)
            {
                ReadFromStateFile(Path);
            }
        }

        private MoneyCollectionSystemReal ConnectExternalMoneyCollectionSystems()
        {
            return new MoneyCollectionSystemReal();
        }

        private DeliverySystemReal ConnectExternalDeliverySystems()
        {
            return new DeliverySystemReal();
        }
        public void ReadFromStateFile(string Path)
        {
            string line;
            string FunctionName;
            try
            {
                int userId = CreateAndGetUser.CreateUser();
                StreamReader sr = new StreamReader(Path + ".txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] funcAndParam = line.Split(':');
                    FunctionName = funcAndParam[0].Trim();
                    string[] param = funcAndParam[1].Split(',');
                    switch (FunctionName)
                    {
                        case "Login":
                            {
                                LogIn.Login(param[0], param[1], userId);
                                break;
                            }
                        case "Register":
                            {
                                Register.Registration(param[0], param[1], userId);
                                break;
                            }
                        case "SaveProductToCart":
                            {
                                SaveProductToCart.SaveProduct(int.Parse(param[0]), userId, int.Parse(param[1]));
                                break;
                            }
                        case "Edit":
                            {
                                WatchAndEdit.Edit(param[0], int.Parse(param[1]), userId);
                                break;
                            }
                        case "Logout":
                            {
                                LogOut.Logout(userId);
                                break;
                            }
                        case "OpenStore":
                            {
                                OpenStore.openStore(param[0], userId);
                                break;
                            }
                        case "AssignStoreOwner":
                            {
                                AssignStoreOwner.assignStoreOwner(userId, param[1], param[2]);
                                break;
                            }
                        case "AssignStoreManager":
                            {
                                string[] boolArray = param[3].Split(';');
                                bool[] privileges = new bool[7];
                                int index = 0;
                                foreach (string X in boolArray)
                                {
                                    if (X.Equals("T"))
                                        privileges[index] = true;
                                    else
                                        privileges[index] = false;

                                    index++;
                                }

                                AssignStoreManager.AsssignManager(userId, param[1], param[2], privileges);
                                break;
                            }
                        case "RemoveStoreManager":
                            {
                                RemoveStoreManager.removeStoreManager(userId, param[1], param[2]);
                                break;
                            }
                        case "AcceptAppointment":
                            {
                                HandlerRequestAppointment.AcceptAppointment(param[0], userId, param[2]);
                                break;
                            }
                        case "DeclineAppointment":
                            {
                                HandlerRequestAppointment.DeclineAppointment(param[0], userId, param[2]);
                                break;
                            }
                        case "RemoveUserFromSystem":
                            {
                                RemoveUserFromSystem.RemoveUser(userId, param[1]);
                                break;
                            }
                    }

                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}