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
    public partial class YachtsLayout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string config = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["ProjectConnection"].ConnectionString;
                SqlConnection rconnection = new SqlConnection(config);
                SqlCommand Rcommand = new SqlCommand($"Select * FROM YachtsLayout where(Yid =@id) ", rconnection);
                Rcommand.Parameters.Add("@id", SqlDbType.NVarChar); //設定參數資料型態
                Rcommand.Parameters["@id"].Value = Request.QueryString["id"]; //接id的值變成參數的值
                rconnection.Open();

                SqlDataReader rereader = Rcommand.ExecuteReader();
                GridView1.DataSource = rereader;//repeater的資料來源是從rereader來
                GridView1.DataBind();//執行繫結



            }


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string Psql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/AddLayout.sql"));
            string getphoto = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection1 = new SqlConnection(getphoto);


            string filePhotoName = "";
            int i = 0;

            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentType.IndexOf("image") == -1)
                {
                    Message.Text = "檔案型態錯誤!";
                    return;
                }

                foreach (var postedFile in FileUpload1.PostedFiles)
                {
                    SqlCommand command1 = new SqlCommand(Psql, getConnection1);
                    string[] fileNames = postedFile.FileName.Split('.');
                    string Extension = fileNames[fileNames.Length - 1];
                    filePhotoName = String.Format("{0:yyyyMMddhhmmsss}{1}.{2}", DateTime.Now, i, Extension);
                    postedFile.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/Yachts_Layout/{0}",
                        filePhotoName)));




                    //photoList.Add($"{filePhotoName}");

                    command1.Parameters.Add("@Photo", SqlDbType.NVarChar);
                    command1.Parameters["@Photo"].Value = filePhotoName;
                    command1.Parameters.Add("@Yid", SqlDbType.Int);
                    command1.Parameters["@Yid"].Value = Request.QueryString["id"];



                    getConnection1.Open();
                    command1.ExecuteNonQuery();
                    getConnection1.Close();
                    i++;
                }
            }
            Response.Redirect("YachtsLayout.aspx?id=" + Request.QueryString["id"]);

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/DeleteLayout.sql"));
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();//抓第幾行要被動作
            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command = new SqlCommand(sql, getConnection);

            command.Parameters.Add("@id", SqlDbType.NVarChar);
            command.Parameters["@id"].Value = id;
            getConnection.Open();
            command.ExecuteNonQuery();
            getConnection.Close();
            Response.Redirect("YachtsLayout.aspx?id=" + Request.QueryString["id"]);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("YachtsInformation.apsx");
        }
    }
}
