<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUsers.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.RegisterUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" />
        <asp:Button ID="sendSMS" runat="server" OnClick="sendSMS_Click" Text="send SMS to Hqtrs" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
