
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="TinTuc.aspx.cs" Inherits="TinTuc" Title="TinTuc List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Tin Tuc List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="TinTucDataSource"
				DataKeyNames="IdTinTuc"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_TinTuc.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="IdTinTuc" HeaderText="Id Tin Tuc" SortExpression="id_TinTuc" ReadOnly />
				<data:HyperLinkField HeaderText="Id Cong Ty" DataNavigateUrlFormatString="CongTyEdit.aspx?IdCongTy={0}" DataNavigateUrlFields="IdCongTy" DataContainer="IdCongTySource" DataTextField="IdQuocGia" />
				<asp:BoundField DataField="TieuDe" HeaderText="Tieu De" SortExpression="TieuDe"  />
				<asp:BoundField DataField="MoTaNgan" HeaderText="Mo Ta Ngan" SortExpression="MoTaNgan"  />
				<asp:BoundField DataField="MoTaChiTiet" HeaderText="Mo Ta Chi Tiet" SortExpression="MoTaChiTiet"  />
				<data:BoundRadioButtonField DataField="KhuyenMai" HeaderText="Khuyen Mai" SortExpression="[KhuyenMai]"  />
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No TinTuc Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnTinTuc" OnClientClick="javascript:location.href='TinTucEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:TinTucDataSource ID="TinTucDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:TinTucProperty Name="CongTy"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:TinTucDataSource>
	    		
</asp:Content>



