
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Quan.aspx.cs" Inherits="Quan" Title="Quan List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Quan List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="QuanDataSource"
				DataKeyNames="IdQuan"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Quan.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="IdQuan" HeaderText="Id Quan" SortExpression="id_Quan" ReadOnly />
				<data:HyperLinkField HeaderText="Id Thanh Pho" DataNavigateUrlFormatString="ThanhPhoEdit.aspx?IdThanhPho={0}" DataNavigateUrlFields="IdThanhPho" DataContainer="IdThanhPhoSource" DataTextField="TenTp" />
				<asp:BoundField DataField="TenQuan" HeaderText="Ten Quan" SortExpression="TenQuan"  />
				<asp:BoundField DataField="MaQuan" HeaderText="Ma Quan" SortExpression="MaQuan"  />
				<asp:BoundField DataField="MoTa" HeaderText="Mo Ta" SortExpression="MoTa"  />
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Quan Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnQuan" OnClientClick="javascript:location.href='QuanEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:QuanDataSource ID="QuanDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:QuanProperty Name="ThanhPho"/> 
					<%--<data:QuanProperty Name="DuongCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:QuanDataSource>
	    		
</asp:Content>



