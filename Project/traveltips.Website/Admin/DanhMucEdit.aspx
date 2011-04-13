
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DanhMucEdit.aspx.cs" Inherits="DanhMucEdit" Title="DanhMuc Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Danh Muc - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdDanhMuc" runat="server" DataSourceID="DanhMucDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DanhMucFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DanhMucFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>DanhMuc not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:DanhMucDataSource ID="DanhMucDataSource" runat="server"
			SelectMethod="GetByIdDanhMuc"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdDanhMuc" QueryStringField="IdDanhMuc" Type="String" />

			</Parameters>
		</data:DanhMucDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewCongTy" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewCongTy_SelectedIndexChanged"			 			 
			DataSourceID="CongTyDataSource"
			DataKeyNames="IdCongTy"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_CongTy.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="IdQuocGia" HeaderText="Id Quoc Gia" SortExpression="id_QuocGia" />				
				<asp:BoundField DataField="IdThanhPho" HeaderText="Id Thanh Pho" SortExpression="id_ThanhPho" />				
				<asp:BoundField DataField="IdQuan" HeaderText="Id Quan" SortExpression="id_Quan" />				
				<asp:BoundField DataField="IdDuong" HeaderText="Id Duong" SortExpression="id_Duong" />				
				<asp:BoundField DataField="IdKhuVuc" HeaderText="Id Khu Vuc" SortExpression="id_KhuVuc" />				
				<asp:BoundField DataField="SoNha" HeaderText="So Nha" SortExpression="SoNha" />				
				<asp:BoundField DataField="DienThoaiCd" HeaderText="Dien Thoai Cd" SortExpression="DienThoaiCD" />				
				<asp:BoundField DataField="DienThoaiDd" HeaderText="Dien Thoai Dd" SortExpression="DienThoaiDD" />				
				<asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax" />				
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />				
				<asp:BoundField DataField="Website" HeaderText="Website" SortExpression="Website" />				
				<asp:BoundField DataField="HinhThucTt" HeaderText="Hinh Thuc Tt" SortExpression="HinhThucTT" />				
				<asp:BoundField DataField="ThoiGianPv" HeaderText="Thoi Gian Pv" SortExpression="ThoiGianPV" />				
				<asp:BoundField DataField="AnhMinhHoa" HeaderText="Anh Minh Hoa" SortExpression="AnhMinhHoa" />				
				<asp:BoundField DataField="GhiChu" HeaderText="Ghi Chu" SortExpression="GhiChu" />				
				<asp:BoundField DataField="MoTaNgan" HeaderText="Mo Ta Ngan" SortExpression="MoTaNgan" />				
				<asp:BoundField DataField="MoTaChiTiet" HeaderText="Mo Ta Chi Tiet" SortExpression="MoTaChiTiet" />				
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Cong Ty Found! </b>
				<asp:HyperLink runat="server" ID="hypCongTy" NavigateUrl="~/admin/CongTyEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:CongTyDataSource ID="CongTyDataSource" runat="server" SelectMethod="Find">
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:CongTyFilter  Column="IdDanhMuc" QueryStringField="IdDanhMuc" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:CongTyDataSource>		
		
		<br />
		

</asp:Content>

