<%@ Page Title="" Language="C#" MasterPageFile="~/sys/RocketMaster.Master" AutoEventWireup="true" CodeBehind="YachtsInformation.aspx.cs" Inherits="TayanaProject.sys.ADDYachts" %>
<%@ Register TagPrefix="uc1" TagName="UserPagination" Src="~/sys/UserPagination.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
    <link href="userCSS.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="col-md-12">
        <div class="card">
            <div class="card-header">
                <h4 class="card-title">遊艇型號</h4>
                <div class="table-responsive">
                    <asp:Button ID="Button1" runat="server" Text="新增船型" OnClick="Button1_Click" />
                   <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" DataKeyNames="id" BorderStyle="None" GridLines="Horizontal" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowCommand="GridView1_RowCommand" >
                        <Columns >
                            
                            <asp:TemplateField HeaderText="照片" SortExpression="photo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Main") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    
                                   <%-- 資料繫結從uploadfile+繫結的資料庫欄位名稱--%>
                                    <asp:Image ID="Image1" style="object-fit: contain" runat="server" ImageUrl='<%# "/sys/uploadfile/Yachts_Photo/"+Eval("Main") %>' Height="100px" ImageAlign="AbsMiddle" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="YachtsType" HeaderText="船的型號" SortExpression="YachtsType" />
                            <asp:TemplateField HeaderText="最新船型" SortExpression="NewYachts">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("NewYachts") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("NewYachts") %>'></asp:Label>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="NewYachts" >最新船型</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="false" CommandName="YachtsAlbum" Text="相簿"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="false" CommandName="YachtsLayout" Text="設計圖"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
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
