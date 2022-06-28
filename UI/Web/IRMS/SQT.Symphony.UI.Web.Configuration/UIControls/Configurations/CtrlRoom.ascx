<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRoom.ascx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlRoom" %>
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

        var roomid = document.getElementById('<%=hdnRoomID.ClientID %>').value;
        if (roomid == '' || roomid == 0) {
            $("#tabs").tabs("disable", 1);
        }
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
        document.getElementById('<%=lblSelectFileForRG.ClientID %>').innerHTML = "";
    }

    function CopyKeyNoandExt() {
        document.getElementById('<%=txtKeyNo.ClientID %>').value = document.getElementById('<%=txtUnitNo.ClientID %>').value;        
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnExtraBed() {
        var chkExtraBedAllowed = document.getElementById('<%=chkExtraBedAllowed.ClientID %>');

        if (chkExtraBedAllowed.checked == true) {
            document.getElementById('<%=txtExtraBed.ClientID %>').disabled = false;
        }
        else {
            document.getElementById('<%=txtExtraBed.ClientID %>').value = '0';
            document.getElementById('<%=txtExtraBed.ClientID %>').disabled = true;
        }

    }
</script>
<script language="javascript">

    function SelectTab() {
        window.location.hash = 'tabs-2';
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
    
</script>
<script type="text/javascript">
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("IsRequire")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgressRoom.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
    }
</script>
<asp:UpdatePanel ID="upnlRoom" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnRoomID" runat="server" />
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
                                                <asp:Literal ID="litTabBasicInformation" runat="server"></asp:Literal>
                                            </a></li>
                                            <li><a href="#tabs-2">
                                                <asp:Literal ID="litTabGallary" runat="server"></asp:Literal></a></li>
                                        </ul>
                                        <div id="tabs-1">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td colspan="6">
                                                        <%if (IsListMessage)
                                                          { %>
                                                        <div class="message finalsuccess">
                                                            <p>
                                                                <strong>
                                                                    <asp:Literal ID="ltrListMessageBI" runat="server"></asp:Literal>
                                                                </strong>
                                                            </p>
                                                        </div>
                                                        <%}%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <div style="float: right; padding-bottom: 5px;">
                                                            <b>
                                                                <asp:Literal ID="litGeneralMandartoryFiledMessage" runat="server"></asp:Literal>
                                                            </b>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire" style="width: 110px;">
                                                        <asp:Label ID="lbltpUnitTypeName" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="200px">
                                                        <asp:DropDownList ID="ddlUnitTypeName" SkinID="searchddl" Style="width: 145px;" runat="server"
                                                            OnSelectedIndexChanged="ddlUnitTypeName_SelectedIndexChanged" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvUnitTypeName" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                SetFocusOnError="True" CssClass="input-notification error png_bg" runat="server"
                                                                ValidationGroup="IsRequire" ControlToValidate="ddlUnitTypeName" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                    <td class="isrequire" style="width: 110px;">
                                                        <asp:Label ID="lblBlock" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="200px">
                                                        <asp:DropDownList ID="ddlWing" SkinID="searchddl" Style="width: 145px;" runat="server"
                                                            OnSelectedIndexChanged="ddlWing_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvWing" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                SetFocusOnError="True" CssClass="input-notification error png_bg" runat="server"
                                                                ValidationGroup="IsRequire" ControlToValidate="ddlWing" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                    <td width="110px">
                                                        <asp:Label ID="lblFloor" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlFloor" SkinID="searchddl" Style="width: 145px;" runat="server">
                                                        </asp:DropDownList>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvFloor" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                SetFocusOnError="True" CssClass="input-notification error png_bg" runat="server"
                                                                ValidationGroup="IsRequire" ControlToValidate="ddlFloor" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Label ID="lbltpUnitNo" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtUnitNo" Style="width: 143px;" runat="server" MaxLength="9" onKeyUp="CopyKeyNoandExt();"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvUnitNo" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtUnitNo"></asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbltpKeyNo" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtKeyNo" SkinID="searchtextbox" Style="width: 143px;" runat="server"
                                                            MaxLength="10"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftKeyNo" runat="server" TargetControlID="txtKeyNo"
                                                            FilterType="Numbers" Enabled="True" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbltpExtNo" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtExtNo" SkinID="searchtextbox" Style="width: 143px;" runat="server"
                                                            MaxLength="10"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftExtNo" runat="server" TargetControlID="txtExtNo"
                                                            FilterType="Numbers" Enabled="True" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Label ID="lbltpNoOfBed" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNoOfBed" runat="server" Style="text-align: right; width: 143px;"
                                                            MaxLength="8"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftNoOfBed" runat="server" TargetControlID="txtNoOfBed"
                                                            FilterType="Numbers" Enabled="True" />
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtNoOfBed"></asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                    <td>
                                                        <%--<asp:Label ID="lbltpMaximum" runat="server"></asp:Label>--%>
                                                        <asp:Label ID="lbltpAdult" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAdult" SkinID="searchtextbox" Style="width: 60px; text-align: right;"
                                                            runat="server" MaxLength="8"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="flAdult" runat="server" TargetControlID="txtAdult"
                                                            FilterType="Numbers" Enabled="True" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbltpChild" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtChild" SkinID="searchtextbox" Style="width: 60px; text-align: right;"
                                                            runat="server" MaxLength="8"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="flChild" runat="server" TargetControlID="txtChild"
                                                            FilterType="Numbers" Enabled="True" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkExtraBedAllowed" runat="server" OnCheckedChanged="chkExtraBedAllowed_CheckedChanged"
                                                            AutoPostBack="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtExtraBed" SkinID="searchtextbox" Enabled="false" Style="width: 60px;
                                                            text-align: right;" runat="server" MaxLength="8"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftExtraBed" runat="server" TargetControlID="txtExtraBed"
                                                            FilterType="Numbers" Enabled="True" />
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:CheckBox ID="chkIsavailableCRS" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr id="tr4" runat="server" visible="false">
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td colspan="5" class="checkbox_new">
                                                        <asp:CheckBox ID="chkIsSmokingAllowed" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr id="tr1" runat="server" visible="false">
                                                    <td>
                                                        <asp:Literal ID="litReservationDetail" runat="server"></asp:Literal>
                                                        <asp:Label ID="lbltpStay" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="5">
                                                        <asp:Label ID="lbltpMin" runat="server"></asp:Label>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:TextBox ID="txtMin" SkinID="searchtextbox" Style="width: 60px; text-align: right;"
                                                            runat="server" MaxLength="8"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="flMin" runat="server" TargetControlID="txtMin" FilterType="Numbers"
                                                            Enabled="True" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Label ID="lbltpMax" runat="server"></asp:Label>
                                                        &nbsp;&nbsp;
                                                        <asp:TextBox ID="txtMax" SkinID="searchtextbox" Style="width: 60px; text-align: right;"
                                                            runat="server" MaxLength="8"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="flMax" runat="server" TargetControlID="txtMax" FilterType="Numbers"
                                                            Enabled="True" />
                                                        &nbsp;
                                                        <asp:CompareValidator ID="cmpStay" runat="server" ForeColor="Red" Display="Dynamic"
                                                            ControlToCompare="txtMin" ControlToValidate="txtMax" Type="Double" ValidationGroup="IsRequire"
                                                            Operator="GreaterThanEqual"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr id="tr2" runat="server" visible="false">
                                                    <td colspan="6" class="checkbox_new">
                                                        <asp:CheckBox ID="chkIsDiscountApplicable" Style="vertical-align: middle" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr id="tr3" runat="server" visible="false">
                                                    <td colspan="6" class="checkbox_new">
                                                        <asp:CheckBox ID="chkIsBlockForBooking" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr id="trAmenitiesHeader" visible="false" runat="server">
                                                    <th align="left" colspan="6">
                                                        <asp:Literal ID="litAmenities" runat="server"></asp:Literal>
                                                        <hr />
                                                    </th>
                                                </tr>
                                                <tr id="trAmenities" runat="server" visible="false">
                                                    <td id="Td1" colspan="6" class="checkbox_new" runat="server">
                                                        <div style="height: 125px; overflow: auto;">
                                                            <asp:CheckBoxList ID="chkAmenitiesList" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                                                            </asp:CheckBoxList>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <div style="float: right; width: auto; display: inline-block;">
                                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" ImageUrl="~/images/cancle.png"
                                                                Style="float: right; margin-left: 5px;" OnClick="btnCancel_Click" />
                                                            <asp:Button ID="btnSave" runat="server" ImageUrl="~/images/save.png" Style="float: right;
                                                                margin-left: 5px;" ValidationGroup="IsRequire" OnClick="btnSave_Click" OnClientClick="return postbackButtonClick();" />
                                                            <asp:Button ID="btnBackToList" runat="server" CausesValidation="False" ImageUrl="~/images/cancle.png"
                                                                Style="float: right; margin-left: 5px;" OnClick="btnBackToList_Click" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="tabs-2">
                                            <asp:UpdatePanel ID="updRoomPhoto" runat="server">
                                                <ContentTemplate>
                                                    <table cellpadding="2" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td>
                                                                <%if (IsListMessageForGallary)
                                                                  { %>
                                                                <div class="message finalsuccess">
                                                                    <p style="padding: 0;">
                                                                        <strong>
                                                                            <asp:Literal ID="litMsgForGallary" runat="server"></asp:Literal>
                                                                        </strong>
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
                                                                    <asp:Label ID="lblSelectFileForRG" runat="server" Style="font-size: 14px; color: Red;
                                                                        margin-left: 10px;"></asp:Label>
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
                                                                <asp:DataList ID="dtlstRoomGallary" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                                                    RepeatLayout="Table" OnItemCommand="dtlstRoomGallary_ItemCommand" DataKeyField="DocumentName"
                                                                    OnItemDataBound="dtlstRoomGallary_ItemDataBound">
                                                                    <ItemTemplate>
                                                                        <a rel="example_group" id="aLinkImage" runat="server" style="height: 125px; width: 100px;
                                                                            padding-right: 25px;" href='<%#GetImage(DataBinder.Eval(Container.DataItem, "DocumentName"))%>'>
                                                                            <img id="imgOfGallary" alt="" runat="server" style="height: 150px; width: 125px;
                                                                                padding-right: -25px;" src='<%#GetImage(DataBinder.Eval(Container.DataItem, "DocumentName"))%>' /></a>
                                                                        <br />
                                                                        <div style="text-align: center;">
                                                                            <asp:LinkButton ID="lnkRommGallaryDelete" runat="server" CommandName="DELETEPHOTO"
                                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem, "DocumentID")%>' OnClientClick="return postbackButtonClick();"
                                                                                OnDataBinding="lnkRommGallaryDelete_DataBinding"><img style="border:0 !important; text-align:center; margin-left:-25px;" src="../../images/delete.png" /></asp:LinkButton>
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
<asp:UpdateProgress AssociatedUpdatePanelID="upnlRoom" ID="UpdateProgressRoom" runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
