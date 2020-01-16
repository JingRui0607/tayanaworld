<%@ Page Title="" Language="C#" MasterPageFile="~/sys/RocketMaster.Master" AutoEventWireup="true" ValidateRequest="False" CodeBehind="AddDealers.aspx.cs" Inherits="TayanaProject.sys.AddDealers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>新增經銷商</h1>
    <br />
    國家<asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    <br />
    經銷商名稱<asp:TextBox ID="AddDealer" runat="server"></asp:TextBox>
    <br />
    經銷商資訊<Textarea ID="AddMain" runat="server" ClientIDMode="Static"></Textarea>
     <script type="text/javascript">
        CKEDITOR.replace('AddMain', {
             filebrowserBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html',
             filebrowserImageBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Images',
             filebrowserFlashBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Flash',
             filebrowserUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
             filebrowserImageUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
             filebrowserFlashUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'

         });</script>
    <br />
    上傳封面照<asp:FileUpload ID="FileUpload1" runat="server" />
     <asp:Label ID="Message" runat="server" Text=""></asp:Label>
    <br />
     <asp:Button ID="Button1" runat="server" Text="確認送出" OnClick="Button1_Click"   />
    <br />
    <input id="Reset1" type="reset" value="重新填寫" />
    <asp:Button ID="Button2" runat="server" Text="取消"  />

</asp:Content>
