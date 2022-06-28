<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RateCardPOSCharge.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.RateCardPOSCharge" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script src="../../Javascript/Common.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">

    function fnConfirmDelete(id) {
        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnConfirmDelete.ClientID %>').value = id;
        $find('mpeConfirmDelete').show();
        return false;
    }

    function fnCheckTabKey(e) {
        if (e.charCode == 9) {
            return true
        }
        else {
            return false;
        }
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updRateCardList" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hfDateFormat" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="ltrMainHeader" runat="server" Text="POS Charges Setup"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td>
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td>
                                                <%if (IsMessage)
                                                  { %>
                                                <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Label ID="lblMessage" runat="server"></asp:Label></strong>
                                                    </p>
                                                </div>
                                                <%}%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>  
                                                <table>
                                                        <tr>
                                                            <td width="100px" style="padding-bottom:10px;">
                                                                <b>Rate Card Name</b>
                                                            </td>
                                                            <td style="padding-bottom:10px;">
                                                                <asp:Label ID="lblRateCardName" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                <div class="box_content">                                                    
                                                    <asp:GridView ID="gvRateCardInfo" runat="server" AutoGenerateColumns="False" CssClass="grid_content">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="litGvHdrNumber" runat="server" Text="Sr. No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="220px">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrRoomTypeName" runat="server" Text="Room Type"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRoomTypeName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="220px">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrPOSChargePerDay" runat="server" Text="POS Charge / Day"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hfRoomTypeID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "RoomTypeID")%>' />
                                                                    <asp:TextBox ID="txtPOSChargeAmount" runat="server" SkinID="nowidth" Width="130px"
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "POSCharge")%>'></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="ftbPOSChargeAmount" runat="server" TargetControlID="txtPOSChargeAmount"
                                                                        FilterMode="ValidChars" ValidChars=".0123456789">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rfvPOSChargeAmount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                            runat="server" ValidationGroup="RequireForPOS" ControlToValidate="txtPOSChargeAmount"
                                                                            Display="Dynamic">
                                                                        </asp:RequiredFieldValidator>
                                                                    </span>
                                                                    <asp:RegularExpressionValidator ID="regPOSChargeAmount" SetFocusOnError="True" runat="server"
                                                                        ValidationGroup="RequireForPOS" ControlToValidate="txtPOSChargeAmount" ValidationExpression="^\d{0,18}(\.\d{0,2})?$"
                                                                        Display="Dynamic" ForeColor="Red" ErrorMessage="Two digits allowd after decimal point."></asp:RegularExpressionValidator>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div style="padding: 10px;">
                                                                <b>
                                                                    <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label></h2> </b>
                                                            </div>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div style="float: right; display: inline; padding-right: 20px;">
                                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_OnClick" Text="Save" ValidationGroup="RequireForPOS" Style="float: right;" />
                                                </div>
                                                <div style="float: right; display: inline; padding-right: 20px;">
                                                    <asp:Button ID="btnBackToList" runat="server" Style="float: right;" Text="Back to List" OnClick="btnBackToList_OnClick" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td class="boxright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxbottomleft">
                                &nbsp;
                            </td>
                            <td class="boxbottomcenter">
                                &nbsp;
                            </td>
                            <td class="boxbottomright">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <div class="clear_divider">
                    </div>
                    <div class="clear">
                        <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                    </div>
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnCancelDelete"
            BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="350px" Width="325px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHeaderConfirmDeletePopup" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="litConfirmDeleteMsg" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYes" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClientClick="fnDisplayCatchErrorMessage();" OnClick="btnYes_Click" />
                                <asp:Button ID="btnCancelDelete" runat="server" Style="display: inline;" />
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
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updRateCardList" ID="UpdateProgressPropertyList"
    runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
