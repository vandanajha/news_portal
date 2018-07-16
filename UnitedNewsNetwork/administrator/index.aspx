<%@ Page Title="" Language="C#" MasterPageFile="~/administrator/admin.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="administrator_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="50%" class="tablestyle">
      <tr>
          <td>
          <a href="article-category.aspx">
            <p>
               <img src="images/article-category.png" alt="pic" vspace="5px" hspace="10px" border="0" width="128px" height="128px"/>
            </p>
            <p>
               Article Category Manager
            </p>
            </a>
          </td>
          <td>
             <a href="list-of-articles.aspx">
             <p>
               <img src="images/article.jpg" alt="pic" vspace="5px" hspace="10px" border="0" width="128px" height="128px"/>
            </p>
            <p>
               Article Manager
            </p>
            </a>
          </td>
          <td>
              <a href="photo-gallary.aspx">
              <p>
               <img src="images/photo-gallary.jpg" alt="pic" vspace="5px" hspace="10px" width="128px" height="128px" border="0"/>
            </p>
            <p>
                Photo Gallary
            </p>
            </a>
          </td>
      </tr>
      <tr>
          <td>
           <a href="video-gallary.aspx">
             <p>
               <img src="images/video-gallary.png" alt="pic" vspace="5px" hspace="10px" width="128px" height="128px" border="0"/>
            </p>
            <p>
                Video Gallary
            </p>
            </a>
          </td>
          <td>
             <a href="#">
              <p>
               <img src="images/openion-poll.png" alt="pic" vspace="5px" hspace="10px" width="128px" height="128px" border="0"/>
            </p>
            <p>
                Openion Polls
            </p>
            </a>
          </td>
          <td>
           <a href="ad-gallary.aspx">
              <p>
               <img src="images/ad-gallary.png" alt="pic" vspace="5px" hspace="10px" width="128px" height="128px" border="0"/>
            </p>
            <p>
               Advertisements
            </p>
            </a>
          </td>
      </tr>

      
  </table>
</asp:Content>

