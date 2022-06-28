<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlDashBoardYieldReport.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.DashBoard.CtrlDashBoardYieldReport" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBoxProspects" TagPrefix="ucP" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessageForYieldReport() {
        document.getElementById('errormessageYieldReport').style.display = "block";
    }
</script>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="box" style="height: 100%;
    min-width: 225px;">
    <tr>
        <td class="boxtopleft">
            &nbsp;
        </td>
        <td class="boxtopcenter">
            RENT YIELD REPORT FOR YEAR<a href="#"><img alt="View" src="../../images/box_arrow.jpg" /></a>
        </td>
        <td class="boxtopright">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="boxleft">
            &nbsp;
        </td>
        <td style="vertical-align: top;">
            <div style="min-height: 175px;">
                <table width="100%">
                    <tr>
                        <td class="dTableBox" style="padding: 10px 0px 10px 0px;">
                            <asp:GridView ID="gvRentYieldQuarterList" runat="server" AutoGenerateColumns="False"
                                Width="100%" SkinID="gvNoPaging" OnRowCommand="gvRentYieldQuarterList_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Quarter" ItemStyle-Width="90px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkGoToInvsPage" runat="server" ForeColor="#0067A4" CommandName="GOTOINVSPAGE"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem, "QuarterID")%>'><%#DataBinder.Eval(Container.DataItem, "QuarterTitle")%></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TotalRoomRentCollected" HeaderText="Rent Income Collected" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField DataField="QuarterAmount" HeaderText="Distributable Rent Amount" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-HorizontalAlign="Right" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <div class="pagecontent_info">
                                        <div class="NoItemsFound">
                                            <h2>
                                                <asp:Literal ID="Literal3" runat="server" Text="No Record Found"></asp:Literal></h2>
                                        </div>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
        <td class="boxright">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="boxbottomleft">
            &nbsp;
        </td>
        <td class="boxbottomcenter">
            &nbsp;
        </td>
        <td class="boxbottomright">
            &nbsp;
        </td>
    </tr>
</table>
<div class="clear_divider">
</div>
<div id="errormessageYieldReport" class="clear" style="display: none;">
    <ucP:MsgBoxProspects ID="MessageBox" runat="server" />
</div>
