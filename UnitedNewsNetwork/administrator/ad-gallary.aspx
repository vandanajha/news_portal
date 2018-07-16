<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/admin.master" AutoEventWireup="true" CodeFile="ad-gallary.aspx.cs" Inherits="administrator_ad_gallary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="ads">
     <table class="tablestyle">
        <tr>
           <th colspan="2">New Advertisement</th>
        </tr>
        <tr>
           <td colspan="2"><asp:Literal ID="errormsg" runat="server"></asp:Literal></td>
        </tr>
        <tr>
           <td>Select Ad</td><td><asp:FileUpload ID="adUploader" runat="server" CssClass="textbox" /></td>
        </tr>
         <tr>
           <td>Alternate Text</td><td><asp:TextBox ID="txtalternatetext" runat="server" CssClass="textbox"/></td>
        </tr>
        <tr>
           <td>Navigate Url</td><td><asp:TextBox ID="txtnavigateurl" runat="server" CssClass="textbox"/></td>
        </tr>
        <tr>
           <td>Keywords</td><td><asp:TextBox ID="txtkeywords" runat="server" CssClass="textbox"/></td>
        </tr>
        <tr>
           <td>Impressions</td><td><asp:TextBox ID="txtimpression" runat="server" CssClass="textbox"/></td>
        </tr>
        <tr>
           <td>&nbsp;</td><td><asp:CheckBox ID="chkLive" runat="server" Text="Is Live?" CssClass="textbox"/></td>
        </tr>
        <tr>
           <td>&nbsp;</td><td><asp:Button ID="btnupload" runat="server" Text="Upload" 
                CssClass="button" onclick="btnupload_Click"/></td>
        </tr>
     </table>
  </div>

  <hr />

  <div id="ad-gallary">
       <asp:GridView ID="gdvadgallary" runat="server"
     DataKeyNames="ad_Id"
     AllowPaging="true" 
    
     ShowHeader="true"
     AutoGenerateColumns="false" 
     Width="100%" 
     HorizontalAlign="Center"  CssClass="tablestyle" 
           onpageindexchanging="gdvadgallary_PageIndexChanging" 
           onrowcancelingedit="gdvadgallary_RowCancelingEdit" 
           onrowdeleting="gdvadgallary_RowDeleting" 
           onrowediting="gdvadgallary_RowEditing" onrowupdating="gdvadgallary_RowUpdating" 
       
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
            <img src='<%#"../"+Eval("ImageUrl") %>' width="100" height="100" alt='<%#Eval("AlternateText") %>'  /><br />
           <a href='PhotoUpload.aspx?Id=<%#Eval("ad_Id") %>&pageurl=adgallary'>Edit Photo</a>
         
       </ItemTemplate>
       <EditItemTemplate>
           <img src='<%#"../"+Eval("ImageUrl") %>' width="100" height="100" alt='<%#Eval("AlternateText") %>'  /><br />
           <a href='PhotoUpload.aspx?Id=<%#Eval("ad_Id") %>&pageurl=adgallary'>Edit Photo</a>
       </EditItemTemplate>
    </asp:TemplateField>
      
    <asp:TemplateField HeaderText="Alternate Text">
     <HeaderStyle/>
       <ItemTemplate>
          <asp:Label ID="lblalternatetext" runat="server" Text='<%#Eval("AlternateText") %>' />
            
       </ItemTemplate>
        <EditItemTemplate>
        <asp:TextBox ID="txtalternatetext" runat="server" Text='<%#Bind("AlternateText") %>' CssClass="textbox"></asp:TextBox>
       </EditItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="Navigate Url">
     <HeaderStyle/>
       <ItemTemplate>
          <asp:Label ID="lblnavigateurl" runat="server" Text='<%#Eval("NavigateUrl") %>' />
            
       </ItemTemplate>
        <EditItemTemplate>
        <asp:TextBox ID="txtnavigateurl" runat="server" Text='<%#Bind("NavigateUrl") %>' CssClass="textbox"></asp:TextBox>
       </EditItemTemplate>
    </asp:TemplateField>

     <asp:TemplateField HeaderText="Keywords">
     <HeaderStyle/>
       <ItemTemplate>
          <asp:Label ID="lblkeywords" runat="server" Text='<%#Eval("Keywords") %>' />
            
       </ItemTemplate>
        <EditItemTemplate>
        <asp:TextBox ID="txtkeywords" runat="server" Text='<%#Bind("Keywords") %>' CssClass="textbox"></asp:TextBox>
       </EditItemTemplate>
    </asp:TemplateField>

     <asp:TemplateField HeaderText="Impressions">
     <HeaderStyle/>
       <ItemTemplate>
          <asp:Label ID="lblimpressions" runat="server" Text='<%#Eval("Impressions") %>' />
            
       </ItemTemplate>
        <EditItemTemplate>
        <asp:TextBox ID="txtimpressions" runat="server" Text='<%#Bind("Impressions") %>' CssClass="textbox"></asp:TextBox>
       </EditItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Is Live">
     <HeaderStyle/>
       <ItemTemplate>
         <asp:CheckBox ID="chklivead" runat="server" Checked='<%#Eval("IsLiveAd") %>' Enabled="false" />
            
       </ItemTemplate>
        <EditItemTemplate>
         <asp:CheckBox ID="chklivead2" runat="server" Checked='<%#Bind("IsLiveAd") %>'/>
       </EditItemTemplate>
    </asp:TemplateField>


    
    
    <asp:TemplateField>
   
       <ItemTemplate>
          <asp:Button ID="Delete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("ad_Id") %>' CssClass="button" />
          <hr />
          <asp:Button ID="Edit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%#Eval("ad_Id") %>' CssClass="button"/>
       </ItemTemplate>
        <EditItemTemplate>
           <asp:Button ID="Update" runat="server" Text="Update" CommandName="Update" CommandArgument='<%#Eval("ad_Id") %>' CssClass="button" />
             <hr />
          <asp:Button ID="Cancel" runat="server" Text="Cancel" CommandName="Cancel" CommandArgument='<%#Eval("ad_Id") %>' CssClass="button"/>
       </EditItemTemplate>       
    </asp:TemplateField>
    
        </Columns>
     </asp:GridView>
  </div>
</asp:Content>

