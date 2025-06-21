<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="addCourseofStudy.aspx.cs" Inherits="DesignTemplate1.Admin.addCourseofStudy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style4 {
        text-align: center;
    }
    .auto-style5 {
        height: 24px;
        font-size: small;
        color: #FF3300;
    }
    .auto-style7 {
        height: 29px;
    }
    .auto-style8 {
        height: 35px;
    }
    .auto-style12 {
        height: 31px;
            width: 444px;
        }
    .auto-style13 {
        height: 26px;
        width: 146px;
    }
    .auto-style14 {
        height: 35px;
        width: 146px;
    }
    .auto-style15 {
        height: 26px;
    }
    .auto-style16 {
        margin-left: 112;
    }
    .auto-style17 {
        width: 4px;
    }
    .auto-style18 {
            width: 204px;
        }
        .auto-style19 {
            height: 22px;
        }
        .auto-style20 {
            height: 22px;
            width: 146px;
        }
        .auto-style21 {
            height: 41px;
        }
        .auto-style22 {
            height: 41px;
            width: 146px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style4">
    <strong>
    <br />Add New Course of Study<br />&nbsp;</strong></div>
<div class="auto-style4">
    <asp:Label ID="lblUni" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#006600">Joseph Sarwuan Tarka University Makurdi</asp:Label>
&nbsp;</div>
<div class="auto-style4">
    <div class="auto-style4">
        <br />
    </div>
    <hr />
    <div class="auto-style4">
        <br />
    </div>
</div>
<div class="auto-style4">
    <strong><em><span class="auto-style5">(Beware of Spelling Errors )</span><br class="auto-style5" /></em></strong>
</div>
<div>
    <table class="auto-style1">
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style7">
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" CssClass="auto-style16" Width="454px">
                    <table class="auto-style12">
                        <tr>
                            <td class="auto-style19"></td>
                            <td class="auto-style20"></td>
                            <td class="auto-style19">
                            </td>
                            <td class="auto-style19"></td>
                        </tr>
                        <tr>
                            <td class="auto-style8"></td>
                            <td class="auto-style14">College</td>
                            <td class="auto-style8">
                                <asp:DropDownList ID="ddlCollege" runat="server" Font-Size="Medium" Height="25px" Width="253px">
                                    <asp:ListItem>College of Physical Sciences</asp:ListItem>
                                    <asp:ListItem>College of Biological Sciences</asp:ListItem>
                                    <asp:ListItem>College of Agronomy</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style8"></td>
                        </tr>
                        <tr>
                            <td class="auto-style21"></td>
                            <td class="auto-style22">Department</td>
                            <td class="auto-style21">
                                <asp:DropDownList ID="ddlDepartment" runat="server" Font-Size="Medium" Height="25px" Width="248px">
                                    <asp:ListItem>Computer Science</asp:ListItem>
                                    <asp:ListItem>Mathematics</asp:ListItem>
                                    <asp:ListItem>Statistics</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style21"></td>
                        </tr>
                        <tr>
                            <td class="auto-style8"></td>
                            <td class="auto-style14">Course of Study</td>
                            <td class="auto-style8">
                                <asp:TextBox ID="txtCourseofStudy" runat="server" Font-Size="Medium" Height="21px" Width="209px"></asp:TextBox>
                            </td>
                            <td class="auto-style8"></td>
                        </tr>
                        <tr>
                            <td class="auto-style15"></td>
                            <td class="auto-style13"></td>
                            <td class="auto-style15"></td>
                            <td class="auto-style15"></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style7">
                <asp:Button ID="btnSubmit" runat="server" CssClass="auto-style17" Font-Size="Medium" Height="29px" Text="Submit" Width="130px" OnClick="btnSubmit_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</div>
</asp:Content>
