<%@ Page Title="" Language="C#" MasterPageFile="~/sys/RocketMaster.Master" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="TayanaProject.sys.UpdateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    
    姓名<asp:TextBox ID="Updatename" runat="server" ClientIDMode="Static"></asp:TextBox>
    <br/>
    密碼<asp:TextBox ID="Updatepassword" runat="server" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
    <br/>
    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static"/>
    <br/>
    確認密碼<asp:TextBox ID="Updaterepassword" runat="server" ClientIDMode="Static"></asp:TextBox>
    <br/>
    信箱<asp:TextBox ID="Updatemail" runat="server" ClientIDMode="Static"></asp:TextBox>
    <br/>
    <asp:Image ID="Image1" style="object-fit: contain" runat="server" Height="100px" Width="100px" />
    <br/>
    照片<asp:FileUpload ID="FileUpload" runat="server" />
    <br/>
    <asp:HiddenField ID="PhotoHiddenField2" runat="server" />
    <asp:Label ID="Message" runat="server" Text="Label"></asp:Label>
    <br/>
    <asp:CheckBox ID="AllChecked" ClientIDMode="Static" runat="server" />全選
    <asp:CheckBoxList ID="Updatepermission" runat="server">

        <asp:ListItem class="permission"  Value="001">最高權限</asp:ListItem>
        <asp:ListItem class="permission" Value="002">第二號權限</asp:ListItem>
        <asp:ListItem class="permission" Value="003">第三號權限</asp:ListItem>
        <asp:ListItem class="permission" Value="004">第四號權限</asp:ListItem>
        <asp:ListItem class="permission" Value="005">第五號權限</asp:ListItem>

    </asp:CheckBoxList>
    <br/>

    
    <asp:Button ID="Button1" runat="server" Text="確認送出" OnClick="Button1_Click" />
    <input id="Reset1" type="reset" value="重新填寫" />
    <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click"  />
    
    

</asp:Content>
