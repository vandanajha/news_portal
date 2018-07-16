<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/admin.master" AutoEventWireup="true" CodeFile="article-category.aspx.cs" Inherits="administrator_article_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table class="tablestyle">
         <tr>
           <th colspan="2">New Article Category</th>
         </tr>
        
         <tr>
           <td>Article Category Name :</td>
           <td>
           <asp:TextBox ID="txtarticlecategoryname" runat="server" CssClass="textbox"></asp:TextBox>
              
           </td>
         </tr>
          <tr>
           <td>&nbsp;</td><td><asp:CheckBox ID="chkLive" runat="server" Text=" Is Live Category ?"></asp:CheckBox></td>
         </tr>

          <tr>
           <td><asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" CssClass="button" /></td><td><input type="reset" id="btncancel" value="Cancel" class="button"/></td>
         </tr>
          <tr>
           <td colspan="2"><asp:Literal ID="errormsg" runat="server"></asp:Literal></td>
         </tr>
     </table>

     <br />
     <hr />

     <table width="100%">
         <tr>
            <td>
            <asp:GridView ID="gdvarticlecategory" runat="server" CssClass="tablestyle"
           DataKeyNames="article_category_Id" AutoGenerateColumns="false" AllowPaging="true" 
           ShowFooter="true" ShowHeader="true"  HorizontalAlign="Center"
            onpageindexchanging="gdvarticlecategory_PageIndexChanging" 
                    onrowcancelingedit="gdvarticlecategory_RowCancelingEdit" 
                   
                    onrowcommand="gdvarticlecategory_RowCommand" 
                    onrowupdating="gdvarticlecategory_RowUpdating" OnRowDeleting="gdvarticlecategory_RowDeleting1" OnRowEditing="gdvarticlecategory_RowEditing1">
           
     <PagerSettings PageButtonCount="5" Mode="Numeric"  Position="Bottom" Visible ="true" />
       <EmptyDataTemplate>
            Sorry , No Data Available
       </EmptyDataTemplate>
       <HeaderStyle BackColor="#bbccdd" HorizontalAlign="Center" Height="30px" Font-Size="12px"/>      
       <AlternatingRowStyle BackColor="#e2e2e2" />
     <FooterStyle BackColor="#bbccdd" />
       <Columns>
         
         <asp:TemplateField HeaderText="Article Category">
           
           <ItemTemplate>
              <asp:Literal ID="lblcategoryname" runat="server" Text='<%#Eval("article_category_name") %>'></asp:Literal>
           </ItemTemplate>
           <EditItemTemplate>
             <asp:TextBox ID="txtcategoryname" runat="server" Text='<%#Bind("article_category_name") %>'></asp:TextBox>
           </EditItemTemplate>

         </asp:TemplateField>

         <asp:TemplateField HeaderText="Status">
           
           <ItemTemplate>
              <asp:CheckBox ID="chkLive1" runat="server" Checked='<%#Eval("IsLiveArticleCategory") %>' Enabled="false"></asp:CheckBox>
           </ItemTemplate>
           <EditItemTemplate>
             <asp:CheckBox ID="chkLive2" runat="server" Checked='<%#Bind("IsLiveArticleCategory") %>'></asp:CheckBox>
           </EditItemTemplate>

         </asp:TemplateField>
          <asp:TemplateField>
           
           <ItemTemplate>
              <asp:Button ID="btnedit" runat="server" Text="Edit"  CommandName="Edit" CommandArgument='<%#Eval("article_category_Id") %>' CssClass="button" />
              <asp:Button ID="btndelete" runat="server" Text="Delete"   CommandName="Delete" CommandArgument='<%#Eval("article_category_Id") %>' CssClass="button"/>
              <asp:Button ID="btnaddarticle" runat="server" Text="Add Article" CommandName="add_article" CommandArgument='<%#Eval("article_category_Id") %>' CssClass="button"/>
              <asp:Button ID="btnlistarticle" runat="server" Text="List Articles" CommandName="list_article" CommandArgument='<%#Eval("article_category_Id") %>' CssClass="button"/>
           </ItemTemplate>
           <EditItemTemplate>
            <asp:Button ID="btnupdate" runat="server" Text="Update"   CommandName="Update" CommandArgument='<%#Eval("article_category_Id") %>' CssClass="button"/>
             <asp:Button ID="btncancel" runat="server" Text="Cancel"   CommandName="Cancel" CommandArgument='<%#Eval("article_category_Id") %>' CssClass="button"/>
           </EditItemTemplate>

         </asp:TemplateField>

       </Columns>
     </asp:GridView>
            </td>
         </tr>
     </table>
</asp:Content>

