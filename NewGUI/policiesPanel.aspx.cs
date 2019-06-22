using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workshop192;

namespace NewGUI
{
    public partial class policiesPanel : System.Web.UI.Page
    {
        string storeName;
        protected void Page_Load(object sender, EventArgs e)
        {
            storeName = Request["storeName"];
            string policiesString = CommunicationLayer.Controllers.ProductsController.GetPolicyOfStore(storeName);
            PlaceHolder1.Controls.Add(new Literal { Text = policiesString.ToString() });
        }

        protected void MinimumAmountToBuyFromProductButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string id1 = MinimumProductIdTextBox1.Text;
                string id2 = MinimumProductIdTextBox2.Text;
                string amount = ProductMinimumAmountTextBox.Text;
                string selectedCompositon = compositionType1.SelectedItem.Value;

                LinkedList<string> parameters = new LinkedList<string>();
                parameters.AddLast("Min");
                parameters.AddLast(selectedCompositon);
                parameters.AddLast(id1);
                parameters.AddLast(id2);
                parameters.AddLast(amount);
                CommunicationLayer.Controllers.ProductsController.AddBuyingPolicy(parameters, storeName, HttpContext.Current.Session.SessionID);
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
        protected void MaximumAmountToBuyFromProductButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string id1 = MaximumProductIdTextBox1.Text;
                string id2 = MaximumProductIdTextBox2.Text;
                string amount = ProductMinimumAmountTextBox.Text;
                string selectedCompositon = compositionType2.SelectedItem.Value;

                LinkedList<string> parameters = new LinkedList<string>();
                parameters.AddLast("Max");
                parameters.AddLast(selectedCompositon);
                parameters.AddLast(id1);
                parameters.AddLast(id2);
                parameters.AddLast(amount);
                CommunicationLayer.Controllers.ProductsController.AddBuyingPolicy(parameters, storeName, HttpContext.Current.Session.SessionID);
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
        protected void MinimumAmountToBuyFromStoreButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string productID = MinimumStoreProductIDTextBox.Text;
                string amount = MinimumStoreAmountTextBox.Text;
                string selectedCompositon = compositionType3.SelectedItem.Value;

                LinkedList<string> parameters = new LinkedList<string>();
                parameters.AddLast("Min");
                parameters.AddLast(selectedCompositon);
                parameters.AddLast("0");
                parameters.AddLast(productID);
                parameters.AddLast(amount);
                CommunicationLayer.Controllers.ProductsController.AddBuyingPolicy(parameters, storeName, HttpContext.Current.Session.SessionID);
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
        protected void MaximumAmountToBuyFromStoreButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string productID = MaximumStoreProductIDTextBox.Text;
                string amount = MaximumStoreAmountTextBox.Text;
                string selectedCompositon = compositionType4.SelectedItem.Value;

                LinkedList<string> parameters = new LinkedList<string>();
                parameters.AddLast("Max");
                parameters.AddLast(selectedCompositon);
                parameters.AddLast("0");
                parameters.AddLast(productID);
                parameters.AddLast(amount);
                CommunicationLayer.Controllers.ProductsController.AddBuyingPolicy(parameters, storeName, HttpContext.Current.Session.SessionID);
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
        protected void UserToBanFromStoreButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string userNameToBan = UserNameToBanTextBox.Text;
                string selectedCompositon = compositionType5.SelectedItem.Value;

                LinkedList<string> parameters = new LinkedList<string>();
                parameters.AddLast("Ban");
                parameters.AddLast(selectedCompositon);
                parameters.AddLast("0");
                parameters.AddLast(userNameToBan);
                parameters.AddLast("user");
                CommunicationLayer.Controllers.ProductsController.AddBuyingPolicy(parameters, storeName, HttpContext.Current.Session.SessionID);
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
        protected void CountryToBanFromStoreButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string countryNameToBan = UserNameToBanTextBox.Text;
                string selectedCompositon = compositionType6.SelectedItem.Value;

