using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TayanaProject.sys
{
    /// <summary>
    /// checkusername 的摘要描述
    /// </summary>
    public class checkusername : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain"; //回傳的是文字所以用這行;ORID用Json

            string qqq = context.Request.QueryString["username"];

            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command =
                new SqlCommand($"select * from [UserInformation] where username=@userid  ", getConnection);
            command.Parameters.Add("@userid", SqlDbType.NVarChar);
            command.Parameters["@userid"].Value = qqq;
            SqlDataAdapter loginAdapter = new SqlDataAdapter(command);

            DataTable user = new DataTable();

            loginAdapter.Fill(user);

            if (user.Rows.Count > 0)
            {
                context.Response.Write("此帳號已經存在了");
            }

            else
            {
                context.Response.Write("這個帳號可以使用");
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}