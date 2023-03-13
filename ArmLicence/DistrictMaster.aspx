<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DistrictMaster.aspx.cs" Inherits="ArmLicence.DistrictMaster" %>
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
              <h5 class="card-title">District Master</h5>

              <!-- No Labels Form -->
              <div class="row g-3">
                
               
                <div class="col-md-12">
                  <input type="text" class="form-control" placeholder="District Name" id="name" runat="server" required/>
                </div>
                  
                

                  <div class="text-center">
                   <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save Record" OnClick="btnSave_Click" />
                   <asp:Button ID="btnReset" runat="server" CssClass="btn btn-secondary" Text="Reset" />

                </div>
                
                  <div class="col-md-12">
                      <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="table table-hover" >
                         
                          <EmptyDataTemplate>
                              No  Record
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
