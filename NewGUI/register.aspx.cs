using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Workshop192;

namespace NewGUI
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string Username = UsernameTextBox.Text;
                string Password = PasswordTextBox.Text;
                if (!ConfirmPasswordTextBox.Text.Equals(PasswordTextBox.Text))
                {
                    Response.Write("<script>alert('Password Does not much!');</script>");
                }
                else if (Username.Equals("") && Password.Equals(""))
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
                    bool ans = CommunicationLayer.Controllers.UsersController.Register(Username, Password, HttpContext.Current.Session.SessionID);
                    if (ans)
                    {
                        Response.Write("<script>alert('Successful Registeration');</script>");
                        Session["temp"] = "Temp";//Must do it in order to keep the session ID perssitent 
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Failed Registeration');</script>");
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