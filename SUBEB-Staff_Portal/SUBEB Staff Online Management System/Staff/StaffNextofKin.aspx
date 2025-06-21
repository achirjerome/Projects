<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.master" AutoEventWireup="true" CodeBehind="StaffNextofKin.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Staff.StaffNextofKin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;</p>
<table style="width: 100%">
    <tr>
        <td style="width: 3px; height: 35px;"></td>
        <td style="width: 530px; color: #006600; background-color: #FFCCFF; text-align: center; height: 35px;"><strong>NEXT OF KIN BIODATA FORM</strong></td>
        <td class="style8" style="height: 35px"></td>
    </tr>
    <tr>
        <td style="width: 3px">&nbsp;</td>
        <td style="width: 530px">
            <asp:Label ID="Label1" runat="server" 
                    style="font-size: medium; color: #FF0000; text-align: center"></asp:Label>
        </td>
        <td style="text-align: left; color: #FF3300">&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 3px">&nbsp;</td>
        <td style="width: 530px">
            <asp:Panel ID="Panel2" runat="server" BorderColor="#999999" BorderStyle="Solid" 
                BorderWidth="2px" style="text-align: left" Width="520px">
                <table class="style4" style="color: #333333; width: 509px">
                    <tr>
                        <td class="style26" style="width: 29px">&nbsp;</td>
                        <td class="style46" style="width: 146px; font-size: medium;">&nbsp;</td>
                        <td class="style44" style="width: 255px">&nbsp;</td>
                        <td style="width: 16px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style26" style="width: 29px">&nbsp;</td>
                        <td class="style46" style="width: 146px; font-size: medium;">Staff Number</td>
                        <td class="style44" style="width: 255px">
                            <asp:TextBox ID="txtKStaffNo" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 16px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style27" style="width: 29px; height: 19px;"></td>
                        <td class="style46" style="width: 146px; height: 19px; font-size: medium;"></td>
                        <td class="style45" style="width: 255px; height: 19px;"></td>
                        <td style="width: 16px; height: 19px;"></td>
                    </tr>
                    <tr>
                        <td class="style27" style="width: 29px; height: 34px;">&nbsp;</td>
                        <td class="style46" style="width: 146px; height: 34px; font-size: medium;">&nbsp;</td>
                        <td class="style45" style="width: 255px; height: 34px;"><strong>NEXT OF KIN INFORMATION</strong></td>
                        <td style="width: 16px; height: 34px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style27" style="width: 29px; height: 34px;"></td>
                        <td class="style46" style="width: 146px; height: 34px; font-size: medium;">First Name</td>
                        <td class="style45" style="width: 255px; height: 34px;">
                            <asp:TextBox ID="txtKFirstName" runat="server" CssClass="style31" Height="26px" style="font-size: medium"></asp:TextBox>
                            <span class="style38" style="color: #FF3300">*</span></td>
                        <td style="width: 16px; height: 34px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style27" style="width: 29px; height: 34px;">&nbsp;</td>
                        <td class="style46" style="width: 146px; height: 34px; font-size: medium;">Middle Name</td>
                        <td class="style45" style="width: 255px; height: 34px;">
                            <asp:TextBox ID="txtMiddleName" runat="server" Height="26px" 
                                style="font-size: medium"></asp:TextBox>
                        </td>
                        <td style="width: 16px; height: 34px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style27" style="width: 29px; height: 34px;"></td>
                        <td class="style46" style="width: 146px; height: 34px; font-size: medium;">Surname</td>
                        <td class="style45" style="width: 255px; height: 34px;">
                            <asp:TextBox ID="txtKLastName" runat="server" CssClass="style31" Height="26px" 
                                style="font-size: medium"></asp:TextBox>
                            <span class="style38" style="color: #FF3300">*</span></td>
                        <td style="width: 16px; height: 34px;"></td>
                    </tr>
                    <tr>
                        <td class="style27" style="width: 29px; height: 34px;">&nbsp;</td>
                        <td class="style46" style="width: 146px; height: 34px; font-size: medium;">Home Town</td>
                        <td class="style45" style="width: 255px; height: 34px;">
                            <asp:TextBox ID="txtHomeTown" runat="server"></asp:TextBox>
                            <span style="color: #FF3300">*</span></td>
                        <td style="width: 16px; height: 34px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style27" style="width: 29px; height: 34px;">&nbsp;</td>
                        <td class="style46" colspan="2" style="height: 34px; font-size: medium;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table class="nav-justified">
                                        <tr>
                                            <td style="height: 35px; width: 163px">Nationality</td>
                                            <td style="height: 35px">
                                                <asp:DropDownList ID="ddlNationality" runat="server" AutoPostBack="True" CssClass="style27" Height="25px" onselectedindexchanged="ddlNationality_SelectedIndexChanged" style="font-size: medium">
                                                    <asp:ListItem>Nigeria</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 35px; width: 163px">State of Origin</td>
                                            <td style="height: 35px">
                                                <asp:DropDownList ID="ddlSOO" runat="server" AutoPostBack="True" CssClass="style27" Height="26px" onselectedindexchanged="ddlSOO_SelectedIndexChanged" style="font-size: medium">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 35px; width: 163px">LGA</td>
                                            <td style="height: 35px">
                                                <asp:DropDownList ID="ddlLGA" runat="server" CssClass="style27" Height="26px" style="font-size: medium">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="width: 16px; height: 34px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style27" style="width: 29px; height: 34px;"></td>
                        <td class="style46" style="width: 146px; height: 34px; font-size: medium;">Relationship</td>
                        <td class="style45" style="width: 255px; height: 34px;">
                            <asp:DropDownList ID="ddlRelationShip" runat="server" CssClass="style31" Height="26px" style="font-size: medium">
                                <asp:ListItem>Aunt</asp:ListItem>
                                <asp:ListItem>Brother</asp:ListItem>
                                <asp:ListItem>Daughter</asp:ListItem>
                                <asp:ListItem>Guardian</asp:ListItem>
                                <asp:ListItem>Father</asp:ListItem>
                                <asp:ListItem>Husband</asp:ListItem>
                                <asp:ListItem Value="Mother">Mother</asp:ListItem>
                                <asp:ListItem>Sister</asp:ListItem>
                                <asp:ListItem>Son</asp:ListItem>
                                <asp:ListItem>Uncle</asp:ListItem>
                                <asp:ListItem>Wife</asp:ListItem>
                            </asp:DropDownList>
                            <span class="style38" style="color: #FF3300">*</span></td>
                        <td style="width: 16px; height: 34px;"></td>
                    </tr>
                    <tr>
                        <td class="style26" style="width: 29px">&nbsp;</td>
                        <td class="style46" style="width: 146px; font-size: medium;">Contact Address</td>
                        <td class="style44" style="width: 255px">
                            <asp:TextBox ID="txtKContactAddress" runat="server" CssClass="style31" 
                                    TextMode="MultiLine" Width="236px" style="font-size: medium"></asp:TextBox>
                            <span style="color: #FF3300">*</span></td>
                        <td style="width: 16px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style27" style="width: 29px; height: 34px;"></td>
                        <td class="style46" style="width: 146px; height: 34px; font-size: medium;">Phone Number</td>
                        <td class="style45" style="width: 255px; height: 34px;">
                            <asp:TextBox ID="txtKPhoneNo" runat="server" CssClass="style31" 
                                style="font-size: medium" TextMode="Number" Height="26px" MaxLength="11"></asp:TextBox>
                        </td>
                        <td style="width: 16px; height: 34px;"></td>
                    </tr>
                    <tr>
                        <td class="style26" style="width: 29px">&nbsp;</td>
                        <td class="style46" style="width: 146px; font-size: medium;">&nbsp;</td>
                        <td class="style44" style="width: 255px">&nbsp;</td>
                        <td style="width: 16px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style26" style="width: 29px">&nbsp;</td>
                        <td class="style46" style="width: 146px; font-size: medium;">&nbsp;</td>
                        <td class="style44" style="width: 255px">
                            <asp:Button ID="btnSave" runat="server" Height="26px" onclick="btnSave_Click" 
                                    style="font-size: large" Text="Save" Width="73px" />
                        </td>
                        <td style="width: 16px">&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
        <td style="text-align: left; color: #FF3300">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtKStaffNo" ErrorMessage="Staff Number required"></asp:RequiredFieldValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtKFirstName" CssClass="style38" 
                    ErrorMessage="First name required"></asp:RequiredFieldValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtKLastName" CssClass="style38" 
                    ErrorMessage="Last name required"></asp:RequiredFieldValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Hometown required" ControlToValidate="txtHomeTown"></asp:RequiredFieldValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtKContactAddress" CssClass="style38" 
                    ErrorMessage="Address required"></asp:RequiredFieldValidator>
            <br />
            <br /></td>
    </tr>
    <tr>
        <td style="width: 3px">&nbsp;</td>
        <td style="width: 530px; text-align: left">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
