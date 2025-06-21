<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="Indictment.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Admin.Indictment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
        <tr>
            <td style="width: 135px">&nbsp;</td>
            <td style="width: 653px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 135px">&nbsp;</td>
            <td style="width: 653px">
                <asp:RadioButton ID="rbtLGEA" runat="server" Checked="True" GroupName="indict" Text="LGEA" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rbtHqtrs" runat="server" GroupName="indict" Text="Hqtrs" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 135px"></td>
            <td class="text-center" style="font-size: medium; height: 30px; width: 653px; background-color: #FFCCCC"><strong>Indictment Registration</strong></td>
            <td style="height: 30px"></td>
        </tr>
        <tr>
            <td style="width: 135px">&nbsp;</td>
            <td style="width: 653px">
                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 135px">&nbsp;</td>
            <td style="width: 653px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" BorderWidth="2px">
                            <table class="nav-justified">
                                <tr>
                                    <td style="width: 50px">&nbsp;</td>
                                    <td style="width: 144px">&nbsp;</td>
                                    <td class="text-right" style="width: 384px">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">&nbsp;</td>
                                    <td style="width: 144px">&nbsp;</td>
                                    <td class="text-right" style="width: 384px">
                                        <asp:Image ID="Image2" runat="server" Height="122px" Width="141px" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 39px">
                                        <hr style="margin-bottom: 0px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 39px; width: 50px"></td>
                                    <td style="width: 144px; height: 39px">Staff Number</td>
                                    <td style="height: 39px; width: 384px">
                                        <asp:TextBox ID="txtStaffNo" runat="server" Height="21px" Width="180px"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                    <td style="height: 39px"></td>
                                </tr>
                                <tr>
                                    <td style="height: 28px; width: 50px"></td>
                                    <td style="width: 144px; height: 28px">Name</td>
                                    <td style="height: 28px; width: 384px">
                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                    </td>
                                    <td style="height: 28px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">&nbsp;</td>
                                    <td style="width: 144px">&nbsp;</td>
                                    <td style="width: 384px">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">&nbsp;</td>
                                    <td style="width: 144px">&nbsp;</td>
                                    <td style="width: 384px">
                                        <asp:Button ID="btnView" runat="server" Height="24px" OnClick="btnView_Click" Text="View" Width="96px" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">&nbsp;</td>
                                    <td style="width: 144px">&nbsp;</td>
                                    <td style="width: 384px">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 135px">&nbsp;</td>
            <td style="width: 653px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 135px">&nbsp;</td>
            <td style="width: 653px">
                <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid" BorderWidth="2px">
                    <table class="nav-justified" style="height: 171px">
                        <tr>
                            <td style="width: 49px">&nbsp;</td>
                            <td style="width: 205px">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 42px; width: 49px"></td>
                            <td style="width: 205px; height: 42px">Date</td>
                            <td style="height: 42px">
                                <asp:TextBox ID="txtDate" runat="server" Height="23px" Width="194px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="txtDate_CalendarExtender" runat="server" BehaviorID="TextBox1_CalendarExtender" ClearTime="True" Format="yyyy-MM-dd" TargetControlID="txtDate" />
                            </td>
                            <td style="height: 42px"></td>
                        </tr>
                        <tr>
                            <td style="height: 38px; width: 49px"></td>
                            <td style="height: 38px; width: 205px">QueryTitle</td>
                            <td style="height: 38px">
                                <asp:TextBox ID="txtqueryTitle" runat="server" Height="24px" Width="392px"></asp:TextBox>
                            </td>
                            <td style="height: 38px"></td>
                        </tr>
                        <tr>
                            <td style="height: 42px; width: 49px"></td>
                            <td style="height: 42px; width: 205px">Upload Scanned Letter</td>
                            <td style="height: 42px">
                                <asp:FileUpload ID="fuLetter" runat="server" Height="26px" Width="370px" />
                            </td>
                            <td style="height: 42px"></td>
                        </tr>
                        <tr>
                            <td style="height: 32px; width: 49px"></td>
                            <td style="width: 205px; height: 32px"></td>
                            <td style="height: 32px"></td>
                            <td style="height: 32px"></td>
                        </tr>
                        <tr>
                            <td style="height: 33px; width: 49px"></td>
                            <td style="width: 205px; height: 33px"></td>
                            <td style="height: 33px">
                                <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" />
                            </td>
                            <td style="height: 33px"></td>
                        </tr>
                        <tr>
                            <td style="height: 33px; width: 49px"></td>
                            <td style="width: 205px; height: 33px"></td>
                            <td style="height: 33px"></td>
                            <td style="height: 33px"></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 135px">&nbsp;</td>
            <td style="width: 653px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
