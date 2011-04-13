
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ThuocTinhSanPham.aspx.cs" Inherits="ThuocTinhSanPham" Title="ThuocTinhSanPham List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Thuoc Tinh San Pham List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ThuocTinhSanPhamDataSource"
				DataKeyNames="IdTtsp"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ThuocTinhSanPham.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="IdTtsp" HeaderText="Id Ttsp" SortExpression="id_TTSP" ReadOnly />
				<data:HyperLinkField HeaderText="Id San Pham" DataNavigateUrlFormatString="SanPhamEdit.aspx?IdSanPham={0}" DataNavigateUrlFields="IdSanPham" DataContainer="IdSanPhamSource" DataTextField="IdCongTy" />
				<data:HyperLinkField HeaderText="Id Thuoc Tinh" DataNavigateUrlFormatString="ThuocTinhEdit.aspx?IdThuocTinh={0}" DataNavigateUrlFields="IdThuocTinh" DataContainer="IdThuocTinhSource" DataTextField="TenThuocTinh" />
				<asp:BoundField DataField="Value1" HeaderText="Value1" SortExpression="Value1"  />
				<asp:BoundField DataField="Value2" HeaderText="Value2" SortExpression="Value2"  />
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No ThuocTinhSanPham Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnThuocTinhSanPham" OnClientClick="javascript:location.href='ThuocTinhSanPhamEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ThuocTinhSanPhamDataSource ID="ThuocTinhSanPhamDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ThuocTinhSanPhamProperty Name="ThuocTinh"/> 
					<data:ThuocTinhSanPhamProperty Name="SanPham"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ThuocTinhSanPhamDataSource>
	    		
</asp:Content>



