<%@ Page Title="" Language="C#" MasterPageFile="~/sys/RocketMaster.Master" AutoEventWireup="true" CodeBehind="YachtsUpdate.aspx.cs" Inherits="TayanaProject.sys.YachtsUpdate" ValidateRequest="False"%>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    
    
    遊艇編號<asp:TextBox ID="UpdateName" runat="server" ClientIDMode="Static"> </asp:TextBox>
    <br/>
    Overview<textarea ID="UpdateOverview" runat="server" ClientIDMode="Static"></textarea>
     <script type="text/javascript">
         CKEDITOR.replace('UpdateOverview', {
             filebrowserBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html',
             filebrowserImageBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Images',
             filebrowserFlashBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Flash',
             filebrowserUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
             filebrowserImageUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
             filebrowserFlashUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'

         });</script>
    <br/>
    Dimensions<%--<asp:TextBox ID="UpdateDimensions" runat="server" ClientIDMode="Static"></asp:TextBox>--%>
    <textarea ID="UpdateDimensions" runat="server" ClientIDMode="Static"></textarea>
    <script type="text/javascript">
        CKEDITOR.replace('UpdateDimensions', {
            filebrowserBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html',
            filebrowserImageBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Images',
            filebrowserFlashBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Flash',
            filebrowserUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
            filebrowserImageUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
            filebrowserFlashUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'

        });
     </script>

    <br/>
    Specification<textarea ID="UpdateSpecification" runat="server" ClientIDMode="Static"></textarea>
    <script type="text/javascript">
        CKEDITOR.replace('UpdateSpecification', {
            filebrowserBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html',
            filebrowserImageBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Images',
            filebrowserFlashBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Flash',
            filebrowserUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
            filebrowserImageUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
            filebrowserFlashUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'

        });
     </script>
    <br/>
    DownLoads
    <asp:HyperLink ID="DownLoadHyperLink1" runat="server">HyperLink</asp:HyperLink>
    <br/>
    <asp:FileUpload ID="DownLoadFileUpload1" runat="server" />
    <asp:HiddenField ID="DownLoadHiddenField2" runat="server" />
    <asp:Label ID="DownLoadMessage" runat="server" Text=""></asp:Label>
    <br/>
  
    
    <asp:Button ID="Button1" runat="server" Text="確認送出" OnClick="Button1_Click"  />
    <input id="Reset1" type="reset" value="重新填寫" />
    <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click"  />


   
    
  



    

    
    
    
    
    
    
    

</asp:Content>
