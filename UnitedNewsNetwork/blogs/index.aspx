<%@ Page Title="" Language="C#" MasterPageFile="~/blogs/blogs.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="blogs_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
    <!--editor's pick-->
    <link rel="stylesheet" type="text/css" media="all" href="css/styles.css"/>    
    <script type="text/javascript" src="js/responsiveCarousel.min.js"></script>

    
    <link href="css/scroller.css" rel="stylesheet" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="top-content">
              <div id="left-top-content">
                 <div class="box">
                 <div class="title">Editor's Pick Blogs</div>
               
                 <div class="slidernav">
                           <div id="navbtns" class="clearfix">
                             <a href="#" class="previous"><img src="images/prev.jpg"></a>
                             <a href="#" class="next"><img src="images/next.jpg"></a>
                           </div>
                 </div>
    
                 <div class="crsl-items" data-navigation="navbtns">

                   <div class="crsl-wrap">

                     <div class="crsl-item">
                         <div class="thumbnail">
                            <img src="images/thumb01.jpg" alt="nyc subway">
                            <span class="postdate">Feb 16, 2014</span>
                         </div>
          
                         <h3><a href="#">Lorem Ipsum Dolor Sit</a></h3>
          
                         <p>Suspendisse laoreet eu tortor vel dapibus. Etiam auctor nisl mattis, ornare nibh eu, lobortis leo. Sed congue mi eget velit dictum, id dictum massa tempus. Cras lobortis lectus neque. Fusce aliquet mauris ac bibendum pharetra.</p>
          
                         <p class="readmore"><a href="#">Read More &raquo;</a></p>
                     </div><!-- post #1 -->
        
                     <div class="crsl-item">
                       <div class="thumbnail">
                         <img src="images/thumb02.jpg" alt="danny antonucci">
                         <span class="postdate">Feb 19, 2014</span>
                      </div>
          
                      <h3><a href="#">A Look Back over A.K.A Cartoon</a></h3>
          
                      <p>Vestibulum in venenatis velit. Praesent commodo eget purus sed interdum. Curabitur faucibus purus ut erat fermentum posuere. Suspendisse blandit viverra sagittis. Nullam cursus scelerisque lorem ut ornare.</p>
          
                      <p class="readmore"><a href="#">Read More &raquo;</a></p>
                    </div><!-- post #2 -->
        
                     <div class="crsl-item">
                       <div class="thumbnail">
                         <img src="images/thumb03.jpg" alt="watercolor paints">
                         <span class="postdate">Feb 23, 2014</span>
                       </div>
          
                       <h3><a href="#">Watercoloring for Beginners</a></h3>
          
                      <p>Cras eget interdum nunc. Nam suscipit congue augue, id interdum risus adipiscing nec. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla non diam id nisi tempus sodales.</p>
          
                      <p class="readmore"><a href="#">Read More &raquo;</a></p>
                    </div><!-- post #3 -->
        
                     <div class="crsl-item">
                       <div class="thumbnail">
                         <img src="images/thumb04.jpg" alt="apple ipod classic photo">
                         <span class="postdate">Mar 02, 2014</span>
                       </div>
          
                       <h3><a href="#">Classic iPods are Back!</a></h3>
          
                       <p>Phasellus condimentum enim nisl, volutpat dapibus turpis euismod nec. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Donec id elit lorem. Vivamus at eros elit. Nullam cursus euismod purus.</p>
          
                       <p class="readmore"><a href="#">Read More &raquo;</a></p>
                    </div><!-- post #4 -->
        
                     <div class="crsl-item">
                       <div class="thumbnail">
                            <img src="images/thumb05.jpg" alt="web design magazines">
                            <span class="postdate">Mar 11, 2014</span>
                       </div>
          
                       <h3><a href="#">The 10 Best Web Design Magazines</a></h3>
          
                       <p>Morbi quis tempus leo, eget vestibulum quam. Pellentesque ac orci urna. Proin vitae neque vel metus pulvinar luctus vitae eu nulla.</p>
          
                       <p class="readmore"><a href="#">Read More &raquo;</a></p>
                    </div><!-- post #5 -->
                 
                   </div><!-- @end .crsl-wrap -->
                 
                 </div><!-- @end .crsl-items -->
    
  
           <script type="text/javascript">
                $(function(){
                     $('.crsl-items').carousel({
                        visible: 3,
                        itemMinWidth: 180,
                        itemEqualHeight: 370,
                        itemMargin: 9,
                });
  
                $("a[href=#]").on('click', function(e) {
                e.preventDefault();
                });
            });
        </script>
                </div>
              </div>

              <div id="right-top-content">
                   <div class="box">

                      

                      <div class="title">Most Read Blogs</div>
                      <div class="box">
                         <ul class="list">

                           <li>
                              <img src="images/thumb01.jpg" alt="" width="50px" height="50px" align="left"/>
                               <h2><a href="#">Title Of the blog goes here Title Of the blog goes here Title Of the blog goes here</a></h2>
                               <a href="#"> By Raghwendra Pratap Singh</a>
                           </li>

                            <li>
                              <img src="images/thumb02.jpg" alt="" width="50px" height="50px" align="left"/>
                                <h2><a href="#">Title Of the blog goes here Title Of the blog goes here Title Of the blog goes here</a></h2>
                               <a href="#"> By Prasant Ojha</a>
                           </li>

                           <li>
                              <img src="images/thumb03.jpg" alt="" width="50px" height="50px" align="left"/>
                               <h2><a href="#">Title Of the blog goes here Title Of the blog goes here Title Of the blog goes here</a></h2>
                               <a href="#"> By Author</a>
                           </li>

                            <li>
                              <img src="images/thumb04.jpg" alt="" width="50px" height="50px" align="left"/>
                                <h2><a href="#">Title Of the blog goes here Title Of the blog goes here Title Of the blog goes here</a></h2>
                               <a href="#"> By Author</a>
                           </li>

                          <li>
                              <img src="images/thumb05.jpg" alt="" width="50px" height="50px" align="left"/>
                                <h2><a href="#">Title Of the blog goes here Title Of the blog goes here Title Of the blog goes here</a></h2>
                               <a href="#"> By Author</a>
                           </li>
                          <li>
                              <img src="images/thumb01.jpg" alt="" width="50px" height="50px" align="left"/>
                                <h2><a href="#">Title Of the blog goes here Title Of the blog goes here Title Of the blog goes here</a></h2>
                               <a href="#"> By Author</a>
                           </li>

                         <li>
                              <img src="images/thumb02.jpg" alt="" width="50px" height="50px" align="left"/>
                               <h2><a href="#">Title Of the blog goes here Title Of the blog goes here Title Of the blog goes here</a></h2>
                               <a href="#"> By Author</a>
                           </li>
                           

                         </ul> 
                             
                      </div>

                    
              </div>
               
             </div>

          </div>
           <div id="bottom-content">
             <table width="25%">
                 <tr>
                     <td>
                         <div class="box">
                             <div class="title">Business</div>
                             <div class="box">
                                 <img src="" alt="" height="150px" width="150px" align="center"/>
                             </div>
                         </div>
                     </td>
                 </tr>
                 <tr>
                     <td>
                          <div class="box">
                         <ul class="list">

                           <li>
                              <img src="images/thumb01.jpg" alt="" width="50px" height="50px" align="left"/>
                               <h2><a href="#">Title Of the blog goes here Title Of the blog goes here Title Of the blog goes here</a></h2>
                               <a href="#"> By Raghwendra Pratap Singh</a>
                           </li>

                            <li>
                              <img src="images/thumb02.jpg" alt="" width="50px" height="50px" align="left"/>
                                <h2><a href="#">Title Of the blog goes here Title Of the blog goes here Title Of the blog goes here</a></h2>
                               <a href="#"> By Prasant Ojha</a>
                           </li>

                           <li>
                              <img src="images/thumb03.jpg" alt="" width="50px" height="50px" align="left"/>
                               <h2><a href="#">Title Of the blog goes here Title Of the blog goes here Title Of the blog goes here</a></h2>
                               <a href="#"> By Author</a>
                           </li>

                            <li>
                              <img src="images/thumb04.jpg" alt="" width="50px" height="50px" align="left"/>
                                <h2><a href="#">Title Of the blog goes here Title Of the blog goes here Title Of the blog goes here</a></h2>
                               <a href="#"> By Author</a>
                           </li>

                          
                           

                         </ul> 
                             
                      </div>
                         <p>Read More...</p>
                     </td>
                 </tr>
             </table>

              <table width="25%">
                 <tr>
                     <td>
                         <div class="box">
                             <div class="title">Political</div>
                             <div class="box">
                                 <img src="" alt="" height="150px" width="150px" align="center"/>
                             </div>
                         </div>
                     </td>
                 </tr>
                 <tr>
                     <td>
                          <div class="box">
                         <ul class="list">

                           <li>
                              <img src="images/thumb01.jpg" alt="" width="50px" height="50px" align="left"/>
                               <h2><a href="#">Title Of the blog goes here Title Of the blog goes here Title Of the blog goes here</a></h2>
                               <a href="#"> By Raghwendra Pratap Singh</a>
                           </li>

                            <li>
                              <img src="images/thumb02.jpg" alt="" width="50px" height="50px" align="left"/>
                                <h2><a href="#">Title Of the blog goes here Title Of the blog goes here Title Of the blog goes here</a></h2>
                               <a href="#"> By Prasant Ojha</a>
                           </li>

                           <li>
                              <img src="images/thumb03.jpg" alt="" width="50px" height="50px" align="left"/>
                               <h2><a href="#">Title Of the blog goes here Title Of the blog goes here Title Of the blog goes here</a></h2>
                               <a href="#"> By Author</a>
                           </li>

                            <li>
                              <img src="images/thumb04.jpg" alt="" width="50px" height="50px" align="left"/>
                                <h2><a href="#">Title Of the blog goes here Title Of the blog goes here Title Of the blog goes here</a></h2>
                               <a href="#"> By Author</a>
                           </li>

                          
                           

                         </ul> 
                             
                      </div>
                         <p>Read More...</p>
                     </td>
                 </tr>
             </table>
           </div>
          
</asp:Content>

