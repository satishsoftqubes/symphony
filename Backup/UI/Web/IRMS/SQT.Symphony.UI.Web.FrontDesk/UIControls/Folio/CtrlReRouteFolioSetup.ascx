<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlReRouteFolioSetup.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio.CtrlReRouteFolioSetup" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/Folio/CtrlCommonSubFolioConfiguration.ascx" TagName="SubFolioConfiguration"
    TagPrefix="ucSubFolioConfiguration" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnSelectAllReRoute() {

        var chkSelectAllReRoute = document.getElementById("<%=chkSelectAllReRoute.ClientID %>");

        var chkPOS = document.getElementById("<%=chkPOS.ClientID %>");
        var chkMiscellaneousCharges = document.getElementById("<%=chkMiscellaneousCharges.ClientID %>");
        var chkPhoneCharges = document.getElementById("<%=chkPhoneCharges.ClientID %>");
        var chkRestaurantCharges = document.getElementById("<%=chkRestaurantCharges.ClientID %>");
        var chkAccommodationCharges = document.getElementById("<%=chkAccommodationCharges.ClientID %>");

        var ddlOperationPOS = document.getElementById("<%=ddlOperationPOS.ClientID %>");
        var ddlOperationMiscellaneousCharges = document.getElementById("<%=ddlOperationMiscellaneousCharges.ClientID %>");
        var ddlPhoneCharges = document.getElementById("<%=ddlPhoneCharges.ClientID %>");
        var ddlRestaurantCharges = document.getElementById("<%=ddlRestaurantCharges.ClientID %>");
        var ddlOperationAccommodationCharges = document.getElementById("<%=ddlOperationAccommodationCharges.ClientID %>");

        if (chkSelectAllReRoute.checked) {

            chkPOS.checked = true;
            chkMiscellaneousCharges.checked = true;
            chkPhoneCharges.checked = true;
            chkRestaurantCharges.checked = true;
            chkAccommodationCharges.checked = true;

            ddlOperationPOS.disabled = false;
            ddlOperationMiscellaneousCharges.disabled = false;
            ddlPhoneCharges.disabled = false;
            ddlRestaurantCharges.disabled = false;
            ddlOperationAccommodationCharges.disabled = false;
        }
        else {

            chkPOS.checked = false;
            chkMiscellaneousCharges.checked = false;
            chkPhoneCharges.checked = false;
            chkRestaurantCharges.checked = false;
            chkAccommodationCharges.checked = false;

            ddlOperationPOS.selectedIndex = 0;
            ddlOperationMiscellaneousCharges.selectedIndex = 0;
            ddlPhoneCharges.selectedIndex = 0;
            ddlRestaurantCharges.selectedIndex = 0;
            ddlOperationAccommodationCharges.selectedIndex = 0;

            ddlOperationPOS.disabled = true;
            ddlOperationMiscellaneousCharges.disabled = true;
            ddlPhoneCharges.disabled = true;
            ddlRestaurantCharges.disabled = true;
            ddlOperationAccommodationCharges.disabled = true;
        }

    }

    function fnSelectPOS() {
        var chkPOS = document.getElementById("<%=chkPOS.ClientID %>");
        var ddlOperationPOS = document.getElementById("<%=ddlOperationPOS.ClientID %>");

        if (chkPOS.checked) {
            ddlOperationPOS.disabled = false;
        }
        else {
            ddlOperationPOS.selectedIndex = 0;
            ddlOperationPOS.disabled = true;
        }
    }

    function fnSelectMiscellaneousCharges() {
        var chkMiscellaneousCharges = document.getElementById("<%=chkMiscellaneousCharges.ClientID %>");
        var ddlOperationMiscellaneousCharges = document.getElementById("<%=ddlOperationMiscellaneousCharges.ClientID %>");

        if (chkMiscellaneousCharges.checked) {
            ddlOperationMiscellaneousCharges.disabled = false;
        }
        else {
            ddlOperationMiscellaneousCharges.selectedIndex = 0;
            ddlOperationMiscellaneousCharges.disabled = true;
        }

    }

    function fnSelectPhoneCharges() {
        var chkPhoneCharges = document.getElementById("<%=chkPhoneCharges.ClientID %>");
        var ddlPhoneCharges = document.getElementById("<%=ddlPhoneCharges.ClientID %>");

        if (chkPhoneCharges.checked) {
            ddlPhoneCharges.disabled = false;
        }
        else {
            ddlPhoneCharges.selectedIndex = 0;
            ddlPhoneCharges.disabled = true;
        }
    }

    function fnSelectRestaurantCharges() {
        var chkRestaurantCharges = document.getElementById("<%=chkRestaurantCharges.ClientID %>");
        var ddlRestaurantCharges = document.getElementById("<%=ddlRestaurantCharges.ClientID %>");

        if (chkRestaurantCharges.checked) {
            ddlRestaurantCharges.disabled = false;
        }
        else {
            ddlRestaurantCharges.selectedIndex = 0;
            ddlRestaurantCharges.disabled = true;
        }
    }

    function fnSelectAccommodationCharges() {
        var chkAccommodationCharges = document.getElementById("<%=chkAccommodationCharges.ClientID %>");
        var ddlOperationAccommodationCharges = document.getElementById("<%=ddlOperationAccommodationCharges.ClientID %>");

        if (chkAccommodationCharges.checked) {
            ddlOperationAccommodationCharges.disabled = false;
        }
        else {
            ddlOperationAccommodationCharges.selectedIndex = 0;
            ddlOperationAccommodationCharges.disabled = true;
        }
    }
