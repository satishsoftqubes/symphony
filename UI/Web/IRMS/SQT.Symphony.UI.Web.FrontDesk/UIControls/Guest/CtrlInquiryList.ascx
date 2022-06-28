<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInquiryList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest.CtrlInquiryList" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%--<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>--%>
<script src="../../Scripts/Common.js" type="text/javascript"></script>
<script src="../../Scripts/jquery-1.8.2.js"></script>
<script src="../../Scripts/jquery-ui.js"></script>
<script type="text/javascript" language="javascript">
    function pageLoad(sender, args) {
        var v1 = '<%=ConfigurationManager.AppSettings["IsUpperCase"].ToString() %>'
        if (v1 == "1") {
            $('input[type="text"],textarea').each(function () { $(this).css("text-transform", "uppercase") });
        }
    }
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
    function fnCheckSearchDate() {
        if (Page_ClientValidate("IsSearchInq")) {
            document.getElementById('errormessage').style.display = "block";
            var varDateFrom = document.getElementById('<%= txtSearchInqGuestarrivalDate.ClientID %>').value;
            var varDateTo = document.getElementById('<%= txtSearchInqGuestDeptDate.ClientID %>').value;
            if (varDateFrom != '' && varDateTo != '') {

                var dateFormat = document.getElementById('<%= hfDateFormat.ClientID %>').value;
                var dateFrom = fnGetValidDateFormat(varDateFrom, dateFormat);
                var dateTo = fnGetValidDateFormat(varDateTo, dateFormat);

                dateFrom = Date.parse(dateFrom, 'MM/dd/yyyy');
                dateTo = Date.parse(dateTo, 'MM/dd/yyyy');

                if (varDateFrom > varDateTo) {
                    $find('mpeDateInquiryMessage').show();
                    return false;
                }
                else {
                    return true;
                }
            }
            else {
                return true;
            }
        }
    }
    function fnCheckUpdateDate() {
        if (Page_ClientValidate("InquiryDataEdit")) {
            document.getElementById('errormessage').style.display = "block";
            var varDateFrom = document.getElementById('<%= txtEditInqArrivalDate.ClientID %>').value;
            var varDateTo = document.getElementById('<%= txtEditInqDeptDate.ClientID %>').value;
            alert(varDateTo);
            alert(varDateFrom);
            if (varDateFrom != '' && varDateTo != '') {

                var dateFormat = document.getElementById('<%= hfDateFormat.ClientID %>').value;
                var dateFrom = fnGetValidDateFormat(varDateFrom, dateFormat);
                var dateTo = fnGetValidDateFormat(varDateTo, dateFormat);
                dateFrom = Date.parse(dateFrom, 'MM/dd/yyyy');
                dateTo = Date.parse(dateTo, 'MM/dd/yyyy');
                if (varDateFrom > varDateTo) {
                    $find('mpeDateInquiryMessage').show();
                    return false;
                }
                else {
                    return true;
                }
            }
            else {
                return true;
            }
        }
    }

