using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workshop192;

namespace NewGUI
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string Username = UsernameTextBox.Text;
                string Password = PasswordTextBox.Text;
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
                    bool ans = CommunicationLayer.Controllers.UsersController.Login(Username, Password, HttpContext.Current.Session.SessionID);
                    if (ans)
                    {
                        Response.Write("<script>alert('Successful Log in');</script>");
                        Response.Redirect("indexLoginUser.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Failed Log in');</script>");
                    }
                }
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }

        }
    }
}