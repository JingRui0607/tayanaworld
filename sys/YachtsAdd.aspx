<%@ Page Title="" Language="C#" MasterPageFile="~/sys/RocketMaster.Master" AutoEventWireup="true" ValidateRequest="False" CodeBehind="YachtsAdd.aspx.cs" Inherits="TayanaProject.sys.YachtsAdd" %>
<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
   
    <script src="ckeditor/ckeditor.js" ></script>
   <%-- <script src="ckeditor/config.js" type="text/javascript" charset="utf-8"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
  <%--  <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="200px" Width="600px"></asp:TextBox>
    <script  type="text/javascript">
        CKEDITOR.replace('TextBox1');
</script>--%>
  
 
    <asp:Button ID="Button3" runat="server" Text="取消" OnClick="Button3_Click" />


    
    <br />


    
    YachtType<asp:TextBox ID="AddName" runat="server" ClientIDMode="Static"> </asp:TextBox>
    <br/>
    Overview<textarea ID="AddOverview" runat="server" ClientIDMode="Static"></textarea>
    <script type="text/javascript">
        CKEDITOR.replace('AddOverview', {
            filebrowserBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html',
            filebrowserImageBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Images',
            filebrowserFlashBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Flash',
            filebrowserUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
            filebrowserImageUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
            filebrowserFlashUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'

        });
</script>
    <br/>
    
    Dimensions<textarea id="AddDimensions" ClientIDMode="Static" runat="server"></textarea>
    <script type="text/javascript">
        CKEDITOR.replace('AddDimensions', {
            filebrowserBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html',
            filebrowserImageBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Images',
            filebrowserFlashBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Flash',
            filebrowserUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
            filebrowserImageUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
            filebrowserFlashUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'

        });
</script>

    <br/>
    Specification<textarea ID="AddSpecification" runat="server" ClientIDMode="Static"></textarea>
    <script type="text/javascript">
        CKEDITOR.replace('AddSpecification', {
            filebrowserBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html',
            filebrowserImageBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Images',
            filebrowserFlashBrowseUrl: '/sys/ckeditor/ckfinder/ckfinder.html?type=Flash',
            filebrowserUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
            filebrowserImageUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
            filebrowserFlashUploadUrl: '/sys/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'

        });
</script>
    <br/>
    Layout & DeckPlan<asp:FileUpload ID="FileLayoutUpload1" runat="server" AllowMultiple="true" />
     <asp:Label ID="Message1" runat="server" Text=""></asp:Label>
    <br />
    IsNewYachts<asp:CheckBox ID="CheckBox1" runat="server" />
    <br/>
    上傳下載附件<asp:FileUpload ID="AddDownUpload1" runat="server" AllowMultiple="true" />
    <br/>

    上傳照片<asp:FileUpload ID="FilePhotoUpload1" runat="server" AllowMultiple="true"/>
    <asp:Label ID="Message" runat="server" Text=""></asp:Label>
    <br/>
    <asp:Button ID="Button1" runat="server" Text="確認送出" OnClick="Button1_Click"  />
    <input id="Reset1" type="reset" value="重新填寫" />
    <asp:Button ID="Button2" runat="server" Text="取消"  />
    

</asp:Content>
