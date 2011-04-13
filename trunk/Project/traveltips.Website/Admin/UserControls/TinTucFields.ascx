<%@ Control Language="C#" ClassName="TinTucFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Tin Tuc:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdTinTuc" Text='<%# Bind("IdTinTuc") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdTinTuc" runat="server" Display="Dynamic" ControlToValidate="dataIdTinTuc" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdTinTuc" runat="server" Display="Dynamic" ControlToValidate="dataIdTinTuc" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Cong Ty:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdCongTy" DataSourceID="IdCongTyCongTyDataSource" DataTextField="IdQuocGia" DataValueField="IdCongTy" SelectedValue='<%# Bind("IdCongTy") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:CongTyDataSource ID="IdCongTyCongTyDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Tieu De:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTieuDe" Text='<%# Bind("TieuDe") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Mo Ta Ngan:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMoTaNgan" Text='<%# Bind("MoTaNgan") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Mo Ta Chi Tiet:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMoTaChiTiet" Text='<%# Bind("MoTaChiTiet") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Khuyen Mai:</td>
				<td>
					<asp:RadioButtonList runat="server" ID="dataKhuyenMai" SelectedValue='<%# Bind("KhuyenMai") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
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


