<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuthorityMast.aspx.cs" Inherits="ArmLicence.AuthorityMast" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main id="main" class="main">

    <div class="pagetitle">
      
    </div><!-- End Page Title -->

        
    <div class="section">
        <form runat="server" id="form1">
      <div class="row">
        <div class="col-sm-12 col-md-12 col-lg-12">

          <div class="card">
            <div class="card-body">
              <h5 class="card-title">Add New Authority Name</h5>

              <!-- No Labels Form -->
              <div class="row g-3">
                
                <div class="col-md-12">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" required></asp:DropDownList>
                </div>
                <div class="col-md-12">
                  <input type="text" class="form-control" placeholder="Authority Name" id="name" runat="server" required/>
                </div>
                    <div class="col-md-12">
                   <asp:Image ID="ProcessedImage" runat="server" Visible="true" />
                        </div>
                  <div class="col-md-12">
                      Authority Signature<br />
                      <asp:FileUpload ID="FileUpload1" runat="server" required/>
                </div>
                
                   <div class="text-center">
                   <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save Record" OnClick="btnSave_Click" />
                   <asp:Button ID="btnReset" runat="server" CssClass="btn btn-secondary" Text="Reset" />

                </div>
                 
                
                  <div class="col-md-12">
                      <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="table table-hover" DataKeyNames="ID" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" >
                         
                          <Columns>
                              <asp:CommandField ShowEditButton="True" />
                              <asp:TemplateField>
                                  <EditItemTemplate>
                                      <asp:FileUpload ID="FileUpload1" runat="server" />
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:Image ID="Image1" runat="server" />
                                  </ItemTemplate>
                              </asp:TemplateField>
                          </Columns>
                         
                          <EmptyDataTemplate>
                              No Weapon Record
                          </EmptyDataTemplate>
                      </asp:GridView>
                      </div>
              
              </div><!-- End No Labels Form -->

            </div>
          </div>

        </div>

        
      </div>
    </form>
            </div>

  </main>
</asp:Content>
