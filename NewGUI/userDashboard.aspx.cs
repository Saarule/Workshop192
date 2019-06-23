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
    public partial class userDashboard : System.Web.UI.Page
    {
        StringBuilder tableRoles = new StringBuilder();
        LinkedList<LinkedList<string>> Roles = new LinkedList<LinkedList<string>>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                bool isLoggedIn = CommunicationLayer.Controllers.UsersController.IsLoggedIn(HttpContext.Current.Session.SessionID);
                if (!isLoggedIn)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You are not logged In to the system! Redirecting to index..');window.location ='index.aspx';", true);
                }

                Roles = CommunicationLayer.Controllers.UsersController.GetRoles(HttpContext.Current.Session.SessionID);
                tableRoles.Append("<table border='1'>");
                tableRoles.Append("<tr><th> Role: </th><th> Store Name: </th>");
                tableRoles.Append("</tr>");
                for (int i = 0; i < Roles.Count; i++)
                {
                    tableRoles.Append("<tr>");
                    tableRoles.Append("<td>" + Roles.ElementAt(i).ElementAt(0) + "</td>");
                    tableRoles.Append("<td>" + Roles.ElementAt(i).ElementAt(1) + "</td>");
                    tableRoles.Append("</tr>");
                }
                tableRoles.Append("</table>");
                PlaceHolder1.Controls.Add(new Literal { Text = tableRoles.ToString() });
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
            catch (Exception exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }


        }
        protected void LogoutButton1_Click(object sender, EventArgs e)
        {
            try
            {
                bool ans = CommunicationLayer.Controllers.UsersController.Logout(HttpContext.Current.Session.SessionID);
                if (ans)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Logout succesfuly');window.location ='index.aspx';", true);
                    //Response.Redirect("index.aspx");
                    //Response.Write("<script>alert('Logout succesfuly');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Logout failed');</script>");
                }
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
            catch (Exception exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }

        protected void OpenStoreButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string storeName = StoreNameTextBox.Text;
                if (storeName.Equals(""))
                {
                    Response.Write("<script>alert('The field of store name empty');</script>");
                }
                else
                {
                    bool ans = CommunicationLayer.Controllers.ProductsController.OpenStore(storeName, HttpContext.Current.Session.SessionID);
                    if (ans)
                    {
                        ScriptManager.RegisterStartupScript(this,
                            this.GetType(),
                            "alert",
                            "alert('Open store succesfully');window.location ='storeOwnerDashboard.aspx';",
                            true);
                        //Response.Write("<script>alert('succesfully opening store');</script>");
                        //Response.Redirect("storeOwnerDashboard.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('The store name is exists');</script>");
                    }
                }
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
            catch (Exception exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
    }
}