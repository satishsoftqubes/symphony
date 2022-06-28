<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPaymentSlabe.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.IRMSCofiguration.CtrlPaymentSlabe" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function pageLoad(sender, args) {
        $(document).ready(function () {
            $("#<%=txtSTitle.ClientID%>").autocomplete('PaymentMilestoneAutoComplete.ashx');
        });
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

</script>
<style type="text/css">
    #progressBackgroundFilter
    {
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
    #processMessage
    {
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
<asp:UpdatePanel ID="updPaymentSlabe" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnTotalInstallment" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                PAYMENT MILESTONE SETUP
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
                                <table width="100%" cellpadding="3" cellspacing="3">
                                    <tr>
                                        <td colspan="2">
                                            <div style="height: 26px;">
                                                <%if (IsMessage)
                                                  { %>
                                                <div class="ResetSuccessfully">
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
                                        <td colspan="2">
                                            <div style="float: right;">
                                                <b>All Bold Fields are Mandatory</b>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" style="width: 130px;">
                                            <asp:Label ID="litPropertyName" runat="server" Text="Property Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfPropertyName" runat="server" ControlToValidate="ddlPropertyName"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    ErrorMessage="*" ValidationGroup="Payment"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:DropDownList ID="ddlPropertyName" runat="server" Style="width: 202px;" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlPropertyName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litBlock" runat="server" Text="Block" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfBlock" SetFocusOnError="true" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    CssClass="rfv_ErrorStar" runat="server" ControlToValidate="ddlBlock" ErrorMessage="*"
                                                    ValidationGroup="Payment"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBlock" runat="server" Style="width: 202px;" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblInstallmentInPercentage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litSlabNO" runat="server" Text="Milestone No." CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfSlabNo" runat="server" ControlToValidate="txtSlabNo"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="Payment"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSlabNo" runat="server" MaxLength="180" SkinID="CmpTextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litSlbTitle" runat="server" Text="Milestone Title" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfSlabTitle" runat="server" ControlToValidate="txtSlabTitle"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="Payment"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSlabTitle" runat="server" MaxLength="180" SkinID="CmpTextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="frvDateOfPossession" runat="server" ControlToValidate="txtDateOfCompletion"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="Payment"></asp:RequiredFieldValidator>
                                            </span>
                                            <b><asp:Literal ID="litDAteOfCompletion" runat="server" Text="Payment Due Date"></asp:Literal></b>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDateOfCompletion" runat="server" SkinID="CmpTextbox" Enabled="false"></asp:TextBox>
                                            <ajx:CalendarExtender ID="txtDateOfCompletion_ColorPickerExtender" runat="server" CssClass="MyCalendar"
                                                Enabled="True" TargetControlID="txtDateOfCompletion" PopupButtonID="imgColor">
                                            </ajx:CalendarExtender>
                                            <asp:Image ID="imgColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                Height="20px" Width="20px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litInstallment" runat="server" Text="Installment" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtInstallment"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="Payment"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtInstallment" runat="server" MaxLength="3" SkinID="CmpTextbox"></asp:TextBox><asp:Literal
                                                ID="Literal1" runat="server" Text=" (%)"></asp:Literal>
                                            <ajx:FilteredTextBoxExtender ID="ftInstallment" runat="server" TargetControlID="txtInstallment"
                                                FilterType="Numbers" ValidChars="1234567890" FilterMode="ValidChars" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:RangeValidator ID="rvInstallment" runat="server" Display="Dynamic" ForeColor="Red"
                                                ControlToValidate="txtInstallment" Type="Double" ValidationGroup="Payment"></asp:RangeValidator>
                                            <div id="validInstallment" runat="server" class="rfv_ErrorStar" visible="false" style="float: left;">
                                                Installment 0 not allowed</div>
                                            <%--<asp:RangeValidator ID="rvInstallment100" runat="server" Display="Dynamic" ErrorMessage="100% installment value reached"
                                                ForeColor="Red" ControlToValidate="txtInstallment" MinimumValue="-2" MaximumValue="-1" Type="Double" ValidationGroup="Payment"></asp:RangeValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:Literal ID="litThumb" runat="server" Text="Description"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDescription" TextMode="MultiLine" SkinID="Medium" Height="60px"
                                                runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" style="text-align: right;">
                                            <div style="float: right; width: auto; height: 26px; display: inline-block;">
                                                <asp:Button ID="btnNew" runat="server" Style="display: inline-block; margin-left: 5px;
                                                    display: inline;" Text="New" OnClick="btnNew_Click" />
                                                <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/save.png" ValidationGroup="Payment" CausesValidation="true"
                                                    OnClick="btnSave_Click" />
                                                <%--<asp:Button ID="btnCancel" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click" />--%>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
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
                                        <table id="tbl" cellpadding="2" cellspacing="0" width="100%" border="0" class="pageinfo">
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    <p class="pageInformation">
                                                        Property Name</p>
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:DropDownList ID="ddlSearchPropertyName" runat="server" SkinID="Search" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlSearchPropertyName_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    <p class="pageInformation">
                                                        Block</p>
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:DropDownList ID="ddlSrchBlock" runat="server" SkinID="Search">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    <p class="pageInformation">
                                                        Milestone Title</p>
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:TextBox ID="txtSTitle" runat="server" SkinID="Search"></asp:TextBox>
                                                </td>
                                                <td align="right" valign="middle" rowspan="2">
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; vertical-align: middle; margin-top: 4px; margin-right: 7px;"
                                                        OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <div style="height: 335px; overflow: auto;">
                                            <asp:GridView ID="grdSlabeList" runat="server" ShowHeader="false" ShowFooter="false"
                                                SkinID="gvNoPaging" AutoGenerateColumns="false" Width="92%" OnRowCommand="grdSlabeList_RowCommand"
                                                OnRowDataBound="grdSlabeList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea" style="width: 137px;">
                                                                    <strong>
                                                                        <asp:Label ID="Label2" runat="server" Width="137px" Text='<%#DataBinder.Eval(Container.DataItem, "SlabTitle")%>'></asp:Label></strong><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "PropertyName")%><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "BlockName")%><br />
                                                                    <%--<%#DataBinder.Eval(Container.DataItem, "SlabNo")%><br />--%>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Installment")%>%<br />
                                                                    <asp:Label ID="lblDateOfCompletion" Width="150px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateOfCompletion") != DBNull.Value ? Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DateOfCompletion")).ToString(DateFormat) : ""%>'></asp:Label>
                                                                    <%--<asp:Label ID="Label3" Width="150px" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DateOfCompletion")).ToString(DateFormat)%>'></asp:Label>--%>
                                                                </div>
                                                                <div class="leftmargin_icons">
                                                                    <%-- <asp:ImageButton ID="btnView" runat="server" ImageUrl="~/images/View.png" Style="border: 0px;
                                                                        vertical-align: middle; margin-top: 7px; margin-right: 7px;" />--%>
                                                                    <asp:ImageButton ID="btnEdit" runat="server" ToolTip="Edit" ImageUrl="~/images/edit.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
                                                                        CommandName="EditData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PaymentSlabeID")%>'
                                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                    <asp:ImageButton ID="btnDelete" ToolTip="Delete" runat="server" ImageUrl="~/images/delete_icon.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
                                                                        CommandName="DeleteData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PaymentSlabeID")%>'
                                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
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
                                                                <asp:Literal ID="Literal3" runat="server" Text="No Record Found"></asp:Literal></h2>
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
        <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="Panel1"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="Panel1" runat="server" Style="display: none;">
            <div style="width: 500px; height: 200px; margin-top: 25px;">
                <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
                    <tr>
                        <td class="modelpopup_boxtopleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxtopcenter">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxtopright">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="modelpopup_boxleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_box_bg">
                            <div style="width: 100px; float: left; margin-top: 10px;">
                                <asp:HyperLink ID="HyperLink1" runat="server">
                                    <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                        ID="Image2" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div style="float: left; width: 225px; margin-top: 40px; margin-left: 10px;">
                                <asp:Label ID="Label1" runat="server" Text="Sure you want to delete?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <asp:Button ID="btnPaymentSlabeYes" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnPaymentSlabeYes_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnPaymentSlabeNo" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            OnClick="btnPaymentSlabeNo_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="modelpopup_boxright">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="modelpopup_boxbottomleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxbottomcenter">
                        </td>
                        <td class="modelpopup_boxbottomright">
                            &nbsp;
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
<asp:UpdateProgress AssociatedUpdatePanelID="updPaymentSlabe" ID="UpdateProgressPaymentSlabe"
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
