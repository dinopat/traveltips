
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="LabelNnEdit.aspx.cs" Inherits="LabelNnEdit" Title="LabelNn Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Label Nn - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdLabel" runat="server" DataSourceID="LabelNnDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LabelNnFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LabelNnFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>LabelNn not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:LabelNnDataSource ID="LabelNnDataSource" runat="server"
			SelectMethod="GetByIdLabel"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdLabel" QueryStringField="IdLabel" Type="String" />

			</Parameters>
		</data:LabelNnDataSource>
		
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
						<data:LabelLanguageFilter  Column="IdLabel" QueryStringField="IdLabel" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:LabelLanguageDataSource>		
		
		<br />
		

</asp:Content>

