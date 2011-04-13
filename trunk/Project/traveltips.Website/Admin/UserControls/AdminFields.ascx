<%@ Control Language="C#" ClassName="AdminFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Admin:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdAdmin" Text='<%# Bind("IdAdmin") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdAdmin" runat="server" Display="Dynamic" ControlToValidate="dataIdAdmin" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdAdmin" runat="server" Display="Dynamic" ControlToValidate="dataIdAdmin" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ten Dang Nhap:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenDangNhap" Text='<%# Bind("TenDangNhap") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Email:</td>
				<td>
					<asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Password:</td>
				<td>
					<asp:TextBox runat="server" ID="dataPassword" Text='<%# Bind("Password") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ho Ten:</td>
				<td>
					<asp:TextBox runat="server" ID="dataHoTen" Text='<%# Bind("HoTen") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Dien Thoai:</td>
				<td>
					<asp:TextBox runat="server" ID="dataDienThoai" Text='<%# Bind("DienThoai") %>' MaxLength="50"></asp:TextBox>
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


