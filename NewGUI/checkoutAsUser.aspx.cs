﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workshop192;

namespace NewGUI
{
    public partial class checkoutAsUser : System.Web.UI.Page
    {
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
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }

        }
        protected void BuyNowButton1_Click(object sender, EventArgs e)
        {

            try
            {

                string name = FirstNameTextBox.Text + LastNameTextBox.Text;
                string creditCardHolderName = CreditCardHolderTextBox.Text;
                string creditCardNumber = CreditCardNumberTextBox.Text;
                string creditCardYear = CreditCardYearTextBox.Text;
                string creditCardMonth = CreditCardMonthTextBox.Text;
                string ccv = DigitsBehindCardTextBox.Text;
                string creditCardHolderID = IDnumberOfHolderTextBox.Text;
                string country = CountryTextBox.Text;
                string city = CityTextBox.Text;
                string street = StreetTextBox.Text;
                string zip = ZipcodeTextBox.Text;


                string[] ans = CommunicationLayer.Controllers.ProductsController.ProcessOfBuying(creditCardNumber, creditCardMonth, creditCardYear, creditCardHolderName, ccv, creditCardHolderID, name, street, city, country, zip, HttpContext.Current.Session.SessionID);
                string transcationPayId = ans[0];
                string transcationSupplyId = ans[1];


                if (transcationPayId != "-1" && transcationSupplyId != "-1")
                {
                    Response.Redirect("confirmationAsUser.aspx?PayID=" + transcationPayId + "&SupplyID=" + transcationSupplyId);
                    Response.Write("<script>alert('Successful Purchase');</script>");
                }
                else
                {
                    if (transcationPayId == "-1" && transcationSupplyId == "-1")
                        Response.Write("<script>alert('money system and delivery system failed');</script>");
                    else if (transcationPayId == "-1")
                        Response.Write("<script>alert('money system failed');</script>");
                    else
                        Response.Write("<script>alert('delivery system failed');</script>");
                }
            }
            catch (ErrorMessageException exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + exception.Message + "')", true);
            }
            catch (Exception)
            {
                Response.Write("<script>alert('purchase faild - error details');</script>");
            }

        }




    }
}
            
    
