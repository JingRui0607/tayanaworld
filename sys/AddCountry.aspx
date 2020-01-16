<%@ Page Title="" Language="C#" MasterPageFile="~/sys/RocketMaster.Master" AutoEventWireup="true" CodeBehind="AddCountry.aspx.cs" Inherits="TayanaProject.sys.AddCountry" %>

<%@ Register Src="~/sys/UserPagination.ascx" TagPrefix="uc1" TagName="UserPagination" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-md-12">
        <div class="card">
            <div class="card-header">
                <h4 class="card-title">國家別<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox> <asp:Button ID="Button1" runat="server"  Text="新增國家" OnClick="Button1_Click" />
                    

                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id"  BorderStyle="None" GridLines="Horizontal" OnRowDeleting="GridView1_RowDeleting"  >
                        <Columns >
                            <asp:BoundField DataField="name" HeaderText="國家" SortExpression="name" />
                           
                            
                            
                           
                            <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            
                            
                            
                        </Columns>
                        <%--<EmptyDataTemplate>
                            <asp:Button ID="Button2" runat="server" Text="Button" />
                        </EmptyDataTemplate>--%>
                        <FooterStyle BorderStyle="None" />
                        <HeaderStyle BorderColor="Black" BorderStyle="Double" BorderWidth="0px" CssClass=" text-primary" />
                    </asp:GridView>
                    <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" />
                    

                </div>
            </div>
        </div>
       
       
        <br />
         <uc1:UserPagination runat="server" ID="UserPagination" />

        


</asp:Content>
