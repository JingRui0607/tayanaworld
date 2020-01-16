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
    public partial class UpdateDealers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Country();
                showdata();
            }


        }
        public void Country()
        {
            //從資料庫取得姓名放進控制項當名字
            string config = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection Connection = new SqlConnection(config);
            SqlCommand command1 = new SqlCommand("select id,name from Country", Connection);
            SqlDataAdapter loginAdapter1 = new SqlDataAdapter(command1);
            DataTable user1 = new DataTable();

            loginAdapter1.Fill(user1);

            DropDownList1.DataSource = user1;
            DropDownList1.DataValueField = "id";
            DropDownList1.DataTextField = "name";


            DropDownList1.DataBind();


            //ListItem item = new ListItem("請選擇國家", "");
            //DropDownList1.Items.Insert(0, item);


        }
        public void showdata()
        {

            string get = System.Web.Configuration.WebConfigurationManager
               .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command =
                new SqlCommand(
                    $"SELECT    id,DealersName,main,photo,initdate ,Cid FROM     Dealers  Where (id=@id) ",
                    getConnection);
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = Request["id"];

            SqlDataAdapter loginAdapter = new SqlDataAdapter(command);
            DataTable user = new DataTable();
            loginAdapter.Fill(user);

            UpdateDealers1.Text = user.Rows[0]["DealersName"].ToString();
            UpdateMain.Value = HttpUtility.HtmlDecode(user.Rows[0]["main"].ToString());
            
            
            DownLoadHyperLink1.Text = user.Rows[0]["photo"].ToString();
            DownLoadHyperLink1.NavigateUrl = "/sys/uploadfile/dealers_photo/" + user.Rows[0]["photo"];
            DownLoadHiddenField2.Value = user.Rows[0]["photo"].ToString();
            DropDownList1.SelectedValue = user.Rows[0]["Cid"].ToString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/UpdateDealers.sql"));

            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command = new SqlCommand(sql, getConnection);

            string fileName;
            if (DownLoadFileUpload1.HasFile)
            {

                //取得副檔名
                string Extension = DownLoadFileUpload1.FileName.Split('.')[DownLoadFileUpload1.FileName.Split('.').Length - 1];
                //新檔案名稱
                fileName = String.Format("{0:yyyyMMddhhmmsss}.{1}", DateTime.Now, Extension);
                //上傳目錄為/upload/Images/
                DownLoadFileUpload1.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/dealers_photo/{0}", fileName)));

            }
            else


            {

                if (DownLoadHiddenField2.Value != "")
                {
                    fileName = DownLoadHiddenField2.Value;
                }
                else
                {
                    DownLoadMessage.Text = "沒有上傳檔案";
                    return;
                }
            }

            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = Request.QueryString["id"];

            command.Parameters.Add("@name", SqlDbType.NVarChar);
            command.Parameters["@name"].Value = UpdateDealers1.Text;
            command.Parameters.Add("@main", SqlDbType.NVarChar);
            command.Parameters["@main"].Value = UpdateMain.Value;
            command.Parameters.Add("@cid", SqlDbType.Int);
            command.Parameters["@cid"].Value = DropDownList1.SelectedValue;
           
            command.Parameters.Add("@photo", SqlDbType.NVarChar);
            command.Parameters["@photo"].Value = fileName;

            getConnection.Open();
            command.ExecuteNonQuery();
            getConnection.Close();
            Response.Redirect("Dealers.aspx");


        }
    }
}