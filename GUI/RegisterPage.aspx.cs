using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunicationLayer;

namespace GUI
{
    public partial class RegisterPage : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton1_Click(object sender, EventArgs e)
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
                bool ans = CommunicationLayer.Controllers.UsersController.Register(Username, Password,GlobalSpecificUser.userNum);
                if (ans)
                {
                    Response.Write("<script>alert('Successful Registeration');</script>");
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Failed Registeration');</script>");
                }
            }
        }
    }   
}