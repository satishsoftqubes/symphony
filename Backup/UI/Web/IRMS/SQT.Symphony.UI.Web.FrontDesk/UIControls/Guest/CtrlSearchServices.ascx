<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSearchServices.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest.CtrlSearchServices" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<style type="text/css">
    .style1
    {
        width: 73px;
    }
    .style2
    {
        width: 71px;
    }
</style>
<script src="../../Scripts/Common.js" type="text/javascript"></script>
<script src="../../Scripts/jquery-1.8.2.js"></script>
<script src="../../Scripts/jquery-ui.js"></script>
<script type="text/javascript" language="javascript">

    function fnClearDate1(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function stopKey(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 8) && (node.type == "text")) { return false; }
        else if ((evt.keyCode == 9) && (node.type == "text")) { return true; }
        else if ((evt.keyCode == 46) && (node.type == "text")) { return false; }
        else { return false; }
    }
    //    function AddServicesValidate() {
    //        if (Page_ClientValidate("IsRequire")) {
    //            document.getElementById('errormessage').style.display = "block";
    //            var varDateValidationFlag = true;
    //            var varServiceName = document.getElementById('<%= ddlSearchServices.ClientID %>').value;
    //            var varDateFrom = document.getElementById('<%= txtStartDate.ClientID %>').value;
    //            var varDateTo = document.getElementById('<%= txtExpiryDate.ClientID %>').value;
    //            if (varDateFrom != '' && varDateTo != '') {
    //                var dateFormat = document.getElementById('<%= hfDateFormat.ClientID %>').value;

    //                var dateFrom = fnGetValidDateFormat(varDateFrom, dateFormat);
    //                var dateTo = fnGetValidDateFormat(varDateTo, dateFormat);

    //                dateFrom = Date.parse(dateFrom, 'MM/dd/yyyy');
    //                dateTo = Date.parse(dateTo, 'MM/dd/yyyy');

    //                if (varDateFrom < varDateTo) {
    //                    varDateValidationFlag = false;
    //                }
    //                else {
    //                    varDateValidationFlag = true;
    //                }
    //            }
    //            else {
    //                varDateValidationFlag = true;
    //            }
    //        }
    //    }


    function fnCheckSearchDate() {
        if (Page_ClientValidate("IsRequire")) {
            document.getElementById('errormessage').style.display = "block";
            var varDateFrom = document.getElementById('<%= txtStartDate.ClientID %>').value;
            var varDateTo = document.getElementById('<%= txtExpiryDate.ClientID %>').value;
            if (varDateFrom != '' && varDateTo != '') {

                var dateFormat = document.getElementById('<%= hfDateFormat.ClientID %>').value;
                var dateFrom = fnGetValidDateFormat(varDateFrom, dateFormat);
                var dateTo = fnGetValidDateFormat(varDateTo, dateFormat);

                dateFrom = Date.parse(dateFrom, 'MM/dd/yyyy');
                dateTo = Date.parse(dateTo, 'MM/dd/yyyy');

                if (varDateFrom > varDateTo) {
                    $find('mpeDateMessage').show();
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
<asp:UpdatePanel ID="updSearchServices" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hfDateFormat" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="ltrMainHeader" Text="Search Services" runat="server"></asp:Literal>
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
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td class="isrequire" style="width: 60px;">
                                                <asp:Literal ID="litSearchServices" Text="Services" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSearchServices" runat="server" Style="width: 180px;">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="isrequire" style="width: 60px;">
                                                <asp:Literal ID="litStartDate" Text="Start Date" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtStartDate" Width="100px" runat="server" SkinID="nowidth" onkeydown="return stopKey(event);"></asp:TextBox>
                                                <asp:Image ID="imgCalStartDate" ToolTip="Choose Date" CssClass="small_img" runat="server"
                                                    ImageUrl="~/images/CalanderIcon.png" Height="20px" Width="20px" />
                                                <ajx:CalendarExtender ID="calStartDate" PopupButtonID="imgCalStartDate" TargetControlID="txtStartDate"
                                                    runat="server">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" title="Clear Date" id="imgClearDate" style="vertical-align: middle;"
                                                    title="<%= strClearDateTooltip %>" onclick="fnClearDate1('<%= txtStartDate.ClientID %>');" />
                                            </td>
                                            <td class="isrequire" style="width: 65px;">
                                                <asp:Literal ID="litEXpiryDate" Text="Expiry Date" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtExpiryDate" runat="server" SkinID="nowidth" Width="100px" onkeydown="return stopKey(event);"></asp:TextBox>
                                                <asp:Image ID="imgCalExpiryDate" ToolTip="Choose Date" CssClass="small_img" runat="server"
                                                    ImageUrl="~/images/CalanderIcon.png" Height="20px" Width="20px" />
                                                <ajx:CalendarExtender ID="calExpiryDate" PopupButtonID="imgCalExpiryDate" TargetControlID="txtExpiryDate"
                                                    runat="server">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" title="Clear Date" id="img1" style="vertical-align: middle;"
                                                    title="<%= strClearDateTooltip %>" onclick="fnClearDate1('<%= txtExpiryDate.ClientID %>');" />
                                                <asp:ImageButton ID="imtbtnSearchServices" ToolTip="Search" runat="server" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; vertical-align: middle; display: inline" ValidationGroup="IsRequire"
                                                    OnClientClick="return fnCheckSearchDate();" OnClick="imtbtnSearchServices_Click" />
                                                <asp:ImageButton ID="imtbtnSearchClearSearchServices" ToolTip="Reset" runat="server"
                                                    ImageUrl="~/images/clearsearch.png" Style="border: 0px; vertical-align: middle;
                                                    margin: -2px 0 0 10px;" OnClientClick="fnDisplayCatchErrorMessage();" OnClick="imtbtnSearchClearSearchServices_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litSearchServicesList" runat="server" Text="Search Services"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvSearchServicesList" runat="server" AutoGenerateColumns="false"
                                                        ShowHeader="true" Width="100%" OnRowDataBound="gvSearchServicesList_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrReservationNo" runat="server" Text="Booking #"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvReservationNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Name"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvGuestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="130px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrServiceName" runat="server" Text="Service Name"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvServiceName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ItemName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrUnitNo" runat="server" Text="Room No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvRoomNo" runat="server" Text='<%# GetFormatedRoomNumber(Eval("RoomNo")) %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrCheckIn" runat="server" Text="Start Date"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "StartDate", "{0:dd-MM-yyyy}")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrCheckOut" runat="server" Text="Expiry Date"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "ExpiryDate", "{0:dd-MM-yyyy}")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrStatus" runat="server" Text="Status"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvStatus" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div style="padding: 10px;">
                                                                <b>
                                                                    <asp:Label ID="lblNoRecordFound" runat="server" Text="No record found."></asp:Label>
                                                                </b>
                                                            </div>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="6">
                                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="add_content_inner"
                                                    OnClick="btnBack_Click" />
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
        <ajx:ModalPopupExtender ID="mpeDateMessage" runat="server" TargetControlID="hfDateMessage"
            PopupControlID="pnlDateMessage" BackgroundCssClass="mod_background" CancelControlID="btnDateMessageOK"
            BehaviorID="mpeDateMessage">
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
                                <asp:Literal ID="ltrMsgDateValidate" Text="Date from should be less than or equal to Date to."
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
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updSearchServices" ID="UpdateSearchServices"
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
