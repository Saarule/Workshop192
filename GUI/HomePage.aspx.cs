using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            //this.Form.Target = "_blank";
            GlobalSpecificUser.Start();
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }

        protected void LogInButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string input = TextBox1.Text;
            if (input.Equals(""))
            {
                Response.Write("<script>alert('field of search is empty');</script>");
            }
            else {
                Session["inputSearch"] = TextBox1.Text;
                Response.Redirect("SearchPage.aspx");
            }
        }

        protected void WatchCartsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("DisplayCart.aspx");
        }

        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckoutPage.aspx");
        }
    }
}