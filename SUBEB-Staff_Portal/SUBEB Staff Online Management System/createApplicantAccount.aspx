<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="createApplicantAccount.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.createApplicantAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent1" runat="server">
    <table class="nav-justified">
    <tr>
        <td style="width: 340px">&nbsp;</td>
        <td style="width: 491px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 340px; height: 43px"></td>
        <td class="text-center" style="height: 43px; color: #339933; font-size: large; width: 491px; background-color: #FFCCFF"><strong>Create Account</strong></td>
        <td style="height: 43px"></td>
    </tr>
    <tr>
        <td style="width: 340px">&nbsp;</td>
        <td style="width: 491px">
            <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" BorderWidth="2px">
                <table class="nav-justified" style="height: 116px">
                    <tr>
                        <td style="width: 48px">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 35px; width: 48px"></td>
                        <td style="height: 35px">User Name</td>
                        <td style="height: 35px">
                            <asp:TextBox ID="txtUsername" runat="server" Height="23px" Width="160px"></asp:TextBox>
                        </td>
                        <td style="height: 35px">
                            <em>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username required" style="color: #FF3300"></asp:RequiredFieldValidator>
                            </em>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 35px; width: 48px"></td>
                        <td style="height: 35px">Email</td>
                        <td style="height: 35px">
                            <asp:TextBox ID="txtEmail" runat="server" Height="23px" Width="160px"></asp:TextBox>
                        </td>
                        <td style="height: 35px">
                            <em>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email required" style="color: #FF3300"></asp:RequiredFieldValidator>
                            </em>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 35px; width: 48px"></td>
                        <td style="height: 35px">Password</td>
                        <td style="height: 35px">
                            <asp:TextBox ID="txtPassword" runat="server" Height="23px" TextMode="Password" Width="140px"></asp:TextBox>
                        </td>
                        <td style="height: 35px">
                            <em>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password required" style="color: #FF3300"></asp:RequiredFieldValidator>
                            </em>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 35px; width: 48px"></td>
                        <td style="height: 35px">Confirm Password</td>
                        <td style="height: 35px; margin-left: 160px">
                            <asp:TextBox ID="txtConfirmPassword" runat="server" Height="23px" TextMode="Password" Width="140px"></asp:TextBox>
                        </td>
                        <td style="height: 35px">
                            <em>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm required" style="color: #FF3300"></asp:RequiredFieldValidator>
                            </em>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 48px; height: 22px"></td>
                        <td style="height: 22px"></td>
                        <td style="height: 22px; margin-left: 160px">
                            <em>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtConfirmPassword" ControlToValidate="txtPassword" ErrorMessage="CompareValidator" style="color: #FF3300">Password didnt match</asp:CompareValidator>
                            </em>
                        </td>
                        <td style="height: 22px"></td>
                    </tr>
                    <tr>
                        <td style="width: 48px">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td style="margin-left: 160px">
                            <asp:Button ID="btnCreateAccount" runat="server" BackColor="White" BorderStyle="Solid" BorderWidth="2px" OnClick="btnCreateAccount_Click" Text="Button" Width="101px" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 48px">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td style="margin-left: 160px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 340px">&nbsp;</td>
        <td style="width: 491px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
