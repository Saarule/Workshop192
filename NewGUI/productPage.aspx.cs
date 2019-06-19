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
    public partial class productPage : System.Web.UI.Page
    {
        StringBuilder productDetails = new StringBuilder();
        LinkedList<LinkedList<string>> products2 = new LinkedList<LinkedList<string>>();
        string productId;
        LinkedList<string> product;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
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
                    Response.Redirect("myCart.aspx");
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

        /*
                          <tr>
                <td>Enter product amount:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="ProductAmountTextBox" runat="server" placeholder="Product amount" class="form-control" type="text"></asp:TextBox></td>
                </tr>


        */
        /*
        				<div class="col-lg-5 offset-lg-1">
					<div class="s_product_text">
						<h3>Faded SkyBlu Denim Jeans</h3>
						<h2>$149.99</h2>
						<ul class="list">
							<li><a class="active" href="#"><span>Category</span> : Household</a></li>
							<li><a href = "#" >< span > Availibility </ span > : In Stock</a></li>
						</ul>
						<p>Mill Oil is an innovative oil filled radiator with the most modern technology. If you are looking for

                                     something that can make your interior look awesome, and at the same time give you the pleasant warm feeling
                                     during the winter.</p>
						<div class="product_count">
              <label for="qty">Quantity:</label>
                            <asp:TextBox id = "ProductAmountTextBox" runat="server" placeholder="1" class="form-control" type="text"></asp:TextBox>
                            <p ></p>
							<a class="button primary-btn" href="#">Add to Cart</a>               
						</div>
					</div>
				</div>
                */
    }
}