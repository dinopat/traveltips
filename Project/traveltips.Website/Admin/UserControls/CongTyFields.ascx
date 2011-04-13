<%@ Control Language="C#" ClassName="CongTyFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Cong Ty:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdCongTy" Text='<%# Bind("IdCongTy") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdCongTy" runat="server" Display="Dynamic" ControlToValidate="dataIdCongTy" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdCongTy" runat="server" Display="Dynamic" ControlToValidate="dataIdCongTy" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Chu Cong Ty:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdChuCongTy" DataSourceID="IdChuCongTyChuCongTyDataSource" DataTextField="TenChuCongTy" DataValueField="IdChuCongTy" SelectedValue='<%# Bind("IdChuCongTy") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:ChuCongTyDataSource ID="IdChuCongTyChuCongTyDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Danh Muc:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdDanhMuc" DataSourceID="IdDanhMucDanhMucDataSource" DataTextField="IdDmCha" DataValueField="IdDanhMuc" SelectedValue='<%# Bind("IdDanhMuc") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:DanhMucDataSource ID="IdDanhMucDanhMucDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Quoc Gia:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdQuocGia" Text='<%# Bind("IdQuocGia") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataIdQuocGia" runat="server" Display="Dynamic" ControlToValidate="dataIdQuocGia" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Thanh Pho:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdThanhPho" Text='<%# Bind("IdThanhPho") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataIdThanhPho" runat="server" Display="Dynamic" ControlToValidate="dataIdThanhPho" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Quan:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdQuan" Text='<%# Bind("IdQuan") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataIdQuan" runat="server" Display="Dynamic" ControlToValidate="dataIdQuan" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Duong:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdDuong" Text='<%# Bind("IdDuong") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataIdDuong" runat="server" Display="Dynamic" ControlToValidate="dataIdDuong" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Khu Vuc:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdKhuVuc" Text='<%# Bind("IdKhuVuc") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataIdKhuVuc" runat="server" Display="Dynamic" ControlToValidate="dataIdKhuVuc" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">So Nha:</td>
				<td>
					<asp:TextBox runat="server" ID="dataSoNha" Text='<%# Bind("SoNha") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Dien Thoai Cd:</td>
				<td>
					<asp:TextBox runat="server" ID="dataDienThoaiCd" Text='<%# Bind("DienThoaiCd") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Dien Thoai Dd:</td>
				<td>
					<asp:TextBox runat="server" ID="dataDienThoaiDd" Text='<%# Bind("DienThoaiDd") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Fax:</td>
				<td>
					<asp:TextBox runat="server" ID="dataFax" Text='<%# Bind("Fax") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Email:</td>
				<td>
					<asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Website:</td>
				<td>
					<asp:TextBox runat="server" ID="dataWebsite" Text='<%# Bind("Website") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Hinh Thuc Tt:</td>
				<td>
					<asp:TextBox runat="server" ID="dataHinhThucTt" Text='<%# Bind("HinhThucTt") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Thoi Gian Pv:</td>
				<td>
					<asp:TextBox runat="server" ID="dataThoiGianPv" Text='<%# Bind("ThoiGianPv") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Anh Minh Hoa:</td>
				<td>
					<asp:TextBox runat="server" ID="dataAnhMinhHoa" Text='<%# Bind("AnhMinhHoa") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ghi Chu:</td>
				<td>
					<asp:TextBox runat="server" ID="dataGhiChu" Text='<%# Bind("GhiChu") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
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
				<td class="literal">Flag:</td>
				<td>
					<asp:TextBox runat="server" ID="dataFlag" Text='<%# Bind("Flag") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataFlag" runat="server" Display="Dynamic" ControlToValidate="dataFlag" ErrorMessage="Invalid value" MaximumValue="255" MinimumValue="0" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>				
			
		</table>

	</ItemTemplate>
</asp:FormView>


