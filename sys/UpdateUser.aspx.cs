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
    public partial class UpdateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showdata();
            }

        }

        public void showdata()
        {
            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command =
                new SqlCommand(
                    $"SELECT   name, password, mail,photo,permission FROM     UserInformation  Where (id=@id) ",
                    getConnection);


            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = Request.QueryString["id"];

            SqlDataAdapter loginAdapter = new SqlDataAdapter(command);
            DataTable user = new DataTable();
            loginAdapter.Fill(user);

            Updatename.Text = user.Rows[0]["name"].ToString();
            HiddenField1.Value = user.Rows[0]["password"].ToString(); //隱藏欄位
            Updatemail.Text = user.Rows[0]["mail"].ToString();
            Image1.ImageUrl = "/sys/uploadfile/" + user.Rows[0]["photo"].ToString();
            PhotoHiddenField2.Value = user.Rows[0]["photo"].ToString();
            //string[] qq = user.Rows[0]["permission"].ToString().Split(',');

            for (int i = 0; i < Updatepermission.Items.Count; i++)
            {
                if (user.Rows[0]["permission"].ToString().IndexOf("," + Updatepermission.Items[i].Value + ",") > -1)//indexof就是在陣列中尋找()內的字串,並回傳第幾個陣列
                {
                    Updatepermission.Items[i].Selected = true;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/UpdateUser.sql"));

            //將更新的新密碼加密
            string str_password = FormsAuthentication.HashPasswordForStoringInConfigFile(Updatepassword.Text, "MD5");

            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command = new SqlCommand(sql, getConnection);


            string fileName;
            if (FileUpload.HasFile)
            {
                if (FileUpload.PostedFile.ContentType.IndexOf("image") == -1)
                {
                    Message.Text = "檔案型態錯誤!";
                    return;
                }
                //取得副檔名
                string Extension = FileUpload.FileName.Split('.')[FileUpload.FileName.Split('.').Length - 1];
                //新檔案名稱
                fileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);
                //上傳目錄為/upload/Images/
                FileUpload.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/User_Photo/{0}", fileName)));

            }
            else


            {

                if (PhotoHiddenField2.Value != "")
                {
                    fileName = PhotoHiddenField2.Value;

                }
                else
                {
                    Message.Text = "沒有上傳檔案";
                    return;
                }
            }


            string permission = ",";

            foreach (ListItem item in Updatepermission.Items)
            {
                if (item.Selected == true)
                {

                    permission += (item.Value + ",");
                }
            }


            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = Request.QueryString["id"];
            command.Parameters.Add("@name", SqlDbType.NVarChar);
            command.Parameters["@name"].Value = Updatename.Text;
            if (string.IsNullOrEmpty(Updaterepassword.Text) )
            {
                command.Parameters.Add("@password", SqlDbType.NVarChar);
                command.Parameters["@password"].Value = HiddenField1.Value;
            }
            else
            {
                command.Parameters.Add("@password", SqlDbType.NVarChar);
                command.Parameters["@password"].Value = str_password;
            }
            command.Parameters.Add("@mail", SqlDbType.NVarChar);
            command.Parameters["@mail"].Value = Updatemail.Text;

            command.Parameters.Add("@photo", SqlDbType.NVarChar);
            command.Parameters["@photo"].Value = fileName;
            command.Parameters.Add("@permission", SqlDbType.NVarChar);
            command.Parameters["@permission"].Value = permission;

            getConnection.Open();
            command.ExecuteNonQuery();
            getConnection.Close();
            Response.Redirect("user.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("user.aspx?Page=" + Request.QueryString["Page"]);
        }
    }
}