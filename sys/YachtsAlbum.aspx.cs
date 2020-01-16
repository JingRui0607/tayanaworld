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
    public partial class YachtsAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                string config = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["ProjectConnection"].ConnectionString;
                SqlConnection rconnection = new SqlConnection(config);
                SqlCommand Rcommand = new SqlCommand($"Select * FROM YachtsAlbum where(YachtsID =@id) ORDER BY MainPhoto DESC", rconnection);
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
            string Psql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/Addphotos.sql"));
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
                    postedFile.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/Yachts_Photo/{0}",
                        filePhotoName)));




                    //photoList.Add($"{filePhotoName}");

                    command1.Parameters.Add("@Photos", SqlDbType.NVarChar);
                    command1.Parameters["@Photos"].Value = filePhotoName;
                    command1.Parameters.Add("@Uid", SqlDbType.Int);
                    command1.Parameters["@Uid"].Value = Request.QueryString["id"];
                    command1.Parameters.Add("@MainPhoto", SqlDbType.Bit);
                    command1.Parameters["@MainPhoto"].Value = 0;


                    getConnection1.Open();
                    command1.ExecuteNonQuery();
                    getConnection1.Close();
                    i++;
                }
            }
            Response.Redirect("YachtsAlbum.aspx?id=" + Request.QueryString["id"]);

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/DeletePhoto.sql"));
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
            Response.Redirect("YachtsAlbum.aspx?id=" + Request.QueryString["id"]);

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string get = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);


            switch (e.CommandName)
            {

                case "mainPhoto":
                    {

                        string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/IsMainPhoto.sql"));
                        Button BTN = (Button)e.CommandSource;    //先抓到這個按鈕（我們設定了CommandName）
                        GridViewRow myRow = (GridViewRow)BTN.NamingContainer;
                        string id = GridView1.DataKeys[myRow.RowIndex].Value.ToString();//抓取ID


                        SqlCommand command = new SqlCommand(sql, getConnection);

                        command.Parameters.Add("@id", SqlDbType.Int);

                        command.Parameters["@id"].Value = Convert.ToInt32(id);
                        command.Parameters.Add("@Yid", SqlDbType.Int);

                        command.Parameters["@Yid"].Value = Request.QueryString["id"];

                        getConnection.Open();

                        command.ExecuteNonQuery();

                        getConnection.Close();

                        break;

                    }

               
            }

            Response.Redirect("YachtsAlbum.aspx?id=" + Request.QueryString["id"]);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("YachtsInformation.aspx");
        }
    }
}