<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInvestorBooking.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlInvestorBooking" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/CommonControls/CtrCommonInvBookingGuestInfo.ascx"
    TagName="CommonGuestInfo" TagPrefix="uc2" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonAddServices.ascx" TagName="AddServices"
    TagPrefix="ucCtrlAddServices" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonHouseKeeping.ascx" TagName="HouseKeeping"
    TagPrefix="ucCtrlHouseKeeping" %>
<%@ Register Src="../CommonControls/CtrlCommonStayInformation.ascx" TagName="CtrlCommonStayInformation"
    TagPrefix="uc3" %>
<%@ Register Src="../Folio/CtrlCommonAddDeposit.ascx" TagName="CtrlCommonAddDeposit"
    TagPrefix="uc4" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonCheckIn.ascx" TagName="CheckIn"
    TagPrefix="ucCtrlCheckIn" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonOterhInformation.ascx" TagName="CommonOterhInformation"
    TagPrefix="ucCtrlCommonOterhInformation" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonVoucherDetails.ascx" TagName="VoucherDetails"
    TagPrefix="ucCtrlVoucherDetails" %>
<%@ Register Src="~/UIControls/Folio/CtrlDepositList.ascx" TagName="DepositList"
    TagPrefix="ucCtrlDepositList" %>
<script type="text/javascript" language="javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

