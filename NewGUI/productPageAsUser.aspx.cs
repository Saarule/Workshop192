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
    public partial class productPageAsUser : System.Web.UI.Page
    {
        StringBuilder productDetails = new StringBuilder();
        LinkedList<LinkedList<string>> products2 = new LinkedList<LinkedList<string>>();
        string productId;
        LinkedList<string> product;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                bool isLoggedIn = CommunicationLayer.Controllers.UsersController.IsLoggedIn(HttpContext.Current.Session.SessionID);
                if (!isLoggedIn)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You are not logged In to the system! Redirecting to index..');window.location ='index.aspx';", true);
                }

                productId = Request["productID"];
                product = CommunicationLayer.Controllers.ProductsController.SearchProductsByID(Int32.Parse(productId));
                string productName = product.ElementAt(1);
                string productCategory = product.ElementAt(2);
                string productPrice = product.ElementAt(3);
                string productAmount = product.ElementAt(4);
                string storeName = product.ElementAt(5);
                productDetails.Append("<h3>" + productName + "</h3>");
                productDetails.Append("<h2>$" + productPrice + "</h2>");
                productDetails.Append("<ul class='list'>");
                productDetails.Append("<li><span>Category</span> : " + productCategory + "</li>");
                productDetails.Append("<li><span> Availibility</span> : " + productAmount + "</li>");
                productDetails.Append("<li><span> Store Name</span> : " + storeName + "</li>");
                productDetails.Append("</ul>");
                PlaceHolder2.Controls.Add(new Literal { Text = productDetails.ToString() });
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }

        }
        protected void AddToCartButton1_Click(object sender, EventArgs e)
        {
            try
            {
                bool ans = CommunicationLayer.Controllers.ProductsController.SaveToCart(HttpContext.Current.Session.SessionID, Int32.Parse(productId), Int32.Parse(ProductAmountTextBox.Text));
                if (ans)
                {
                    Response.Write("<script>alert('succesfully added product to cart');</script>");
                    Response.Redirect("myCartAsUser.aspx");
                }
                else
                {
                    Response.Write("<script>alert('There was error when adding product to cart');</script>");
                }
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
    }
}