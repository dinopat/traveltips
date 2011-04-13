<%@ Control Language="C#" ClassName="DuongFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Duong:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdDuong" Text='<%# Bind("IdDuong") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdDuong" runat="server" Display="Dynamic" ControlToValidate="dataIdDuong" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdDuong" runat="server" Display="Dynamic" ControlToValidate="dataIdDuong" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Quan:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdQuan" DataSourceID="IdQuanQuanDataSource" DataTextField="TenQuan" DataValueField="IdQuan" SelectedValue='<%# Bind("IdQuan") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:QuanDataSource ID="IdQuanQuanDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Ten Duong:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenDuong" Text='<%# Bind("TenDuong") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ma Duong:</td>
				<td>
					<asp:HiddenField runat="server" id="dataMaDuong" Value='<%# Bind("MaDuong") %>'></asp:HiddenField>
				</td>
			</tr>				
			<tr>
				<td class="literal">Mo Ta:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMoTa" Text='<%# Bind("MoTa") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Flag:</td>
				<td>
					<asp:TextBox runat="server" ID="dataFlag" Text='<%# Bind("Flag") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataFlag" runat="server" Display="Dynamic" ControlToValidate="dataFlag" ErrorMessage="Invalid value" MaximumValue="255" MinimumValue="0" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			
		</table>

	</ItemTemplate>
</asp:FormView>


