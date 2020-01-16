<%@ Page Title="" Language="C#" MasterPageFile="~/Tayana.Master" AutoEventWireup="true" CodeBehind="NewsMain.aspx.cs" Inherits="TayanaProject.NewsMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentTop" runat="server">
    <div class="banner">
        <ul>
            <li>
                <img src="tayana/images/newbanner.jpg" alt="Tayana Yachts" /></li>
        </ul>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentLeft" runat="server">
    <div class="left">

        <div class="left1">
            <p><span>NEWS</span></p>
            <ul>
                <li><a href="NewsIndex.aspx">News & Events</a></li>

            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentRight" runat="server">
    <div id="crumb"><a href="#">Home</a> >> <a href="#">News</a> >> <a href="NewsIndex.aspx"><span class="on1">News & Events</span></a></div>

    <div class="right">
        <div class="right1">
            <div class="title"><span>News & Events</span></div>
            <div class="box3">
                <h4 id="NewsMainName" runat="server"></h4>
                <div id="NewsMains" runat="server"></div>
            </div>


            <div class="downloads">
                <p>
                    <img src="tayana/images/downloads.gif" alt="&quot;&quot;" /></p>
                <ul>
                     <asp:Repeater ID="Repeater_download" runat="server">

                       
                        <ItemTemplate>
                            <li>
                                
                                <a href='<%# "sys/uploadfile/News_download/"+ Eval("filename") %>'  > <%# Eval("title") %> - <%# Eval("ROW_ID") %> </a>

                            </li>
                        </ItemTemplate>


                    </asp:Repeater>
                   <%-- <li><a href="#">Downloads 001</a></li>
                    <li><a href="#">Downloads 001</a></li>
                    <li><a href="#">Downloads 001</a></li>
                    <li><a href="#">Downloads 001</a></li>
                    <li><a href="#">Downloads 001</a></li>--%>
                </ul>
            </div>
            <div class="buttom001"><a href="#"><img src="tayana/images/back.gif" alt="&quot;&quot;" width="55" height="28" /></a></div>

        </div>
    </div>


</asp:Content>
