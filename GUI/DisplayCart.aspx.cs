using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class DisplayCart : System.Web.UI.Page
    {
        StringBuilder tableProducts = new StringBuilder();
        LinkedList<LinkedList<string>> products = new LinkedList<LinkedList<string>>();
        protected void Page_Load(object sender, EventArgs e)
        {
            products = CommunicationLayer.Controllers.ProductsController.GetProductsOfCart(GlobalSpecificUser.userNum);
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

        protected void DeleteButton1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Equals(""))
            {
                Response.Write("<script>alert('The field of product id empty');</script>");
            }
            else if (!TextBox1.Text.All(char.IsDigit) || int.Parse(TextBox1.Text) <= 0)
            {
                Response.Write("<script>alert('The field of product id must be number and positive');</script>");
            }
            else
            {
                bool ans = CommunicationLayer.Controllers.ProductsController.DeleteFromCart(GlobalSpecificUser.userNum, int.Parse(TextBox1.Text));
            }
        }
    }
}