<%@ Page Title="" Language="C#" MasterPageFile="~/ES/ES.master" AutoEventWireup="true" CodeBehind="StaffTransferES.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.ES.StaffTransferES" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style16">
        <tr>
            <td style="width: 173px">&nbsp;</td>
            <td style="width: 725px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 173px">&nbsp;</td>
            <td style="width: 725px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 173px">&nbsp;</td>
            <td style="width: 725px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 173px">&nbsp;</td>
            <td style="width: 725px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" BorderWidth="2px" GroupingText="Staff Transfer">
                            <table class="style16" style="font-size: medium">
                                <tr>
                                    <td style="width: 31px">&nbsp;</td>
                                    <td style="width: 187px">
                                        <asp:Image ID="Image2" runat="server" Height="135px" Width="128px" />
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 31px">&nbsp;</td>
                                    <td style="width: 187px">&nbsp;</td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" style="color: #FF3300"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 31px; height: 25px;"></td>
                                    <td class="text-center" colspan="2" style="height: 25px; font-size: large; color: #006600; background-color: #FFCCFF;">Current Work Station</td>
                                    <td style="height: 25px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 31px">&nbsp;</td>
                                    <td style="width: 187px">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 31px">&nbsp;</td>
                                    <td style="width: 187px">Staff Number</td>
                                    <td>
                                        <asp:DropDownList ID="ddlStaffNo" runat="server" AutoPostBack="True" Height="25px" onselectedindexchanged="ddlStaffNo_SelectedIndexChanged" style="font-size: medium" Width="132px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="height: 35px; width: 31px">&nbsp;</td>
                                    <td style="height: 35px; width: 187px">Name</td>
                                    <td style="height: 35px">
                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                    </td>
                                    <td style="height: 35px">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="height: 35px; width: 31px"></td>
                                    <td style="height: 35px; width: 187px">Previous Transfered Date</td>
                                    <td style="height: 35px">
                                        <asp:TextBox ID="txtPreviousDate" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="height: 35px"></td>
                                </tr>
                                <tr>
                                    <td style="height: 35px; width: 31px">&nbsp;</td>
                                    <td style="height: 35px; width: 187px">LGEA</td>
                                    <td style="height: 35px">
                                        <asp:Label ID="lblCurrentLGEA" runat="server"></asp:Label>
                                    </td>
                                    <td style="height: 35px">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="height: 35px; width: 31px"></td>
                                    <td style="height: 35px; width: 187px">Current Workstation</td>
                                    <td style="height: 35px">
                                        <asp:Label ID="lblPPA" runat="server"></asp:Label>
                                    </td>
                                    <td style="height: 35px"></td>
                                </tr>
                                <tr>
                                    <td style="height: 35px; width: 31px">&nbsp;</td>
                                    <td colspan="2" style="height: 35px; ">
                                        <hr />
                                    </td>
                                    <td style="height: 35px">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="height: 35px; width: 31px">&nbsp;</td>
                                    <td class="text-center" colspan="2" style="height: 35px; color: #006600; font-size: large; background-color: #FFCCFF;">Transfer To New Work Station</td>
                                    <td style="height: 35px">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="height: 35px; width: 31px">&nbsp;</td>
                                    <td style="height: 35px; width: 187px">&nbsp;</td>
                                    <td style="height: 35px">&nbsp;</td>
                                    <td style="height: 35px">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="height: 35px; width: 31px">&nbsp;</td>
                                    <td style="height: 35px; width: 187px">LGEA</td>
                                    <td style="height: 35px">
                                        <asp:DropDownList ID="ddlWorkLGEA" runat="server" AutoPostBack="True" Height="25px" OnSelectedIndexChanged="ddlWorkLGEA_SelectedIndexChanged" style="font-size: medium" Width="414px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="height: 35px">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="height: 35px; width: 31px"></td>
                                    <td style="height: 35px; width: 187px">Transfer To</td>
                                    <td style="height: 35px">
                                        <asp:DropDownList ID="ddlPosting" runat="server" Height="25px" style="font-size: medium" Width="414px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="height: 35px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 31px">&nbsp;</td>
                                    <td style="width: 187px">New transfer Date</td>
                                    <td>
                                        <asp:TextBox ID="txtNewDate" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="txtNewDate_CalendarExtender" runat="server" BehaviorID="TextBox2_CalendarExtender" TargetControlID="txtNewDate" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 31px">&nbsp;</td>
                                    <td style="width: 187px">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 31px">&nbsp;</td>
                                    <td style="width: 187px">&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnTransfer" runat="server" Height="29px" onclick="btnTransfer_Click" style="font-size: medium" Text="Transfer" Width="106px" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 31px">&nbsp;</td>
                                    <td style="width: 187px">&nbsp;</td>
                                    <td>&nbsp;</td>
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
            <td style="width: 173px">&nbsp;</td>
            <td style="width: 725px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
