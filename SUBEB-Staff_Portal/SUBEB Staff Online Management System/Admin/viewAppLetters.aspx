<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewAppLetters.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Admin.viewAppLetters" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 1046px;
        }
        .auto-style3 {
            height: 752px;
        }
        .auto-style4 {
            width: 1046px;
            height: 752px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style4">
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" BorderWidth="2px" Height="989px" Width="930px">
                        <asp:Image ID="Image1" runat="server" Height="980px" Width="926px" />
                    </asp:Panel>
                </td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="btnTreated" runat="server" Text="Treated" OnClick="btnTreated_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
