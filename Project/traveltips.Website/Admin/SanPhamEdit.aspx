
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SanPhamEdit.aspx.cs" Inherits="SanPhamEdit" Title="SanPham Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">San Pham - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdSanPham" runat="server" DataSourceID="SanPhamDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SanPhamFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SanPhamFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>SanPham not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:SanPhamDataSource ID="SanPhamDataSource" runat="server"
			SelectMethod="GetByIdSanPham"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdSanPham" QueryStringField="IdSanPham" Type="String" />

			</Parameters>
		</data:SanPhamDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewThuocTinhSanPham" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewThuocTinhSanPham_SelectedIndexChanged"			 			 
			DataSourceID="ThuocTinhSanPhamDataSource"
			DataKeyNames="IdTtsp"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_ThuocTinhSanPham.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Value1" HeaderText="Value1" SortExpression="Value1" />				
				<asp:BoundField DataField="Value2" HeaderText="Value2" SortExpression="Value2" />				
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Thuoc Tinh San Pham Found! </b>
				<asp:HyperLink runat="server" ID="hypThuocTinhSanPham" NavigateUrl="~/admin/ThuocTinhSanPhamEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ThuocTinhSanPhamDataSource ID="ThuocTinhSanPhamDataSource" runat="server" SelectMethod="Find">
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ThuocTinhSanPhamFilter  Column="IdSanPham" QueryStringField="IdSanPham" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ThuocTinhSanPhamDataSource>		
		
		<br />
		

</asp:Content>

