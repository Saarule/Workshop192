﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workshop192;

namespace NewGUI
{
    public partial class manageStorePanel : System.Web.UI.Page
    {
        StringBuilder tableProducts = new StringBuilder();
        LinkedList<LinkedList<string>> products = new LinkedList<LinkedList<string>>();
        string storeName;

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

                storeName = Request["storeName"];
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
                    ScriptManager.RegisterStartupScript(this,
                            this.GetType(),
                            "alert",
                            "alert('Logout succesfuly');window.location ='index.aspx';",
                            true);

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
            catch (Exception)
            {
                Response.Write("<script>alert('illegal input');</script>");
            }
        }

        
        protected void AddProductButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string productName = ProductNameTextBox1.Text;
                string productPrice = ProductPriceTextBox.Text;
                string productCategory = ProductCategoryTextBox.Text;
                string productAmount = ProductAmountTextBox.Text;
                bool ans = CommunicationLayer.Controllers.ProductsController.ManageProducts(HttpContext.Current.Session.SessionID, -1, productName, productCategory, Int32.Parse(productPrice), Int32.Parse(productAmount), storeName, "add");
                if (ans)
                {
                    Response.Write("<script>alert('succesfully added product');</script>");
                    Response.Redirect("manageStorePanel.aspx?storeName=" + storeName);
                }
                else
                {
                    Response.Write("<script>alert('There was error when adding the product');</script>");
                }
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
            catch (Exception)
            {
                Response.Write("<script>alert('illegal input');</script>");
            }
        }

        protected void RemoveProductButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string productIdToDelete = ProductIdToDeleteTextBox.Text;
                bool ans = CommunicationLayer.Controllers.ProductsController.ManageProducts(HttpContext.Current.Session.SessionID, Int32.Parse(productIdToDelete), null, null, -1, -1, storeName, "delete");
                if (ans)
                {
                    Response.Write("<script>alert('succesfully delete product');</script>");
                    Response.Redirect("manageStorePanel.aspx?storeName=" + storeName);
                }
                else
                {
                    Response.Write("<script>alert('There was error when deleting the product');</script>");
                }
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
            catch (Exception)
            {
                Response.Write("<script>alert('illegal input');</script>");
            }

        }

        protected void EditProductButton1_Click(object sender, EventArgs e)
        {
            try
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
                    Response.Redirect("manageStorePanel.aspx?storeName=" + storeName);
                }
                else
                {
                    Response.Write("<script>alert('There was error when editing the product');</script>");
                }
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
            catch (Exception)
            {
                Response.Write("<script>alert('illegal input');</script>");
            }

        }

    }
}