<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/admin.master" AutoEventWireup="true" CodeFile="photo-gallary.aspx.cs" Inherits="administrator_photo_gallary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tablestyle">
         <tr>
           <th colspan="2">Photo Gallary</th>
         </tr>
        <tr>
           <td colspan="2"><asp:Literal ID="errormsg" runat="server"></asp:Literal></td>
         </tr>
         <tr>
           
            <td>Select Photo<font color="red">*</font></td>
            <td><asp:FileUpload ID="photoUploader" runat="server" CssClass="textbox"></asp:FileUpload> &nbsp;(400px X 250px)</td>
         </tr>
        
         <tr>
           <td valign="top">Photo Description :</td>
           <td>
           <asp:TextBox ID="txtphotodescription" runat="server" CssClass="textbox" 
                   TextMode="MultiLine" Height="150px" Width="334px"></asp:TextBox>
              
           </td>
         </tr>
          <tr>
           <td>&nbsp;</td><td><asp:CheckBox ID="chkfeatured" runat="server" Text=" Is Featured Photo ?"></asp:CheckBox></td>
         </tr>
          <tr>
           <td>&nbsp;</td><td><asp:CheckBox ID="chkLive" runat="server" Text=" Is Live Photo ?"></asp:CheckBox></td>
         </tr>

          <tr>
           <td><asp:Button ID="btnsave" runat="server" Text="Save" CssClass="button" 
                   onclick="btnsave_Click" /></td><td><input type="reset" id="btncancel" value="Cancel"class="button" /></td>
         </tr>
          
     </table>

     <br />
     <hr />

     
             <asp:GridView ID="gdvphotogallary" runat="server"
     DataKeyNames="photo_Id"
     AllowPaging="true" 
    
     ShowHeader="true"
     AutoGenerateColumns="false" 
     Width="100%" 
     HorizontalAlign="Center"  CssClass="tablestyle" 
        onpageindexchanging="gdvphotogallary_PageIndexChanging" 
        onrowcancelingedit="gdvphotogallary_RowCancelingEdit" 
        onrowdeleting="gdvphotogallary_RowDeleting" 
        onrowediting="gdvphotogallary_RowEditing" onrowupdating="gdvphotogallary_RowUpdating"
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
           <img src='<%#"../photo-gallary/"+Eval("photo_name") %>' width="100" height="100" alt='<%#Eval("photo_name") %>'  /><br />
           <a href='PhotoUpload.aspx?Id=<%#Eval("photo_Id") %>&pageurl=photogallary'>Edit Photo</a>
         
       </ItemTemplate>
       <EditItemTemplate>
           <img src='<%#"../photo-gallary/"+Eval("photo_name") %>' width="100" height="100" alt='<%#Eval("photo_name") %>'  /><br />
           <a href='PhotoUpload.aspx?Id=<%#Eval("photo_Id") %>&pageurl=photogallary'>Edit Photo</a>
       </EditItemTemplate>
    </asp:TemplateField>
      
    <asp:TemplateField HeaderText="Description">
     <HeaderStyle/>
       <ItemTemplate>
          <asp:Label ID="lblphotodescription" runat="server" Text='<%#Eval("photo_description") %>' />
            
       </ItemTemplate>
        <EditItemTemplate>
        <asp:TextBox ID="txtphotodescription2" runat="server" Text='<%#Bind("photo_description") %>' TextMode="MultiLine" CssClass="textbox"></asp:TextBox>
       </EditItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="Featured Photo ?">
     <HeaderStyle/>
       <ItemTemplate>
          <asp:CheckBox ID="chkfeaturedphoto" runat="server" Checked='<%#Eval("IsFeaturedPhoto") %>' Enabled="false" />
            
       </ItemTemplate>
        <EditItemTemplate>
          <asp:CheckBox ID="chkfeaturedphoto2" runat="server" Checked='<%#Bind("IsFeaturedPhoto") %>' />
       </EditItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Is Live">
     <HeaderStyle/>
       <ItemTemplate>
         <asp:CheckBox ID="chklivephoto" runat="server" Checked='<%#Eval("IsLivePhoto") %>' Enabled="false" />
            
       </ItemTemplate>
        <EditItemTemplate>
         <asp:CheckBox ID="chklivephoto2" runat="server" Checked='<%#Bind("IsLivePhoto") %>'/>
       </EditItemTemplate>
    </asp:TemplateField>


    <asp:TemplateField HeaderText="Date">
     <HeaderStyle/>
       <ItemTemplate>
          <asp:Label ID="lblpublishdate" runat="server" Text='<%#Eval("date_added") %>' />
            
       </ItemTemplate>
        <EditItemTemplate>
          <asp:Label ID="lblpublishdate2" runat="server" Text='<%#Bind("date_added") %>' />
       </EditItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField>
   
       <ItemTemplate>
          <asp:Button ID="Delete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("photo_Id") %>' CssClass="button" />
          <hr />
          <asp:Button ID="Edit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%#Eval("photo_Id") %>' CssClass="button"/>
       </ItemTemplate>
        <EditItemTemplate>
           <asp:Button ID="Update" runat="server" Text="Update" CommandName="Update" CommandArgument='<%#Eval("photo_Id") %>' CssClass="button" />
             <hr />
          <asp:Button ID="Cancel" runat="server" Text="Cancel" CommandName="Cancel" CommandArgument='<%#Eval("photo_Id") %>' CssClass="button"/>
       </EditItemTemplate>       
    </asp:TemplateField>
    
        </Columns>
     </asp:GridView>
         
</asp:Content>

