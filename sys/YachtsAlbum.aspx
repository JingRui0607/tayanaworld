<%@ Page Title="" Language="C#" MasterPageFile="~/sys/RocketMaster.Master" AutoEventWireup="true" CodeBehind="YachtsAlbum.aspx.cs" Inherits="TayanaProject.sys.YachtsAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:FileUpload ID="FileUpload1" AllowMultiple="true" runat="server" /><asp:Button ID="Button1" runat="server" Text="新增" OnClick="Button1_Click" />
    <asp:Button ID="Button3" runat="server" Text="返回" OnClick="Button3_Click" />

    <br />
    <asp:Label ID="Message" runat="server" Text=""></asp:Label>

    <div class="col-md-12">
        <div class="card">
            <div class="card-header">
                <h4 class="card-title">相片</h4>
                <div class="table-responsive">
                    <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand"  >
                        <Columns>
                            <asp:TemplateField HeaderText="照片" SortExpression="Photos">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Photos") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="Image1"  max-width="609px" width="300" style="object-fit: contain" runat="server" ImageUrl='<%# "/sys/uploadfile/Yachts_Photo/"+Eval("Photos") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="設為封面照" SortExpression="MainPhoto">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("MainPhoto") %>'></asp:Label>
                                    <asp:Button ID="Button2" runat="server" CommandName="mainPhoto" Text="封面照" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" OnClientClick="javascript:if(!window.confirm('你確定要刪除嗎?')) window.event.returnValue = false;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                    </asp:GridView>
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
