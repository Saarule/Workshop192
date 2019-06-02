using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton1_Click(object sender, EventArgs e)
        {

            string Username = TextBox1.Text;
            string Password = TextBox2.Text;
            if (Username.Equals("") && Password.Equals(""))
            {
                Response.Write("<script>alert('The fields of username and password empty');</script>");
            }
            else if (Username.Equals(""))
            {
                Response.Write("<script>alert('The field of username empty');</script>");
            }
            else if (Password.Equals(""))
            {
                Response.Write("<script>alert('The field of password empty');</script>");
            }
            else
            {
                Pair pair = new Pair(Username, Password);
                // send HTTP (username,password)
                bool ans = CommunicationLayer.Controllers.UsersController.Login(Username, Password,GlobalSpecificUser.userID);
                if (ans)
                {
                    Response.Write("<script>alert('Successful Log in');</script>");
                    Response.Redirect("LoginUserHomePage.aspx");
                }
                else {
                    Response.Write("<script>alert('Failed Log in');</script>");
                }
            }
        }
    }
}