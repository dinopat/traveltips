
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ChuCongTy.aspx.cs" Inherits="ChuCongTy" Title="ChuCongTy List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Chu Cong Ty List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ChuCongTyDataSource"
				DataKeyNames="IdChuCongTy"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ChuCongTy.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="IdChuCongTy" HeaderText="Id Chu Cong Ty" SortExpression="id_ChuCongTy" ReadOnly />
				<asp:BoundField DataField="TenChuCongTy" HeaderText="Ten Chu Cong Ty" SortExpression="TenChuCongTy"  />
				<asp:BoundField DataField="TenCongTy" HeaderText="Ten Cong Ty" SortExpression="TenCongTy"  />
				<asp:BoundField DataField="TenDangNhap" HeaderText="Ten Dang Nhap" SortExpression="TenDangNhap"  />
				<asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password"  />
				<asp:BoundField DataField="DiaChi" HeaderText="Dia Chi" SortExpression="DiaChi"  />
				<asp:BoundField DataField="DienThoaiCd" HeaderText="Dien Thoai Cd" SortExpression="DienThoaiCD"  />
				<asp:BoundField DataField="DienThoaiDd" HeaderText="Dien Thoai Dd" SortExpression="DienThoaiDD"  />
				<asp:BoundField DataField="NgayTao" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngay Tao" SortExpression="NgayTao"  />
				<asp:BoundField DataField="NgayKetThuc" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngay Ket Thuc" SortExpression="NgayKetThuc"  />
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No ChuCongTy Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnChuCongTy" OnClientClick="javascript:location.href='ChuCongTyEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ChuCongTyDataSource ID="ChuCongTyDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
>			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ChuCongTyDataSource>
	    		
</asp:Content>



