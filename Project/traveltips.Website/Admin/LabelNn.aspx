
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="LabelNn.aspx.cs" Inherits="LabelNn" Title="LabelNn List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Label Nn List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="LabelNnDataSource"
				DataKeyNames="IdLabel"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_LabelNn.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="IdLabel" HeaderText="Id Label" SortExpression="id_Label" ReadOnly />
				<asp:BoundField DataField="MaLabel" HeaderText="Ma Label" SortExpression="MaLabel"  />
				<asp:BoundField DataField="TenLabel" HeaderText="Ten Label" SortExpression="TenLabel"  />
				<asp:BoundField DataField="MoTa" HeaderText="Mo Ta" SortExpression="MoTa"  />
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No LabelNn Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnLabelNn" OnClientClick="javascript:location.href='LabelNnEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:LabelNnDataSource ID="LabelNnDataSource" runat="server"
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
		</data:LabelNnDataSource>
	    		
</asp:Content>



