<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRateCardList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlRateCardList" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
    function fnPrint() {
        document.getElementById('dvToHide').style.display = 'none';
        window.print();
        window.close();
    }
    function fnOpenRateCardPrint() {

        window.open("RatecardPrint.aspx", "RatecardPrint", "width=800,height=700,status=0,toolbar=0,scrollbars=1");
        return false;
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
                                <asp:Literal ID="litMainHeader" runat="server" Text="Ratecard List"></asp:Literal>
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
                                        <%--<tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="120px">
                                                            <asp:Literal ID="ltrSrchRateCardName" runat="server" Text="RateCard Name"></asp:Literal>
                                                        </td>
                                                        <td width="250px">
                                                            <asp:TextBox ID="txtRateCardName" runat="server" SkinID="searchtextbox"></asp:TextBox>
                                                            
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="ltrCardType" runat="server" Text="Type"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlRateCardType" runat="server" SkinID="nowidth" Width="150px">
                                                                <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Daily" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Weekly" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Quarterly" Value="3"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;&nbsp;
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
                                                <hr />
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td>
                                                <div class="clear">
                                                </div>
                                                <div style="float: right;">
                                                    <asp:Button ID="btnRateCardPrint" runat="server" Text="Print" OnClientClick="return fnOpenRateCardPrint();" />
                                                </div>
                                                <asp:DataList ID="dlRateCardList" runat="server" CellPadding="0" CellSpacing="5"
                                                    RepeatDirection="Horizontal" RepeatColumns="2" OnItemDataBound="dlRateCardList_ItemDataBound">
                                                    <ItemTemplate>
                                                        <b>
                                                            <asp:Label ID="lblRateCardRoomType" runat="server" Text='<%#String.Concat(DataBinder.Eval(Container.DataItem, "DisplayMinimumDays")," - ",DataBinder.Eval(Container.DataItem, "RateCardName"))%>'></asp:Label></b>
                                                        <asp:Label ID="lblRateId" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "RateID")%>'></asp:Label>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvRoomTypeList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                Width="100%" DataKeyNames="Deposit,TotalRackRate,RackRate" SkinID="gvNoPaging">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRoomType" runat="server" Text="Room Type"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkRateCardRoomType" runat="server" CommandName="RoomType" CommandArgument='<%#Eval("RoomTypeID") + ","+Eval("RoomType") %>'>
                                                                                <asp:Label ID="lblRateCardRoomType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RoomType")%>'></asp:Label></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRoomTypeDeposit" runat="server" Text="Deposit"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvDepositAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Deposit")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRoomTypeRackRate" runat="server" Text="Rack Rate"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvTotalRackRate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RackRate")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRoomTypeTax" runat="server" Text="Taxes"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvTax" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Taxes")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRoomTypeTotal" runat="server" Text="Total"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvTotal" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Total")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                        </b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                                <%--  <asp:GridView ID="gvRateCardList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                        Width="100%">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <div style="float: left; width: 371px; border-right: 1px solid #ccc; padding-left: 1px; font-weight:bold;">
                                                                        <asp:Literal ID="litGvHdrRateCard" runat="server" Text="RateCard"></asp:Literal>
                                                                    </div>
                                                                    <div style="float: left; width: 200px; border-right: 1px solid #ccc;">
                                                                        <asp:Label ID="lblGvHdrType" runat="server" Text="Type" Style="padding-left: 14px; font-weight:bold;
                                                                            vertical-align: middle;"></asp:Label>
                                                                    </div>
                                                                    <div style="float: left; width: 200px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        <asp:Label ID="lblGvHdrStartDate" runat="server" Text="Start Date" Style="padding-left: 12px; font-weight:bold;
                                                                            vertical-align: middle;"></asp:Label>
                                                                    </div>
                                                                    <div style="float: left; width: 200px; padding-left: 1px;">
                                                                        <asp:Label ID="lblGvHdrEndDate" runat="server" Text="End Date" Style="padding-left: 12px; font-weight:bold;
                                                                            vertical-align: middle;"></asp:Label>
                                                                    </div>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <div style="float: left; width: 372px; border-right: 1px solid #ccc; padding-left: 1px; font-weight:bold;">
                                                                        &nbsp;<%# DataBinder.Eval(Container.DataItem, "RateCard")%></div>
                                                                    <div style="float: left; width: 200px; border-right: 1px solid #ccc; font-weight:bold;">
                                                                        <asp:Label ID="lblTotalAVL" runat="server" Style="padding-left: 22px;" Text='<%# DataBinder.Eval(Container.DataItem, "Type")%>'></asp:Label>
                                                                    </div>
                                                                    <div style="float: left; width: 200px; border-right: 1px solid #ccc; padding-left: 1px; font-weight:bold;">
                                                                        <asp:Label ID="lblTotalBLK" runat="server" Style="padding-left: 22px;" Text='<%# DataBinder.Eval(Container.DataItem, "StartDate")%>'></asp:Label>
                                                                    </div>
                                                                    <div style="float: left; width: 200px; vertical-align: middle; padding-left: 1px; font-weight:bold;">
                                                                        <asp:Label ID="lblTotalArrival" runat="server" Style="padding-left: 22px;" Text='<%# DataBinder.Eval(Container.DataItem, "EndDate")%>'></asp:Label>
                                                                    </div>
                                                                    <div id="dvGR<%# Container.DataItemIndex %>" style="width: 100%; float: left;padding-bottom:10px;">
                                                                        <div class="box_content" style="border-left:1px solid #ccc; border-bottom:1px solid #ccc;">
                                                                            <asp:GridView ID="gvRoomTypeList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                Width="100%">
                                                                                <Columns>
                                                                                    <asp:TemplateField  ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrRoomTypeSrNo" runat="server" Text="No."></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%# Container.DataItemIndex + 1 %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrRoomType" runat="server" Text="Room Types"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "RoomType")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="180px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrRoomTypeRackRate" runat="server" Text="Rack Rate"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "RackRate")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="180px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrRoomTypeTax" runat="server" Text="Tax"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "Tax")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="180px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrRoomTypeServices" runat="server" Text="Services"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "Services")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="180px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrRoomTypeTotal" runat="server" Text="Total"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "Total")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <div style="padding: 10px;">
                                                                                        <b>
                                                                                            <asp:Label ID="lblNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
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
                                                    </asp:GridView>--%>
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
        <ajx:ModalPopupExtender ID="mpeRateCardPrint" runat="server" TargetControlID="hdnRateCardPrint"
            PopupControlID="pnlRateTypePrint" CancelControlID="btnCancelRateCard" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnRateCardPrint" runat="server" />
        <asp:Panel ID="pnlRateTypePrint" runat="server" Style="display: none;">
            <div class="box_col1">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="Literal1" runat="server" Text="Ratecard List"></asp:Literal>
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
                                                        <asp:DataList ID="dlToPrint" runat="server" CellPadding="0" CellSpacing="5" RepeatDirection="Horizontal"
                                                            RepeatColumns="2" OnItemDataBound="dlToPrint_ItemDataBound">
                                                            <ItemTemplate>
                                                                <b>
                                                                    <asp:Label ID="lblRateCardRoomType" runat="server" Text='<%#String.Concat(DataBinder.Eval(Container.DataItem, "DisplayMinimumDays")," - ",DataBinder.Eval(Container.DataItem, "RateCardName"))%>'></asp:Label></b>
                                                                <asp:Label ID="lblRateId" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "RateID")%>'></asp:Label>
                                                                <div class="box_content">
                                                                    <asp:GridView ID="gvRoomTypeList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                        Width="100%" DataKeyNames="Deposit,TotalRackRate,RackRate" SkinID="gvNoPaging">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrRoomType" runat="server" Text="Room Type"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkRateCardRoomType" runat="server" CommandName="RoomType" CommandArgument='<%#Eval("RoomTypeID") + ","+Eval("RoomType") %>'>
                                                                                        <asp:Label ID="lblRateCardRoomType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RoomType")%>'></asp:Label></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrRoomTypeDeposit" runat="server" Text="Deposit"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblGvDepositAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Deposit")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrRoomTypeRackRate" runat="server" Text="Rate"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblGvTotalRackRate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RackRate")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrRoomTypeTax" runat="server" Text="Taxes"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblGvTax" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Taxes")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrRoomTypeTotal" runat="server" Text="Total"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblGvTotal" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Total")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <EmptyDataTemplate>
                                                                            <div style="padding: 10px;">
                                                                                <b>
                                                                                    <asp:Label ID="lblNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                                </b>
                                                                            </div>
                                                                        </EmptyDataTemplate>
                                                                    </asp:GridView>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:DataList>
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
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<script type="text/javascript">
    function fnOnClickInnerGrid(obj) {
        var imgID = obj.id;
        var divID = imgID.replace("imgGR", "dvGR");

        var toHidShowDiv = document.getElementById(divID);

        if (toHidShowDiv.style.display == 'none') {
            toHidShowDiv.style.display = 'block';
            document.getElementById(imgID).src = "../../images/icon222.png";
        }
        else if (toHidShowDiv.style.display == 'block') {
            toHidShowDiv.style.display = 'none';
            document.getElementById(imgID).src = "../../images/icon111.png";
        }
    }
</script>
