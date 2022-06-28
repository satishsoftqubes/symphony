<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TodaysDeparturePrintt.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.TodaysDeparturePrintt" %>

<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link id="Link1" href="~/Styles/style.css" runat="server" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function fnPrint() {
            document.getElementById('dvToHide').style.display = 'none';
            window.print();
            window.close();
        }
        function fnDisplayCatchErrorMessage() {
            document.getElementById('errormessage').style.display = "block";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="srcptmana" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div style="width: 800px; margin: 0; height: 40px; text-align: center;">
        <img src="<%=Page.ResolveUrl("~/images/Logo - registerd_small.jpg") %>" style="width: 100px;"
            border="0" alt="" />
    </div>
    <div style="text-align: center; width: 800px; margin-bottom: 35px;">
        <asp:Label runat="server" ID="lblPropertyaddress"></asp:Label></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="content">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="boxtopleft">
                            &nbsp;
                        </td>
                        <td class="boxtopcenter">
                            <asp:Literal ID="litMainHeader" runat="server" Text="Today's Departure"></asp:Literal>
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
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <div class="clear">
                                            </div>
                                            <div class="box_head">
                                                <span>
                                                    <asp:Literal ID="litgvhdArrivalList" runat="server" Text="Departure List"></asp:Literal>
                                                </span>
                                            </div>
                                            <div class="clear">
                                            </div>
                                            <div class="box_content">
                                                <asp:GridView ID="gvDeparture" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                    Width="100%" SkinID="gvNoPaging" OnRowDataBound="gvDeparture_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrDepartureSrNo" runat="server" Text="No."></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrDepartureResNo" runat="server" Text="Booking #"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrDepartureGuest" runat="server" Text="Name"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGvPhone" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrRateCardType" runat="server" Text="Rate Card Name"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "RateCardName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrDepartureType" runat="server" Text="RM Type"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrDepartureRoom" runat="server" Text="Room"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvRoomNo" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrCheckIn" runat="server" Text="Check In"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGvCheckInDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckInDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrCheckOut" runat="server" Text="Check Out"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGvCheckOutDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckOutDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrDeparturePayment" runat="server" Text="Balance"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGvDeparturePayment" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrDrop" runat="server" Text="Drop"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
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
        <tr>
            <td>
                <div id="dvToHide" style="padding-bottom: 10px; padding-top: 10px; padding-left: 10px;
                    padding-right: 10px;" align="center">
                    <asp:Button ID="btnCancelPritnRegFrom" runat="server" Style="display: inline;" Text="Print"
                        OnClientClick="fnPrint();" />
                </div>
            </td>
        </tr>
    </table>
    <div id="errormessage" class="clear">
        <uc1:MsgBox ID="MessageBox" runat="server" />
    </div>
    </form>
</body>
</html>
