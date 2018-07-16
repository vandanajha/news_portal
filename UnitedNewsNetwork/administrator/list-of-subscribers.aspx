<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/admin.master" AutoEventWireup="true" CodeFile="list-of-subscribers.aspx.cs" Inherits="administrator_list_of_subscribers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="gdvsubscribers" runat="server" AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="subscriber_Id" CssClass="tablestyle">
   <Columns>
     <asp:TemplateField HeaderText="Photo">
          <ItemTemplate>
            <img alt='<%#Eval("subscriber_Id") %>' src='../process_image.ashx?subscriber=<%#Eval("subscriber_Id") %>' height="50px" width="50px"/><br />
            <a href='photoUploader.aspx?Id=<%#Eval("subscriber_Id") %>'>Edit</a>
          </ItemTemplate>
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Name">
          <ItemTemplate>
             <%#Eval("subscriber_first_name") %>&nbsp;<%#Eval("subscriber_last_name") %>
          </ItemTemplate>
      </asp:TemplateField>

       <asp:TemplateField HeaderText="Address">
          <ItemTemplate>
             <%#Eval("subscriber_address") %>,<%#Eval("subscriber_city") %><br />State :<%#Eval("subscriber_state") %><br />Country :<%#Eval("subscriber_country") %><br />Mobile No. : <%#Eval("subscriber_mobile_no") %><br />
            Email      : <%#Eval("subscriber_email") %>
          </ItemTemplate>
      </asp:TemplateField>

      

       <asp:TemplateField HeaderText="Account">
          <ItemTemplate>
            UserName : <%#Eval("subscriber_user_name") %><br />
            Password : <%#Eval("subscriber_password") %>
          </ItemTemplate>
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Status">
          <ItemTemplate>
            <asp:CheckBox ID="chkstatus1" runat="server" Checked='<%#Eval("IsLiveSubscriber") %>' Enabled="false" />   
          </ItemTemplate>
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Date">
          <ItemTemplate>
           <%#Eval("date_added") %>       
          </ItemTemplate>
      </asp:TemplateField>

   </Columns>
</asp:GridView>
</asp:Content>

