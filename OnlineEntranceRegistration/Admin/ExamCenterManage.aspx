<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="ExamCenterManage.aspx.cs" Inherits="OnlineEntranceRegistration.Admin.ExamCenterManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h4 align="center" class="text-white">Add Exam Center</h4>
        <div class="container  ">
            <div class="jumbotron col-12">
                <div class="row">

                    <div id="" class="form-group col-md-6 ">
                        <label for="" class="">Exam Center Name  </label>
                        <asp:TextBox ID="txtexamcentername" class="form-control" placeholder="Exam Center Name" runat="server"></asp:TextBox>
                    </div>
                    <div id="" class="form-group col-md-6 ">
                        <label for="id_country" class="">Incharge  </label>
                        <asp:TextBox ID="txtincharge" class="form-control" placeholder="Incharge " runat="server"></asp:TextBox>
                    </div>

                </div>
                <div class="row">

                    <div id="" class="form-group col-md-6 ">
                        <label for="" class="">State  </label>
                        <asp:DropDownList runat="server" ID="ddlstate" Class="select form-control" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="" class="form-group col-md-6 ">
                        <label for="id_country" class="">City  </label>
                        <asp:DropDownList runat="server" ID="ddlcity" Class="select form-control">
                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </div>
                <div class="form-group">
                    <label for="" class="">Address  </label>
                    <asp:TextBox ID="txtaddress" class="form-control" placeholder="Address " runat="server"></asp:TextBox>
                </div>
                <div class="row">

                    <div class="form-group col-md-6">
                        <label for="" class="">Center Code  </label>
                        <asp:TextBox ID="txtCenterCode" class="form-control" placeholder="Center Code " runat="server"></asp:TextBox>
                    </div>
                     <div class="form-group col-md-6">
                        <label for="" class="">No. of Seat  </label>
                        <asp:TextBox ID="txtseat" class="form-control" placeholder="No. Of Seat " runat="server"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="btnsave" runat="server" Text="Submit" Class="btn-primary" OnClick="btnsave_Click" />
                <asp:Label ID="lblMessage" CssClass="text-success" runat="server"></asp:Label>
            </div>
            
        </div>
    </div>
</asp:Content>
