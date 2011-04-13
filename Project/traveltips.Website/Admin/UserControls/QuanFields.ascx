<%@ Control Language="C#" ClassName="QuanFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Quan:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdQuan" Text='<%# Bind("IdQuan") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdQuan" runat="server" Display="Dynamic" ControlToValidate="dataIdQuan" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdQuan" runat="server" Display="Dynamic" ControlToValidate="dataIdQuan" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Thanh Pho:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdThanhPho" DataSourceID="IdThanhPhoThanhPhoDataSource" DataTextField="TenTp" DataValueField="IdThanhPho" SelectedValue='<%# Bind("IdThanhPho") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:ThanhPhoDataSource ID="IdThanhPhoThanhPhoDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Ten Quan:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenQuan" Text='<%# Bind("TenQuan") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ma Quan:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMaQuan" Text='<%# Bind("MaQuan") %>' MaxLength="50"></asp:TextBox>
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


