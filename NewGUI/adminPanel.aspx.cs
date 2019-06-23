using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workshop192;

namespace NewGUI
{
    public partial class adminPanel : System.Web.UI.Page
    {
        StringBuilder userTable = new StringBuilder();
        LinkedList<string> users = new LinkedList<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                bool isLoggedIn = CommunicationLayer.Controllers.UsersController.IsLoggedIn(HttpContext.Current.Session.SessionID);
                if (!isLoggedIn)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You are not logged In to the system! Redirecting to index..');window.location ='index.aspx';", true);
                    return;
                }

                CommunicationLayer.Controllers.UsersController.GetAllUserName();
                users = CommunicationLayer.Controllers.UsersController.GetAllUserName();
                userTable.Append("<table border='1'>");
                userTable.Append("<tr><th> Users: </th></tr>");
                for (int i = 0; i < users.Count; i++)
                {
                    userTable.Append("<tr>");
                    userTable.Append("<td>" + users.ElementAt(i) + "</td>");
                    userTable.Append("</tr>");
                }
                userTable.Append("</table>");
                PlaceHolder1.Controls.Add(new Literal { Text = userTable.ToString() });
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }

        }
        protected void UserToRemoveButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string userToRemove = UserToRemove.Text;
                if (userToRemove.Equals(""))
                {
                    Response.Write("<script>alert('The Username field is empty');</script>");
                }
                else
                {
                    bool ans = CommunicationLayer.Controllers.UsersController.RemoveUserFromSystem(HttpContext.Current.Session.SessionID, userToRemove);
                    if (ans)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User Removed Succesfully');window.location ='adminPanel.aspx';", true);
                    }
                    else
                    {
                        Response.Write("<script>alert('There was error when deleting the User');</script>");
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