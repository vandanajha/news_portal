<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="photo-gallery.aspx.cs" Inherits="photo_gallary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
        <!-- bjqs.css contains the *essential* css needed for the slider to work -->
    <link rel="stylesheet" href="css/bjqs.css" type="text/css"/>

   

    <!-- demo.css contains additional styles used to set up this demo page - not required for the slider --> 
    <link rel="stylesheet" href="css/demo.css" type="text/css"/>

    <!-- load jQuery and the plugin -->
 
    <script type="text/javascript" src="js/bjqs-1.3.min.js"></script>

    <script type="text/javascript" src="js/jquery-ui-1.9.0.custom.min.js" ></script>
<script type="text/javascript" src="js/jquery-ui-tabs-rotate.js" ></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#featured").tabs({ fx: { opacity: "toggle"} }).tabs("rotate", 5000, true);
    });
</script>

<style type="text/css">
    #featured{ 
	width:400px; 
	padding-right:250px; 
	position:relative; 
	border:5px solid #ccc; 
	height:250px; overflow:hidden;
	background:#fff;
}
#featured ul.ui-tabs-nav{ 
	position:absolute; 
	top:0; left:400px; 
	list-style:none; 
	padding:0; margin:0; 
	width:250px; height:250px;
	overflow:auto;
	overflow-x:hidden;
}
#featured ul.ui-tabs-nav li{ 
	padding:1px 0; padding-left:13px;  
	font-size:12px; 
	color:#666; 
}
#featured ul.ui-tabs-nav li img{ 
	float:left; margin:2px 5px; 
	background:#fff; 
	padding:2px; 
	border:1px solid #eee;
}
#featured ul.ui-tabs-nav li span{ 
	font-size:11px; font-family:Verdana; 
	line-height:18px; 
}
#featured li.ui-tabs-nav-item a{ 
	display:block; 
	height:60px; text-decoration:none;
	color:#333;  background:#fff; 
	line-height:20px; outline:none;
}
#featured li.ui-tabs-nav-item a:hover{ 
	background:#f2f2f2; 
}
#featured li.ui-tabs-selected, #featured li.ui-tabs-active{ 
	background:url('images/selected-item.gif') top left no-repeat;  
}
#featured ul.ui-tabs-nav li.ui-tabs-selected a, #featured ul.ui-tabs-nav li.ui-tabs-active a{ 
	background:#ccc; 
}
#featured .ui-tabs-panel{ 
	width:400px; height:250px; 
	background:#999; position:relative;
}
#featured .ui-tabs-panel .info{ 
	position:absolute; 
	bottom:0; left:0; 
	height:70px; 
	background: url('images/transparent-bg.png'); 
}
#featured .ui-tabs-panel .info a.hideshow{
	position:absolute; font-size:11px; font-family:Verdana; color:#f0f0f0; right:10px; top:-20px; line-height:20px; margin:0; outline:none; background:#333;
}
#featured .info h2{ 
	font-size:1.2em; font-family:Georgia, serif; 
	color:#fff; padding:5px; margin:0; font-weight:normal;
	overflow:hidden; 
}
#featured .info p{ 
	margin:0 5px; 
	font-family:Verdana; font-size:11px; 
	line-height:15px; color:#f0f0f0;
}
#featured .info a{ 
	text-decoration:none; 
	color:#fff; 
}
#featured .info a:hover{ 
	text-decoration:underline; 
}
#featured .ui-tabs-hide{ 
	display:none; 
}
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
  <div class="box">
  <div class="title">Today's Photos</div>
 
                                                   <!--  Outer wrapper for presentation only, this can be anything you like -->
                                                          <div id="banner-fade">

                                                            <!-- start Basic Jquery Slider -->
                                                                 <ul class="bjqs">
                                                     <asp:Repeater ID="rptphotogallery" runat="server">
                                                      
                                                           <ItemTemplate>

                                                                 <li>
                                                                  
                                                                        <img alt="" src='<%#"photo-gallary/"+Eval("photo_name") %>' title='<%#HttpContext.Current.Server.HtmlEncode(Eval("photo_description").ToString())%>'/>
                                                                    </a>
                                                               </li>
  		                     
                                             
                                                            </ItemTemplate>
                                                            
                                                    </asp:Repeater>
                                                                
                                                                 </ul>
                                                                       <!-- end Basic jQuery Slider -->

                                                                </div>
                                                                 <!-- End outer wrapper -->

                                                                <script class="secret-source" type="text/javascript">
                                                                    jQuery(document).ready(function ($) {

                                                                        $('#banner-fade').bjqs({
                                                                            height:250,
                                                                            width: 400,
                                                                            responsive: true
                                                                        });

                                                                    });
                                                               </script>
 </div>
 <br />

<br />

<hr />
 <div class="box">
    <div class="title">Featured Photos</div>
    
  <div id="featured">

      <asp:Repeater ID="rptfeatured" runat="server">
        <HeaderTemplate>
          <ul class="ui-tabs-nav">
        </HeaderTemplate>
        <ItemTemplate>
            
             <li class="ui-tabs-nav-item" id='<%#"nav-fragment-"+Eval("photo_Id")%>'><a href='<%#"#fragment-"+Eval("photo_Id")%>'><img src='<%#"photo-gallary/thumbnails/"+Eval("photo_name")%>' alt=""/><span><%#Eval("photo_name")%></span></a></li>
        </ItemTemplate>

        <FooterTemplate>
          </ul>
        </FooterTemplate>
     </asp:Repeater>
     <asp:Repeater ID="rptthumbnails" runat="server">
        <ItemTemplate>
	      <div id='<%#"fragment-"+Eval("photo_Id")%>' class="ui-tabs-panel" style="">
			
             <img src='<%#"photo-gallary/"+Eval("photo_name")%>' alt=""/>
			  <div class="info" >
				<h2><a href="#" ><%#Eval("photo_name")%></a></h2>
				<p><%#Eval("photo_description")%></p>
			  </div>
	      </div>
          </ItemTemplate>
       </asp:Repeater>

       
	      
			
	     

 </div>
   
   
  



        
   


    

        
            
                
            

            

            
            


        

 </div>


</asp:Content>

