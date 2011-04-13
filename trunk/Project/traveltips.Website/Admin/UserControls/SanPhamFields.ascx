<%@ Control Language="C#" ClassName="SanPhamFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id San Pham:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdSanPham" DataSourceID="IdSanPhamCongTyDataSource" DataTextField="IdQuocGia" DataValueField="IdCongTy" SelectedValue='<%# Bind("IdSanPham") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CongTyDataSource ID="IdSanPhamCongTyDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Cong Ty:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdCongTy" Text='<%# Bind("IdCongTy") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataIdCongTy" runat="server" Display="Dynamic" ControlToValidate="dataIdCongTy" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Loai Sp:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdLoaiSp" DataSourceID="IdLoaiSpLoaiSpDataSource" DataTextField="IdLoaiSpCha" DataValueField="IdLoaiSp" SelectedValue='<%# Bind("IdLoaiSp") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:LoaiSpDataSource ID="IdLoaiSpLoaiSpDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Tu Dien:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdTuDien" Text='<%# Bind("IdTuDien") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataIdTuDien" runat="server" Display="Dynamic" ControlToValidate="dataIdTuDien" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ten Sp:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenSp" Text='<%# Bind("TenSp") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ma Sp:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMaSp" Text='<%# Bind("MaSp") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Gia:</td>
				<td>
					<asp:TextBox runat="server" ID="dataGia" Text='<%# Bind("Gia") %>'></asp:TextBox><asp:RegularExpressionValidator ID="RegExVal_dataGia"  runat="server" ControlToValidate="dataGia" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
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
				<td class="literal">Anh Minh Hoa:</td>
				<td>
					<asp:HiddenField runat="server" id="dataAnhMinhHoa" Value='<%# Bind("AnhMinhHoa") %>'></asp:HiddenField>
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


