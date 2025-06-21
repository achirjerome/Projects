<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="StudentReg.aspx.cs" Inherits="DesignTemplate1.Admin.StudentReg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style4 {
        width: 350px;
    }
    .auto-style11 {
        width: 118px;
    }
    .auto-style12 {
        width: 72px;
    }
    .auto-style13 {
        width: 480px;
    }
    .auto-style14 {
        width: 384px;
    }
    .auto-style15 {
        width: 598px;
    }
    .auto-style16 {
        width: 118px;
        height: 38px;
    }
    .auto-style17 {
        width: 384px;
        height: 38px;
    }
    .auto-style18 {
        width: 598px;
        height: 38px;
    }
    .auto-style19 {
        width: 350px;
        height: 38px;
    }
    .auto-style20 {
        width: 118px;
        height: 36px;
    }
    .auto-style21 {
        width: 384px;
        height: 36px;
    }
    .auto-style22 {
        width: 598px;
        height: 36px;
    }
    .auto-style23 {
        width: 350px;
        height: 36px;
    }
    .auto-style24 {
        width: 118px;
        height: 37px;
    }
    .auto-style25 {
        width: 384px;
        height: 37px;
    }
    .auto-style26 {
        width: 598px;
        height: 37px;
    }
    .auto-style27 {
        width: 350px;
        height: 37px;
    }
    .auto-style28 {
        width: 72px;
        height: 20px;
    }
    .auto-style29 {
        width: 480px;
        height: 20px;
    }
    .auto-style30 {
        height: 20px;
    }
    .auto-style31 {
        width: 72px;
        height: 33px;
    }
    .auto-style32 {
        width: 480px;
        height: 33px;
    }
    .auto-style33 {
        height: 33px;
    }
    .auto-style34 {
        font-size: medium;
    }
    .auto-style35 {
        width: 480px;
        height: 20px;
        color: #CC3300;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
    <tr>
        <td class="auto-style12">&nbsp;</td>
        <td class="auto-style13">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style28"></td>
        <td class="auto-style35"><strong>Add New Student</strong></td>
        <td class="auto-style30"></td>
    </tr>
    <tr>
        <td class="auto-style28">&nbsp;</td>
        <td class="auto-style29">&nbsp;</td>
        <td class="auto-style30">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style12">&nbsp;</td>
        <td class="auto-style13">
            <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid">
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style11">&nbsp;</td>
                        <td class="auto-style14">&nbsp;</td>
                        <td class="auto-style15">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style16"></td>
                        <td class="auto-style17">Programme</td>
                        <td class="auto-style18">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlProgram" runat="server" Height="23px">
                                        <asp:ListItem>PGD</asp:ListItem>
                                        <asp:ListItem>MSc</asp:ListItem>
                                        <asp:ListItem>PhD</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="auto-style19"></td>
                    </tr>
                    <tr>
                        <td class="auto-style16"></td>
                        <td class="auto-style17">Course of Study</td>
                        <td class="auto-style18">
                            <asp:DropDownList ID="ddlCourseofStudy" runat="server" Height="27px" Width="240px">
                                <asp:ListItem>Computer Science</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style19"></td>
                    </tr>
                    <tr>
                        <td class="auto-style20"></td>
                        <td class="auto-style21">Matric No</td>
                        <td class="auto-style22">
                            <asp:TextBox ID="txtMatric_No" runat="server" Height="23px" Width="140px"></asp:TextBox>
                        </td>
                        <td class="auto-style23"></td>
                    </tr>
                    <tr>
                        <td class="auto-style24"></td>
                        <td class="auto-style25">First Name</td>
                        <td class="auto-style26">
                            <asp:TextBox ID="txtFirstname" runat="server" Height="23px" Width="140px"></asp:TextBox>
                        </td>
                        <td class="auto-style27"></td>
                    </tr>
                    <tr>
                        <td class="auto-style11"></td>
                        <td class="auto-style14">Surname</td>
                        <td class="auto-style15">
                            <asp:TextBox ID="txtSurname" runat="server" Height="23px" Width="140px"></asp:TextBox>
                        </td>
                        <td class="auto-style4"></td>
                    </tr>
                    <tr>
                        <td class="auto-style11">&nbsp;</td>
                        <td class="auto-style14">&nbsp;</td>
                        <td class="auto-style15">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style12">&nbsp;</td>
        <td class="auto-style13">&nbsp;</td>        
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style31"></td>
        <td class="auto-style32">
            <asp:Button ID="btnSubmit" runat="server" Height="25px" Text="Submit" Width="114px" CssClass="auto-style34" OnClick="btnSubmit_Click" />
        </td>
        <td class="auto-style33"></td>
    </tr>
    <tr>
        <td class="auto-style12">&nbsp;</td>
        <td class="auto-style13">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
