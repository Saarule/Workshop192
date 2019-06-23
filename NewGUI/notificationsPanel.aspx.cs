using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
<<<<<<< HEAD
using Workshop192;

=======
using Workshop192;

>>>>>>> NewestGUI
namespace NewGUI
{
    public partial class notificationsPanel : System.Web.UI.Page
    {
        StringBuilder notificationTable = new StringBuilder();
        LinkedList<string> notifications = new LinkedList<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            try
            {
                int userId = CommunicationLayer.Controllers.Dictionary_SessionId_UserId.GetInstance().Get_UserId_From_Dictionary(HttpContext.Current.Session.SessionID);
                string username = CommunicationLayer.Controllers.UsersController.getUserNameByUserId(userId);
                notifications = Notifications.Notification.GetInstance().Send_Notifications_To_Me(username);

                notificationTable.Append("<table border='1'>");
                notificationTable.Append("<tr><th> Notification: </th></tr>");
                for (int i = 0; i < notifications.Count; i++)
                {
                    notificationTable.Append("<tr>");
                    notificationTable.Append("<td>" + notifications.ElementAt(i) + "</td>");
                    notificationTable.Append("</tr>");
                }
                notificationTable.Append("</table>");
                PlaceHolder1.Controls.Add(new Literal { Text = notificationTable.ToString() });
            }
            catch (ErrorMessageException exception)
            {}
            catch (Exception)
            {

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
>>>>>>> NewestGUI
            }
        }
    }
}