using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class SearchPage : System.Web.UI.Page
    {
        StringBuilder tableProducts = new StringBuilder();
        LinkedList<LinkedList<string>> products = new LinkedList<LinkedList<string>>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string input = (string)Session["inputSearch"];
            products = CommunicationLayer.Controllers.ProductsController.SearchProducts(input);
            tableProducts.Append("<table border='1' bgcolor= "+ @"""#FFFFFF""" +">");
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

        protected void AddButton1_Click(object sender, EventArgs e)
        {
            string productID = TextBox1.Text;
            string amount = TextBox2.Text;
            if (productID.Equals("") && amount.Equals(""))
            {
                Response.Write("<script>alert('The fields of id and amount empty');</script>");
            }
            else if (productID.Equals(""))
            {
                Response.Write("<script>alert('The field of id empty');</script>");
            }
            else if (amount.Equals(""))
            {
                Response.Write("<script>alert('The field of amount empty');</script>");
            }
            else
            {
                //try
                //{
                    //need to check why has exception 
                    CommunicationLayer.Controllers.ProductsController.addToCart(GlobalSpecificUser.userNum, int.Parse(productID), int.Parse(amount));
                try{}
                catch (Exception)
                {
                    Response.Write("<script>alert('illegal arguments');</script>");
                }
            }
        }
    }
}