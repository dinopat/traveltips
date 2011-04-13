
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="LabelLanguageEdit.aspx.cs" Inherits="LabelLanguageEdit" Title="LabelLanguage Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Label Language - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdLabelLanguage" runat="server" DataSourceID="LabelLanguageDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LabelLanguageFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LabelLanguageFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>LabelLanguage not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:LabelLanguageDataSource ID="LabelLanguageDataSource" runat="server"
			SelectMethod="GetByIdLabelLanguage"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdLabelLanguage" QueryStringField="IdLabelLanguage" Type="String" />

			</Parameters>
		</data:LabelLanguageDataSource>
		
		<br />

		

</asp:Content>

