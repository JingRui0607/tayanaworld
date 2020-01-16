<%@ Page Title="" Language="C#" MasterPageFile="~/sys/RocketMaster.Master" AutoEventWireup="true" CodeBehind="Dealers.aspx.cs" Inherits="TayanaProject.sys.Dealers" %>

<%@ Register Src="~/sys/UserPagination.ascx" TagPrefix="uc1" TagName="UserPagination" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="col-md-12">
        <div class="card">
            <div class="card-header">
                <h4 class="card-title">User Informatio<asp:Button ID="Button1" runat="server"  Text="新增經銷商" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="編輯國家別" OnClick="Button2_Click" />
                </h4>

                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id"  BorderStyle="None" GridLines="Horizontal" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" >
                        <Columns >
                            <asp:BoundField DataField="Country" HeaderText="國家" SortExpression="Country" />
                            <asp:TemplateField HeaderText="經銷商照" SortExpression="mainphoto">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("photo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    
                                  
                                    <asp:Image ID="Image1" style="object-fit: contain;max-width:100px" runat="server" ImageUrl='<%# "/sys/uploadfile/dealers_photo/"+Eval("photo") %>' Height="100px"  ImageAlign="AbsMiddle" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DealersName" HeaderText="經銷商" SortExpression="DealersName" />
                            

                            
                            
                            
                            <asp:TemplateField HeaderText="編輯" ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                    
                    

                </div>
            </div>
        </div>
       
       
        <br />


        <uc1:UserPagination runat="server" ID="UserPagination" />




</asp:Content>
