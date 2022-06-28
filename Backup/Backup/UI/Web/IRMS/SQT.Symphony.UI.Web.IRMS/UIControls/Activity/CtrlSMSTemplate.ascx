<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSMSTemplate.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Activity.CtrlSMSTemplate" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>

<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>

<style type="text/css">
    #progressBackgroundFilter
    {
        position: fixed;
        top: 0px;
        width:100%;
        height:100%;
        bottom: 0px;
        left: 0px;
        right: 0px;
        overflow: hidden;
        padding: 0;
        margin: 0;
        background-color: #000;
        filter: alpha(opacity=50);
        opacity: 0.5;
        z-index: 1111111;
    }
    #processMessage
    {
        position: fixed;
        top: 50%;
        left: 50%;
        padding: 10px;
        width: 30px;
        border-radius:10px;
        z-index: 1111112;
        background-color:#fff;
        border: solid 1px #efefef;
    }
</style>
<asp:UpdatePanel ID="updSMSTemplate" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                SMS
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
                                <div style="height: 424px;">
                                    <table width="100%" cellpadding="3" cellspacing="3">
                                        <tr>
                                            <td colspan="2">
                                                <div style="height: 26px;">
                                                    <%if (IsInsert)
                                                      { %>
                                                    <div class="ResetSuccessfully">
                                                        <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                            <img src="../../images/success.png" />
                                                        </div>
                                                        <div>
                                                            <asp:Label ID="lblNewsMsg" runat="server"></asp:Label></div>
                                                        <div style="height: 10px;">
                                                        </div>
                                                    </div>
                                                    <% }%>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td colspan="4">
                                            <div style="float:right;">
                                                <b>All Bold Fields are Mandatory</b>
                                            </div>
                                        </td>
                                    </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="litTitle" runat="server" Text="Title" CssClass="RequireFile"></asp:Label>
                                                <span class="erroraleart">
                                                    <asp:RequiredFieldValidator ID="rvfTitle" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                        runat="server" ControlToValidate="txtTitle" ErrorMessage="*" ValidationGroup="NewLatter"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTitle" runat="server" SkinID="Long" MaxLength="20"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litDetail" runat="server" Text="Details"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDetails" runat="server" TextMode="MultiLine" SkinID="Long" Height="60px"
                                                    MaxLength="160"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td class="readiobuttonarea">
                                                <asp:RadioButton ID="rdoIsOnUnitBooking" Text="Unit Booking" GroupName="SMSGroup"
                                                    runat="server" /><br />
                                                <asp:RadioButton ID="rdoIsOnInvestorCreation" Text="Investor Creation" GroupName="SMSGroup"
                                                    runat="server" /><br />
                                                <asp:RadioButton ID="rdoIsOnUnitPaymentReceived" Text="Unit Payment Receive" GroupName="SMSGroup"
                                                    runat="server" /><br />
                                                <asp:RadioButton ID="rdoIsOnUnitTaxReceived" Text="Unit Tax Receive" GroupName="SMSGroup"
                                                    runat="server" /><br />
                                                <asp:RadioButton ID="rdoIsOnUnitInsuranceReceived" Text="Unit Insurance Receive"
                                                    GroupName="SMSGroup" runat="server" /><br />
                                                <asp:RadioButton ID="rdoIsOther" Text="Other"
                                                    GroupName="SMSGroup" runat="server" /><br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align:right;">
                                                <div style="vertical-align: middle; margin-top: 5px; width:100%;">
                                                    <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;" runat="server"
                                                        ImageUrl="~/images/save.png" ValidationGroup="NewLatter" CausesValidation="true"
                                                        OnClick="btnSave_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                    <asp:Button ID="btnCancel" Text="Cancel" Style="display: inline-block;margin-left: 5px;"
                                                        runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
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
                    <%--<div class="clear">
                        <uc1:MsgBox ID="MessageBox" runat="server" />
                    </div>--%>
                </td>
                <td style="width: 2px;">
                    &#160;
                </td>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                QUICK SEARCH
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
                                <div class="box_leftmargin_content">
                                    <div>
                                        <table id="tbl" cellpadding="2" cellspacing="0" border="0" class="pageinfo">
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Title
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSTitle" runat="server" SkinID="Search"></asp:TextBox>
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; vertical-align: middle; margin-top: -4px; margin-left: 5px;"
                                                        OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <div style="height: 391px;">
                                            <asp:GridView ID="grdSMSList" runat="server" ShowHeader="false" ShowFooter="false"
                                                SkinID="gvNoPaging" AutoGenerateColumns="false" Width="92%" OnRowCommand="grdSMSList_RowCommand"
                                                OnRowDataBound="grdSMSList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea">
                                                                    <strong>
                                                                        <%#DataBinder.Eval(Container.DataItem, "Title")%></strong><br />
                                                                </div>
                                                                <div class="leftmargin_icons">
                                                                    <asp:ImageButton ID="btnEdit" ToolTip="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "SMSTemplateID")%>'
                                                                        CommandName="EDITDATA" runat="server" ImageUrl="~/images/edit.png" Style="border: 0px;
                                                                        vertical-align: middle; margin-top: 7px; margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                </div>
                                                                <div class="clear">
                                                                </div>
                                                            </div>
                                                            <div class="clear">
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <div class="pagecontent_info" id="MsgRecFnd" runat="server">
                                                        <div class="NoItemsFound" id="msgNoRecordFound" runat="server">
                                                            <h2>
                                                                <asp:Literal ID="Literal5" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                        </div>
                                                    </div>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                    </div>
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
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updSMSTemplate" ID="UpdateProgressSMSTemplate"
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
