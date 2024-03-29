﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebLogin.aspx.cs" Inherits="ArmLicence.WebLogin" %>

<html lang="en">
    <head><meta charset="utf-8"><meta content="width=device-width, initial-scale=1.0" name="viewport">
        <title>Login</title><meta name="robots" content="noindex, nofollow">
        <meta content="" name="description"><meta content="" name="keywords"><link 
            ="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/img/favicon.png" rel="icon">
      <%--  <link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/img/apple-touch-icon.png" rel="apple-touch-icon"><link href="https://fonts.gstatic.com" rel="preconnect">
        <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Nunito:300,300i,400,400i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet">
        <link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"><link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet">
        <link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/boxicons/css/boxicons.min.css" rel="stylesheet"><link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/quill/quill.snow.css" rel="stylesheet">
        <link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/quill/quill.bubble.css" rel="stylesheet"><link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/remixicon/remixicon.css" rel="stylesheet">
        <link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/simple-datatables/style.css" rel="stylesheet"><link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/css/style.css" rel="stylesheet">--%>

          <!-- Vendor CSS Files -->
  <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <link href="assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet">
  <link href="assets/vendor/boxicons/css/boxicons.min.css" rel="stylesheet">
  <link href="assets/vendor/quill/quill.snow.css" rel="stylesheet">
  <link href="assets/vendor/quill/quill.bubble.css" rel="stylesheet">
  <link href="assets/vendor/remixicon/remixicon.css" rel="stylesheet">
  <link href="assets/vendor/simple-datatables/style.css" rel="stylesheet">

  <!-- Template Main CSS File -->
  <link href="assets/css/style.css" rel="stylesheet">


    </head><body><main><div class="container">
        
        <section class="section register min-vh-100 d-flex flex-column align-items-center justify-content-center py-4"><div class="container"><div class="row justify-content-center"><div class="col-lg-4 col-md-6 d-flex flex-column align-items-center justify-content-center"><div class="d-flex justify-content-center py-4"> <a href="#" class="logo d-flex align-items-center w-auto"> <img src="#" alt=""> <span class="d-none d-lg-block"><center> Card Based <br />Arms License Certificate</center></span> </a></div><div class="card mb-3"><div class="card-body"><div class="pt-4 pb-2"><h5 class="card-title text-center pb-0 fs-4">Login to Your Account</h5></div><form class="row g-3 needs-validation was-validated" novalidate="" runat="server"><div class="col-12"> <label for="yourUsername" class="form-label">Username</label><div class="input-group has-validation">  <input type="text" name="username" class="form-control" id="yourUsername"  runat="server" required><div class="invalid-feedback">Please enter your username.</div></div></div><div class="col-12"> <label for="yourPassword" class="form-label">Password</label> <input type="password" name="password" class="form-control" id="yourPassword" required runat="server"><div class="invalid-feedback">Please enter your password.</div></div>
            <div class="col-12"><div class="form-check"> 
                <asp:Label ID="lblerro" runat="server" Text="" CssClass="text-danger"></asp:Label>
            <%--<input class="form-check-input" type="checkbox" name="remember" value="true" id="rememberMe"> <label class="form-check-label" for="rememberMe">Remember me</label>--%></div></div><div class="col-12">
            
            <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-primary w-100" OnClick="LinkButton1_Click">Login</asp:LinkButton></div>
            <div class="col-12">
                
            </div></form></div></div>
            <div> <span style="font-size:12px"> Contents Owned and Maintained by Home Department, Haryana.
			</span>
                <br />
                <span style="font-size:12px">

				Developed  and Maintained by  
				NIC, Haryana.</span>


            </div></div></div></div></section></div></main> <a href="#" class="back-to-top d-flex align-items-center justify-content-center"><i class="bi bi-arrow-up-short"></i></a>  <script src="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/apexcharts/apexcharts.min.js"></script> <script src="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script> <script src="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/chart.js/chart.umd.js"></script> <script src="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/echarts/echarts.min.js"></script> <script src="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/quill/quill.min.js"></script> <script src="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/simple-datatables/simple-datatables.js"></script> <script src="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/tinymce/tinymce.min.js"></script> <script src="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/php-email-form/validate.js"></script>  <script src="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/js/main.js"></script> <script async="" src="https://www.googletagmanager.com/gtag/js?id=G-P7JSYB1CSP"></script><script>if (window.self == window.top) { window.dataLayer = window.dataLayer || []; function gtag() { dataLayer.push(arguments); } gtag('js', new Date()); gtag('config', 'G-P7JSYB1CSP'); }</script> <svg id="SvgjsSvg1001" width="2" height="0" xmlns="http://www.w3.org/2000/svg" version="1.1" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:svgjs="http://svgjs.dev" style="overflow: hidden; top: -100%; left: -100%; position: absolute; opacity: 0;"><defs id="SvgjsDefs1002"></defs><polyline id="SvgjsPolyline1003" points="0,0"></polyline><path id="SvgjsPath1004" d="M0 0 "></path></svg></body></html>