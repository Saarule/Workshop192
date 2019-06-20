using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewGUI
{
    public partial class confirmation : System.Web.UI.Page
    {
        string transcationPayId;
        string transcationSupplyId;
        protected void Page_Load(object sender, EventArgs e)
        {
            transcationPayId = Request["PayID"];
            transcationSupplyId = Request["SupplyID"];

            PlaceHolder3.Controls.Add(new Literal { Text = transcationPayId.ToString() });
            PlaceHolder4.Controls.Add(new Literal { Text = transcationSupplyId.ToString() });
        }
    }
}