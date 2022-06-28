<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRoomType.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlRoomType" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript" src="../../fancybox/jquery.fancybox-1.3.4.pack.js"></script>
<link rel="stylesheet" type="text/css" href="../../fancybox/jquery.fancybox-1.3.4.css"
    media="screen" />
<script src="../../Javascript/jquery.MultiFile.js" type="text/javascript"></script>
<script type="text/javascript">
    function pageLoad(sender, args) {
        $(function () {
            $("#tabs").tabs();
        });

        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });
    }

    $(document).ready(function () {
        $("a[rel=example_group]").fancybox({
            'transitionIn': 'none',
            'transitionOut': 'none',
            'titlePosition': 'over',
            'titleFormat': function (title, currentArray, currentIndex, currentOpts) {
                return '<span id="fancybox-title-over">Image ' + (currentIndex + 1) + ' / ' + currentArray.length + (title.length ? ' &nbsp; ' + title : '') + '</span>';
            }
        });


    });

    function fnClearMessage() {
        document.getElementById("<%=lblSelectFileForRG.ClientID %>").innerHTML = "";
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<script type="text/javascript">
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("IsRequire")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgressRoomType.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
    }
</script>
<script language="javascript">
    function SelectTab() {
        if (window.location.hash != '#tabs-1') {
            window.location.hash = 'tabs-2';
        }
    }

    function SelectTabIndex(tabIndex) {
        var tabOpts = {
            disabled: [1]
        };

        $("#tabs").tabs(tabOpts);
        if (tabIndex == '0') {
            $("#tabs").tabs("disable", 1);
        }
        else if (tabIndex == '1') {
            $("#tabs").tabs("enable", 1);
        }
    }

    function fnRequireValidationForCheckBox() {
        var chkOverBooking = document.getElementById("<%=chkOverBooking.ClientID %>");

        var ddlOverBooking = document.getElementById("<%=ddlOverBooking.ClientID %>");
        var txtOverBooking = document.getElementById("<%=txtOverBooking.ClientID %>");

        var ddlRequireOverBooking = document.getElementById("<%=rfvddlOverBooking.ClientID %>");
        var txtRequireOverBooking = document.getElementById("<%=rfvtxtOverBooking.ClientID %>");
        var revOverBooking = document.getElementById("<%=revOverBooking.ClientID %>");

        if (chkOverBooking.checked) {
            ddlOverBooking.disabled = false;
            txtOverBooking.disabled = false;

            ValidatorEnable(ddlRequireOverBooking, true);
            ValidatorEnable(txtRequireOverBooking, true);
            ValidatorEnable(revOverBooking, true);

        }
        else {
            ddlOverBooking.disabled = true;
            txtOverBooking.disabled = true;

            ddlOverBooking.selectedIndex = 0;
            txtOverBooking.value = "";

            ValidatorEnable(ddlRequireOverBooking, false);
            ValidatorEnable(txtRequireOverBooking, false);
            ValidatorEnable(revOverBooking, false);
        }

    }

    function fncheck() {
        if (Page_ClientValidate("IsRequire")) {

            document.getElementById('errormessage').style.display = "block";
            var chkOverBooking = document.getElementById("<%=chkOverBooking.ClientID %>");
            var ddlOverBooking1 = document.getElementById("<%=ddlOverBooking.ClientID %>");
            var txtOverBooking1 = document.getElementById("<%=txtOverBooking.ClientID %>");
            var lblOverBooking = document.getElementById("<%=lblOverBooking.ClientID %>");

            if (chkOverBooking.checked) {
                if (ddlOverBooking1.value != '00000000-0000-0000-0000-000000000000') {
                    if (ddlOverBooking1.selectedIndex == 1) {

                        var v = parseFloat(txtOverBooking1.value);
                        if (v > 100) {
                            lblOverBooking.style.display = 'block';
                            return false;
                        }
                        else {
                            lblOverBooking.style.display = 'none';
                            updateProgress = $find("<%= UpdateProgressRoomType.ClientID %>");
                            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
                            return true;
                        }
                    }
                }
                else {
                    updateProgress = $find("<%= UpdateProgressRoomType.ClientID %>");
                    window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
                    return true;
                }
            }
            else {
                updateProgress = $find("<%= UpdateProgressRoomType.ClientID %>");
                window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
                return true;
            }
        }
    }


    function fnChangeMessage() {
        var txtOverBooking = document.getElementById("<%=txtOverBooking.ClientID %>");
        var lblOverBooking = document.getElementById("<%=lblOverBooking.ClientID %>");
        if (txtOverBooking.value == '') {
            lblOverBooking.style.display = 'none';
        }
    }
