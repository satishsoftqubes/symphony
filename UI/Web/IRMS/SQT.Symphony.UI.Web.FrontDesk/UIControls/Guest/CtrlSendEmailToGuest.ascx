<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSendEmailToGuest.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest.CtrlSendEmailToGuest" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="../../Scripts/Common.js" type="text/javascript"></script>
<script src="../../Scripts/jquery-1.8.2.js"></script>
<script src="../../Scripts/jquery-ui.js"></script>
<script type="text/javascript" language="javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function stopKey(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 8) && (node.type == "text")) { return false; }
        else if ((evt.keyCode == 9) && (node.type == "text")) { return true; }
        else if ((evt.keyCode == 46) && (node.type == "text")) { return false; }
        else { return false; }
    }
</script>
<style>
    .Checkbocselectionguest
    {
        float: left;
        margin-right: 15px;
        width: 110px;
    }
</style>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="content">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="boxtopleft">
                        &nbsp;
                    </td>
                    <td class="boxtopcenter">
                        <asp:Literal ID="litSendEmailTo" runat="server" Text="Send Email To"></asp:Literal>
                    </td>
                    <td class="boxtopright">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="boxleft">
                        &nbsp;
                    </td>
                    <td align="left">
                        <div class="box_form">
                            <%if (IsMessage)
                              { %>
                            <div class="ResetSuccessfully">
                                <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                    <img src="../../images/success.png" />
                                </div>
                                <div>
                                    <asp:Label ID="lblInquiryListMsg" runat="server"></asp:Label></div>
                                <div style="height: 10px;">
                                </div>
                            </div>
                            <% }%>
                        </div>
                        <asp:MultiView ID="mvSendEmailCategory" runat="server">
                            <asp:View ID="vEmailToOthercategory" runat="server">
                                <div style="text-align: right; margin-right: 17px;">
                                    <asp:LinkButton ID="lnkSendEmailTomarketing" runat="server" Text="Send Email To Marketing"
                                        OnClick="lnkSendEmailTomarketing_Click"></asp:LinkButton></div>
                                <table cellpadding="2" cellspacing="2" width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <div>
                                                <asp:CheckBox ID="chkAllGuest" AutoPostBack="true" OnCheckedChanged="chkAllGuest_CheckChanged"
                                                    Text="All" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="Checkbocselectionguest">
                                                <asp:CheckBox ID="chkInvestorOnly" Text="Investor" runat="server" />
                                            </div>
                                            <div class="Checkbocselectionguest">
                                                <asp:CheckBox ID="chkCheckInGuest" Text="In house Guest" runat="server" />
                                            </div>
                                            <div>
                                                <asp:CheckBox ID="chkCheckOutGuest" Text="Check out Guest" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="padding-bottom: 10px;">
                                            <div class="Checkbocselectionguest">
                                                <asp:CheckBox ID="chkWaitListGuest" Text="Wait List" runat="server" />
                                            </div>
                                            <div class="Checkbocselectionguest">
                                                <asp:CheckBox ID="chkInquiryOnly" Text="Inquiry List" runat="server" />
                                            </div>
                                            <div class="Checkbocselectionguest">
                                                <asp:CheckBox ID="chkEmailDbList" Text="Email List" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 80px; padding-bottom: 10px;">
                                            <b>
                                                <asp:Literal ID="litEmailSubject" runat="server" Text="Email Subject"></asp:Literal></b>
                                        </td>
                                        <td style="padding-bottom: 10px;">
                                            <asp:TextBox ID="txtEmailSubject" runat="server"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvEmailSubject" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                    runat="server" ControlToValidate="txtEmailSubject" Display="Dynamic" ValidationGroup="EmailSendToGuest">
                                                </asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div>
                                                <CKEditor:CKEditorControl ID="ckEmailSendToGuest" runat="server" Height="450px">
                                                </CKEditor:CKEditorControl></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Button ID="btnSendEmailToGuest" Text="Send Email" runat="server" Style="display: inline;
                                                padding-right: 10px;" OnClick="btnSendEmailToGuest_Click" ValidationGroup="EmailSendToGuest" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="vEmailToMarketing" runat="server">
                                <div style="text-align: right; display: block; margin-left: 89%;">
                                    <asp:Button ID="btnBackToListEmail" runat="server" Text="Back To List" OnClick="btnBackToListEmail_Click">
                                    </asp:Button></div>
                                <table cellpadding="2" cellspacing="2" width="100%">
                                    <tr id="trMarketingValue" runat="server">
                                        <td style="vertical-align: top; width: 113px !important;">
                                            <asp:Literal ID="litMarketingValueStatus" runat="server" Text="Marketing Category"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMarketingValueStatus" runat="server">
                                            </asp:DropDownList>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rvfMarketingValueStatus" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                    ValidationGroup="EmailSendToMarketing" ControlToValidate="ddlMarketingValueStatus"
                                                    Display="Dynamic">
                                                </asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 80px; padding-bottom: 10px;">
                                            <b>
                                                <asp:Literal ID="Literal2" runat="server" Text="Email Subject"></asp:Literal></b>
                                        </td>
                                        <td style="padding-bottom: 10px;">
                                            <asp:TextBox ID="txtEmailSubjectForMarketing" runat="server"></asp:TextBox>
                                            <span>
                                                <asp:RequiredFieldValidator ID="rfvEmailSubjectForMarketing" SetFocusOnError="true"
                                                    CssClass="input-notification error png_bg" runat="server" ControlToValidate="txtEmailSubjectForMarketing"
                                                    Display="Dynamic" ValidationGroup="EmailSendToMarketing">
                                                </asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div>
                                                <CKEditor:CKEditorControl ID="CKEMarketingPeoplebody" runat="server" Height="450px">
                                                </CKEditor:CKEditorControl></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Button ID="btnSendEmailToMarketing" Text="Send Email" runat="server" Style="display: inline;
                                                padding-right: 10px;" OnClick="btnSendEmailToMarketing_Click" ValidationGroup="EmailSendToMarketing" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                    </td>
                    <td class="boxright">
                    </td>
                </tr>
                <tr>
                    <td class="boxbottomleft">
                    </td>
                    <td class="boxbottomcenter">
                    </td>
                    <td class="boxbottomright">
                    </td>
                </tr>
            </table>
            <div class="clear_divider">
            </div>
            <div class="clear">
            </div>
        </td>
    </tr>
</table>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<%--<asp:UpdatePanel ID="updSendEmailsToGuest" runat="server">
    <ContentTemplate>

    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="updSendEmailsToGuest" ID="upProgessSendEmailsToGuest"
    runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>--%>
