<%@ Page Title="" Language="C#" MasterPageFile="~/sys/RocketMaster.Master" AutoEventWireup="true" CodeBehind="NewsUpdate.aspx.cs" Inherits="TayanaProject.sys.NewsUpdate"  ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    最新消息時間<input  type="date" id="UpdateTime"  placeholder="" runat="server" />
    
    <br />
     標題<asp:TextBox ID="Updatetitle" runat="server" ClientIDMode="Static"> </asp:TextBox>
    <br/>
    內容<Textarea ID="UpdateMain" runat="server" ClientIDMode="Static"> </Textarea>
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
    簡述<asp:TextBox ID="Updatebrief" runat="server" ClientIDMode="Static"></asp:TextBox>
    <br/>
    
   
   
    封面照
   <asp:HyperLink ID="PhotoHyperLink1" runat="server">HyperLink</asp:HyperLink>
    <br/>
    <asp:FileUpload ID="PhotoFileUpload1" runat="server" />
    <asp:HiddenField ID="PhotoHiddenField2" runat="server" />
    <asp:Label ID="PhotoMessage" runat="server" Text=""></asp:Label>
    
    <br/>

    下載檔
    <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
    <br/>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    
    <br/>
  
    
    <asp:Button ID="Button1" runat="server" Text="確認送出" OnClick="Button1_Click1"  />
    <input id="Reset1" type="reset" value="重新填寫" />
    <asp:Button ID="Button2" runat="server" Text="取消"   />






</asp:Content>
