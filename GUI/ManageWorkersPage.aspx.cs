using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class ManageWorkersPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SendButton_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Equals("")) {
                Response.Write("<script>alert('The field of user name empty');</script>");
            }
            bool [] privileges = new bool[6];
            bool wasDone = false;
            for(int i = 0; i < CheckBox2.Items.Count; i++)
            {
                if (CheckBox2.Items[i].Selected == true)
                {
                    privileges[i] = true;
                    wasDone = true;
                }
            }
            if(wasDone == false && RadioButtonList1.Items[1].Selected == true)
            {
                Response.Write("<script>alert('must at least 1 action!');</script>");
            }
            string action = "";
            for (int i = 0; i < RadioButtonList1.Items.Count; i++)
            {
                if (RadioButtonList1.Items[i].Selected)
                {
                    if (i == 0)
                        action = "addStoreOwner";
                    else if (i == 1)
                        action = "addStoreManager";
                    else if (i == 2)
                        action = "deleteStoreOnwer";
                    else
                        action = "deleteStoreManager";
                }
            }
            // play command with action and privileges
        }

        protected void ContinueButton_Click(object sender, EventArgs e)
        {
            Label2.Visible = true;
            TextBox1.Visible = true;
            SendButton.Visible = true;
            if (RadioButtonList1.Items[1].Selected)
            {
                CheckBox2.Visible = true;
                priviLabel.Visible = true;
            }
            else
            {
                CheckBox2.Visible = false;
                priviLabel.Visible = false;
            }
        }
    }
}