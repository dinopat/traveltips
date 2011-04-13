
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="QuocGiaEdit.aspx.cs" Inherits="QuocGiaEdit" Title="QuocGia Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Quoc Gia - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdQuocGia" runat="server" DataSourceID="QuocGiaDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/QuocGiaFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/QuocGiaFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>QuocGia not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:QuocGiaDataSource ID="QuocGiaDataSource" runat="server"
			SelectMethod="GetByIdQuocGia"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdQuocGia" QueryStringField="IdQuocGia" Type="String" />

			</Parameters>
		</data:QuocGiaDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewThanhPho" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewThanhPho_SelectedIndexChanged"			 			 
			DataSourceID="ThanhPhoDataSource"
			DataKeyNames="IdThanhPho"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_ThanhPho.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="TenTp" HeaderText="Ten Tp" SortExpression="TenTP" />				
				<asp:BoundField DataField="MaTp" HeaderText="Ma Tp" SortExpression="MaTP" />				
				<asp:BoundField DataField="Mota" HeaderText="Mota" SortExpression="Mota" />				
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Thanh Pho Found! </b>
				<asp:HyperLink runat="server" ID="hypThanhPho" NavigateUrl="~/admin/ThanhPhoEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ThanhPhoDataSource ID="ThanhPhoDataSource" runat="server" SelectMethod="Find">
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ThanhPhoFilter  Column="IdQuocGia" QueryStringField="IdQuocGia" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ThanhPhoDataSource>		
		
		<br />
		

</asp:Content>

