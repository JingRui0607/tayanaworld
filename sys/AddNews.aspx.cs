using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TayanaProject.sys
{
    public partial class AddNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/AddNews.sql"));
            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command = new SqlCommand(sql, getConnection);



            //新增封面照

            string filePhotoName = "";
            int i = 0;
            //List<string> photoList = new List<string>();
            if (FilePhotoUpload1.HasFile)
            {
                if (FilePhotoUpload1.PostedFile.ContentType.IndexOf("image") == -1)
                {
                    Message.Text = "檔案型態錯誤!";
                    return;
                }


                string[] fileNames = FilePhotoUpload1.FileName.Split('.');
                string Extension = fileNames[fileNames.Length - 1];
                filePhotoName = String.Format("{0:yyyyMMddhhmmsss}{1}.{2}", DateTime.Now, i, Extension);
                FilePhotoUpload1.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/Yachts_News/{0}", filePhotoName)));



                command.Parameters.Add("@mainphoto", SqlDbType.NVarChar);
                command.Parameters["@mainphoto"].Value = filePhotoName;
             




            }
            else
            {
                command.Parameters.Add("@mainphoto", SqlDbType.NVarChar);
                command.Parameters["@mainphoto"].Value = filePhotoName;

            }

            //新增其他最新消息內容
            command.Parameters.Add("@date", SqlDbType.DateTime);

            if (string.IsNullOrEmpty(timeStart.Value))
                command.Parameters["@date"].Value = DBNull.Value;
            else
            command.Parameters["@date"].Value = timeStart.Value;

            command.Parameters.Add("@title", SqlDbType.NVarChar);
            command.Parameters["@title"].Value = Addtitle.Text;
            command.Parameters.Add("@main", SqlDbType.NVarChar);
            command.Parameters["@main"].Value = Addmain.Value;
            command.Parameters.Add("@brief", SqlDbType.NVarChar);
            command.Parameters["@brief"].Value = Addbrief.Text;
           


            command.Parameters.Add("@Istop", SqlDbType.Bit);
            if (CheckBox1.Checked)
            {
                command.Parameters["@Istop"].Value = 1;
            }
            if (!CheckBox1.Checked)

            {
                command.Parameters["@Istop"].Value = 0;
            }



            getConnection.Open();

            int uid = Convert.ToInt32(command.ExecuteScalar());//回傳id
            getConnection.Close();



            //新增下載檔案



            string Dsql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/AddNewsDownload.sql"));

            SqlConnection ConnectionDownload = new SqlConnection(get);



            string DownloadName = "";
            int a = 0;
            if (AddDownUpload1.HasFile)
            {
                foreach (var postedFile in AddDownUpload1.PostedFiles)
                {
                    SqlCommand commandDownload = new SqlCommand(Dsql, ConnectionDownload);
                    string[] files = postedFile.FileName.Split('.');
                    //取得副檔名
                    string Extension = files[files.Length - 1];
                    //新檔案名稱
                    DownloadName = String.Format("{0:yyyyMMddhhmmsss}{1}.{2}", DateTime.Now, a, Extension);
                    //上傳目錄為/upload/Images/
                    postedFile.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/News_download/{0}", DownloadName)));

                    commandDownload.Parameters.Add("@Download", SqlDbType.NVarChar);
                    commandDownload.Parameters["@Download"].Value = DownloadName;

                    commandDownload.Parameters.Add("@Uid", SqlDbType.Int);
                    commandDownload.Parameters["@Uid"].Value = uid;


                    ConnectionDownload.Open();
                    commandDownload.ExecuteNonQuery();
                    ConnectionDownload.Close();
                    a -= -1;// a++ XD


                }


            }





            Response.Redirect("NewsIndex.aspx");



        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsIndex.aspx");

        }
    }
}