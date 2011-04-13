<%@ Control Language="C#" ClassName="CommentFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Comment:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdComment" Text='<%# Bind("IdComment") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdComment" runat="server" Display="Dynamic" ControlToValidate="dataIdComment" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdComment" runat="server" Display="Dynamic" ControlToValidate="dataIdComment" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id User:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdUser" DataSourceID="IdUserUserDataSource" DataTextField="TenDangNhap" DataValueField="IdUser" SelectedValue='<%# Bind("IdUser") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:UserDataSource ID="IdUserUserDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Congty:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdCongty" DataSourceID="IdCongtyCongTyDataSource" DataTextField="IdQuocGia" DataValueField="IdCongTy" SelectedValue='<%# Bind("IdCongty") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:CongTyDataSource ID="IdCongtyCongTyDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Tieu De:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTieuDe" Text='<%# Bind("TieuDe") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Noi Dung:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNoiDung" Text='<%# Bind("NoiDung") %>' MaxLength="50"></asp:TextBox>
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


