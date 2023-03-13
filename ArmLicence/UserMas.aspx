<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserMas.aspx.cs" Inherits="ArmLicence.UserMas" %>
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
              <h5 class="card-title">Add New User</h5>

              <!-- No Labels Form -->
              <div class="row g-3">
                
                <div class="col-md-12">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" required>
                      
                    </asp:DropDownList>
                </div>
                <div class="col-md-6">
                  <input type="text" class="form-control" placeholder="User Name" id="uid" runat="server" required>
                </div>
                <div class="col-md-6">
                  <input type="text" class="form-control" placeholder="Password" id="pass" runat="server" required>
                </div>
                  <div class="col-md-6">
                  <input type="text" class="form-control" placeholder="Mobile" runat="server" id="mobile" required/>
                </div>
                   <div class="col-md-6">
                  <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" required>
                         
                        <asp:ListItem Value="U">Authority</asp:ListItem>
                       <asp:ListItem Value="V">Authority Verifier</asp:ListItem>
                      <asp:ListItem Value="A">Admin</asp:ListItem>
                       </asp:DropDownList>
                </div>
                  
                


                
                  <div class="col-md-12">
                      <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="table table-hover" DataKeyNames="Id" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" >
                         
                          <Columns>
                              <asp:CommandField ShowEditButton="True" />
                          </Columns>
                         
                          <EmptyDataTemplate>
                              No Weapon Record
                          </EmptyDataTemplate>
                      </asp:GridView>
                      </div>
               <div class="text-center">
                   <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save Record" OnClick="btnSave_Click"  />
                   <asp:Button ID="btnReset" runat="server" CssClass="btn btn-secondary" Text="Reset" />

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
