using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for DAL
/// </summary>
public static class DAL
{
    public static SqlConnection getconnection()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["unn"].ConnectionString);
        return (cn);

    }


    /*article_category_master*/
    public static int add_a_article_category(string article_category_name,bool IsLiveArticleCategory,Guid user_Id)
    {
         SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("add_a_article_category", cn);
        cmd.CommandType = CommandType.StoredProcedure;

         cmd.Parameters.AddWithValue("@article_category_name",article_category_name);
         cmd.Parameters.AddWithValue("@IsLiveArticleCategory",IsLiveArticleCategory);
         cmd.Parameters.AddWithValue("@user_Id",user_Id);

        int result = cmd.ExecuteNonQuery();
        return (result);
    }


    public static int update_a_article_category(int article_category_Id, string article_category_name, bool IsLiveArticleCategory, Guid user_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("update_a_article_category", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@article_category_Id", article_category_Id);
        cmd.Parameters.AddWithValue("@article_category_name", article_category_name);
        cmd.Parameters.AddWithValue("@IsLiveArticleCategory", IsLiveArticleCategory);
        cmd.Parameters.AddWithValue("@user_Id", user_Id);

        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static int delete_a_article_category(int article_category_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("delete_a_article_category", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@article_category_Id", article_category_Id);
       

        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static DataSet get_a_article_category(int article_category_Id)
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_a_article_category", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@article_category_Id", article_category_Id);


        SqlDataAdapter dacategory = new SqlDataAdapter(cmd);
        DataSet dscategory = new DataSet();
        dacategory.Fill(dscategory, "article_category_master");
        return (dscategory);

    }

    public static DataSet get_all_article_category()
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_article_category", cn);
        cmd.CommandType = CommandType.StoredProcedure;
       


        SqlDataAdapter dacategory = new SqlDataAdapter(cmd);
        DataSet dscategory = new DataSet();
        dacategory.Fill(dscategory, "article_category_master");
        return (dscategory);

    }

    public static DataSet get_all_active_article_category()
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_active_article_category", cn);
        cmd.CommandType = CommandType.StoredProcedure;



        SqlDataAdapter dacategory = new SqlDataAdapter(cmd);
        DataSet dscategory = new DataSet();
        dacategory.Fill(dscategory, "article_category_master");
        return (dscategory);

    }

    /*article_master*/
    public static int add_a_article(string article_title,string article_source,byte[] article_photo,string article_summary,string article_description,int article_category_Id,string article_type,string article_tags, bool IsLiveArticle, Guid user_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("add_a_article", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@article_title", article_title);
        cmd.Parameters.AddWithValue("@article_source", article_source);
        cmd.Parameters.AddWithValue("@article_photo", article_photo);
        cmd.Parameters.AddWithValue("@article_summary", article_summary);
        cmd.Parameters.AddWithValue("@article_description", article_description);
        cmd.Parameters.AddWithValue("@article_category_Id", article_category_Id);
        cmd.Parameters.AddWithValue("@article_type", article_type);
        cmd.Parameters.AddWithValue("@article_tags", article_tags);
        cmd.Parameters.AddWithValue("@IsLiveArticle", IsLiveArticle);
        cmd.Parameters.AddWithValue("@user_Id", user_Id);

        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static int update_a_article(int article_Id,string article_title, string article_source, string article_summary, string article_description, int article_category_Id, string article_type, string article_tags, bool IsLiveArticle, Guid user_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("update_a_article", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@article_Id", article_Id);
        cmd.Parameters.AddWithValue("@article_title", article_title);
        cmd.Parameters.AddWithValue("@article_source", article_source);
       
        cmd.Parameters.AddWithValue("@article_summary", article_summary);
        cmd.Parameters.AddWithValue("@article_description", article_description);
        cmd.Parameters.AddWithValue("@article_category_Id", article_category_Id);
        cmd.Parameters.AddWithValue("@article_type", article_type);
        cmd.Parameters.AddWithValue("@article_tags", article_tags);
        cmd.Parameters.AddWithValue("@IsLiveArticle", IsLiveArticle);
        cmd.Parameters.AddWithValue("@user_Id", user_Id);

        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static int delete_a_article(int article_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("delete_a_article", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@article_Id", article_Id);
       

        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static int update_a_article_photo(int article_Id,byte[] article_photo,Guid user_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("update_a_article_photo", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@article_Id", article_Id);
        cmd.Parameters.AddWithValue("@article_photo", article_photo);
        cmd.Parameters.AddWithValue("@user_Id", user_Id);

        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static int update_a_article_visit(int article_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("update_a_article_visit", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@article_Id", article_Id);
      

        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static DataSet get_all_articles()
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_articles", cn);
        cmd.CommandType = CommandType.StoredProcedure;



        SqlDataAdapter daarticle = new SqlDataAdapter(cmd);
        DataSet dsarticle = new DataSet();
        daarticle.Fill(dsarticle, "vw_article_master");
        return (dsarticle);

    }

    public static DataSet get_all_active_articles()
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_active_articles", cn);
        cmd.CommandType = CommandType.StoredProcedure;



        SqlDataAdapter daarticle = new SqlDataAdapter(cmd);
        DataSet dsarticle = new DataSet();
        daarticle.Fill(dsarticle, "vw_article_master");
        return (dsarticle);

    }

    public static DataSet get_a_article(int article_Id)
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_a_article", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@article_Id", article_Id);


        SqlDataAdapter daarticle = new SqlDataAdapter(cmd);
        DataSet dsarticle = new DataSet();
        daarticle.Fill(dsarticle, "vw_article_master");
        return (dsarticle);

    }

    public static DataSet get_all_articles_of_a_category(int article_category_Id)
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_articles_of_a_category", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@article_category_Id", article_category_Id);


        SqlDataAdapter daarticle = new SqlDataAdapter(cmd);
        DataSet dsarticle = new DataSet();
        daarticle.Fill(dsarticle, "vw_article_master");
        return (dsarticle);

    }

    public static DataSet get_all_active_articles_of_a_category(int article_category_Id)
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_active_articles_of_a_category", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@article_category_Id", article_category_Id);


        SqlDataAdapter daarticle = new SqlDataAdapter(cmd);
        DataSet dsarticle = new DataSet();
        daarticle.Fill(dsarticle, "vw_article_master");
        return (dsarticle);

    }

    public static byte[] get_a_article_photo(int article_Id)
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_a_article_photo", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@article_Id", article_Id);

        byte[] article_photo = (byte[])cmd.ExecuteScalar();
        return (article_photo);


    }


    /*article_comment_master*/

    public static int add_a_comment(string article_comment_description,int article_Id,string sender_name,string sender_email)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("add_a_comment", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@article_comment_description", article_comment_description);
        cmd.Parameters.AddWithValue("@article_Id", article_Id);
        cmd.Parameters.AddWithValue("@sender_name", sender_name);
        cmd.Parameters.AddWithValue("@sender_email", sender_email);
        

        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static int update_a_comment(int article_comment_Id, bool IsLiveComment)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("update_a_comment", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@article_comment_Id", article_comment_Id);
        cmd.Parameters.AddWithValue("@IsLiveComment", IsLiveComment);
        


        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static int delete_a_comment(int article_comment_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("delete_a_comment", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@article_comment_Id", article_comment_Id);
        



        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static DataSet get_all_comments()
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_comments", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        

        SqlDataAdapter dacomment = new SqlDataAdapter(cmd);
        DataSet dscomment = new DataSet();
        dacomment.Fill(dscomment, "article_comment_master");
        return (dscomment);

    }

    public static DataSet get_all_live_comments()
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_live_comments", cn);
        cmd.CommandType = CommandType.StoredProcedure;


        SqlDataAdapter dacomment = new SqlDataAdapter(cmd);
        DataSet dscomment = new DataSet();
        dacomment.Fill(dscomment, "article_comment_master");
        return (dscomment);

    }

    public static DataSet get_all_comments_of_article(int article_Id)
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_comments_of_article", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@article_Id", article_Id);

        SqlDataAdapter dacomment = new SqlDataAdapter(cmd);
        DataSet dscomment = new DataSet();
        dacomment.Fill(dscomment, "article_comment_master");
        return (dscomment);

    }

    public static DataSet get_all_live_comments_of_article(int article_Id)
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_live_comments_of_article", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@article_Id", article_Id);

        SqlDataAdapter dacomment = new SqlDataAdapter(cmd);
        DataSet dscomment = new DataSet();
        dacomment.Fill(dscomment, "article_comment_master");
        return (dscomment);

    }

    public static DataSet get_a_comment(int article_comment_Id)
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_a_comment", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@article_comment_Id", article_comment_Id);

        SqlDataAdapter dacomment = new SqlDataAdapter(cmd);
        DataSet dscomment = new DataSet();
        dacomment.Fill(dscomment, "article_comment_master");
        return (dscomment);

    }
    /*photo_gallary*/

    public static int add_a_gallary_photo(string photo_name,string photo_description, int article_Id, bool IsFeaturedPhoto, bool IsLivePhoto, Guid user_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("add_a_gallary_photo", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@photo_name", photo_name);
       
        cmd.Parameters.AddWithValue("@photo_description", photo_description);
        cmd.Parameters.AddWithValue("@article_Id", article_Id);
        cmd.Parameters.AddWithValue("@IsFeaturedPhoto", IsFeaturedPhoto);       
        cmd.Parameters.AddWithValue("@IsLivePhoto", IsLivePhoto);
        cmd.Parameters.AddWithValue("@user_Id", user_Id);

        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static int update_a_gallary_photo(int photo_Id, string photo_description, int article_Id, bool IsFeaturedPhoto, bool IsLivePhoto, Guid user_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("update_a_gallary_photo", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@photo_Id", photo_Id);
        
        cmd.Parameters.AddWithValue("@photo_description", photo_description);
        cmd.Parameters.AddWithValue("@article_Id", article_Id);
        cmd.Parameters.AddWithValue("@IsFeaturedPhoto", IsFeaturedPhoto);
        cmd.Parameters.AddWithValue("@IsLivePhoto", IsLivePhoto);
        cmd.Parameters.AddWithValue("@user_Id", user_Id);

        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static int update_a_photo_of_gallary(int photo_Id, string photo_name, Guid user_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("update_a_photo_of_gallary", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@photo_Id", photo_Id);
        cmd.Parameters.AddWithValue("@photo_name", photo_name);
        
        cmd.Parameters.AddWithValue("@user_Id", user_Id);

        int result = cmd.ExecuteNonQuery();
        return (result);
    }
    public static int update_a_photo_visit(int photo_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("update_a_photo_visit", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@photo_Id", photo_Id);
      

        int result = cmd.ExecuteNonQuery();
        return (result);
    }
    public static int delete_a_gallary_photo(int photo_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("delete_a_gallary_photo", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@photo_Id", photo_Id);


        int result = cmd.ExecuteNonQuery();
        return (result);
    }
    public static DataSet get_all_gallary_photos()
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_gallary_photos", cn);
        cmd.CommandType = CommandType.StoredProcedure;
       


        SqlDataAdapter daphotogallary = new SqlDataAdapter(cmd);
        DataSet dsphotogallary = new DataSet();
        daphotogallary.Fill(dsphotogallary, "photo_gallary");
        return (dsphotogallary);

    }

    public static DataSet get_all_live_gallary_photos()
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_live_gallary_photos", cn);
        cmd.CommandType = CommandType.StoredProcedure;



        SqlDataAdapter daphotogallary = new SqlDataAdapter(cmd);
        DataSet dsphotogallary = new DataSet();
        daphotogallary.Fill(dsphotogallary, "photo_gallary");
        return (dsphotogallary);

    }

    public static DataSet get_all_live_gallary_photos_of_article(int article_Id)
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_live_gallary_photos_of_article", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@article_Id", article_Id);

        SqlDataAdapter daphotogallary = new SqlDataAdapter(cmd);
        DataSet dsphotogallary = new DataSet();
        daphotogallary.Fill(dsphotogallary, "photo_gallary");
        return (dsphotogallary);

    }
    public static DataSet get_a_gallary_photo(int photo_Id)
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_a_gallary_photo", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@photo_Id", photo_Id);


        SqlDataAdapter daphotogallary = new SqlDataAdapter(cmd);
        DataSet dsphotogallary = new DataSet();
        daphotogallary.Fill(dsphotogallary, "photo_gallary");
        return (dsphotogallary);

    }



    

    /*video_gallary*/

    /*video_gallary*/

    public static int add_a_video(string video_name,  string video_url, string video_description, int article_Id, bool IsFeaturedVideo, bool IsLiveVideo, Guid user_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("add_a_video", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@video_name", video_name);
       
        cmd.Parameters.AddWithValue("@video_url", video_url);
        cmd.Parameters.AddWithValue("@video_description", video_description);
        cmd.Parameters.AddWithValue("@article_Id", article_Id);
        cmd.Parameters.AddWithValue("@IsFeaturedVideo", IsFeaturedVideo);
        cmd.Parameters.AddWithValue("@IsLiveVideo", IsLiveVideo);
        cmd.Parameters.AddWithValue("@user_Id", user_Id);

        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static int update_a_video(int video_Id, string video_name, string video_url, string video_description, int article_Id, bool IsFeaturedVideo, bool IsLiveVideo, Guid user_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("update_a_video", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@video_Id", video_Id);
        cmd.Parameters.AddWithValue("@video_name", video_name);
       
        cmd.Parameters.AddWithValue("@video_url", video_url);
        cmd.Parameters.AddWithValue("@video_description", video_description);
        cmd.Parameters.AddWithValue("@article_Id", article_Id);
        cmd.Parameters.AddWithValue("@IsFeaturedVideo", IsFeaturedVideo);
        cmd.Parameters.AddWithValue("@IsLiveVideo", IsLiveVideo);
        cmd.Parameters.AddWithValue("@user_Id", user_Id);

        int result = cmd.ExecuteNonQuery();
        return (result);
    }


    public static int update_a_video_visit(int video_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("update_a_video_visit", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@video_Id", video_Id);


        int result = cmd.ExecuteNonQuery();
        return (result);
    }
    public static int delete_a_video(int video_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("delete_a_video", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@video_Id", video_Id);


        int result = cmd.ExecuteNonQuery();
        return (result);
    }
    public static DataSet get_all_videos()
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_videos", cn);
        cmd.CommandType = CommandType.StoredProcedure;



        SqlDataAdapter davideogallary = new SqlDataAdapter(cmd);
        DataSet dsvideogallary = new DataSet();
        davideogallary.Fill(dsvideogallary, "video_gallary");
        return (dsvideogallary);

    }

    public static DataSet get_all_live_videos()
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_live_videos", cn);
        cmd.CommandType = CommandType.StoredProcedure;



        SqlDataAdapter davideogallary = new SqlDataAdapter(cmd);
        DataSet dsvideogallary = new DataSet();
        davideogallary.Fill(dsvideogallary, "video_gallary");
        return (dsvideogallary);

    }

    public static DataSet get_all_live_videos_of_article(int article_Id)
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_live_videos_of_article", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@article_Id", article_Id);

        SqlDataAdapter davideogallary = new SqlDataAdapter(cmd);
        DataSet dsvideogallary = new DataSet();
        davideogallary.Fill(dsvideogallary, "video_gallary");
        return (dsvideogallary);

    }
    public static DataSet get_a_video(int video_Id)
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_a_video", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@video_Id", video_Id);


        SqlDataAdapter davideogallary = new SqlDataAdapter(cmd);
        DataSet dsvideogallary = new DataSet();
        davideogallary.Fill(dsvideogallary, "video_gallary");
        return (dsvideogallary);

    }


    /*ads_master*/

    public static int add_a_ad(string ImageUrl, string AlternateText,string NavigateUrl,string Keywords, int Impressions, bool IsLiveAd,Guid user_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("add_a_ad", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@ImageUrl", ImageUrl);

        cmd.Parameters.AddWithValue("@AlternateText", AlternateText);
        cmd.Parameters.AddWithValue("@NavigateUrl", NavigateUrl);
        cmd.Parameters.AddWithValue("@Keywords", Keywords);
        cmd.Parameters.AddWithValue("@Impressions", Impressions);
        cmd.Parameters.AddWithValue("@IsLiveAd", IsLiveAd);
        cmd.Parameters.AddWithValue("@user_Id", user_Id);

        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static int update_a_ad(int ad_Id, string AlternateText,string NavigateUrl,string Keywords, int Impressions,  bool IsLiveAd, Guid user_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("update_a_ad", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ad_Id", ad_Id);

        cmd.Parameters.AddWithValue("@AlternateText", AlternateText);
        cmd.Parameters.AddWithValue("@NavigateUrl", NavigateUrl);
        cmd.Parameters.AddWithValue("@Keywords", Keywords);
        cmd.Parameters.AddWithValue("@Impressions", Impressions);
        cmd.Parameters.AddWithValue("@IsLiveAd", IsLiveAd);
        cmd.Parameters.AddWithValue("@user_Id", user_Id);

        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static int update_a_photo_of_ad(int ad_Id, string ImageUrl, Guid user_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("update_a_photo_of_ad", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ad_Id", ad_Id);
        cmd.Parameters.AddWithValue("@ImageUrl", ImageUrl);
        cmd.Parameters.AddWithValue("@user_Id", user_Id);

        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static DataSet get_a_ad(int ad_Id)
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_a_ad", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ad_Id", ad_Id);


        SqlDataAdapter daadgallary = new SqlDataAdapter(cmd);
        DataSet dsadgallary = new DataSet();
        daadgallary.Fill(dsadgallary, "ads_gallary");
        return (dsadgallary);

    }

    public static DataSet get_all_ads()
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_ads", cn);
        cmd.CommandType = CommandType.StoredProcedure;
       


        SqlDataAdapter daadgallary = new SqlDataAdapter(cmd);
        DataSet dsadgallary = new DataSet();
        daadgallary.Fill(dsadgallary, "ads_gallary");
        return (dsadgallary);

    }

    public static DataSet get_all_live_ads()
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_live_ads", cn);
        cmd.CommandType = CommandType.StoredProcedure;



        SqlDataAdapter daadgallary = new SqlDataAdapter(cmd);
        DataSet dsadgallary = new DataSet();
        daadgallary.Fill(dsadgallary, "ads_gallary");
        return (dsadgallary);

    }

    public static int delete_a_ad(int ad_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("delete_a_ad", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@ad_Id", ad_Id);


        int result = cmd.ExecuteNonQuery();
        return (result);
    }
    /**/
    public static void bind_dropdownlist(DropDownList ddlcontrol, DataSet ds, string data_text, string data_value)
    {
        ddlcontrol.DataSource = ds;
        ddlcontrol.DataTextField = data_text;
        ddlcontrol.DataValueField = data_value;
        ddlcontrol.DataBind();
        
    }
    /*
    user_master

     */


    public static int add_a_subscriber(Guid user_Id, string first_name, string last_name, byte[] photo, string address, string city, string state, string country, string mobile_no, string email, string user_name, string password, bool IsLiveSubscriber)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("add_a_subscriber", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@subscriber_Id", user_Id);
        cmd.Parameters.AddWithValue("@subscriber_first_name", first_name);
        cmd.Parameters.AddWithValue("@subscriber_last_name", last_name);
        cmd.Parameters.AddWithValue("@subscriber_photo_url", photo);
        cmd.Parameters.AddWithValue("@subscriber_address", address);
        cmd.Parameters.AddWithValue("@subscriber_city", city);
        cmd.Parameters.AddWithValue("@subscriber_state", state);
        cmd.Parameters.AddWithValue("@subscriber_country", country);
        cmd.Parameters.AddWithValue("@subscriber_mobile_no", mobile_no);
        cmd.Parameters.AddWithValue("@subscriber_email", email);       
        cmd.Parameters.AddWithValue("@subscriber_user_name", user_name);
        cmd.Parameters.AddWithValue("@subscriber_password", password);
        cmd.Parameters.AddWithValue("@IsLiveSubscriber", IsLiveSubscriber);
       

        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static int update_a_subscriber_profile(Guid user_Id, string first_name, string last_name, string address, string city, string state, string country, string mobile_no, string email, bool IsLiveSubscriber)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("update_a_subscriber_profile", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@subscriber_Id", user_Id);
        cmd.Parameters.AddWithValue("@subscriber_first_name", first_name);
        cmd.Parameters.AddWithValue("@subscriber_last_name", last_name);        
        cmd.Parameters.AddWithValue("@subscriber_address", address);
        cmd.Parameters.AddWithValue("@subscriber_city", city);
        cmd.Parameters.AddWithValue("@subscriber_state", state);
        cmd.Parameters.AddWithValue("@subscriber_country", country);
        cmd.Parameters.AddWithValue("@subscriber_mobile_no", mobile_no);
        cmd.Parameters.AddWithValue("@subscriber_email", email);      
        cmd.Parameters.AddWithValue("@IsLiveSubscriber", IsLiveSubscriber);


        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static int update_a_subscriber_photo(Guid user_Id,byte[] photo)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("update_a_subscriber_photo", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@subscriber_Id", user_Id);
        cmd.Parameters.AddWithValue("@subscriber_photo_url", photo);
       


        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static int update_a_subscriber_account(string subscriber_user_name, string subscriber_password)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("update_a_subscriber_account", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@subscriber_user_name",subscriber_user_name);
        cmd.Parameters.AddWithValue("@subscriber_password", subscriber_password);



        int result = cmd.ExecuteNonQuery();
        return (result);
    }

    public static int delete_a_subscriber(Guid subscriber_Id)
    {
        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();

        SqlCommand cmd = new SqlCommand("delete_a_subscriber", cn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@subscriber_Id", subscriber_Id);
      



        int result = cmd.ExecuteNonQuery();
        return (result);
    }
    public static DataSet get_all_subscribers()
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_subscribers", cn);
        cmd.CommandType = CommandType.StoredProcedure;



        SqlDataAdapter dasubscriber = new SqlDataAdapter(cmd);
        DataSet dssubscriber = new DataSet();
        dasubscriber.Fill(dssubscriber, "subscriber_master");
        return (dssubscriber);

    }

    public static DataSet get_all_live_subscribers()
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_all_live_subscribers", cn);
        cmd.CommandType = CommandType.StoredProcedure;



        SqlDataAdapter dasubscriber = new SqlDataAdapter(cmd);
        DataSet dssubscriber = new DataSet();
        dasubscriber.Fill(dssubscriber, "subscriber_master");
        return (dssubscriber);

    }

    public static DataSet get_a_subscriber(Guid subscriber_Id)
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_a_subscriber", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@subscriber_Id", subscriber_Id);


        SqlDataAdapter dasubscriber = new SqlDataAdapter(cmd);
        DataSet dssubscriber = new DataSet();
        dasubscriber.Fill(dssubscriber, "subscriber_master");
        return (dssubscriber);

    }

    public static byte[] get_a_subscriber_photo(Guid subscriber_Id)
    {


        SqlConnection cn = getconnection();
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        cn.Open();
        SqlCommand cmd = new SqlCommand("get_a_subscriber_photo", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@subscriber_Id", subscriber_Id);


        byte[] subscriber_photo = (byte[])cmd.ExecuteScalar();
        return (subscriber_photo);

    }
}