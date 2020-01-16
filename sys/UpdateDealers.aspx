<%@ Page Title="" Language="C#" MasterPageFile="~/sys/RocketMaster.Master" ValidateRequest="False" AutoEventWireup="true" CodeBehind="UpdateDealers.aspx.cs" Inherits="TayanaProject.sys.UpdateDealers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     
    
    國家別<asp:DropDownList ID="DropDownList1" runat="server" ClientIDMode="Static"></asp:DropDownList>
    <br/>
    經銷商區域<asp:TextBox ID="UpdateDealers1" runat="server" ClientIDMode="Static"></asp:TextBox>
    <br/>
    內容<Textarea ID="UpdateMain" runat="server" ClientIDMode="Static"></Textarea>
     <script type="text/javascript">
        CKEDITOR.replace('UpdateMain', {
             filebrowserBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html',
             filebrowserImageBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Images',
             filebrowserFlashBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Flash',
             filebrowserUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
             filebrowserImageUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
             filebrowserFlashUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'

         });</script>
    <br/>
    照片
    <asp:HyperLink ID="DownLoadHyperLink1" runat="server">HyperLink</asp:HyperLink>
    <br/>
    <asp:FileUpload ID="DownLoadFileUpload1" runat="server" />
    <asp:HiddenField ID="DownLoadHiddenField2" runat="server" />
    <asp:Label ID="DownLoadMessage" runat="server" Text=""></asp:Label>
    <br/>
  
    
    <asp:Button ID="Button1" runat="server" Text="確認送出" OnClick="Button1_Click"   />
    <input id="Reset1" type="reset" value="重新填寫" />
    <asp:Button ID="Button2" runat="server" Text="取消"  />







</asp:Content>
