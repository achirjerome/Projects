<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="staffBioAdmin.aspx.cs" Inherits="SUBEB_Staff_Online_Management_System.Admin.staffBioAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


        .auto-style1 {
            width: 100%;
        }
        .auto-style6 {
            height: 27px;
            width: 140px;
        }
        .auto-style4 {
            height: 27px;
            width: 617px;
        }
        .auto-style2 {
            height: 27px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>

                <%--<td class="auto-style5">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>--%>
                
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Image ID="Image1" runat="server" Height="123px" Width="127px" />
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style4">
                        <asp:Panel ID="Panel1" runat="server" Width="559px">
                            <asp:FormView ID="FormView1" runat="server" AllowPaging="true" BorderStyle="Solid" CellPadding="4" CellSpacing="4" GridLines="Horizontal" HeaderText="Bio Data" BorderWidth="2px">
                                <ItemTemplate>
                                    <table class="table-padding">
                                        <tr>
                                            <td>Staff No</td>
                                            <td><%#Eval("StaffNo") %></td>
                                        </tr>
                                        <tr>
                                            <td>Fisrt Name</td>
                                            <td><%#Eval("FirstName") %></td>
                                        </tr>
                                        <tr>
                                            <td>Middlename</td>
                                            <td><%#Eval("Middlename") %></td>
                                        </tr>
                                        <tr>
                                            <td>Surname</td>
                                            <td><%#Eval("Surname") %></td>
                                        </tr>
                                        <tr>
                                            <td>Sex</td>
                                            <td><%#Eval("Sex") %></td>
                                        </tr>
                                        <tr>
                                            <td>Marital Status</td>
                                            <td><%#Eval("MarritalStatus") %></td>
                                        </tr>
                                        <tr>
                                            <td>Number of Children</td>
                                            <td><%#Eval("NoofChildren") %></td>
                                        </tr>
                                        <tr>
                                            <td>Date of Birth</td>
                                            <td><%#Eval("DateofBirth") %></td>
                                        </tr>
                                        <tr>
                                            <td>Home Town</td>
                                            <td><%#Eval("HomeTown") %></td>
                                        </tr>
                                        <tr>
                                            <td>Nationality</td>
                                            <td><%#Eval("Nationality")%></td>
                                        </tr>
                                        <tr>
                                            <td>STate of Origin</td>
                                            <td><%#Eval("StateofOrigin") %></td>
                                        </tr>
                                        <tr>
                                            <td>LGA</td>
                                            <td><%#Eval("LGA") %></td>
                                        </tr>
                                        <tr>
                                            <td>Religion</td>
                                            <td><%#Eval("Religion") %></td>
                                        </tr>
                                        <tr>
                                            <td>Contact Address</td>
                                            <td><%#Eval("ContactAddress")%></td>
                                        </tr>
                                        <tr>
                                            <td>Permanent Address</td>
                                            <td><%#Eval("PermanentAddress") %></td>
                                        </tr>
                                        <tr>
                                            <td>Phone Number</td>
                                            <td><%#Eval("PhoneNo") %></td>
                                        </tr>
                                        <tr>
                                            <td>Email</td>
                                            <td><%#Eval("Email") %></td>
                                        </tr>
                                        <tr>
                                            <td>Qualification</td>
                                            <td><%#Eval("Qualification")%></td>
                                        </tr>
                                        <tr>
                                            <td>Area of Study</td>
                                            <td><%#Eval("Speciaty") %></td>
                                        </tr>
                                        <tr>
                                            <td>Date of Appointment</td>
                                            <td><%#Eval("DateofAppointment") %></td>
                                        </tr>
                                        <tr>
                                            <td>Job Type</td>
                                            <td><%#Eval("JobTitle")%></td>
                                        </tr>
                                        <tr>
                                            <td>GradeLevel</td>
                                            <td><%#Eval("GradeLevelStep") %></td>
                                        </tr>
                                        <tr>
                                            <td>Blood Group</td>
                                            <td><%#Eval("BloodGroup") %></td>
                                        </tr>
                                        <tr style="column-span:all">
                                            <td>&nbsp; </td>
                                        </tr>
                                        <tr style="column-span:all">
                                            <td><strong>NEXT OF KIN</strong> </td>
                                        </tr>
                                        tr&gt;
                                        <td>First Name</td>
                                        <td><%#Eval("kinFirstName") %></td>
                                        </tr>
                                        tr&gt;
                                        <td>Middle Name</td>
                                        <td><%#Eval("KinMidname") %></td>
                                        </tr>
                                        tr&gt;
                                        <td>SurName</td>
                                        <td><%#Eval("kinSurname") %></td>
                                        </tr>
                                        tr&gt;
                                        <td>Hoetown</td>
                                        <td><%#Eval("kinHomeTown") %></td>
                                        </tr>
                                        tr&gt;
                                        <td>LGA</td>
                                        <td><%#Eval("kinLGA") %></td>
                                        </tr>
                                        tr&gt;
                                        <td>State of Origin</td>
                                        <td><%#Eval("Stateoforigin") %></td>
                                        </tr>
                                        tr&gt;
                                        <td>Nationality</td>
                                        <td><%#Eval("kinNationality") %></td>
                                        </tr>
                                        tr&gt;
                                        <td>Contact Address</td>
                                        <td><%#Eval("kinResidence") %></td>
                                        </tr>
                                        tr&gt;
                                        <td>Phone Number</td>
                                        <td><%#Eval("kinPhoneNo") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <RowStyle BorderColor="#CCCCCC" />
                            </asp:FormView>
                        </asp:Panel>
                    </td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
   
   
</body>
</html>
