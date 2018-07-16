<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/admin.master" AutoEventWireup="true" CodeFile="video-gallary.aspx.cs" Inherits="administrator_video_gallary"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table class="tablestyle">
         <tr>
           <th colspan="2">Video Gallary</th>
         </tr>
        <tr>
           <td colspan="2"><asp:Literal ID="errormsg" runat="server"></asp:Literal></td>
         </tr>
         <tr>
           
            <td>Video Title<font color="red">*</font></td>
            <td> <asp:TextBox ID="txtvideoname" runat="server" CssClass="textbox" Width="334px"></asp:TextBox></td>
         </tr>
         <tr>
           
            <td>Select Video Photo<font color="red">*</font></td>
            <td> <asp:FileUpload ID="photoUploader" runat="server" CssClass="textbox" Width="334px"></asp:FileUpload></td>
         </tr>
        <tr>
           
            <td>Paste Video Url<font color="red">*</font></td>
            <td> <asp:TextBox ID="txtvideourl" runat="server" CssClass="textbox" TextMode="MultiLine" Height="50px" Width="334px"></asp:TextBox></td>
         </tr>
         <tr>
           <td valign="top">Photo Description :</td>
           <td>
           <asp:TextBox ID="txtvideodescription" runat="server" CssClass="textbox" 
                   TextMode="MultiLine" Height="150px" Width="334px"></asp:TextBox>
              
           </td>
         </tr>
          <tr>
           <td>&nbsp;</td><td><asp:CheckBox ID="chkfeatured" runat="server" Text=" Is Featured Video ?"></asp:CheckBox></td>
         </tr>
          <tr>
           <td>&nbsp;</td><td><asp:CheckBox ID="chkLive" runat="server" Text=" Is Live Video ?"></asp:CheckBox></td>
         </tr>

          <tr>
           <td><asp:Button ID="btnsave" runat="server" Text="Save" CssClass="button" 
                   onclick="btnsave_Click" /></td><td><input type="reset" id="btncancel" value="Cancel"class="button" /></td>
         </tr>
          
     </table>

     <br />
     <hr />

     
             <asp:GridView ID="gdvvideogallary" runat="server"
     DataKeyNames="video_Id"
     AllowPaging="true" 
    
     ShowHeader="true"
     AutoGenerateColumns="false" 
     Width="100%" 
     HorizontalAlign="Center"  CssClass="tablestyle" 
        onpageindexchanging="gdvvideogallary_PageIndexChanging" 
        onrowcancelingedit="gdvvideogallary_RowCancelingEdit" 
        onrowediting="gdvvideogallary_RowEditing" 
        onrowdeleting="gdvvideogallary_RowDeleting" onrowupdating="gdvvideogallary_RowUpdating"
        >
       <PagerSettings PageButtonCount="10" Mode="Numeric"  Position="Bottom" Visible ="true" />
       <EmptyDataTemplate>
            Sorry , No Data Available
       </EmptyDataTemplate>
       <RowStyle HorizontalAlign="Left" />
       <HeaderStyle BackColor="#bbccdd" HorizontalAlign="Center" Height="30px" Font-Size="12px"/>      
       <AlternatingRowStyle BackColor="#e2e2e2" />
       
      <Columns>
       
            
     <asp:TemplateField HeaderText="Title">
         <ItemStyle HorizontalAlign="Center" />
       <ItemTemplate>
           <asp:Literal ID="lblvideoname" runat="server" Text='<%#Eval("video_name") %>'></asp:Literal>
         
       </ItemTemplate>
       <EditItemTemplate>
          <asp:TextBox ID="txtvideoname2" runat="server" Text='<%#Bind("video_name") %>' CssClass="textbox"></asp:TextBox>
       </EditItemTemplate>
    </asp:TemplateField>
      
       <asp:TemplateField HeaderText="Video">
         <ItemStyle HorizontalAlign="Center" />
       <ItemTemplate>
           <asp:Literal ID="lblvideourl" runat="server" Text='<%#Eval("video_url") %>'></asp:Literal>        
       </ItemTemplate>
       <EditItemTemplate>
          <asp:TextBox ID="txtvideourl2" runat="server" Text='<%#Bind("video_url") %>' CssClass="textbox"></asp:TextBox>
       </EditItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Description">
     <HeaderStyle/>
       <ItemTemplate>
          <asp:Label ID="lblvideodescription" runat="server" Text='<%#Eval("video_description") %>' />
            
       </ItemTemplate>
       <EditItemTemplate>
          <asp:TextBox ID="txtvideodescription2" runat="server" Text='<%#Bind("video_description") %>' CssClass="textbox"></asp:TextBox>
       </EditItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="Featured Video ?">
     <HeaderStyle/>
       <ItemTemplate>
          <asp:CheckBox ID="chkfeaturedvideo" runat="server" Checked='<%#Eval("IsFeaturedVideo") %>' Enabled="false" />
            
       </ItemTemplate>
       <EditItemTemplate>
          <asp:CheckBox ID="chkfeaturedvideo2" runat="server" Checked='<%#Bind("IsFeaturedVideo") %>' />
       </EditItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Is Live">
     <HeaderStyle/>
       <ItemTemplate>
         <asp:CheckBox ID="chklivevideo" runat="server" Checked='<%#Eval("IsLiveVideo") %>' Enabled="false" />
            
       </ItemTemplate>
       <EditItemTemplate>
          <asp:CheckBox ID="chklivevideo2" runat="server" Checked='<%#Bind("IsLiveVideo") %>'/>
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
          <asp:Button ID="Delete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("video_Id") %>' CssClass="button" />
            <hr />
          <asp:Button ID="Edit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%#Eval("video_Id") %>' CssClass="button"/>
       </ItemTemplate>   
       
       <EditItemTemplate>
         <asp:Button ID="Update" runat="server" Text="Update" CommandName="Update" CommandArgument='<%#Eval("video_Id") %>' CssClass="button" />
           <hr />
          <asp:Button ID="Cancel" runat="server" Text="Cancel" CommandName="Cancel" CommandArgument='<%#Eval("video_Id") %>' CssClass="button"/>
       </EditItemTemplate>    
    </asp:TemplateField>
    
        </Columns>
     </asp:GridView>
</asp:Content>

