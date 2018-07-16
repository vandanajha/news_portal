using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class list_of_artcles2 : System.Web.UI.Page
{
    int article_category_Id = 0;
  
    protected void Page_Load(object sender, EventArgs e)
    {
       
       




        if (!IsPostBack)
        {
           /* DataSet dsarticles = (DataSet)Session["dsarticles"];
            DataTable articleTable = dsarticles.Tables["vw_article_master"];
            var articles = (from article in articleTable.AsEnumerable()
                            where article.Field<int>("article_category_Id") == article_category_Id
                            select new { article_Id = article.Field<int>("article_Id"), article_title = article.Field<string>("article_title"), article_source = article.Field<string>("article_source"), article_photo = article.Field<byte[]>("article_photo"), article_summary = article.Field<string>("article_summary"), article_category_Id = article.Field<int>("article_category_Id"), article_category_name = article.Field<string>("article_category_name"), date_added = article.Field<DateTime>("date_added") }).Take(20);






            rptarticles.DataSource = articles;
            rptarticles.DataBind();*/
            BindRepeater();
        }

    }


    public int PageNumber
    {
        get
        {
            if (ViewState["PageNumber"] != null)
                return Convert.ToInt32(ViewState["PageNumber"]);
            else
                return 0;
        }
        set
        {
            ViewState["PageNumber"] = value;
        }
    }
    protected void rptPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
        BindRepeater();
    }

    protected void BindRepeater()
    {
        if (Request.QueryString["category"] != null)
        {
            article_category_Id = Convert.ToInt32(Request.QueryString["category"].ToString());
        }
        else
        {
            Response.Redirect("index.aspx");
        }
          








            DataSet dsarticles = DAL.get_all_active_articles_of_a_category(article_category_Id);

        DataTable articleTable = dsarticles.Tables["vw_article_master"];
        PagedDataSource pgitems = new PagedDataSource();
        DataView dv = new DataView(articleTable);
        pgitems.DataSource = dv;
        pgitems.AllowPaging = true;
        pgitems.PageSize = 10;
        pgitems.CurrentPageIndex = PageNumber;
        if (pgitems.PageCount > 1)
        {
            rptPaging.Visible = true;
            ArrayList pages = new ArrayList();
            for (int i = 0; i < pgitems.PageCount; i++)
            {
                pages.Add((i + 1).ToString());
            }
            rptPaging.DataSource = pages;
            rptPaging.DataBind();
        }
        else
        {
            rptPaging.Visible = false;
        }

        rptarticles.DataSource = pgitems;
        rptarticles.DataBind();
       

    }
   
}