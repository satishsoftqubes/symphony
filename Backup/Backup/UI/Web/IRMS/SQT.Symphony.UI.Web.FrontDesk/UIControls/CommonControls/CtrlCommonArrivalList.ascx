<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonArrivalList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCommonArrivalList" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<div class="box_head">
    <span>
        <asp:Literal ID="litgvhdArrivalList" runat="server" Text="Arrival List"></asp:Literal>
    </span>
</div>
<div class="clear">
</div>
<div class="box_content">
    <asp:GridView ID="gvArrival" runat="server" AutoGenerateColumns="false" ShowHeader="true"
        Width="100%" OnRowDataBound="gvArrival_RowDataBound" SkinID="gvNoPaging">
        <Columns>
            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <HeaderTemplate>
                    <asp:Label ID="lblGvHdrArrivalSrNo" runat="server" Text="No."></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="65px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <HeaderTemplate>
                    <asp:Label ID="lblGvHdrArrivalResNo" runat="server" Text="Booking #"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblGvReservationNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <asp:Label ID="lblGvHdrArrivalStatus" Text="Status" runat="server"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Image ID="imgReservationStatus" runat="server" Style="height: 20px; width: 20px;" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <HeaderTemplate>
                    <asp:Label ID="lblGvHdrGuestFullName" runat="server" Text="Name"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <HeaderTemplate>
                    <asp:Label ID="lblGvHdrGuestType" runat="server" Text="Guest Type"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <%#DataBinder.Eval(Container.DataItem, "GuestType")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <HeaderTemplate>
                    <asp:Label ID="lblGvHdrRoomTypeName" runat="server" Text="RM Type"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                <HeaderTemplate>
                    <asp:Label ID="lblGvHdrRateCardName" Text="Rate Card" runat="server"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <%#DataBinder.Eval(Container.DataItem, "RateCardName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <asp:Label ID="lblGvHdrPickUp" Text="Pickup" runat="server"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblGvPickUp" Text="Pickup" runat="server"></asp:Label>
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
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
