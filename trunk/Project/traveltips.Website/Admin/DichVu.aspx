
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DichVu.aspx.cs" Inherits="DichVu" Title="DichVu List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Dich Vu List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="DichVuDataSource"
				DataKeyNames="IdDichVu"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_DichVu.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Id Dich Vu" DataNavigateUrlFormatString="CongTyEdit.aspx?IdCongTy={0}" DataNavigateUrlFields="IdCongTy" DataContainer="IdDichVuSource" DataTextField="IdQuocGia" />
				<asp:BoundField DataField="IdCongTy" HeaderText="Id Cong Ty" SortExpression="id_CongTy"  />
				<asp:BoundField DataField="TenDv" HeaderText="Ten Dv" SortExpression="TenDV"  />
				<asp:BoundField DataField="MaDv" HeaderText="Ma Dv" SortExpression="MaDV"  />
				<asp:BoundField DataField="MotaNgan" HeaderText="Mota Ngan" SortExpression="MotaNgan"  />
				<asp:BoundField DataField="MotaChiTiet" HeaderText="Mota Chi Tiet" SortExpression="MotaChiTiet"  />
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No DichVu Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnDichVu" OnClientClick="javascript:location.href='DichVuEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:DichVuDataSource ID="DichVuDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:DichVuProperty Name="CongTy"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:DichVuDataSource>
	    		
</asp:Content>



