<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sprint.aspx.cs" Inherits="ArmLicence.Sprint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
        function PrintPage() {
            window.print();
        }
    </script>

    <style type="text/css">
        @media print {

            .btn {
               display:none;
            }
        }

            .style2 {
                font-size: 16px;
                font-family:'Times New Roman', Times, serif;
                font-weight: bold;
                color: #A80F0C;
    position: relative;
    top: 6px;
            }

            .style13 {
                font-size: 7px
            }

            .style3 {
                font-size: 10px
            }

            .style9 {
                font-size: 10px;
                font-weight: bold
            }

            .style10 {
                font-size: 8px;
                font-weight: bold;
                display: block;
    padding-top: 12px;
            }

            .style4 {
                font-size: 10px;
                padding: 10px 10px 10px 10px 10px
            }

            table {
                border-collapse: separate;
                border-radius: 6px;
            }



            .auto-style1 {
                text-align: right;
            }

            .backimg {
                background: url(img/back.jpeg);
                background-repeat: no-repeat;
                background-size: cover;
            }

            .frontimg {
                background: url(img/front.jpeg);
                background-repeat: no-repeat;
                background-size: cover;
            }




            .auto-style2 {
                width: 76px;
            }







            .auto-style4 {
                text-align: left;
            }
        
        

      
        

        .auto-style5 {
            font-size: 12px;
        }
        
        

      
        

        </style>

 
     <script>
         // Add an event listener for the 'keydown' event on the document
         document.addEventListener('keydown', function (event) {
             // Check if Ctrl key (or Cmd key on Mac) and 'P' key are pressed
             if ((event.ctrlKey || event.metaKey) && event.key === 'p') {
                 // Prevent the default print action
                 event.preventDefault();
             }
         });
     </script>
    <script type="text/javascript">
        function PrintPage() {

        window.print();
    }
    </script>
</head>
<body style="font-family:Arial, Helvetica,sans-serif;margin:3px;text-align:center">
    <form id="form1" runat="server">
        <div class="auto-style4" id="divid">
       <table width="320px" height="195px" border="0"  style="border-collapse: collapse;" class="frontimg" cellpadding="0px" border-spacing="opx"
       cellspacing="0px">
  <tr>
    <td  rowspan="2" style="text-align:center;" class="style3"><img src="img/header_img.png" width="28px"  /><br /><strong><asp:Label ID="lblpolice" runat="server" Text="Label"></asp:Label> </strong> </td>
    <td style="text-align:right" class="style2"> ARMS LICENSE  </td>
  </tr>
  <tr>
    <td style="text-align:right" class="style3"><strong>Lic No</strong>.
        <strong>
        <asp:Label ID="lbllicno" runat="server" Text="Label"></asp:Label> </strong>&nbsp;&nbsp; </td>
  </tr>
  <tr height="5px">
    <td colspan="1" style="padding-right:7px" class="auto-style2">
        <asp:Image ID="Image1" runat="server" Width="80px" Height="80px"/>
        <br />
        <asp:Image ID="Image2" runat="server" Width="80px" Height="20px"/>

    </td>

    <td >
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="style3">
        
        Name<br />
     
          <asp:Label ID="lblname" runat="server" Text="Label" CssClass="style9"></asp:Label></td>
                <td class="auto-style1" rowspan="4" style="vertical-align:top">
      

        <asp:Image ID="Image3" runat="server" Width="95px"/> 
      

                </td>
            </tr>
            <tr>
                <td class="style3">Father's Name <br />
      
          <asp:Label ID="lblfname" runat="server" Text="Label" class="style9"></asp:Label> </td>
            </tr>
            <tr>
                <td class="style3">Address<br />
   
          <asp:Label ID="lbladd" runat="server" Text="Label" CssClass="style9"></asp:Label> </td>
            </tr>
            <tr>
                <td class="style3">Area Validity <br />
       
            <asp:Label ID="lblarea" runat="server" Text="Label" CssClass="style9"></asp:Label>  </td>
            </tr>
        </table>
      

          </td>
   
  </tr>
  <tr>
       
    <td  colspan="2" >
        <table style="width:100%">
            <tr style="position:relative;bottom:10px;">
                <td style="font-weight:bold;font-size:10px"><span class="style3">UIN<br />
                    <asp:Label ID="lbluin" runat="server" Text="Label" CssClass="auto-style5"></asp:Label></span></td>
                <td class="style3">Date of Issue<br />
        <span class="style9"> <asp:Label ID="lbldoi" runat="server" Text="Label"></asp:Label></span> </td>
                <td class="style3">Date of Expiry <br />
       <span class="style9">  <asp:Label ID="lbldoe" runat="server" Text="Label"></asp:Label></span></td>
            </tr>
        </table>
      </td>
  </tr>
  </table>


       
      <table width="320px" height="195px" border="0"  class="backimg" style="padding-top:5px" cellpadding="0px" border-spacing="opx"
       cellspacing="0px">
  <tr style="height:70%">
       
    <td width="5%">

        
        &nbsp;</td>
       
    <td>

        
        <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="style4" style="border:thin;text-align:center;"  >
        </asp:GridView>
        
      </td>
       
    <td width="5%">

        
        &nbsp;</td>
  </tr>

            <tr>
       
    <td >
        
        &nbsp;</td>
       
    <td class="style10" style="text-align:center">
        
        <asp:Image ID="Image4" runat="server"  Width="100px" />
            <br />    
        
        Signature of issuing Authority

    </td>
       
    <td >
        
        &nbsp;</td>
  </tr>
            <tr>
       
    <td >
        
        &nbsp;</td>
       
    <td class="style13" style="text-align:center">
        
     
       Disclaimer: This card is property of Govt. of India if found please post it to<br />
        <asp:Label ID="lblauthority" runat="server" Text="Authority"></asp:Label>

    </td>
       
    <td >
        
        &nbsp;</td>
  </tr>
  </table>
        </div>
       
        <asp:Button ID="Button1" runat="server" Text="Print" CssClass="btn" OnClientClick="javascript:PrintPage();" OnClick="Button1_Click"/>

    
        <a href="UserMain.aspx"><button type="button"  class="btn"> Close</button></a>
    </form>
</body>
</html>
