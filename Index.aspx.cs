using System;
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


namespace TayanaProject
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                topphoto();
                sphoto();
                News();

            }

        }
        public void topphoto()
        {
            string config = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["ProjectConnection"].ConnectionString;
           
           

            SqlConnection rconnection = new SqlConnection(config);


            SqlCommand Rcommand = new SqlCommand($"Select Photos ,(select  YachtsType from YachtsType where id= YachtsAlbum.YachtsID ) as YachtsType , (select  NewYachts from YachtsType where id= YachtsAlbum.YachtsID ) as  NewYachts FROM YachtsAlbum where MainPhoto=1  ", rconnection);

        


            rconnection.Open();
            SqlDataReader rereader = Rcommand.ExecuteReader();

            Repeater3.DataSource = rereader;//repeater的資料來源是從rereader來
            Repeater3.DataBind();//執行繫結
          
            rconnection.Close();

        }
        public void sphoto()
        {
            string config = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["ProjectConnection"].ConnectionString;



            SqlConnection rconnection = new SqlConnection(config);


            SqlCommand Rcommand = new SqlCommand($"Select Photos ,(select  YachtsType from YachtsType where id= YachtsAlbum.YachtsID ) as YachtsType , (select  NewYachts from YachtsType where id= YachtsAlbum.YachtsID ) as  NewYachts FROM YachtsAlbum where MainPhoto=1  ", rconnection);




            rconnection.Open();
            SqlDataReader rereader = Rcommand.ExecuteReader();

           
            Repeater1.DataSource = rereader;//repeater的資料來源是從rereader來
            Repeater1.DataBind();//執行繫結
            rconnection.Close();

        }
        public void News()
        {
            string config = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["ProjectConnection"].ConnectionString;



            SqlConnection rconnection = new SqlConnection(config);


            SqlCommand Rcommand = new SqlCommand($"SELECT   TOP (3) id, Newstop, mainphoto, title, main, brief, download, initdate, NewsDate FROM     YachtsNews ORDER BY Newstop DESC, initdate DESC  ", rconnection);




            rconnection.Open();
            SqlDataReader rereader = Rcommand.ExecuteReader();

            Repeater2.DataSource = rereader;//repeater的資料來源是從rereader來
            Repeater2.DataBind();//執行繫結
         
            rconnection.Close();


        }

    }

}