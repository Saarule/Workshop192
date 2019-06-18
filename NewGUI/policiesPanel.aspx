<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="policiesPanel.aspx.cs" Inherits="NewGUI.policiesPanel" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <title>Policies Panel</title>
	<link rel="icon" href="img/Fevicon.png" type="image/png">

  <link rel="stylesheet" href="vendors/bootstrap/bootstrap.min.css">
  <link rel="stylesheet" href="vendors/fontawesome/css/all.min.css">
    <link rel="stylesheet" href="vendors/themify-icons/themify-icons.css">
    <link rel="stylesheet" href="vendors/linericon/style.css">
  <link rel="stylesheet" href="vendors/owl-carousel/owl.theme.default.min.css">
  <link rel="stylesheet" href="vendors/owl-carousel/owl.carousel.min.css">
  <link rel="stylesheet" href="vendors/nice-select/nice-select.css">
  <link rel="stylesheet" href="vendors/nouislider/nouislider.min.css">

  <link rel="stylesheet" href="css/style.css">
</head>
<body>
  <!--================ Start Header Menu Area =================-->
    <form id="form2" runat="server">
	<header class="header_area">
    <div class="main_menu">
      <nav class="navbar navbar-expand-lg navbar-light">
        <div class="container">
          <a class="navbar-brand logo_h" href="index.html"><img src="img/logo.png" alt=""></a>
          <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <div class="collapse navbar-collapse offset" id="navbarSupportedContent">
            <ul class="nav navbar-nav menu_nav ml-auto mr-auto">
              <li class="nav-item"><a class="nav-link" href="index.html">Home</a></li>
              <li class="nav-item active submenu dropdown">
                <a href="#" class="nav-link dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true"
                  aria-expanded="false">Shop</a>
                <ul class="dropdown-menu">
                  <li class="nav-item"><a class="nav-link" href="category.html">Shop Category</a></li>
                  <li class="nav-item"><a class="nav-link" href="single-product.html">Product Details</a></li>
                  <li class="nav-item"><a class="nav-link" href="checkout.html">Product Checkout</a></li>
                  <li class="nav-item"><a class="nav-link" href="confirmation.html">Confirmation</a></li>
                  <li class="nav-item"><a class="nav-link" href="cart.html">Shopping Cart</a></li>
                </ul>
							</li>
							<li class="nav-item submenu dropdown">
                <a href="#" class="nav-link dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true"
                  aria-expanded="false">My Account</a>
                <ul class="dropdown-menu">
                  <li class="nav-item"><a class="nav-link" href="login.html">Login</a></li>
                  <li class="nav-item"><a class="nav-link" href="register.html">Register</a></li>
                </ul>
              </li>
              <li class="nav-item"><a class="nav-link" href="contact.html">Contact</a></li>
            </ul>

            <ul class="nav-shop">
              <li class="nav-item"><button><i class="ti-search"></i></button></li>
              <li class="nav-item"><button><i class="ti-shopping-cart"></i><span class="nav-shop__circle">3</span></button> </li>
              <li class="nav-item"><a class="button button-header" href="#">Buy Now</a></li>
            </ul>
          </div>
        </div>
      </nav>
    </div>
  </header>
	<!--================ End Header Menu Area =================-->

  
  
  <!--================Checkout Area =================-->
 
        <section class="order_details section-margin--small">
    <div class="container">
      <div class="row mb-5">
        <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h5 class="billing-title">Add policiy</h5>
            <table class="order-rable">
              <tr>
                <td>Store Amounts Purchase Policy:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="StoreNameTextBox" runat="server" placeholder="Store name" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox id="StoreMinimumAmountTextBox" runat="server" placeholder="Minimum Amount" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox id="StoreMaximumAmountTextBox" runat="server" placeholder="Maximum Amount" class="form-control" type="text"></asp:TextBox></td>
                </tr>
              <tr>
                <tr>
                <td>Product Amounts Purchase Policy:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="ProductNameTextBox" runat="server" placeholder="Product Name" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox id="ProductMinimumAmountTextBox" runat="server" placeholder="Minimum Amount" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox id="ProductMaximumAmountTextBox" runat="server" placeholder="Maximum Amount" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                  <tr>
                <td>Country Limit:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="CountryNameTextBox" runat="server" placeholder="Country" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                <td>User Limit:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="UserNameTextBox" runat="server" placeholder="Username" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                 <tr>
                <td>Compose policies:</td>
              </tr>
                <tr>
                    <td>

               <asp:DropDownList id="compositionType"
                    AutoPostBack="True"
                    runat="server">

                  <asp:ListItem Selected="True" Value="OR"> OR </asp:ListItem>
                  <asp:ListItem Value="AND"> AND </asp:ListItem>
                  <asp:ListItem Value="XOR"> XOR </asp:ListItem>

               </asp:DropDownList>
                
            </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
              <tr>
                <td><asp:Button ID="AddPolicyButton1" runat="server" class="button button-register w-100" Text="Add Policy" OnClick="AddPolicyButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>
       </div>
      </div>
  </section>
  <!--================End Checkout Area =================-->


<!--================ Start footer Area  =================-->	
	<footer class="footer">
		<div class="footer-area">
			<div class="container">
				<div class="row section_gap">
					<div class="col-lg-3 col-md-6 col-sm-6">
						<div class="single-footer-widget tp_widgets">
							
						</div>
					</div>
					<div class="offset-lg-1 col-lg-2 col-md-6 col-sm-6">
						<div class="single-footer-widget tp_widgets">
							
						</div>
					</div>
					<div class="col-lg-2 col-md-6 col-sm-6">
						<div class="single-footer-widget instafeed">
							
						</div>
					</div>
					<div class="offset-lg-1 col-lg-3 col-md-6 col-sm-6">
						<div class="single-footer-widget tp_widgets">
							
							
						</div>
					</div>
				</div>
			</div>
		</div>

		<div class="footer-bottom">
			<div class="container">
				<div class="row d-flex">
					
				</div>
			</div>
		</div>
	</footer>
	<!--================ End footer Area  =================-->



  <script src="vendors/jquery/jquery-3.2.1.min.js"></script>
  <script src="vendors/bootstrap/bootstrap.bundle.min.js"></script>
  <script src="vendors/skrollr.min.js"></script>
  <script src="vendors/owl-carousel/owl.carousel.min.js"></script>
  <script src="vendors/nice-select/jquery.nice-select.min.js"></script>
  <script src="vendors/jquery.ajaxchimp.min.js"></script>
  <script src="vendors/mail-script.js"></script>
  <script src="js/main.js"></script>
</form>
</body>
</html>
