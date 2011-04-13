
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ThuocTinhSanPhamEdit.aspx.cs" Inherits="ThuocTinhSanPhamEdit" Title="ThuocTinhSanPham Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Thuoc Tinh San Pham - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdTtsp" runat="server" DataSourceID="ThuocTinhSanPhamDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ThuocTinhSanPhamFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ThuocTinhSanPhamFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ThuocTinhSanPham not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ThuocTinhSanPhamDataSource ID="ThuocTinhSanPhamDataSource" runat="server"
			SelectMethod="GetByIdTtsp"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdTtsp" QueryStringField="IdTtsp" Type="String" />

			</Parameters>
		</data:ThuocTinhSanPhamDataSource>
		
		<br />

		

</asp:Content>