</script>
<asp:UpdatePanel ID="updReRoute" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server" Text="ReRoute Folio Setup"></asp:Literal>
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
                                    <asp:MultiView ID="mvReRouteFolio" runat="server">
                                        <asp:View ID="vReRouteFolio" runat="server">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td style="font-weight: bold; font-size: 13px; border: 1px solid #ccccce;">
                                                        <table cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td width="100px">
                                                                    <asp:Literal ID="litReRouteSetupBookingNo" runat="server" Text="Booking #"></asp:Literal>
                                                                </td>
                                                                <td width="200px">
                                                                    <asp:Literal ID="litDisplayReRouteSetupBookingNo" runat="server" Text="30417"></asp:Literal>
                                                                </td>
                                                                <td width="150px">
                                                                    <asp:Literal ID="litReRouteSetupSourceFolio" runat="server" Text="Source Folio"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayReRouteSetupSourceFolio" runat="server" Text="30417"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litReRouteSetupUnitNo" runat="server" Text="Room No."></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayReRouteSetupUnitNo" runat="server" Text="101 - Standard"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litReRouteSetupGuestName" runat="server" Text="Name"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:Literal ID="litDisplayReRouteSetupGuestName" runat="server" Text="Mr. Bharat Patel"></asp:Literal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <fieldset style="border: 1px solid #ccc !important;">
                                                            <legend><b>
                                                                <asp:Literal ID="litReRouteSetup" runat="server" Text="ReRoute Setup"></asp:Literal></b>
                                                            </legend>
                                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                                <tr>
                                                                    <td width="200px">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <div style="float: left; padding-right: 15px;">
                                                                            <asp:RadioButtonList ID="rbtReRoute" RepeatColumns="2" RepeatDirection="Horizontal"
                                                                                runat="server">
                                                                                <asp:ListItem Selected="True" Text="Reservation" Value="Reservation"></asp:ListItem>
                                                                                <asp:ListItem Text="Sub Folio" Value="Sub Folio"></asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </div>
                                                                        <div style="float: left; margin-top: 5px;">
                                                                            <asp:Button ID="btnAddSubFolio" runat="server" Text="Add Sub Folio" OnClick="btnAddSubFolio_Click" /></div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:CheckBox ID="chkSelectAllReRoute" runat="server" Text="Select All" onclick="fnSelectAllReRoute();" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkAccommodationCharges" runat="server" Text="Accommodation Charges"
                                                                            onclick="fnSelectAccommodationCharges();" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlOperationAccommodationCharges" runat="server">
                                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                            <asp:ListItem Text="E-voyages - 111" Value="E-voyages - 111"></asp:ListItem>
                                                                            <asp:ListItem Text="E-voyages - 112" Value="E-voyages - 112"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkRestaurantCharges" runat="server" Text="Restaurant Charges"
                                                                            onclick="fnSelectRestaurantCharges();" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlRestaurantCharges" runat="server">
                                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                            <asp:ListItem Text="E-voyages - 111" Value="E-voyages - 111"></asp:ListItem>
                                                                            <asp:ListItem Text="E-voyages - 112" Value="E-voyages - 112"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkPhoneCharges" runat="server" Text="Phone Charges" onclick="fnSelectPhoneCharges();" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlPhoneCharges" runat="server">
                                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                            <asp:ListItem Text="E-voyages - 111" Value="E-voyages - 111"></asp:ListItem>
                                                                            <asp:ListItem Text="E-voyages - 112" Value="E-voyages - 112"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkMiscellaneousCharges" runat="server" Text="Miscellaneous Charges"
                                                                            onclick="fnSelectMiscellaneousCharges();" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlOperationMiscellaneousCharges" runat="server">
                                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                            <asp:ListItem Text="E-voyages - 111" Value="E-voyages - 111"></asp:ListItem>
                                                                            <asp:ListItem Text="E-voyages - 112" Value="E-voyages - 112"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkPOS" runat="server" Text="POS" onclick="fnSelectPOS();" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlOperationPOS" runat="server">
                                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                            <asp:ListItem Text="E-voyages - 111" Value="E-voyages - 111"></asp:ListItem>
                                                                            <asp:ListItem Text="E-voyages - 112" Value="E-voyages - 112"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </fieldset>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Button ID="btnReRouteSave" runat="server" Style="display: inline; padding-right: 10px;"
                                                            Text="Save" />
                                                        <asp:Button ID="btnReRouteCancel" runat="server" Style="display: inline;" Text="Cancel" OnClick="btnReRouteCancel_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vSubFolio" runat="server">
                                            <ucSubFolioConfiguration:SubFolioConfiguration ID="ctrlCommonSubFolioConfiguration"
                                                runat="server" OnbtnSubFolioConfigurationCallParent_Click="btnSubFolioConfigurationCallParent_Click" />
                                        </asp:View>                                        
                                    </asp:MultiView>
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
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updReRoute" ID="UpdateProgressReRoute"
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
