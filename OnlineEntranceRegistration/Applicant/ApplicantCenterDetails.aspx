<%@ Page Title="" Language="C#" MasterPageFile="~/Applicant/MasterPageApplicant.Master" AutoEventWireup="true" CodeBehind="ApplicantCenterDetails.aspx.cs" Inherits="OnlineEntranceRegistration.Applicant.ApplicantCenterDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function checkValidateion() {
            console.log("asdf-");
            var ddlstate = document.getElementById('<%=ddlstate.ClientID%>').value;
            if (ddlstate == "" || ddlstate == '0') {
                alert("Please Select state ");
                return false;
            }
            var ddlcity = document.getElementById('<%=ddlcity.ClientID%>').value;
            if (ddlcity == "" || ddlcity == '0') {
                alert("Please Select City");
                return false;
            }
            var ddlCenter1 = document.getElementById('<%=ddlCenter1.ClientID%>').value;
            if (ddlCenter1 == "" || ddlCenter1 == '0') {
                alert("Please Select Center  ");
                return false;
            }

            

            var ddlstate2 = document.getElementById('<%=ddlstate2.ClientID%>').value;
            if (ddlstate2 == "" || ddlstate2 == '0') {
                alert("Please Select state ");
                return false;
            }
            var ddlcity2 = document.getElementById('<%=ddlcity2.ClientID%>').value;
            if (ddlcity2 == "" || ddlcity2 == '0') {
                alert("Please Select City");
                return false;
            }
            var ddlCenter2 =document.getElementById('<%=ddlcenter2.ClientID%>').value;
            if (ddlCenter2 == "" || ddlCenter2 == '0') {
                alert("Please Select Center  ");
                return false;
            }

            
            var ddlstate3 = document.getElementById('<%=ddlstate3.ClientID%>').value;
            if (ddlstate3 == "" || ddlstate3 == '0')
            {
                alert("Please Select state ");
                return false;
            }

            var ddlcity3 = document.getElementById('<%=ddlcity3.ClientID%>').value;
            if (ddlcity3 == "" || ddlcity3 == '0') {
                alert("Please Select City");
                return false;
            }
            var ddlCenter3 = document.getElementById('<%=ddlcenter3.ClientID%>').value;
            if (ddlCenter3 == "" || ddlCenter3 == '0') {
                alert("Please Select Center  ");
                return false;
            }


            var ddlmedium = document.getElementById('<%=ddlmedium.ClientID%>').value;
            if (ddlmedium == "" || ddlmedium == '0') {
                alert("Please Select medium  ");
                return false;
            }

            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin: 12px;">
        <div class="col-md-12 sub-head">
            <h4 align="center">Select Exam Center   </h4>
        </div>
        <div class="col-md-12 jumbotron">
            <div>
                <h4 align="center" class="col-md-12 text-primary">Select Exam Center 1</h4>
            </div>
            <div class="row ">
                <div id="" class="form-group col-md-4 ">
                    <label for="" class="">State  </label>
                    <asp:DropDownList runat="server" ID="ddlstate" Class="select form-control" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="" class="form-group col-md-4 ">
                    <label for="id_country" class="">City  </label>
                    <asp:DropDownList runat="server" ID="ddlcity" Class="select form-control" OnSelectedIndexChanged="ddlcity_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="" class="form-group col-md-4 ">
                    <label for="id_country" class="">Exam Center  </label>
                    <asp:DropDownList runat="server" ID="ddlCenter1" Class="select form-control">
                        <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div>
                <h4 align="center" class="col-md-12 text-primary">Select Exam Center 2 </h4>
            </div>
            <div class="row ">
                <div id="" class="form-group col-md-4 ">
                    <label for="" class="">State  </label>
                    <asp:DropDownList runat="server" ID="ddlstate2" Class="select form-control" OnSelectedIndexChanged="ddlstate2_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="" class="form-group col-md-4 ">
                    <label for="id_country" class="">City  </label>
                    <asp:DropDownList runat="server" ID="ddlcity2" Class="select form-control" OnSelectedIndexChanged="ddlcity2_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="" class="form-group col-md-4 ">
                    <label for="id_country" class="">Exam Center  </label>
                    <asp:DropDownList runat="server" ID="ddlcenter2" Class="select form-control">
                        <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div>
                <h4 align="center" class="col-md-12 text-primary">Select Exam Center 3</h4>
            </div>
            <div class="row ">
                <div id="" class="form-group col-md-4 ">
                    <label for="" class="">State  </label>
                    <asp:DropDownList runat="server" ID="ddlstate3" Class="select form-control" OnSelectedIndexChanged="ddlstate3_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="" class="form-group col-md-4 ">
                    <label for="id_country" class="">City  </label>
                    <asp:DropDownList runat="server" ID="ddlcity3" Class="select form-control" OnSelectedIndexChanged="ddlcity3_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="" class="form-group col-md-4 ">
                    <label for="id_country" class="">Exam Center  </label>
                    <asp:DropDownList runat="server" ID="ddlcenter3" Class="select form-control">
                        <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group col-md-12">
                <label for="ddlmedium" class="">Question Paper Medium </label>
                <asp:DropDownList runat="server" ID="ddlmedium" Class="select form-control">
                    <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                    <asp:ListItem Text="English" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Hindi" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <div>
                <asp:Button runat="server" ID="btnsubmit" OnClientClick="return checkValidateion()"  OnClick="btnsubmit_Click" CssClass="btn btn-primary col-md-12" Text="Proceed Next" />
                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
