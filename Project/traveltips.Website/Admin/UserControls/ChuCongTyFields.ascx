<%@ Control Language="C#" ClassName="ChuCongTyFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Chu Cong Ty:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdChuCongTy" Text='<%# Bind("IdChuCongTy") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdChuCongTy" runat="server" Display="Dynamic" ControlToValidate="dataIdChuCongTy" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdChuCongTy" runat="server" Display="Dynamic" ControlToValidate="dataIdChuCongTy" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ten Chu Cong Ty:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenChuCongTy" Text='<%# Bind("TenChuCongTy") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ten Cong Ty:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenCongTy" Text='<%# Bind("TenCongTy") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Ten Dang Nhap:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenDangNhap" Text='<%# Bind("TenDangNhap") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Password:</td>
				<td>
					<asp:TextBox runat="server" ID="dataPassword" Text='<%# Bind("Password") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Dia Chi:</td>
				<td>
					<asp:TextBox runat="server" ID="dataDiaChi" Text='<%# Bind("DiaChi") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
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
				<td class="literal">Ngay Tao:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNgayTao" Text='<%# Bind("NgayTao", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgayTao" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>				
			<tr>
				<td class="literal">Ngay Ket Thuc:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNgayKetThuc" Text='<%# Bind("NgayKetThuc", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgayKetThuc" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
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


