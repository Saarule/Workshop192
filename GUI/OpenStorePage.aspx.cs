using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class OpenStorePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Send_Click(object sender, EventArgs e)
        {
            string storeName = TextBox1.Text;
            if (storeName.Equals(""))
            {
                Response.Write("<script>alert('The field of store name empty');</script>");
            }
            else
            {
                bool ans = CommunicationLayer.Controllers.ProductsController.OpenStore(storeName, HttpContext.Current.Session.SessionID);
                if (ans)
                {
                    Response.Write("<script>alert('succesfully opening store');</script>");
                }
                else
                {
                    Response.Write("<script>alert('The store name is exists');</script>");
                }
            }
        }
    }
}