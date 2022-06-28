<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonDepatureList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCommonDepatureList" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<div class="box_head">
    <span>
        <asp:Literal ID="litgvhdDepartureList" runat="server" Text="Departure List"></asp:Literal>
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
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
