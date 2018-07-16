using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class administrator_list_of_articles : System.Web.UI.Page
{
    int article_Id = 0;
    int article_category_Id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["category"] != null)
        {
            article_category_Id = Convert.ToInt32(Request.QueryString["category"].ToString());
        }
        if (!IsPostBack)
        {
            if (article_category_Id > 0)
            {
                gdvarticlelist.DataSource = DAL.get_all_articles_of_a_category(article_category_Id);
                gdvarticlelist.DataBind();
            }
            else
            {
                gdvarticlelist.DataSource = DAL.get_all_articles();
                gdvarticlelist.DataBind();
            }
        }
    }
    protected void gdvarticlelist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        article_Id = Convert.ToInt32(e.CommandArgument.ToString());

        if (e.CommandName == "Modify")
        {
            Response.Redirect("edit-a-article.aspx?article=" + article_Id.ToString());

        }
        if (e.CommandName == "add_photo")
        {
            Response.Redirect("photo-gallary.aspx?article=" + article_Id.ToString());

        }
        if (e.CommandName == "add_video")
        {
            Response.Redirect("video-gallary.aspx?article=" + article_Id.ToString());

        }
    }

    protected void gdvarticlelist_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int article_Id = Convert.ToInt32(e.Keys["article_Id"].ToString());
            int r = DAL.delete_a_article(article_Id);
            if (r > 0)
            {
                if (article_category_Id > 0)
                {
                    gdvarticlelist.DataSource = DAL.get_all_articles_of_a_category(article_category_Id);
                    gdvarticlelist.DataBind();
                }
                else
                {
                    gdvarticlelist.DataSource = DAL.get_all_articles();
                    gdvarticlelist.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            errormsg.Text = "<font color='red'>" + ex.Message + "</font>";
        }
    }

    protected void gdvarticlelist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvarticlelist.PageIndex = e.NewPageIndex;
        if (article_category_Id > 0)
        {
            gdvarticlelist.DataSource = DAL.get_all_articles_of_a_category(article_category_Id);
            gdvarticlelist.DataBind();
        }
        else
        {
            gdvarticlelist.DataSource = DAL.get_all_articles();
            gdvarticlelist.DataBind();
        }
    }
}