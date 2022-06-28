<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRateCardRoomTypes.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.CtrlRateCardRoomTypes" %>
<script type="text/javascript" language="javascript">
    function fnSetRowIndex(rowIndex) {
        document.getElementById('<%= hfRowIndex.ClientID %>').value = rowIndex;
    }
</script>
<asp:UpdatePanel ID="upnlRoomTypes" runat="server">
    <ContentTemplate>
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left">
                    <h1>
                        <asp:Literal ID="litHeaderRoomTypes" runat="server"></asp:Literal></h1>
                </td>
                <td align="right" valign="bottom">
                    <asp:CheckBox ID="chkEnableDayRates" runat="server" Visible="false" AutoPostBack="true"
                        Checked="true" OnCheckedChanged="chkEnableDayRates_OnCheckedChanged" />
                </td>
            </tr>
        </table>
        <div>
            <hr />
        </div>
        <div class="box_content">
            <asp:Panel ID="pnlRoomTypes" runat="server" Width="1090px" Height="180px" ScrollBars="Horizontal">
            <asp:HiddenField ID="hfRowIndex" runat="server" />
            <asp:HiddenField ID="hfRowIndexOfExtraDays" runat="server" />
            <asp:GridView ID="gvRoomTypes" runat="server" AutoGenerateColumns="false" Width="100%"
                OnRowCommand="gvRoomTypes_OnRowCommand" ShowHeader="true" SkinID="gvNoPaging"
                DataKeyNames="RoomTypeID" OnRowDataBound="gvRoomTypes_RowDataBound">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                        <HeaderTemplate>
                            <asp:Literal ID="litGvHdrNumber" runat="server"></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <HeaderTemplate>
                            <asp:Literal ID="litGvHdrSelect" runat="server"></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" OnCheckedChanged="chkSelect_OnCheckedChanged"
                                AutoPostBack="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="210px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                        <HeaderTemplate>
                            <asp:Literal ID="litGvHdrRoomType" runat="server"></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblRoomType" runat="server" Width="200px" Text='<%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <HeaderTemplate>
                            <asp:Literal ID="litGvHdrViewComplimentoryServiceInfo" runat="server" Text="Comp. Services"></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" Text="View" Enabled="false" ToolTip="View Complimentory Services"
                                ForeColor="#0067a4" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RoomTypeID")%>'
                                CommandName="VIEWCOMPLMNTRYSERVICE"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="85px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                        <HeaderTemplate>
                            <asp:Literal ID="litGvHdrDeposit" runat="server" Text="Deposit"></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtDeposit" runat="server" SkinID="nowidth" MaxLength="13" OnTextChanged="txtDeposit_textChanged" AutoPostBack="true" Enabled="false"
                                Style="text-align: right; border: 1px solid #CCCCCC;" Width="70px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDeposit" Display="Dynamic" runat="server" SetFocusOnError="true"
                                Enabled="false" Text="*" ForeColor="Red" ValidationGroup="IsRequire" ControlToValidate="txtDeposit"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="regDeposit" runat="server"
                                Text="*" ForeColor="Red" ControlToValidate="txtDeposit" SetFocusOnError="true"
                                ValidationGroup="IsRequire">
                            </asp:RegularExpressionValidator>
                            <ajx:FilteredTextBoxExtender ID="ftbDeposit" runat="server" TargetControlID="txtDeposit"
                                FilterMode="ValidChars" ValidChars="0123456789.">
                            </ajx:FilteredTextBoxExtender>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="85px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                        <HeaderTemplate>
                            <asp:Literal ID="litGvHdrTotalRackRate" runat="server"></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtTotalRackRate" OnTextChanged="txtTotalRackRate_textChanged" AutoPostBack="true"
                                runat="server" SkinID="nowidth" Style="text-align: right; border: 1px solid #CCCCCC;"
                                MaxLength="13" Enabled="false" Width="70px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTotalRackRate" Display="Dynamic" runat="server"
                                SetFocusOnError="true" Enabled="false" Text="*" ForeColor="Red" ValidationGroup="IsRequire"
                                ControlToValidate="txtTotalRackRate"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="regTotalRackRate" runat="server"
                                Text="*" ForeColor="Red" ControlToValidate="txtTotalRackRate" SetFocusOnError="true"
                                ValidationGroup="IsRequire">
                            </asp:RegularExpressionValidator>
                            <ajx:FilteredTextBoxExtender ID="ftbTotalRackRate" runat="server" TargetControlID="txtTotalRackRate"
                                FilterMode="ValidChars" ValidChars="0123456789.">
                            </ajx:FilteredTextBoxExtender>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="85px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                        <HeaderTemplate>
                            <asp:Literal ID="litGvHdrRackRate" runat="server"></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtRackRate" runat="server" SkinID="nowidth" Style="text-align: right;
                                border: 1px solid #CCCCCC;" MaxLength="13" Enabled="false" Width="70px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRackRate" Display="Dynamic" runat="server" SetFocusOnError="true"
                                Enabled="false" Text="*" ForeColor="Red" ValidationGroup="IsRequire" ControlToValidate="txtRackRate"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="regRackRate" runat="server"
                                Text="*" ForeColor="Red" ControlToValidate="txtRackRate" SetFocusOnError="true"
                                ValidationGroup="IsRequire">
                            </asp:RegularExpressionValidator>
                            <ajx:FilteredTextBoxExtender ID="ftbRackRate" runat="server" TargetControlID="txtRackRate"
                                FilterMode="ValidChars" ValidChars="0123456789.">
                            </ajx:FilteredTextBoxExtender>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                        <HeaderTemplate>
                            <asp:Literal ID="litGvHdrTaxes" runat="server" Text="Taxes"></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtTaxes" runat="server" SkinID="nowidth" MaxLength="13" Enabled="false"
                                Style="text-align: right; border: 1px solid #CCCCCC;" Width="70px"></asp:TextBox>
                            <%-- <asp:ImageButton ID="imgbtnRefreshTax" runat="server" Enabled="false" ImageUrl="~/images/clearsearch.png"
                                Style="border: 0px; vertical-align: middle; margin: 0px 0 0 5px;" />--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                        <HeaderTemplate>
                            <asp:Literal ID="litGvHdrTotal" runat="server" Text="Total"></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTotal" runat="server" Enabled="false" Style="text-align: right;"
                                Width="70px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                        <HeaderTemplate>
                            <asp:Literal ID="litGvHdrExtraBedCharge" runat="server" Text="POS Charge/Day"></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtExtraBedCharge" runat="server" SkinID="nowidth" MaxLength="13"
                                Enabled="false" Style="text-align: right; border: 1px solid #CCCCCC;" Width="70px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvExtraBedCharge" Display="Dynamic" runat="server"
                                SetFocusOnError="true" Text="*" ForeColor="Red" ValidationGroup="IsRequire" ControlToValidate="txtExtraBedCharge"
                                Enabled="false"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="regExtraBedCharge" runat="server"
                                Text="*" ForeColor="Red" ControlToValidate="txtExtraBedCharge" SetFocusOnError="true"
                                ValidationGroup="IsRequire">
                            </asp:RegularExpressionValidator>
                            <ajx:FilteredTextBoxExtender ID="ftbExtraBedCharge" runat="server" TargetControlID="txtExtraBedCharge"
                                FilterMode="ValidChars" ValidChars="0123456789.">
                            </ajx:FilteredTextBoxExtender>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:TemplateField ItemStyle-Width="65px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrExtraAdult" runat="server" ></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtExtraAdult" runat="server" SkinID="nowidth" MaxLength="13" Enabled="false" Width="60px"></asp:TextBox>
                                <asp:RegularExpressionValidator Display="Dynamic" ID="regExtraAdult" runat="server"
                                    Text="*" ForeColor="Red" ControlToValidate="txtExtraAdult" SetFocusOnError="true"
                                    ValidationGroup="IsRequire">
                                </asp:RegularExpressionValidator>
                                <ajx:FilteredTextBoxExtender ID="ftbExtraAdult" runat="server" TargetControlID="txtExtraAdult" FilterMode="ValidChars"
                                    ValidChars="0123456789." ></ajx:FilteredTextBoxExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="65px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrExtChild" runat="server"></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtExtraChild" runat="server" SkinID="nowidth" MaxLength="13" Enabled="false" Width="60px"></asp:TextBox>
                                <asp:RegularExpressionValidator Display="Dynamic" ID="regExtraChild" runat="server"
                                    Text="*" ForeColor="Red" ControlToValidate="txtExtraChild" SetFocusOnError="true"
                                    ValidationGroup="IsRequire">
                                </asp:RegularExpressionValidator>
                                <ajx:FilteredTextBoxExtender ID="ftbExtraChild" runat="server" TargetControlID="txtExtraChild" FilterMode="ValidChars"
                                    ValidChars="0123456789." ></ajx:FilteredTextBoxExtender>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    <asp:TemplateField ItemStyle-Width="65px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                        <HeaderTemplate>
                            <asp:Literal ID="litGvHdrMonday" runat="server"></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtMonday" runat="server" SkinID="nowidth" MaxLength="13" Enabled="false"
                                Style="text-align: right; border: 1px solid #CCCCCC;" Width="60px"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="regMonday" runat="server" Text="*"
                                ForeColor="Red" ControlToValidate="txtMonday" SetFocusOnError="true" ValidationGroup="IsRequire">
                            </asp:RegularExpressionValidator>
                            <ajx:FilteredTextBoxExtender ID="ftbMonday" runat="server" TargetControlID="txtMonday"
                                FilterMode="ValidChars" ValidChars="0123456789.">
                            </ajx:FilteredTextBoxExtender>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="65px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                        <HeaderTemplate>
                            <asp:Literal ID="litGvHdrTuesday" runat="server"></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtTuesday" runat="server" SkinID="nowidth" MaxLength="13" Enabled="false"
                                Style="text-align: right; border: 1px solid #CCCCCC;" Width="60px"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="regTuesday" runat="server"
                                Text="*" ForeColor="Red" ControlToValidate="txtTuesday" SetFocusOnError="true"
                                ValidationGroup="IsRequire">
                            </asp:RegularExpressionValidator>
                            <ajx:FilteredTextBoxExtender ID="ftbTuesday" runat="server" TargetControlID="txtTuesday"
                                FilterMode="ValidChars" ValidChars="0123456789.">
                            </ajx:FilteredTextBoxExtender>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="65px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                        <HeaderTemplate>
                            <asp:Literal ID="litGvHdrWednesday" runat="server"></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtWednesday" runat="server" SkinID="nowidth" MaxLength="13" Enabled="false"
                                Style="text-align: right; border: 1px solid #CCCCCC;" Width="60px"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="regWednesday" runat="server"
                                Text="*" ForeColor="Red" ControlToValidate="txtWednesday" SetFocusOnError="true"
                                ValidationGroup="IsRequire">
                            </asp:RegularExpressionValidator>
                            <ajx:FilteredTextBoxExtender ID="ftbWednesday" runat="server" TargetControlID="txtWednesday"
                                FilterMode="ValidChars" ValidChars="0123456789.">
                            </ajx:FilteredTextBoxExtender>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="65px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                        <HeaderTemplate>
                            <asp:Literal ID="litGvHdrThursday" runat="server"></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtThursday" runat="server" SkinID="nowidth" MaxLength="13" Enabled="false"
                                Style="text-align: right; border: 1px solid #CCCCCC;" Width="60px"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="regThursday" runat="server"
                                Text="*" ForeColor="Red" ControlToValidate="txtThursday" SetFocusOnError="true"
                                ValidationGroup="IsRequire">
                            </asp:RegularExpressionValidator>
                            <ajx:FilteredTextBoxExtender ID="ftbThursday" runat="server" TargetControlID="txtThursday"
                                FilterMode="ValidChars" ValidChars="0123456789.">
                            </ajx:FilteredTextBoxExtender>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="65px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                        <HeaderTemplate>
                            <asp:Literal ID="litGvHdrFriday" runat="server"></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtFriday" runat="server" SkinID="nowidth" MaxLength="13" Enabled="false"
                                Style="text-align: right; border: 1px solid #CCCCCC;" Width="60px"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="regFriday" runat="server" Text="*"
                                ForeColor="Red" ControlToValidate="txtFriday" SetFocusOnError="true" ValidationGroup="IsRequire">
                            </asp:RegularExpressionValidator>
                            <ajx:FilteredTextBoxExtender ID="ftbFriday" runat="server" TargetControlID="txtFriday"
                                FilterMode="ValidChars" ValidChars="0123456789.">
                            </ajx:FilteredTextBoxExtender>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="65px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                        <HeaderTemplate>
                            <asp:Literal ID="litGvHdrSaturday" runat="server"></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtSaturday" runat="server" SkinID="nowidth" MaxLength="13" Enabled="false"
                                Style="text-align: right; border: 1px solid #CCCCCC;" Width="60px"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="regSaturday" runat="server"
                                Text="*" ForeColor="Red" ControlToValidate="txtSaturday" SetFocusOnError="true"
                                ValidationGroup="IsRequire">
                            </asp:RegularExpressionValidator>
                            <ajx:FilteredTextBoxExtender ID="ftbSaturday" runat="server" TargetControlID="txtSaturday"
                                FilterMode="ValidChars" ValidChars="0123456789.">
                            </ajx:FilteredTextBoxExtender>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="65px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                        <HeaderTemplate>
                            <asp:Literal ID="litGvHdrSunday" runat="server"></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtSunday" runat="server" SkinID="nowidth" MaxLength="13" Enabled="false"
                                Style="text-align: right; border: 1px solid #CCCCCC;" Width="60px"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="regSunday" runat="server" Text="*"
                                ForeColor="Red" ControlToValidate="txtSunday" SetFocusOnError="true" ValidationGroup="IsRequire">
                            </asp:RegularExpressionValidator>
                            <ajx:FilteredTextBoxExtender ID="ftbSunday" runat="server" TargetControlID="txtSunday"
                                FilterMode="ValidChars" ValidChars="0123456789.">
                            </ajx:FilteredTextBoxExtender>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div style="padding: 10px;">
                        <b>
                            <asp:Literal ID="litNoRecordFound" runat="server"></asp:Literal>
                        </b>
                    </div>
                </EmptyDataTemplate>
            </asp:GridView>
            </asp:Panel>
        </div>
        <ajx:ModalPopupExtender ID="mpeAddEditService" runat="server" TargetControlID="hdnAddEditService"
            PopupControlID="pnlAddEditService" BackgroundCssClass="mod_background" CancelControlID="btnCloseComplimentoryServices">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnAddEditService" runat="server" />
        <asp:Panel ID="pnlAddEditService" runat="server" Height="500px" Width="700px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderAddEditService" runat="server" Text="Complimentory Services"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%" border="0">
                        <tr>
                            <td>
                                <div style="height: 300px; overflow: auto;">
                                    <div class="clear">
                                    </div>
                                    <div class="box_content">
                                        <asp:GridView ID="gvRoomTypeComplimentoryServices" runat="server" AutoGenerateColumns="false"
                                            Width="100%" ShowHeader="true" SkinID="gvNoPaging" DataKeyNames="ItemID" OnRowDataBound="gvRoomTypeComplimentoryServices_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Literal ID="litGvHdrNumber" runat="server" Text="No."></asp:Literal>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Literal ID="litGvHdrSelect" runat="server" Text="Select"></asp:Literal>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelectComplimentoryServices" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="175px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Literal ID="litGvHdrPostingFeq" runat="server" Text="Posting Frequency"></asp:Literal>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlPostingFrequency" runat="server" Style="width: 125px;" SkinID="searchddl">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvPostingFrequency" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                            Display="Dynamic" ControlToValidate="ddlPostingFrequency" ValidationGroup="IsRequireComplimentoryServices"
                                                            runat="server" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Literal ID="litGvHdrServiceName" runat="server" Text="Service"></asp:Literal>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblService" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ItemName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="padding: 10px;">
                                                    <b>
                                                        <asp:Literal ID="litNoRecordFound" runat="server" Text="No record found."></asp:Literal>
                                                    </b>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnCancelComplimentoryServices" ValidationGroup="IsRequireComplimentoryServices"
                                    runat="server" Height="25px" Text="Save" OnClick="btnCancelComplimentoryServices_Click" Style="display: inline; padding-left: 5px;" />
                                    <asp:Button ID="btnCloseComplimentoryServices"  Height="25px" runat="server" Text="Cancel" Style="display: inline;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="upnlRoomTypes" ID="upgrsRoomTypes" runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
