using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class index : System.Web.UI.Page
{
    protected void ShowArticles(Object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            try
            {
                int article_category_Id = Convert.ToInt32(((Literal)e.Item.FindControl("lblarticlecategory")).Text);


                ((Repeater)e.Item.FindControl("rptheadlines")).DataSource = DAL.get_all_active_articles_of_a_category(article_category_Id);
                ((Repeater)e.Item.FindControl("rptheadlines")).DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }


    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {

            try
            {
                DataSet dsarticles = DAL.get_all_active_articles();

                 DataTable articleTable = dsarticles.Tables["vw_article_master"];
                    //top

                    var toparticles = (from article in articleTable.AsEnumerable()
                                       where article.Field<string>("article_type").Contains("TOP STORY")
                                       select new { article_Id = article.Field<int>("article_Id"), article_title = article.Field<string>("article_title"), article_photo = article.Field<byte[]>("article_photo"), article_summary = article.Field<string>("article_summary"), article_category_Id = article.Field<int>("article_category_Id") }).Take(5);

                    lstmainstory.DataSource = toparticles;
                    lstmainstory.DataBind();

                    /*

                    var toparticles2 = (from article in articleTable.AsEnumerable()
                                        where article.Field<string>("article_type").Contains("TOP STORY")
                                        select new { article_Id = article.Field<int>("article_Id"), article_title = article.Field<string>("article_title"), article_photo = article.Field<byte[]>("article_photo"), article_summary = article.Field<string>("article_summary"), article_category_Id = article.Field<int>("article_category_Id") }).Take(4).Skip(1);

                    lsttopstory.DataSource = toparticles2;
                    lsttopstory.DataBind();
                    */


                    //latest
                    var latestarticles = (from article in articleTable.AsEnumerable()
                                          where article.Field<string>("article_type").Contains("FEATURED STORY")
                                          select new { article_Id = article.Field<int>("article_Id"), article_title = article.Field<string>("article_title"), article_photo = article.Field<byte[]>("article_photo"), article_category_Id = article.Field<int>("article_category_Id") }).Take(20);

                    rptlatest.DataSource = latestarticles;
                    rptlatest.DataBind();


                


              
                    //headlines

                        DataSet dscategory = DAL.get_all_active_article_category();

                        DataTable categoryTable = dscategory.Tables["article_category_master"];

                    //category
                    var categories = from category in categoryTable.AsEnumerable()

                                     select new { article_category_Id = category.Field<int>("article_category_Id"), article_category_name = category.Field<string>("article_category_name") };
                    lstcategory.DataSource = categories;
                    lstcategory.DataBind();

                
        /*
                //photo_gallary

                DataSet dsphotogallary = DAL.get_all_live_gallary_photos();

                DataTable photoTable = dsphotogallary.Tables["photo_gallary"];
                var photos = (from photo in photoTable.AsEnumerable()
                              select new { photo_Id = photo.Field<int>("photo_Id"), photo_name = photo.Field<string>("photo_name"), photo_description = photo.Field<string>("photo_description"), article_Id = photo.Field<int>("article_Id"), IsFeaturedPhoto = photo.Field<bool>("IsFeaturedPhoto"), IsLivePhoto = photo.Field<bool>("IsLivePhoto"), date_added = photo.Field<DateTime>("date_added") }).Take(6);

                rptphotogallary.DataSource = photos;
                rptphotogallary.DataBind();

               */
        }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}