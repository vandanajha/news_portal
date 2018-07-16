using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class login : System.Web.UI.Page
{
    string username = "";
    string password = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            
            string errmsg = "";
            if (String.IsNullOrEmpty(txtusername.Text.Trim()))
            {
                errmsg += "<li>Please Enter User Name</li>";
            }
            else
            {
                username = txtusername.Text;
            }

            if (String.IsNullOrEmpty(txtpassword.Text.Trim()))
            {
                errmsg += "<li>Please Enter Password</li>";
            }
            else
            {
                password = txtpassword.Text;
            }

            if (errmsg.Length > 0)
            {
                errormsg.Text = "<font color='red'><ul>" + errmsg + "</ul></font>";
            }
            else
            {
                if (Membership.ValidateUser(username, password) == true)
                {
                    FormsAuthentication.RedirectFromLoginPage(username, cboxRemember.Checked);
                }
                else
                {
                    errormsg.Text = "<font color='red'>Please Login With Valid Credentials</font>";
                }
            }
        }
        catch (Exception ex)
        {
            errormsg.Text = "<font color='red'><ul>" + ex.Message + "</ul></font>";
        }
    }
}