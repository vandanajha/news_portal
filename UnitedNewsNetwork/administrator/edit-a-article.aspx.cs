using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

public partial class administrator_edit_a_article : System.Web.UI.Page
{
    int article_Id = 0;
    string article_title = "";
    string article_source = "UNN";
    byte[] article_photo;
    string article_summary = "";
    string article_description = "";
    int article_category_Id = 0;
    string article_type = "";
    string article_tags = "";
    bool IsLiveArticle = false;

    Guid user_Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["article"] != null)
        {
            article_Id = Convert.ToInt32(Request.QueryString["article"].ToString ());
        }

        if (!IsPostBack)
        {
            DAL.bind_dropdownlist(ddlcategory, DAL.get_all_active_article_category(), "article_category_name", "article_category_Id");
            if (article_Id > 0)
            {
                DataRow row = DAL.get_a_article(article_Id).Tables["vw_article_master"].Rows[0];
                txtarticletitle.Text = row["article_title"].ToString();
                txtarticlesource.Text = row["article_source"].ToString();
                txtarticlesummary.Content = row["article_summary"].ToString();
                txtarticledescription.Content = row["article_description"].ToString();
                ddlcategory.SelectedValue = row["article_category_Id"].ToString();
                ddltypes.SelectedValue = row["article_type"].ToString();
                txtarticletags.Text = row["article_tags"].ToString();
                chkLive.Checked=Convert.ToBoolean(row["IsLiveArticle"].ToString());

            }
        }

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string errmsg = "";
        try
        {

            user_Id = (Guid)Membership.GetUser(User.Identity.Name).ProviderUserKey;
           
            if (String.IsNullOrEmpty(txtarticletitle.Text.Trim()))
            {
                errmsg += "<li>Please Enter Article Title</li>";
            }
            else
            {
                article_title = txtarticletitle.Text.Trim();
            }

            article_source = txtarticlesource.Text.Trim();



            if (String.IsNullOrEmpty(txtarticlesummary.Content.Trim()))
            {
                errmsg += "<li>Please Enter Article Summary</li>";
            }
            else
            {
                article_summary = txtarticlesummary.Content.Trim();
            }
            if (String.IsNullOrEmpty(txtarticledescription.Content.Trim()))
            {
                errmsg += "<li>Please Enter Article Story</li>";
            }
            else
            {
                article_description = txtarticledescription.Content.Trim();
            }

            if (ddlcategory.SelectedIndex <= 0)
            {
                errmsg += "<li>Please Select a Category</li>";
            }
            else
            {
                article_category_Id = Convert.ToInt32(ddlcategory.SelectedItem.Value);

            }

            if (ddltypes.SelectedIndex <= 0)
            {
                errmsg += "<li>Please Select a Article Type</li>";
            }
            else
            {
                article_type = ddltypes.SelectedItem.Text;

            }

            article_tags = txtarticletags.Text.Trim();

            IsLiveArticle = chkLive.Checked;

            if (errmsg.Length > 0)
            {
                errormsg.Text = "<font color='red'><ul>" + errmsg + "</ul></font>";
               
            }
            else
            {
                int r = DAL.update_a_article(article_Id, article_title, article_source, article_summary, article_description, article_category_Id, article_type, article_tags, IsLiveArticle, user_Id);
                if (r > 0)
                {

                    errmsg = "";
                    txtarticletitle.Text = "";
                    txtarticlesource.Text = "";
                    txtarticlesummary.Content = "";
                    txtarticledescription.Content = "";
                    txtarticletags.Text = "";
                    Response.Redirect("list-of-articles.aspx");
                }
            }

        }
        catch (Exception ex)
        {
            errormsg.Text = "<font color='red'><ul>" + ex.Message + "</ul></font>";
        }
        finally
        {
            errmsg = "";
        }
    }
}