using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewGUI
{
    public partial class products : System.Web.UI.Page
    {
        StringBuilder tableProducts = new StringBuilder();
        LinkedList<LinkedList<string>> products2 = new LinkedList<LinkedList<string>>();
        string storeName;
        protected void Page_Load(object sender, EventArgs e)
        {
            string productId;
            string productName;
            string productCategory;
            string productPrice;
            string productAmount;
            string productStoreName;
            products2 = CommunicationLayer.Controllers.ProductsController.GetAllProducts();
            tableProducts.Append("<section class='lattest - product - area pb - 40 category - list'>");
            tableProducts.Append("<div class='row'>");;
            for (int i = 0; i < products2.Count; i++)
            {
                tableProducts.Append("<div class='col - md - 6 col - lg - 4'>");
                tableProducts.Append("<div class='card text - center card - product'>");
                tableProducts.Append("<div class='card - product__img'>");
                tableProducts.Append("<img class='card - img' src='img / product / product1.png' alt=''>");
                tableProducts.Append("<ul class='card - product__imgOverlay'>");
                tableProducts.Append("<li><button><i class='ti - shopping - cart'></i></button></li>");
                tableProducts.Append("</ul>");
                tableProducts.Append("</div>");
                tableProducts.Append("<div class='card - body'>");
                tableProducts.Append("<p>");
                productCategory = products2.ElementAt(i).ElementAt(2);
                tableProducts.Append(productCategory);
                tableProducts.Append("</p>");
                tableProducts.Append("<h4 class='card - product__title'><a href = '#' >");
                productName = products2.ElementAt(i).ElementAt(1);
                tableProducts.Append(productName);
                tableProducts.Append("</a></h4>");
                tableProducts.Append("<p class='card - product__price'>");
                productPrice = products2.ElementAt(i).ElementAt(3);
                tableProducts.Append(productPrice);
                tableProducts.Append("</p>");
                tableProducts.Append("</div>");
                tableProducts.Append("</div>");
                tableProducts.Append("</div>");

            }
            tableProducts.Append("</div>");
            tableProducts.Append("</section>");
            PlaceHolder2.Controls.Add(new Literal { Text = tableProducts.ToString() });
        }
    }
}