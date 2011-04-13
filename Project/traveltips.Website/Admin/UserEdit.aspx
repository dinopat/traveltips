
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="UserEdit.aspx.cs" Inherits="UserEdit" Title="User Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">User - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdUser" runat="server" DataSourceID="UserDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/UserFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/UserFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>User not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:UserDataSource ID="UserDataSource" runat="server"
			SelectMethod="GetByIdUser"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdUser" QueryStringField="IdUser" Type="String" />

			</Parameters>
		</data:UserDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewComment" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewComment_SelectedIndexChanged"			 			 
			DataSourceID="CommentDataSource"
			DataKeyNames="IdComment"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Comment.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="TieuDe" HeaderText="Tieu De" SortExpression="TieuDe" />				
				<asp:BoundField DataField="NoiDung" HeaderText="Noi Dung" SortExpression="NoiDung" />				
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Comment Found! </b>
				<asp:HyperLink runat="server" ID="hypComment" NavigateUrl="~/admin/CommentEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:CommentDataSource ID="CommentDataSource" runat="server" SelectMethod="Find">
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:CommentFilter  Column="IdUser" QueryStringField="IdUser" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:CommentDataSource>		
		
		<br />
		

</asp:Content>

