<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="story-of-article.aspx.cs" Inherits="artical_story2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
      .art-sec h1 {
padding-bottom: 7px;
text-align: left;
font-size: 27px;
line-height: 34px;
text-align:justify;
}


.content
{
    text-align:justify;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div id="artical-story" class="box">
        <asp:Repeater ID="rptarticles" runat="server">
           <HeaderTemplate>
              
           </HeaderTemplate>

           <ItemTemplate>
              <div class="title">Edited By :<%#Eval("article_source")%>&nbsp;| &nbsp;<%#String.Format("{0:dddd, MMMM d, yyyy}",Eval("date_added"))%></div>
              <div class="box art-sec">
                 <h2><%#Eval("article_title") %></h2>
              </div>
               <div class="box">
                  
                  <img src='process_image.ashx?article=<%#Eval("article_Id") %>' alt='<%#Eval("article_title") %>' width="580px" style="min-height:250px; height:auto;"/>
                  <div class="box content">
                    <%#Eval("article_description")%>
                  </div>
               </div>
           </ItemTemplate>

           <FooterTemplate>
              <div id="article-social-plug" class="box">
     <div id="fb" class="fb-like" data-href="http://unitednewsnetwork.in/story-of-article.aspx" data-layout="standard" data-action="like" data-show-faces="true" data-share="true"></div>
   </div>
              <div class="title content">Tags :<%#Eval("article_tags")%></div>
           </FooterTemplate>

        </asp:Repeater>
   </div>

  

   <div id="article-comment-area" class="box">
    <table class="table">
            <tr>
               <th colspan="2">Leave Your Reply</th>
            </tr>
             <tr>
               <td>Your Name :</td><td><asp:TextBox ID="txtname" runat="server" class="textbox"></asp:TextBox></td>
            </tr>
            <tr>
               <td>Your Email :</td><td><asp:TextBox ID="txtemail" runat="server" class="textbox"></asp:TextBox></td>
            </tr>
            <tr>
               <td valign="top">Your Comment :</td><td>
                <asp:TextBox ID="txtcomment" 
                    runat="server" TextMode="MultiLine" Height="120px" Width="350px" class="textbox"></asp:TextBox></td>
            </tr>
            <tr>
               <td colspan="2"><asp:Button ID="btnsend" runat="server" Text="Send" 
                       CssClass="button" onclick="btnsend_Click" /></td>
            </tr>
         </table>
   </div>
  <div id="artical-comment-list" class="box content">
   <div class="title content">Comments</div>
          <asp:Repeater ID="rptcomments" runat="server">
           <ItemTemplate>
                         
                           <b> <%#Eval("sender_name") %><br /><%#String.Format("{0:dddd, MMMM d, yyyy}",Eval("date_added"))%></b>
                           <br><br>
                           <%#Eval("article_comment_description") %>
                        
           </ItemTemplate>
           <SeparatorTemplate>
           <hr />
           </SeparatorTemplate>
        </asp:Repeater>
     
  </div>
</asp:Content>

