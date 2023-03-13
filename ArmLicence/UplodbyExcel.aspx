<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UplodbyExcel.aspx.cs" Inherits="ArmLicence.UplodbyExcel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main id="main" class="main"><div class="pagetitle"></div><section class="section"><div class="row"><div class="col-lg-12"><div class="card">
            <div class="card-title text-center text-danger h2">ARMS LICENSE Printing</div>
              <hr />
            <div class="card-body">
           <center> <h5 class="card-title">Upload Data by Excel</h5></center>
          <span class="pull-right"><a href="tblweaponholder.xls" >Download sample data </a></span>
                <br />

          <center>
            <form runat="server">

                <div class="row mb-4"> <label for="inputText" class="col-sm-2 col-form-label">Upload File(.xls)</label>
                <div class="col-sm-6"> <asp:FileUpload ID="FileUpload1" runat="server" /></div>
                
              
                <div class="col-sm-2">   <asp:Button ID="btnsearch" runat="server" class="btn btn-primary" Text="Upload Data" OnClick="btnsearch_Click" />   </div>

                </div>

                <div class="col-md-12">
                    <asp:Label ID="lblerror" runat="server" Text="" CssClass="text-danger"></asp:Label></div>

                
                
                                
                        
                <asp:GridView ID="GridView1" runat="server" CssClass="table" BorderStyle="None"  EmptyDataText="No Record Uploaded">
                   
                </asp:GridView>
            </form>
              
          </center>

           </div></div></div>
            

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           </div></section></main>
</asp:Content>
