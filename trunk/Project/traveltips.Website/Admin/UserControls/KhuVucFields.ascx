<%@ Control Language="C#" ClassName="KhuVucFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Khu Vuc:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdKhuVuc" Text='<%# Bind("IdKhuVuc") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdKhuVuc" runat="server" Display="Dynamic" ControlToValidate="dataIdKhuVuc" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdKhuVuc" runat="server" Display="Dynamic" ControlToValidate="dataIdKhuVuc" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ten Kv:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenKv" Text='<%# Bind("TenKv") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ma Kv:</td>
				<td>
					<asp:HiddenField runat="server" id="dataMaKv" Value='<%# Bind("MaKv") %>'></asp:HiddenField>
				</td>
			</tr>				
			<tr>
				<td class="literal">Mo Ta:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMoTa" Text='<%# Bind("MoTa") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
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


