<%@ Control Language="C#" ClassName="DanhMucFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Danh Muc:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdDanhMuc" Text='<%# Bind("IdDanhMuc") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdDanhMuc" runat="server" Display="Dynamic" ControlToValidate="dataIdDanhMuc" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdDanhMuc" runat="server" Display="Dynamic" ControlToValidate="dataIdDanhMuc" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Dm Cha:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdDmCha" Text='<%# Bind("IdDmCha") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataIdDmCha" runat="server" Display="Dynamic" ControlToValidate="dataIdDmCha" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ten Danh Muc:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenDanhMuc" Text='<%# Bind("TenDanhMuc") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ma Danh Muc:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMaDanhMuc" Text='<%# Bind("MaDanhMuc") %>' MaxLength="50"></asp:TextBox>
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


