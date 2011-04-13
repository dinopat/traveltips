<%@ Control Language="C#" ClassName="GalleryFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Gallery:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdGallery" Text='<%# Bind("IdGallery") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdGallery" runat="server" Display="Dynamic" ControlToValidate="dataIdGallery" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdGallery" runat="server" Display="Dynamic" ControlToValidate="dataIdGallery" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
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
				<td class="literal">Ten Anh:</td>
				<td>
					<asp:TextBox runat="server" ID="dataTenAnh" Text='<%# Bind("TenAnh") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Duong Dan:</td>
				<td>
					<asp:TextBox runat="server" ID="dataDuongDan" Text='<%# Bind("DuongDan") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>				
			<tr>
				<td class="literal">Mo Ta:</td>
				<td>
					<asp:TextBox runat="server" ID="dataMoTa" Text='<%# Bind("MoTa") %>' MaxLength="50"></asp:TextBox>
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


