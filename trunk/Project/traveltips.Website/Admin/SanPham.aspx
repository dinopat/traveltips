
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SanPham.aspx.cs" Inherits="SanPham" Title="SanPham List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">San Pham List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="SanPhamDataSource"
				DataKeyNames="IdSanPham"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_SanPham.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Id San Pham" DataNavigateUrlFormatString="CongTyEdit.aspx?IdCongTy={0}" DataNavigateUrlFields="IdCongTy" DataContainer="IdSanPhamSource" DataTextField="IdQuocGia" />
				<asp:BoundField DataField="IdCongTy" HeaderText="Id Cong Ty" SortExpression="id_CongTy"  />
				<data:HyperLinkField HeaderText="Id Loai Sp" DataNavigateUrlFormatString="LoaiSpEdit.aspx?IdLoaiSp={0}" DataNavigateUrlFields="IdLoaiSp" DataContainer="IdLoaiSpSource" DataTextField="IdLoaiSpCha" />
				<asp:BoundField DataField="IdTuDien" HeaderText="Id Tu Dien" SortExpression="id_TuDien"  />
				<asp:BoundField DataField="TenSp" HeaderText="Ten Sp" SortExpression="TenSP"  />
				<asp:BoundField DataField="MaSp" HeaderText="Ma Sp" SortExpression="MaSP"  />
				<asp:BoundField DataField="Gia" HeaderText="Gia" SortExpression="Gia"  />
				<asp:BoundField DataField="MoTaNgan" HeaderText="Mo Ta Ngan" SortExpression="MoTaNgan"  />
				<asp:BoundField DataField="MoTaChiTiet" HeaderText="Mo Ta Chi Tiet" SortExpression="MoTaChiTiet"  />
				<asp:BoundField DataField="AnhMinhHoa" HeaderText="Anh Minh Hoa" SortExpression="AnhMinhHoa"  />
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No SanPham Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnSanPham" OnClientClick="javascript:location.href='SanPhamEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:SanPhamDataSource ID="SanPhamDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:SanPhamProperty Name="CongTy"/> 
					<data:SanPhamProperty Name="LoaiSp"/> 
					<%--<data:SanPhamProperty Name="ThuocTinhSanPhamCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:SanPhamDataSource>
	    		
</asp:Content>



