
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CongTyEdit.aspx.cs" Inherits="CongTyEdit" Title="CongTy Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Cong Ty - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdCongTy" runat="server" DataSourceID="CongTyDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CongTyFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CongTyFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>CongTy not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:CongTyDataSource ID="CongTyDataSource" runat="server"
			SelectMethod="GetByIdCongTy"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdCongTy" QueryStringField="IdCongTy" Type="String" />

			</Parameters>
		</data:CongTyDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewGallery" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewGallery_SelectedIndexChanged"			 			 
			DataSourceID="GalleryDataSource"
			DataKeyNames="IdGallery"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Gallery.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="TenAnh" HeaderText="Ten Anh" SortExpression="TenAnh" />				
				<asp:BoundField DataField="DuongDan" HeaderText="Duong Dan" SortExpression="DuongDan" />				
				<asp:BoundField DataField="MoTa" HeaderText="Mo Ta" SortExpression="MoTa" />				
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Gallery Found! </b>
				<asp:HyperLink runat="server" ID="hypGallery" NavigateUrl="~/admin/GalleryEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:GalleryDataSource ID="GalleryDataSource" runat="server" SelectMethod="Find">
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:GalleryFilter  Column="IdCongTy" QueryStringField="IdCongTy" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:GalleryDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewTinTuc" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewTinTuc_SelectedIndexChanged"			 			 
			DataSourceID="TinTucDataSource"
			DataKeyNames="IdTinTuc"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_TinTuc.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="TieuDe" HeaderText="Tieu De" SortExpression="TieuDe" />				
				<asp:BoundField DataField="MoTaNgan" HeaderText="Mo Ta Ngan" SortExpression="MoTaNgan" />				
				<asp:BoundField DataField="MoTaChiTiet" HeaderText="Mo Ta Chi Tiet" SortExpression="MoTaChiTiet" />				
				<asp:BoundField DataField="KhuyenMai" HeaderText="Khuyen Mai" SortExpression="KhuyenMai" />				
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Tin Tuc Found! </b>
				<asp:HyperLink runat="server" ID="hypTinTuc" NavigateUrl="~/admin/TinTucEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:TinTucDataSource ID="TinTucDataSource" runat="server" SelectMethod="Find">
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:TinTucFilter  Column="IdCongTy" QueryStringField="IdCongTy" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:TinTucDataSource>		
		
		<br />
		

</asp:Content>

