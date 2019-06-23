using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Workshop192;

namespace NewGUI
{
    public partial class indexLoginUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
=======
            try
            {
                bool isLoggedIn = CommunicationLayer.Controllers.UsersController.IsLoggedIn(HttpContext.Current.Session.SessionID);
                if (!isLoggedIn)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You are not logged In to the system! Redirecting to index..');window.location ='index.aspx';", true);
                }
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
>>>>>>> NewestGUI
        }
        protected void Notifications_Click(object sender, EventArgs e)
        {
            LinkedList<string> ret = CommunicationLayer.NotificationsHandler.Send_Notifications_To_Me(HttpContext.Current.Session.SessionID);
            Response.Write("<script>alert('hello');</script>");
            for (int i = 0; i < ret.Count; i++)
            {
                Response.Write("<script>alert('"+ret.ElementAt(i) +"');</script>");
            }
        }
    }
}