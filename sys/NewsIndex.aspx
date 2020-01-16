<%@ Page Title="" Language="C#" MasterPageFile="~/sys/RocketMaster.Master" AutoEventWireup="true" CodeBehind="NewsIndex.aspx.cs" Inherits="TayanaProject.sys.NewsIndex" %>

<%@ Register Src="~/sys/UserPagination.ascx" TagPrefix="uc1" TagName="UserPagination" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="col-md-12">
        <div class="card">
            <div class="card-header">
                <h4 class="card-title">最新消息<asp:Button ID="Button1" runat="server"  Text="新增News" OnClick="Button1_Click"  />
                   
                </h4>

                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id"  BorderStyle="None" GridLines="Horizontal"  OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowCommand="GridView1_RowCommand" >
                        <Columns >
                            <asp:BoundField DataField="title" HeaderText="標題" SortExpression="title" />
                            <asp:TemplateField HeaderText="News封面照" SortExpression="mainphoto">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("mainphoto") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    
                                  
                                    <asp:Image ID="Image1" style="object-fit: contain" runat="server" ImageUrl='<%# "/sys/uploadfile/Yachts_News/"+Eval("mainphoto") %>' Height="100px" ImageAlign="AbsMiddle" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="brief" HeaderText="簡述" SortExpression="brief" />
                        

                            <asp:TemplateField HeaderText="置頂" SortExpression="Newstop">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Newstop") %>'></asp:Label>
                                    <asp:Button ID="Button2" runat="server" CommandName="NewsTop" Text="按我置頂" />
                                </ItemTemplate>
                             </asp:TemplateField>
                            
                            
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
