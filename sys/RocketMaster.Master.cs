using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using TayanaProject.sys;

namespace TayanaProject.sys
{
    public partial class RocketMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!HttpContext.Current.User.Identity.IsAuthenticated)//現在是否登入,假如沒有就跳回Login頁面
            {
                Response.Redirect("Login.aspx");

            }
            //取得UserData ,將UserData反序列化成物件才能控制
            string strUserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;

            UserInformation Myperson = JsonConvert.DeserializeObject<UserInformation>(strUserData);

            ShowUserName.InnerText = HttpContext.Current.User.Identity.Name;//顯示名字
           hiih.Src= "/sys/uploadfile/User_Photo/" + Myperson.photo;//顯示大頭貼

           
            //photo2.Src = "/uploadfile/" + Myperson.photo;//顯示大頭貼


            StringBuilder sb = new StringBuilder();//假如遇到字串需要一直累加(+=)最好使用StringBuilder
            if (Myperson.permission.IndexOf("001") > -1)
            {
                sb.Append(@" <li class='active'>
                    <a href ='/sys/user.aspx'>
                    <i class='nc-icon nc-single-02'></i>
                    <p>User Information</p>
                    </a>
                    </li>");



            }

            if (Myperson.permission.IndexOf("002") > -1)
            {
                sb.Append(@" <li class='active'>
                    <a href ='/sys/YachtsInformation.aspx'>
                    <i class='nc-icon nc-tile-56'></i>
                    <p>Yachts</p>
                    </a>
                    </li>");


            }
            if (Myperson.permission.IndexOf("003") > -1)
            {
                sb.Append(@" <li class='active'>
                    <a href ='/sys/NewsIndex.aspx'>
                    <i class='nc-icon nc-tile-56'></i>
                    <p>News</p>
                    </a>
                    </li>");


            }
            if (Myperson.permission.IndexOf("004") > -1)
            {
                sb.Append(@" <li class='active'>
                    <a href ='/sys/Dealers.aspx'>
                    <i class='nc-icon nc-tile-56'></i>
                    <p>Dealers</p>
                    </a>
                    </li>");


            }
            if (Myperson.permission.IndexOf("005") > -1)
            {
                sb.Append(@" <li class='active'>
                    <a href ='/Index.aspx'>
                    <i class='nc-icon nc-tile-56'></i>
                    <p>前台</p>
                    </a>
                    </li>");


            }


            PermissionLiteral.Text = sb.ToString();



        }
    }
}