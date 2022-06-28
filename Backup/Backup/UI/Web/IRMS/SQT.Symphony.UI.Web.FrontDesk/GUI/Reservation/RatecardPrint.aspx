<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RatecardPrint.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.RatecardPrint" %>

<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <asp:ScriptManager ID="srcptmanaRateCardPrint" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div style="width: 800px; margin: 0; height: 40px; text-align: center;">
        <img src="<%=Page.ResolveUrl("~/images/Logo - registerd_small.jpg") %>" style="width: 100px;"
            border="0" alt="" />
    </div>
    <div style="text-align: center; width: 800px;">
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
                                    <tr>
                                        <td>
                                            <div class="clear">
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
                    <asp:Button ID="btnBack" Visible="false" runat="server" Text="Back" Style="display: inline;"
                        OnClick="btnBack_Click" />
                </div>
            </td>
        </tr>
    </table>
    <div id="errormessage" class="clear" style="display: none;">
        <uc1:MsgBox ID="MessageBox" runat="server" />
    </div>
    </form>
</body>
</html>
