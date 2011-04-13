<%@ Control Language="C#" ClassName="UserFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id User:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdUser" Text='<%# Bind("IdUser") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdUser" runat="server" Display="Dynamic" ControlToValidate="dataIdUser" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdUser" runat="server" Display="Dynamic" ControlToValidate="dataIdUser" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ten Dang Nhap:</td>
				<td>
					<asp:HiddenField runat="server" id="dataTenDangNhap" Value='<%# Bind("TenDangNhap") %>'></asp:HiddenField>
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
					<asp:TextBox runat="server" ID="dataHoTen" Text='<%# Bind("HoTen") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Email:</td>
				<td>
					<asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Dia Chi:</td>
				<td>
					<asp:TextBox runat="server" ID="dataDiaChi" Text='<%# Bind("DiaChi") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Dien Thoai:</td>
				<td>
					<asp:HiddenField runat="server" id="dataDienThoai" Value='<%# Bind("DienThoai") %>'></asp:HiddenField>
				</td>
			</tr>				
			<tr>
				<td class="literal">Website:</td>
				<td>
					<asp:TextBox runat="server" ID="dataWebsite" Text='<%# Bind("Website") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Avatar:</td>
				<td>
					<asp:TextBox runat="server" ID="dataAvatar" Text='<%# Bind("Avatar") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
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


