<%@ Page Title="" Language="C#" MasterPageFile="~/Tayana.Master" AutoEventWireup="true" CodeBehind="Specifications.aspx.cs" Inherits="TayanaProject.Specifications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="shortcut icon" href="favicon.ico" />



    <script type="text/javascript">
        $(function () {
            $('.topbuttom').click(function () {
                $('html, body').scrollTop(0);
            });
        });
    </script>
    <link rel="stylesheet" type="text/css" href="/tayana/html/css/jquery.ad-gallery.css">
    <style type="text/css">
        img, div, input {
            behavior: url("");
        }
    </style>
    <script type="text/javascript" src="/tayana/Scripts/jquery.ad-gallery.js"></script>
    <script type="text/javascript">
        $(function () {
               var galleries = $('.ad-gallery').adGallery();
               galleries[0].settings.effect = 'fade';
               if ($('.banner input[type=hidden]').val() == "0") {
                   $(".bannermasks").hide();
                   $(".banner").hide();
                   $("#crumb").css("top", "125px");
               }
           });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentTop" runat="server">
    <div class="bannermasks">
        <%-- <div class="bannermasks" style="top:95px">--%>

        <img src="tayana/images/banner01_masks.png" alt="&quot;&quot;" />
    </div>
    <!--遮罩結束-->

    <div class="banner1">
        <input type="hidden" name="ctl00$ContentPlaceHolder1$Gallery1$HiddenField1" id="ctl00_ContentPlaceHolder1_Gallery1_HiddenField1" value="1" />
        <div id="gallery" class="ad-gallery">
            <div class="ad-image-wrapper">
            </div>
            <%--   <div class="ad-controls" style="display:none">--%>
            <div class="ad-controls">
            </div>
            <div class="ad-nav ">
                <%--<div class="ad-nav " style="top:396px" >--%>
                <div class="ad-thumbs">

                    <ul class="ad-thumb-list">



                        <asp:Repeater ID="Repeater3" runat="server">

                            <ItemTemplate>


                                <li><a href='<%# "sys/uploadfile/Yachts_Photo/"+Eval("Photos") %>'>
                                    <img src='<%# "sys/uploadfile/Yachts_Photo/s"+Eval("Photos") %>' class="image0" />
                                </a></li>


                            </ItemTemplate>

                        </asp:Repeater>

                    </ul>

                </div>
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentLeft" runat="server">

    <div class="left">

        <div class="left1">
            <p><span>YACHTS</span></p>
            <ul>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <li>

                            <a href='<%# "Overview.aspx?id="+ Eval("id") %>'><%# Eval("YachtsType") %> <span style="color: red"><%# Eval("NewYachts").ToString()=="False"?"":"New" %></span></a>

                        </li>
                    </ItemTemplate>

                </asp:Repeater>

            </ul>
        </div>
    </div>
</asp:Content>






<asp:Content ID="Content4" ContentPlaceHolderID="ContentRight" runat="server">

    <div id="crumb"><a href="#">Home</a> >> <a href="#">Yachts</a> >> <a href="#"><span class="on1" runat="server" id="Yachtsnnn"></span></a></div>

    <div class="right">
        <div class="right1">
            <div class="title"><span id="rightYachtsName" runat="server"></span><span id="spanname" runat="server" style='color: red'></span></div>
            <div class="menu_y">
                <ul>
                    <li class="menu_y00">YACHTS</li>

                   <li><a class="menu_yli01"  href="Overview.aspx" id="menuOverview" runat="server"></a></li>
                    <li><a class="menu_yli02" href="Layout.aspx" id="menuLayout" runat="server"></a></li>
                    <li><a class="menu_yli03" href="Specifications.aspx" id="menuSpec" runat="server"></a></li>
                </ul>
            </div>

            <%-- 內容--%>
            <div class="box5">
                <h4>DETAIL SPECIFICATION</h4>

                <div id="yacht001" runat="server"></div>

            </div>


            <p class="topbuttom">
                <img src="tayana/images/top.gif" alt="top" /></p>




        </div>
    </div>
    <style>
        .ad-controls {
            display: none;
        }

        .ad-gallery .ad-image-wrapper {
            height: 355px;
        }

        .ad-gallery .ad-nav {
            top: 455px;
        }

        .bannermasks {
            top: 156px;
            z-index: 0;
        }

        #crumb {
            top: 569px;
        }

        .conbg {
            margin-top: 98px;
        }

        .ad-gallery .ad-image-wrapper {
            width: 96.5%;
            left: 18px;
        }
        .ad-gallery .ad-image-wrapper .ad-next .ad-next-image {
                width: 0px;
            }
           .ad-gallery .ad-image-wrapper .ad-prev .ad-prev-image, .ad-gallery .ad-image-wrapper .ad-next .ad-next-image {
               width: 0;
           }

           

        /*.contain {
            width: 985px;
        }
        .conbg {
            width: 984px;
        }*/

        }
    </style>

</asp:Content>
