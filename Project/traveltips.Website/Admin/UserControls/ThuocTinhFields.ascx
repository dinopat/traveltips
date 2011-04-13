<%@ Control Language="C#" ClassName="ThuocTinhFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Thuoc Tinh:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdThuocTinh" Text='<%# Bind("IdThuocTinh") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdThuocTinh" runat="server" Display="Dynamic" ControlToValidate="dataIdThuocTinh" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdThuocTinh" runat="server" Display="Dynamic" ControlToValidate="dataIdThuocTinh" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ten Thuoc Tinh:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenThuocTinh" Text='<%# Bind("TenThuocTinh") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ma Thuoc Tinh:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMaThuocTinh" Text='<%# Bind("MaThuocTinh") %>' MaxLength="50"></asp:TextBox>
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


