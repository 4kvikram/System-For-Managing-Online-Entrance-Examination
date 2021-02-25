<%@ Page Title="" Language="C#" MasterPageFile="~/Applicant/MasterPageApplicant.Master" AutoEventWireup="true" CodeBehind="ApplicantPersnolDetails.aspx.cs" Inherits="OnlineEntranceRegistration.Applicant.ApplicantPersnolDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function checkValidateion() {
            var fname = document.getElementById('<%=txtfname.ClientID%>').value;
            if (fname == "") {
                alert("First Name Cannot Be Empty");
                return false;
            }
            var lname = document.getElementById('<%=txtlname.ClientID%>').value;
            if (lname == "") {
                alert("Last Name Cannot Be Empty");
                return false;
            }
            var fatname = document.getElementById('<%=txtfatherName.ClientID%>').value;
            if (fatname == "") {
                alert("Father's Name Cannot Be Empty");
                return false;
            }

            var txtmothersname = document.getElementById('<%=txtmothersname.ClientID%>').value;
            if (txtmothersname == "") {
                alert("Mother's Name Cannot Be Empty");
                return false;
            }

            var txtdob = document.getElementById('<%=txtdob.ClientID%>').value;
            if (txtdob == "") {
                alert("Date of Birth Name Cannot Be Empty");
                return false;
            }
            var rdoGender = document.getElementById('<%=rdoGender.ClientID%>').value;
            if (rdoGender == "") {
                alert("Please select gender");
                return false;
            }
            var txtAddress = document.getElementById('<%=txtAddress.ClientID%>').value;
            if (txtAddress == "") {
                alert("Address Can Not be empty");
                return false;
            }

            var ddlstate = document.getElementById('<%=ddlstate.ClientID%>').value;
            if (ddlstate == "" ||ddlstate=='0') {
                alert("Please Select State");
                return false;
            }
            var ddlcity = document.getElementById('<%=ddlcity.ClientID%>').value;
            if (ddlcity == "" || ddlcity=='0') {
                alert("Please Select City");
                return false;
            }
            var ddlcourse = document.getElementById('<%=ddlcourse.ClientID%>').value;
            console.log(ddlcourse);
            if (ddlcourse == "" || ddlcourse=='0') {
                alert("Please Select Course");
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin: 12px;">
        <div class="col-md-12 sub-head">
            <h4 align="center">Applicant Personal Details   </h4>
        </div>
        <div class="col-md-12 jumbotron">
            <div class="row">
                <div id="" class="form-group col-md-6">
                    <label for="txtfname" class=" requiredField">
                        First Name<span class="asteriskField">*</span>
                    </label>
                    <div class="">
                        <asp:TextBox ID="txtfname" class="textinput textInput form-control" placeholder=" Enter First Name" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div id="" class="form-group col-md-6">
                    <label for="txtlname" class=" requiredField">
                        Last Name<span class="asteriskField">*</span>
                    </label>
                    <div class="">
                        <asp:TextBox ID="txtlname" class="textinput textInput form-control" placeholder=" Enter Last Name" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div id="" class="form-group">
                <label for="txtfatherName" class=" requiredField">
                    Father's Name<span class="asteriskField">*</span>
                </label>
                <div class="">
                    <asp:TextBox ID="txtfatherName" class="textinput textInput form-control" placeholder=" Enter Father's Name" runat="server"></asp:TextBox>
                </div>
            </div>
            <div id="" class="form-group">
                <label for="txtmothersname" class=" requiredField">
                    Mother's Name<span class="asteriskField">*</span>
                </label>
                <div class="">
                    <asp:TextBox ID="txtmothersname" class="textinput textInput form-control" placeholder=" Enter Mother's Name" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div id="" class="form-group col-md-6">
                    <label for="txtdob" class=" requiredField">
                        Date Of Birth<span class="asteriskField">*</span>
                    </label>
                    <div class="">
                        <asp:TextBox ID="txtdob" class="textinput textInput form-control" TextMode="date" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div id="" class="form-group col-md-6">
                    <label for="" class=" requiredField">
                        Gender<span class="asteriskField">*</span>
                    </label>
                    <div class="">
                        <asp:RadioButtonList Class=" form-control" ID="rdoGender" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Male</asp:ListItem>
                            <asp:ListItem Value="2">Female</asp:ListItem>
                            <asp:ListItem Value="3">Other</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>
            <div id="" class="form-group">
                <label for="" class=" requiredField">
                    Address<span class="asteriskField">*</span>
                </label>
                <div class="">
                    <asp:TextBox ID="txtAddress" class="textinput textInput form-control" placeholder=" Enter Address" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row ">
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
            <div class="row">
                <div id="" class="form-group col-md-6">
                    <label for="txtdob" class=" requiredField">
                        Are You Physically Challanged<span class="asteriskField">*</span>
                    </label>
                    <asp:RadioButtonList Class=" form-control" ID="rdbphys" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Selected Value="2">No</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div id="" class="form-group col-md-6">
                    <label for="txtlname" class=" requiredField">
                        Category<span class="asteriskField">*</span>
                    </label>
                    <div class="">
                        <asp:DropDownList ID="ddlcatagory" runat="server" Class="select form-control">
                            <asp:ListItem Selected Text="Genaral" Value="1"></asp:ListItem>
                            <asp:ListItem Text="OBC" Value="2"></asp:ListItem>
                            <asp:ListItem Text="SC/ST" Value="3"></asp:ListItem>
                        </asp:DropDownList>

                    </div>
                </div>
            </div>
            <div id="" class="form-grou ">
                <label for="" class="">
                    Course Course Applyed For
                </label>
                <asp:DropDownList runat="server" ID="ddlcourse" Class="select form-control">
                    <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <div>
                <asp:Button runat="server" ID="btnsubmit" OnClientClick="return checkValidateion()" OnClick="btnsubmit_Click" CssClass="btn btn-primary col-md-12" Text="Proceed Next" />
                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
