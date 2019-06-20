<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ownStorePanel.aspx.cs" Inherits="NewGUI.ownStorePanel" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <title>Own Store Panel</title>
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
          <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <div class="collapse navbar-collapse offset" id="navbarSupportedContent">
            <ul class="nav navbar-nav menu_nav ml-auto mr-auto">
              <li class="nav-item"><a class="nav-link" href="indexLoginUser.aspx">Home</a></li>
              <li class="nav-item active submenu dropdown">
                <a href="#" class="nav-link dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true"
                  aria-expanded="false">Shop</a>
                <ul class="dropdown-menu">
                  <li class="nav-item"><a class="nav-link" href="productsAsUser.aspx">Browse Products</a></li>
                  <li class="nav-item"><a class="nav-link" href="myCartAsUser.aspx">My Cart</a></li>
                </ul>
							</li>
							<li class="nav-item submenu dropdown">
                <a href="#" class="nav-link dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true"
                  aria-expanded="false">My Account</a>
                <ul class="dropdown-menu">
                    <li class="nav-item"><a class="nav-link" href="userDashboard.aspx">User Dashboard</a></li>
                    <li class="nav-item"><a class="nav-link" href="storeOwnerDashboard.aspx">Store Owner Dashboard</a></li>
                 <!-- <li class="nav-item"><a class="nav-link" href="login.html">Login</a></li> -->
                 <!-- <li class="nav-item"><a class="nav-link" href="register.html">Register</a></li> -->
                 <!-- <li class="nav-item"><a class="nav-link" href="tracking-order.html">Tracking</a></li> -->
                </ul>
              </li>
            </ul>

           <ul class="nav-shop">
                <a href="mycartAsUser.aspx" class="notification">
                <span>Inbox</span>
                <span class="badge">3</span>
                 </a>

              <li class="nav-item"><a class="button button-header" href="productsAsUser.aspx">Buy Now</a></li>
            </ul>
          </div>
        </div>
      </nav>
    </div>
  </header>
	<!--================ End Header Menu Area =================-->

<!-- ================ start banner area ================= -->	
	<section class="blog-banner-area" id="category">
		<div class="container h-100">
			<div class="blog-banner">
				<div class="text-center">
					<h1>Store Owner Panel</h1>
					<nav aria-label="breadcrumb" class="banner-breadcrumb">
          </nav>
				</div>
			</div>
    </div>
	</section>
<!-- ================ end banner area ================= -->

  <!--================Order Details Area =================-->
  <section class="order_details section-margin--small">
    <div class="container">
      <div class="row mb-5">
          <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h3 class="billing-title">Add Store Manager</h3>
            <table class="order-rable">
              <tr>
                <td>Enter store manager username:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="StoreManagerToAddTextBox" runat="server" placeholder="Username" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                 <tr>
                <td>Privileges:</td>
              </tr>
                   <tr>
                          <td><asp:CheckBox ID="AddProductCheckBox" runat="server" Text="  Add Product" /></td>  
                   </tr>
                   <tr>
                          <td><asp:CheckBox ID="RemoveProductCheckBox" runat="server" Text="  Remove Product" /></td>  
                   </tr>
                     <tr>
                          <td><asp:CheckBox ID="EditProductCheckBox" runat="server" Text="  Edit Product" /></td>  
                   </tr>
                      <tr>
                          <td><asp:CheckBox ID="AddDiscountPolicyCheckBox" runat="server" Text="  Add discount policy" /></td>  
                   </tr>
                      <tr>
                          <td><asp:CheckBox ID="AddSellingPolicyCheckBox" runat="server" Text="  Add selling policy" /></td>  
                   </tr>
                     <tr>
                          <td><asp:CheckBox ID="RemoveDiscountPolicyCheckBox" runat="server" Text="  Remove discount policy" /></td>  
                   </tr>
                     <tr>
                          <td><asp:CheckBox ID="RemoveSellingPolicyCheckBox" runat="server" Text="  Remove selling policy" /></td>  
                   </tr>
              <tr>
                <td><asp:Button ID="Button5" runat="server" class="button button-register w-100" Text="Add Store Manager" OnClick="AddStoreManagerButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>
          <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h3 class="billing-title">Remove Store Manager</h3>
            <table class="order-rable">
              <tr>
                <td>Enter store manager username:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="StoreManagerToRemoveTextBox" runat="server" placeholder="Username" class="form-control" type="text"></asp:TextBox></td>
                </tr>
              <tr>
                <td><asp:Button ID="Button9" runat="server" class="button button-register w-100" Text="Remove Store Manager" OnClick="RemoveStoreManagerButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>
          <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h3 class="billing-title">Add Store Owner</h3>
            <table class="order-rable">
              <tr>
                <td>Enter store owner username:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="StoreOwnerTextBox" runat="server" placeholder="Username" class="form-control" type="text"></asp:TextBox></td>
                </tr>
              <tr>
                <td><asp:Button ID="Button2" runat="server" class="button button-register w-100" Text="Add Store Owner" OnClick="AddStoreOwnerButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>
   
      </div>
    </div>
  </section>
  <!--================End Order Details Area =================-->


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
