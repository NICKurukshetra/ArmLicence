<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="ArmLicence.Upload" %>

<html lang="en">
    <head><meta charset="utf-8"><meta content="width=device-width, initial-scale=1.0" name="viewport">
        <title>Fetch Data</title><meta name="robots" content="noindex, nofollow">
        <meta content="" name="description"><meta content="" name="keywords"><link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/img/favicon.png" rel="icon">
        <link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/img/apple-touch-icon.png" rel="apple-touch-icon"><link href="https://fonts.gstatic.com" rel="preconnect">
        <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Nunito:300,300i,400,400i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet">
        <link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"><link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet">
        <link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/boxicons/css/boxicons.min.css" rel="stylesheet"><link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/quill/quill.snow.css" rel="stylesheet">
        <link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/quill/quill.bubble.css" rel="stylesheet"><link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/remixicon/remixicon.css" rel="stylesheet">
        <link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/vendor/simple-datatables/style.css" rel="stylesheet"><link href="https://bootstrapmade.com/demo/templates/NiceAdmin/assets/css/style.css" rel="stylesheet">
        <style type="text/css">

#main,
  #footer {
    margin-left: 50px;
    margin-right: 50px;
  }

#main {
  margin-top: 0px;
  padding: 20px 30px;
  transition: all 0.3s;
}
        </style>

    </head><body>
        

        <main id="main" class="main"><div class="pagetitle"></div><section class="section"><div class="row"><div class="col-lg-12"><div class="card">
            <div class="card-title text-center text-danger h2">ARMS LICENSE Printing</div>
              <hr />
            <div class="card-body">
           <center> <h5 class="card-title">Upload Data by Excel</h5></center>
          

          <center>
            <form runat="server">

                <div class="row mb-3"> <label for="inputText" class="col-sm-2 col-form-label">Upload</label>
                <div class="col-sm-3"> <asp:FileUpload ID="FileUpload1" runat="server" /></div>
                    <label for="inputText" class="col-sm-2 col-form-label">License No</label>
                <div class="col-sm-3"> <input type="text" class="form-control" id="txtlicno" runat="server"></div>
                <div class="col-sm-2">   <asp:Button ID="btnsearch" runat="server" class="btn btn-primary" Text="Upload Data" OnClick="btnsearch_Click" />   </div>

                </div>

                
                
                                
                        
                <asp:GridView ID="GridView1" runat="server" CssClass="table" BorderStyle="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" EmptyDataText="No Record Found">
                    <Columns>
                        <asp:CommandField SelectText="Print" ShowSelectButton="True"></asp:CommandField>
                    </Columns>
                </asp:GridView>
            </form>
              
          </center>

           </div></div></div>
            

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           </div></section></main>

           </body></html>