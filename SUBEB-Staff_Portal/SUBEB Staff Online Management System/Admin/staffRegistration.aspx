<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="staffRegistration.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Admin.staffRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style4" style="width: 1032px">
        <tr>
            <td class="auto-style56" style="color: #339933; background-color: #FFCCFF; "><strong>STAFF REGISTRATION FORM</strong></td>
            <td style="height: 49px"></td>
        </tr>
        <tr>
            <td class="auto-style57">
                <table class="nav-justified">
                    <tr>
                        <td>
                            <asp:RadioButton ID="rbtLGEA" runat="server" Checked="True" GroupName="staffdb" Text="LGEA" />
                        </td>
                        <td>
                            <asp:RadioButton ID="rbtHqtrs" runat="server" GroupName="staffdb" Text="Hqtrs" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style57">
                <asp:Label ID="Label1" runat="server" style="color: #FF0000"></asp:Label>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style57">
                <asp:Panel ID="Panel1" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="2px" Width="744px">
                    <table class="auto-style58">
                        <tr>
                            <td class="auto-style38"></td>
                            <td class="auto-style63" style="text-align: left;">Staff Number</td>
                            <td class="auto-style59" style="text-align: left;">
                                <asp:TextBox ID="txtStaffNo" runat="server" CssClass="style27" OnTextChanged="txtPSHN_TextChanged" style="font-size: medium"></asp:TextBox>
                                <span style="color: #CC3300">*</span></td>
                            <td class="style23" style="height: 34px; width: 252px; text-align: left;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtStaffNo" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style38"></td>
                            <td class="auto-style63" style="color: #333333; text-align: left;">First Name</td>
                            <td class="auto-style59" style="text-align: left;">
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="style27" style="font-size: medium"></asp:TextBox>
                                <span style="color: #CC3300">*</span></td>
                            <td class="style23" style="height: 34px; width: 252px; text-align: left;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Required" style="color: #FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style38">&nbsp;</td>
                            <td class="auto-style63" style="color: #333333; text-align: left;">Middle Name</td>
                            <td class="auto-style59" style="text-align: left;">
                                <asp:TextBox ID="txtMiddleName" runat="server" CssClass="style27" style="font-size: medium"></asp:TextBox>
                            </td>
                            <td class="style5" style="width: 252px; height: 34px; text-align: left;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style38"></td>
                            <td class="auto-style63" style="color: #333333; text-align: left;">Surname</td>
                            <td class="auto-style59" style="text-align: left;">
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="style27" style="font-size: medium"></asp:TextBox>
                                <span style="color: #CC3300">*</span></td>
                            <td class="style5" style="width: 252px; height: 34px; text-align: left;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLastName" ErrorMessage="Required" style="color: #FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style38"></td>
                            <td class="auto-style63" style="color: #333333; text-align: left;">Sex</td>
                            <td class="auto-style59" style="text-align: left;">
                                <asp:RadioButton ID="rbtMale" runat="server" Checked="True" GroupName="Sex" style="font-size: medium; color: #333333;" Text="Male" />
                                <asp:RadioButton ID="rbtFemale" runat="server" CssClass="style27" GroupName="Sex" style="font-size: medium; color: #333333;" Text="Female" />
                                <span style="color: #CC3300">*</span></td>
                            <td class="style5" style="width: 252px; height: 34px; text-align: left;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style38">&nbsp;</td>
                            <td class="auto-style63" style="color: #333333; text-align: left;">Marital Status</td>
                            <td class="auto-style59" style="text-align: left;">
                                <asp:DropDownList ID="ddlMaritalStatus" runat="server" Height="26px" style="font-size: medium" Width="127px">
                                    <asp:ListItem>Single</asp:ListItem>
                                    <asp:ListItem>Married</asp:ListItem>
                                    <asp:ListItem>Divorced </asp:ListItem>
                                    <asp:ListItem>Widow</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="style5" style="width: 252px; height: 34px; text-align: left;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style38">&nbsp;</td>
                            <td class="auto-style63" style="color: #333333; text-align: left;">No of Children</td>
                            <td class="auto-style59" style="text-align: left;">
                                <asp:TextBox ID="txtNoofChildren" runat="server" style="font-size: medium" Width="136px"></asp:TextBox>
                            </td>
                            <td class="style5" style="width: 252px; height: 34px; text-align: left;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style38"></td>
                            <td class="auto-style63" style="color: #333333; text-align: left;">Date of birth</td>
                            <td class="auto-style59" style="text-align: left;">
                                <asp:TextBox ID="txtDateofBirth" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="txtDateofBirth_CalendarExtender" runat="server" BehaviorID="txtDateofBirth_CalendarExtender" TargetControlID="txtDateofBirth" />
                            </td>
                            <td class="style5" style="width: 252px; height: 34px; text-align: left;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtDateofBirth" ErrorMessage="Required" style="color: #FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style38"></td>
                            <td class="auto-style63" style="color: #333333; text-align: left;">HomeTown</td>
                            <td class="auto-style59" style="text-align: left;">
                                <asp:TextBox ID="txtHomeTown" runat="server" CssClass="style27" style="font-size: medium"></asp:TextBox>
                                <span style="color: #CC3300">*</span></td>
                            <td class="style5" style="width: 252px; height: 34px; text-align: left;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtHomeTown" ErrorMessage="Required" style="color: #CC3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style38">&nbsp;</td>
                            <td class="auto-style63" style="color: #333333; text-align: left;">
                                Nationality</td>
                            <td class="auto-style59" style="text-align: left;">
                                <asp:DropDownList ID="ddlNationality" runat="server" AutoPostBack="True" CssClass="style27" Height="25px" onselectedindexchanged="ddlNationality_SelectedIndexChanged" style="font-size: medium">
                                    <asp:ListItem>Nigeria</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="style5" style="width: 252px; height: 34px; text-align: left;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style39"></td>
                            <td class="style22" colspan="2" style="height: 37px; color: #333333; text-align: left;">
                                <asp:UpdatePanel ID="udpNationality" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table class="nav-justified">
                                            <tr>
                                                <td style="height: 47px; width: 192px">&nbsp;</td>
                                                <td style="height: 47px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="height: 44px; width: 192px">State of Origin</td>
                                                <td style="height: 44px">
                                                    <asp:DropDownList ID="ddlSOO" runat="server" AutoPostBack="True" CssClass="style27" Height="26px" onselectedindexchanged="ddlSOO_SelectedIndexChanged" style="font-size: medium">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 35px; width: 192px">LGA</td>
                                                <td style="height: 35px">
                                                    <asp:DropDownList ID="ddlLGA" runat="server" CssClass="style27" Height="26px" style="font-size: medium">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 35px; width: 192px">&nbsp;</td>
                                                <td style="height: 35px">&nbsp;</td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="style5" style="width: 252px; height: 37px; text-align: left;"></td>
                        </tr>
                        <tr>
                            <td class="auto-style20"></td>
                            <td class="auto-style44" style="color: #333333; text-align: left;">Religion</td>
                            <td style="text-align: left;" class="auto-style6">
                                <asp:DropDownList ID="ddlReligion" runat="server" Height="20px" style="font-size: medium" Width="161px">
                                    <asp:ListItem>Christianity</asp:ListItem>
                                    <asp:ListItem>Islam</asp:ListItem>
                                    <asp:ListItem>Atheist</asp:ListItem>
                                    <asp:ListItem>Judaism</asp:ListItem>
                                    <asp:ListItem>Hundaism</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList>
                                <span style="color: #FF3300">*</span></td>
                            <td class="style5" style="width: 252px; height: 56px; text-align: left;"></td>
                        </tr>
                        <tr>
                            <td class="auto-style21"></td>
                            <td class="auto-style45" style="color: #333333; text-align: left;">Contact Address</td>
                            <td style="text-align: left;" class="auto-style7">
                                <asp:TextBox ID="txtContactAddress" runat="server" CssClass="style27" style="font-size: medium" TextMode="MultiLine" Width="296px" Height="39px"></asp:TextBox>
                                <span style="color: #CC3300">*</span></td>
                            <td class="style5" style="width: 252px; height: 54px; text-align: left;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtContactAddress" ErrorMessage="Required" style="color: #FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style22"></td>
                            <td class="auto-style46" style="color: #333333; text-align: left;">Permanent Address</td>
                            <td class="auto-style8" style="text-align: left;">
                                <asp:TextBox ID="txtPermanentAddress" runat="server" TextMode="MultiLine" Height="39px" Width="297px"></asp:TextBox>
                                <span style="color: #FF3300">*</span></td>
                            <td class="style5" style="width: 252px; height: 57px; text-align: left;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtPermanentAddress" ErrorMessage="Required" style="color: #FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style23"></td>
                            <td class="auto-style47" style="color: #333333; text-align: left;">Phone Number</td>
                            <td class="auto-style9" style="text-align: left;">
                                <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="style27" MaxLength="11" style="font-size: medium"></asp:TextBox>
                            </td>
                            <td class="style5" style="width: 252px; height: 48px; text-align: left;"></td>
                        </tr>
                        <tr>
                            <td class="auto-style40"></td>
                            <td class="auto-style64" style="color: #333333; text-align: left;">Email Address</td>
                            <td class="auto-style60" style="text-align: left;">
                                <asp:TextBox ID="txtemail" runat="server" CssClass="style27" Height="29px" style="font-size: medium" TextMode="Email" Width="237px"></asp:TextBox>
                            </td>
                            <td class="style5" style="width: 252px; height: 44px; text-align: left;"></td>
                        </tr>
                        <tr>
                            <td class="auto-style25"></td>
                            <td class="auto-style49" style="text-align: left; color: #333333;">Highest Qualification</td>
                            <td style="text-align: left; " class="auto-style11">
                                <asp:DropDownList ID="ddlQualification" runat="server" Height="26px" style="font-size: medium">
                                    <asp:ListItem>FSLC</asp:ListItem>
                                    <asp:ListItem>ND</asp:ListItem>
                                    <asp:ListItem>NCE</asp:ListItem>
                                    <asp:ListItem>PGD</asp:ListItem>
                                    <asp:ListItem>PGDE</asp:ListItem>
                                    <asp:ListItem>B Sc</asp:ListItem>
                                    <asp:ListItem>B Sc(ED)</asp:ListItem>
                                    <asp:ListItem>B Tech</asp:ListItem>
                                    <asp:ListItem>M Sc</asp:ListItem>
                                    <asp:ListItem>PhD</asp:ListItem>
                                    <asp:ListItem>M Ed</asp:ListItem>
                                    <asp:ListItem>SSCE</asp:ListItem>
                                    <asp:ListItem>BA</asp:ListItem>
                                    <asp:ListItem>MA</asp:ListItem>
                                    <asp:ListItem>B Agric</asp:ListItem>
                                    <asp:ListItem>B Eng</asp:ListItem>
                                    <asp:ListItem>M Eng</asp:ListItem>
                                    <asp:ListItem>M Tech</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="style5" style="width: 252px; height: 43px; text-align: left;"></td>
                        </tr>
                        <tr>
                            <td class="auto-style40"></td>
                            <td class="auto-style64" style="text-align: left; color: #333333;">Field of Study</td>
                            <td style="text-align: left; " class="auto-style60">
                                <asp:TextBox ID="txtSpeciaty" runat="server" Height="27px" style="font-size: medium" Width="274px"></asp:TextBox>
                                <span style="color: #FF3300">*</span></td>
                            <td class="style5" style="width: 252px; height: 44px; text-align: left;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtSpeciaty" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style41"></td>
                            <td class="auto-style65" style="text-align: left; color: #333333;">Date of First Appointment</td>
                            <td style="text-align: left; " class="auto-style61">
                                <asp:TextBox ID="txtDateofAppointment" runat="server" Height="23px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="txtDateofAppointment_CalendarExtender" runat="server" BehaviorID="txtDateofAppointment_CalendarExtender" TargetControlID="txtDateofAppointment" />
                                <span style="color: #FF3300">*</span></td>
                            <td class="style5" style="width: 252px; height: 47px; text-align: left;"></td>
                        </tr>
                        <tr>
                            <td class="auto-style27"></td>
                            <td class="auto-style51" style="text-align: left; color: #333333;">Date of Last Promotion</td>
                            <td style="text-align: left; " class="auto-style13">
                                <asp:TextBox ID="txtDateofLastPromotion" runat="server" Height="27px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="txtDateofLastPromotion_CalendarExtender" runat="server" BehaviorID="txtDateofLastPromotion_CalendarExtender" TargetControlID="txtDateofLastPromotion" />
                                <span style="color: #FF3300">*</span></td>
                            <td class="style5" style="width: 252px; height: 46px; text-align: left;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style41"></td>
                            <td class="auto-style65" style="text-align: left; color: #333333;">Job Type</td>
                            <td style="text-align: left; " class="auto-style61">
                                <asp:DropDownList ID="ddlJobTitle" runat="server" style="font-size: medium">
                                    <asp:ListItem>Teaching</asp:ListItem>
                                    <asp:ListItem>Non-Teaching</asp:ListItem>
                                </asp:DropDownList>
                                <span style="color: #FF3300">*</span></td>
                            <td class="style5" style="width: 252px; height: 47px; text-align: left;"></td>
                        </tr>
                        <tr>
                            <td class="auto-style38">&nbsp;</td>
                            <td class="auto-style63" style="text-align: left; color: #333333;">Grade Level/Step</td>
                            <td style="text-align: left; " class="auto-style59">
                                <asp:DropDownList ID="ddlCurrentGradeLevel" runat="server" Height="25px" style="font-size: medium">
                                    <asp:ListItem>Grade Level</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                </asp:DropDownList>
                                <span style="font-size: x-large">/<asp:DropDownList ID="ddlCurrentStep" runat="server" Height="25px" style="font-size: medium">
                                    <asp:ListItem>Step</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList>
                                <span style="color: #FF3300">*</span></span></td>
                            <td class="style5" style="width: 252px; height: 34px; text-align: left;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style40"></td>
                            <td class="auto-style64" style="text-align: left; color: #333333;">Rank</td>
                            <td style="text-align: left; " class="auto-style60">
                                <asp:TextBox ID="txtRank" runat="server" style="font-size: medium" Width="190px"></asp:TextBox>
                                <span style="color: #FF3300">*</span></td>
                            <td class="style5" style="width: 252px; height: 44px; text-align: left;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtRank" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style39">&nbsp;</td>
                            <td class="auto-style52" style="text-align: left; color: #333333;">Blood Group</td>
                            <td style="text-align: left; " class="auto-style14">
                                <asp:DropDownList ID="ddlBloodGroup" runat="server">
                                    <asp:ListItem>A</asp:ListItem>
                                    <asp:ListItem>AB</asp:ListItem>
                                    <asp:ListItem>B</asp:ListItem>
                                    <asp:ListItem>O+</asp:ListItem>
                                    <asp:ListItem>O-</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="style5" style="width: 252px; height: 37px; text-align: left;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style28"></td>
                            <td class="style22" style="height: 51px; text-align: left; color: #333333;" colspan="2">
                                <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" BorderWidth="2px" GroupingText="Work Section">
                                    <asp:UpdatePanel ID="udpWork" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <table class="nav-justified">
                                                <tr>
                                                    <td style="height: 41px">Work LGEA</td>
                                                    <td style="height: 41px"></td>
                                                    <td style="height: 41px">
                                                        <asp:DropDownList ID="ddlWorkLGEA" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlWorkLGEA_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Workstation</td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlWorkStation" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                            </td>
                            <td class="style5" style="width: 252px; height: 51px; text-align: left;"></td>
                        </tr>
                        <tr>
                            <td class="auto-style42">&nbsp;</td>
                            <td class="auto-style66" style="text-align: left; color: #333333;">Upload Passport</td>
                            <td style="text-align: left; " class="auto-style62">
                                <asp:FileUpload ID="fuPassport" runat="server" CssClass="style27" style="font-size: medium" />
                                <span style="color: #CC3300">*</span></td>
                            <td class="style5" style="width: 252px; height: 28px; text-align: left;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fuPassport" ErrorMessage="Required" style="color: #CC3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style42"></td>
                            <td class="auto-style66" style="text-align: left; color: #333333;"></td>
                            <td style="text-align: left; " class="auto-style62"></td>
                            <td class="style5" style="width: 252px; height: 28px; text-align: left;"></td>
                        </tr>
                        <tr>
                            <td class="auto-style38">&nbsp;</td>
                            <td class="auto-style63" style="text-align: left; color: #333333;">&nbsp;</td>
                            <td style="text-align: left; " class="auto-style59">&nbsp;</td>
                            <td class="style5" style="width: 252px; height: 34px; text-align: left;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style30"></td>
                            <td class="auto-style54" style="text-align: left;"></td>
                            <td style="text-align: left; " class="auto-style16">
                                <asp:Button ID="btnContinue" runat="server" Height="29px" onclick="btnContinue_Click" style="font-size: medium" Text="Continue" Width="101px" />
                            </td>
                            <td class="style5" style="width: 252px; height: 39px; text-align: left;"></td>
                        </tr>
                        <tr>
                            <td class="auto-style31"></td>
                            <td class="auto-style55" style="text-align: left;"></td>
                            <td style="text-align: left; " class="auto-style17"></td>
                            <td class="style5" style="width: 252px; height: 22px; text-align: left;"></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style57">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style57">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
    .auto-style3 {
        height: 49px;
        width: 365px;
    }
    .auto-style4 {
        width: 365px;
    }
    .auto-style6 {
        height: 56px;
        width: 510px;
    }
    .auto-style7 {
        height: 54px;
        width: 510px;
    }
    .auto-style8 {
        height: 57px;
        width: 510px;
    }
    .auto-style9 {
        height: 48px;
        width: 510px;
    }
    .auto-style11 {
        height: 43px;
        width: 510px;
    }
    .auto-style13 {
        height: 46px;
        width: 510px;
    }
    .auto-style14 {
        height: 37px;
        width: 510px;
    }
    .auto-style16 {
        height: 39px;
        width: 510px;
    }
    .auto-style17 {
        height: 22px;
        width: 510px;
    }
    .auto-style20 {
        height: 56px;
        width: 38px;
    }
    .auto-style21 {
        height: 54px;
        width: 38px;
    }
    .auto-style22 {
        height: 57px;
        width: 38px;
    }
    .auto-style23 {
        height: 48px;
        width: 38px;
    }
    .auto-style25 {
        height: 43px;
        width: 38px;
    }
    .auto-style27 {
        height: 46px;
        width: 38px;
    }
    .auto-style28 {
        height: 51px;
        width: 38px;
    }
    .auto-style30 {
        height: 39px;
        width: 38px;
    }
    .auto-style31 {
        height: 22px;
        width: 38px;
    }
        .auto-style38 {
            height: 34px;
            width: 38px;
        }
        .auto-style39 {
            height: 37px;
            width: 38px;
        }
        .auto-style40 {
            height: 44px;
            width: 38px;
        }
        .auto-style41 {
            height: 47px;
            width: 38px;
        }
        .auto-style42 {
            height: 28px;
            width: 38px;
        }
        .auto-style44 {
            height: 56px;
            width: 429px;
        }
        .auto-style45 {
            height: 54px;
            width: 429px;
        }
        .auto-style46 {
            height: 57px;
            width: 429px;
        }
        .auto-style47 {
            height: 48px;
            width: 429px;
        }
        .auto-style49 {
            height: 43px;
            width: 429px;
        }
        .auto-style51 {
            height: 46px;
            width: 429px;
        }
        .auto-style52 {
            height: 37px;
            width: 429px;
        }
        .auto-style54 {
            height: 39px;
            width: 429px;
        }
        .auto-style55 {
            height: 22px;
            width: 429px;
        }
        .auto-style56 {
            height: 49px;
            width: 851px;
        }
        .auto-style57 {
            width: 851px;
        }
        .auto-style58 {
            height: 690px;
            width: 693px;
        }
        .auto-style59 {
            height: 34px;
            width: 510px;
        }
        .auto-style60 {
            height: 44px;
            width: 510px;
        }
        .auto-style61 {
            height: 47px;
            width: 510px;
        }
        .auto-style62 {
            height: 28px;
            width: 510px;
        }
        .auto-style63 {
            height: 34px;
            width: 429px;
        }
        .auto-style64 {
            height: 44px;
            width: 429px;
        }
        .auto-style65 {
            height: 47px;
            width: 429px;
        }
        .auto-style66 {
            height: 28px;
            width: 429px;
        }
    </style>
</asp:Content>

