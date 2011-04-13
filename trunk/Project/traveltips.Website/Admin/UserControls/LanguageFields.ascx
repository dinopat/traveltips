<%@ Control Language="C#" ClassName="LanguageFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Language:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdLanguage" Text='<%# Bind("IdLanguage") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdLanguage" runat="server" Display="Dynamic" ControlToValidate="dataIdLanguage" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdLanguage" runat="server" Display="Dynamic" ControlToValidate="dataIdLanguage" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ten Nn:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenNn" Text='<%# Bind("TenNn") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ma Nn:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMaNn" Text='<%# Bind("MaNn") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Mota:</td>
				<td>
					<asp:HiddenField runat="server" id="dataMota" Value='<%# Bind("Mota") %>'></asp:HiddenField>
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


