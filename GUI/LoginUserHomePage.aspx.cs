using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class LoginUserHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CommunicationLayer.Controllers.UsersController.isAdmin(GlobalSpecificUser.userNum))
                Button2.Visible = true;
        }
        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            bool ans = CommunicationLayer.Controllers.UsersController.Logout(GlobalSpecificUser.userNum);
            if (ans)
            {
                Response.Redirect("HomePage.aspx");
                Response.Write("<script>alert('Logout succesfuly');</script>");
            }
            else
            {
                Response.Write("<script>alert('Logout failed');</script>");
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string input = TextBox1.Text;
            if (input.Equals(""))
            {
                Response.Write("<script>alert('field of search is empty');</script>");
            }
            else
            {
                Session["inputSearch"] = TextBox1.Text;
                Response.Redirect("SearchPage.aspx");
            }
        }

        protected void WatchCartsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("DisplayCart.aspx");
        }

        protected void OpenStoreButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("OpenStorePage.aspx");
        }

        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckoutPage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RolesPage.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //remove user for admin
        }
    }
}