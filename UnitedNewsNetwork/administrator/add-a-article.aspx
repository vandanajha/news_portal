<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/admin.master" AutoEventWireup="true" CodeFile="add-a-article.aspx.cs" Inherits="administrator_add_a_article" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <table class="tablestyle" width="90%">
       <tr>
           <th colspan="2">New Article</th>
       </tr>
        <tr>
           <td colspan="2"><asp:Literal ID="errormsg" runat="server"></asp:Literal></td>
         </tr>
       <tr>
           <td>Article Title</td><td><asp:TextBox ID="txtarticletitle" runat="server" CssClass="textbox" Width="400px"></asp:TextBox></td>
       </tr>
      <tr>
           <td>Article Source</td><td><asp:TextBox ID="txtarticlesource" runat="server" CssClass="textbox" Width="400px"></asp:TextBox></td>
       </tr>
       <tr>
           <td>Select Photo</td><td><asp:FileUpload ID="photoUploader" runat="server" CssClass="textbox" Width="400px"></asp:FileUpload></td>
       </tr>
       <tr>
           <td valign="top">Summary</td><td>
           <cc1:Editor ID="txtarticlesummary" runat="server" Height="200px" Width="600px"/>
           </td>
       </tr>
      <tr>
           <td valign="top">Story</td>
           <td>
           <cc1:Editor ID="txtarticledescription" runat="server" Height="300px" Width="600px"/></td>
       </tr>
      <tr>
           <td> Article Category</td>
           <td><asp:DropDownList ID="ddlcategory" runat="server" AppendDataBoundItems="true" CssClass="textbox">
           <asp:ListItem Value="0" Selected="True">Select Category</asp:ListItem>
           </asp:DropDownList></td>
       </tr>
       <tr>
           <td> Article Type</td><td>
           <asp:DropDownList ID="ddltypes" runat="server" CssClass="textbox">
               <asp:ListItem Value="NA" Selected="True">Select Type</asp:ListItem>
               <asp:ListItem Value="TOP STORY">TOP STORY</asp:ListItem>
               <asp:ListItem Value="FEATURED STORY">FEATURED STORY</asp:ListItem>
               <asp:ListItem Value="HEADLINE STORY">HEADLINE STORY</asp:ListItem>
               <asp:ListItem Value="BREAKING STORY">BREAKING STORY</asp:ListItem>
           </asp:DropDownList>
           </td>
       </tr>
        <tr>
           <td>Article Tags</td><td><asp:TextBox ID="txtarticletags" runat="server" CssClass="textbox" Width="600px"></asp:TextBox></td>
       </tr>
        <tr>
           <td>&nbsp;</td>
           <td><asp:CheckBox ID="chkLive" runat="server" Text="Is Live Article" /></td>
       </tr>
       <tr>
       <td><asp:Button ID="btnsubmit" Text="Submit" runat="server" onclick="btnsubmit_Click" CssClass="button" /></td>
               <td><asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="button"/></td>
       </tr>
   </table>
</asp:Content>

