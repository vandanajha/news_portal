using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class artical_story2 : System.Web.UI.Page
{
    int article_Id = 0;
    int article_category_Id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["article"] != null && Request.QueryString["category"] != null)
        {
            article_Id = Convert.ToInt32(Request.QueryString["article"].ToString());
            article_category_Id = Convert.ToInt32(Request.QueryString["category"].ToString());

        }
        else
        {
            Response.Redirect("index.aspx");
        }

        if (!IsPostBack)
        {
            rptarticles.DataSource = DAL.get_a_article(article_Id);
            rptarticles.DataBind();
            int r = DAL.update_a_article_visit(article_Id);
            /*
                        rptphotogallary.DataSource = DAL.get_all_live_gallary_photos_of_article(article_Id);
                        rptphotogallary.DataBind();

                        rptvideogallary.DataSource = DAL.get_all_live_videos_of_article(article_Id);
                        rptvideogallary.DataBind();*/

            bind_comments(article_Id);
        }

    }

    protected void bind_comments(int article_Id)
    {
        rptcomments.DataSource = DAL.get_all_live_comments_of_article(article_Id);
        rptcomments.DataBind();
    }
    protected void btnsend_Click(object sender, EventArgs e)
    {
        string sender_name = txtname.Text.Trim();
        string sender_email = txtemail.Text.Trim();
        string comment_description = txtcomment.Text.Trim();

        int r = DAL.add_a_comment(comment_description, article_Id, sender_name, sender_email);
        if (r > 0)
        {
            txtname.Text = "";
            txtemail.Text = "";
            txtcomment.Text = "";
            bind_comments(article_Id);
        }
    }
}