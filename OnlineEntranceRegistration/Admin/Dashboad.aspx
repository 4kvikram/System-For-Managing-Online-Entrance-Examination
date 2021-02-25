<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="Dashboad.aspx.cs" Inherits="OnlineEntranceRegistration.Admin.Dashboad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Static/login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="container-fluid">
            <div class="row">

                <div class="col-md-12">
                    <div class="row main-card">
                        <div class="col-md-12 sub-head">
                            <h4 align="center">Analystic</h4>
                        </div>

                        <div class="col-md-4 mt-3">
                            <div class="card">
                                <div class="card-body">
                                    <h4 class="card-title">EXAM CENTERS</h4>
                                    <h6 class="card-subtitle mb-2 text-dark">Total Exam Centers =
                                        <asp:Label ID="lblTotalCenter" Text="3" class="text-dark" runat="server"></asp:Label></h6>
                                    <h6 class="card-subtitle mb-2 text-dark">Active Exam Centers =
                                        <asp:Label ID="lblActiveCenter" Text="3" class="text-dark" runat="server"></asp:Label></h6>
                                    <h6 class="card-subtitle mb-2 text-dark">Deactive Exam Centers =
                                        <asp:Label ID="lblDeactiveCenter" Text="3" class="text-dark" runat="server"></asp:Label></h6>
                                    <p class="card-text"></p>
                                    <a Class=" btn btn-primary" href="ExamCenterManage.aspx" >Add Exam Center</a>
                                    <a Class=" btn btn-success" href="ExamCenterList.aspx" >Manage Exam Center</a>
                                    
                                </div>
                            </div>

                        </div>
                         <div class="col-md-4 mt-3">
                            <div class="card">
                                <div class="card-body">
                                    <h4 class="card-title">Courses</h4>
                                    <h6 class="card-subtitle mb-2 text-dark">Total Course =
                                        <asp:Label ID="lbltotalcourse" Text="3" class="text-dark" runat="server"></asp:Label></h6>
                                    <h6 class="card-subtitle mb-2 text-dark">Active Course =
                                        <asp:Label ID="lblactiveCourse" Text="3" class="text-dark" runat="server"></asp:Label></h6>
                                    <h6 class="card-subtitle mb-2 text-dark">Deactive Course =
                                        <asp:Label ID="lblDactiveCourse" Text="3" class="text-dark" runat="server"></asp:Label></h6>
                                    <p class="card-text"></p>
                                    <a Class=" btn btn-primary" href="AddCourse.aspx" >Add Course</a>
                                    <a Class=" btn btn-success" href="ManageCourse.aspx" >Manage Course</a>
                                    
                                </div>
                            </div>

                        </div>
                        <div class="col-md-4 mt-3">
                            <div class="card">
                                <div class="card-body">
                                    <h4 class="card-title">Application Setting</h4>
                                    <br />
                                    <br />
                                    <br />
                                    
                                    <a Class=" btn btn-primary" href="EntranceSettingList.aspx" >Update Setting</a>
                                    <a Class=" btn btn-success" href="EntranceSetting.aspx" >Add Application Setting</a>
                                    
                                </div>
                            </div>

                        </div>

                         <div class="col-md-4 mt-3">
                            <div class="card">
                                <div class="card-body">
                                    <h4 class="card-title">Applicant</h4>
                                    <h6 class="card-subtitle mb-2 text-dark">Total Applicant =
                                        <asp:Label ID="lblapplicant" Text="3" class="text-dark" runat="server"></asp:Label></h6>
                                  <br />
                                    <br />
                                    <br />
                                </div>
                            </div>

                        </div>
                     


                    </div>
                </div>

            </div>
        </div>

    </div>
    <br />
</asp:Content>
