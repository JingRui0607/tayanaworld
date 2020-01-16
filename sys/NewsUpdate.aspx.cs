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
    public partial class NewsUpdate : System.Web.UI.Page
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
                    $"SELECT   title, main, brief, Newstop, mainphoto ,NewsDate FROM     YachtsNews  Where (id=@id) ",
                    getConnection);
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = Request["id"];

            SqlDataAdapter loginAdapter = new SqlDataAdapter(command);
            DataTable user = new DataTable();
            loginAdapter.Fill(user);

            UpdateTime.Value= Convert.ToDateTime(user.Rows[0]["NewsDate"]).ToString("yyyy-MM-dd");
            
            Updatetitle.Text = HttpUtility.HtmlDecode(user.Rows[0]["title"].ToString());
            UpdateMain.Value = HttpUtility.HtmlDecode(user.Rows[0]["main"].ToString());
            Updatebrief.Text = HttpUtility.HtmlDecode(user.Rows[0]["brief"].ToString());

            PhotoHyperLink1.Text = user.Rows[0]["mainphoto"].ToString();
            PhotoHyperLink1.NavigateUrl = "/sys/uploadfile/Yachts_News/" + user.Rows[0]["mainphoto"];
            PhotoHiddenField2.Value = user.Rows[0]["mainphoto"].ToString();

        }

        

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/UpdateNews.sql"));

            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command = new SqlCommand(sql, getConnection);

            string fileName;
            if (PhotoFileUpload1.HasFile)
            {

                //取得副檔名
                string Extension = PhotoFileUpload1.FileName.Split('.')[PhotoFileUpload1.FileName.Split('.').Length - 1];
                //新檔案名稱
                fileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);
                //上傳目錄為/upload/Images/
                PhotoFileUpload1.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/Yachts_News/{0}", fileName)));

            }
            else


            {

                if (PhotoHiddenField2.Value != "")
                {
                    fileName = PhotoHiddenField2.Value;
                }
                else
                {
                    PhotoMessage.Text = "沒有上傳檔案";
                    return;
                }
            }
            command.Parameters.Add("@date", SqlDbType.DateTime);

            if (string.IsNullOrEmpty(UpdateTime.Value))
                command.Parameters["@date"].Value = DBNull.Value;
            else
                command.Parameters["@date"].Value = UpdateTime.Value;


            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = Request.QueryString["id"];
            command.Parameters.Add("@title", SqlDbType.NVarChar);
            command.Parameters["@title"].Value = Updatetitle.Text;
            command.Parameters.Add("@main", SqlDbType.NVarChar);
            command.Parameters["@main"].Value = UpdateMain.Value;
            command.Parameters.Add("@brief", SqlDbType.NVarChar);
            command.Parameters["@brief"].Value = Updatebrief.Text;

            command.Parameters.Add("@photo", SqlDbType.NVarChar);
            command.Parameters["@photo"].Value = fileName;

            getConnection.Open();
            command.ExecuteNonQuery();
            getConnection.Close();
            Response.Redirect("NewsIndex.aspx?page="+Request.QueryString["page"]);
        }
    }
}