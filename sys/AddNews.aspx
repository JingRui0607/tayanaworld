<%@ Page Title="" Language="C#" MasterPageFile="~/sys/RocketMaster.Master" AutoEventWireup="true" ValidateRequest="False" CodeBehind="AddNews.aspx.cs" Inherits="TayanaProject.sys.AddNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <h1>新增最新消息</h1>



    最新消息時間<input  type="date" id="timeStart"  placeholder="請輸入時間" runat="server" />
    
    <br />
    標題<asp:TextBox ID="Addtitle" runat="server" ClientIDMode="Static"> </asp:TextBox>
    <br />
    內容
    <Textarea ID="Addmain" runat="server" ClientIDMode="Static"></Textarea>
    <script type="text/javascript">
        CKEDITOR.replace('Addmain', {
             filebrowserBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html',
             filebrowserImageBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Images',
             filebrowserFlashBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Flash',
             filebrowserUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
             filebrowserImageUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
             filebrowserFlashUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'

         });</script>
    <br />
    簡述<asp:TextBox ID="Addbrief" runat="server" ClientIDMode="Static"></asp:TextBox>
    <br />
    封面照<asp:FileUpload ID="FilePhotoUpload1" runat="server" />
    <asp:Label ID="Message" runat="server" Text=""></asp:Label>
    <br />

    是否置頂<asp:CheckBox ID="CheckBox1" runat="server" />
    <br />
    上傳下載檔<asp:FileUpload ID="AddDownUpload1" runat="server" AllowMultiple="true" />
    <br />


    <asp:Button ID="Button1" runat="server" Text="確認送出" OnClick="Button1_Click" />
    <input id="Reset1" type="reset" value="重新填寫" />
    <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" />


</asp:Content>
