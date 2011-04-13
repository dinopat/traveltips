<%@ Control Language="C#" ClassName="DichVuFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Dich Vu:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdDichVu" DataSourceID="IdDichVuCongTyDataSource" DataTextField="IdQuocGia" DataValueField="IdCongTy" SelectedValue='<%# Bind("IdDichVu") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CongTyDataSource ID="IdDichVuCongTyDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Cong Ty:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdCongTy" Text='<%# Bind("IdCongTy") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ten Dv:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenDv" Text='<%# Bind("TenDv") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ma Dv:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMaDv" Text='<%# Bind("MaDv") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Mota Ngan:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMotaNgan" Text='<%# Bind("MotaNgan") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Mota Chi Tiet:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMotaChiTiet" Text='<%# Bind("MotaChiTiet") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
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


