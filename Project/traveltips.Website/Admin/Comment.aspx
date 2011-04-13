
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Comment.aspx.cs" Inherits="Comment" Title="Comment List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Comment List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="CommentDataSource"
				DataKeyNames="IdComment"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Comment.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="IdComment" HeaderText="Id Comment" SortExpression="id_Comment" ReadOnly />
				<data:HyperLinkField HeaderText="Id User" DataNavigateUrlFormatString="UserEdit.aspx?IdUser={0}" DataNavigateUrlFields="IdUser" DataContainer="IdUserSource" DataTextField="TenDangNhap" />
				<data:HyperLinkField HeaderText="Id Congty" DataNavigateUrlFormatString="CongTyEdit.aspx?IdCongTy={0}" DataNavigateUrlFields="IdCongTy" DataContainer="IdCongtySource" DataTextField="IdQuocGia" />
				<asp:BoundField DataField="TieuDe" HeaderText="Tieu De" SortExpression="TieuDe"  />
				<asp:BoundField DataField="NoiDung" HeaderText="Noi Dung" SortExpression="NoiDung"  />
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Comment Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnComment" OnClientClick="javascript:location.href='CommentEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:CommentDataSource ID="CommentDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CommentProperty Name="CongTy"/> 
					<data:CommentProperty Name="User"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:CommentDataSource>
	    		
</asp:Content>



