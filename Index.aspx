<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TayanaProject.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <script type="text/javascript" src="/tayana/Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="/tayana/Scripts/jquery.cycle.all.2.74.js"></script>
    <script type="text/javascript">


        $(function () {

            // 先取得 #abgne-block-20110111 , 必要參數及輪播間隔
            var $block = $('#abgne-block-20110111'),
                timrt, speed = 4000;


            // 幫 #abgne-block-20110111 .title ul li 加上 hover() 事件
            var $li = $('.title ul li', $block).hover(function () {
                // 當滑鼠移上時加上 .over 樣式
                $(this).addClass('over').siblings('.over').removeClass('over');
            }, function () {
                // 當滑鼠移出時移除 .over 樣式
                $(this).removeClass('over');
            }).click(function () {
                // 當滑鼠點擊時, 顯示相對應的 div.info
                // 並加上 .on 樣式

                $(this).addClass('on').siblings('.on').removeClass('on');
                $('#abgne-block-20110111 .bd .banner ul:eq(0)').children().hide().eq($(this).index()).fadeIn(1000);
            });

            // 幫 $block 加上 hover() 事件
            $block.hover(function () {
                // 當滑鼠移上時停止計時器
                clearTimeout(timer);
            }, function () {
                // 當滑鼠移出時啟動計時器
                timer = setTimeout(move, speed);
            });

            // 控制輪播
            function move() {
                var _index = $('.title ul li.on', $block).index();
                _index = (_index + 1) % $li.length;
                $li.eq(_index).click();

                timer = setTimeout(move, speed);
            }

            // 啟動計時器
            timer = setTimeout(move, speed);

        });


    </script>
    <!--[if lt IE 7]>
<script type="text/javascript" src="javascript/iepngfix_tilebg.js"></script>
<![endif]-->
    <link href="/tayana/html/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/tayana/html/css/reset.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="contain">
            <div class="sub">
                <p><a href="Index.aspx">Home</a></p>
            </div>

            <!--------------------------------選單開始---------------------------------------------------->
            <div class="menu">
                <ul>

                    <li class="menuli01"><a href="Yachts.aspx">Yachts</a></li>
                    <li class="menuli02"><a href="NewsIndex.aspx">NEWS</a></li>
                    <li class="menuli03"><a href="Company.aspx">COMPANY</a></li>
                    <li class="menuli04"><a href="Dealers.aspx">DEALERS</a></li>
                    <li class="menuli05"><a href="Contact.aspx">CONTACT</a></li>
                </ul>
            </div>
            <!--------------------------------選單開始結束---------------------------------------------------->


            <!--遮罩-->
            <div class="bannermasks">
                <img src="tayana/images/banner00_masks.png" alt="&quot;&quot;" />
            </div>
            <!--遮罩結束-->








            <!--------------------------------換圖開始---------------------------------------------------->
            <div id="abgne-block-20110111">
                <div class="bd">
                    <div class="banner">

                        <ul>
                            <asp:Repeater ID="Repeater3" runat="server">

                                <ItemTemplate>


                                    <li class="info on"><a href="<%# "sys/uploadfile/Yachts_Photo/"+Eval("Photos") %>">
                                        <img src='<%# "sys/uploadfile/Yachts_Photo/"+Eval("Photos")  %>'  style="object-fit: contain; max-width:967px;"/></a><!--文字開始--><div class="wordtitle">
                                            TAYANA <span><%# Eval("YachtsType") %></span><br />
                                            <p>SPECIFICATION SHEET</p>
                                        </div>

                                        <div class="new" visible='<%# Eval("NewYachts").ToString()=="False"?false:true %>' runat="server" >
                                        <asp:Image ID="Image1"  runat="server" ImageUrl="tayana/html/images/new01.png" />
                                        </div>
                                            <!--文字結束-->
                                    </li>


                                </ItemTemplate>

                            </asp:Repeater>




                        </ul>


                        <!--小圖開始-->
                        <div class="bannerimg title">
                            <ul>
                                <asp:Repeater ID="Repeater1" runat="server">

                                    <ItemTemplate>
                                        <li>
                                            <div>
                                                <p class="bannerimg_p">
                                                    <img src='<%# "sys/uploadfile/Yachts_Photo/s"+Eval("Photos") %>' alt="&quot;&quot;" />
                                                </p>
                                            </div>
                                        </li>
                                    </ItemTemplate>

                                </asp:Repeater>

                            </ul>
                        </div>
                        <!--小圖結束-->
                    </div>
                </div>
            </div>
            <!--------------------------------換圖結束---------------------------------------------------->


            <!--------------------------------最新消息---------------------------------------------------->
            <div class="news">
                <div class="newstitle">
                    <p class="newstitlep1">
                        <img src="tayana/images/news.gif" alt="news" />
                    </p>
                    <p class="newstitlep2"><a href="NewsIndex.aspx">More>></a></p>
                </div>

                <ul>
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>

                            <li>

                                <div class="news01">
                                    <!--TOP標籤-->
                                    <div class="newstop" visible='<%# Eval("Newstop").ToString()=="False"?false:true %>' runat="server" >
                                        <img src="tayana/images/new_top01.png" alt="&quot;&quot;" />
                                    </div>
                                    <!--TOP標籤結束-->
                                    <div class="news02p1">
                                        <p class="news02p1img">
                                            <img src='<%# "sys/uploadfile/Yachts_News/"+Eval("mainphoto") %>' style="object-fit: contain " width="107" alt="&quot;&quot;" />
                                        </p>
                                    </div>
                                    <p class="news02p2"><span><%# Eval("title").ToString().Length>20?Eval("title").ToString().Substring(20)+"..." :Eval("title").ToString()%></span> <a href="NewsMain.aspx"><%# Eval("brief").ToString().Length>50?Eval("brief").ToString().Substring(50)+"...":Eval("brief").ToString() %></a></p>
                                </div>
                            </li>

                        </ItemTemplate>

                    </asp:Repeater>

                    <!--TOP第一則最新消息-->
                   
                    <!--TOP第一則最新消息結束-->

                    <!--第二則-->
                   
                    <!--第二則結束-->

                    
                </ul>
            </div>
            <!--------------------------------最新消息結束---------------------------------------------------->



            <!--------------------------------落款開始---------------------------------------------------->
            <div class="footer">

                <div class="footerp00">
                    <a href="#">
                        <img src="tayana/images/tog.jpg" alt="&quot;&quot;" /></a>
                    <p class="footerp001">© 1973-2011 Tayana Yachts, Inc. All Rights Reserved</p>
                </div>
                <div class="footer01">
                    <span>No. 60, Hai Chien Road, Chung Men Li, Lin Yuan District, Kaohsiung City, Taiwan, R.O.C.</span><br />
                    <span>TEL：+886(7)641-2721</span> <span>FAX：+886(7)642-3193</span><span><a href="mailto:tayangco@ms15.hinet.net">E-mail：tayangco@ms15.hinet.net</a>.</span>
                </div>
            </div>
            <!--------------------------------落款結束---------------------------------------------------->

        </div>


    </form>
</body>
</html>
