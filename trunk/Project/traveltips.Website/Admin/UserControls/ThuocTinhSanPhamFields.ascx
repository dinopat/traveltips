<%@ Control Language="C#" ClassName="ThuocTinhSanPhamFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Ttsp:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdTtsp" Text='<%# Bind("IdTtsp") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdTtsp" runat="server" Display="Dynamic" ControlToValidate="dataIdTtsp" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdTtsp" runat="server" Display="Dynamic" ControlToValidate="dataIdTtsp" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id San Pham:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdSanPham" DataSourceID="IdSanPhamSanPhamDataSource" DataTextField="IdCongTy" DataValueField="IdSanPham" SelectedValue='<%# Bind("IdSanPham") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:SanPhamDataSource ID="IdSanPhamSanPhamDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Thuoc Tinh:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdThuocTinh" DataSourceID="IdThuocTinhThuocTinhDataSource" DataTextField="TenThuocTinh" DataValueField="IdThuocTinh" SelectedValue='<%# Bind("IdThuocTinh") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:ThuocTinhDataSource ID="IdThuocTinhThuocTinhDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Value1:</td>
				<td>
					<asp:TextBox runat="server" ID="dataValue1" Text='<%# Bind("Value1") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Value2:</td>
				<td>
					<asp:TextBox runat="server" ID="dataValue2" Text='<%# Bind("Value2") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
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