</script>
<asp:UpdatePanel ID="updRoomReservation" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server" Text="Complimentary Reservation"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                            </td>
                            <td>
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td width="48%" style="vertical-align: top; border-right: 1px solid #ccccce;">
                                                <uc3:CtrlCommonStayInformation ID="CtrlCommonStayInformation1" runat="server" />
                                            </td>
                                            <td style="vertical-align: top;">
                                                <uc2:CommonGuestInfo ID="ucCommonGuestInfo" runat="server" />
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td colspan="2">
                                                <div style="float: left; width: auto; display: inline-block;">
                                                    <asp:Button ID="btnCalRate" runat="server" Style="float: left; margin-left: 5px;"
                                                        Text="Calculate Rate" OnClick="btnCalRate_Click" />
                                                </div>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td colspan="2">
                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                   <%-- <tr>
                                                        <td width="85%">
                                                            <div class="box_head">
                                                                <span>
                                                                    <asp:Literal ID="litRoomReservationList" runat="server" Text="Investor Booking Charges"></asp:Literal>
                                                                </span>
                                                            </div>
                                                            <div class="clear">
                                                            </div>
                                                            <div class="box_content">
                                                                <asp:GridView ID="gvRoomReservation" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                    Width="100%">
                                                                    <Columns>
                                                                        <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1 %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrRate" runat="server" Text="Rate"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Rate")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrRoomRate" runat="server" Text="Unit Rate"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "RoomRate")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrServices" runat="server" Text="Services"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Services")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrUnitTaxes" runat="server" Text="Unit Taxes"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "UnitTaxes")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrUnitType" runat="server" Text="Extra"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Extra")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrDiscount" runat="server" Text="Discount"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Discount")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrTotal" runat="server" Text="Total"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Total")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <div style="padding: 10px;">
                                                                            <b>
                                                                                <asp:Label ID="lblNoRecordFoundForRoomReservation" runat="server" Text="No Record Found."></asp:Label>
                                                                            </b>
                                                                        </div>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                        <td style="vertical-align: top;">
                                                            <asp:CheckBox ID="chkLockRate" runat="server" Text="Lock Rate" /><br />
                                                            <asp:LinkButton ID="lnkRoomReservationServices" ToolTip="Add Service" runat="server"
                                                                OnClick="lnkRoomReservationServices_Click"><img src="../../images/ServiceStatus32x32.png" style="border:1px solid grey;" /></asp:LinkButton>
                                                            &nbsp;&nbsp;&nbsp;
                                                            <asp:LinkButton ID="lnkHouseKeeping" runat="server" ToolTip="House Keeping" OnClick="lnkHouseKeeping_Click"><img src="../../images/HKP28x28.png" style="border:1px solid grey; height:32px; width:32px;" /></asp:LinkButton>
                                                            
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td colspan="2">
                                                            <div style="float: left; padding-right: 20px;">
                                                                <asp:LinkButton ID="lnkCheckiIn" runat="server" ToolTip="CheckIN" Text="Check IN"
                                                                    OnClick="lnkCheckiIn_OnClick"></asp:LinkButton>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:LinkButton ID="lnkDeposit" runat="server" ToolTip="Deposit" Text="Deposit" OnClick="lnkDeposit_OnClick"></asp:LinkButton>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:LinkButton ID="lnkReRoute" runat="server" ToolTip="ReRoute" Text="ReRoute" OnClick="lnkReRoute_OnClick"></asp:LinkButton>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:LinkButton ID="lnkVoucherDetail" runat="server" ToolTip="VoucherDetail" Text="VoucherDetail"
                                                                    OnClick="lnkVoucherDetail_OnClick"></asp:LinkButton>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:LinkButton ID="lnkFolio" runat="server" ToolTip="Folio" Text="Folio" OnClick="lnkFolio_OnClick"></asp:LinkButton>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:LinkButton ID="lnkOtherInfo" runat="server" ToolTip="OtherInfo" Text="Other Info"
                                                                    OnClick="lnkOtherInfo_OnClick"></asp:LinkButton>
                                                            </div>
                                                            <div style="float: left;">
                                                                <ul class="buttonnav">
                                                                    <li><a href="#">Print</a>
                                                                        <ul>
                                                                            <li>
                                                                                <asp:LinkButton ID="lnkConfirmation" runat="server" Text="Confirmation"></asp:LinkButton></li>
                                                                            <li>
                                                                                <asp:LinkButton ID="lnkSigninSheet" runat="server" Text="Signin Sheet"></asp:LinkButton></li>
                                                                        </ul>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                            <div style="float: right; display: inline-block;">
                                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="false" ImageUrl="~/images/cancle.png"
                                                                    Style="float: right; margin-left: 5px;" Text="Cancel" OnClick="btnCancel_Click" />
                                                                <asp:Button ID="btnSave" runat="server" CausesValidation="true" Text="Save" ImageUrl="~/images/save.png"
                                                                    Style="float: right; margin-left: 5px;" ValidationGroup="IsRequire" OnClick="btnSave_Click" />
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
        <ucCtrlAddServices:AddServices ID="ctrlCommonAddServices" runat="server" OnbtnAddServicesCallParent_Click="btnAddServicesCallParent_Click" />
        <ucCtrlHouseKeeping:HouseKeeping ID="ctrlCommonHouseKeeping" runat="server" />
        <%--        <ajx:ModalPopupExtender ID="mpeDeposit" runat="server" TargetControlID="hdnDeposit"
            PopupControlID="pnlDeposit" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnDeposit" runat="server" />
        <asp:Panel ID="pnlDeposit" runat="server" Width="900px" Style="display: none;">
            <uc4:CtrlCommonAddDeposit ID="CtrlCommonAddDeposit1" runat="server" OnbtnAddDepositCallParent_Click="btnAddDepositCallParent_Click" />
        </asp:Panel>--%>
        <ajx:ModalPopupExtender ID="mpeOtherInfo" runat="server" TargetControlID="hdnOtherInfo"
            PopupControlID="pnlOtherInfo" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnOtherInfo" runat="server" />
        <asp:Panel ID="pnlOtherInfo" runat="server" Width="650px" Style="display: none;">
            <ucCtrlCommonOterhInformation:CommonOterhInformation ID="ctrlCommonOterhInformation"
                runat="server" />
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeVoucherDetails" runat="server" TargetControlID="hdnVoucherDetails"
            PopupControlID="pnlVoucherDetails" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnVoucherDetails" runat="server" />
        <asp:Panel ID="pnlVoucherDetails" runat="server" Width="500px" Style="display: none;">
            <ucCtrlVoucherDetails:VoucherDetails ID="CommonCtrlVoucherDetails" runat="server" />
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeCheckIn" runat="server" TargetControlID="hdnCheckIn"
            PopupControlID="pnlCheckIn" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnCheckIn" runat="server" />
        <asp:Panel ID="pnlCheckIn" runat="server" Width="800px" Style="display: none;">
            <ucCtrlCheckIn:CheckIn ID="ctrlCommonCheckIn" runat="server" OnbtnCheckInCallParent_Click="btnCheckInCallParent_Click" />
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeDepositList" runat="server" TargetControlID="hdnDepositList"
            PopupControlID="pnlDepositList" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnDepositList" runat="server" />
        <asp:Panel ID="pnlDepositList" runat="server" Width="900px" Style="display: none;">
            <ucCtrlDepositList:DepositList ID="CtrlDepositList" runat="server" OnbtnDepositListCallParent_Click="btnDepositListCallParent_Click" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updRoomReservation" ID="UpdateProgressRoomReservation"
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
