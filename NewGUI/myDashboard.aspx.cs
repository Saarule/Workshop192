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
    public partial class myDashboard : System.Web.UI.Page
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

                if (!CommunicationLayer.Controllers.UsersController.IsAdmin(HttpContext.Current.Session.SessionID))
                {
                    adminPanelButton.Visible = false;
                    adminPanelButton.Enabled = false;
                }
                else
                {
                    adminPanelButton.Visible = true;
                    adminPanelButton.Enabled = true;
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

        }
        protected void LogoutButton1_Click(object sender, EventArgs e)
        {
            try
            {
                bool ans = CommunicationLayer.Controllers.UsersController.Logout(HttpContext.Current.Session.SessionID);
                if (ans)
                {
                    Response.Redirect("index.aspx");
                    Response.Write("<script>alert('Logout succesfuly');</script>");
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
                        Response.Write("<script>alert('succesfully opening store');</script>");
                        Response.Redirect("myDashboard.aspx");
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
        }
        protected void ManageStoreButton1_Click(object sender, EventArgs e)
        {
            try
            {
                String storeNameToManage = StoreToManageTextBox.Text;

                if (storeNameToManage.Equals(""))
                {
                    Response.Write("<script>alert('The field of store name empty');</script>");
                }
                else
                {
                    if (CommunicationLayer.Controllers.UsersController.IsManagerOfStore(HttpContext.Current.Session.SessionID, storeNameToManage) || CommunicationLayer.Controllers.UsersController.IsOwnerOfStore(HttpContext.Current.Session.SessionID, storeNameToManage))
                    {
                        Response.Redirect("manageStorePanel.aspx?storeName=" + storeNameToManage);
                    }
                    else
                    {
                        Response.Write("<script>alert('You are not store manager of that store!');</script>");
                    }
                }
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
        protected void OwnStoreButton1_Click(object sender, EventArgs e)
        {
            try
            {
                String storeNameToOwn = StoreToOwnTextBox.Text;
                if (storeNameToOwn.Equals(""))
                {
                    Response.Write("<script>alert('The field of store name empty');</script>");
                }
                else
                {
                    if (CommunicationLayer.Controllers.UsersController.IsOwnerOfStore(HttpContext.Current.Session.SessionID, storeNameToOwn))
                    {
                        Response.Redirect("ownStorePanel.aspx?storeName=" + storeNameToOwn);
                    }
                    else
                    {
                        Response.Write("<script>alert('You are not store owner of that store!');</script>");
                    }
                }
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
        protected void ManagePoliciesButton1_Click(object sender, EventArgs e)
        {
            try
            {
                String storeNameToManage = StoreToManagePoliciesTextBox.Text;
                if (storeNameToManage.Equals(""))
                {
                    Response.Write("<script>alert('The field of store name empty');</script>");
                }
                else
                {
                    if (CommunicationLayer.Controllers.UsersController.IsManagerOfStore(HttpContext.Current.Session.SessionID, storeNameToManage) || CommunicationLayer.Controllers.UsersController.IsOwnerOfStore(HttpContext.Current.Session.SessionID, storeNameToManage))
                    {
                        Response.Redirect("policiesPanel.aspx?storeName=" + storeNameToManage);
                    }
                    else
                    {
                        Response.Write("<script>alert('You are not store manager of that store!');</script>");
                    }
                }
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
        protected void adminPanelButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminPanel.aspx");
        }
        protected void ManageNotificitaionsButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("notificationsPanel.aspx");
        }
    }
}