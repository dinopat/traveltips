<%@ Control Language="C#" ClassName="ThanhPhoFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Thanh Pho:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdThanhPho" Text='<%# Bind("IdThanhPho") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdThanhPho" runat="server" Display="Dynamic" ControlToValidate="dataIdThanhPho" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdThanhPho" runat="server" Display="Dynamic" ControlToValidate="dataIdThanhPho" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Quoc Gia:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdQuocGia" DataSourceID="IdQuocGiaQuocGiaDataSource" DataTextField="TenQg" DataValueField="IdQuocGia" SelectedValue='<%# Bind("IdQuocGia") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:QuocGiaDataSource ID="IdQuocGiaQuocGiaDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Ten Tp:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenTp" Text='<%# Bind("TenTp") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ma Tp:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMaTp" Text='<%# Bind("MaTp") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Mota:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMota" Text='<%# Bind("Mota") %>' MaxLength="50"></asp:TextBox>
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


