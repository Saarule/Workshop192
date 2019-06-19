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
    public partial class ownStorePanel : System.Web.UI.Page
    {
        //StringBuilder tableProducts = new StringBuilder();
        //LinkedList<LinkedList<string>> products = new LinkedList<LinkedList<string>>();
        string storeName;

        protected void Page_Load(object sender, EventArgs e)
        {
            storeName = Request["storeName"];
            /*
            products = CommunicationLayer.Controllers.ProductsController.GetProductsOfStore(storeName);
            tableProducts.Append("<table border='1'>");
            tableProducts.Append("<tr><th> Product ID: </th><th> Product Name: </th><th> Product Category: </th><th> Product Price: </th><th> Product Amount: </th><th> Store Name: </th>");
            tableProducts.Append("</tr>");
            for (int i = 0; i < products.Count; i++)
            {
                tableProducts.Append("<tr>");
                tableProducts.Append("<td>" + products.ElementAt(i).ElementAt(0) + "</td>");
                tableProducts.Append("<td>" + products.ElementAt(i).ElementAt(1) + "</td>");
                tableProducts.Append("<td>" + products.ElementAt(i).ElementAt(2) + "</td>");
                tableProducts.Append("<td>" + products.ElementAt(i).ElementAt(3) + "</td>");
                tableProducts.Append("<td>" + products.ElementAt(i).ElementAt(4) + "</td>");
                tableProducts.Append("<td>" + products.ElementAt(i).ElementAt(5) + "</td>");
                tableProducts.Append("</tr>");
            }
            tableProducts.Append("</table>");
            PlaceHolder1.Controls.Add(new Literal { Text = tableProducts.ToString() });
            */

        }


        protected void AddStoreManagerButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string storeManagerName = StoreManagerToAddTextBox.Text;
                bool checkbox1 = AddProductCheckBox.Checked;
                bool checkbox2 = RemoveProductCheckBox.Checked;
                bool checkbox3 = EditProductCheckBox.Checked;
                bool checkbox4 = AddDiscountPolicyCheckBox.Checked;
                bool checkbox5 = AddSellingPolicyCheckBox.Checked;
                bool checkbox6 = RemoveDiscountPolicyCheckBox.Checked;
                bool checkbox7 = RemoveSellingPolicyCheckBox.Checked;
                bool[] priviliges = new bool[7];
                priviliges[0] = checkbox1;
                priviliges[1] = checkbox2;
                priviliges[2] = checkbox3;
                priviliges[3] = checkbox4;
                priviliges[4] = checkbox5;
                priviliges[5] = checkbox6;
                priviliges[6] = checkbox7;
                bool ans = CommunicationLayer.Controllers.UsersController.AssignStoreManager(HttpContext.Current.Session.SessionID, storeName, storeManagerName, priviliges);
                if (ans)
                {
                    Response.Write("<script>alert('succesfully added Store Manager');</script>");
                    Response.Redirect("ownStorePanel.aspx");
                }
                else
                {
                    Response.Write("<script>alert('There was error when adding the Store Manager');</script>");
                }
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }

        }
        protected void RemoveStoreManagerButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string storeManagerName = StoreManagerToRemoveTextBox.Text;
                bool ans = CommunicationLayer.Controllers.UsersController.RemoveStoreManger(HttpContext.Current.Session.SessionID, storeName, storeManagerName);
                if (ans)
                {
                    Response.Write("<script>alert('succesfully removed Store Manager');</script>");
                    Response.Redirect("ownStorePanel.aspx");
                }
                else
                {
                    Response.Write("<script>alert('There was error when removing the Store Manager');</script>");
                }
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }

        }
        protected void AddStoreOwnerButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string storeOwnerName = StoreOwnerTextBox.Text;
                bool ans = CommunicationLayer.Controllers.UsersController.AssignStoreOwner(HttpContext.Current.Session.SessionID, storeName, storeOwnerName);
                if (ans)
                {
                    Response.Write("<script>alert('succesfully added Store Owner');</script>");
                    Response.Redirect("owmStorePanel.aspx");
                }
                else
                {
                    Response.Write("<script>alert('There was error when adding the Store Owner');</script>");
                }
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
    }
}