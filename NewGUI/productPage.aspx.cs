using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewGUI
{
    public partial class productPage : System.Web.UI.Page
    {
        StringBuilder productDetails = new StringBuilder();
        LinkedList<LinkedList<string>> products2 = new LinkedList<LinkedList<string>>();
        string productId;
        string productName;
        string productAmount;
        string productPrice;
        string productCategory;
        protected void Page_Load(object sender, EventArgs e)
        {
            productId = Request["productID"];
            //product = CommunicationLayer.Controllers.ProductsController.GetProductsOfStore(storeName);
            productDetails.Append("<div class='col-lg-5 offset-lg-1'>");
            productDetails.Append("<div class='s_product_text'>");
            //productName = product[0];
            productDetails.Append("<h3>"+productName+"</h3>");
            //productPrice = product[0];
            productDetails.Append("<h2>$"+productPrice+"</h2>");
            productDetails.Append("<ul class='list'>");
            //productCategory = product[0];
            productDetails.Append("<li><a class='active' href='#'><span>Category</span> : " +productCategory +"</a></li>");
            //productAmount = product[0];
            productDetails.Append("<li><a href = '#' >< span > Availibility </ span > : "+productAmount+"</a></li>");
            productDetails.Append("</ul>");
            productDetails.Append("<div class='product_count'>");
            productDetails.Append("<label for='qty'>Quantity:</label>");
            productDetails.Append("<asp:TextBox id = 'ProductAmountTextBox' runat='server' placeholder='1' class='form-control' type='text'></asp:TextBox>>");
            productDetails.Append("<p></p>");
            productDetails.Append("<asp:Button ID ='Button5' class='button primary-btn' runat = 'server' Text='Add to Cart' OnClick='AddToCartButton1_Click'/>");
            //productDetails.Append("<a class='button primary-btn' href='#'>Add to Cart</a>");
            productDetails.Append("</div>");
            productDetails.Append("</div>");
            productDetails.Append("</div>");

        }
        protected void AddToCartButton1_Click(object sender, EventArgs e)
        {

        }

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