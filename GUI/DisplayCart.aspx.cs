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
        List<List<string>> products = new List<List<string>>();
        protected void Page_Load(object sender, EventArgs e)
        {
            /* EXAMPLE List<string> a = new List<string>();
            a.Add("water");
            a.Add("10");
            a.Add("20");
            List<string> b = new List<string>();
            b.Add("bread");
            b.Add("15");
            b.Add("8");
            products.Add(a);
            products.Add(b);
            products.Add(b); */
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
                Response.Write("<script>alert('The field of product name empty');</script>");
            }
        }
    }
}