</script>
<asp:UpdatePanel ID="updInquiryList" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hfDateFormat" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litInquiryList" runat="server" Text="Inquiry List"></asp:Literal>
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
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td>
                                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                    <tr>
                                                        <td width="50px">
                                                            <asp:Literal ID="litSearchInqGuestName" runat="server" Text="Name"></asp:Literal>
                                                        </td>
                                                        <td width="170px">
                                                            <asp:TextBox ID="txtSearchInqGuestName" runat="server" Style="width: 140px !important;"
                                                                SkinID="searchtextbox"></asp:TextBox>
                                                        </td>
                                                        <td width="65px">
                                                            <asp:Literal ID="litSearchInqGuestMobile" runat="server" Text="Mobile No."></asp:Literal>
                                                        </td>
                                                        <td width="170px">
                                                            <asp:TextBox ID="txtSearchInqMobileNo" runat="server" Style="width: 140px !important;"
                                                                SkinID="searchtextbox"></asp:TextBox>
                                                        </td>
                                                        <td width="65px">
                                                            <asp:Literal ID="litSearchInqGuestMEmail" runat="server" Text="Email"></asp:Literal>
                                                        </td>
                                                        <td width="170px">
                                                            <asp:TextBox ID="txtSearchInqGuestEmail" runat="server" Style="width: 140px !important;"
                                                                SkinID="searchtextbox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 60px;">
                                                            <asp:Literal ID="litSearchInqGuestarrivalDate" Text="Arrival Date" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSearchInqGuestarrivalDate" Width="100px" runat="server" SkinID="nowidth"
                                                                onkeydown="return stopKey(event);"></asp:TextBox>
                                                            <asp:Image ID="imgCalInqGuestarrivalDate" ToolTip="Choose Arrival Date" CssClass="small_img"
                                                                runat="server" ImageUrl="~/images/CalanderIcon.png" Height="20px" Width="20px" />
                                                            <ajx:CalendarExtender ID="calInqGuestarrivalDate" PopupButtonID="imgCalInqGuestarrivalDate"
                                                                TargetControlID="txtSearchInqGuestarrivalDate" runat="server">
                                                            </ajx:CalendarExtender>
                                                            <img src="../../images/clear.png" title="Clear Date" id="imgClearDate" style="vertical-align: middle;"
                                                                onclick="fnClearDate('<%= txtSearchInqGuestarrivalDate.ClientID %>');" />
                                                        </td>
                                                        <td style="width: 65px;">
                                                            <asp:Literal ID="litSearchInqGuestDeptDate" Text="Departure Date" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSearchInqGuestDeptDate" runat="server" SkinID="nowidth" Width="100px"
                                                                onkeydown="return stopKey(event);"></asp:TextBox>
                                                            <asp:Image ID="imgCalSearchInqGuestDeptDate" ToolTip="Choose Departure Date" CssClass="small_img"
                                                                runat="server" ImageUrl="~/images/CalanderIcon.png" Height="20px" Width="20px" />
                                                            <ajx:CalendarExtender ID="calSearchInqGuestDeptDate" PopupButtonID="imgCalSearchInqGuestDeptDate"
                                                                TargetControlID="txtSearchInqGuestDeptDate" runat="server">
                                                            </ajx:CalendarExtender>
                                                            <img src="../../images/clear.png" title="Clear Date" id="imgClearSearchInqGuestDeptDate"
                                                                style="vertical-align: middle;" onclick="fnClearDate('<%= txtSearchInqGuestDeptDate.ClientID %>');" />
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litSearchInqStatus" Text="Inquiry Status" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlSearchInqGuestStatus" runat="server" Style="width: 80px;
                                                                height: 25px;">
                                                                <asp:ListItem Selected="True" Text="-ALL-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                <asp:ListItem Text="Inquiry" Value="Inquiry"></asp:ListItem>
                                                                <asp:ListItem Text="Wait list" Value="Wait list"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:ImageButton ID="imtbtnSearchInquiry" ToolTip="Search" runat="server" ImageUrl="~/images/search-icon.png"
                                                                Style="border: 0px; vertical-align: middle; display: inline" OnClick="imtbtnSearchInquiry_Click"
                                                                ValidationGroup="IsSearchInq" OnClientClick="return fnCheckSearchDate();" />
                                                            <asp:ImageButton ID="imtbtnSearchClearInquiry" ToolTip="Reset" runat="server" ImageUrl="~/images/clearsearch.png"
                                                                Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClientClick="fnDisplayCatchErrorMessage();"
                                                                OnClick="imtbtnSearchClearInquiry_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; height: 200px; overflow: auto;" colspan="8">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="vertical-align: top;">
                                                            <div class="box_head">
                                                                <span>
                                                                    <asp:Literal ID="litInquiryListGrid" runat="server" Text="Inquiry List"></asp:Literal>
                                                                </span>
                                                            </div>
                                                            <div class="clear">
                                                            </div>
                                                            <div class="box_content">
                                                                <asp:GridView ID="gvInquiryList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                    Width="100%" OnRowCommand="gvInquiryList_RowCommand" OnRowDataBound="gvInquiryList_RowDataBound"
                                                                    OnPageIndexChanging="gvInquiryList_PageIndexChanging">
                                                                    <Columns>
                                                                        <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrInqSrNo" runat="server" Text="No."></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1 %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrInqGuestName" runat="server" Text="Name"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGvInqGuestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'></asp:Label>
                                                                                <%--<asp:LinkButton ID="lnkInqGuestName" runat="server" CommandName="VIEWINQDATA" CommandArgument='<%#Eval("Gender") + "," +Eval("CreatedOn")%>'
                                                                                    Text=' <%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'></asp:LinkButton>--%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrGuestEmail" runat="server" Text="Email"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Email")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrInqGuestMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Phone")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="95px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrInqStatus" runat="server" Text="Status"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Inq_StatusTerm")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrInqArrivalDate" runat="server" Text="Arrival date"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGvInqArrivalDate" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrInqDeptlDate" runat="server" Text="Dept. date"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGvInqDeptlDate" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrInqCreatedDate" runat="server" Text="Inq. On"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGvInqCreatedDate" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblInqActions" runat="server" Text="Action"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPopUp" runat="server" Text="Actions"></asp:Label>
                                                                                <ajx:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lblPopUp"
                                                                                    PopupControlID="Panel2" PopupPosition="Left">
                                                                                </ajx:HoverMenuExtender>
                                                                                <asp:Panel ID="Panel2" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                                    <div class="actionsbuttons_hovermenu">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                                            <tr>
                                                                                                <td class="actionsbuttons_hover_lettmenu">
                                                                                                </td>
                                                                                                <td class="actionsbuttons_hover_centermenu">
                                                                                                    <ul>
                                                                                                        <li>
                                                                                                            <asp:LinkButton Style="background: none !important; border: none;" ID="lnkViewInqData"
                                                                                                                runat="server" ToolTip="View" CommandName="VIEWINQDATA" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InqID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                        </li>
                                                                                                        <li>
                                                                                                            <asp:LinkButton Style="background: none !important; border: none;" ID="lnkInqEdit"
                                                                                                                runat="server" ToolTip="Edit" CommandName="EDITINQDATA" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InqID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                        </li>
                                                                                                        <li>
                                                                                                            <asp:LinkButton Style="background: none !important; border: none;" ID="lnkMakeReservationFromInq"
                                                                                                                runat="server" ToolTip="Make reservation" CommandName="MAKERESERVATION" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InqID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                        </li>
                                                                                                        <li>
                                                                                                            <asp:LinkButton Style="background: none !important; border: none;" ID="lnkSendEmailToGuest"
                                                                                                                runat="server" ToolTip="Send Email To Guest" CommandName="SENDEMAILTOGUEST" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InqID")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                        </li>
                                                                                                    </ul>
                                                                                                </td>
                                                                                                <td class="actionsbuttons_hover_rightmenu">
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </asp:Panel>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <div style="padding: 10px;">
                                                                            <b>
                                                                                <asp:Label ID="lblNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                            </b>
                                                                        </div>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
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
        <ajx:ModalPopupExtender ID="mpeEditInquiryData" runat="server" TargetControlID="hdnEditInquiryData"
            PopupControlID="pnlEditInquiryData" BackgroundCssClass="mod_background" CancelControlID="imgEditInquiryClose">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnEditInquiryData" runat="server" />
        <asp:Panel ID="pnlEditInquiryData" runat="server" Width="600px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="litEditEnquiryHeader" runat="server" Text="Inquiry"></asp:Literal>
                        </span>
                    </div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="imgEditInquiryClose" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td colspan="2">
                                <div style="text-align: right;">
                                    <b>
                                        <asp:Label ID="lblEditInqCurrentTime" runat="server"></asp:Label></b>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="litDateValidationmsg" Visible="false" ForeColor="Red" runat="server"
                                    Text="Departure date must be greater than Arrival date"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trForInqCreatedBy" runat="server" visible="false">
                            <td class="isrequire">
                                <asp:Label ID="lblInqCreatedBy" runat="server" Text="Inq. Created By"></asp:Label></b>
                            </td>
                            <td>
                                <asp:Label ID="lblDispInqCreatedBy" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" style="vertical-align: top;">
                                <asp:Literal ID="litEditInqStatus" runat="server" Text="Status"></asp:Literal>
                            </td>
                            <td>
                                <asp:RadioButtonList runat="server" ID="rblEditInquiryStatus" RepeatColumns="3" RepeatDirection="Horizontal"
                                    AutoPostBack="true" OnSelectedIndexChanged="rblEditInquiryStatus_SelectedIndexChanged">
                                    <asp:ListItem Text="Inquiry" Value="Inquiry" Selected="true"></asp:ListItem>
                                    <asp:ListItem Text="Wait List" Value="Wait List"></asp:ListItem>
                                    <asp:ListItem Text="Email Database" Value="Email Database"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr id="trMarketingValue" runat="server" visible="false">
                            <td style="vertical-align: top; width: 113px !important;">
                                <asp:Literal ID="litMarketingValueStatus" runat="server" Text="Marketing Category"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMarketingValueStatus" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" style="width: 80px !important;">
                                <asp:Literal ID="litEditInqGuestName" runat="server" Text="Name"></asp:Literal>
                            </td>
                            <td>
                                <div style="float: left;">
                                    <asp:DropDownList ID="ddlEditInqGuestTitle" runat="server" Style="width: 80px; height: 25px;">
                                        <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                        <asp:ListItem Text="Mr." Value="Mr."></asp:ListItem>
                                        <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                                        <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                                    </asp:DropDownList>
                                    <span>
                                        <asp:RequiredFieldValidator ID="rvfEditInqGuestTitle" InitialValue="00000000-0000-0000-0000-000000000000"
                                            SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                            ValidationGroup="InquiryDataEdit" ControlToValidate="ddlEditInqGuestTitle" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </span>
                                    <asp:TextBox ID="txtEditInqGuestFirstName" runat="server" MaxLength="150" Style="width: 120px !important;"></asp:TextBox>
                                    <ajx:TextBoxWatermarkExtender ID="txtEditwmeInqGuestFName" runat="server" TargetControlID="txtEditInqGuestFirstName"
                                        WatermarkText="First Name">
                                    </ajx:TextBoxWatermarkExtender>
                                    <span>
                                        <asp:RequiredFieldValidator ID="rvfEditInqGuestFirstName" SetFocusOnError="true"
                                            CssClass="input-notification error png_bg" runat="server" ValidationGroup="InquiryDataEdit"
                                            ControlToValidate="txtEditInqGuestFirstName" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </span>
                                    <asp:TextBox ID="txtEditInqGuestLastName" runat="server" MaxLength="150" Style="width: 120px !important;"></asp:TextBox>
                                    <ajx:TextBoxWatermarkExtender ID="txtEditwmeInqGuestLastName" runat="server" TargetControlID="txtEditInqGuestLastName"
                                        WatermarkText="Last Name">
                                    </ajx:TextBoxWatermarkExtender>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litEditInqGuestMobile" runat="server" Text="Mobile No."></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditInqGuestCode" runat="server" Text="+91" Style="width: 30px !important;"></asp:TextBox>
                                <asp:TextBox ID="txtEditInqGuestMobile" Style="width: 190px;" runat="server" MaxLength="16"></asp:TextBox>
                                <ajx:FilteredTextBoxExtender ID="ftEditInqGuestMobile" runat="server" TargetControlID="txtEditInqGuestMobile"
                                    ValidChars="0123456789" FilterMode="ValidChars">
                                </ajx:FilteredTextBoxExtender>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvEditInqGuestMobile" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="InquiryDataEdit" ControlToValidate="txtEditInqGuestMobile"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litEditInqGuestGuestEmail" runat="server" Text="Email"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditInqGuestEmail" runat="server"></asp:TextBox>
                                <span>
                                    <asp:RegularExpressionValidator ID="revEditInqGuestEmail" Display="Dynamic" ValidationGroup="InquiryDataEdit"
                                        runat="server" ErrorMessage="Please Enter Valid Email" ForeColor="Red" ControlToValidate="txtEditInqGuestEmail"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litEditInqGuestGender" runat="server" Text="Gender"></asp:Literal>
                            </td>
                            <td>
                                <asp:RadioButtonList runat="server" ID="rblEditInqGuestGender" RepeatColumns="3"
                                    RepeatDirection="Horizontal">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litEditInqGuestCompanyName" runat="server" Text="Company Name"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditInqGuestCompanyName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" align="left" style="vertical-align: top;" runat="server" id="tdArrivalDateEdit">
                                <asp:Literal ID="litEditInqArrivalDate" runat="server" Text="Arrival Date"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditInqArrivalDate" Width="180px" SkinID="nowidth" runat="server"
                                    onkeydown="return stopKey(event);"></asp:TextBox>
                                <asp:Image ID="imbEditInqArrivalDate" ToolTip="Choose Date" CssClass="small_img"
                                    runat="server" ImageUrl="~/images/CalanderIcon.png" Height="20px" Width="20px" />
                                <ajx:CalendarExtender ID="calEditInqArrivalDate" Format="dd-MM-yyyy" PopupButtonID="imbEditInqArrivalDate"
                                    TargetControlID="txtEditInqArrivalDate" runat="server">
                                </ajx:CalendarExtender>
                                <img src="../../images/clear.png" id="img1" title="Clear Date" style="vertical-align: middle;"
                                    onclick="fnClearDate('<%= txtEditInqArrivalDate.ClientID %>');" />
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvEditInqArrivalDate" runat="server" ControlToValidate="txtEditInqArrivalDate"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="InquiryDataEdit">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" style="vertical-align: top;" runat="server" id="tdDeptDateEdit">
                                <asp:Literal ID="litEditInqDeptDate" runat="server" Text="Departure Date"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEditInqDeptDate" Width="180px" SkinID="nowidth" runat="server"
                                    onkeydown="return stopKey(event);"></asp:TextBox>
                                <asp:Image ID="imbEditInqDeptDate" ToolTip="Choose Date" CssClass="small_img" runat="server"
                                    ImageUrl="~/images/CalanderIcon.png" Height="20px" Width="20px" />
                                <ajx:CalendarExtender ID="calEditEndDate" Format="dd-MM-yyyy" runat="server" PopupButtonID="imbEditInqDeptDate"
                                    TargetControlID="txtEditInqDeptDate">
                                </ajx:CalendarExtender>
                                <img src="../../images/clear.png" title="Clear Date" id="img2" style="vertical-align: middle;"
                                    onclick="fnClearDate('<%= txtEditInqDeptDate.ClientID %>');" />
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvEditInqDeptDate" runat="server" ControlToValidate="txtEditInqDeptDate"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="InquiryDataEdit">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <div style="display: inline-block;">
                                    <asp:Button ID="btnUpdateInquiry" runat="server" CausesValidation="true" Text="Save"
                                        ImageUrl="~/images/save.png" OnClick="btnUpdateInquiry_Click" Style="float: right;
                                        margin-left: 5px;" ValidationGroup="InquiryDataEdit" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeDateInquiryMessage" runat="server" TargetControlID="hfDateMessage"
            PopupControlID="pnlDateMessage" BackgroundCssClass="mod_background" CancelControlID="btnDateMessageOK"
            BehaviorID="mpeDateInquiryMessage">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfDateMessage" runat="server" />
        <asp:Panel ID="pnlDateMessage" runat="server" Width="350px">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderDateValidate" Text="Message" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="ltrMsgDateValidate" Text="Departure date must be greater than Arrival date."
                                    runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnDateMessageOK" Text="Ok" runat="server" Style="display: inline;
                                    padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeSendEmailToGuest" runat="server" TargetControlID="hdnSendEmailToGuest"
            PopupControlID="pnlSendEmailToGuest" BackgroundCssClass="mod_background" CancelControlID="imgCloseEmailSendToGuest"
            BehaviorID="mpeSendEmailToGuest">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnSendEmailToGuest" runat="server" />
        <asp:Panel ID="pnlSendEmailToGuest" runat="server" Width="950px" Height="350">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="litHeaderSendEmailToGuest" Text="Send Email To Guest" runat="server"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="imgCloseEmailSendToGuest" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>
                                <%--<CKEditor:CKEditorControl ID="ckEmailSendToGuest" runat="server">
                                </CKEditor:CKEditorControl>--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnSendEmailToGuest" Text="Send Email" runat="server" Style="display: inline;
                                    padding-right: 10px;" OnClick="btnSendEmailToGuest_Click" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updInquiryList" ID="UpdateInquiryList"
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
