<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="OnlineEntranceRegistration.ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .loading-holder {
            display: flex;
            align-items: center;
            justify-content: center;
            width: 100%;
            height: 100%;
            position: fixed;
            background: rgba(255, 255, 255, 0.9);
            z-index: 10000;
            top: 0;
            left: 0;
        }

        .loading {
            position: relative;
        }

        .loading-bar {
            display: inline-block;
            width: 5px;
            height: 35px;
            border-radius: 3px;
            animation: loading 1s ease-in-out infinite;
        }

            .loading-bar + .loading-bar {
                margin-left: 5px;
            }

            .loading-bar:nth-child(1) {
                background-color: #1277eb;
                animation-delay: 0;
            }

            .loading-bar:nth-child(2) {
                background-color: #1277eb;
                animation-delay: 0.09s;
            }

            .loading-bar:nth-child(3) {
                background-color: #1277eb;
                animation-delay: .18s;
            }

            .loading-bar:nth-child(4) {
                background-color: #1277eb;
                animation-delay: .27s;
            }

        @keyframes loading {
            0% {
                transform: scale(1);
            }

            20% {
                transform: scale(1, 2.2);
            }

            40% {
                transform: scale(1);
            }
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="Static/jquery-3.1.0.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            console.log("about ready!");
        });

        function emailSubmit() {
            $("#loder").append(' <div class="loading-holder" id="id"><div id="con" class="loading"> <div class="loading-bar"></div> <div class="loading-bar"></div> <div class="loading-bar"></div> <div class="loading-bar"></div>   </div><p><h4 class="text-primary">Verifying Your Data.....</h4> </p></div>');

            $.ajax({
                url: 'ForgetPassword.aspx/SendOtp',
                type: 'post',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                data: "{email : '" + $("#idtxtemail").val() + "'}",
                success: function (data) {
                    data = JSON.parse(data.d)
                    $("#loder").empty();
                    if (data) {
                        $("#divforgtPass").css("visibility", "visible");
                        $("#divSendotp").css("visibility", "hidden");
                        alert('Check your Mail for OTP');
                    }
                    else {
                        alert('Email is not correct');
                    }
                },
                error: function () {
                    alert('Something Went Wrong');
                }
            });
        }

    </script>
    <h1 style="text-align: center;" class="text-white">Recover Password</h1>
    <div>
        <div id="loder">
        </div>
        <div class="container">
            <div class="row jumbotron">
                <div class="col-12">
                    <div class="form-group" id="divSendotp" style="visibility: visible">
                        <label for="id_oldPassword">
                            Email<span class="asteriskField">*</span>
                        </label>
                        <div class="">
                            <input type="text" name="txtemail" class="form-control" id="idtxtemail">
                        </div>
                        <a onclick="emailSubmit()" class="btn btn-primary">Get OTP</a>
                    </div>
                    <div style="visibility: hidden" id="divforgtPass">
                        <div class="form-group">
                            <label for="id_newPassword" class=" requiredField">
                                Enter OTP<span class="asteriskField">*</span>
                            </label>
                            <div>
                                <asp:TextBox ID="txtotp" class="textinput textInput form-control" runat="server" placeholder="Enter OTP"></asp:TextBox>
                            </div>
                        </div>
                        <div id="div_id_newPassword" class="form-group">
                            <label for="id_newPassword" class=" requiredField">
                                New Password<span class="asteriskField">*</span>
                            </label>
                            <div class="">
                                <asp:TextBox ID="txtnewPassword" class="textinput textInput form-control" placeholder=" Enter New Password" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div id="div_id_ConfirmPassword" class="form-group">
                            <label for="id_ConfirmPassword"
                                class=" requiredField">
                                Confirm Password<span class="asteriskField">*</span>
                            </label>
                            <div class="">
                                <asp:TextBox ID="txtConPass" class="textinput textInput form-control" placeholder="Confirm New Password" TextMode="Password" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Button ID="btnForgetPassword" CssClass="btn-primary" runat="server" Text="Save Changes" OnClick="btnForgetPassword_Click" />
                        <asp:Label runat="server" ID="lblmessage" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
