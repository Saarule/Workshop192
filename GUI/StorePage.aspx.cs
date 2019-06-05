using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class StorePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InventoryButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("InventoryPage.aspx");
        }

        protected void TreeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }

        protected void ManageWorkersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageWorkersPage.aspx");
        }
    }
}