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
                  

            .style1 {
                font-size:12px;
                font-weight:bold;
                font-family:Arial, Helvetica, sans-serif;
                
            }
            .headingtext
            {

                color:white;
            }

            .subheading {
                font-weight:bold;
                font-size:10px;
                font-family:Arial, Helvetica, sans-serif;
                
            }
             .holderdata {
                 font-weight:bold;
                font-size:10px;
                font-family:Arial, Helvetica, sans-serif;
                text-align:left;
                padding-left:5px;
                
            }

             .uino {
            
            font-weight:bold;
            font-size:19px;
            color:#040067;
        }

        .stylebackgrid {
                font-size: 10px;
                padding: 10px 10px 10px 10px 10px
            }

        .disclamer {
                font-size: 8px
            }

        .issueauth {
                font-size: 11px;
                
                display: block;
                 padding-top: 12px;
            }
            table {
                border-collapse: separate;
                border-radius: 6px;
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

        </style>

 

    <script type="text/javascript">
        function PrintPage() {

        window.print();
    }
    </script>
</head>
<body style="font-family:Arial, Helvetica,sans-serif;margin:1px;text-align:center">
    <form id="form1" runat="server">
        <div class="auto-style4" id="divid">
       <table width="320px" height="195px" border="0"  style="border-collapse: collapse;" class="frontimg" cellpadding="0px" border-spacing="opx"
       cellspacing="0px">
           
  <tr class="headingtext">
    <td style="width:38%;background-color:#670001" colspan="2"><span class="style1"><asp:Label ID="lblpolice" runat="server" Text="Label"></asp:Label> </span><br /></td>
      <td style="width:13%" rowspan="2"><img src="img/header_img.png" width="28px" alt="" /></td>
   
    <td style="width:49%;background-color:#670001"><span class="style1"> ARMS LICENSE </span>
        <br />
    </td>
  </tr>
           
  <tr class="headingtext">
    <td style="width:45%;background-color:#020034" colspan="2"><span class="subheading"> Lic No. <asp:Label ID="lbllicno" runat="server" Text="Label"></asp:Label></span></td>
   
    <td style="width:45%;background-color:#020034"><span class="subheading"> Issue Date. <asp:Label ID="lbldoi" runat="server" Text="Label"></asp:Label></span>
    </td>
  </tr>
  <tr style="width:70px;vertical-align:bottom" class="holderdata">
    <td rowspan="4" style="padding-top:5px"> <asp:Image ID="Image1" runat="server" Width="65px" Height="68px"/>
        
        <asp:Image ID="Image2" runat="server" Width="65px" Height="20px"/></td>
    <td >NAME</td>
      <td colspan="2">: <asp:Label ID="lblname" runat="server" Text="Label" CssClass="style9"></asp:Label></td>
   
  </tr>
  <tr class="holderdata">
    <td >F.NAME</td>
      <td colspan="2" >: <asp:Label ID="lblfname" runat="server" Text="Label" class="style9"></asp:Label></td>
   
  </tr>
  <tr class="holderdata">
    <td >ADDRESS</td>
      <td colspan="2">: <asp:Label ID="lbladd" runat="server" Text="Label" CssClass="style9"></asp:Label></td>
   
  </tr>
  <tr class="holderdata">
    <td >CATEGORY</td>
      <td colspan="2">: </td>
   
  </tr>
  <tr class="holderdata">
    <td rowspan="3" ><asp:Image ID="Image3" runat="server" Width="65px" Height="65px"/></td>
    <td >VALID UPTO</td>
      <td colspan="2">: <asp:Label ID="lbldoe" runat="server" Text="Label"></asp:Label></td>
   
  </tr>
  <tr class="holderdata">
    <td >AREA VALIDITY</td>
      <td colspan="2">: <asp:Label ID="lblarea" runat="server" Text="Label" CssClass="style9"></asp:Label> </td>
   
  </tr>
  <tr>
    <td colspan="3" class="uino">UIN:<asp:Label ID="lbluin" runat="server" Text="Label"></asp:Label></td>
  </tr>
  </table>


       
      <table width="320px" height="195px" border="0"  class="backimg" style="padding-top:5px" cellpadding="0px" border-spacing="opx"
       cellspacing="0px">
  <tr style="height:70%">
       
    <td width="5%">

        
        &nbsp;</td>
       
    <td style="vertical-align:central ">

        
        <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="stylebackgrid" style="text-align:center;"  >
        </asp:GridView>
        
      </td>
       
    <td width="5%">

        
        &nbsp;</td>
  </tr>

            <tr>
       
    <td >
        
        &nbsp;</td>
       
    <td class="issueauth" style="text-align:center">
        
        <asp:Image ID="Image4" runat="server" Height="15px" Width="60px" />
                <br />
        
        Signature of issuing Authority</td>
       
    <td >
        
        &nbsp;</td>
  </tr>
            <tr>
       
    <td >
        
        &nbsp;</td>
       
    <td class="disclamer" style="text-align:center">
        
     
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
