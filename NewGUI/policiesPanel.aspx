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
                  <li class="nav-item"><a class="nav-link" href="products.aspx">Browse Products</a></li>
                  <li class="nav-item"><a class="nav-link" href="myCart.aspx">My Cart</a></li>
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
                <a href="mycart.aspx" class="notification">
                <span>Inbox</span>
                <span class="badge">3</span>
                 </a>

              <li class="nav-item"><a class="button button-header" href="products.aspx">Buy Now</a></li>
            </ul>
          </div>
        </div>
      </nav>
    </div>
  </header>
	<!--================ End Header Menu Area =================-->

  	<!-- ================ start Selling policies banner area ================= -->	
	<section class="blog-banner-area" id="category">
		<div class="container h-100">
			<div class="blog-banner">
				<div class="text-center">
					<h1>Selling Policies</h1>
					<nav aria-label="breadcrumb" class="banner-breadcrumb">
          </nav>
				</div>
			</div>
    </div>
	</section>
	<!-- ================ end Selling policies banner area ================= -->
  
  <!--================Checkout Area 1=================-->
 
        <section class="order_details section-margin--small">
    <div class="container">
      <div class="row mb-5">
        <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h5 class="billing-title">Minimum Amount to buy from product Policy:</h5>
            <table class="order-rable">
                <tr>
                <td>Enter products IDs and Amount:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="MinimumProductIdTextBox1" runat="server" placeholder="Product policy is apply on" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox id="MinimumProductIdTextBox2" runat="server" placeholder="Product policy evaluates" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox id="ProductMinimumAmountTextBox" runat="server" placeholder="Minimum Amount" class="form-control" type="text"></asp:TextBox></td>
                </tr>
            
                 <tr>
                <td>Compose policies:</td>
              </tr>
                <tr>
                    <td>

               <asp:DropDownList id="compositionTypeMinimumProductAmount"
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
                <td><asp:Button ID="MinimumAmountToBuyFromProductButton1" runat="server" class="button button-register w-100" Text="Add Policy" OnClick="MinimumAmountToBuyFromProductButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>

          <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h5 class="billing-title">Maximum Amount to buy from product Policy:</h5>
            <table class="order-rable">
                <tr>
                <td>Enter products IDs and Amount:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="MaximumProductIdTextBox1" runat="server" placeholder="Product policy is apply on" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox id="MaximumProductIdTextBox2" runat="server" placeholder="Product policy evaluates" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox id="ProductMaximumAmountTextBox" runat="server" placeholder="Maximum Amount" class="form-control" type="text"></asp:TextBox></td>
                </tr>
            
                 <tr>
                <td>Compose policies:</td>
              </tr>
                <tr>
                    <td>

               <asp:DropDownList id="DropDownList2"
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
                <td><asp:Button ID="MaximumAmountToBuyFromProductButton1" runat="server" class="button button-register w-100" Text="Add Policy" OnClick="MaximumAmountToBuyFromProductButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>

          <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h5 class="billing-title">Minimum Amount to buy from Store Policy:</h5>
            <table class="order-rable">
                <tr>
                <td>Enter store name and Amount:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="MinimumStoreNameTextBox" runat="server" placeholder="Store name" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox id="MinimumStoreAmountTextBox" runat="server" placeholder="Minimum Amount" class="form-control" type="text"></asp:TextBox></td>
                </tr>
            
                 <tr>
                <td>Compose policies:</td>
              </tr>
                <tr>
                    <td>

               <asp:DropDownList id="DropDownList3"
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
                <td><asp:Button ID="MinimumAmountToBuyFromStoreButton1" runat="server" class="button button-register w-100" Text="Add Policy" OnClick="MinimumAmountToBuyFromStoreButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>

          <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h5 class="billing-title">Maximum Amount to buy from Store Policy:</h5>
            <table class="order-rable">
                <tr>
                <td>Enter store name and Amount:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="MaximumStoreNameTextBox" runat="server" placeholder="Store name" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox id="MaximumStoreAmountTextBox" runat="server" placeholder="Maximum Amount" class="form-control" type="text"></asp:TextBox></td>
                </tr>
            
                 <tr>
                <td>Compose policies:</td>
              </tr>
                <tr>
                    <td>

               <asp:DropDownList id="DropDownList4"
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
                <td><asp:Button ID="MaximumAmountToBuyFromStoreButton1" runat="server" class="button button-register w-100" Text="Add Policy" OnClick="MaximumAmountToBuyFromStoreButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>

          <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h5 class="billing-title">Ban User from Store Policy:</h5>
            <table class="order-rable">
                <tr>
                <td>Enter Username to Ban:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="UserNameToBanTextBox" runat="server" placeholder="Username" class="form-control" type="text"></asp:TextBox></td>
                </tr>
            
                 <tr>
                <td>Compose policies:</td>
              </tr>
                <tr>
                    <td>

               <asp:DropDownList id="DropDownList5"
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
                <td><asp:Button ID="UserToBanFromStoreButton1" runat="server" class="button button-register w-100" Text="Add Policy" OnClick="UserToBanFromStoreButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>

          <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h5 class="billing-title">Ban Country from Store Policy:</h5>
            <table class="order-rable">
                <tr>
                <td>Enter Country to Ban:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="CountryToBanTextBox" runat="server" placeholder="Country" class="form-control" type="text"></asp:TextBox></td>
                </tr>
            
                 <tr>
                <td>Compose policies:</td>
              </tr>
                <tr>
                    <td>

               <asp:DropDownList id="DropDownList6"
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
                <td><asp:Button ID="CountryToBanFromStoreButton1" runat="server" class="button button-register w-100" Text="Add Policy" OnClick="CountryToBanFromStoreButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>

       </div>
      </div>
  </section>
  <!--================End Checkout Area 1=================-->

