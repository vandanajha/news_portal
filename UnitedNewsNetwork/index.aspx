<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
        <!-- bjqs.css contains the *essential* css needed for the slider to work -->
    <link rel="stylesheet" href="css/bjqs.css" type="text/css"/>

   

    <!-- demo.css contains additional styles used to set up this demo page - not required for the slider --> 
    <link rel="stylesheet" href="css/demo.css" type="text/css"/>

    <!-- load jQuery and the plugin -->
 
    <script type="text/javascript" src="js/bjqs-1.3.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

                                      <div id="left-content-top">

                                                     <div id="left-content-top-left">
                                                     <!--  Outer wrapper for presentation only, this can be anything you like -->
                                                          <div id="banner-fade">

                                                            <!-- start Basic Jquery Slider -->
                                                                 <ul class="bjqs">
                                                     <asp:Repeater ID="lstmainstory" runat="server">
                                                      
                                                           <ItemTemplate>

                                                                 <li>
                                                                    <a href='story-of-article.aspx?article=<%#Eval("article_Id") %>&category=<%#Eval("article_category_Id") %>'>
                                                                        <img src='process_image.ashx?article=<%#Eval("article_Id") %>' title='<%#HttpContext.Current.Server.HtmlEncode(Eval("article_title").ToString())%>'/>
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
                                                                            height: 550,
                                                                            width: 620,
                                                                            responsive: true
                                                                        });

                                                                    });
                                                               </script>
       

                                                       </div>

                                                       <div id="left-content-top-right">
                                                                   <div class="box">
                                                                   <div class="title">
                                                                            Latest News
                                                                   </div>
                                                                   <div class="box">
                                                                             <div id="multilines">

                                                                                    <asp:Repeater ID="rptlatest" runat="server">
                                                                                        <HeaderTemplate>
                                                                                               <ul class="newsticker">
                                                                                         </HeaderTemplate>

                                                                                          <ItemTemplate>
                                                                                                
                                                                                                         <li><img src='process_image.ashx?article=<%#Eval("article_Id") %>' alt='<%#Eval("article_title") %>' height="50px" width="50px" align="left" hspace="5px" vspace="5px"/><a href='story-of-article.aspx?article=<%#Eval("article_Id") %>&category=<%#Eval("article_category_Id") %>'><%#Eval("article_title") %> </a></li>
                                                                                                  
                                      
                                                                                           </ItemTemplate>

                                                                                           <FooterTemplate>
                                                                                              </ul>

                                                                               <div class="controls"> <a class="prev-button" href="#"><img src="images/prev.png"/></a>  <a class="stop-button" href="#"><img src="images/stop.png"/></a> <a class="start-button" href="#"><img src="images/start.gif"/></a><a class="next-button" href="#"><img src="images/next.png"/></a> </div>

                                                                                <script type="text/javascript" src="js/newsTicker.js"></script> 
                                                                                <script type="text/javascript">
                                                                                                var multilines = $('#multilines .newsticker').newsTicker({
                                                                                                 row_height: 100,
               						 speed: 800,
                					 prevButton: $('#multilines .prev-button'),
               						 nextButton: $('#multilines .next-button'),
                					 stopButton: $('#multilines .stop-button'),
                					 startButton: $('#multilines .start-button'),
            						});

            						var oneliner = $('#oneliner .newsticker').newsTicker({
                					row_height: 44,
               						max_rows: 1,
                					time: 5000,
                					nextButton: $('#oneliner .header')
            						});

            						// Pause newsTicker on .header hover
            						$('#oneliner .header').hover(function() {
                						oneliner.newsTicker('pause');
            							}, function() {
                						oneliner.newsTicker('unpause');
            						});
        					</script>
                                                                                           </FooterTemplate>

                                                                                        </asp:Repeater>
                                                                                
                                                                                   
                                                                                  
                                                                               

                                                       </div>
                                                    </div>
                                                  </div>

                                                  </div>

                                                 </div>

                                                 <div id="left-content-bottom">

                                                      <asp:DataList ID="lstcategory" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" OnItemDataBound="ShowArticles" Width="100%" ItemStyle-VerticalAlign="Top" RepeatLayout="Flow">
                                                           <ItemTemplate>
                                                                                <div class="headline">
                                                                                   <div class="box">
                                                                                          <div class="title"> <asp:Literal ID="lblarticlecategory" runat="server" Text='<%#Eval("article_category_Id") %>' Visible="false"></asp:Literal><%#Eval("article_category_name") %>&raquo;</div>
                                                                                           <div class="box">

                                                                                                   <asp:Repeater ID="rptheadlines" runat="server">
                                                                                                        <HeaderTemplate>
                                                                                                            <ul class="list">
                                                       
                                                                                                         </HeaderTemplate>

                                                                                                         <ItemTemplate>
                                                                                                                     <li> <img src='process_image.ashx?article=<%#Eval("article_Id") %>' alt="pic1" height="50px" width="50px" align="left" vspace="5px" hspace="10px"/><%#Eval("article_title") %>  <a href='story-of-article.aspx?article=<%#Eval("article_Id") %>&category=<%#Eval("article_category_Id") %>'>Read more...</a></li>
                                                                                    		       
                                                                                                                     
                                                                                                                    
                                                                                                          </ItemTemplate>

                                                                                                          <FooterTemplate>
                                                                                                               </ul>
                                                                                                          </FooterTemplate>
                                                                                                       </asp:Repeater>
                                                                                                  
                                                                                    		         
                                                                                    		       
                                                                                                  </div>
                                                                                            </div>
                                                                                         </div>
                                                                </ItemTemplate>
                               
                                   
      
                                                           </asp:DataList>
                                                                                    		
                                                                               	                	

                                                             		                       
                                                  </div>
</asp:Content>

