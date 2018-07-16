<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/admin.master" AutoEventWireup="true" CodeFile="list-of-articles.aspx.cs" Inherits="administrator_list_of_articles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="gdvarticlelist" runat="server"
     DataKeyNames="article_Id"
     AllowPaging="true" 
    
     ShowHeader="true"
     AutoGenerateColumns="false" 
     Width="100%" 
     HorizontalAlign="Center"  CssClass="tablestyle" onrowcommand="gdvarticlelist_RowCommand" onrowdeleting="gdvarticlelist_RowDeleting" onpageindexchanging="gdvarticlelist_PageIndexChanging"   
        >
       <PagerSettings PageButtonCount="10" Mode="Numeric"  Position="Bottom" Visible ="true" />
       <EmptyDataTemplate>
            Sorry , No Data Available
       </EmptyDataTemplate>
       <RowStyle HorizontalAlign="Left" />
       <HeaderStyle BackColor="#bbccdd" HorizontalAlign="Center" Height="30px" Font-Size="12px"/>      
       <AlternatingRowStyle BackColor="#e2e2e2" />
       
      <Columns>
       
            
     <asp:TemplateField HeaderText="Photo">
         <ItemStyle HorizontalAlign="Center" />
       <ItemTemplate>
           <img src='../process_image.ashx?article=<%#Eval("article_Id") %>' width="82" height="50" alt='<%#Eval("article_title") %>'  /><br />
           <a href='PhotoUpload.aspx?Id=<%#Eval("article_Id") %>&pageurl=article'>Edit Photo</a>
         
       </ItemTemplate>
       
    </asp:TemplateField>
      
    <asp:TemplateField HeaderText="Title">
     <HeaderStyle/>
       <ItemTemplate>
          <asp:Label ID="lbltitle" runat="server" Text='<%#Eval("article_title") %>' />
            
       </ItemTemplate>
       
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="Publish Date">
     <HeaderStyle/>
       <ItemTemplate>
          <asp:Label ID="lblpublishdate" runat="server" Text='<%#Eval("date_added") %>' />
            
       </ItemTemplate>
       
    </asp:TemplateField>
    
    <asp:TemplateField>
       <ItemStyle Width="55%" />
       <ItemTemplate>
          <asp:Button ID="Remove" runat="server" Text="Remove" CommandName="Delete" CommandArgument='<%#Eval("article_Id") %>' CssClass="button"/>
          <asp:Button ID="Modify" runat="server" Text="Modify" CommandName="Modify" CommandArgument='<%#Eval("article_Id") %>' CssClass="button"/>
          <asp:Button ID="btnphoto" runat="server" Text="Add Photo" CommandName="add_photo" CommandArgument='<%#Eval("article_Id") %>' CssClass="button"/>
          <asp:Button ID="btnvideo" runat="server" Text="Add Videos" CommandName="add_video" CommandArgument='<%#Eval("article_Id") %>' CssClass="button"/>
       </ItemTemplate>       
    </asp:TemplateField>
  
        </Columns>
     </asp:GridView>

 <br />
     <asp:Literal ID="errormsg" runat="server"></asp:Literal>
</asp:Content>

