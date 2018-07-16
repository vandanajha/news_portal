using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class administrator_list_of_subscribers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gdvsubscribers.DataSource = DAL.get_all_subscribers();
            gdvsubscribers.DataBind();
        }
    }
}