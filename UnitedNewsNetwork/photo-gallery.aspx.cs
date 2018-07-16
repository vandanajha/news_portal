using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class photo_gallary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable photoTable=DAL.get_all_gallary_photos().Tables["photo_gallary"];

            var unfeaturedphotos = (from photo in photoTable.AsEnumerable()
                                  where photo.Field<bool>("IsFeaturedPhoto") == false && photo.Field<bool>("IsLivePhoto") == true
                                  select new { photo_Id = photo.Field<int>("photo_Id"), photo_name = photo.Field<string>("photo_name"), photo_description = photo.Field<string>("photo_description") });

            rptphotogallery.DataSource = unfeaturedphotos;
            rptphotogallery.DataBind();


            var featuredphotos = (from photo in photoTable.AsEnumerable()
                                  where photo.Field<bool>("IsFeaturedPhoto") == true && photo.Field<bool>("IsLivePhoto")==true
                               select new {photo_Id=photo.Field<int>("photo_Id"), photo_name = photo.Field<string>("photo_name"), photo_description = photo.Field<string>("photo_description")});

            rptfeatured.DataSource = featuredphotos;
            rptfeatured.DataBind();

          



           
            rptthumbnails.DataSource = featuredphotos;
            rptthumbnails.DataBind();
        }
    }


    
    
}