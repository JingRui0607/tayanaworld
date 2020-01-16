<%@ Page Title="" Language="C#" MasterPageFile="~/Tayana.Master" AutoEventWireup="true" CodeBehind="NewsIndex.aspx.cs" Inherits="TayanaProject.NewsIndex" %>

<%@ Register Src="~/sys/UserPagination.ascx" TagPrefix="uc1" TagName="UserPagination" %>


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

            <div class="box2_list">
                <ul>

                    <asp:Repeater ID="Repeater1" runat="server">

                        <ItemTemplate>
                            <li>
                                <div class="list01">
                                    <ul>
                                        <li>
                                            <div>
                                                <p>
                                                    <img src='<%# "sys/uploadfile/Yachts_News/"+ Eval("mainphoto") %>' style="object-fit: contain; max-width:161px;" alt="&quot;&quot;" />
                                                </p>
                                            </div>
                                        </li>
                                        <li><span><%# DataBinder.Eval(Container.DataItem,"NewsDate","{0:yyyy-MM-dd}") %></span><br />
                                           <a style="text-decoration:none;color: #34A9D4;" href=<%#"NewsMain.aspx?id="+ Eval("id") %>> <%# Eval("title") %></a></li><br />
                                        <li><%# Eval("brief") %></li>
                                    </ul>
                                </div>
                            </li>
                        </ItemTemplate>



                    </asp:Repeater>

                </ul>
              

                <uc1:UserPagination runat="server" ID="UserPagination" />
            </div>
        </div>
    </div>

</asp:Content>
