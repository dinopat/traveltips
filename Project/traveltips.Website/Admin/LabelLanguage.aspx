
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="LabelLanguage.aspx.cs" Inherits="LabelLanguage" Title="LabelLanguage List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Label Language List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="LabelLanguageDataSource"
				DataKeyNames="IdLabelLanguage"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_LabelLanguage.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="IdLabelLanguage" HeaderText="Id Label Language" SortExpression="id_LabelLanguage" ReadOnly />
				<data:HyperLinkField HeaderText="Id Language" DataNavigateUrlFormatString="LanguageEdit.aspx?IdLanguage={0}" DataNavigateUrlFields="IdLanguage" DataContainer="IdLanguageSource" DataTextField="TenNn" />
				<data:HyperLinkField HeaderText="Id Label" DataNavigateUrlFormatString="LabelNnEdit.aspx?IdLabel={0}" DataNavigateUrlFields="IdLabel" DataContainer="IdLabelSource" DataTextField="MaLabel" />
				<asp:BoundField DataField="NoiDung" HeaderText="Noi Dung" SortExpression="NoiDung"  />
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No LabelLanguage Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnLabelLanguage" OnClientClick="javascript:location.href='LabelLanguageEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:LabelLanguageDataSource ID="LabelLanguageDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:LabelLanguageProperty Name="LabelNn"/> 
					<data:LabelLanguageProperty Name="Language"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:LabelLanguageDataSource>
	    		
</asp:Content>



