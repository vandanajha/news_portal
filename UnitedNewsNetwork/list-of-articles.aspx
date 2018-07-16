<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="list-of-articles.aspx.cs" Inherits="list_of_artcles2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Repeater ID="rptarticles" runat="server">
         <HeaderTemplate>
          <div class="box">
            <ul class="list">
          
         </HeaderTemplate>

         <ItemTemplate>
           
         <li>
          
               
            

              <div class="title">
                
                               <%#Eval("article_title") %>                       
                
             </div> 
                
             <div class="box"> 
                  <a href='story-of-article.aspx?article=<%#Eval("article_Id") %>&category=<%#Eval("article_category_Id") %>' title='<%#Eval("article_title") %>' align="left">
                     <img src='process_image.ashx?article=<%#Eval("article_Id") %>' width="100" height="100" alt='<%#Eval("article_title") %>' border="0"/>
                 </a>
                  <%#Eval("article_summary") %> &nbsp; <a href='story-of-article.aspx?article=<%#Eval("article_Id") %>&category=<%#Eval("article_category_Id") %>' title='<%#Eval("article_title") %>'>Read More...</a>
             </div>
            </li> 
         
         </ItemTemplate>

         <FooterTemplate>
          
           </ul>

           </div>
         </FooterTemplate>


      </asp:Repeater>
      <br />
        <div style="overflow: hidden;width:100%;clear:both;">
        <asp:Repeater ID="rptPaging" runat="server" onitemcommand="rptPaging_ItemCommand">
            <ItemTemplate>
                                <asp:LinkButton ID="btnPage"
                 style="padding:8px; margin:2px; background:#e90000; border:solid 1px #666; font:8pt tahoma;"
                CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                 runat="server" ForeColor="White" Font-Bold="True"><%# Container.DataItem %>
                                </asp:LinkButton>
           </ItemTemplate>
        </asp:Repeater>
        </div>
</asp:Content>

