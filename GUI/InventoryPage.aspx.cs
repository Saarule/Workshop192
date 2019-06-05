using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class InventoryPage : System.Web.UI.Page
    {
        StringBuilder tableProducts = new StringBuilder();
        LinkedList<LinkedList<string>> products = new LinkedList<LinkedList<string>>();
        protected void Page_Load(object sender, EventArgs e)
        {

            products = CommunicationLayer.Controllers.ProductsController.getProductsOfStore((string)Session["storeName"]); //function that return all products in store

            tableProducts.Append("<table border='1'>");
            tableProducts.Append("<tr><th>Product ID:</th><th>Product Name:</th><th>Catagory:</th><th>Price:</th><th>Amount:</th><th>Store Name:</th>");
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
            PH1.Controls.Add(new Literal { Text = tableProducts.ToString() });
        }

        protected void AddnewProductButton_Click(object sender, EventArgs e)
        {
            string name = TextBox6.Text;
            string price = TextBox9.Text;
            string catagory = TextBox8.Text;
            string amount = TextBox1.Text;

            if (name.Equals(""))
            {
                Response.Write("<script>alert('field of product Name is empty');</script>");
            }
            else if (!price.All(char.IsDigit) || !amount.All(char.IsDigit) || price.Equals("") || amount.Equals(""))
            {
                Response.Write("<script>alert('illegal input in fileds that must be numric');</script>");
            }
            else if (int.Parse(price) <= 0 || int.Parse(amount) <= 0)
            {
                Response.Write("<script>alert('price or amount must be positive numbers');</script>");
            }
            else
            {
                string storeName = (string)Session["storeName"];
                try
                {
                    bool ans = CommunicationLayer.Controllers.ProductsController.ManageProducts(GlobalSpecificUser.userNum, -1 , name, catagory, int.Parse(price), int.Parse(amount), storeName, "add");
                    if (ans)
                    {
                        Response.Write("<script>alert('product added succesfully');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('product added unsuccesfully');</script>");
                    }
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('The fields of product details was illegal');</script>");
                }
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            string productid = TextBox7.Text;
            if (productid.Equals(""))
            {
                Response.Write("<script>alert('The field of product ID empty');</script>");
            }
            else
            {
                string storeName = (string)Session["storeName"];
                try
                {
                    bool ans = CommunicationLayer.Controllers.ProductsController.ManageProducts(GlobalSpecificUser.userNum, int.Parse(productid), "", "", 0, 0, storeName, "delete");
                    if (ans)
                    {
                        Response.Write("<script>alert('product delete succesfully');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('product delete unsuccesfully');</script>");
                    }
                }
                catch (Exception) {
                    Response.Write("<script>alert('The field of product ID illegal');</script>");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string name = TextBox2.Text;
            string price = TextBox3.Text;
            string catagory = TextBox4.Text;
            string amount = TextBox5.Text;
            string productID = TextBox10.Text;

            if (productID.Equals("") || name.Equals(""))
            {
                Response.Write("<script>alert('field of productID or product Name is empty');</script>");
            }
            else if (!price.All(char.IsDigit) || !amount.All(char.IsDigit) || !productID.All(char.IsDigit) || price.Equals("") || amount.Equals(""))
            {
                Response.Write("<script>alert('illegal input in fileds that must be numric');</script>");
            }
            else if (int.Parse(price)<= 0 || int.Parse(amount) <= 0)
            {
                Response.Write("<script>alert('price or amount must be positive numbers');</script>");
            }
            else
            {
                string storeName = (string)Session["storeName"];
                try
                {
                    bool ans = CommunicationLayer.Controllers.ProductsController.ManageProducts(GlobalSpecificUser.userNum, int.Parse(productID), name, catagory, int.Parse(price), int.Parse(amount), storeName, "edit");
                    if (ans)
                    {
                        Response.Write("<script>alert('product edited succesfully');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('product edited unsuccesfully');</script>");
                    }
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('The fields of product details was illegal');</script>");
                }
            }
        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            Reset();
            if (RadioButtonList1.Items[2].Selected)
            {
                Label7.Visible = true;
                TextBox7.Visible = true;
                DeleteButton.Visible = true;
            }
            else if (RadioButtonList1.Items[1].Selected)
            {
                Label2.Visible = true;
                Label3.Visible = true;
                Label4.Visible = true;
                Label8.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                Button2.Visible = true;
                Label9.Visible = true;
                TextBox10.Visible = true;

            }
            else if (RadioButtonList1.Items[0].Selected)
            {
                Label11.Visible = true;
                Label12.Visible = true;
                Label13.Visible = true;
                Label14.Visible = true;
                TextBox1.Visible = true;
                TextBox6.Visible = true;
                TextBox8.Visible = true;
                TextBox9.Visible = true;
                WatchCartsButton.Visible = true;
            }
        }
        private void Reset()
        {
            Label7.Visible = false;
            TextBox7.Visible = false;
            DeleteButton.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label8.Visible = false;
            Label9.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            Button2.Visible = false;
            Label11.Visible = false;
            Label12.Visible = false;
            Label13.Visible = false;
            Label14.Visible = false;
            TextBox1.Visible = false;
            TextBox6.Visible = false;
            TextBox8.Visible = false;
            TextBox9.Visible = false;
            TextBox10.Visible = false;
            WatchCartsButton.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}