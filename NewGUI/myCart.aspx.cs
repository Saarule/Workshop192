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
    public partial class myCart : System.Web.UI.Page
    {
        StringBuilder tableProducts3 = new StringBuilder();
        LinkedList<LinkedList<string>> products3 = new LinkedList<LinkedList<string>>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string productId;
                string productName;
                string productCategory;
                string productPrice;
                string productAmount;
                string productStoreName;
                products3 = CommunicationLayer.Controllers.ProductsController.DisplayCart(HttpContext.Current.Session.SessionID);
                for (int i = 0; i < products3.Count; i++)
                {
                    productId = products3.ElementAt(i).ElementAt(0);
                    productName = products3.ElementAt(i).ElementAt(1);
                    productCategory = products3.ElementAt(i).ElementAt(2);
                    productPrice = products3.ElementAt(i).ElementAt(3);
                    productAmount = products3.ElementAt(i).ElementAt(4);
                    productStoreName = products3.ElementAt(i).ElementAt(5);

                    tableProducts3.Append("<tr>");
                    tableProducts3.Append("<td>");
                    tableProducts3.Append("<div class='media'>");
                    tableProducts3.Append("<div class='d-flex'>");
                    tableProducts3.Append("<img src = 'img/cart/cart1.png' alt=''>");
                    tableProducts3.Append("</div>");
                    tableProducts3.Append("<div class='media-body'>");
                    tableProducts3.Append("<h5>" + productName + "</h5>");
                    tableProducts3.Append("</div>");
                    tableProducts3.Append("</div>");
                    tableProducts3.Append("</td>");
                    tableProducts3.Append("<td>");
                    tableProducts3.Append("<h5>$" + productPrice + "</h5>");
                    tableProducts3.Append("</td>");

                    tableProducts3.Append("<td>");
                    tableProducts3.Append("<h5>" + productAmount + "</h5>");
                    tableProducts3.Append("</td>");
                    //tableProducts3.Append("<div>");
                    //tableProducts3.Append("<td>");
                    //tableProducts3.Append("<asp:TextBox id='ProductAmountTextBox"+productId+"' runat='server' maxlength='12' placeholder='1' class='form-control' type='text' Text="+productAmount+"></asp:TextBox>");
                    //tableProducts3.Append("</td>");
                    //tableProducts3.Append("</div>");

                    tableProducts3.Append("<td>");
                    int total = (Int32.Parse(productPrice) * Int32.Parse(productAmount));
                    tableProducts3.Append("<h5>$" + total.ToString() + "</h5>");

                    tableProducts3.Append("</td>");
                    tableProducts3.Append("</tr>");
                }
                PlaceHolder3.Controls.Add(new Literal { Text = tableProducts3.ToString() });
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
        protected void ProceedToCheckOutButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("checkout.aspx");
            /*
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
            */
        }
        

        /*
            <tr>
                  <td>
                      <div class="media">
                          <div class="d-flex">
                              <img src = "img/cart/cart1.png" alt="">
                          </div>
                          <div class="media-body">
                              <p>Minimalistic shop for multipurpose use</p>
                          </div>
                      </div>
                  </td>
                  <td>
                      <h5>$370.00</h5>
                  </td>
                  <td>
                  <asp:TextBox id = 'ProductAmountTextBox' runat= 'server' maxlength= "10" placeholder= '1' class='form-control' type='text' Text='1'></asp:TextBox>
                      </td>
                  <td>
                      <h5>$720.00</h5>
                  </td>
              </tr>

         */

        /*
                <tr>
                      <td>
                          <div class="media">
                              <div class="d-flex">
                                  <img src = "img/cart/cart1.png" alt="">
                              </div>
                              <div class="media-body">
                                  <p>Minimalistic shop for multipurpose use</p>
                              </div>
                          </div>
                      </td>
                      <td>
                          <h5>$360.00</h5>
                      </td>
                      <td>
                          <div class="product_count">
                              <input type = "text" name="qty" id="sst" maxlength="12" value="1" title="Quantity:"
                                  class="input-text qty">
                              <button onclick = "var result = document.getElementById('sst'); var sst = result.value; if( !isNaN( sst )) result.value++;return false;"
                                  class="increase items-count" type="button"><i class="lnr lnr-chevron-up"></i></button>
                              <button onclick = "var result = document.getElementById('sst'); var sst = result.value; if( !isNaN( sst ) &amp;&amp; sst > 0 ) result.value--;return false;"
                                  class="reduced items-count" type="button"><i class="lnr lnr-chevron-down"></i></button>
                          </div>
                      </td>
                      <td>
                          <h5>$720.00</h5>
                      </td>
                  </tr>


*/

        /*
                                      <tr><td><div class='media'><div class='d-flex'><img src = 'img/cart/cart1.png' alt=''></div><div class='media-body'><h5>milk</h5></div></div></td><td><h5>$120</h5></td><td><div class='product_count'><input type = 'text' name='qty' id='sst' maxlength='12' value='1' title='Quantity: 'class='input-text qty'><button onclick = 'var result = document.getElementById('sst'); var sst = result.value; if (!isNaN(sst)) result.value++; return false;class='increase items-count' type='button'><i class='lnr lnr-chevron-up'></i></button><button onclick = 'var result = document.getElementById('sst'); var sst = result.value; if (!isNaN(sst) & amp; &amp; sst > 0 ) result.value--; return false;class='reduced items-count' type='button'><i class='lnr lnr-chevron-down'></i></button></div></td><td><h5>$120</h5></td></tr>
        */
    }
}
 