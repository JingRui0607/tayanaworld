<%@ Page Title="" Language="C#" MasterPageFile="~/sys/RocketMaster.Master" AutoEventWireup="true" CodeBehind="YachtsLayout.aspx.cs" Inherits="TayanaProject.sys.YachtsLayout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:FileUpload ID="FileUpload1" AllowMultiple="true" runat="server" /><asp:Button ID="Button1" runat="server" Text="新增" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="返回" OnClick="Button2_Click" />
    <br />
    <asp:Label ID="Message" runat="server" Text=""></asp:Label>

    <div class="col-md-12">
        <div class="card">
            <div class="card-header">
                <h4 class="card-title">設計圖</h4>
                <div class="table-responsive">
                    <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting"   >
                        <Columns>
                            <asp:TemplateField HeaderText="設計圖" SortExpression="Photos">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Photos") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="Image1" max-width="609px" width="300" style="object-fit: contain" runat="server" ImageUrl='<%# "/sys/uploadfile/Yachts_Layout/"+Eval("LayoutPhoto") %>' />
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
