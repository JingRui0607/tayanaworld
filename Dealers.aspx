<%@ Page Title="" Language="C#" MasterPageFile="~/Tayana.Master" AutoEventWireup="true" CodeBehind="Dealers.aspx.cs" Inherits="TayanaProject.Dealers" %>

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
            <p><span>DEALERS</span></p>
            <ul>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <li>

                            <a href='<%# "Dealers.aspx?id="+ Eval("id") %>'><%# Eval("Country") %> </a>

                        </li>
                    </ItemTemplate>

                </asp:Repeater>





            </ul>



        </div>




    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentRight" runat="server">
    <div id="crumb"><a href="#">Home</a> >> <a href="#">Dealers </a>>> <a href="#"><span  runat="server" id="rightCountryName2" class="on1"></span></a></div>
    <div class="right">
        <div class="right1">
            <div class="title"><span id="rightCountryName" runat="server"></span></div>

            <div class="box2_list">
                <ul>



                    <asp:Repeater ID="Repeater_Main" runat="server">


                        <ItemTemplate>


                            <li>
                                <div class="list02">
                                    <ul>
                                        <li class="list02li">
                                            <div>
                                                <p>
                                                    <img style="object-fit: contain ;max-width:209px;" src='<%# "sys/uploadfile/dealers_photo/"+ Eval("photo") %>' />>
                                                </p>
                                            </div>
                                        </li>
                                        <li><span> <%# Eval("DealersName") %></span><br />
                                          
                                            <%# Eval("main") %>

                                        </li>
                                    </ul>
                                </div>
                            </li>


                        </ItemTemplate>


                    </asp:Repeater>








                </ul>

                <uc1:userpagination runat="server" id="UserPagination" />


            </div>

            <!--------------------------------內容結束------------------------------------------------------>
        </div>
    </div>




</asp:Content>
