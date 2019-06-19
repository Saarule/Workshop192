using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewGUI
{
    public partial class checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BuyNowButton1_Click(object sender, EventArgs e)
        {
            string name = FirstNameTextBox.Text + LastNameTextBox.Text;
            string addressToDeliver = CountryTextBox.Text + CityTextBox.Text + StreetTextBox.Text;
            /*
            bool ans = CommunicationLayer.Controllers.ProductsController.ProcessOfBuying(null,HttpContext.Current.Session.SessionID, name , addressToDeliver);
            if (ans)
            {
                Response.Redirect("confirmation.aspx");
                Response.Write("<script>alert('Successful Purchase');</script>");
            }
            else
            {
                Response.Write("<script>alert('Purchase failed');</script>");
            }
            */
        }
    }
}