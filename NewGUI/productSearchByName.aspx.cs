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
    public partial class productSearchByName : System.Web.UI.Page
    {
        StringBuilder tableProducts = new StringBuilder();
        LinkedList<LinkedList<string>> products3 = new LinkedList<LinkedList<string>>();
        string productName;
        protected void Page_Load(object sender, EventArgs e)
        {
            productName = Request["productName"];
            try
            {
                string productId;
                string productCategory;
                string productPrice;
                string productAmount;
                string productStoreName;
                
                products3 = CommunicationLayer.Controllers.ProductsController.SearchProducts(productName);

                for (int i = 0; i < products3.Count; i++)
                {
                    tableProducts.Append("<div class='col-md-6 col-lg-4'>");
                    tableProducts.Append("<div class='card text-center card-product'>");
                    tableProducts.Append("<div class='card-product__img'>");
                    tableProducts.Append("<img class='card-img' src='img/product/product7.png' alt=''>");
                    tableProducts.Append("</div>");
                    tableProducts.Append("<div class='card-body'>");
                    tableProducts.Append("<p>");
                    productCategory = products3.ElementAt(i).ElementAt(2);
                    tableProducts.Append(productCategory);
                    tableProducts.Append("</p>");
                    productId = products3.ElementAt(i).ElementAt(0);
                    tableProducts.Append("<h4 class='card-product__title'><a href = 'productPage.aspx?productID=" + productId + "'>");
                    productName = products3.ElementAt(i).ElementAt(1);
                    tableProducts.Append(productName);
                    tableProducts.Append("</a></h4>");
                    tableProducts.Append("<p class='card-product__price'>");
                    productPrice = products3.ElementAt(i).ElementAt(3);
                    tableProducts.Append(productPrice);
                    tableProducts.Append("</p>");
                    tableProducts.Append("</div>");
                    tableProducts.Append("</div>");
                    tableProducts.Append("</div>");

                }
                PlaceHolder3.Controls.Add(new Literal { Text = tableProducts.ToString() });
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }

        protected void SearchButton2_Click(object sender, EventArgs e)
        {
            string productName = SearchTextBox.Text;
            Response.Redirect("productSearchByName.aspx?productName=" + productName);


        }
    }
}