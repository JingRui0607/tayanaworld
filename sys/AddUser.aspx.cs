using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TayanaProject.sys
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {



            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/AddUser.sql"));
            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);


            string password =
                FormsAuthentication.HashPasswordForStoringInConfigFile(Addpassword.Text, "MD5"); //做md5轉換



            string fileName;
            if (AddFileUpload.HasFile)
            {
                if (AddFileUpload.PostedFile.ContentType.IndexOf("image") == -1)
                {
                    Message.Text = "檔案型態錯誤!";
                    return;
                }

                string[] files = AddFileUpload.FileName.Split('.');
                //取得副檔名
                string Extension = files[files.Length - 1];
                //新檔案名稱
                fileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);
                //上傳目錄為/upload/Images/
                AddFileUpload.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/User_Photo/{0}", fileName)));

            }
            else
            {
                Message.Text = "沒有上傳檔案";
                return;
            }


            string permission = ",";

            foreach (ListItem item in Addpermission.Items)
            {
                if (item.Selected == true)
                {

                    permission += (item.Value + ",");
                }
            }









            SqlCommand command = new SqlCommand(sql, getConnection);


            command.Parameters.Add("@name", SqlDbType.NVarChar);
            command.Parameters["@name"].Value = Addname.Text;
            command.Parameters.Add("@username", SqlDbType.NVarChar);
            command.Parameters["@username"].Value = Addusername.Text;
            command.Parameters.Add("@password", SqlDbType.NVarChar);
            command.Parameters["@password"].Value = password;
            command.Parameters.Add("@mail", SqlDbType.NVarChar);
            command.Parameters["@mail"].Value = Addmail.Text;
            command.Parameters.Add("@photo", SqlDbType.NVarChar);
            command.Parameters["@photo"].Value = fileName;
            command.Parameters.Add("@permission", SqlDbType.NVarChar);
            command.Parameters["@permission"].Value = permission;


            getConnection.Open();
            command.ExecuteNonQuery();
            getConnection.Close();



            Response.Redirect("user.aspx");
        }
    }
}