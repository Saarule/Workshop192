using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewGUI
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                CommunicationLayer.Controllers.CreateWorld.Init();
                Response.Redirect("index.aspx");
            }
            catch (Exception ee)
            {
                Response.Write("<script>alert('"+ee.Message+"');</script>");
            }
        }
    }
}