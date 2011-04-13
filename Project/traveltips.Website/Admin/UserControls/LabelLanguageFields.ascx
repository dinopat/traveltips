<%@ Control Language="C#" ClassName="LabelLanguageFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td class="literal">Id Label Language:</td>
				<td>
					<asp:TextBox runat="server" ID="dataIdLabelLanguage" Text='<%# Bind("IdLabelLanguage") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataIdLabelLanguage" runat="server" Display="Dynamic" ControlToValidate="dataIdLabelLanguage" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataIdLabelLanguage" runat="server" Display="Dynamic" ControlToValidate="dataIdLabelLanguage" ErrorMessage="Invalid value" MaximumValue="9223372036854775807" MinimumValue="-9223372036854775808" Type="Double"></asp:RangeValidator>
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Language:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdLanguage" DataSourceID="IdLanguageLanguageDataSource" DataTextField="TenNn" DataValueField="IdLanguage" SelectedValue='<%# Bind("IdLanguage") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:LanguageDataSource ID="IdLanguageLanguageDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Id Label:</td>
				<td>
					<data:EntityDropDownList runat="server" ID="dataIdLabel" DataSourceID="IdLabelLabelNnDataSource" DataTextField="MaLabel" DataValueField="IdLabel" SelectedValue='<%# Bind("IdLabel") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:LabelNnDataSource ID="IdLabelLabelNnDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>				
			<tr>
				<td class="literal">Noi Dung:</td>
				<td>
					<asp:TextBox runat="server" ID="dataNoiDung" Text='<%# Bind("NoiDung") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
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


