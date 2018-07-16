using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;

public partial class administrator_add_a_article : System.Web.UI.Page
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
        if (Request.QueryString["category"] != null)
        {
            article_category_Id = Convert.ToInt32(Request.QueryString["category"].ToString());
        }
        if (!IsPostBack)
        {
            ddlcategory.SelectedValue = article_category_Id.ToString ();
            DAL.bind_dropdownlist(ddlcategory, DAL.get_all_active_article_category(), "article_category_name", "article_category_Id");
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {

            user_Id = (Guid)Membership.GetUser(User.Identity.Name).ProviderUserKey;
            string errmsg = "";
            if (String.IsNullOrEmpty(txtarticletitle.Text.Trim()))
            {
                errmsg += "<li>Please Enter Article Title</li>";
            }
            else
            {
               article_title= txtarticletitle.Text.Trim();
            }

            article_source = txtarticlesource.Text.Trim();

            if (photoUploader != null && photoUploader.HasFile)
            {
                int len = photoUploader.PostedFile.ContentLength;
                article_photo = new byte[len];
                photoUploader.PostedFile.InputStream.Read(article_photo, 0, len);
            }
            else
            {
                string filename = Server.MapPath("~/administrator/images/bg.gif");
                FileStream fs = new FileStream(filename, FileMode.Open);
                int len = Convert.ToInt32(fs.Length);
                article_photo = new byte[len];
                fs.Read(article_photo, 0, len);
            }

            if (String.IsNullOrEmpty(txtarticlesummary.Content.Trim()))
            {
                errmsg += "<li>Please Enter Article Summary</li>";
            }
            else
            {
               article_summary= txtarticlesummary.Content.Trim();
            }
            if (String.IsNullOrEmpty(txtarticledescription.Content.Trim()))
            {
                errmsg += "<li>Please Enter Article Story</li>";
            }
            else
            {
              article_description= txtarticledescription.Content.Trim();
            }

            if (ddlcategory.SelectedIndex <= 0)
            {
                errmsg += "<li>Please Select a Category</li>";
            }
            else
            {
                article_category_Id =Convert.ToInt32(ddlcategory.SelectedItem.Value);

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
                int r = DAL.add_a_article(article_title, article_source, article_photo, article_summary, article_description, article_category_Id, article_type, article_tags, IsLiveArticle, user_Id);
                if (r > 0)
                {
                  
                    errmsg = "";
                    txtarticletitle.Text = "";
                    txtarticlesource.Text = "";
                    txtarticlesummary.Content = "";
                    txtarticledescription.Content = "";
                    txtarticletags.Text = "";
                }
            }

        }
        catch (Exception ex)
        {
            errormsg.Text = "<font color='red'><ul>" + ex.Message + "</ul></font>";
        }
    }
}