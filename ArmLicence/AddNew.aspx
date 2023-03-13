<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNew.aspx.cs" Inherits="ArmLicence.AddNew" %>
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
              <h5 class="card-title">Add New Holder Data</h5>
                 <asp:Label ID="lblerror" runat="server" Text="" CssClass="text-bg-danger"></asp:Label>
              <!-- No Labels Form -->
              <div class="row g-3">
                
                <div class="col-md-6">
                      <label for="inputNanme4" class="form-label">UIN No (18 Digits)</label>
                  
                  
                  <input type="number" class="form-control"  id="uin" runat="server" maxlength="4" required>
                </div>
                <div class="col-md-6">
                    <label for="inputNanme4" class="form-label">License No</label>
                  <input type="text" class="form-control"  id="licno" runat="server" required>
                </div>
                  <div class="col-md-12">
                        <label for="inputNanme4" class="form-label">Holder Name</label>
                  <input type="text" class="form-control" runat="server" id="name" required>
                </div>
                   <div class="col-md-12">
                         <label for="inputNanme4" class="form-label">Holder Father's Name</label>
                  <input type="text" class="form-control"  runat="server" id="fname" required>
                </div>
                <div class="col-12">
                    <label for="inputNanme4" class="form-label">Address</label>
                    <textarea class="form-control"  id="add" style="height: 80px;" runat="server"></textarea>
                </div>
                <div class="col-md-4">
                     <label for="inputNanme4" class="form-label">Mobile (10 Digit)</label>
                  <input type="number" class="form-control" runat="server" id="mobile" required>
                </div>
                <div class="col-md-4">
                       <label for="inputNanme4" class="form-label">Area of Validity</label>

                    <asp:DropDownList ID="area" runat="server" CssClass="form-control" required>
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>All India</asp:ListItem>
                        <asp:ListItem>District</asp:ListItem>
                        <asp:ListItem>SDM/Taluka/Tehsil/Others</asp:ListItem>
                        <asp:ListItem>State</asp:ListItem>
                        <asp:ListItem>Three Adjoining District</asp:ListItem>
                        <asp:ListItem>Three Adjoining State</asp:ListItem>
                       </asp:DropDownList>
                <%-- <input type="text" class="form-control"  runat="server" id="area" required>--%>
                </div>
                <div class="col-md-4">
                     <label for="inputNanme4" class="form-label">License Type</label>
                  <input type="text" class="form-control"  runat="server" id="lictype" required>
                </div>
                   <div class="col-md-6">
                       <label for="inputNanme4" class="form-label">Date of Issue (DD/MM/YYYY)</label>
                  <input  class="form-control"  runat="server" id="doi" required>
                </div>
                <div class="col-md-6">
                     <label for="inputNanme4" class="form-label">Date of Expiry (DD/MM/YYYY)</label>
                 <input  class="form-control"  runat="server" id="doe" required>
                </div>
                
                   
                 
                  <div class="col-md-3">
                       <label for="inputNanme4" class="form-label">Weapon</label>
                      <asp:DropDownList ID="weapon" runat="server" CssClass="form-control">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Air Weapon</asp:ListItem>
                        <asp:ListItem>Blank Firing Gun</asp:ListItem>
                        <asp:ListItem>DBBL Combination Gun</asp:ListItem>
                        <asp:ListItem>DBBL Combination Gun and Pistol</asp:ListItem>
                        <asp:ListItem>DBBL Rifle</asp:ListItem>
                        <asp:ListItem>Handgun Revolver or Pistol</asp:ListItem>
                          <asp:ListItem>Rifle</asp:ListItem>
                          <asp:ListItem>Shotguns DBBL SBBL DBML SBML</asp:ListItem>
                          <asp:ListItem>TBBL Combination of Gun and Rifle</asp:ListItem>
                       </asp:DropDownList>
                 <%-- <input type="text" class="form-control" placeholder="Weapon" runat="server" id="weapon">--%>
                </div>
                   <div class="col-md-2">
                       <label for="inputNanme4" class="form-label">Bore</label>
                  <input type="text" class="form-control" placeholder="Bore" runat="server" id="bore">
                </div>
                  <div class="col-md-4">
                      <label for="inputNanme4" class="form-label">Weapon No</label>
                  <input type="text" class="form-control" placeholder="Weapon No" runat="server" id="weaponno">
                </div>
                  
                  <div class="col-md-3">
                       <label for="inputNanme4" class="form-label">Ammunition</label>
                  <input type="text" class="form-control" placeholder="Ammunition" runat="server" id="Ammunition">
                </div>


                   <div class="col-md-10">
                  
                </div>
                  
                   <div class="col-md-2">
                       <asp:Button ID="btnadd" runat="server" Text="Add Row" OnClick="btnadd_Click"  formnovalidate/>
                       
                   </div>
                  <div class="col-md-12">
                            <asp:Label ID="lblgriderror" runat="server" Text="" CssClass="text-bg-danger"></asp:Label>

                      <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="table table-hover" OnRowDeleting="GridView1_RowDeleting">
                          <Columns>
                              <asp:TemplateField ShowHeader="False">
                                  <ItemTemplate>
                                      <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                  </ItemTemplate>
                              </asp:TemplateField>
                          </Columns>
                          <EmptyDataTemplate>
                              No Weapon Record
                          </EmptyDataTemplate>
                      </asp:GridView>
                      </div>

                   <div class="col-md-6">
                        <label for="inputText" class="col-sm-4 col-form-label">Upload Photo</label>
                        <asp:FileUpload ID="FileUpload1" runat="server" required OnUnload="FileUpload1_Unload"/>
                </div>
                <div class="col-md-6">
                 <label for="inputText" class="col-sm-6 col-form-label">Upload Signature</label>
                        <asp:FileUpload ID="FileUpload2" runat="server" required/>
                </div>
                <hr />
                 
               <div class="text-center">
                   <asp:Button ID="btnSave"  runat="server" CssClass="btn btn-primary" Text="Save Record" OnClick="btnSave_Click" />
                   <asp:Button ID="btnReset" runat="server" CssClass="btn btn-secondary" Text="Reset" OnClick="btnReset_Click" />

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
