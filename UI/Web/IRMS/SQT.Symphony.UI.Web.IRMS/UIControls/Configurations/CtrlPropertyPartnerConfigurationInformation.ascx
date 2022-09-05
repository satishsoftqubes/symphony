<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPropertyPartnerConfigurationInformation.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Configurations.CtrlPropertyPartnerConfigurationInformation" %>

<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>

<%--<script type="text/javascript">
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("Configuration")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgressProperty.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
        else {
            return false;
        }
    }
</script>--%>

<style type="text/css">
    #progressBackgroundFilter {
        position: fixed;
        top: 0px;
        width: 100%;
        height: 100%;
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

    #processMessage {
        position: fixed;
        top: 50%;
        left: 50%;
        padding: 10px;
        width: 30px;
        border-radius: 10px;
        z-index: 1111112;
        background-color: #fff;
        border: solid 1px #efefef;
    }
</style>

<asp:UpdatePanel ID="updPropertyPartner" runat="server">
    <ContentTemplate>

        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">&nbsp;
                            </td>
                            <td class="boxtopcenter">PROPERTY PARTNER
                            </td>
                            <td class="boxtopright">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">&nbsp;
                            </td>
                            <td>
                                <table cellpadding="3" cellspacing="3" border="0" width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <div style="height: 26px;">
                                                <%if (IsMessage)
                                                    { %>
                                                <div class="ResetSuccessfully">
                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                        <img src="../../images/success.png" />
                                                    </div>
                                                    <div>
                                                        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                                                    </div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <%}%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div style="float: right;">
                                                <b>All Bold Fields are Mandatory</b>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litPropertyName" runat="server" Text="Property Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvPropertyName" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    InitialValue="00000000-0000-0000-0000-000000000000" runat="server" ValidationGroup="Configuration"
                                                    ControlToValidate="ddlPropertyName" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPropertyName" runat="server" Style="width: 205px;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litPartnerName" runat="server" Text="Partner Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvPartnerName" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    InitialValue="00000000-0000-0000-0000-000000000000" runat="server" ValidationGroup="Configuration"
                                                    ControlToValidate="ddlPartnerName" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPartnerName" runat="server" Style="width: 205px;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litPartnershipInPercentage" runat="server" Text="Partnership Percentage" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvPartnershipInPercentage" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtPartnershipInPercentage"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <%--<asp:TextBox autocomplete="off" ID="txtPartnershipInPercentage" AutoPostBack="true" OnTextChanged="fnCalculateTotalCost" SkinID="CmpTextbox" runat="server" MaxLength="10"></asp:TextBox>--%>
                                            <asp:TextBox autocomplete="off" ID="txtPartnershipInPercentage" SkinID="CmpTextbox" runat="server" MaxLength="10"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litTotalToInvest" runat="server" Text="Total To Invest" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvTotalToInvest" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtTotalToInvest"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <%--<asp:TextBox autocomplete="off" ID="txtTotalToInvest" AutoPostBack="true" OnTextChanged="fnCalculateTotalCost" SkinID="CmpTextbox" runat="server" MaxLength="10"></asp:TextBox>--%>
                                            <asp:TextBox autocomplete="off" ID="txtTotalToInvest"  SkinID="CmpTextbox" runat="server" MaxLength="10"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litTotalDue" runat="server" Text="Total Due" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvTotalDue" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtTotalDue"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <%--<asp:TextBox autocomplete="off" ID="txtTotalToInvest" AutoPostBack="true" OnTextChanged="fnCalculateTotalCost" SkinID="CmpTextbox" runat="server" MaxLength="10"></asp:TextBox>--%>
                                            <asp:TextBox autocomplete="off" ID="txtTotalDue" SkinID="CmpTextbox" runat="server" MaxLength="10"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litTotalInvested" runat="server" Text="Total Invested" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvTotalInvested" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtTotalInvested"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <%--<asp:TextBox autocomplete="off" ID="txtTotalToInvest" AutoPostBack="true" OnTextChanged="fnCalculateTotalCost" SkinID="CmpTextbox" runat="server" MaxLength="10"></asp:TextBox>--%>
                                            <asp:TextBox autocomplete="off" ID="txtTotalInvested"  SkinID="CmpTextbox" runat="server" MaxLength="10"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litDescription" runat="server" Text="Description" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvDescription" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtDescription"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <%--<asp:TextBox autocomplete="off" ID="txtTotalToInvest" AutoPostBack="true" OnTextChanged="fnCalculateTotalCost" SkinID="CmpTextbox" runat="server" MaxLength="10"></asp:TextBox>--%>
                                            <asp:TextBox TextMode="MultiLine" rows="4" autocomplete="off" ID="txtDescription" SkinID="CmpTextbox" runat="server" MaxLength="3000"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="left" valign="top" colspan="2" style="text-align: right;">
                                            <div style="float: right; width: auto; display: inline-block;">
                                                <asp:Button ID="btnNew" runat="server" Style="display: inline-block; margin-left: 5px; display: inline;"
                                                    Text="New" OnClick="btnNew_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/save.png" ValidationGroup="Configuration" CausesValidation="true"
                                                    OnClick="btnSave_Click" OnClientClick="return postbackButtonClick();" />
                                                <asp:Button ID="btnCancel" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="boxright">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxbottomleft">&nbsp;
                            </td>
                            <td class="boxbottomcenter">&nbsp;
                            </td>
                            <td class="boxbottomright">&nbsp;
                            </td>
                        </tr>
                    </table>
                    <div class="clear_divider">
                    </div>
                </td>
                <td style="width: 2px;">&#160;
                </td>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">&nbsp;
                            </td>
                            <td class="boxtopcenter">QUICK SEARCH
                            </td>
                            <td class="boxtopright">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">&nbsp;
                            </td>
                            <td>
                                <div class="box_leftmargin_content">
                                    <div>
                                        <table id="tbl" cellpadding="2" cellspacing="0" width="100%" border="0" class="pageinfo">
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">Property Name
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSPropertyName" runat="server" Style="vertical-align: middle; margin-top: 7px; width: 125px !important;"
                                                        MaxLength="65"></asp:TextBox>
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; vertical-align: middle; margin-left: 5px;" OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <div style="height: 775px; overflow: auto;">
                                            <asp:GridView ID="grdPropertyPartnerList" runat="server" ShowHeader="false" ShowFooter="false"
                                                SkinID="gvNoPaging" AutoGenerateColumns="false" Width="92%" OnRowCommand="grdPropertyPartnerList_RowCommand"
                                                OnRowDataBound="grdPropertyPartnerList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea">
                                                                    <strong>
                                                                        <%#DataBinder.Eval(Container.DataItem, "PropertyName")%></strong><br />
                                                                </div>
                                                                <div class="leftmargin_icons">
                                                                    <asp:ImageButton ID="btnEdit" ToolTip="Edit" runat="server" ImageUrl="~/images/edit.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
                                                                        CommandName="EditData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PropertyID")%>' OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                    <asp:ImageButton ID="btnDelete" ToolTip="Delete" runat="server" ImageUrl="~/images/delete_icon.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
                                                                        CommandName="DeleteData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PropertyPartnerID")%>' OnClientClick="fnDisplayCatchErrorMessage()" />
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
                                                    <div class="pagecontent_info">
                                                        <div class="NoItemsFound">
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
                            <td class="boxright">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxbottomleft">&nbsp;
                            </td>
                            <td class="boxbottomcenter">&nbsp;
                            </td>
                            <td class="boxbottomright">&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="Panel1"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="Panel1" runat="server" Style="display: none;">
            <div style="width: 500px; height: 200px; margin-top: 25px;">
                <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
                    <tr>
                        <td class="modelpopup_boxtopleft">&nbsp;
                        </td>
                        <td class="modelpopup_boxtopcenter">&nbsp;
                        </td>
                        <td class="modelpopup_boxtopright">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="modelpopup_boxleft">&nbsp;
                        </td>
                        <td class="modelpopup_box_bg">
                            <div style="width: 100px; float: left; margin-top: 10px;">
                                <asp:HyperLink ID="HyperLink1" runat="server">
                                    <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                        ID="Image1" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div style="float: left; width: 225px; margin-top: 40px; margin-left: 10px;">
                                <asp:Label ID="Label1" runat="server" Text="Sure you want to delete?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <asp:Button ID="btnPropertyPartnerYes" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnPropertyPartnerYes_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnPropertyPartnerNo" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            OnClick="btnPropertyPartnerNo_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="modelpopup_boxright">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="modelpopup_boxbottomleft">&nbsp;
                        </td>
                        <td class="modelpopup_boxbottomcenter"></td>
                        <td class="modelpopup_boxbottomright">&nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updPropertyPartner" ID="UpdateProgressPropertyPartner"
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

