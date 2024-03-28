<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConvertNumericToText2.aspx.cs" Inherits="ConvertNumericToText1.ConvertNumericToText2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 184px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <center>
	        <asp:Panel ID="pnlConvert" runat="server" 
                style="border-style:inset;width: 50%; height: 550px; margin-top: 80px; margin-bottom: 20px;" 
                BackColor="#EFF2FB" BorderStyle="Groove">

                <table id="tblConvert" runat="server" border="0" style="width:62%;background-color:#EFF2FB" >
                    <tr><td colspan="2" style="text-align:center"><h2>Convert Numeric To Text</h2></td></tr>
                    <tr><td colspan="2">&nbsp;</td></tr>
                    <tr>
                        <td class="auto-style1"><asp:Label ID="lblNumber" runat="server">Enter a Number :</asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtNumber" runat="server" style="margin-left: 0px" Width="250px" Font-Size="Medium"></asp:TextBox>&nbsp;
                            <asp:Button ID="btnConvert" runat="server" Text="Convert" OnClick="btnConvert_Click" BackColor="#007BFF" Font-Size="Medium" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td><asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Visible="false"></asp:Label></td>
                    </tr>
                    <tr><td colspan="2">&nbsp;</td></tr>
                    <tr>
                        <td class="auto-style1"><asp:Label ID="lblConvert" runat="server">Convert to Text :</asp:Label></td>
                        <td><asp:Label ID="lblConvertToText" runat="server" Width="350px" Font-Bold="true" Font-Size="Medium"></asp:Label></td>
                    </tr>
                
                </table>
              </asp:Panel>
        </center>
    </form>
</body>
</html>
