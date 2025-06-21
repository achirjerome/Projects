<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewLetters.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Admin.viewLetters" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
            width: 860px;
            background-color: #FFCCCC;
        }
        .auto-style3 {
            width: 860px;
        }
        .auto-style4 {
            width: 860px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style2"><strong>Scanned Coopy</strong></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style4">
                    <asp:Image ID="Image1" runat="server" BorderStyle="Solid" BorderWidth="2px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
