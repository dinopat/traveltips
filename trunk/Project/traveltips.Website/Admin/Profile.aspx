<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminFull.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Admin_Profile" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="" style="width:98%; margin-left:5px; margin-right:5px">
    <h3 class="heading colr">Tài khoản của bạn</h3>
       <div class="box-left">
       <table cellspacing="2" cellpadding="2" border="0" width="100%">
      <tbody>
      
      <tr>
      <td nowrap="nowrap" width="20%" valign="top"><font size="-1" >Email:
      </font>
      </td>
      <td>
          &nbsp;<asp:TextBox ID="txtEmail" Width="200" runat="server" EnableTheming="True" ReadOnly="True"></asp:TextBox></td>
      </tr>
            <tr>
        <td></td>
        <td>Địa chỉ email được dùng để đăng nhập vào Travetips.com.</td>
      </tr>
      <tr>
      <td nowrap="nowrap" width="20%" valign="top" style="height: 21px"><font size="-1">Tên đăng nhập:
      </font>
      </td>
      <td style="height: 21px">
          &nbsp;<asp:TextBox ID="txtUserName" Width="200" runat="server" ReadOnly="True"></asp:TextBox></td>
      </tr>
      <tr>
      <td nowrap="nowrap" width="20%" valign="top"><font size="-1">Họ và tên:
      </font>
      </td>
      <td>
          &nbsp;<asp:TextBox ID="txtHoTen" Width="200" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
      <td nowrap="nowrap" width="20%" valign="top"><font size="-1">Điện thoại:
      <i><font size="-2" face="Arial, sans-serif">
      (optional)
      </font></i>
      </font>
      </td>
      <td>
          &nbsp;<asp:TextBox ID="txtPhone" Width="200" runat="server"></asp:TextBox></td>
      </tr>
  <!--    <tr>
      <td nowrap="nowrap" width="20%" valign="top">
      <font size="-1">Địa chỉ:
      <i><font size="-2" face="Arial, sans-serif">
      (optional)
      </font></i>
      </font>
      </td>
      <td>
          &nbsp;<asp:TextBox ID="txtAddress" Width="200" runat="server"></asp:TextBox></td>
      </tr> -->
      <tr>
      <td></td>
            <td></td>
      </tr>
            <tr>
        <td> </td>
        <td>
          				    <label class="button">
					    <asp:Button ID="btnSaveModify" runat="server" Text="Lưu" OnClick="btnSaveModify_Click"/>
					    <span>Lưu </span>
				    </label>
            </td>
      </tr>
      </tbody></table>           
    </div>
    <div class="box-right">
           <h5 class="heading colr">ĐỔI PASSWORD</h5>
           <div class="divError"><asp:Label ID="lblError" runat="server"></asp:Label></div>
       <table cellspacing="2" cellpadding="2" border="0" width="100%">
      <tbody>
      <tr>
      <td nowrap="nowrap" width="20%" valign="top"><font size="-1" >Password cũ:
      </font>
      </td>
      <td>
          <asp:TextBox ID="txtOldPass" TextMode="Password" runat="server" Width="200"  Text=""></asp:TextBox></td>
      
      </tr>
      <tr>
      <td nowrap="nowrap" width="20%" valign="top"><font size="-1">Password mới:
      </font>
      </td>
      <td>
          <asp:TextBox ID="txtNewPass" TextMode="Password" runat="server" Width="200"  Text=""></asp:TextBox></td>
      </tr>
      <tr>
        <td nowrap="nowrap" width="20%" valign="top"><font size="-1">Nhập lại Password mới:</font></td>
        <td>
            <asp:TextBox ID="txtRepeatNewPass" TextMode="Password" runat="server" Width="200"  Text=""></asp:TextBox></td>
      </tr>
            <tr>
        <td> </td>
        <td>
          </td>
      </tr>
      <tr>
        <td> </td>
        <td>
          				    <label class="button">
					                <asp:Button ID="btnChangePass" runat="server" Text="Thay đổi" OnClick="btnChangePass_Click" />

					    <span>Thay đổi</span>
				    </label></td>
      </tr>
      </tbody></table>           
    </div>
    </div>
</asp:Content>

