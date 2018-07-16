using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

public partial class video_gallary : System.Web.UI.Page
{

    int video_Id = 0;
  

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["video"] != null && Request.QueryString["title"]!=null) 
        {
            video_Id = Convert.ToInt32(Request.QueryString["video"].ToString ());
            DataRow row=DAL.get_a_video(video_Id).Tables["video_gallary"].Rows[0];
            lblvideoplayer.Text =row["video_url"].ToString();
            lblvideodescription.Text =row["video_description"].ToString();
        }
            //video_gallary
            DataSet dsvideogallary = DAL.get_all_live_videos();

            DataTable videoTable = dsvideogallary.Tables["video_gallary"];
            var videos = (from video in videoTable.AsEnumerable()
                          select new { video_Id = video.Field<int>("video_Id"), video_name = video.Field<string>("video_name"), video_url = video.Field<string>("video_url"), video_description = video.Field<string>("video_description"), article_Id = video.Field<int>("article_Id"), IsFeaturedVideo = video.Field<bool>("IsFeaturedVideo"), IsLiveVideo = video.Field<bool>("IsLiveVideo"), date_added = video.Field<DateTime>("date_added") }).Take(6);

            
            rptvideos.DataSource = videos;
            rptvideos.DataBind();


           

        }
    
   
}