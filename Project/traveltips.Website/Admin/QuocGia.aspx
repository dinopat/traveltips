
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="QuocGia.aspx.cs" Inherits="QuocGia" Title="QuocGia List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Quoc Gia List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="QuocGiaDataSource"
				DataKeyNames="IdQuocGia"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_QuocGia.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="IdQuocGia" HeaderText="Id Quoc Gia" SortExpression="id_QuocGia" ReadOnly />
				<asp:BoundField DataField="TenQg" HeaderText="Ten Qg" SortExpression="TenQG"  />
				<asp:BoundField DataField="MaQg" HeaderText="Ma Qg" SortExpression="MaQG"  />
				<asp:BoundField DataField="MoTa" HeaderText="Mo Ta" SortExpression="MoTa"  />
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No QuocGia Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnQuocGia" OnClientClick="javascript:location.href='QuocGiaEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:QuocGiaDataSource ID="QuocGiaDataSource" runat="server"
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
		</data:QuocGiaDataSource>
	    		
</asp:Content>



