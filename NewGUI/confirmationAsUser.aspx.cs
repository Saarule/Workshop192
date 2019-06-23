using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workshop192;

namespace NewGUI
{
    public partial class confirmationAsUser : System.Web.UI.Page
    {
        string transcationPayId;
        string transcationSupplyId;
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


                transcationPayId = Request["PayID"];
                transcationSupplyId = Request["SupplyID"];

                PlaceHolder3.Controls.Add(new Literal { Text = transcationPayId.ToString() });
                PlaceHolder4.Controls.Add(new Literal { Text = transcationSupplyId.ToString() });
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
    }
}