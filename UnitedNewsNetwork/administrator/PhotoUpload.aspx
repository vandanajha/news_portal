<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/admin.master" AutoEventWireup="true" CodeFile="PhotoUpload.aspx.cs" Inherits="administrator_PhotoUpload2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tablestyle">
       <tr>
          <th colspan="2" align="center">Upload Photo</th>
       </tr>
       <tr>
         <td>Select Photo<font color="red">*</font></td><td><asp:FileUpload ID="photoUploader" runat="server" CssClass="textbox"></asp:FileUpload>(150px X 200px)</td>
      </tr>
      <tr>
          <td>
                   <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="button" onclick="btnsave_Click" OnClientClick="return validate()"></asp:Button>
        </td>
         <td>
                   <input type="reset" id="btnreset" value="Cancel" class="button" onclick="window.location.href = 'list-of-articles.aspx'" />
        </td>
       </tr>
      </table>

</asp:Content>

