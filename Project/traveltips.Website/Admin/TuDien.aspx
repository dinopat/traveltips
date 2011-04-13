
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="TuDien.aspx.cs" Inherits="TuDien" Title="TuDien List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Tu Dien List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="TuDienDataSource"
				DataKeyNames="IdTuDien"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_TuDien.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="IdTuDien" HeaderText="Id Tu Dien" SortExpression="id_TuDien" ReadOnly />
				<asp:BoundField DataField="IdDanhMuc" HeaderText="Id Danh Muc" SortExpression="id_DanhMuc"  />
				<asp:BoundField DataField="TenTu" HeaderText="Ten Tu" SortExpression="TenTu"  />
				<asp:BoundField DataField="MaTu" HeaderText="Ma Tu" SortExpression="MaTu"  />
				<asp:BoundField DataField="NhomTu" HeaderText="Nhom Tu" SortExpression="NhomTu"  />
				<asp:BoundField DataField="MoTa" HeaderText="Mo Ta" SortExpression="MoTa"  />
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No TuDien Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnTuDien" OnClientClick="javascript:location.href='TuDienEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:TuDienDataSource ID="TuDienDataSource" runat="server"
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
		</data:TuDienDataSource>
	    		
</asp:Content>



