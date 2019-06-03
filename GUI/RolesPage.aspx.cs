using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class RollesPage : System.Web.UI.Page
    {
        StringBuilder tableRoles = new StringBuilder();
        LinkedList<LinkedList <string>> Roles = new LinkedList<LinkedList<string>>();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Roles = ?
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

        protected void ContinueButton_Click(object sender, EventArgs e)
        {

        }
    }
}