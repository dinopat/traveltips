<%@ Control Language="C#" ClassName="TuDienFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Tu Dien:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdTuDien" Text='<%# Bind("IdTuDien") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdTuDien" runat="server" Display="Dynamic" ControlToValidate="dataIdTuDien" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdTuDien" runat="server" Display="Dynamic" ControlToValidate="dataIdTuDien" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Danh Muc:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdDanhMuc" Text='<%# Bind("IdDanhMuc") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataIdDanhMuc" runat="server" Display="Dynamic" ControlToValidate="dataIdDanhMuc" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ten Tu:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenTu" Text='<%# Bind("TenTu") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ma Tu:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMaTu" Text='<%# Bind("MaTu") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Nhom Tu:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNhomTu" Text='<%# Bind("NhomTu") %>' MaxLength="50"></asp:TextBox>
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


