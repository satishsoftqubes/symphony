<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCancellationPolicy.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlCancellationPolicy" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script type="text/javascript" language="javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnConfirmDelete(id) {
        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnConfirmDelete.ClientID %>').value = id;
        $find('mpeConfirmDelete').show();
        return false;
    }


    function fnConfirmDeletePolicy(id) {
        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnConfirmDeletePolicy.ClientID %>').value = id;
        $find('mpeConfirmDeletePolicy').show();
        return false;
    }


    //    function pageLoad(sender, args) {
    //        $(function () {
    //            $("#tabs").tabs();
    //        });

    //        $('#tabs').tabs({
    //            select: function (event, ui) {
    //                window.location.hash = ui.tab.hash;
    //            }
    //        });
    //    }

    //    function SelectTab(tabno) {
    //        if (tabno == '1') {
    //            window.location.hash = 'tabs-1';
    //        }
    //        else if (tabno == '2') {
    //            window.location.hash = 'tabs-2';
    //        }
    //        else if (tabno == '3') {
    //            window.location.hash = 'tabs-3';
    //        }
    //    }

</script>
<asp:UpdatePanel ID="upnlReservationConfig" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left" valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td align="left" valign="top">
                                <div class="box_form">
                                    <asp:MultiView ID="mvCancellationPolicy" runat="server">
                                        <asp:View ID="vCancellationPolicyList" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td colspan="4">
                                                        <%if (IsCancellationPolicyMsg)
                                                          { %>
                                                        <div class="message finalsuccess">
                                                            <p>
                                                                <strong>
                                                                    <asp:Literal ID="litNewCancelPolicyMsg" runat="server"></asp:Literal></strong>
                                                            </p>
                                                        </div>
                                                        <%}%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="275px">
                                                                    <asp:Literal ID="litNoOfVerificationCriteriaForAmendmentOrCancellationReservaion"
                                                                        runat="server" Text="Min. Verification Criteria for Cancel Reservation"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNoOfVerificationCriteriaForAmendmentOrCancellationReservaion"
                                                                        runat="server" MaxLength="10" Style="width: 50px;"></asp:TextBox>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rfvMinCriteriaforAmentRes" SetFocusOnError="True"
                                                                            CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForTopSave"
                                                                            ControlToValidate="txtNoOfVerificationCriteriaForAmendmentOrCancellationReservaion"
                                                                            Display="Static"></asp:RequiredFieldValidator>
                                                                    </span>
                                                                    <ajx:FilteredTextBoxExtender ID="ftNoOfVerificationCriteriaForAmendmentOrCancellationReservaion"
                                                                        runat="server" FilterMode="ValidChars" ValidChars="0123456789" TargetControlID="txtNoOfVerificationCriteriaForAmendmentOrCancellationReservaion">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                </td>
                                                                <td width="470px">
                                                                    Retention charge for Premature check out on unposted accommodation charge (%)
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtRetentionCharge" runat="server" MaxLength="5" Style="width: 50px;"></asp:TextBox>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rfvRetentionCharge" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                            runat="server" ValidationGroup="IsRequireForTopSave" ControlToValidate="txtRetentionCharge"
                                                                            Display="Static"></asp:RequiredFieldValidator>
                                                                    </span>
                                                                    <ajx:FilteredTextBoxExtender ID="fteRetentionCharge" runat="server" FilterMode="ValidChars"
                                                                        ValidChars="0123456789." TargetControlID="txtRetentionCharge">
                                                                    </ajx:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" align="right">
                                                                    <asp:Button ID="btnSaveTop" runat="server" ValidationGroup="IsRequireForTopSave"
                                                                        OnClick="btnSaveTop_OnClick" Text="Save" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 15px;">
                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td style="padding: 0px;" align="left">
                                                                    <b>Cancellation Policy List</b>
                                                                </td>
                                                                <td align="right" style="padding: 0px;">
                                                                    <asp:Button ID="btnAddTopCancellationPolicy" runat="server" Text="Add" OnClick="btnAddCancellationPolicy_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 0px;" colspan="2">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvCancellationPolicy" OnRowCommand="gvCancellationPolicy_RowCommand"
                                                                OnPageIndexChanging="gvCancellationPolicy_PageIndexChanging" DataKeyNames="ResPolicyID" OnRowDataBound="gvCancellationPolicy_RowDataBound"
                                                                runat="server" AutoGenerateColumns="False" Width="100%">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSrNo" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrPolicyTitle" Text="Policy Title" runat="server" ItemStyle-Width="100px"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblUnitNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PolicyTitle")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAllowedOnRateCard" Text="Applied On Rate Card" runat="server"
                                                                                ItemStyle-Width="100px"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRateCards" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAction" Text="Actions" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ResPolicyID")%>'
                                                                                CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" alt="" /></asp:LinkButton>
                                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ResPolicyID")%>'
                                                                                CommandName="DELETEDATA"><img src="../../images/delete.png" alt="" /></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label>
                                                                        </b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vCancellationPolicy" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td colspan="6">
                                                        <%if (IsMessagePolicy)
                                                          { %>
                                                        <div class="message finalsuccess">
                                                            <p>
                                                                <strong>
                                                                    <asp:Literal ID="litNewCancelPolicy" runat="server"></asp:Literal></strong>
                                                            </p>
                                                        </div>
                                                        <%}%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <b>Title</b>
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvTitle" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequireForNCP" ControlToValidate="txtTitle"
                                                                Display="Static"></asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkFirst" AutoPostBack="true" OnCheckedChanged="ckhFirst_Changed"
                                                            runat="server" />
                                                    </td>
                                                    <td style="width: 105px;">
                                                        <asp:TextBox ID="txtFirstCharges" Enabled="false" MaxLength="15" runat="server" Style="width: 75px !important;"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="fteFirstCharges" runat="server" FilterType="Custom, Numbers"
                                                            ValidChars="." TargetControlID="txtFirstCharges">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvFirstCharges" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtFirstCharges" Display="Static"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                    <td style="width: 100px;">
                                                        <asp:DropDownList AutoPostBack="true" ID="ddlFirstChargesType" OnSelectedIndexChanged="ddlFirstChargesType_SelectedIndexChanged"
                                                            Enabled="false" runat="server" Style="width: 75px !important;">
                                                            <asp:ListItem Selected="True" Value="%" Text="%"></asp:ListItem>
                                                            <asp:ListItem Value="Flat" Text="Flat"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 150px;">
                                                        Charge for cancellation
                                                    </td>
                                                    <td style="width: 175px;">
                                                        <asp:TextBox ID="txtFirstMindays" Enabled="false" MaxLength="8" runat="server" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;
                                                        <ajx:FilteredTextBoxExtender ID="fteFirstMindays" runat="server" FilterType="Custom, Numbers"
                                                            TargetControlID="txtFirstMindays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvFirstMindays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtFirstMindays" Display="Static"></asp:RequiredFieldValidator></span>Min
                                                        days to
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFirstMaxdays" Enabled="false" MaxLength="8" runat="server" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;
                                                        <ajx:FilteredTextBoxExtender ID="fteFirstMaxdays" runat="server" FilterType="Custom, Numbers"
                                                            TargetControlID="txtFirstMaxdays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvFirstMaxdays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtFirstMaxdays" Display="Static"></asp:RequiredFieldValidator></span>Max
                                                        days prior to check in date
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:RangeValidator ID="rvFirstCharges" Display="Dynamic" runat="server" MinimumValue="0"
                                                            MaximumValue="100" ControlToValidate="txtFirstCharges" SetFocusOnError="true"
                                                            ValidationGroup="IsRequireForNCP" ForeColor="Red" Type="Double"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator Display="Dynamic" ID="revFirstCharges" runat="server"
                                                            ForeColor="Red" ControlToValidate="txtFirstCharges" SetFocusOnError="true" ValidationGroup="IsRequireForNCP">
                                                        </asp:RegularExpressionValidator>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:CompareValidator ID="cvFirstMaxdays" runat="server" ControlToCompare="txtFirstMindays"
                                                            Type="Integer" SetFocusOnError="True" ForeColor="Red" ControlToValidate="txtFirstMaxdays"
                                                            Operator="GreaterThan" ValidationGroup="IsRequireForNCP" Display="Dynamic"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkSecond" AutoPostBack="true" OnCheckedChanged="chkSecond_Changed"
                                                            runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSecondCharges" Enabled="false" MaxLength="15" runat="server"
                                                            Style="width: 75px !important;"></asp:TextBox><ajx:FilteredTextBoxExtender ID="fteSecondCharges"
                                                                runat="server" FilterType="Custom, Numbers" ValidChars="." TargetControlID="txtSecondCharges">
                                                            </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvSecondCharges" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtSecondCharges" Display="Static"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList AutoPostBack="true" ID="ddlSecondChargesType" OnSelectedIndexChanged="ddlSecondChargesType_SelectedIndexChanged"
                                                            Enabled="false" runat="server" Style="width: 75px !important;">
                                                            <asp:ListItem Selected="True" Value="%" Text="%"></asp:ListItem>
                                                            <asp:ListItem Value="Flat" Text="Flat"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        Charge for cancellation
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSecondMindays" Enabled="false" MaxLength="8" runat="server" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;<ajx:FilteredTextBoxExtender
                                                            ID="fteSecondMindays" runat="server" FilterType="Custom, Numbers" TargetControlID="txtSecondMindays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvSecondMindays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtSecondMindays" Display="Static"></asp:RequiredFieldValidator></span>Min
                                                        days to
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSecondMaxdays" Enabled="false" MaxLength="8" runat="server" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;<ajx:FilteredTextBoxExtender
                                                            ID="fteSecondMaxdays" runat="server" FilterType="Custom, Numbers" TargetControlID="txtSecondMaxdays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvSecondMaxdays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtSecondMaxdays" Display="Static"></asp:RequiredFieldValidator></span>Max
                                                        days prior to check in date
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:RangeValidator ID="rvSecondCharges" Display="Dynamic" runat="server" MinimumValue="0"
                                                            MaximumValue="100" ControlToValidate="txtSecondCharges" SetFocusOnError="true"
                                                            ValidationGroup="IsRequireForNCP" ForeColor="Red" Type="Double"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator Display="Dynamic" ID="revSecondCharges" runat="server"
                                                            ForeColor="Red" ControlToValidate="txtSecondCharges" SetFocusOnError="true" ValidationGroup="IsRequireForNCP">
                                                        </asp:RegularExpressionValidator>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:CompareValidator ID="cvSecondMaxdays" runat="server" ControlToCompare="txtSecondMindays"
                                                            Type="Integer" SetFocusOnError="True" ForeColor="Red" ControlToValidate="txtSecondMaxdays"
                                                            Operator="GreaterThan" ValidationGroup="IsRequireForNCP" Display="Dynamic"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkThird" AutoPostBack="true" OnCheckedChanged="chkThird_Changed"
                                                            runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtThirdCharges" Enabled="false" MaxLength="15" runat="server" Style="width: 75px !important;"></asp:TextBox><ajx:FilteredTextBoxExtender
                                                            ID="fteThirdCharges" runat="server" FilterType="Custom, Numbers" ValidChars="."
                                                            TargetControlID="txtThirdCharges">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvThirdCharges" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtThirdCharges" Display="Static"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList AutoPostBack="true" ID="ddlThirdChargesType" OnSelectedIndexChanged="ddlThirdChargesType_SelectedIndexChanged"
                                                            Enabled="false" runat="server" Style="width: 75px !important;">
                                                            <asp:ListItem Selected="True" Value="%" Text="%"></asp:ListItem>
                                                            <asp:ListItem Value="Flat" Text="Flat"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        Charge for cancellation
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtThirdMindays" Enabled="false" MaxLength="8" runat="server" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;<ajx:FilteredTextBoxExtender
                                                            ID="fteThirdMindays" runat="server" FilterType="Custom, Numbers" TargetControlID="txtThirdMindays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvThirdMindays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtThirdMindays" Display="Static"></asp:RequiredFieldValidator></span>Min
                                                        days to
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtThirdMaxdays" Enabled="false" MaxLength="8" runat="server" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;<ajx:FilteredTextBoxExtender
                                                            ID="fteThirdMaxdays" runat="server" FilterType="Custom, Numbers" TargetControlID="txtThirdMaxdays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvThirdMaxdays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtThirdMaxdays" Display="Static"></asp:RequiredFieldValidator></span>Max
                                                        days prior to check in date
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:RangeValidator ID="rvThirdCharges" Display="Dynamic" runat="server" MinimumValue="0"
                                                            MaximumValue="100" ControlToValidate="txtThirdCharges" SetFocusOnError="true"
                                                            ValidationGroup="IsRequireForNCP" ForeColor="Red" Type="Double"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator Display="Dynamic" ID="revThirdCharges" runat="server"
                                                            ForeColor="Red" ControlToValidate="txtThirdCharges" SetFocusOnError="true" ValidationGroup="IsRequireForNCP">
                                                        </asp:RegularExpressionValidator>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:CompareValidator ID="cvThirdMaxdays" runat="server" ControlToCompare="txtThirdMindays"
                                                            Type="Integer" SetFocusOnError="True" ForeColor="Red" ControlToValidate="txtThirdMaxdays"
                                                            Operator="GreaterThan" ValidationGroup="IsRequireForNCP" Display="Dynamic"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkFourth" AutoPostBack="true" OnCheckedChanged="chkFourth_Changed"
                                                            runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFourthCharges" runat="server" MaxLength="15" Style="width: 75px !important;"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="fteFourthCharges" runat="server" FilterType="Custom, Numbers"
                                                            ValidChars="." TargetControlID="txtFourthCharges">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvFourthCharges" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtFourthCharges" Display="Static"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList AutoPostBack="true" ID="ddlFourthChargesType" OnSelectedIndexChanged="ddlFourthChargesType_SelectedIndexChanged"
                                                            Enabled="false" runat="server" Style="width: 75px !important;">
                                                            <asp:ListItem Selected="True" Value="%" Text="%"></asp:ListItem>
                                                            <asp:ListItem Value="Flat" Text="Flat"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        Charge for cancellation
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFourthMindays" Enabled="false" MaxLength="8" runat="server" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;
                                                        <ajx:FilteredTextBoxExtender ID="fteFourthMindays" runat="server" FilterType="Custom, Numbers"
                                                            TargetControlID="txtFourthMindays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvFourthMindays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtFourthMindays" Display="Static"></asp:RequiredFieldValidator></span>Min
                                                        days to
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFourthMaxdays" Enabled="false" MaxLength="8" runat="server" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;<ajx:FilteredTextBoxExtender
                                                            ID="fteFourthMaxdays" runat="server" FilterType="Custom, Numbers" TargetControlID="txtFourthMaxdays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvFourthMaxdays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtFourthMaxdays" Display="Static"></asp:RequiredFieldValidator></span>Max
                                                        days prior to check in date
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:RangeValidator ID="rvFourthCharges" Display="Dynamic" runat="server" MinimumValue="0"
                                                            MaximumValue="100" ControlToValidate="txtFourthCharges" SetFocusOnError="true"
                                                            ValidationGroup="IsRequireForNCP" ForeColor="Red" Type="Double"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator Display="Dynamic" ID="revFourthCharges" runat="server"
                                                            ForeColor="Red" ControlToValidate="txtFourthCharges" SetFocusOnError="true" ValidationGroup="IsRequireForNCP">
                                                        </asp:RegularExpressionValidator>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:CompareValidator ID="cvFourthMaxdays" runat="server" ControlToCompare="txtFourthMindays"
                                                            Type="Integer" SetFocusOnError="True" ForeColor="Red" ControlToValidate="txtFourthMaxdays"
                                                            Operator="GreaterThan" ValidationGroup="IsRequireForNCP" Display="Dynamic"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkFifth" AutoPostBack="true" OnCheckedChanged="chkFifth_Changed"
                                                            runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFifthCharges" Enabled="false" MaxLength="15" runat="server" Style="width: 75px !important;"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="fteFifthCharges" runat="server" FilterType="Custom, Numbers"
                                                            ValidChars="." TargetControlID="txtFifthCharges">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvFifthCharges" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtFifthCharges" Display="Static"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList AutoPostBack="true" ID="ddlFifthChargesType" OnSelectedIndexChanged="ddlFifthChargesType_SelectedIndexChanged"
                                                            Enabled="false" runat="server" Style="width: 75px !important;">
                                                            <asp:ListItem Selected="True" Value="%" Text="%"></asp:ListItem>
                                                            <asp:ListItem Value="Flat" Text="Flat"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        Charge for cancellation
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFifthMindays" Enabled="false" MaxLength="8" runat="server" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;
                                                        <ajx:FilteredTextBoxExtender ID="fteFifthMindays" runat="server" FilterType="Custom, Numbers"
                                                            TargetControlID="txtFifthMindays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvFifthMindays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtFifthMindays" Display="Static"></asp:RequiredFieldValidator></span>Min
                                                        days to
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFifthMaxdays" Enabled="false" MaxLength="8" runat="server" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;
                                                        <ajx:FilteredTextBoxExtender ID="fteFifthMaxdays" runat="server" FilterType="Custom, Numbers"
                                                            TargetControlID="txtFifthMaxdays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvFifthMaxdays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtFifthMaxdays" Display="Static"></asp:RequiredFieldValidator></span>Max
                                                        days prior to check in date
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:RangeValidator ID="rvFifthCharges" Display="Dynamic" runat="server" MinimumValue="0"
                                                            MaximumValue="100" ControlToValidate="txtFifthCharges" SetFocusOnError="true"
                                                            ValidationGroup="IsRequireForNCP" ForeColor="Red" Type="Double"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator Display="Dynamic" ID="revFifthCharges" runat="server"
                                                            ForeColor="Red" ControlToValidate="txtFifthCharges" SetFocusOnError="true" ValidationGroup="IsRequireForNCP">
                                                        </asp:RegularExpressionValidator>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:CompareValidator ID="cvFifthMaxdays" runat="server" ControlToCompare="txtFifthMindays"
                                                            Type="Integer" SetFocusOnError="True" ForeColor="Red" ControlToValidate="txtFifthMaxdays"
                                                            Operator="GreaterThan" ValidationGroup="IsRequireForNCP" Display="Dynamic"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr id="trPolicySix" runat="server" visible="false">
                                                    <td>
                                                        <asp:CheckBox ID="chkSix" AutoPostBack="true" OnCheckedChanged="chkSix_Changed" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSixCharges" Enabled="false" MaxLength="15" runat="server" Style="width: 75px !important;"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="fteSixCharges" runat="server" FilterType="Custom, Numbers"
                                                            ValidChars="." TargetControlID="txtSixCharges">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvSixCharges" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtSixCharges" Display="Static"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList AutoPostBack="true" ID="ddlSixChargesType" OnSelectedIndexChanged="ddlSixChargesType_SelectedIndexChanged"
                                                            Enabled="false" runat="server" Style="width: 75px !important;">
                                                            <asp:ListItem Selected="True" Value="%" Text="%"></asp:ListItem>
                                                            <asp:ListItem Value="Flat" Text="Flat"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        Charge for cancellation
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSixMindays" Enabled="false" runat="server" MaxLength="8" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;
                                                        <ajx:FilteredTextBoxExtender ID="fteSixMindays" runat="server" FilterType="Custom, Numbers"
                                                            TargetControlID="txtSixMindays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvSixMindays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtSixMindays" Display="Static"></asp:RequiredFieldValidator></span>Min
                                                        days to
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSixMaxdays" Enabled="false" runat="server" MaxLength="8" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;
                                                        <ajx:FilteredTextBoxExtender ID="fteSixMaxdays" runat="server" FilterType="Custom, Numbers"
                                                            TargetControlID="txtSixMaxdays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvSixMaxdays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtSixMaxdays" Display="Static"></asp:RequiredFieldValidator></span>Max
                                                        days prior to check in date
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:RangeValidator ID="rvSixCharges" Display="Dynamic" runat="server" MinimumValue="0"
                                                            MaximumValue="100" ControlToValidate="txtSixCharges" SetFocusOnError="true" ValidationGroup="IsRequireForNCP"
                                                            ForeColor="Red" Type="Double"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator Display="Dynamic" ID="revSixCharges" runat="server"
                                                            ForeColor="Red" ControlToValidate="txtSixCharges" SetFocusOnError="true" ValidationGroup="IsRequireForNCP">
                                                        </asp:RegularExpressionValidator>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:CompareValidator ID="cvSixMaxdays" runat="server" ControlToCompare="txtSixMindays"
                                                            Type="Integer" SetFocusOnError="True" ForeColor="Red" ControlToValidate="txtSixMaxdays"
                                                            Operator="GreaterThan" ValidationGroup="IsRequireForNCP" Display="Dynamic"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr id="trPolicySeven" runat="server" visible="false">
                                                    <td>
                                                        <asp:CheckBox ID="chkSeven" AutoPostBack="true" OnCheckedChanged="chkSeven_Changed"
                                                            runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSevenCharges" Enabled="false" MaxLength="15" runat="server" Style="width: 75px !important;"></asp:TextBox><ajx:FilteredTextBoxExtender
                                                            ID="fteSevenCharges" runat="server" FilterType="Custom, Numbers" ValidChars="."
                                                            TargetControlID="txtSevenCharges">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvSevenCharges" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtSevenCharges" Display="Static"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList AutoPostBack="true" ID="ddlSevenChargesType" OnSelectedIndexChanged="ddlSevenChargesType_SelectedIndexChanged"
                                                            Enabled="false" runat="server" Style="width: 75px !important;">
                                                            <asp:ListItem Selected="True" Value="%" Text="%"></asp:ListItem>
                                                            <asp:ListItem Value="Flat" Text="Flat"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        Charge for cancellation
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSevenMindays" Enabled="false" runat="server" MaxLength="8" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;<ajx:FilteredTextBoxExtender
                                                            ID="fteSevenMindays" runat="server" FilterType="Custom, Numbers" TargetControlID="txtSevenMindays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvSevenMindays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtSevenMindays" Display="Static"></asp:RequiredFieldValidator></span>Min
                                                        days to
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSevenMaxdays" Enabled="false" runat="server" MaxLength="8" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;<ajx:FilteredTextBoxExtender
                                                            ID="fteSevenMaxdays" runat="server" FilterType="Custom, Numbers" TargetControlID="txtSevenMaxdays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvSevenMaxdays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtSevenMaxdays" Display="Static"></asp:RequiredFieldValidator></span>Max
                                                        days prior to check in date
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:RangeValidator ID="rvSevenCharges" Display="Dynamic" runat="server" MinimumValue="0"
                                                            MaximumValue="100" ControlToValidate="txtSevenCharges" SetFocusOnError="true"
                                                            ValidationGroup="IsRequireForNCP" ForeColor="Red" Type="Double"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator Display="Dynamic" ID="revSevenCharges" runat="server"
                                                            ForeColor="Red" ControlToValidate="txtSevenCharges" SetFocusOnError="true" ValidationGroup="IsRequireForNCP">
                                                        </asp:RegularExpressionValidator>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:CompareValidator ID="cvSevenMaxdays" runat="server" ControlToCompare="txtSevenMindays"
                                                            Type="Integer" SetFocusOnError="True" ForeColor="Red" ControlToValidate="txtSevenMaxdays"
                                                            Operator="GreaterThan" ValidationGroup="IsRequireForNCP" Display="Dynamic"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr id="trPolicyEighth" runat="server" visible="false">
                                                    <td>
                                                        <asp:CheckBox ID="chkEighth" AutoPostBack="true" OnCheckedChanged="chkEighth_Changed"
                                                            runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEighthCharges" Enabled="false" MaxLength="15" runat="server"
                                                            Style="width: 75px !important;"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="fteEighthCharges" runat="server" FilterType="Custom, Numbers"
                                                            ValidChars="." TargetControlID="txtEighthCharges">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvEighthCharges" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtEighthCharges" Display="Static"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList AutoPostBack="true" ID="ddlEighthChargesType" OnSelectedIndexChanged="ddlEighthChargesType_SelectedIndexChanged"
                                                            Enabled="false" runat="server" Style="width: 75px !important;">
                                                            <asp:ListItem Selected="True" Value="%" Text="%"></asp:ListItem>
                                                            <asp:ListItem Value="Flat" Text="Flat"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        Charge for cancellation
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEighthMindays" Enabled="false" MaxLength="8" runat="server" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;<ajx:FilteredTextBoxExtender
                                                            ID="fteEighthMindays" runat="server" FilterType="Custom, Numbers" TargetControlID="txtEighthMindays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvEighthMindays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtEighthMindays" Display="Static"></asp:RequiredFieldValidator></span>Min
                                                        days to
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEighthMaxdays" Enabled="false" MaxLength="8" runat="server" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;<ajx:FilteredTextBoxExtender
                                                            ID="fteEighthMaxdays" runat="server" FilterType="Custom, Numbers" TargetControlID="txtEighthMaxdays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvEighthMaxdays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtEighthMaxdays" Display="Static"></asp:RequiredFieldValidator></span>Max
                                                        days prior to check in date
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:RangeValidator ID="rvEighthCharges" Display="Dynamic" runat="server" MinimumValue="0"
                                                            MaximumValue="100" ControlToValidate="txtEighthCharges" SetFocusOnError="true"
                                                            ValidationGroup="IsRequireForNCP" ForeColor="Red" Type="Double"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator Display="Dynamic" ID="revEighthCharges" runat="server"
                                                            ForeColor="Red" ControlToValidate="txtEighthCharges" SetFocusOnError="true" ValidationGroup="IsRequireForNCP">
                                                        </asp:RegularExpressionValidator>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:CompareValidator ID="cvEighthMaxdays" runat="server" ControlToCompare="txtEighthMindays"
                                                            Type="Integer" SetFocusOnError="True" ForeColor="Red" ControlToValidate="txtEighthMaxdays"
                                                            Operator="GreaterThan" ValidationGroup="IsRequireForNCP" Display="Dynamic"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr id="trPolicyNine" runat="server" visible="false">
                                                    <td>
                                                        <asp:CheckBox ID="chkNine" AutoPostBack="true" OnCheckedChanged="chkNine_Changed"
                                                            runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNineCharges" Enabled="false" MaxLength="15" runat="server" Style="width: 75px !important;"></asp:TextBox><ajx:FilteredTextBoxExtender
                                                            ID="fteNineCharges" runat="server" FilterType="Custom, Numbers" ValidChars="."
                                                            TargetControlID="txtNineCharges">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvNineCharges" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtNineCharges" Display="Static"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlNineChargesType" OnSelectedIndexChanged="ddlNineChargesType_SelectedIndexChanged"
                                                            Enabled="false" AutoPostBack="true" runat="server" Style="width: 75px !important;">
                                                            <asp:ListItem Selected="True" Value="%" Text="%"></asp:ListItem>
                                                            <asp:ListItem Value="Flat" Text="Flat"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        Charge for cancellation
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNineMindays" Enabled="false" MaxLength="8" runat="server" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;<ajx:FilteredTextBoxExtender
                                                            ID="fteNineMindays" runat="server" FilterType="Custom, Numbers" ValidChars="."
                                                            TargetControlID="txtNineMindays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvNineMindays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtNineMindays" Display="Static"></asp:RequiredFieldValidator></span>Min
                                                        days to
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNineMaxdays" Enabled="false" MaxLength="8" runat="server" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;<ajx:FilteredTextBoxExtender
                                                            ID="fteNineMaxdays" runat="server" FilterType="Custom, Numbers" ValidChars="."
                                                            TargetControlID="txtNineMaxdays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvNineMaxdays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtNineMaxdays" Display="Static"></asp:RequiredFieldValidator></span>Max
                                                        days prior to check in date
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:RangeValidator ID="rvNineCharges" Display="Dynamic" runat="server" MinimumValue="0"
                                                            MaximumValue="100" ControlToValidate="txtNineCharges" SetFocusOnError="true"
                                                            ValidationGroup="IsRequireForNCP" ForeColor="Red" Type="Double"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator Display="Dynamic" ID="revNineCharges" runat="server"
                                                            ForeColor="Red" ControlToValidate="txtNineCharges" SetFocusOnError="true" ValidationGroup="IsRequireForNCP">
                                                        </asp:RegularExpressionValidator>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:CompareValidator ID="cvNineMaxdays" runat="server" ControlToCompare="txtNineMindays"
                                                            Type="Integer" SetFocusOnError="True" ForeColor="Red" ControlToValidate="txtNineMaxdays"
                                                            Operator="GreaterThan" ValidationGroup="IsRequireForNCP" Display="Dynamic"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr id="trPolicyTen" runat="server" visible="false">
                                                    <td>
                                                        <asp:CheckBox ID="chkTen" AutoPostBack="true" OnCheckedChanged="chkTen_Changed" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTenCharges" Enabled="false" MaxLength="15" runat="server" Style="width: 75px !important;"></asp:TextBox><ajx:FilteredTextBoxExtender
                                                            ID="fteTenCharges" runat="server" FilterType="Custom, Numbers" ValidChars="."
                                                            TargetControlID="txtTenCharges">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvTenCharges" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtTenCharges" Display="Static"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList AutoPostBack="true" ID="ddlTenChargesType" OnSelectedIndexChanged="ddlTenChargesType_SelectedIndexChanged"
                                                            Enabled="false" runat="server" Style="width: 75px !important;">
                                                            <asp:ListItem Selected="True" Value="%" Text="%"></asp:ListItem>
                                                            <asp:ListItem Value="Flat" Text="Flat"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        Charge for cancellation
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTenMindays" Enabled="false" MaxLength="8" runat="server" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;<ajx:FilteredTextBoxExtender
                                                            ID="fteTenMindays" runat="server" FilterType="Custom, Numbers" TargetControlID="txtTenMindays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvTenMindays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtTenMindays" Display="Static"></asp:RequiredFieldValidator></span>Min
                                                        days to
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTenMaxdays" Enabled="false" MaxLength="8" runat="server" Style="width: 75px !important;"></asp:TextBox>&nbsp;&nbsp;<ajx:FilteredTextBoxExtender
                                                            ID="fteTenMaxdays" runat="server" FilterType="Custom, Numbers" TargetControlID="txtTenMaxdays">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <span>
                                                            <asp:RequiredFieldValidator Enabled="false" ID="rfvTenMaxdays" SetFocusOnError="True"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequireForNCP"
                                                                ControlToValidate="txtTenMaxdays" Display="Static"></asp:RequiredFieldValidator></span>Max
                                                        days prior to check in date
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:RangeValidator ID="rvTenCharges" Display="Dynamic" runat="server" MinimumValue="0"
                                                            MaximumValue="100" ControlToValidate="txtTenCharges" SetFocusOnError="true" ValidationGroup="IsRequireForNCP"
                                                            ForeColor="Red" Type="Double"></asp:RangeValidator>
                                                        <asp:RegularExpressionValidator Display="Dynamic" ID="revTenCharges" runat="server"
                                                            ForeColor="Red" ControlToValidate="txtTenCharges" SetFocusOnError="true" ValidationGroup="IsRequireForNCP">
                                                        </asp:RegularExpressionValidator>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:CompareValidator ID="cvTenMaxdays" runat="server" ControlToCompare="txtTenMindays"
                                                            Type="Integer" SetFocusOnError="True" ForeColor="Red" ControlToValidate="txtTenMaxdays"
                                                            Operator="GreaterThan" ValidationGroup="IsRequireForNCP" Display="Dynamic"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <b>
                                                                        <asp:Literal ID="lithdrCancellationPolicy" Text="Policy Note" runat="server"></asp:Literal></b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <CKEditor:CKEditorControl ID="txtCancellationPolicy" runat="server">
                                                                    </CKEditor:CKEditorControl>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5" align="right">
                                                        <asp:Button ID="bntAddNewPolicy" OnClick="bntAddNewPolicy_Click" runat="server" Text="Add New Policy"
                                                            Style="display: inline;" />
                                                        <asp:Button ID="btnNewSave" ValidationGroup="IsRequireForNCP" OnClick="btnNewSave_Click"
                                                            runat="server" Text="Save" Style="display: inline;" />
                                                        <asp:Button ID="btnNewCancel" runat="server" Text="Cancel" Style="display: inline;"
                                                            OnClick="btnNewCancel_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
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
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="350px" Width="325px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderConfirmDeletePopup" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="ltrConfirmDeleteMsg" Text="Sure you want to delete?" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYes" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClick="btnYes_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                <asp:Button ID="btnNo" runat="server" Style="display: inline;" OnClick="btnNo_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeConfirmDeletePolicy" runat="server" TargetControlID="hdnConfirmDeletePolicy"
            PopupControlID="pnlDeleteDataPolicy" BackgroundCssClass="mod_background" BehaviorID="mpeConfirmDeletePolicy">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDeletePolicy" runat="server" />
        <asp:Panel ID="pnlDeleteDataPolicy" runat="server" Height="350px" Width="325px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderConfirmDeletePopupPolicy" Text="Cancellation Policy" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="ltrConfirmDeleteMsgPolicy" Text="Sure you want to delete?" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYesPolicy" Text="Yes" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClick="btnYesPolicy_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                <asp:Button ID="btnNoPolicy" Text="No" runat="server" Style="display: inline;" OnClick="btnNoPolicy_Click" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="upnlReservationConfig" ID="UpdateProgressReservationConfig"
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
