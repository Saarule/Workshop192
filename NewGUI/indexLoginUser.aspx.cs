using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;

namespace NewGUI
{
    public partial class indexLoginUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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