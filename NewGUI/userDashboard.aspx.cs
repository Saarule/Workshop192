using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewGUI
{
    public partial class userDashboard : System.Web.UI.Page
    {
        StringBuilder tableRoles = new StringBuilder();
        LinkedList<LinkedList<string>> Roles = new LinkedList<LinkedList<string>>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Roles = CommunicationLayer.Controllers.UsersController.GetRoles(HttpContext.Current.Session.SessionID);
            tableRoles.Append("<table border='1'>");
            tableRoles.Append("<tr><th>Role:</th><th>Store Name:</th>");
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
        protected void LogoutButton1_Click(object sender, EventArgs e)
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

        protected void OpenStoreButton1_Click(object sender, EventArgs e)
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
                }
                else
                {
                    Response.Write("<script>alert('The store name is exists');</script>");
                }
            }
        }
    }
}