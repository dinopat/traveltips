
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ThanhPho.aspx.cs" Inherits="ThanhPho" Title="ThanhPho List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Thanh Pho List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ThanhPhoDataSource"
				DataKeyNames="IdThanhPho"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ThanhPho.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="IdThanhPho" HeaderText="Id Thanh Pho" SortExpression="id_ThanhPho" ReadOnly />
				<data:HyperLinkField HeaderText="Id Quoc Gia" DataNavigateUrlFormatString="QuocGiaEdit.aspx?IdQuocGia={0}" DataNavigateUrlFields="IdQuocGia" DataContainer="IdQuocGiaSource" DataTextField="TenQg" />
				<asp:BoundField DataField="TenTp" HeaderText="Ten Tp" SortExpression="TenTP"  />
				<asp:BoundField DataField="MaTp" HeaderText="Ma Tp" SortExpression="MaTP"  />
				<asp:BoundField DataField="Mota" HeaderText="Mota" SortExpression="Mota"  />
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No ThanhPho Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnThanhPho" OnClientClick="javascript:location.href='ThanhPhoEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ThanhPhoDataSource ID="ThanhPhoDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ThanhPhoProperty Name="QuocGia"/> 
					<%--<data:ThanhPhoProperty Name="QuanCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ThanhPhoDataSource>
	    		
</asp:Content>



