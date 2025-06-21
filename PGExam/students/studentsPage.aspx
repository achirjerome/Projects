<%@ Page Title="" Language="C#" MasterPageFile="~/students/studentsMaster.Master" AutoEventWireup="true" CodeBehind="studentsPage.aspx.cs" Inherits="DesignTemplate1.students.studentsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        * {
          box-sizing: border-box;
        }

        /* Create two equal columns that floats next to each other */
        .column {
          float: left;
          width: 25%;
          padding: 10px;
          text-align:center;
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
        .auto-style1 {
            color: #006600;
        }
    </style>
        <h1 class="auto-style1"> Menu</h1>
    <p>&nbsp;</p>
    <hr />
    <div class="row">
        
       
        <div class="column" style="background-color:cyan;">
            <p>
                &nbsp 
            </p>
            <p>
                <i class="fas fa-keyboard"><a href="semester_reg">Reg Courses </a></i>
            </p>
            <p>
                &nbsp 
            </p>
        </div>
        <div class="column" style="background-color:coral;">
            <p>
                &nbsp 
            </p>
            <p>
                <i class="fas fa-eye"><a href="#">View Biod data </a></i>
            </p>
            <p>
                &nbsp 
            </p>
        </div>
        <div class="column" style="background-color:violet;">
            <p>
                &nbsp 
            </p>
            <p>
                <i class="fas fa-eye"><a href="#">View Courses </a></i>
            </p>
            <p>
                &nbsp 
            </p>
        </div>

        <div class="column" style="background-color:#bbb;">
            <p>
                &nbsp 
            </p>
            <p>
                <i class="fas fa-eye"><a href="#">View Result </a></i>
            </p>
            <p>
                &nbsp 
            </p>
        </div>
    </div>
    <hr />
</asp:Content>
