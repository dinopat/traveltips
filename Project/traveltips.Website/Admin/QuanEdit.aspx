
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="QuanEdit.aspx.cs" Inherits="QuanEdit" Title="Quan Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Quan - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="IdQuan" runat="server" DataSourceID="QuanDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/QuanFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/QuanFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Quan not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:QuanDataSource ID="QuanDataSource" runat="server"
			SelectMethod="GetByIdQuan"
		>
			<Parameters>
				<asp:QueryStringParameter Name="IdQuan" QueryStringField="IdQuan" Type="String" />

			</Parameters>
		</data:QuanDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewDuong" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewDuong_SelectedIndexChanged"			 			 
			DataSourceID="DuongDataSource"
			DataKeyNames="IdDuong"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Duong.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="TenDuong" HeaderText="Ten Duong" SortExpression="TenDuong" />				
				<asp:BoundField DataField="MaDuong" HeaderText="Ma Duong" SortExpression="MaDuong" />				
				<asp:BoundField DataField="MoTa" HeaderText="Mo Ta" SortExpression="MoTa" />				
				<asp:BoundField DataField="Flag" HeaderText="Flag" SortExpression="Flag" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Duong Found! </b>
				<asp:HyperLink runat="server" ID="hypDuong" NavigateUrl="~/admin/DuongEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:DuongDataSource ID="DuongDataSource" runat="server" SelectMethod="Find">
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:DuongFilter  Column="IdQuan" QueryStringField="IdQuan" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:DuongDataSource>		
		
		<br />
		

</asp:Content>

