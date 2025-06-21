<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="DesignTemplate1.Admin.RegisterUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            margin-left: 0;
        }
        .auto-style5 {
            width: 8px;
        }
        .auto-style8 {
            height: 35px;
        }
        .auto-style9 {
            height: 30px;
        }
        .auto-style10 {
            height: 29px;
        }
        .auto-style11 {
            height: 31px;
        }
        .auto-style12 {
            width: 167px;
        }
        .auto-style13 {
            height: 35px;
            width: 167px;
        }
        .auto-style14 {
            height: 30px;
            width: 167px;
        }
        .auto-style15 {
            height: 29px;
            width: 167px;
        }
        .auto-style16 {
            height: 31px;
            width: 167px;
        }
        .auto-style17 {
            width: 497px;
        }
        .auto-style18 {
            color: #339933;
        }
        .auto-style19 {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
&nbsp;&nbsp; <span class="auto-style18"><strong>&nbsp;Register New User</strong></span></p>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <table class="auto-style1">
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style17">
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" CssClass="auto-style4">
                    <table class="auto-style1">
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style12">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8"></td>
                            <td class="auto-style13">Staff Number</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="txtStaffNo" runat="server" Height="23px" Width="200px"></asp:TextBox>
                            </td>
                            <td class="auto-style8"></td>
                        </tr>
                        <tr>
                            <td class="auto-style9"></td>
                            <td class="auto-style14">Email Address</td>
                            <td class="auto-style9">
                                <asp:TextBox ID="txtEmail" runat="server" Height="23px" Width="200px"></asp:TextBox>
                            </td>
                            <td class="auto-style9"></td>
                        </tr>
                        <tr>
                            <td class="auto-style10"></td>
                            <td class="auto-style15">Password</td>
                            <td class="auto-style10">
                                <asp:TextBox ID="txtpassword" runat="server" Height="23px" Width="200px"></asp:TextBox>
                            </td>
                            <td class="auto-style10"></td>
                        </tr>
                        <tr>
                            <td class="auto-style11"></td>
                            <td class="auto-style16">Confirm Password</td>
                            <td class="auto-style11">
                                <asp:TextBox ID="txtConfirmEmail" runat="server" Height="23px" Width="200px"></asp:TextBox>
                            </td>
                            <td class="auto-style11"></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style12">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style17">
                <asp:Button ID="btnSubmit" runat="server" CssClass="auto-style19" Height="30px" OnClick="btnSubmit_Click" Text="Submit" Width="111px" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
