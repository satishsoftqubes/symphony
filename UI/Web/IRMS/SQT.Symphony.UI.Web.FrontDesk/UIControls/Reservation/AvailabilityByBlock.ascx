<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AvailabilityByBlock.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.AvailabilityByBlock" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updAvailabilityByBlock" runat="server">
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
                                <asp:Literal ID="litMainHeader" runat="server" Text="Availability By Block"></asp:Literal>
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
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litSearchFromDate" runat="server" Text="From"></asp:Literal>
                                                        </td>
                                                        <td width="230px">
                                                            <asp:TextBox ID="txtSearchFromDate" runat="server" Style="width: 140px !important;"
                                                                SkinID="searchtextbox" onkeypress="return false;"></asp:TextBox>
                                                            <asp:Image ID="imgFromDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                Height="20px" Width="20px" />
                                                            <ajx:CalendarExtender ID="calFromDate" PopupButtonID="imgFromDate" TargetControlID="txtSearchFromDate"
                                                                runat="server" Format="dd/MMM/yyyy">
                                                            </ajx:CalendarExtender>
                                                            <%--<img src="../../images/clear.png" id="imgClearArrival" style="vertical-align: middle;"
                                                                title="Clear Date" onclick="fnClearDate('<%= txtArrivalDate.ClientID %>');" />--%>
                                                        </td>
                                                        <td width="40px">
                                                            <asp:Literal ID="litSearchToDate" runat="server" Text="To"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSearchToDate" runat="server" Style="width: 140px !important;"
                                                                SkinID="searchtextbox" onkeypress="return false;"></asp:TextBox>
                                                            <asp:Image ID="imgSearchToDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                Height="20px" Width="20px" />
                                                            <ajx:CalendarExtender ID="calSearchToDate" PopupButtonID="imgSearchToDate" TargetControlID="txtSearchToDate"
                                                                runat="server" Format="dd/MMM/yyyy">
                                                            </ajx:CalendarExtender>
                                                            <img src="../../images/clear.png" id="imgClearDeparture" style="vertical-align: middle;"
                                                                title="Clear Date" onclick="fnClearDate('<%= txtSearchToDate.ClientID %>');" />&nbsp;&nbsp;
                                                            <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                                Style="border: 0px; margin-left: 5px; vertical-align: middle;" />
                                                            <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                                Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litAvailabilityByBlock" runat="server" Text="Availability By Block"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvAvailabilityByBlock" runat="server" AutoGenerateColumns="false"
                                                        ShowHeader="true" Width="100%">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <div style="float: left; width: 20px; border-right: 1px solid #ccc;">
                                                                        &nbsp;
                                                                    </div>
                                                                    <div style="float: left; width: 368px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        <asp:Literal ID="litGvHdrRoomType" runat="server" Text="Block Name"></asp:Literal>
                                                                    </div>
                                                                    <div style="float: left; width: 50px; border-right: 1px solid #ccc;">
                                                                        <asp:Label ID="litGvHdrTotal" runat="server" Text="Total" Style="padding-left: 14px;
                                                                            vertical-align: middle;"></asp:Label></div>
                                                                        <div style="float: left; width: 50px; border-right: 1px solid #ccc;">
                                                                            <asp:Label ID="lblGvHdrBlockAVL" runat="server" Text="AVL" Style="padding-left: 14px;
                                                                                vertical-align: middle;"></asp:Label>
                                                                        </div>
                                                                        <div style="float: left; width: 50px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                            <asp:Label ID="lblGvHdrBlockOOS" runat="server" Text="OOS" Style="padding-left: 12px;
                                                                                vertical-align: middle;"></asp:Label>
                                                                        </div>
                                                                        <div style="float: left; width: 47px; border-right: 1px solid #ccc; vertical-align: middle;
                                                                            padding-left: 1px;">
                                                                            <img src="../../images/Arrival22x22.png" title="Today’s Arrival" id="imgGvHdrArrival" style="padding-left: 12px;
                                                                                vertical-align: middle;" />
                                                                        </div>
                                                                        <div style="float: left; width: 50px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                            <img src="../../images/Departure22X22.png" title="Departure" id="imgGvHdrDepartur"
                                                                                style="padding-left: 13px; vertical-align: middle;" />
                                                                        </div>
                                                                        <div style="float: left; width: 48px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                            <img src="../../images/CheckIn22x22.png" title="Checked In" id="img1" style="padding-left: 12px;
                                                                                vertical-align: middle;" />
                                                                        </div>
                                                                        <div style="float: left; width: 50px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                            <img src="../../images/No-Show22x22.png" title="Checked out" id="imgGvHdrNoShow" style="padding-left: 14px;
                                                                                vertical-align: middle;" />
                                                                        </div>
                                                                        <%--<div style="float: left; width: 48px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        <img src="../../images/Guarented22x22.png" title="Guarented" id="imgGvHdrGuarented"
                                                                            style="padding-left: 13px; vertical-align: middle;" />
                                                                    </div>--%>
                                                                        <div style="float: left; width: 50px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                            <img src="../../images/UnConfirmed22x22.png" title="Provisional" id="imgGvHdrUnConfirmed"
                                                                                style="padding-left: 14px; vertical-align: middle;" />
                                                                        </div>
                                                                        <div style="float: left; width: 49px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                            <img src="../../images/InHouse22x22.png" title="Pending Allocation" id="imgGvHdrInHouse" style="padding-left: 14px;
                                                                                vertical-align: middle;" />
                                                                        </div>
                                                                        <div style="float: left; width: 49px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                            <img src="../../images/Non-Arrival22x22.png" title="Non-Arrival" id="imgGvHdrNonArrival"
                                                                                style="padding-left: 13px; vertical-align: middle;" />
                                                                        </div>
                                                                        <div style="float: left; width: 49px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                            <img src="../../images/Confirmed22x22.png" title="Confirmed" id="imgGvHdrConfirmed"
                                                                                style="padding-left: 13px; vertical-align: middle;" />
                                                                        </div>
                                                                        <div style="float: left; width: 47px; padding-left: 1px;">
                                                                            <img src="../../images/WaitingList22x22.png" title="Waiting List" id="imgGvHdrWaitingList"
                                                                                style="padding-left: 13px; vertical-align: middle;" />
                                                                        </div>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <div style="float: left; width: 20px; border-right: 1px solid #ccc;">
                                                                        <img id="imgGR<%# Container.DataItemIndex %>" alt="" src="../../images/plus_minus.png"
                                                                            onclick="fnOnClickInnerGrid(this);" />
                                                                    </div>
                                                                    <div style="float: left; width: 372px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        &nbsp;<%# DataBinder.Eval(Container.DataItem, "BlockName")%></div>
                                                                    <div style="float: left; width: 50px; border-right: 1px solid #ccc;">
                                                                        <asp:Label ID="lblTotal" runat="server" Style="padding-left: 22px;" Text='<%# DataBinder.Eval(Container.DataItem, "Total")%>'></asp:Label>
                                                                    </div>
                                                                    <div style="float: left; width: 50px; border-right: 1px solid #ccc;">
                                                                        <asp:Label ID="lblTotalAVL" runat="server" Style="padding-left: 22px;" Text='<%# DataBinder.Eval(Container.DataItem, "TotalAVL")%>'></asp:Label>
                                                                    </div>
                                                                    <div style="float: left; width: 50px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        <asp:Label ID="lblTotalOOS" runat="server" Style="padding-left: 22px;" Text='<%# DataBinder.Eval(Container.DataItem, "TotalOOS")%>'></asp:Label>
                                                                    </div>
                                                                    <div style="float: left; width: 47px; border-right: 1px solid #ccc; vertical-align: middle;
                                                                        padding-left: 1px;">
                                                                        <asp:Label ID="lblTotalArrival" runat="server" Style="padding-left: 22px;" Text='<%# DataBinder.Eval(Container.DataItem, "TotalArrival")%>'></asp:Label>
                                                                    </div>
                                                                    <div style="float: left; width: 50px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        <asp:Label ID="lblTotalDepature" runat="server" Style="padding-left: 22px;" Text='<%# DataBinder.Eval(Container.DataItem, "TotalDepature")%>'></asp:Label>
                                                                    </div>
                                                                    <div style="float: left; width: 48px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        <asp:Label ID="lblTotalCheckIn" runat="server" Style="padding-left: 22px;" Text='<%# DataBinder.Eval(Container.DataItem, "TotalCheckIn")%>'></asp:Label>
                                                                    </div>
                                                                    <div style="float: left; width: 50px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        <asp:Label ID="lblTotalNoShow" runat="server" Style="padding-left: 22px;" Text='<%# DataBinder.Eval(Container.DataItem, "TotalNoShow")%>'></asp:Label>
                                                                    </div>
                                                                   <%-- <div style="float: left; width: 48px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        <asp:Label ID="lblTotalGuaranted" runat="server" Style="padding-left: 22px;" Text='<%# DataBinder.Eval(Container.DataItem, "TotalGuaranted")%>'></asp:Label>
                                                                    </div>--%>
                                                                    <div style="float: left; width: 50px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        <asp:Label ID="lblTotalUnConfirmed" runat="server" Style="padding-left: 22px;" Text='<%# DataBinder.Eval(Container.DataItem, "TotalUnConfirmed")%>'></asp:Label>
                                                                    </div>
                                                                    <div style="float: left; width: 49px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        <asp:Label ID="lblTotalInHouse" runat="server" Style="padding-left: 22px;" Text='<%# DataBinder.Eval(Container.DataItem, "TotalInHouse")%>'></asp:Label>
                                                                    </div>
                                                                    <div style="float: left; width: 49px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        <asp:Label ID="lblTotalNonArrival" runat="server" Style="padding-left: 22px;" Text='<%# DataBinder.Eval(Container.DataItem, "TotalNonArrival")%>'></asp:Label>
                                                                    </div>
                                                                    <div style="float: left; width: 49px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        <asp:Label ID="lblTotalConfirmed" runat="server" Style="padding-left: 22px;" Text='<%# DataBinder.Eval(Container.DataItem, "TotalConfirmed")%>'></asp:Label>
                                                                    </div>
                                                                    <div style="float: left; width: 47px; padding-left: 1px;">
                                                                        <asp:Label ID="lblTotalWaightingList" runat="server" Style="padding-left: 22px;"
                                                                            Text='<%# DataBinder.Eval(Container.DataItem, "TotalWaightingList")%>'></asp:Label>
                                                                    </div>
                                                                    <div id="dvGR<%# Container.DataItemIndex %>" style="display: block; width: 100%; float: left;">
                                                                        <div class="box_content">
                                                                            <asp:GridView ID="gvInnerGridAvaiByBlockList" runat="server" Width="100%" ShowHeader="true"
                                                                                AutoGenerateColumns="false">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrRoomType" runat="server" Text="Room Type"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "RoomType")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrTotal" runat="server" Text="Total"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "Total")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrAVL" runat="server" Text="AVL" ToolTip="Available"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "AVL")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <%--<asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrENQ" runat="server" Text="ENQ"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "ENQ")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>--%>
                                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrOOS" runat="server" Text="OOS" ToolTip="Out of Service"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "OOS")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <img src="../../images/Arrival22x22.png" title="Today’s Arrival" id="imgGvHdrArrival" style="vertical-align: middle;" />
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "Arrival")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <img src="../../images/Departure22X22.png" title="Departure" id="imgGvHdrDepartur"
                                                                                                style="vertical-align: middle;" />
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "Departure")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <img src="../../images/CheckIn22x22.png" title="Checked In" id="imgGvHdrCheckIn" style="vertical-align: middle;" />
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "CheckIn")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <img src="../../images/No-Show22x22.png" title="Checked out" id="imgGvHdrNoShow" style="vertical-align: middle;" />
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "NoShow")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                   <%-- <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <img src="../../images/Guarented22x22.png" title="Guarented" id="imgGvHdrGuarented"
                                                                                                style="vertical-align: middle;" />
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "Guarented")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>--%>
                                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <img src="../../images/UnConfirmed22x22.png" title="Provisional" id="imgGvHdrUnConfirmed"
                                                                                                style="vertical-align: middle;" />
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "UnConfirmed")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <img src="../../images/InHouse22x22.png" title="Pending Allocation" id="imgGvHdrInHouse" style="vertical-align: middle;" />
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "InHouse")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <img src="../../images/Non-Arrival22x22.png" title="Non-Arrival" id="imgGvHdrNonArrival"
                                                                                                style="vertical-align: middle;" />
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "NonArrival")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <img src="../../images/Confirmed22x22.png" title="Confirmed" id="imgGvHdrConfirmed"
                                                                                                style="vertical-align: middle;" />
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "Confirmed")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <img src="../../images/WaitingList22x22.png" title="Waiting List" id="imgGvHdrWaitingList"
                                                                                                style="vertical-align: middle;" />
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "WaitingList")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <div style="padding: 10px;">
                                                                                        <b>
                                                                                            <asp:Label ID="lblGRNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                                        </b>
                                                                                    </div>
                                                                                </EmptyDataTemplate>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div style="padding: 10px;">
                                                                <b>
                                                                    <asp:Label ID="lblGRNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
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
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<script type="text/javascript">
    function fnOnClickInnerGrid(obj) {
        var imgID = obj.id;
        var divID = imgID.replace("imgGR", "dvGR");

        var toHidShowDiv = document.getElementById(divID);

        if (toHidShowDiv.style.display == 'none') {
            toHidShowDiv.style.display = 'block';
            document.getElementById(imgID).src = "../../images/plus_minus.png";
        }
        else if (toHidShowDiv.style.display == 'block') {
            toHidShowDiv.style.display = 'none';
            document.getElementById(imgID).src = "../../images/plus_button.png";
                }

               
    }
</script>