</script>
<asp:UpdatePanel ID="updRoomType" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#fff">
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
                            <td align="left" style="padding-top: 10px; background-color: #fff !important;">
                                <div class="demo">
                                    <div id="tabs">
                                        <ul>
                                            <li><a href="#tabs-1">
                                                <asp:Literal ID="litRoomTypeTabBasicInformation" runat="server"></asp:Literal></a></li>
                                            <li><a href="#tabs-2">
                                                <asp:Literal ID="litRoomTypeTabGallery" runat="server"></asp:Literal></a></li>
                                        </ul>
                                        <div id="tabs-1">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td colspan="4">
                                                        <%if (IsListMessageForBI)
                                                          { %>
                                                        <div class="message finalsuccess">
                                                            <p>
                                                                <strong>
                                                                    <asp:Literal ID="ltrListMessageBI" runat="server"></asp:Literal></strong>
                                                            </p>
                                                        </div>
                                                        <%}%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <div style="float: right; padding-bottom: 5px;">
                                                            <b>
                                                                <asp:Literal ID="litGeneralMandartoryFiledMessage" runat="server"></asp:Literal>
                                                            </b>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Label ID="lbltpUnitTypeName" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtUnitTypeName" SkinID="searchtextbox" runat="server" MaxLength="65"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvAmanitiesName" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtUnitTypeName"
                                                                Display="Dynamic"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                    <td class="isrequire">
                                                        <asp:Label ID="lbltpUnitTypeCode" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtUnitTypeCode" SkinID="searchtextbox" runat="server" MaxLength="7"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvUnitTypeCode" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtUnitTypeCode"
                                                                Display="Dynamic"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 15px 0px 0px 0px;" colspan="4">
                                                        <b>Room Specifications</b>
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litSBA" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSBA" SkinID="searchtextbox" runat="server" MaxLength="7"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftSBA" runat="server" FilterMode="ValidChars" ValidChars="0123456789."
                                                            TargetControlID="txtSBA">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <asp:RegularExpressionValidator Display="Dynamic" ID="revSBA" runat="server" ForeColor="Red"
                                                            ControlToValidate="txtSBA" SetFocusOnError="true" ValidationExpression="^\d{0,18}(\.\d{0,2})?$"
                                                            ValidationGroup="IsRequire">
                                                        </asp:RegularExpressionValidator>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litCarpetArea" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCarpetArea" SkinID="searchtextbox" runat="server" MaxLength="7"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftCarpetArea" runat="server" FilterMode="ValidChars"
                                                            ValidChars="0123456789." TargetControlID="txtCarpetArea">
                                                        </ajx:FilteredTextBoxExtender>
                                                        <asp:RegularExpressionValidator Display="Dynamic" ID="revCarpetArea" runat="server"
                                                            ForeColor="Red" ControlToValidate="txtCarpetArea" SetFocusOnError="true" ValidationExpression="^\d{0,18}(\.\d{0,2})?$"
                                                            ValidationGroup="IsRequire">
                                                        </asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litMaxAdult" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMaxAdult" SkinID="searchtextbox" MaxLength="8" runat="server"
                                                            Style="width: 60px; text-align: right;"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftMaxAdult" runat="server" TargetControlID="txtMaxAdult"
                                                            FilterType="Numbers" />
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litMaxChild" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtMaxChild" SkinID="searchtextbox" MaxLength="8" runat="server"
                                                            Style="width: 60px; text-align: right;"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftMaxChild" runat="server" TargetControlID="txtMaxChild"
                                                            FilterType="Numbers" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litNoOfBeds" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNoOfBeds" SkinID="searchtextbox" runat="server" MaxLength="7"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftNoOfBeds" runat="server" FilterType="Numbers"
                                                            TargetControlID="txtNoOfBeds">
                                                        </ajx:FilteredTextBoxExtender>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litBedSize" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBedSize" SkinID="searchtextbox" runat="server" MaxLength="250"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkExtraBedAllowed" runat="server" OnCheckedChanged="chkExtraBedAllowed_CheckedChanged"
                                                            AutoPostBack="true" />
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="txtExtraBed" SkinID="searchtextbox" Enabled="false" Style="width: 60px;
                                                            text-align: right;" runat="server" MaxLength="8"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftExtraBed" runat="server" TargetControlID="txtExtraBed"
                                                            FilterType="Numbers" Enabled="True" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 10px;" colspan="4">
                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td width="49%" style="padding-bottom: 5px;">
                                                                    <b>Room Amenities</b>
                                                                </td>
                                                                <td width="1%">
                                                                    &nbsp;
                                                                </td>
                                                                <td width="50%" style="padding-bottom: 5px;">
                                                                    <b>Complementory Services</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="content_checkbox">
                                                                    <div style="height: 75px; overflow: auto; border: 1px solid Gray;" class="checkbox_new">
                                                                        <asp:CheckBoxList ID="chkAmenitiesList" RepeatColumns="3" RepeatDirection="Horizontal"
                                                                            runat="server" Width="100%">
                                                                        </asp:CheckBoxList>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td class="content_checkbox">
                                                                    <div style="height: 75px; overflow: auto; border: 1px solid Gray;" class="checkbox_new">
                                                                        <asp:CheckBoxList ID="chkComplementoryServices" RepeatColumns="3" RepeatDirection="Horizontal"
                                                                            runat="server" Width="100%">
                                                                        </asp:CheckBoxList>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="tr10" runat="server" visible="false">
                                                    <td class="lblsameasth" width="150px">
                                                        &nbsp;
                                                    </td>
                                                    <td width="280px">
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAmenitiesList" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                </tr>
                                                <tr>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="tr3" runat="server" visible="false">
                                                    <th colspan="3" style="text-align: left;">
                                                        <asp:Literal ID="litReservationInformation" runat="server"></asp:Literal>
                                                        <hr />
                                                    </th>
                                                </tr>
                                                <tr id="tr4" runat="server" visible="false">
                                                    <td class="isrequire">
                                                        <asp:Literal ID="litRackRate" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRackRate" SkinID="searchtextbox" MaxLength="15" runat="server"
                                                            Style="text-align: right;"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvRackRate" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtRackRate" Display="Dynamic"></asp:RequiredFieldValidator></span>
                                                        <ajx:FilteredTextBoxExtender ID="flRackRate" runat="server" TargetControlID="txtRackRate"
                                                            FilterType="Custom, Numbers" ValidChars="." />
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litMinNight" runat="server"></asp:Literal>
                                                        <asp:TextBox ID="txtMinNight" SkinID="searchtextbox" MaxLength="8" runat="server"
                                                            Style="width: 60px; text-align: right;"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftMinNight" runat="server" TargetControlID="txtMinNight"
                                                            FilterType="Numbers" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Literal ID="litMaxNight" runat="server"></asp:Literal>
                                                        <asp:TextBox ID="txtMaxNight" SkinID="searchtextbox" runat="server" MaxLength="8"
                                                            Style="width: 60px; text-align: right;"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftMaxNight" runat="server" TargetControlID="txtMaxNight"
                                                            FilterType="Numbers" />
                                                        &nbsp;&nbsp;&nbsp;<asp:Literal ID="litNight" runat="server"></asp:Literal>
                                                        <asp:CompareValidator ID="cmpRackRate" runat="server" Display="Dynamic" ControlToCompare="txtMinNight"
                                                            ControlToValidate="txtMaxNight" Type="Double" ValidationGroup="IsRequire" Operator="GreaterThanEqual"
                                                            ForeColor="Red"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr id="tr5" runat="server" visible="false">
                                                    <td>
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:RegularExpressionValidator ID="revRackRate" SetFocusOnError="True" runat="server"
                                                            ValidationGroup="IsRequire" ControlToValidate="txtRackRate" ValidationExpression="^\d{0,18}(\.\d{0,2})?$"
                                                            Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr id="tr6" runat="server" visible="false">
                                                    <td>
                                                        <asp:Literal ID="litCRLimit" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCRLimit" SkinID="searchtextbox" Style="text-align: right;" MaxLength="15"
                                                            runat="server"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftCRLimit" runat="server" TargetControlID="txtCRLimit"
                                                            FilterType="Custom, Numbers" ValidChars="." />
                                                    </td>
                                                    <td>
                                                        <%--<asp:Literal ID="litMaxAdult" runat="server"></asp:Literal>
                                                        <asp:TextBox ID="txtMaxAdult" SkinID="searchtextbox" MaxLength="8" runat="server"
                                                            Style="width: 60px; text-align: right;"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftMaxAdult" runat="server" TargetControlID="txtMaxAdult"
                                                            FilterType="Numbers" />
                                                        &nbsp;&nbsp;&nbsp;
                                                        <asp:Literal ID="litMaxChild" runat="server"></asp:Literal>
                                                        <asp:TextBox ID="txtMaxChild" SkinID="searchtextbox" MaxLength="8" runat="server"
                                                            Style="width: 60px; text-align: right;"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftMaxChild" runat="server" TargetControlID="txtMaxChild"
                                                            FilterType="Numbers" />--%>
                                                    </td>
                                                </tr>
                                                <tr id="tr7" runat="server" visible="false">
                                                    <td>
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:RegularExpressionValidator ID="revCRLimit" SetFocusOnError="True" runat="server"
                                                            ValidationGroup="IsRequire" ValidationExpression="^\d{0,18}(\.\d{0,2})?$" ControlToValidate="txtCRLimit"
                                                            Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr id="trOverBookingToHie" runat="server" visible="false">
                                                    <td class="checkbox_new">
                                                        <asp:CheckBox ID="chkOverBooking" Text="Overbooking" runat="server" onclick="fnRequireValidationForCheckBox();" />
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlOverBooking" SkinID="searchddl" runat="server" Style="width: 75px;
                                                            float: left;">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvddlOverBooking" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                            runat="server" ValidationGroup="IsRequire" ControlToValidate="ddlOverBooking"
                                                            Display="Dynamic" EnableClientScript="true" InitialValue="00000000-0000-0000-0000-000000000000"
                                                            Style="float: left; padding-bottom: 16px;"></asp:RequiredFieldValidator>
                                                        <asp:TextBox ID="txtOverBooking" runat="server" MaxLength="15" Style="width: 62px;
                                                            float: left; text-align: right; margin-left: 15px;" onchange="fnChangeMessage();"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftOverBooking" runat="server" TargetControlID="txtOverBooking"
                                                            FilterType="Custom, Numbers" ValidChars="." />
                                                        <span style="float: left;">
                                                            <asp:RequiredFieldValidator ID="rfvtxtOverBooking" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtOverBooking"
                                                                Display="Dynamic" EnableClientScript="true"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="revOverBooking" SetFocusOnError="True" runat="server"
                                                                ValidationGroup="IsRequire" ControlToValidate="txtOverBooking" ValidationExpression="^\d{0,18}(\.\d{0,2})?$"
                                                                Display="Dynamic" ForeColor="Red" EnableClientScript="true" Style="float: left;
                                                                margin-left: 20px;"></asp:RegularExpressionValidator>
                                                            <asp:Label ID="lblOverBooking" runat="server" ForeColor="Red" Style="display: none;
                                                                margin-left: 20px; float: left; vertical-align: top;"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr id="tr1" runat="server" visible="false">
                                                    <td colspan="3" class="checkbox_new">
                                                        <asp:CheckBox ID="chkIsdiscountApplicable" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr id="tr2" runat="server" visible="false">
                                                    <td colspan="3" class="checkbox_new">
                                                        <asp:CheckBox ID="chkIsavailableCRS" Width="150px" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr id="trDepositToHie" runat="server" visible="false">
                                                    <td class="checkbox_new" colspan="3" style="height: 250px; overflow: auto; vertical-align: top;">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litDeposit" runat="server"></asp:Literal></span></div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvDepositList" runat="server" SkinID="gvNoPaging" AutoGenerateColumns="False"
                                                                Width="100%" OnRowDataBound="gvDepositList_RowDataBound" DataKeyNames="DepositID,IsFlat">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkDepositList" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrDeposit" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvDDepositName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DepositName")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRate" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvDepositRate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DepositRate")%>'></asp:Label>
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
                                                <tr>
                                                    <td colspan="3">
                                                        <div style="float: right; width: auto; display: inline-block;">
                                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" ImageUrl="~/images/cancle.png"
                                                                Style="float: right; margin-left: 5px;" OnClick="btnCancel_Click" />
                                                            <asp:Button ID="btnSave" runat="server" ImageUrl="~/images/save.png" Style="float: right;
                                                                margin-left: 5px;" ValidationGroup="IsRequire" OnClick="btnSave_Click" OnClientClick="return fncheck();" />
                                                            <asp:Button ID="btnBackToList" runat="server" CausesValidation="False" ImageUrl="~/images/cancle.png"
                                                                Style="float: right; margin-left: 5px;" OnClick="btnBackToList_Click" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="tabs-2">
                                            <asp:UpdatePanel ID="updPhoto" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <table cellpadding="2" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td>
                                                                <%if (IsListMessageForGallary)
                                                                  { %>
                                                                <div class="message finalsuccess">
                                                                    <p>
                                                                        <strong>
                                                                            <asp:Literal ID="ltrListMessageGallary" runat="server"></asp:Literal></strong>
                                                                    </p>
                                                                </div>
                                                                <%}%>
                                                            </td>
                                                        </tr>
                                                        <tr id="trPhoto" runat="server">
                                                            <td>
                                                                <div style="float: left; width: 250px;">
                                                                    <div id='browse_file' style="float: left; padding-right: 25px;">
                                                                        <asp:FileUpload ID="fuRoomPhoto" runat="server" class="multi" onchange="fnClearMessage();" />
                                                                    </div>
                                                                    <div style="float: left;">
                                                                        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" OnClientClick="return postbackButtonClick();" />
                                                                    </div>
                                                                    <br />
                                                                    <br />
                                                                    <asp:Label ID="lblSelectFileForRG" Style="font-size: 14px; color: Red; margin-left: 10px;"
                                                                        runat="server"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <hr />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DataList ID="dtlstRoomTypeGallary" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                                                    RepeatLayout="Table" OnItemCommand="dtlstRoomTypeGallary_ItemCommand" DataKeyField="DocumentName"
                                                                    OnItemDataBound="dtlstRoomTypeGallary_ItemDataBound">
                                                                    <ItemTemplate>
                                                                        <a rel="example_group" id="aLinkImage" runat="server" style="height: 125px; width: 100px;
                                                                            padding-right: 25px;" href='<%#GetImage(DataBinder.Eval(Container.DataItem, "DocumentName"))%>'>
                                                                            <img id="imgOfGallary" alt="" runat="server" style="height: 150px; width: 125px;
                                                                                padding-right: -25px;" src='<%#GetImage(DataBinder.Eval(Container.DataItem, "DocumentName"))%>' /></a>
                                                                        <br />
                                                                        <div style="text-align: center; border: 0px;">
                                                                            <asp:LinkButton ID="lnkRommGallaryDelete" runat="server" CommandName="DELETEPHOTO"
                                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem, "DocumentID")%>' OnClientClick="return postbackButtonClick();"
                                                                                OnDataBinding="lnkRommGallaryDelete_DataBinding"><img style="border:0 !important; text-align:center; margin-left:-25px;" border="0" src="../../images/delete.png" /></asp:LinkButton>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:DataList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="btnUpload" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </td>
                            <td class="boxright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #fff;">
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
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSave" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updRoomType" ID="UpdateProgressRoomType"
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
