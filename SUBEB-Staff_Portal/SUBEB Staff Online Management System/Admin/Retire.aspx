<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="Retire.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Admin.Retire" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
        <tr>
            <td style="width: 69px">&nbsp;</td>
            <td class="auto-style1" style="font-size: medium; width: 924px">
                <asp:RadioButton ID="rbtLGEA" runat="server" Checked="True" GroupName="db" Text="LGEA" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="rbtHqtrs" runat="server" GroupName="db" Text="Hqtrs" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 30px; width: 69px"></td>
            <td class="text-center" style="font-size: medium; height: 30px; width: 924px; background-color: #FFCCCC"><strong>Staff </strong>R<span style="font-weight: bold">etirement</span></td>
            <td style="height: 30px"></td>
        </tr>
        <tr>
            <td style="width: 69px">&nbsp;</td>
            <td style="width: 924px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table class="nav-justified">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" BorderWidth="2px">
                                        <table class="nav-justified">
                                            <tr>
                                                <td style="width: 79px">&nbsp;</td>
                                                <td style="width: 143px">&nbsp;</td>
                                                <td style="width: 437px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 79px">&nbsp;</td>
                                                <td style="width: 143px">&nbsp;</td>
                                                <td style="width: 437px">&nbsp;</td>
                                                <td>
                                                    <asp:Image ID="Image2" runat="server" Height="124px" style="margin-left: 0px" Width="143px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 79px">&nbsp;</td>
                                                <td style="font-size: medium; width: 143px">Staff Number</td>
                                                <td style="width: 437px">
                                                    <asp:TextBox ID="txtSTaffNo" runat="server" Height="21px" Width="145px"></asp:TextBox>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnView" runat="server" Height="30px" OnClick="btnView_Click" style="font-size: small" Text="View" Width="93px" />
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 79px">&nbsp;</td>
                                                <td style="font-size: medium; width: 143px">Name:</td>
                                                <td style="width: 437px">
                                                    <asp:Label ID="lblName" runat="server" Font-Size="Medium"></asp:Label>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblMsg" runat="server" ForeColor="#FF3300"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" BorderWidth="2px">
                                        <table class="nav-justified">
                                            <tr>
                                                <td style="width: 81px">&nbsp;</td>
                                                <td style="width: 257px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="height: 44px; width: 81px"></td>
                                                <td style="width: 257px; height: 44px">Retirement Date</td>
                                                <td style="height: 44px">
                                                    <asp:TextBox ID="txtDate" runat="server" Height="22px" Width="184px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="txtDate_CalendarExtender" runat="server" BehaviorID="TextBox1_CalendarExtender" Format="yyyy-MM-dd" TargetControlID="txtDate" />
                                                </td>
                                                <td style="height: 44px"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 81px">&nbsp;</td>
                                                <td style="width: 257px">Retirement Reason</td>
                                                <td>
                                                    <asp:TextBox ID="txtReason" runat="server" Height="52px" TextMode="MultiLine" Width="429px"></asp:TextBox>
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 81px">&nbsp;</td>
                                                <td style="width: 257px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 81px">&nbsp;</td>
                                                <td style="width: 257px">&nbsp;</td>
                                                <td>
                                                    <asp:Button ID="btnRetire" runat="server" Height="31px"  OnClientClick="if (!confirm('Do you want to retire this staff?')) return false;" OnClick="btnRetire_Click" Text="Retire" Width="102px" style="font-size: small" />
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 81px">&nbsp;</td>
                                                <td style="width: 257px">&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 69px">&nbsp;</td>
            <td style="width: 924px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </asp:Content>
