<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="addCourses.aspx.cs" Inherits="DesignTemplate1.Admin.addCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            font-size: small;
            color: #FF3300;
        }
        .auto-style6 {
            width: 650px;
        }
        .auto-style7 {
            width: 502px;
        }
        .auto-style9 {
            width: 82px;
        }
        .auto-style10 {
            height: 12px;
            width: 82px;
        }
        .auto-style11 {
            width: 202px;
        }
        .auto-style12 {
            height: 12px;
            width: 483px;
        }
        .auto-style13 {
            height: 12px;
            width: 202px;
        }
        .auto-style15 {
            width: 202px;
            height: 32px;
        }
        .auto-style16 {
            width: 82px;
            height: 32px;
        }
        .auto-style17 {
            height: 29px;
        }
        .auto-style20 {
            width: 82px;
            height: 36px;
        }
        .auto-style28 {
            width: 202px;
            height: 34px;
        }
        .auto-style29 {
            width: 82px;
            height: 34px;
        }
        .auto-style30 {
            width: 202px;
            height: 35px;
        }
        .auto-style31 {
            width: 82px;
            height: 35px;
        }
        .auto-style32 {
            width: 21px;
            height: 34px;
        }
        .auto-style33 {
            width: 21px;
            height: 35px;
        }
        .auto-style34 {
            width: 21px;
            height: 32px;
        }
        .auto-style35 {
            width: 21px;
            height: 36px;
        }
        .auto-style36 {
            width: 21px;
        }
        .auto-style37 {
            height: 12px;
            width: 21px;
        }
        .auto-style38 {
            width: 217px;
            height: 34px;
        }
        .auto-style39 {
            width: 217px;
            height: 35px;
        }
        .auto-style40 {
            width: 217px;
            height: 32px;
        }
        .auto-style41 {
            width: 217px;
            height: 36px;
        }
        .auto-style42 {
            width: 217px;
        }
        .auto-style43 {
            height: 12px;
            width: 217px;
        }
        .auto-style44 {
            width: 202px;
            height: 36px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style4">
        <strong>
        <br />Add New Course<br />&nbsp;</strong></div>
    <div class="auto-style4">
        <asp:Label ID="lblUni" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#006600">Joseph Sarwuan Tarka University Makurdi</asp:Label>
&nbsp;</div>
    <div class="auto-style4">
        <br />
        <hr />
        <br />
    </div>
    <div class="auto-style4">
        <strong><em><span class="auto-style5">(Beware of Spelling Errors )</span><br class="auto-style5" /></em></strong>
        <br />
    </div>
    <div>
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style7">
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid">
                        <table class="auto-style12">
                            <tr>
                                <td class="auto-style32"></td>
                                <td class="auto-style28">College</td>
                                <td class="auto-style38">
                                    <asp:DropDownList ID="ddlCollege" runat="server" Font-Size="Medium">
                                        <asp:ListItem>College of Physical Sciences</asp:ListItem>
                                        <asp:ListItem>College of Biological Sciences</asp:ListItem>
                                        <asp:ListItem>College of Agronomy</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style29"></td>
                            </tr>
                            <tr>
                                <td class="auto-style33"></td>
                                <td class="auto-style30">Department</td>
                                <td class="auto-style39">
                                    <asp:DropDownList ID="ddlDepartment" runat="server" Font-Size="Medium">
                                        <asp:ListItem>Computer Science</asp:ListItem>
                                        <asp:ListItem>Mathematics</asp:ListItem>
                                        <asp:ListItem>Statistics</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style31"></td>
                            </tr>
                            <tr>
                                <td class="auto-style34"></td>
                                <td class="auto-style15">Programme</td>
                                <td class="auto-style40">
                                    <asp:DropDownList ID="ddlProgram" runat="server" Font-Size="Medium">
                                        <asp:ListItem>PGD</asp:ListItem>
                                        <asp:ListItem>MSc</asp:ListItem>
                                        <asp:ListItem>PhD</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style16"></td>
                            </tr>
                            <tr>
                                <td class="auto-style35">&nbsp;</td>
                                <td class="auto-style44">Course of Study</td>
                                <td class="auto-style41">
                                    <asp:DropDownList ID="ddlCourseOfStudy" runat="server" Font-Size="Medium">
                                        <asp:ListItem>Computer Science</asp:ListItem>
                                        <asp:ListItem>Zoology</asp:ListItem>
                                        <asp:ListItem>Biochemistry</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style20">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style35"></td>
                                <td class="auto-style44">Course Code</td>
                                <td class="auto-style41">
                                    <asp:TextBox ID="txtCollegeName0" runat="server" CssClass="auto-style6" Font-Size="Medium" Height="21px" Width="150px"></asp:TextBox>
                                </td>
                                <td class="auto-style20"></td>
                            </tr>
                            <tr>
                                <td class="auto-style36">&nbsp;</td>
                                <td class="auto-style11">Course Title</td>
                                <td class="auto-style42">
                                    <asp:TextBox ID="txtCollegeName" runat="server" CssClass="auto-style6" Font-Size="Medium" Height="36px" TextMode="MultiLine" Width="289px"></asp:TextBox>
                                </td>
                                <td class="auto-style9">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style37"></td>
                                <td class="auto-style13"></td>
                                <td class="auto-style43"></td>
                                <td class="auto-style10"></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style7">
                    <asp:Button ID="btnSubmit" runat="server" CssClass="auto-style17" Font-Size="Medium" Height="29px" Text="Submit" Width="130px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
