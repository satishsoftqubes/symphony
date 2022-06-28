<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPostUnitCharges.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio.CtrlPostUnitCharges" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function validate(Type) {

        var start = document.getElementById("<%=txtPostUnitChargesStartDate.ClientID%>").value;
        var end = document.getElementById("<%=txtPostUnitChargesEndDate.ClientID%>").value;

        var stDate = new Date(start);
        var enDate = new Date(end);
        if (start > end) {
            document.getElementById("ErrorMsg").innerHTML = "End Date Not Less Then To Start Date";
            return false;
        }

    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
    
</script>
<ajx:ModalPopupExtender ID="mpePostUnitCharges" runat="server" TargetControlID="hdnPostUnitCharges"
    PopupControlID="pnlPostUnitCharges" BackgroundCssClass="mod_background" CancelControlID="btnPostUnitChargesCancel">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnPostUnitCharges" runat="server" />
<asp:Panel ID="pnlPostUnitCharges" runat="server" Width="595px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="litPostRoomChargesHeader" runat="server" Text="Post Room Charges"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <%if (IsMessage)
              { %>
            <div class="ResetSuccessfully">
                <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                    <img src="../../images/success.png" />
                </div>
                <div>
                    <asp:Label ID="lblCommonMsg" runat="server"></asp:Label></div>
                <div style="height: 10px;">
                </div>
            </div>
            <% }%>
            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                <tr>
                    <td style="border: 1px solid #ccccce;">
                        <div style="float: left; width: 100px;">
                            <asp:Literal ID="litPostRoomChargesReservationNo" runat="server" Text="Booking #"></asp:Literal>
                        </div>
                        <div style="float: left; width: 100px;">
                            <asp:Literal ID="litDisplayPostRoomChargesReservationNo" runat="server" Text="30374"></asp:Literal>
                        </div>
                        <div style="float: left; width: 50px;">
                            <asp:Literal ID="litPostUnitChargesUnitNo" runat="server" Text="Room"></asp:Literal>
                        </div>
                        <div style="float: left; width: 100px;">
                            <asp:Literal ID="litDisplayPostUnitChargesUnitNo" runat="server" Text="101 - Standard"></asp:Literal>
                        </div>
                        <div style="float: left; width: 100px;">
                            <asp:Literal ID="litPostUnitChargesGuestName" runat="server" Text="Name"></asp:Literal>
                        </div>
                        <div style="float: left;">
                            <asp:Literal ID="litDisplayPostUnitChargesGuestName" runat="server" Text="Mr. Prakash Patel"></asp:Literal>
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
                        <fieldset style="border: 1px solid #ccc !important;">
                            <legend>
                                <asp:Literal ID="litPostUnitChargesInfo" Text="Post Room Charges Info." runat="server"></asp:Literal>
                            </legend>
                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                <tr>
                                    <td class="isrequire">
                                        <asp:Literal ID="litPostUnitChargesStartDate" runat="server" Text="Start Date"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPostUnitChargesStartDate" runat="server" onkeypress="return false;"></asp:TextBox>
                                        <asp:Image ID="imgPostUnitChargesStartDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                            Height="20px" Width="20px" />
                                        <ajx:CalendarExtender ID="CalPostUnitChargesStartDate" PopupButtonID="imgPostUnitChargesStartDate"
                                            TargetControlID="txtPostUnitChargesStartDate" runat="server">
                                        </ajx:CalendarExtender>
                                        <img src="../../images/clear.png" id="imgDD" style="vertical-align: middle;" title="Clear Date"
                                            onclick="fnClearDate('<%= txtPostUnitChargesStartDate.ClientID %>');" />
                                        <span>
                                            <asp:RequiredFieldValidator ID="rfvPostUnitChargesStartDate" SetFocusOnError="true"
                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="AddPostUnitCharges"
                                                ControlToValidate="txtPostUnitChargesStartDate" Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="isrequire">
                                        <asp:Literal ID="litPostUnitChargesEndDate" runat="server" Text="End Date"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPostUnitChargesEndDate" runat="server" onkeypress="return false;"></asp:TextBox>
                                        <asp:Image ID="imgPostUnitChargesEndDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                            Height="20px" Width="20px" />
                                        <ajx:CalendarExtender ID="CalPostUnitChargesEndDate" PopupButtonID="imgPostUnitChargesEndDate"
                                            TargetControlID="txtPostUnitChargesEndDate" runat="server">
                                        </ajx:CalendarExtender>
                                        <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" title="Clear Date"
                                            onclick="fnClearDate('<%= txtPostUnitChargesEndDate.ClientID %>');" />
                                        <span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                runat="server" ValidationGroup="AddPostUnitCharges" ControlToValidate="txtPostUnitChargesEndDate"
                                                Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <span id="ErrorMsg" style="color: Red"></span>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnPostUnitChargesSave" OnClientClick="return validate('PROFILE');"
                            OnClick="btnPostUnitChargesSave_OnClick" runat="server" Text="Save" Style="display: inline;"
                            ValidationGroup="AddPostUnitCharges" />
                        <asp:Button ID="btnPostUnitChargesCancel" runat="server" Text="Cancel" Style="display: inline;" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
