<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlUnitResell.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlUnitResell" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
</script>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="content" style="padding-left: 0px; width: 66.66%">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                <tr>
                    <td class="boxtopleft">
                        &nbsp;
                    </td>
                    <td class="boxtopcenter">
                        UNIT RESELL
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
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:MultiView ID="mvResellUnit" runat="server">
                                    <asp:View ID="vResellTypeSelection" runat="server">
                                        <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <b>Unit Resell</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:RadioButtonList ID="rdblResellTo" runat="server" RepeatColumns="2" Width="325"
                                                        RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rdblResellTo_OnSelectedIndexChanged">
                                                        <asp:ListItem Text="Back to Company" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="To Investor" Value="0"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div style="height: 350px;">
                                                        &nbsp;</div>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                    <asp:View ID="vResellToCompany" runat="server">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <table width="100%" cellpadding="3" cellspacing="3">
                                                        <tr>
                                                            <td colspan="2">
                                                                <div style="height: 26px;">
                                                                    <%if (IsMessage)
                                                                      { %>
                                                                    <div class="ResetSuccessfully" >
                                                                        <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                                            <img src="../../images/success.png" /></div>
                                                                        <div>
                                                                            <asp:Label ID="lblErrorMessage" runat="server"></asp:Label></div>
                                                                        <div style="height: 10px;">
                                                                        </div>
                                                                    </div>
                                                                    <%}%>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" style="width: 125px;">
                                                                <asp:Label ID="litInvestor" CssClass="RequireFile" runat="server" Text="Investor Name"></asp:Label>
                                                                <span class="erroraleart">
                                                                    <asp:RequiredFieldValidator ID="rvfddlInvestor" runat="server" ControlToValidate="ddlInvestor"
                                                                        SetFocusOnError="true" CssClass="rfv_ErrorStar" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                        ErrorMessage="*" ValidationGroup="InvestorUnit"></asp:RequiredFieldValidator>
                                                                </span>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:DropDownList ID="ddlInvestor" runat="server" Style="width: 202px;" OnSelectedIndexChanged="ddlInvestor_SelectedIndexChanged"
                                                                    AutoPostBack="true">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="litRoomName" CssClass="RequireFile" runat="server" Text="Unit No"></asp:Label>
                                                                <span class="erroraleart">
                                                                    <asp:RequiredFieldValidator ID="rvfddlUnitNo" runat="server" ControlToValidate="ddlUnitNo"
                                                                        SetFocusOnError="true" CssClass="rfv_ErrorStar" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                        ErrorMessage="*" ValidationGroup="InvestorUnit"></asp:RequiredFieldValidator>
                                                                </span>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:DropDownList ID="ddlUnitNo" runat="server" Style="width: 202px;">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblSellDate" runat="server" Text="Sell Date"></asp:Label>
                                                                <span class="erroraleart">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSellDate"
                                                                        SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="InvestorUnit"></asp:RequiredFieldValidator>
                                                                </span>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtSellDate" runat="server" Enabled="false" Style="width: 80px !important;"
                                                                    onkeydown="return stopKey(event);"></asp:TextBox>
                                                                <asp:Image ID="imgSellDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                    Height="20px" Width="20px" />
                                                                <ajx:CalendarExtender ID="calSellDate" PopupButtonID="imgSellDate" CssClass="MyCalendar"
                                                                    TargetControlID="txtSellDate" runat="server">
                                                                </ajx:CalendarExtender>
                                                                <img src="../../images/clear.png" id="img2" style="vertical-align: middle;" onclick="fnClearDate('<%= txtSellDate.ClientID %>');" />
                                                                <%--<asp:CustomValidator ID="cvFinalPaymentDate" runat="server" ErrorMessage="Invalid date."
                                                                    Display="Dynamic" ControlToValidate="txtRegistrationDate" OnServerValidate="vFinalPaymentDate_ServerValidate"
                                                                    ValidationGroup="InvestorUnit" ForeColor="Red"></asp:CustomValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" colspan="2" style="text-align: right;">
                                                                <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;"
                                                                    runat="server" ImageUrl="~/images/save.png" ValidationGroup="InvestorUnit" CausesValidation="true"
                                                                    OnClick="btnSave_Click" />
                                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Style="display: inline-block;
                                                                    margin-left: 5px;" OnClick="btnCancel_OnClick" />
                                                                <%--<asp:Button ID="btnNew" runat="server" Style="display: inline-block; margin-left: 5px;
                                                    display: inline;" Text="New" OnClick="btnNew_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/save.png" ValidationGroup="InvestorUnit" CausesValidation="true"
                                                    OnClick="btnSave_Click" OnClientClick="return postbackButtonClick();" />
                                                <asp:Button ID="Button1" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click" />--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                </asp:MultiView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
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
            <div id="errormessage" class="clear" style="display: none;">
                <uc1:MsgBox ID="MessageBox" runat="server" />
            </div>
        </td>
    </tr>
</table>
