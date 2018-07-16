<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="video-gallery.aspx.cs" Inherits="video_gallary"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
       .player
       {
           width:63.5%;
           float:left;
           border:1px solid #d1d1d1;
           padding:2px;
       }
       
       .videos
       {
           width:35%;
           float:right;
           border:1px solid #d1d1d1;
       }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
 <div class="box">

    <div id="video-player" class="player">
      <asp:Literal ID="lblvideoplayer" runat="server"><iframe width="420" height="315" src="https://www.youtube.com/embed/huoxh0gs0wo" frameborder="0" allowfullscreen></iframe></asp:Literal>
    </div>
    <div id="video-listing" class="videos">
       <div id="multilines">

                                                                                    <asp:Repeater ID="rptvideos" runat="server">
                                                                                        <HeaderTemplate>
                                                                                               <ul class="newsticker">
                                                                                         </HeaderTemplate>

                                                                                          <ItemTemplate>
                                                                                                             
                                                                                                        <li>
                                                                                                         <a href='?video=<%#Eval("video_Id") %>&title=<%#Eval("video_name") %>'>
                                                                                                             <img alt='<%#Eval("video_name")%>' src='<%#"video-gallary/"+Eval("video_name")+".jpg" %>' height="50px" width="50px" align="left" vspace="5px" hspace="5px"/>
                                                                                                          
                                                                                                             <%#Eval("video_name") %> 
                                                                                                          </a>
                                                                                                        </li>
                                                                                                  
                                      
                                                                                           </ItemTemplate>

                                                                                           <FooterTemplate>
                                                                                              </ul>

                                                                               <div class="controls"> <a class="prev-button" href="#"><img src="images/prev.png"/></a>  <a class="stop-button" href="#"><img src="images/stop.png"/></a> <a class="start-button" href="#"><img src="images/start.gif"/></a><a class="next-button" href="#"><img src="images/next.png"/></a> </div>

                                                                                <script type="text/javascript" src="js/newsTicker.js"></script> 
                                                                                <script type="text/javascript">
                                                                                                var multilines = $('#multilines .newsticker').newsTicker({
                                                                                                 row_height: 100,
               						 speed: 3000,
                					 prevButton: $('#multilines .prev-button'),
               						 nextButton: $('#multilines .next-button'),
                					 stopButton: $('#multilines .stop-button'),
                					 startButton: $('#multilines .start-button'),
            						});

            						var oneliner = $('#oneliner .newsticker').newsTicker({
                					row_height: 44,
               						max_rows: 1,
                					time:6000,
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
    		      
<div class="box">
 <asp:Literal ID="lblvideodescription" runat="server"></asp:Literal>
</div>

 
</asp:Content>

