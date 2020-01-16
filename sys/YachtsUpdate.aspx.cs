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
    public partial class YachtsUpdate : System.Web.UI.Page
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
                    $"SELECT    YachtsType, Overview, Dimensions, Specifications, Downloads, MainPhoto FROM     YachtsType  Where (id=@id) ",
                    getConnection);
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = Request["id"];

            SqlDataAdapter loginAdapter = new SqlDataAdapter(command);
            DataTable user = new DataTable();
            loginAdapter.Fill(user);

            UpdateName.Text =  user.Rows[0]["YachtsType"].ToString();
            UpdateOverview.Value= HttpUtility.HtmlDecode(user.Rows[0]["Overview"].ToString());

            UpdateDimensions.Value = HttpUtility.HtmlDecode(user.Rows[0]["Dimensions"].ToString());

            UpdateSpecification.Value = HttpUtility.HtmlDecode(user.Rows[0]["Specifications"].ToString());
            DownLoadHyperLink1.Text = user.Rows[0]["Downloads"].ToString();
            DownLoadHyperLink1.NavigateUrl = "/sys/uploadfile/Yachts_DownLoad/"+ user.Rows[0]["Downloads"];
            DownLoadHiddenField2.Value = user.Rows[0]["Downloads"].ToString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/YachtsUpdate.sql"));

            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command = new SqlCommand(sql, getConnection);

            string fileName="";
            if (DownLoadFileUpload1.HasFile)
            {
                
                //取得副檔名
                string Extension = DownLoadFileUpload1.FileName.Split('.')[DownLoadFileUpload1.FileName.Split('.').Length - 1];
                //新檔案名稱
                fileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);
                //上傳目錄為/upload/Images/
                DownLoadFileUpload1.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/Yachts_DownLoad/{0}", fileName)));

            }
            else


            {

                if (DownLoadHiddenField2.Value != "")
                {
                    fileName = DownLoadHiddenField2.Value;
                }
                //else
                //{
                //    DownLoadMessage.Text = "沒有上傳檔案";
                //    return;
                //}
            }

            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = Request.QueryString["id"];
            command.Parameters.Add("@YachtsType", SqlDbType.NVarChar);
            command.Parameters["@YachtsType"].Value = UpdateName.Text;
            command.Parameters.Add("@Overview", SqlDbType.NVarChar);
            command.Parameters["@Overview"].Value = UpdateOverview.Value;

            command.Parameters.Add("@Dimensions", SqlDbType.NVarChar);
            command.Parameters["@Dimensions"].Value = UpdateDimensions.Value;

            command.Parameters.Add("@Specifications", SqlDbType.NVarChar);
            command.Parameters["@Specifications"].Value = UpdateSpecification.Value;
            command.Parameters.Add("@Downloads", SqlDbType.NVarChar);
            command.Parameters["@Downloads"].Value = fileName;

            getConnection.Open();
            command.ExecuteNonQuery();
            getConnection.Close();
            Response.Redirect("YachtsInformation.aspx?page=" + Request.QueryString["Page"]);





        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("YachtsInformation.aspx");
        }
    }
}