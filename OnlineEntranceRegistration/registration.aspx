<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="OnlineEntranceRegistration.registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="container  ">
            <div class="jumbotron col-12">
                <div class="row">

                    <div id="" class="form-group col-md-6 ">
                        <label for="id_country" class="">First Name  </label>
                        <asp:TextBox ID="serverName" class="form-control" placeholder="First Name" runat="server"></asp:TextBox>
                    </div>
                    <div id="" class="form-group col-md-6 ">
                        <label for="id_country" class="">Last Name  </label>
                        <asp:TextBox ID="TextBox1" class="form-control" placeholder="Last Name" runat="server"></asp:TextBox>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
