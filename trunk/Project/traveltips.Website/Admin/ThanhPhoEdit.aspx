
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ThanhPhoEdit.aspx.cs" Inherits="ThanhPhoEdit" Title="ThanhPho Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Thanh Pho - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdThanhPho" runat="server" DataSourceID="ThanhPhoDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ThanhPhoFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ThanhPhoFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ThanhPho not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ThanhPhoDataSource ID="ThanhPhoDataSource" runat="server"
			SelectMethod="GetByIdThanhPho"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdThanhPho" QueryStringField="IdThanhPho" Type="String" />

			</Parameters>
		</data:ThanhPhoDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewQuan" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewQuan_SelectedIndexChanged"			 			 
			DataSourceID="QuanDataSource"
			DataKeyNames="IdQuan"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Quan.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="TenQuan" HeaderText="Ten Quan" SortExpression="TenQuan" />				
				<asp:BoundField DataField="MaQuan" HeaderText="Ma Quan" SortExpression="MaQuan" />				
				<asp:BoundField DataField="MoTa" HeaderText="Mo Ta" SortExpression="MoTa" />				
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Quan Found! </b>
				<asp:HyperLink runat="server" ID="hypQuan" NavigateUrl="~/admin/QuanEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:QuanDataSource ID="QuanDataSource" runat="server" SelectMethod="Find">
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:QuanFilter  Column="IdThanhPho" QueryStringField="IdThanhPho" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:QuanDataSource>		
		
		<br />
		

</asp:Content>

