using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewGUI
{
    public partial class manageStorePanel : System.Web.UI.Page
    {
        string storeName;
        protected void Page_Load(object sender, EventArgs e)
        {
            storeName = Request["storeName"];
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

        
        protected void AddProductButton1_Click(object sender, EventArgs e)
        {
            string productName = ProductNameTextBox1.Text;
            string productPrice = ProductPriceTextBox.Text;
            string productCategory = ProductCategoryTextBox.Text;
            string productAmount = ProductAmountTextBox.Text;
            bool ans = CommunicationLayer.Controllers.ProductsController.ManageProducts(HttpContext.Current.Session.SessionID, -1, productName, productCategory, Int32.Parse(productPrice), Int32.Parse(productAmount), storeName, "add");
            if (ans)
            {
                Response.Write("<script>alert('succesfully added product');</script>");
                Response.Redirect("manageStorePanel.aspx");
            }
            else
            {
                Response.Write("<script>alert('There was error when adding the product');</script>");
            }
        }

        protected void RemoveProductButton1_Click(object sender, EventArgs e)
        {
            string productIdToDelete = ProductIdToDeleteTextBox.Text;
            bool ans = CommunicationLayer.Controllers.ProductsController.ManageProducts(HttpContext.Current.Session.SessionID, Int32.Parse(productIdToDelete), null , null , -1 , -1 , storeName, "delete");
            if (ans)
            {
                Response.Write("<script>alert('succesfully delete product');</script>");
                Response.Redirect("manageStorePanel.aspx");
            }
            else
            {
                Response.Write("<script>alert('There was error when deleting the product');</script>");
            }

        }

        protected void EditProductButton1_Click(object sender, EventArgs e)
        {
            string productID = ProductIdTextBox2.Text;
            string productName = ProductNameTextBox2.Text;
            string productPrice = ProductPriceTextBox2.Text;
            string productCategory = ProductCategoryTextBox2.Text;
            string productAmount = ProductAmountTextBox2.Text;
            bool ans = CommunicationLayer.Controllers.ProductsController.ManageProducts(HttpContext.Current.Session.SessionID, Int32.Parse(productID), productName, productCategory, Int32.Parse(productPrice), Int32.Parse(productAmount), storeName, "edit");
            if (ans)
            {
                Response.Write("<script>alert('succesfully edit product');</script>");
                Response.Redirect("manageStorePanel.aspx");
            }
            else
            {
                Response.Write("<script>alert('There was error when editing the product');</script>");
            }

        }
    }
}