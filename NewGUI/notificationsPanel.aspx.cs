using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewGUI
{
    public partial class notificationsPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
        }
    }
}