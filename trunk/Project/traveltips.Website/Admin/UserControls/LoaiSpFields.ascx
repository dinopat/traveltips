<%@ Control Language="C#" ClassName="LoaiSpFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Loai Sp:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdLoaiSp" Text='<%# Bind("IdLoaiSp") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdLoaiSp" runat="server" Display="Dynamic" ControlToValidate="dataIdLoaiSp" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdLoaiSp" runat="server" Display="Dynamic" ControlToValidate="dataIdLoaiSp" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Loai Sp Cha:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdLoaiSpCha" Text='<%# Bind("IdLoaiSpCha") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataIdLoaiSpCha" runat="server" Display="Dynamic" ControlToValidate="dataIdLoaiSpCha" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ten Loai Sp:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenLoaiSp" Text='<%# Bind("TenLoaiSp") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ma Loai Sp:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMaLoaiSp" Text='<%# Bind("MaLoaiSp") %>' MaxLength="50"></asp:TextBox>
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


