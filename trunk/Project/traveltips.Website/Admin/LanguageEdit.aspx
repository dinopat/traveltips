
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="LanguageEdit.aspx.cs" Inherits="LanguageEdit" Title="Language Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Language - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdLanguage" runat="server" DataSourceID="LanguageDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LanguageFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LanguageFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Language not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:LanguageDataSource ID="LanguageDataSource" runat="server"
			SelectMethod="GetByIdLanguage"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdLanguage" QueryStringField="IdLanguage" Type="String" />

			</Parameters>
		</data:LanguageDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewLabelLanguage" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewLabelLanguage_SelectedIndexChanged"			 			 
			DataSourceID="LabelLanguageDataSource"
			DataKeyNames="IdLabelLanguage"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_LabelLanguage.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="NoiDung" HeaderText="Noi Dung" SortExpression="NoiDung" />				
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Label Language Found! </b>
				<asp:HyperLink runat="server" ID="hypLabelLanguage" NavigateUrl="~/admin/LabelLanguageEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:LabelLanguageDataSource ID="LabelLanguageDataSource" runat="server" SelectMethod="Find">
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:LabelLanguageFilter  Column="IdLanguage" QueryStringField="IdLanguage" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:LabelLanguageDataSource>		
		
		<br />
		

</asp:Content>

