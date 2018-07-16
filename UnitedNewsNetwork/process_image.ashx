<%@ WebHandler Language="C#" Class="process_image" %>

using System;
using System.Web;

public class process_image : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        if (context.Request.QueryString["article"] != null)    
        {

            int article = Convert.ToInt32(context.Request.QueryString["article"].ToString());
            byte[] photo = DAL.get_a_article_photo(article);
            context.Response.BinaryWrite(photo);
        }

       
        
       /* if (context.Request.QueryString["placeId"] != null)
        {

            int placeId = Convert.ToInt32(context.Request.QueryString["placeId"].ToString());
            byte[] photo = dataHandling.get_a_place_photo(placeId);
            context.Response.BinaryWrite(photo);
        }

        if (context.Request.QueryString["vehicleId"] != null)
        {

            int vehicleId = Convert.ToInt32(context.Request.QueryString["vehicleId"].ToString());
            byte[] photo = dataHandling.get_a_vehicle_photo(vehicleId);
            context.Response.BinaryWrite(photo);
        }
        if (context.Request.QueryString["testimonial"] != null)
        {

            int testimonialId = Convert.ToInt32(context.Request.QueryString["testimonial"].ToString());
            byte[] photo = dataHandling.get_a_testimonial_photo(testimonialId);
            context.Response.BinaryWrite(photo);
        }*/
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}