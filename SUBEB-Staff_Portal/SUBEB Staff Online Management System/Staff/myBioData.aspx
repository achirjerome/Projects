<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.master" AutoEventWireup="true" CodeBehind="myBioData.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Staff.myBioData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
    <tr>
        <td style="width: 112px" class="style2">
            &nbsp;</td>
        <td style="width: 640px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 112px; height: 45px;">
            </td>
        <td style="font-size: large; font-weight: 700; color: #006600; width: 640px; background-color: #FFCCFF; height: 45px;">
            My Personal Data</td>
        <td style="height: 45px">
            </td>
    </tr>
    <tr>
        <td style="width: 112px" class="style2">
            &nbsp;</td>
        <td style="width: 640px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 112px" class="style2">
            &nbsp;</td>
        <td style="width: 640px">
            <asp:Image ID="Image2" runat="server" Height="114px" Width="131px" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 112px" class="style2">
            &nbsp;</td>
        <td style="width: 640px">
            <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" BorderWidth="2px" BorderColor="#333333">
                <table style="width: 100%; font-size: medium;" border="1">
                    <tr>
                        <td style="color: #006600; text-align: justify; background-color: #FFCCFF;" class="text-center" colspan="4"><span class="style7"></span><span style="color: #006600"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Personal Data</strong></span></span></span></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 37px;"></td>
                        <td style="width: 173px; height: 37px;">Staff No:</td>
                        <td style="width: 218px; height: 37px;">
                            <asp:Label ID="lblPSN" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 37px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 37px;"></td>
                        <td style="width: 173px; height: 37px;">Name:</td>
                        <td style="width: 218px; height: 37px;">
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 37px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 32px;"></td>
                        <td style="width: 173px; height: 32px;">Sex:</td>
                        <td style="width: 218px; height: 32px;">
                            <asp:Label ID="lblSex" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 32px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 38px;"></td>
                        <td style="width: 173px; height: 38px;">Marital Status:</td>
                        <td style="width: 218px; height: 38px;">
                            <asp:Label ID="lblMaritalStatus" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 38px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 37px;"></td>
                        <td style="width: 173px; height: 37px;">Number of Children:</td>
                        <td style="width: 218px; height: 37px;">
                            <asp:Label ID="lblNoofChildren" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 37px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 36px;"></td>
                        <td style="width: 173px; height: 36px;">Date of Birth:</td>
                        <td style="width: 218px; height: 36px;">
                            <asp:Label ID="lblDateofBirth" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 36px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 36px;"></td>
                        <td style="width: 173px; height: 36px;">Home Town:</td>
                        <td style="width: 218px; height: 36px;">
                            <asp:Label ID="lblHomeTown" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 36px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 33px;"></td>
                        <td style="width: 173px; height: 33px;">LGA of Origin:</td>
                        <td style="width: 218px; height: 33px;">
                            <asp:Label ID="lblLGA" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 33px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 34px;"></td>
                        <td style="width: 173px; height: 34px;">State of origin:</td>
                        <td style="width: 218px; height: 34px;">
                            <asp:Label ID="lblStateofOrigin" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 34px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 37px;"></td>
                        <td style="width: 173px; height: 37px;">Nationality:</td>
                        <td style="width: 218px; height: 37px;">
                            <asp:Label ID="lblNationality" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 37px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 36px;"></td>
                        <td style="width: 173px; height: 36px;">Religion:</td>
                        <td style="width: 218px; height: 36px;">
                            <asp:Label ID="lblReligion" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 36px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 25px;"></td>
                        <td style="width: 173px; height: 25px;">Residential Address:</td>
                        <td style="width: 218px; height: 25px;">
                            <asp:Label ID="lblContactAddress" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 25px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 25px;"></td>
                        <td style="width: 173px; height: 25px;">Permanent Address:</td>
                        <td style="width: 218px; height: 25px;">
                            <asp:Label ID="lblPermanentAddress" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 25px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 25px;"></td>
                        <td style="width: 173px; height: 25px;">Phone Number:</td>
                        <td style="width: 218px; height: 25px;">
                            <asp:Label ID="lblPhoneNo" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 25px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 25px;"></td>
                        <td style="width: 173px; height: 25px;">Email:</td>
                        <td style="width: 218px; height: 25px;">
                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 25px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 25px;"></td>
                        <td style="width: 173px; height: 25px;">Qualification:</td>
                        <td style="width: 218px; height: 25px;">
                            <asp:Label ID="lblQualification" runat="server"></asp:Label>
                            <asp:Label ID="lblFieldofStudy" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 25px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px">&nbsp;</td>
                        <td style="width: 173px">Date of First Appointment:</td>
                        <td style="width: 218px">
                            <asp:Label ID="lblDateofAppointment" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 25px;"></td>
                        <td style="width: 173px; height: 25px;">Job Type:</td>
                        <td style="width: 218px; height: 25px;">
                            <asp:Label ID="lblJobType" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 25px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 25px;"></td>
                        <td style="width: 173px; height: 25px;">Current Work Station:</td>
                        <td style="width: 218px; height: 25px;">
                            <asp:Label ID="lblWorkStation" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 25px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 25px;"></td>
                        <td style="width: 173px; height: 25px;">Date of Last Promotion:</td>
                        <td style="width: 218px; height: 25px;">
                            <asp:Label ID="lblDateofLastPromotion" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 25px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 25px;"></td>
                        <td style="width: 173px; height: 25px;">Current Grade Level:</td>
                        <td style="width: 218px; height: 25px;">
                            <asp:Label ID="lblGradeLevel" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 25px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 25px;"></td>
                        <td style="width: 173px; height: 25px;">Current Rank:</td>
                        <td style="width: 218px; height: 25px;">
                            <asp:Label ID="lblRank" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 25px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px">&nbsp;</td>
                        <td style="width: 173px">&nbsp;</td>
                        <td style="width: 218px">&nbsp;</td>
                        <td style="width: 20px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="color: #006600; background-color: #FFCCFF;" colspan="4"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Next of Kin</span></strong></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 25px;"></td>
                        <td style="width: 173px; height: 25px;">Name:</td>
                        <td style="width: 218px; height: 25px;">
                            <asp:Label ID="lblKinName" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 25px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 25px;"></td>
                        <td style="width: 173px; height: 25px;">Relationship:</td>
                        <td style="width: 218px; height: 25px;">
                            <asp:Label ID="lblRelationship" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 25px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 25px;"></td>
                        <td style="width: 173px; height: 25px;">Contact Address:</td>
                        <td style="width: 218px; height: 25px;">
                            <asp:Label ID="lblKinContactAddress" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 25px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px; height: 25px;"></td>
                        <td style="width: 173px; height: 25px;">Phone Number:</td>
                        <td style="width: 218px; height: 25px;">
                            <asp:Label ID="lblKinPhoneNo" runat="server"></asp:Label>
                        </td>
                        <td style="width: 20px; height: 25px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 70px">&nbsp;</td>
                        <td style="width: 173px">&nbsp;</td>
                        <td style="width: 218px">&nbsp;</td>
                        <td style="width: 20px">&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 112px" class="style2">
            &nbsp;</td>
        <td style="width: 640px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
