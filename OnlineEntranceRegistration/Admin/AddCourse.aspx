<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="OnlineEntranceRegistration.Admin.AddCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h4 align="center" class="text-white">Course Details</h4>
        <div class="container  ">
            <div class="jumbotron col-12">
                <div id="" class="form-group">
                    <label for="" class="">Course Name</label>
                    <asp:TextBox ID="txtcourseName" class="form-control" placeholder="Exam Course Name" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="" class="">Course Code  </label>
                    <asp:TextBox ID="txtCourseCode" class="form-control"  placeholder="Enter Course Code " runat="server"></asp:TextBox>
                </div>
                <div class="row">
                    <div class="form-group col-md-6">
                        <label for="" class="">Course Duration </label>
                        <asp:TextBox ID="txtCourseDuration" class="form-control" placeholder="Enter Course Duration " runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="" class="">No. of Seat Available </label>
                        <asp:TextBox ID="txtseat" class="form-control" placeholder="No. Of Seat " runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="" class="">Course Details  </label>
                    <asp:TextBox ID="txtcoursedetails" class="form-control" placeholder="Enter Course Details " runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="btnsave" runat="server" Text="Save" Class="btn-primary col-md-12" OnClick="btnsave_Click" />
                <asp:Label ID="lblMessage" CssClass="text-success" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
