using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TayanaProject.sys
{
    public partial class YachtsAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //新增主表
            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/YachtsAdd.sql"));
            string get = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command = new SqlCommand(sql, getConnection);

           

            command.Parameters.Add("@YachtsType", SqlDbType.NVarChar);
            command.Parameters["@YachtsType"].Value = AddName.Text;
            command.Parameters.Add("@Overview", SqlDbType.NVarChar);
            command.Parameters["@Overview"].Value = AddOverview.Value;

            command.Parameters.Add("@Dimensions", SqlDbType.NVarChar);
            command.Parameters["@Dimensions"].Value = AddDimensions.Value;

            command.Parameters.Add("@Specifications", SqlDbType.NVarChar);
            command.Parameters["@Specifications"].Value = AddSpecification.Value;

           
            command.Parameters.Add("@NewYachts", SqlDbType.Bit);
            if (CheckBox1.Checked)
            {
                command.Parameters["@NewYachts"].Value = 1;
            }
            if(!CheckBox1.Checked)

            {
                command.Parameters["@NewYachts"].Value = 0;
            }



            getConnection.Open();
            int uid = Convert.ToInt32(command.ExecuteScalar());
            getConnection.Close();


            //新增下載
            string Dsql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/AddDownload.sql"));
       
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
                    postedFile.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/Yachts_DownLoad/{0}", DownloadName)));

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

           


            //新增照片

            string Psql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/Addphotos.sql"));
            string getphoto = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection1 = new SqlConnection(getphoto);
          

            string filePhotoName="";
            int i = 0;
            List<string> photoList = new List<string>();
            if (FilePhotoUpload1.HasFile)
            {
                if (FilePhotoUpload1.PostedFile.ContentType.IndexOf("image") == -1)
                {
                    Message.Text = "檔案型態錯誤!";
                    return;
                }
                foreach (var postedFile in FilePhotoUpload1.PostedFiles)
                {
                    SqlCommand command1 = new SqlCommand(Psql, getConnection1);
                    string[] fileNames = postedFile.FileName.Split('.');
                    string Extension = fileNames[fileNames.Length - 1];
                    filePhotoName = String.Format("{0:yyyyMMddhhmmsss}{1}.{2}", DateTime.Now,i, Extension);
                    postedFile.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/Yachts_Photo/{0}", filePhotoName)));

                    ChangeImageSize(filePhotoName, Server.MapPath(String.Format("~/sys/uploadfile/Yachts_Photo/")), 63);



                    //photoList.Add($"{filePhotoName}");

                    command1.Parameters.Add("@Photos", SqlDbType.NVarChar);
                    command1.Parameters["@Photos"].Value = filePhotoName;
                    command1.Parameters.Add("@Uid", SqlDbType.Int);
                    command1.Parameters["@Uid"].Value = uid;
                   

                    getConnection1.Open();
                    command1.ExecuteNonQuery();
                    getConnection1.Close();
                    i++;
                }
            }
            //新增Layout


            string LaySql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/AddLayout.sql"));
            string getLay = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection LayConnection1 = new SqlConnection(getLay);


            string fileLayName = "";
            int s = 0;
           
            if (FileLayoutUpload1.HasFile)
            {
                if (FileLayoutUpload1.PostedFile.ContentType.IndexOf("image") == -1)
                {
                    Message1.Text = "檔案型態錯誤!";
                    return;
                }
                foreach (var postedFile in FileLayoutUpload1.PostedFiles)
                {
                    SqlCommand command2 = new SqlCommand(LaySql, LayConnection1);
                    string[] fileNames = postedFile.FileName.Split('.');
                    string Extension = fileNames[fileNames.Length - 1];
                    fileLayName = String.Format("{0:yyyyMMddhhmmsss}{1}.{2}", DateTime.Now, s, Extension);
                    postedFile.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/Yachts_Layout/{0}", fileLayName)));


                    






                    //photoList.Add($"{filePhotoName}");

                    command2.Parameters.Add("@Photo", SqlDbType.NVarChar);
                    command2.Parameters["@Photo"].Value = fileLayName;
                    command2.Parameters.Add("@Yid", SqlDbType.Int);
                    command2.Parameters["@Yid"].Value = uid;


                    LayConnection1.Open();
                    command2.ExecuteNonQuery();
                    LayConnection1.Close();
                    s++;
                }
            }





            Response.Redirect("YachtsInformation.aspx");



        }
        protected void ChangeImageSize(string FileName, string FilePath, int SmallHeight)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(FilePath + FileName);
            //絕對路徑，http://wangshifuola.blogspot.com/2011/10/aspnetimage-resize.html
            System.Drawing.Imaging.ImageFormat ThisFormat = img.RawFormat;
           
            int FixHeight = SmallHeight;
            int FixWidth = FixHeight * img.Width / img.Height;
            Bitmap ImgOutput = new Bitmap(img, FixWidth, FixHeight);
            ImgOutput.Save(FilePath + "s" + FileName, ThisFormat);
            img.Dispose();
            ImgOutput.Dispose();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("YachtsInformation.aspx");
        }
    }
}