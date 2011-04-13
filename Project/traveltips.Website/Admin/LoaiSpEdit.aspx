
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="LoaiSpEdit.aspx.cs" Inherits="LoaiSpEdit" Title="LoaiSp Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Loai Sp - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdLoaiSp" runat="server" DataSourceID="LoaiSpDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LoaiSpFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LoaiSpFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>LoaiSp not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:LoaiSpDataSource ID="LoaiSpDataSource" runat="server"
			SelectMethod="GetByIdLoaiSp"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdLoaiSp" QueryStringField="IdLoaiSp" Type="String" />

			</Parameters>
		</data:LoaiSpDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewSanPham" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewSanPham_SelectedIndexChanged"			 			 
			DataSourceID="SanPhamDataSource"
			DataKeyNames="IdSanPham"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_SanPham.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="IdCongTy" HeaderText="Id Cong Ty" SortExpression="id_CongTy" />				
				<asp:BoundField DataField="IdTuDien" HeaderText="Id Tu Dien" SortExpression="id_TuDien" />				
				<asp:BoundField DataField="TenSp" HeaderText="Ten Sp" SortExpression="TenSP" />				
				<asp:BoundField DataField="MaSp" HeaderText="Ma Sp" SortExpression="MaSP" />				
				<asp:BoundField DataField="Gia" HeaderText="Gia" SortExpression="Gia" />				
				<asp:BoundField DataField="MoTaNgan" HeaderText="Mo Ta Ngan" SortExpression="MoTaNgan" />				
				<asp:BoundField DataField="MoTaChiTiet" HeaderText="Mo Ta Chi Tiet" SortExpression="MoTaChiTiet" />				
				<asp:BoundField DataField="AnhMinhHoa" HeaderText="Anh Minh Hoa" SortExpression="AnhMinhHoa" />				
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No San Pham Found! </b>
				<asp:HyperLink runat="server" ID="hypSanPham" NavigateUrl="~/admin/SanPhamEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:SanPhamDataSource ID="SanPhamDataSource" runat="server" SelectMethod="Find">
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:SanPhamFilter  Column="IdLoaiSp" QueryStringField="IdLoaiSp" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:SanPhamDataSource>		
		
		<br />
		

</asp:Content>

