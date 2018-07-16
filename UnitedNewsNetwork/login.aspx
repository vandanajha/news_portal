<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="527" border="0" align="center" cellpadding="0" cellspacing="0" align="center" style="margin-top:20px">
      <tr>
        <td height="243" background="images/login-user.jpg">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="46%">&nbsp;</td>
            <td width="54%" background="images/login-bg.jpg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td><img src="images/free-membership.jpg" width="286" height="56" /></td>
              </tr>
              <tr>
                <td><div align="center">
                    <asp:TextBox ID="txtusername" runat="server" Width="200px" Height="30px" Font-Size="14px"></asp:TextBox>
                </div></td>
              </tr>
              <tr>
                <td><img src="images/password.jpg" width="107" height="20" /></td>
              </tr>
              <tr>
                <td><div align="center">
                    <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Width="200px" Height="30px" Font-Size="14px"></asp:TextBox>
                </div></td>
              </tr>
              <tr>
                 <td>
                   <div align="center">
                     <asp:CheckBox ID="cboxRemember" runat="server" Text="Remember Me" />
                   </div>
                 </td>
              </tr>
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="66%"><div align="center"><a href="password_recovery.aspx">Forget Password</a></div></td>
                    <td width="34%"><asp:ImageButton ID="btnLogin" runat="server" 
                            ImageUrl="images/login.jpg" width="75" height="27" 
                            onclick="btnLogin_Click"/></td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td><div align="center"><asp:Literal ID="errormsg" runat="server"></asp:Literal></div></td>
              </tr>
              <tr>
                <td><a href="registration.aspx"><img src="images/create-new-account.jpg" width="286" height="29" border="0"/></a></td>
              </tr>
            </table></td>
          </tr>
        </table></td>
      </tr>
    </table>
</asp:Content>

