using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Security;

public partial class register : System.Web.UI.Page
{
    string firstname = "";
    string lastname = "";
    string address = "";
    string city = "";
    string state = "";
    string country = "";
    string email = "";
    string mobileno = "";
    string username = "";
    string password = "";
    string path = "";
    byte[] photo;

    Guid user_Id;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnregister_Click(object sender, EventArgs e)
    {
        string errmsg = "";
        try
        {


            
            if (Session["CAPTCHA"] != null)
            {

                if (txtcaptcha.Text.Trim() == Session["CAPTCHA"].ToString())
                {
                    if (chkterms.Checked == true)
                    {
                        if (txtfirstname.Text.Trim().Length <=0)
                        {
                            errmsg += "<li>Please Enter First Name</li>";
                        }
                        else
                        {
                            firstname = txtfirstname.Text.Trim();
                        }
                        lastname = txtlastname.Text.Trim();

                        if (txtaddress.Text.Trim().Length <=0)
                        {
                            errmsg += "<li>Please Enter Address</li>";
                        }
                        else
                        {
                            address = txtaddress.Text.Trim();
                        }

                        if (txtcity.Text.Trim().Length <=0)
                        {
                            errmsg += "<li>Please Enter City</li>";
                        }
                        else
                        {
                            city = txtcity.Text.Trim();
                        }

                        if (txtstate.Text.Trim().Length <=0)
                        {
                            errmsg += "<li>Please Enter State</li>";
                        }
                        else
                        {
                            state = txtstate.Text.Trim();
                        }

                        if (txtcountry.Text.Trim().Length <=0)
                        {
                            errmsg += "<li>Please Enter City</li>";
                        }
                        else
                        {
                            country = txtcountry.Text.Trim();
                        }




                        if (txtmobileno.Text.Trim().Length <=0)
                        {
                            errmsg += "<li>Please Enter Your Mobile No.</li>";
                        }
                        else
                        {
                            mobileno = txtmobileno.Text.Trim();
                        }

                        if (txtemail.Text.Trim().Length <=0)
                        {
                            errmsg += "<li>Please Enter Your Email.</li>";
                        }
                        else
                        {
                            email = txtemail.Text.Trim();
                        }

                        if (txtusername.Text.Trim().Length <=0)
                        {
                            errmsg += "<li>Please Enter Your UserName.</li>";
                        }
                        else
                        {
                            username = txtusername.Text.Trim();
                        }
                        if (txtpassword.Text.Trim().Length <=0)
                        {
                            errmsg += "<li>Please Enter Your Password.</li>";
                        }
                        else
                        {
                            password = txtpassword.Text.Trim();
                        }
                        if (photoUploader != null && photoUploader.HasFile)
                        {
                            int len = photoUploader.PostedFile.ContentLength;
                            photo = new byte[len];
                            photoUploader.PostedFile.InputStream.Read(photo, 0, len);
                        }
                        else
                        {
                            path = Server.MapPath("~/images/user.gif");
                            FileStream fs = new FileStream(path, FileMode.Open);
                            int len = Convert.ToInt32(fs.Length);
                            photo = new byte[len];
                            fs.Read(photo, 0, len);

                        }

                        if (errmsg.Trim().Length > 0)
                        {
                            lblerror.Text = "<font color='red'><ul>" + errmsg + "</ul></font>";
                        }
                        else
                        {
                           
                            MembershipUser user = Membership.CreateUser(username, password, email);
                            if (user != null)
                            {
                                user_Id = (Guid)user.ProviderUserKey;
                                if (user != null)
                                {

                                    int r = DAL.add_a_subscriber(user_Id, firstname, lastname, photo, address, city, state, country, mobileno, email, username, password, true);

                                    if (r > 0)
                                    {

                                        Roles.AddUserToRole(username, "subscriber");
                                        Response.Redirect("thanks.aspx?page=registration");

                                    }
                                }

                            }

                            
                        }
                    }
                    else
                    {
                        lblerror.Text = "<font color='red'>Please check the terms and conditions !</font>";
                    }
                }
                else
                {
                    lblerror.Text = "<font color='red'>Please Enter Correct Captcha Code !</font>";
                }
            }
            else
            {
                lblerror.Text = "<font color='red'>Please Enter Captcha Code !</font>";
            }
        }
        catch (Exception ex)
        {
            lblerror.Text = "<font color='red'>" + ex.Message + "</font>";
        }
    }
}