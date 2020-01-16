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
    public partial class AddDealers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Country();

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


            ListItem item = new ListItem("請選擇國家", "");
            DropDownList1.Items.Insert(0, item);


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = File.ReadAllText(HttpContext.Current.Server.MapPath("/sys/AddDealers.sql"));
            string get = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["ProjectConnection"].ConnectionString;
            SqlConnection getConnection = new SqlConnection(get);
            SqlCommand command = new SqlCommand(sql, getConnection);

            //新增封面照

            string filePhotoName = "";
            int i = 0;
            //List<string> photoList = new List<string>();
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentType.IndexOf("image") == -1)
                {
                    Message.Text = "檔案型態錯誤!";
                    return;
                }


                string[] fileNames = FileUpload1.FileName.Split('.');
                string Extension = fileNames[fileNames.Length - 1];
                filePhotoName = String.Format("{0:yyyyMMddhhmmsss}{1}.{2}", DateTime.Now, i, Extension);
                FileUpload1.SaveAs(Server.MapPath(String.Format("~/sys/uploadfile/dealers_photo/{0}", filePhotoName)));



                command.Parameters.Add("@photo", SqlDbType.NVarChar);
                command.Parameters["@photo"].Value = filePhotoName;


                command.Parameters.Add("@main", SqlDbType.NVarChar);
                command.Parameters["@main"].Value = AddMain.Value;
                command.Parameters.Add("@name", SqlDbType.NVarChar);
                command.Parameters["@name"].Value = AddDealer.Text;
                command.Parameters.Add("@cid", SqlDbType.Int);
                command.Parameters["@cid"].Value = DropDownList1.SelectedValue;


                getConnection.Open();

                command.ExecuteNonQuery();
                getConnection.Close();

                Response.Redirect("Dealers.aspx");


            }
        }
    }
}