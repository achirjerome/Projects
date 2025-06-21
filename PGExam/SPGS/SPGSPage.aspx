<%@ Page Title="" Language="C#" MasterPageFile="~/SPGS/SPGS.Master" AutoEventWireup="true" CodeBehind="SPGSPage.aspx.cs" Inherits="DesignTemplate1.SPGS.SPGSPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        * {
          box-sizing: border-box;
        }

        /* Create two equal columns that floats next to each other */
        .column {
          float: left;
          width: 19%;
          padding: 10px;
          text-align:center;
        }
        .column_small {
          float: left;
          width: 1%;   
          background-color:white;
        }

        img{
          
          opacity: 0.5;
        }

        /* Clear floats after the columns */
        .row:after {
          content: "";
          display: table;
          clear: both;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Menu</h3>
    <hr />    
    <div class="row">
        &nbsp;
    </div>
    <div class="row">
  
        <div class="column img" style="background-color:cyan; ">
            <p>&nbsp;</p>
            <p><i class="fas fa-user-edit"><a href="StudentReg.aspx">Add Department</a></i> </p>
            <p>&nbsp;</p>
        </div>

        <div class="column_small">
            <p>&nbsp;</p>
        </div>

        <div class="column" style="background-color:coral ;">
            <p>&nbsp;</p>
            <p><i class="fas fa-user-edit"><a href="addCourses.aspx">Add College </a></i></p>
            <p>&nbsp;</p>
        </div>

        <div class="column_small">
            <p>&nbsp;</p>
        </div>

        <div class="column" style="background-color: violet;">
            <p>&nbsp;</p>
            <p><i class="fas fa-eye"><a href="addCourseofStudy.aspx">View Departments</a></i></p>
            <p>&nbsp;</p>
        </div>

        <div class="column_small">
            <p>&nbsp;</p>
        </div>

        <div class="column" style="background-color:#bbb;">
            <p>&nbsp;</p>
            <p><i class="fas fa-eye"><a href="addDepartment">View Colleges</a></i></p>
            <p>&nbsp;</p>
   
        </div>
    </div>
    <div class="row">
        &nbsp;
    </div>
       <%--New row--%>
    <div class="row">
  
        <div class="column img" style="background-color:cyan; ">
            <p>&nbsp;</p>
            <p><i class="fas fa-eye"><a href="StudentReg.aspx">View Results</a></i> </p>
            <p>&nbsp;</p>
        </div>

        <div class="column_small">
            <p>&nbsp;</p>
        </div>

        <div class="column" style="background-color:coral ;">
            <p>&nbsp;</p>
            <p><i class="fas fa-eye"><a href="addCourses.aspx">View Students </a></i></p>
            <p>&nbsp;</p>
        </div>
    </div>
    <div class="row">
        &nbsp;
    </div>
    <hr />
 
</asp:Content>
