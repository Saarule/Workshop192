﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageStorePanel.aspx.cs" Inherits="NewGUI.manageStorePanel" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <title>Aroma Shop</title>
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
              <li class="nav-item"><a class="nav-link" href="indexLoginUser.aspx">Home</a></li>
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
                    <li class="nav-item"><a class="nav-link" href="userDashboard.aspx">User Dashboard</a></li>
                    <li class="nav-item"><a class="nav-link" href="storeOwnerDashboard.aspx">Store Owner Dashboard</a></li>
                 <!-- <li class="nav-item"><a class="nav-link" href="login.html">Login</a></li> -->
                 <!-- <li class="nav-item"><a class="nav-link" href="register.html">Register</a></li> -->
                 <!-- <li class="nav-item"><a class="nav-link" href="tracking-order.html">Tracking</a></li> -->
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

  <!--================Order Details Area =================-->
  <section class="order_details section-margin--small">
    <div class="container">
      <div class="row mb-5">
        <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h3 class="billing-title">Add Product</h3>
            <table class="order-rable">
              <tr>
                <td>Enter product name:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="ProductNameTextBox1" runat="server" placeholder="Product name" class="form-control" type="text"></asp:TextBox></td>
                </tr>
              <tr>
                <tr>
                <td>Enter product category:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="ProductCategoryTextBox" runat="server" placeholder="Category" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                  <tr>
                <td>Enter product price:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="ProductPriceTextBox" runat="server" placeholder="Product price" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                 <tr>
                <td>Enter product amount:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="ProductAmountTextBox" runat="server" placeholder="Product amount" class="form-control" type="text"></asp:TextBox></td>
                </tr>
              <tr>
                <td><asp:Button ID="Button3" runat="server" class="button button-register w-100" Text="Add Product" OnClick="AddProductButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>
        <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h3 class="billing-title">Remove Product</h3>
            <table class="order-rable">
              <tr>
                <td>Enter product ID:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="ProductIdToDeleteTextBox" runat="server" placeholder="Product ID" class="form-control" type="text"></asp:TextBox></td>
                </tr>
              <tr>
                <td><asp:Button ID="Button1" runat="server" class="button button-register w-100" Text="Remove Product" OnClick="RemoveProductButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>
        <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h3 class="billing-title">Edit Product</h3>
            <table class="order-rable">
              <tr>
                <td>Enter product ID:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="ProductIdTextBox2" runat="server" placeholder="Product ID" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                <td>Enter product name:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="ProductNameTextBox2" runat="server" placeholder="Product name" class="form-control" type="text"></asp:TextBox></td>
                </tr>
              <tr>
                <tr>
                <td>Enter product category:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="ProductCategoryTextBox2" runat="server" placeholder="Category" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                  <tr>
                <td>Enter product price:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="ProductPriceTextBox2" runat="server" placeholder="Product price" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                 <tr>
                <td>Enter product amount:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="ProductAmountTextBox2" runat="server" placeholder="Product amount" class="form-control" type="text"></asp:TextBox></td>
                </tr>
              <tr>
                <td><asp:Button ID="Button4" runat="server" class="button button-register w-100" Text="Edit Product" OnClick="EditProductButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>
          <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h3 class="billing-title">Remove Product</h3>
            <table class="order-rable">
              <tr>
                <td>Enter product ID:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="TextBox1" runat="server" placeholder="Product ID" class="form-control" type="text"></asp:TextBox></td>
                </tr>
              <tr>
                <td><asp:Button ID="Button2" runat="server" class="button button-register w-100" Text="Remove Product" OnClick="RemoveProductButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>
          <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h3 class="billing-title">Remove Product</h3>
            <table class="order-rable">
              <tr>
                <td>Enter product ID:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="TextBox2" runat="server" placeholder="Product ID" class="form-control" type="text"></asp:TextBox></td>
                </tr>
              <tr>
                <td><asp:Button ID="Button5" runat="server" class="button button-register w-100" Text="Remove Product" OnClick="RemoveProductButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>
          <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h3 class="billing-title">Remove Product</h3>
            <table class="order-rable">
              <tr>
                <td>Enter product ID:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="TextBox3" runat="server" placeholder="Product ID" class="form-control" type="text"></asp:TextBox></td>
                </tr>
              <tr>
                <td><asp:Button ID="Button6" runat="server" class="button button-register w-100" Text="Remove Product" OnClick="RemoveProductButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>
      </div>
    </div>
  </section>
  <!--================End Order Details Area =================-->



  <!--================ Start footer Area  =================-->	
	<footer>
		<div class="footer-area footer-only">
			<div class="container">
				<div class="row section_gap">
					<div class="col-lg-3 col-md-6 col-sm-6">
						<div class="single-footer-widget tp_widgets ">
							<h4 class="footer_title large_title">Our Mission</h4>
							<p>
								So seed seed green that winged cattle in. Gathering thing made fly you're no 
								divided deep moved us lan Gathering thing us land years living.
							</p>
							<p>
								So seed seed green that winged cattle in. Gathering thing made fly you're no divided deep moved 
							</p>
						</div>
					</div>
					<div class="offset-lg-1 col-lg-2 col-md-6 col-sm-6">
						<div class="single-footer-widget tp_widgets">
							<h4 class="footer_title">Quick Links</h4>
							<ul class="list">
								<li><a href="#">Home</a></li>
								<li><a href="#">Shop</a></li>
								<li><a href="#">Blog</a></li>
								<li><a href="#">Product</a></li>
								<li><a href="#">Brand</a></li>
								<li><a href="#">Contact</a></li>
							</ul>
						</div>
					</div>
					<div class="col-lg-2 col-md-6 col-sm-6">
						<div class="single-footer-widget instafeed">
							<h4 class="footer_title">Gallery</h4>
							<ul class="list instafeed d-flex flex-wrap">
								<li><img src="img/gallery/r1.jpg" alt=""></li>
								<li><img src="img/gallery/r2.jpg" alt=""></li>
								<li><img src="img/gallery/r3.jpg" alt=""></li>
								<li><img src="img/gallery/r5.jpg" alt=""></li>
								<li><img src="img/gallery/r7.jpg" alt=""></li>
								<li><img src="img/gallery/r8.jpg" alt=""></li>
							</ul>
						</div>
					</div>
					<div class="offset-lg-1 col-lg-3 col-md-6 col-sm-6">
						<div class="single-footer-widget tp_widgets">
							<h4 class="footer_title">Contact Us</h4>
							<div class="ml-40">
								<p class="sm-head">
									<span class="fa fa-location-arrow"></span>
									Head Office
								</p>
								<p>123, Main Street, Your City</p>
	
								<p class="sm-head">
									<span class="fa fa-phone"></span>
									Phone Number
								</p>
								<p>
									+123 456 7890 <br>
									+123 456 7890
								</p>
	
								<p class="sm-head">
									<span class="fa fa-envelope"></span>
									Email
								</p>
								<p>
									free@infoexample.com <br>
									www.infoexample.com
								</p>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>

		<div class="footer-bottom">
			<div class="container">
				<div class="row d-flex">
					<p class="col-lg-12 footer-text text-center">
						<!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
Copyright &copy;<script>document.write(new Date().getFullYear());</script> All rights reserved | This template is made with <i class="fa fa-heart" aria-hidden="true"></i> by <a href="https://colorlib.com" target="_blank">Colorlib</a>
<!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. --></p>
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