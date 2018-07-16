using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class administrator_article_category : System.Web.UI.Page
{
    int article_category_Id = 0;
    string article_category_name = "";
    bool IsLiveArticleCategory = false;
    Guid user_Id;

    protected void bind_article_category()
    {
        gdvarticlecategory.DataSource = DAL.get_all_article_category();
        gdvarticlecategory.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind_article_category();
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
           
            user_Id =(Guid) Membership.GetUser(User.Identity.Name).ProviderUserKey;
            string errmsg = "";
            if (String.IsNullOrEmpty(txtarticlecategoryname.Text.Trim()))
            {
                errmsg += "<li>Please Enter Article Category Name</li>";
            }
            else
            {
                article_category_name = txtarticlecategoryname.Text.Trim();
            }


            IsLiveArticleCategory = chkLive.Checked;

            if (errmsg.Length > 0)
            {
                errormsg.Text = "<font color='red'><ul>" + errmsg + "</ul></font>";
            }
            else
            {
                int r = DAL.add_a_article_category(article_category_name, IsLiveArticleCategory, user_Id);
                if (r > 0)
                {
                    bind_article_category();
                    errmsg = "";
                    txtarticlecategoryname.Text = "";
                }
            }
            
        }
        catch (Exception ex)
        {
            errormsg.Text = "<font color='red'><ul>" + ex.Message + "</ul></font>";
        }
    }
    protected void gdvarticlecategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvarticlecategory.PageIndex = e.NewPageIndex;
        bind_article_category();
    }
    protected void gdvarticlecategory_RowEditing(object sender, GridViewEditEventArgs e)
    {
       
    }
    protected void gdvarticlecategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gdvarticlecategory.EditIndex = -1;
        bind_article_category();
    }
    protected void gdvarticlecategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }
    protected void gdvarticlecategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
           
            user_Id = (Guid)Membership.GetUser(User.Identity.Name).ProviderUserKey;
            article_category_Id = Convert.ToInt32(e.Keys["article_category_Id"].ToString());
            
            article_category_name = ((TextBox)gdvarticlecategory.Rows[e.RowIndex].FindControl("txtcategoryname")).Text;
            IsLiveArticleCategory = ((CheckBox)gdvarticlecategory.Rows[e.RowIndex].FindControl("chkLive2")).Checked;
            int r = DAL.update_a_article_category(article_category_Id,article_category_name, IsLiveArticleCategory, user_Id);
           
            if (r > 0)
            {
                
                gdvarticlecategory.EditIndex = -1;
                bind_article_category();
            }
            else
            {
                errormsg.Text = "<font color='red'>Error Updating Record(s)</font>";
            }

        
        }
        catch (Exception ex)
        {
            errormsg.Text = ex.Message;
        }
    }
    protected void gdvarticlecategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        article_category_Id = Convert.ToInt32(e.CommandArgument.ToString());
        if (e.CommandName == "add_article")
        {
            Response.Redirect("add-a-article.aspx?category="+article_category_Id.ToString ());
        }

        if (e.CommandName == "list_article")
        {
            Response.Redirect("list-of-articles.aspx?category=" + article_category_Id.ToString());
        }
    }

    protected void gdvarticlecategory_RowEditing1(object sender, GridViewEditEventArgs e)
    {
        gdvarticlecategory.EditIndex = e.NewEditIndex;
        bind_article_category();
    }
    protected void gdvarticlecategory_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            article_category_Id = Convert.ToInt32(e.Keys["article_category_Id"].ToString());
            int r = DAL.delete_a_article_category(article_category_Id);
            if (r > 0)
            {
                bind_article_category();
            }
        }
        catch (Exception ex)
        {
            errormsg.Text = ex.Message;
        }
    }
}