<%@ Page Title="" Language="C#" MasterPageFile="~/Tayana.Master" AutoEventWireup="true" CodeBehind="Yachts.aspx.cs" Inherits="TayanaProject.Yachts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>

<%--上面--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentTop" runat="server">

    <%-- 遮罩--%>

    <div class="bannermasks">
        <img src="tayana/images/banner01_masks.png" alt="&quot;&quot;" /></div>
    <!--遮罩結束-->

    <div id="buttom01"><a href="#">
        <img src="tayana/images/buttom01.gif" alt="next" /></a></div>

    <!--小圖開始-->
    <div class="bannerimg">
        <ul>
            <li><a href="#">
                <div class="on">
                    <p class="bannerimg_p">
                        <img src="tayana/images/pit003.jpg" alt="&quot;&quot;" /></p>
                </div>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/images/pit003.jpg" alt="&quot;&quot;" width="300" /></p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/images/pit003.jpg" alt="&quot;&quot;" /></p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/images/pit003.jpg" alt="&quot;&quot;" /></p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/images/pit003.jpg" alt="&quot;&quot;" /></p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/images/pit003.jpg" alt="&quot;&quot;" /></p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/images/pit003.jpg" alt="&quot;&quot;" /></p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/images/pit003.jpg" alt="&quot;&quot;" /></p>
            </a></li>
        </ul>

        <ul>
            <li><a class="on" href="#">
                <p class="bannerimg_p">
                    <img src="images/pit003.jpg" alt="&quot;&quot;" /></p>
            </a></li>
            <li>
                <p class="bannerimg_p"><a href="#">
                    <img src="tayana/images/pit003.jpg" alt="&quot;&quot;" /></p>
            </li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/images/pit003.jpg" alt="&quot;&quot;" /></p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/images/pit003.jpg" alt="&quot;&quot;" /></p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/images/pit003.jpg" alt="&quot;&quot;" /></p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/images/pit003.jpg" alt="&quot;&quot;" /></p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/images/pit003.jpg" alt="&quot;&quot;" /></p>
            </a></li>
            <li><a href="#">
                <p class="bannerimg_p">
                    <img src="tayana/images/pit003.jpg" alt="&quot;&quot;" /></p>
            </a></li>
        </ul>


    </div>
    <!--小圖結束-->


    <div id="buttom02"><a href="#">
        <img src="tayana/images/buttom02.gif" alt="next" /></a></div>

    <!--------------------------------換圖開始---------------------------------------------------->

    <div class="banner">
        <ul>
            <li>
                <img src="tayana/images/test002.jpg" /></li>
            <li>
                <img src="tayana/images/test002.jpg" /></li>
            <li>
                <img src="tayana/images/test002.jpg" /></li>
            <li>
                <img src="tayana/images/test002.jpg" /></li>
            <li>
                <img src="tayana/images/test002.jpg" /></li>
            <li>
                <img src="tayana/images/test002.jpg" /></li>
        </ul>

    </div>
    <%--  <asp:Repeater ID="Repeater1" runat="server" >
        <HeaderTemplate>
                   <!--遮罩-->
                   <div class="bannermasks" style="margin: 78px 0 0 0px" >
                       <img src="tayana/images/banner01_masks.png" alt="&quot;&quot;" />
                   </div>
                   <!--遮罩結束-->
                   <div class="banner">
                       <div id="gallery" class="ad-gallery">
                           <div class="ad-image-wrapper">
                           </div>
                           <div class="ad-controls" style="display: none">
                           </div>
                           <div class="ad-nav">
                               <div class="ad-thumbs">
                                   <ul class="ad-thumb-list">
               </HeaderTemplate>
               <ItemTemplate>
                   <li>
                       <a href="/sys/uploadfile/Yachts_Photo/<%#Eval("Photos")%>">
                           <img src="/sys/uploadfile/Yachts_Photo/<%#Eval("Photos")%>">
                       </a>
                      
                   &nbsp;</li>
               </ItemTemplate>
               <FooterTemplate>
                   </ul>
               </div>
               </div>
               </div>
               </div>
               </FooterTemplate>

    </asp:Repeater>--%>
</asp:Content>



<%--左邊--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentLeft" runat="server">
    <div class="left">

        <div class="left1">
            <p><span>YACHTS</span></p>
            <ul>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <li>

                            <a href='<%# "Yachts.aspx?id="+ Eval("id") %>'>'<%# Eval("YachtsType") %>' </a>

                        </li>
                    </ItemTemplate>

                </asp:Repeater>

            </ul>
        </div>
    </div>




</asp:Content>


<%--右邊--%>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentRight" runat="server">
    <div id="crumb"><a href="#">Home</a> >> <a href="#">Yachts</a> >> <a href="#"><span class="on1" runat="server" id="Yachtsnnn"></span></a></div>

    <div class="right">
        <div class="right1">
            <div class="title"><span id="rightYachtsName" runat="server"></span></div>
            <div class="menu_y">
                <ul>
                    <li class="menu_y00">YACHTS</li>
                    
                    <li><a class="menu_yli01" href="Overview.aspx"><span runat="server" id="rightspan1"></span></a></li>
                    <li><a class="menu_yli02" href="Layout.aspx"><span runat="server" id="rightspan2"></span></a></li>
                    <li><a class="menu_yli03" href="Specifications.aspx"><span runat="server" id="rightspan3"></span></a></li>
                </ul>
            </div>
        </div>
    </div>


</asp:Content>
