using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace TayanaProject.sys
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //密碼轉換成MD5碼
            string password = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd.Value, "MD5");
            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command = new SqlCommand($"select * from [UserInformation] where username=@userid and password = @password  ", getConnection);
            command.Parameters.Add("@userid", SqlDbType.NVarChar);
            command.Parameters["@userid"].Value = username.Value;
            command.Parameters.Add("@password", SqlDbType.NVarChar);
            command.Parameters["@password"].Value = password;

            SqlDataAdapter loginAdapter = new SqlDataAdapter(command);

            DataTable user = new DataTable();

            loginAdapter.Fill(user);

            if (user.Rows.Count>0)
            {

                UserInformation Userinformation = new UserInformation();
                Userinformation.username = user.Rows[0]["username"].ToString();
                Userinformation.name = user.Rows[0]["name"].ToString();
                Userinformation.mail = user.Rows[0]["mail"].ToString();
                Userinformation.permission = user.Rows[0]["permission"].ToString();
                Userinformation.photo = user.Rows[0]["photo"].ToString();

                string userData = JsonConvert.SerializeObject(Userinformation);//將物件序列化成字串才能存入cookie

                SetAuthenTicket(userData, username.Value);//呼叫副程式SetAuthenTicket 創立一張門票跟存入Cookie
                Response.Redirect("user.aspx");


            }
            else
            {
                Label1.Text = "登入失敗";
            }


        }

        void SetAuthenTicket(string userData, string userId)
        {
            //宣告一個驗證票
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userId, DateTime.Now, DateTime.Now.AddHours(2), false, userData);
            //加密驗證票
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            //建立Cookie
            HttpCookie authenticationcookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            authenticationcookie.Expires = DateTime.Now.AddHours(2);
            //將Cookie寫入回應
            Response.Cookies.Add(authenticationcookie);
        }
    }
}