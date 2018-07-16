using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;

public partial class administrator_video_gallary : System.Web.UI.Page
{
    string video_name;
    
    string video_photo_url = "";
    string video_description = "";
    string video_url = "";
    bool IsFeaturedVideo = false;
    bool IsLiveVideo = false;

    int article_Id = 0;
    Guid user_Id;

    protected void bind_videogallary()
    {
        gdvvideogallary.DataSource = DAL.get_all_videos();
        gdvvideogallary.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind_videogallary();
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            user_Id = (Guid)Membership.GetUser(User.Identity.Name).ProviderUserKey;
           
            string errmsg = "";

            if (string.IsNullOrEmpty(txtvideoname.Text.Trim()))
            {
                errmsg = "<li>Please Enter Video Title</li>";
            }
            else
            {
                video_name = txtvideoname.Text.Trim();
            }

            if (photoUploader != null && photoUploader.HasFile)
            {
                video_photo_url = photoUploader.FileName;
            }
            else
            {
                errmsg = "<li>Please Select a Video Photo</li>";
            }
            if (string.IsNullOrEmpty(txtvideourl.Text.Trim()))
            {
                errmsg = "<li>Please Enter Video Url</li>";
            }
            else
            {
                video_url = txtvideourl.Text;
            }

            if (string.IsNullOrEmpty(txtvideodescription.Text.Trim()))
            {
                errmsg = "<li>Please Enter Video Description</li>";
            }
            else
            {
                video_description = txtvideodescription.Text.Trim();
            }
            

            if (Request.QueryString["article"] != null)
            {
                article_Id = Convert.ToInt32(Request.QueryString["article"].ToString());
            }
            else
            {
                article_Id = 0;
            }
            IsFeaturedVideo = chkfeatured.Checked;
            IsLiveVideo = chkLive.Checked;

            if (errmsg.Length > 0)
            {
                errormsg.Text = "<font color='red'><ul>" + errmsg + "</ul></font>";
            }
            else
            {
                int r = DAL.add_a_video(video_name, video_url, video_description, article_Id, IsFeaturedVideo, IsLiveVideo, user_Id);
                if (r > 0)
                {
                    saveImages(photoUploader, video_name);

                    txtvideoname.Text = "";
                    txtvideourl.Text = "";
                    txtvideodescription.Text = "";
                    errmsg = "";
                    bind_videogallary();
                }

            }
        }
        catch (Exception ex)
        {
            errormsg.Text = "<font color='red'><ul><li>" + ex.Message + "</li></ul></font>";
        }
    }
    protected void gdvvideogallary_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvvideogallary.PageIndex = e.NewPageIndex;
        bind_videogallary();
    }
    protected void gdvvideogallary_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gdvvideogallary.EditIndex = e.NewEditIndex;
        bind_videogallary();
    }
    protected void gdvvideogallary_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gdvvideogallary.EditIndex =-1;
        bind_videogallary();
    }
    protected void gdvvideogallary_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int video_Id = Convert.ToInt32(e.Keys["video_Id"].ToString());
            int r = DAL.delete_a_video(video_Id);

            if (r > 0)
            {
                bind_videogallary();
            }
        }
        catch (Exception ex)
        {
            errormsg.Text = "<font color='red'><ul><li>" + ex.Message + "</li></ul></font>";
        }
    }
    protected void gdvvideogallary_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            int video_Id = Convert.ToInt32(e.Keys["video_Id"].ToString());
            string video_name=((TextBox)gdvvideogallary.Rows[e.RowIndex].FindControl("txtvideoname2")).Text;
            string video_url = ((TextBox)gdvvideogallary.Rows[e.RowIndex].FindControl("txtvideourl2")).Text;
            string video_description = ((TextBox)gdvvideogallary.Rows[e.RowIndex].FindControl("txtvideodescription2")).Text;
            bool IsFeatured = ((CheckBox)gdvvideogallary.Rows[e.RowIndex].FindControl("chkfeaturedvideo2")).Checked;
            bool IsLive = ((CheckBox)gdvvideogallary.Rows[e.RowIndex].FindControl("chklivevideo2")).Checked;

            int r=DAL.update_a_video(video_Id,video_name,video_url,video_description,0,IsFeatured,IsLive,user_Id);

            if(r>0)
            {
                 gdvvideogallary.EditIndex =-1;
                bind_videogallary();
            }
        }
        catch (Exception ex)
        {
             errormsg.Text = "<font color='red'><ul><li>" + ex.Message + "</li></ul></font>";
        }
    }


    private void GenerateImages(int w, int h, Stream sourcePath, string targetPath)
    {
        using (var image = System.Drawing.Image.FromStream(sourcePath))
        {
            var newWidth = w;
            var newHeight = h;
            var thumbnailImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);
            thumbnailImg.Save(targetPath, image.RawFormat);
        }
    }

    private void saveImages(FileUpload photoUploader, string filename)
    {
        //string filename = Path.GetFileName(photoUploader.PostedFile.FileName);
        string targetPath = Server.MapPath("~/video-gallary/" + filename + ".jpg");
        Stream strm = photoUploader.PostedFile.InputStream;
        var targetFile = targetPath;
        //Based on scalefactor image size will vary
        GenerateImages(150, 150, strm, targetFile);

    }
}