<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="EntranceSetting.aspx.cs" Inherits="OnlineEntranceRegistration.Admin.EntranceSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <h4 align="center" class="text-white">Entrance Setting</h4>
        <div class="container  ">
            <div class="jumbotron col-12">
                <div class="row">
                    <div id="" class="form-group col-md-6 ">
                        <label for="" class="">Application Start Date  </label>
                        <asp:TextBox ID="txtstartdate" class="form-control" placeholder="Exam Center Name" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                    <div id="" class="form-group col-md-6 ">
                        <label for="id_country" class="">Application Last Date   </label>
                        <asp:TextBox ID="txtLastdate" class="form-control" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div id="" class="form-group col-md-6 ">
                        <label for="" class="">Admit Card Release Date (Tentative) </label>
                        <asp:TextBox ID="txtadmit" class="form-control" placeholder="Exam Center Name" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                    <div id="" class="form-group col-md-6 ">
                        <label for="id_country" class="">Exam Date (Tentative) </label>
                        <asp:TextBox ID="txtExamDate" class="form-control" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>
                 <div id="" class="form-group ">
                        <label for="id_country" class="">Result Date (Tentative)  </label>
                        <asp:TextBox ID="txtResDate" class="form-control" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                <div class="form-group">
                    <label for="" class="">Notification For Student (If any) </label>
                    <asp:TextBox ID="txtnotification" class="form-control" TextMode="MultiLine"   runat="server"></asp:TextBox>
                </div>
                    <div class="form-group">
                        <label for="" class="">Important Notice (If any)  </label>
                        <asp:TextBox ID="txtnotice" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </div>
                    
               
                <asp:Button ID="btnsave" runat="server" Text="Submit" Class="btn-primary" OnClick="btnsave_Click" />
                <asp:Label ID="lblMessage" CssClass="text-success" runat="server"></asp:Label>
            </div>
            
        </div>
    </div>
</asp:Content>
