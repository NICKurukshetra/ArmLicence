<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PendingbioUpload.aspx.cs" Inherits="ArmLicence.PendingbioUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main id="main" class="main"><div class="pagetitle"></div><section class="section"><div class="row"><div class="col-lg-12"><div class="card">
            <div class="card-title text-center text-danger h2">Upload Photo/Signature</div>
              <hr />
            <div class="card-body">
           <center> <h5 class="card-title">Pending data UIN No Wise</h5></center>
          

          <center>
            <form runat="server">

                <%--<div class="row mb-3"> <label for="inputText" class="col-sm-2 col-form-label">UIN</label>
                <div class="col-sm-3"> <input type="text" class="form-control" id="txtuin" runat="server" required></div>
                    <label for="inputText" class="col-sm-2 col-form-label">License No</label>
                <div class="col-sm-3"> <input type="text" class="form-control" id="txtlicno" runat="server"></div>
                <div class="col-sm-2">   <asp:Button ID="btnsearch" runat="server" class="btn btn-primary" Text="Search" OnClick="btnsearch_Click" />   </div>

                </div>--%>

                
                
                                
                        
                <asp:GridView ID="GridView1" runat="server" CssClass="table" BorderStyle="None" EmptyDataText="No Record Found" DataKeyNames="ID" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                    <Columns>
                        <asp:TemplateField>
                            <EditItemTemplate>
                                 <label for="inputNanme4" class="form-label">Upload Photo</label>
                                <asp:FileUpload ID="FileUpload1" runat="server" required/>
                                 <label for="inputNanme4" class="form-label">Signature</label>
                                <asp:FileUpload ID="FileUpload2" runat="server" required/>
                            </EditItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:CommandField ShowEditButton="True" />
                        </Columns>
                </asp:GridView>
            </form>
              
          </center>

           </div></div></div>
            

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           </div></section></main>
</asp:Content>
