using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class CheckoutPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PayButton1_Click(object sender, EventArgs e)
        {
            string CreditNum = TextBox1.Text;
            string Address = TextBox2.Text;
            if (CreditNum.Equals("") && Address.Equals(""))
            {
                Response.Write("<script>alert('The fields of CreditNum and Address empty');</script>");
            }
            else if (CreditNum.Equals(""))
            {
                Response.Write("<script>alert('The field of CreditNum empty');</script>");
            }
            else if (Address.Equals(""))
            {
                Response.Write("<script>alert('The field of Address empty');</script>");
            }
            else
            {
                Response.Write("<script>alert('The buying was succesfull');</script>");
            }
        }
    }
}