<%@ Page Title="" Language="C#" MasterPageFile="~/sys/RocketMaster.Master" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="TayanaProject.sys.user" %>

<%@ Register Src="~/sys/UserPagination.ascx" TagPrefix="uc1" TagName="UserPagination" %>


<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    
    <link href="userCSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="col-md-12">
        <div class="card">
            <div class="card-header">
                <h4 class="card-title">User Informatio<asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="新增" />
                </h4>
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" BorderStyle="None" GridLines="Horizontal">
                        <Columns >
                            <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" />
                            <asp:TemplateField HeaderText="照片" SortExpression="photo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("photo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    
                                   <%-- 資料繫結從uploadfile+繫結的資料庫欄位名稱--%>
                                    <asp:Image ID="Image1" style="object-fit: contain" runat="server" ImageUrl='<%# "/sys/uploadfile/User_Photo/"+Eval("photo") %>' Height="100px" ImageAlign="AbsMiddle" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="username" HeaderText="帳號" SortExpression="username" />
                            <asp:BoundField DataField="mail" HeaderText="信箱" SortExpression="mail" />
                            <asp:TemplateField HeaderText="編輯" ShowHeader="False">
                               <%-- <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Button ID="Button2" runat="server" Text="Button" />
                        </EmptyDataTemplate>
                        <FooterStyle BorderStyle="None" />
                        <HeaderStyle BorderColor="Black" BorderStyle="Double" BorderWidth="0px" CssClass=" text-primary" />
                    </asp:GridView>
                    
                    

                </div>
            </div>
        </div>
       
        <uc1:UserPagination ID="UserPagination" runat="server" />
        <br />
       
    </div>










</asp:Content>


