<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="ManageCourse.aspx.cs" Inherits="OnlineEntranceRegistration.Admin.ManageCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="width:100%; min-height:424px;">
        <div>
            <h5 align="center" class="text-white">Manage Course</h5>
        </div>
        <div align="center" >

            <asp:GridView ID="grdCourse" runat="server" AutoGenerateColumns="False" OnRowCommand="grdexamcenter_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <%--(name,code,duration,seat,details,status,dateOfCreated)--%>
                    <asp:TemplateField HeaderText="Course Name">
                        <ItemTemplate>
                            <%#Eval("name") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                   
                    <asp:TemplateField HeaderText="Course Code">
                        <ItemTemplate>
                            <%#Eval("code") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Course Duration">
                        <ItemTemplate>
                            <%#Eval("duration") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="No of Seat">
                        <ItemTemplate>
                            <%#Eval("seat") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Other Details">
                        <ItemTemplate>
                            <%#Eval("details") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Menu">
                    <ItemTemplate>
                        <asp:LinkButton  Class=" btn btn-danger" ID="btnDelete" CommandName="cmdDelete" Text="DELETE" OnClientClick="return confirm('Do you want to Delete Record !!!!!')" CommandArgument='<%#Eval("id") %>' runat="server"></asp:LinkButton>
                        <asp:LinkButton  Class=" btn btn-primary" ID="btnEdit" CommandName="cmdEdit" Text="EDIT" CommandArgument='<%#Eval("id") %>' runat="server"></asp:LinkButton>
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