                LinkedList<string> parameters = new LinkedList<string>();
                parameters.AddLast("Ban");
                parameters.AddLast(selectedCompositon);
                parameters.AddLast("0");
                parameters.AddLast(countryNameToBan);
                parameters.AddLast("country");
                CommunicationLayer.Controllers.ProductsController.AddBuyingPolicy(parameters, storeName, HttpContext.Current.Session.SessionID);
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
        protected void DiscountMinimumAmountToBuyFromProductButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string id1 = DiscountMinimumProductIdTextBox1.Text;
                string id2 = DiscountMinimumProductIdTextBox2.Text;
                string amount = DiscountProductMinimumAmountTextBox.Text;
                string discount = DiscountMinimumProductInPercentage.Text;
                string selectedCompositon = compositionType7.SelectedItem.Value;

                LinkedList<string> parameters = new LinkedList<string>();
                parameters.AddLast("Min");
                parameters.AddLast(selectedCompositon);
                parameters.AddLast(id1);
                parameters.AddLast(id2);
                parameters.AddLast(amount);
                CommunicationLayer.Controllers.ProductsController.AddDiscountPolicy(parameters, storeName, Int32.Parse(discount), HttpContext.Current.Session.SessionID);
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }

        }
        protected void DiscountMaximumAmountToBuyFromProductButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string id1 = DiscountMaximumProductIdTextBox1.Text;
                string id2 = DiscountMaximumProductIdTextBox2.Text;
                string amount = DiscountProductMaximumAmountTextBox.Text;
                string discount = DiscountMaximumProductInPercentage.Text;
                string selectedCompositon = compositionType8.SelectedItem.Value;

                LinkedList<string> parameters = new LinkedList<string>();
                parameters.AddLast("Max");
                parameters.AddLast(selectedCompositon);
                parameters.AddLast(id1);
                parameters.AddLast(id2);
                parameters.AddLast(amount);
                CommunicationLayer.Controllers.ProductsController.AddDiscountPolicy(parameters, storeName, Int32.Parse(discount), HttpContext.Current.Session.SessionID);
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
        protected void DiscountMinimumAmountToBuyFromStoreButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string productID = DiscountMinimumStoreProductIDTextBox.Text;
                string amount = DiscountMinimumStoreAmountTextBox.Text;
                string discount = DiscountMinimumStoreInPercentage.Text;
                string selectedCompositon = compositionType9.SelectedItem.Value;

                LinkedList<string> parameters = new LinkedList<string>();
                parameters.AddLast("Min");
                parameters.AddLast(selectedCompositon);
                parameters.AddLast("0");
                parameters.AddLast(productID);
                parameters.AddLast(amount);
                CommunicationLayer.Controllers.ProductsController.AddBuyingPolicy(parameters, storeName, HttpContext.Current.Session.SessionID);
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
        protected void DiscountMaximumAmountToBuyFromStoreButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string productID = DiscountMaximumStoreProductIDTextBox.Text;
                string amount = DiscountMaximumStoreAmountTextBox.Text;
                string discount = DiscountMaximumStoreInPercentage.Text;
                string selectedCompositon = compositionType10.SelectedItem.Value;

                LinkedList<string> parameters = new LinkedList<string>();
                parameters.AddLast("Max");
                parameters.AddLast(selectedCompositon);
                parameters.AddLast("0");
                parameters.AddLast(productID);
                parameters.AddLast(amount);
                CommunicationLayer.Controllers.ProductsController.AddBuyingPolicy(parameters, storeName, HttpContext.Current.Session.SessionID);
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }


        protected void RemoveSellingPolicyButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string productId = IdOfProductToRemoveItsSellingPolicyTextBox1.Text;
                CommunicationLayer.Controllers.ProductsController.RemoveBuyingPolicy(storeName, Int32.Parse(productId), HttpContext.Current.Session.SessionID);
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
        protected void RemoveDiscountPolicyButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string productId = IdOfProductToRemoveItsDiscountPolicyTextBox1.Text;
                CommunicationLayer.Controllers.ProductsController.RemoveDiscountPolicy(storeName, Int32.Parse(productId), HttpContext.Current.Session.SessionID);
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
        }
        
    }
}