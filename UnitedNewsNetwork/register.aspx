<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <table class="tablestyle">
      <tr>
         <th colspan="4">New Registration</th>
      </tr>
      <tr>
         <td colspan="4"><asp:Literal ID="lblerror" runat="server"></asp:Literal></td>
      </tr>
      <tr>
          <td nowrap>First Name</td>
          <td><asp:TextBox ID="txtfirstname" runat="server" CssClass="textbox" /></td>
          <td nowrap>Last Name</td>
          <td><asp:TextBox ID="txtlastname" runat="server" CssClass="textbox" /></td>
      </tr>
      <tr>
          <td>Address</td>
          <td><asp:TextBox ID="txtaddress" runat="server" CssClass="textbox" TextMode="MultiLine"/></td>
          <td>City</td>
          <td><asp:TextBox ID="txtcity" runat="server" CssClass="textbox" /></td>
      </tr>
      <tr>
          <td>State</td>
          <td><asp:TextBox ID="txtstate" runat="server" CssClass="textbox" /></td>
          <td>Country</td>
          <td><asp:TextBox ID="txtcountry" runat="server" CssClass="textbox" /></td>
      </tr>
      <tr>
          <td nowrap>Mobile No.</td>
          <td><asp:TextBox ID="txtmobileno" runat="server" CssClass="textbox" /></td>
          <td>Email</td>
          <td><asp:TextBox ID="txtemail" runat="server" CssClass="textbox" /></td>
      </tr>
      <tr>
          <td nowrap>User Name</td>
          <td><asp:TextBox ID="txtusername" runat="server" CssClass="textbox" /></td>
          <td>Password</td>
          <td><asp:TextBox ID="txtpassword" runat="server" CssClass="textbox" TextMode="Password"/></td>
      </tr>
      <tr>
          <td nowrap>Select Photo</td>
          <td colspan="3"><asp:FileUpload ID="photoUploader" runat="server" CssClass="textbox"></asp:FileUpload></td>
          
      </tr>
      <tr>
          <td  colspan="2">Please Enter the Code</td>
          <td> <img src="captcha.ashx" alt="captcha" width="100px" style="height:30px" /></td>
          <td><asp:TextBox ID="txtcaptcha" runat="server" CssClass="textbox"/></td>
          
      </tr>
       <tr>
          
          <td colspan="4"><asp:CheckBox ID="chkterms" runat="server" CssClass="textbox" Text="I agree to the terms and conditions of &lt;a href=&quot;http://www.unitednewsnetwork.in&quot;&gt;United News Network&lt;a&gt;"/></td>
          
      </tr>
      <tr>
      <td>&nbsp;</td>
       <td>
       <asp:Button ID="btnregister" Text="Register" runat="server"  CssClass="button" 
               onclick="btnregister_Click" /> &nbsp;
       </td>
       <td>
       <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="button"/>
       </td>
       <td>&nbsp;</td>
       </tr>
   </table>
</asp:Content>

