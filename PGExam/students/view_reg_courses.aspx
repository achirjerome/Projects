<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view_reg_courses.aspx.cs" Inherits="DesignTemplate1.students.view_reg_courses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            text-align: left;
            color: #006600;
        }
        .auto-style2 {
            text-align: center;
        }
         </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="auto-style1">
            <strong>Registered Courses</strong></div>
        <div class="auto-style2">

            <asp:GridView ID="GridView1" runat="server" PageSize="20" GridLines="Horizontal" CellPadding="5" CellSpacing="5">
                <Columns>
                    <asp:TemplateField HeaderText = "S/No" ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                        </ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
                    </asp:TemplateField>
                    
                </Columns>
                <HeaderStyle BackColor="#CCFFCC" />
            </asp:GridView>

        </div>
    </form>
   
</body>
</html>
