<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangeRoomNumOnly.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.ChangeRoomNumOnly" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<asp:UpdatePanel ID="updFolioDetails" runat="server">
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
                                <asp:Literal ID="litMainHeader" runat="server" Text="Change Wrongly Assigned Room Number"></asp:Literal>
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
                                        <tr style="background-color: #F3F3F5;">
                                            <td width="33%" style="vertical-align: top; border: 1px solid #ccccce !important;">
                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                    <tr>
                                                        <th style="width: 75px;" align="left">
                                                            <asp:Label ID="lblFolioDetailsGuestName" runat="server" Text="Name"></asp:Label>
                                                        </th>
                                                        <td>
                                                            <asp:Label ID="lblFolioDetailsDisplayGuestName" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 75px;" align="left">
                                                            <asp:Label ID="lblFolioDetailsMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                        </th>
                                                        <td>
                                                            <asp:Label ID="lblFolioDetailsDisplayMobileNo" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 75px;" align="left">
                                                            <asp:Label ID="lblFolioDetailsEmail" runat="server" Text="Email"></asp:Label>
                                                        </th>
                                                        <td>
                                                            <asp:Label ID="lblFolioDetailsDisplayEmail" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="33%" style="vertical-align: top; border: 1px solid #ccccce !important;">
                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                    <tr>
                                                        <th style="width: 75px;" align="left">
                                                            <asp:Literal ID="litArrivalDate" runat="server" Text="Check In"></asp:Literal>
                                                        </th>
                                                        <td>
                                                            <asp:Literal ID="litDisplayArrivalDate" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 75px;" align="left">
                                                            <asp:Literal ID="litDepatureDate" runat="server" Text="Check Out"></asp:Literal>
                                                        </th>
                                                        <td>
                                                            <asp:Literal ID="litDisplayDepatureDate" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 75px;" align="left">
                                                            <asp:Literal ID="litFolioNo" runat="server" Text="Folio No."></asp:Literal>
                                                        </th>
                                                        <td>
                                                            <asp:Literal ID="litDisplayFolioNo" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="vertical-align: top; border: 1px solid #ccccce !important;">
                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                    <tr>
                                                        <th style="width: 75px;" align="left">
                                                            <asp:Literal ID="litUnitNo" runat="server" Text="Room No."></asp:Literal>
                                                        </th>
                                                        <td>
                                                            <asp:Literal ID="litDisplayUnitNo" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 75px;" align="left">
                                                            <asp:Literal ID="litRoomType" runat="server" Text="Room Type"></asp:Literal>
                                                        </th>
                                                        <td>
                                                            <asp:Literal ID="litDisplayRoomType" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 85px;" align="left">
                                                            <asp:Literal ID="litRateCard" runat="server" Text="Rate Card"></asp:Literal>
                                                        </th>
                                                        <td>
                                                            <asp:Literal ID="litDisplayRateCard" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <table cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="200px">Current Assigned Room No.</td>
                                                        <td>
                                                            <asp:Literal ID="ltrCurrentAssignedRoomNo" runat="server"></asp:Literal>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>New Room No.</td>
                                                        <td>
                                                            <asp:TextBox ID="txtNewRoomNo" runat="server" SkinID="searchtextbox"></asp:TextBox>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvtxtNewRoomNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                    runat="server" ValidationGroup="IsRequiredToGetRoom" ControlToValidate="txtNewRoomNo"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                            
                                                        </td>
                                                        <td><asp:Button ID="btnGetRooms" runat="server" Text="Get Room(s)" ValidationGroup="IsRequiredToGetRoom" OnClick="btnGetRooms_Click" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td>Select Room No.</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlNewRoomNo" runat="server" SkinID="searchddl"></asp:DropDownList>
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvddlRoomNo" SetFocusOnError="true" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                 CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequiredToSetRoom" ControlToValidate="ddlNewRoomNo"
                                                                    Display="Dynamic">
                                                                </asp:RequiredFieldValidator>
                                                            </span>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td>
                                                            <asp:Button ID="btnUpdateRoomNo" runat="server" Text="Update" ValidationGroup="IsRequiredToSetRoom" OnClick="btnUpdateRoomNo_Click" />
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
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="updFolioDetails" ID="UpdateProgressFolioDetails"
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
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
