<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="EntranceSettingList.aspx.cs" Inherits="OnlineEntranceRegistration.Admin.EntranceSettingList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; min-height: 424px;">
        <div>
            <h5 align="center" class="text-white">Manage Exam Centes</h5>
        </div>
        <div align="center">

            <asp:GridView ID="grdsetting" runat="server" AutoGenerateColumns="False" OnRowCommand="grdsetting_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Start Date">
                        <ItemTemplate>
                            <%#Eval("startDate") %><br />

                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Last Date">
                        <ItemTemplate>
                            <%#Eval("endDate") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Notification">
                        <ItemTemplate>
                            <%#Eval("notification") %><br />

                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Notice">
                        <ItemTemplate>
                            <%#Eval("notice") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Menu">
                        <ItemTemplate>
                            <asp:LinkButton Class=" btn btn-danger" ID="btnDelete" CommandName="cmdDelete" Text="DELETE" OnClientClick="return confirm('Do you want to Delete Record !!!!!')" CommandArgument='<%#Eval("id") %>' runat="server"></asp:LinkButton>
                            <asp:LinkButton Class=" btn btn-primary" ID="cmdEdit" CommandName="cmdEdit" Text="EDIT"  CommandArgument='<%#Eval("id") %>' runat="server"></asp:LinkButton>
                        </ItemTemplate> 
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <br />
        </div>
    </div>

</asp:Content>
