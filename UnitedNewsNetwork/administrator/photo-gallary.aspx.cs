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

public partial class administrator_photo_gallary : System.Web.UI.Page
{
    string photo_name;
    string photo_description = "";
    string photo_url = "";
    bool IsFeaturedPhoto = false;
    bool IsLivePhoto = false;

    int article_Id = 0;
    Guid user_Id;

    protected void bind_photogallary()
    {
        gdvphotogallary.DataSource = DAL.get_all_gallary_photos();
        gdvphotogallary.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind_photogallary();
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            user_Id = (Guid)Membership.GetUser(User.Identity.Name).ProviderUserKey;
            string errmsg = "";
           
            if (string.IsNullOrEmpty(txtphotodescription.Text.Trim()))
            {
                errmsg = "<li>Please Enter Photo Description</li>";
            }
            else
            {
                photo_description = txtphotodescription.Text.Trim();
            }
            if (photoUploader.HasFile)
            {
                photo_name = photoUploader.FileName;
                photo_url = Server.MapPath("~/photo-gallary/") + photo_name;
            }
            else
            {
                errmsg = "<li>Please Select Photo</li>";
            }

            if (Request.QueryString["article"] != null)
            {
                article_Id = Convert.ToInt32(Request.QueryString["article"].ToString());
            }
            else
            {
                article_Id = 0;
            }
            IsFeaturedPhoto = chkfeatured.Checked;
            IsLivePhoto = chkLive.Checked;

            if (errmsg.Length > 0)
            {
                errormsg.Text = "<font color='red'><ul>"+errmsg+"</ul></font>";
            }
            else
            {
                int r = DAL.add_a_gallary_photo(photo_name, photo_description, article_Id, IsFeaturedPhoto, IsLivePhoto, user_Id);
                if (r > 0)
                {
                    if (photoUploader.HasFile)
                    {
                        saveImages(photoUploader);
                        saveThumbnails(photoUploader);
                    }
                    
                    txtphotodescription.Text = "";
                    errmsg = "";
                    bind_photogallary();
                }
               
            }
        }
        catch (Exception ex)
        {
            errormsg.Text = "<font color='red'><ul><li>" + ex.Message + "</li></ul></font>";
        }

    }
    protected void gdvphotogallary_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvphotogallary.PageIndex = e.NewPageIndex;
        bind_photogallary();
    }
    protected void gdvphotogallary_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gdvphotogallary.EditIndex = e.NewEditIndex;
        bind_photogallary();
    }
    protected void gdvphotogallary_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gdvphotogallary.EditIndex = -1;
        bind_photogallary();
    }
    protected void gdvphotogallary_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int photo_Id = Convert.ToInt32(e.Keys["photo_Id"].ToString());
            int r = DAL.delete_a_gallary_photo(photo_Id);

            if (r > 0)
            {
                bind_photogallary();
            }
        }
        catch (Exception ex)
        {
            errormsg.Text = "<font color='red'><ul><li>" + ex.Message + "</li></ul></font>";
        }
    }
    protected void gdvphotogallary_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            int photo_Id = Convert.ToInt32(e.Keys["photo_Id"].ToString());
            string photo_description = ((TextBox)gdvphotogallary.Rows[e.RowIndex].FindControl("txtphotodescription2")).Text;
     
            bool IsFeatured = ((CheckBox)gdvphotogallary.Rows[e.RowIndex].FindControl("chkfeaturedphoto2")).Checked;
            bool IsLive = ((CheckBox)gdvphotogallary.Rows[e.RowIndex].FindControl("chklivephoto2")).Checked;

            int r = DAL.update_a_gallary_photo(photo_Id,photo_description, 0, IsFeatured, IsLive, user_Id);

            if (r > 0)
            {
                gdvphotogallary.EditIndex = -1;
                bind_photogallary();
            }
        }
        catch (Exception ex)
        {
            errormsg.Text = "<font color='red'><ul><li>" + ex.Message + "</li></ul></font>";
        }
    }


    private void saveThumbnails(FileUpload photoUploader)
    {
        string filename = Path.GetFileName(photoUploader.PostedFile.FileName);
        string targetPath = Server.MapPath("~/photo-gallary/thumbnails/" + filename);
        Stream strm = photoUploader.PostedFile.InputStream;
        var targetFile = targetPath;
        //Based on scalefactor image size will vary
        GenerateImages(80, 50, strm, targetFile);

    }


    private void saveImages(FileUpload photoUploader)
    {
        string filename = Path.GetFileName(photoUploader.PostedFile.FileName);
        string targetPath = Server.MapPath("~/photo-gallary/" + filename);
        Stream strm = photoUploader.PostedFile.InputStream;
        var targetFile = targetPath;
        //Based on scalefactor image size will vary
        GenerateImages(400, 250, strm, targetFile);

    }


    private void GenerateImages(int w,int h,Stream sourcePath, string targetPath)
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
   
}