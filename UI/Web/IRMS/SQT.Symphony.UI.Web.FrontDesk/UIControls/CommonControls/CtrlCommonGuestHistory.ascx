<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonGuestHistory.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCommonGuestHistory" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<table border="0" cellpadding="2" cellspacing="2" width="100%">
    <tr>
        <td colspan="2" style="font-weight: bold; font-size: 13px; border: 1px solid #ccccce;">
            <div style="float: left; text-align: left;">
                <asp:Literal ID="litGuestHistoryName" runat="server"></asp:Literal>
            </div>
            <div style="float: right;">
                <asp:Literal ID="litGuestContactLable" runat="server" Text="Contact No."></asp:Literal>
                &nbsp;&nbsp;&nbsp;
                <asp:Literal ID="litGuestHistoryContactNo" runat="server"></asp:Literal>
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <hr />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <div class="box_head">
                <span>
                    <asp:Literal ID="litGroupReservationList" runat="server" Text="Guest History List"></asp:Literal>
                </span>
            </div>
            <div class="clear">
            </div>
            <div class="box_content">
                <asp:GridView ID="gvGuestHistory" runat="server" AutoGenerateColumns="false" ShowHeader="true"
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
                        <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Label ID="lblGvHdrBookingNo" runat="server" Text="Booking #"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "RESNo")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Label ID="lblGvHdrRoomCnf" runat="server" Text="Room/CNF"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "Unit")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Label ID="lblGvHdrCheckInDate" runat="server" Text="Check In"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "CheckIn")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Label ID="lblGvHdrCheckOutDate" runat="server" Text="Check Out"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "CheckOut")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Label ID="lblGvHdrNights" runat="server" Text="Nights"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "Nights")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Label ID="lblGvHdrRateCard" runat="server" Text="RateCard Type"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "RateCard")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Right">
                            <HeaderTemplate>
                                <asp:Label ID="lblGvHdrInvoiceAmt" runat="server" Text="Invoice AMT"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "InvoiceAMT")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                <asp:Label ID="lblGvHdrStatus" runat="server" Text="Status"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "Status")%>
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
        <td colspan="2" align="center" style="padding-top: 15px;">
            <asp:Button ID="btnGuestHistoryPrint" runat="server" Text="Print" Style="display: inline;" />
            <asp:Button ID="btnGuestHistoryCancel" runat="server" Text="Cancel" Style="display: inline;"
                OnClick="btnGuestHistoryCancel_Click" />
        </td>
    </tr>
</table>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
