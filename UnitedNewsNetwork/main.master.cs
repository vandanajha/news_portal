using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
            DataSet dscategory = DAL.get_all_active_article_category();

            DataTable categoryTable = dscategory.Tables["article_category_master"];


            rptmenu.DataSource = dscategory;
            rptmenu.DataBind();

            
               
           
                DataSet dsarticles = DAL.get_all_active_articles();

                DataTable articleTable = dsarticles.Tables["vw_article_master"];

               
                //popular
                var populararticles = (from article in articleTable.AsEnumerable()
                                       orderby article.Field<int>("ArticleVisitCount")
                                       select new { article_Id = article.Field<int>("article_Id"), article_title = article.Field<string>("article_title"), article_category_Id = article.Field<int>("article_category_Id") }).Take(10).Reverse();


                rptpopular.DataSource = populararticles;
                rptpopular.DataBind();

                //video_gallary
                DataSet dsvideogallary = DAL.get_all_live_videos();

                DataTable videoTable = dsvideogallary.Tables["video_gallary"];
                var videos = (from video in videoTable.AsEnumerable()
                              select new { video_Id = video.Field<int>("video_Id"), video_name = video.Field<string>("video_name"), video_url = video.Field<string>("video_url"), video_description = video.Field<string>("video_description"), article_Id = video.Field<int>("article_Id"), IsFeaturedVideo = video.Field<bool>("IsFeaturedVideo"), IsLiveVideo = video.Field<bool>("IsLiveVideo"), date_added = video.Field<DateTime>("date_added") });


                rptvideos.DataSource = videos;
                rptvideos.DataBind();

                //ad_gallary

                rptadv.DataSource = DAL.get_all_live_ads();
                rptadv.DataBind();

                
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}
