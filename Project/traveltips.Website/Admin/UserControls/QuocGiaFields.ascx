<%@ Control Language="C#" ClassName="QuocGiaFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Quoc Gia:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdQuocGia" Text='<%# Bind("IdQuocGia") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdQuocGia" runat="server" Display="Dynamic" ControlToValidate="dataIdQuocGia" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdQuocGia" runat="server" Display="Dynamic" ControlToValidate="dataIdQuocGia" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ten Qg:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenQg" Text='<%# Bind("TenQg") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ma Qg:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMaQg" Text='<%# Bind("MaQg") %>' MaxLength="50"></asp:TextBox>
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