<!-- ================ start Discount policies banner area ================= -->	
	<section class="blog-banner-area" id="category">
		<div class="container h-100">
			<div class="blog-banner">
				<div class="text-center">
					<h1>Discount policies</h1>
					<nav aria-label="breadcrumb" class="banner-breadcrumb">

                 </nav>
				</div>
			</div>
         </div>
	</section>
	<!-- ================ end Discount policies banner area ================= -->

          <!--================Checkout Area 2=================-->
 
        <section class="order_details section-margin--small">
    <div class="container">
      <div class="row mb-5">
        <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h5 class="billing-title">Minimum Amount to buy from product Policy:</h5>
            <table class="order-rable">
                <tr>
                <td>Enter products IDs and Amount:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="DiscountMinimumProductIdTextBox1" runat="server" placeholder="Product policy is apply on" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox id="DiscountMinimumProductIdTextBox2" runat="server" placeholder="Product policy evaluates" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox id="DiscountProductMinimumAmountTextBox" runat="server" placeholder="Minimum Amount" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td><asp:TextBox id="DiscountMinimumProductInPercentage" runat="server" placeholder="Discount in %" class="form-control" type="text"></asp:TextBox></td>
                </tr>
            
                 <tr>
                <td>Compose policies:</td>
              </tr>
                <tr>
                    <td>

               <asp:DropDownList id="DropDownList1"
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
                <td><asp:Button ID="Button1" runat="server" class="button button-register w-100" Text="Add Policy" OnClick="DiscountMinimumAmountToBuyFromProductButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>

          <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h5 class="billing-title">Maximum Amount to buy from product Policy:</h5>
            <table class="order-rable">
                <tr>
                <td>Enter products IDs and Amount:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="DiscountMaximumProductIdTextBox1" runat="server" placeholder="Product policy is apply on" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox id="DiscountMaximumProductIdTextBox2" runat="server" placeholder="Product policy evaluates" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox id="DiscountProductMaximumAmountTextBox" runat="server" placeholder="Maximum Amount" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                  <tr>
                    <td><asp:TextBox id="DiscountMaximumProductInPercentage" runat="server" placeholder="Discount in %" class="form-control" type="text"></asp:TextBox></td>
                </tr>
            
                 <tr>
                <td>Compose policies:</td>
              </tr>
                <tr>
                    <td>

               <asp:DropDownList id="DropDownList7"
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
                <td><asp:Button ID="Button2" runat="server" class="button button-register w-100" Text="Add Policy" OnClick="DiscountMaximumAmountToBuyFromProductButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>

          <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h5 class="billing-title">Minimum Amount to buy from Store Policy:</h5>
            <table class="order-rable">
                <tr>
                <td>Enter store name and Amount:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="DiscountMinimumStoreNameTextBox" runat="server" placeholder="Store name" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox id="DiscountMinimumStoreAmountTextBox" runat="server" placeholder="Minimum Amount" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                   <tr>
                    <td><asp:TextBox id="DiscountMinimumStoreInPercentage" runat="server" placeholder="Discount in %" class="form-control" type="text"></asp:TextBox></td>
                </tr>
            
                 <tr>
                <td>Compose policies:</td>
              </tr>
                <tr>
                    <td>

               <asp:DropDownList id="DropDownList8"
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
                <td><asp:Button ID="Button3" runat="server" class="button button-register w-100" Text="Add Policy" OnClick="DiscountMinimumAmountToBuyFromStoreButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>

          <div class="col-md-6 col-xl-4 mb-4 mb-xl-0">
          <div class="confirmation-card">
            <h5 class="billing-title">Maximum Amount to buy from Store Policy:</h5>
            <table class="order-rable">
                <tr>
                <td>Enter store name and Amount:</td>
              </tr>
                <tr>
                    <td><asp:TextBox id="DiscountMaximumStoreNameTextBox" runat="server" placeholder="Store name" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox id="DiscountMaximumStoreAmountTextBox" runat="server" placeholder="Maximum Amount" class="form-control" type="text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox id="DiscountMaximumStoreInPercentage" runat="server" placeholder="Discount in %" class="form-control" type="text"></asp:TextBox></td>
                </tr>
            
                 <tr>
                <td>Compose policies:</td>
              </tr>
                <tr>
                    <td>

               <asp:DropDownList id="DropDownList9"
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
                <td><asp:Button ID="Button4" runat="server" class="button button-register w-100" Text="Add Policy" OnClick="DiscountMaximumAmountToBuyFromStoreButton1_Click" /></td>
              </tr>
            </table>
          </div>
        </div>


       </div>
      </div>
  </section>
  <!--================End Checkout Area 2=================-->

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
