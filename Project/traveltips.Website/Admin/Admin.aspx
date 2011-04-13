
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Admin.aspx.cs" Inherits="Admin" Title="Admin List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Admin List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AdminDataSource"
				DataKeyNames="IdAdmin"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Admin.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="IdAdmin" HeaderText="Id Admin" SortExpression="id_Admin" ReadOnly />
				<asp:BoundField DataField="TenDangNhap" HeaderText="Ten Dang Nhap" SortExpression="TenDangNhap"  />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"  />
				<asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password"  />
				<asp:BoundField DataField="HoTen" HeaderText="Ho Ten" SortExpression="HoTen"  />
				<asp:BoundField DataField="DienThoai" HeaderText="Dien Thoai" SortExpression="DienThoai"  />
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Admin Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAdmin" OnClientClick="javascript:location.href='AdminEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AdminDataSource ID="AdminDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
>			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:AdminDataSource>
	    		
</asp:Content>



