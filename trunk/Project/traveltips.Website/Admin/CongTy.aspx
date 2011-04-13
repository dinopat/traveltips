
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CongTy.aspx.cs" Inherits="CongTy" Title="CongTy List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Cong Ty List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="CongTyDataSource"
				DataKeyNames="IdCongTy"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_CongTy.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="IdCongTy" HeaderText="Id Cong Ty" SortExpression="id_CongTy" ReadOnly />
				<data:HyperLinkField HeaderText="Id Chu Cong Ty" DataNavigateUrlFormatString="ChuCongTyEdit.aspx?IdChuCongTy={0}" DataNavigateUrlFields="IdChuCongTy" DataContainer="IdChuCongTySource" DataTextField="TenChuCongTy" />
				<data:HyperLinkField HeaderText="Id Danh Muc" DataNavigateUrlFormatString="DanhMucEdit.aspx?IdDanhMuc={0}" DataNavigateUrlFields="IdDanhMuc" DataContainer="IdDanhMucSource" DataTextField="IdDmCha" />
				<asp:BoundField DataField="IdQuocGia" HeaderText="Id Quoc Gia" SortExpression="id_QuocGia"  />
				<asp:BoundField DataField="IdThanhPho" HeaderText="Id Thanh Pho" SortExpression="id_ThanhPho"  />
				<asp:BoundField DataField="IdQuan" HeaderText="Id Quan" SortExpression="id_Quan"  />
				<asp:BoundField DataField="IdDuong" HeaderText="Id Duong" SortExpression="id_Duong"  />
				<asp:BoundField DataField="IdKhuVuc" HeaderText="Id Khu Vuc" SortExpression="id_KhuVuc"  />
				<asp:BoundField DataField="SoNha" HeaderText="So Nha" SortExpression="SoNha"  />
				<asp:BoundField DataField="DienThoaiCd" HeaderText="Dien Thoai Cd" SortExpression="DienThoaiCD"  />
				<asp:BoundField DataField="DienThoaiDd" HeaderText="Dien Thoai Dd" SortExpression="DienThoaiDD"  />
				<asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax"  />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"  />
				<asp:BoundField DataField="Website" HeaderText="Website" SortExpression="Website"  />
				<asp:BoundField DataField="HinhThucTt" HeaderText="Hinh Thuc Tt" SortExpression="HinhThucTT"  />
				<asp:BoundField DataField="ThoiGianPv" HeaderText="Thoi Gian Pv" SortExpression="ThoiGianPV"  />
				<asp:BoundField DataField="AnhMinhHoa" HeaderText="Anh Minh Hoa" SortExpression="AnhMinhHoa"  />
				<asp:BoundField DataField="GhiChu" HeaderText="Ghi Chu" SortExpression="GhiChu"  />
				<asp:BoundField DataField="MoTaNgan" HeaderText="Mo Ta Ngan" SortExpression="MoTaNgan"  />
				<asp:BoundField DataField="MoTaChiTiet" HeaderText="Mo Ta Chi Tiet" SortExpression="MoTaChiTiet"  />
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No CongTy Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnCongTy" OnClientClick="javascript:location.href='CongTyEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:CongTyDataSource ID="CongTyDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CongTyProperty Name="ChuCongTy"/> 
					<data:CongTyProperty Name="DanhMuc"/> 
					<%--<data:CongTyProperty Name="GalleryCollection" />--%>
					<%--<data:CongTyProperty Name="TinTucCollection" />--%>
					<%--<data:CongTyProperty Name="DichVu" />--%>
					<%--<data:CongTyProperty Name="CommentCollection" />--%>
					<%--<data:CongTyProperty Name="SanPham" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:CongTyDataSource>
	    		
</asp:Content>



