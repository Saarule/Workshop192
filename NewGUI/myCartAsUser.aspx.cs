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
    public partial class myCartAsUser : System.Web.UI.Page
    {
        StringBuilder tableProducts3 = new StringBuilder();
        LinkedList<LinkedList<string>> products3 = new LinkedList<LinkedList<string>>();
        int subTotal;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bool isLoggedIn = CommunicationLayer.Controllers.UsersController.IsLoggedIn(HttpContext.Current.Session.SessionID);
                if (!isLoggedIn)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You are not logged In to the system! Redirecting to index..');window.location ='index.aspx';", true);
                    return;
                }

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
                    subTotal = subTotal + (Int32.Parse(productAmount) * Int32.Parse(productPrice));
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
                PlaceHolder4.Controls.Add(new Literal { Text = subTotal.ToString() });
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
        protected void ProceedToCheckOutButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("checkoutAsUser.aspx");
        }
        protected void RemoveProductButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string productID = ProductToRemoveTextBox.Text;
                CommunicationLayer.Controllers.ProductsController.EditCart("delete", Int32.Parse(productID), HttpContext.Current.Session.SessionID);
                Response.Redirect("myCartAsUser.aspx");
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
    }
}