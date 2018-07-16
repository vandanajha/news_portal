using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class administrator_ad_gallary : System.Web.UI.Page
{
    string path = "";
    string filename = "";
    string ImageUrl = "";
    string AlternateText = "";
    string NavigateUrl = "";
    string Keywords = "";
    int Impressions = 0;
    bool IsLiveAd = false;

    Guid user_Id;


    protected void bind_ads()
    {
        gdvadgallary.DataSource = DAL.get_all_ads();
        gdvadgallary.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind_ads();
        }
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        try
        {
            string errmsg = "";
            if (adUploader != null && adUploader.HasFile == true)
            {
                path = Server.MapPath("~/ads");
                filename = adUploader.FileName;

                path = path + "\\" + filename;

                ImageUrl = "ads/" + filename;

                if (String.IsNullOrEmpty(txtalternatetext.Text.Trim()))
                {
                    errmsg += "<li>Please Enter Alternate Text</li>";
                }
                else
                {
                    AlternateText = txtalternatetext.Text.Trim();
                }

                if (String.IsNullOrEmpty(txtnavigateurl.Text.Trim()))
                {
                    errmsg += "<li>Please Enter Navigate Url</li>";
                }
                else
                {
                    NavigateUrl += txtnavigateurl.Text.Trim();
                }

                if (String.IsNullOrEmpty(txtkeywords.Text.Trim()))
                {
                    errmsg += "<li>Please Enter Keywords</li>";
                }
                else
                {
                    Keywords = txtkeywords.Text.Trim();
                }

                if (String.IsNullOrEmpty(txtimpression.Text.Trim()))
                {
                    errmsg += "<li>Please Enter Impressions(Weightage)</li>";
                }
                else
                {
                    string digits = "0123456789";

                    bool FOUND = false;
                    for (int i = 0; i < txtimpression.Text.Trim().Length; i++)
                    {
                        string ch = txtimpression.Text.Trim().Substring(i, 1);
                        if (digits.IndexOf(ch) == -1)
                        {
                            FOUND = true;
                            break;
                        }
                    }


                    if (FOUND == true)
                    {
                        errmsg += "<li>Please Enter Valid Impressions(Weightage) In Numeric</li>";
                    }
                    else
                    {
                        Impressions = Convert.ToInt32(txtimpression.Text);
                    }
                }


                IsLiveAd = chkLive.Checked;

                user_Id = (Guid)Membership.GetUser(User.Identity.Name).ProviderUserKey;
                if (errmsg.Length > 0)
                {
                    errormsg.Text = "<font color='red'><ul>" + errmsg + "</ul></font>";
                }
                else
                {
                    int r = DAL.add_a_ad(ImageUrl, AlternateText, NavigateUrl, Keywords, Impressions, IsLiveAd, user_Id);
                    if (r > 0)
                    {
                        adUploader.SaveAs(path);
                        bind_ads();

                        txtalternatetext.Text = "";
                        txtnavigateurl.Text = "";
                        txtkeywords.Text = "";
                        txtimpression.Text = "";
                        chkLive.Checked = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            errormsg.Text = "<font color='red'><ul><li>" + ex.Message + "</li></ul></font>";
        }
    }
    protected void gdvadgallary_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gdvadgallary.EditIndex = e.NewEditIndex;
        bind_ads();
    }
    protected void gdvadgallary_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gdvadgallary.EditIndex = -1;
        bind_ads();
    }
    protected void gdvadgallary_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvadgallary.PageIndex = e.NewPageIndex;
        bind_ads();
    }
    protected void gdvadgallary_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int ad_Id = Convert.ToInt32(e.Keys["ad_Id"].ToString());
            int r = DAL.delete_a_ad(ad_Id);

            if (r > 0)
            {
                bind_ads();
            }
        }
        catch (Exception ex)
        {
            errormsg.Text = "<font color='red'><ul><li>" + ex.Message + "</li></ul></font>";
        }
    }
    protected void gdvadgallary_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            int ad_Id = Convert.ToInt32(e.Keys["ad_Id"].ToString());
            AlternateText = ((TextBox)gdvadgallary.Rows[e.RowIndex].FindControl("txtalternatetext")).Text;
            NavigateUrl = ((TextBox)gdvadgallary.Rows[e.RowIndex].FindControl("txtnavigateurl")).Text;
            Keywords = ((TextBox)gdvadgallary.Rows[e.RowIndex].FindControl("txtkeywords")).Text;
            Impressions= Convert.ToInt32(((TextBox)gdvadgallary.Rows[e.RowIndex].FindControl("txtimpressions")).Text);            
            IsLiveAd = ((CheckBox)gdvadgallary.Rows[e.RowIndex].FindControl("chklivead2")).Checked;
            user_Id = (Guid)Membership.GetUser(User.Identity.Name).ProviderUserKey;
            int r = DAL.update_a_ad(ad_Id,AlternateText,NavigateUrl,Keywords,Impressions,IsLiveAd,user_Id);

            if (r > 0)
            {
                gdvadgallary.EditIndex = -1;
                bind_ads();
            }
        }
        catch (Exception ex)
        {
            errormsg.Text = "<font color='red'><ul><li>" + ex.Message + "</li></ul></font>";
        }
    }
}