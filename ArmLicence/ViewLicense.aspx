<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewLicense.aspx.cs" Inherits="ArmLicence.ViewLicense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Verify License</title>
     <meta content="width=device-width, initial-scale=1.0" name="viewport"/>
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
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="card">
                <div class="card-body">
            <asp:Image ID="Image1" runat="server"  CssClass="img-thumbnail" Width="120px" />
                    <br />
            <asp:Image ID="Image2" runat="server"  CssClass="img-thumbnail" Width="120px" />
            <asp:DetailsView ID="DetailsView1" runat="server" CssClass="table table-active">
                <EmptyDataTemplate>
                    No Record Found
                </EmptyDataTemplate>
                    </asp:DetailsView>
             <br />
            <asp:GridView ID="GridView2" runat="server" CssClass="table table-light">
                <EmptyDataTemplate>
                    No Weapon Record
                </EmptyDataTemplate>
                    </asp:GridView>
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Panel ID="Panel1" runat="server">
                            <asp:Button ID="btnupdate" runat="server" Text="Verify Record" CssClass="btn btn-danger"  onClientClick=" return confirm('Are you sure?')" OnClick="btnupdate_Click" />


                          <a href="VerifyCard.aspx" class="btn btn-info">Back</a>
                       </asp:Panel>
                        </div>

                    </div>
              </div>
                </div>
        </div>
    </form>
</body>
</html>
