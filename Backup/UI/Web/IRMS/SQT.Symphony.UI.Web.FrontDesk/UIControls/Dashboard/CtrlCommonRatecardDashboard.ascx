<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonRatecardDashboard.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Dashboard.CtrlCommonRatecardDashboard" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    //    function OpenRoomType() {

    //        $find('<%=mpeRoomTypeDetail.BehaviorID%>').show();

    //    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<table border="0" cellpadding="2" cellspacing="2" width="100%">
    <tr>
        <td align="right">
            <asp:CheckBox ID="chkIsFullRoom" runat="server" OnCheckedChanged="chkIsFullRoom_CheckChanged"
                Text="Is Per Room" AutoPostBack="true" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:RadioButtonList ID="rblRatecardTyep" runat="server" RepeatColumns="7" Width="100%"
                OnSelectedIndexChanged="rblRatecardTyep_SelectedIndexChanged" AutoPostBack="true">
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <%--<div class="box_head">
                <span>
                    <asp:Literal ID="litgvhdRateCard" runat="server" Text="Standard Rate Card"></asp:Literal>
                </span>
            </div>--%>
            <div class="clear">
            </div>
            <div class="box_content">
                <asp:GridView ID="gvRoomTypeList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                    Width="100%" OnRowCommand="gvRoomTypeList_OnCommand" OnRowDataBound="gvRoomTypeList_RowDataBound"
                    DataKeyNames="Deposit,TotalRackRate,RackRate" SkinID="gvNoPaging">
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
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td style="padding-top: 28px;">
                        <b>Corporate Rate card</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        Name: &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtSrchCorpRateCard" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="Search" Style="display: inline;" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<ajx:ModalPopupExtender ID="mpeRoomTypeDetail" runat="server" TargetControlID="hdnMessege"
    PopupControlID="pnlRoomTypeDetail" CancelControlID="iBtnCacelRoomTypeDetail"
    BackgroundCssClass="mod_background">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnMessege" runat="server" />
<asp:Panel ID="pnlRoomTypeDetail" runat="server" Width="500px" Height="600px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <div style="display: inline;">
                <span>
                    <asp:Literal ID="litPopupHrdRoomType" runat="server" Text="Room Type"></asp:Literal>
                </span>
            </div>
            <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                <asp:ImageButton ID="iBtnCacelRoomTypeDetail" runat="server" ImageUrl="~/images/closepopup.png"
                    Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table width="100%" cellpadding="2" cellspacing="2">
                <tr>
                    <td style="border-right: 1px solid #ccccce; width: 50%; vertical-align: top;">
                        <table border="0" cellpadding="2" cellspacing="2" width="100%" style="vertical-align: top;">
                            <tr>
                                <th align="left" style="vertical-align: top;">
                                    <b>
                                        <asp:Literal ID="litHrdRoomSpecification" runat="server" Text=" Room Specification"></asp:Literal></b>
                                    <hr />
                                </th>
                            </tr>
                            <tr>
                                <td style="vertical-align: top;">
                                    <div style="height: 300px; overflow: auto;">
                                        <asp:GridView ID="gvRoomAmenities" Width="100%" runat="server" SkinID="gvNoPaging"
                                            ShowHeader="false">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "AmenitiesName")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <asp:Label ID="lblgvRoomAmenitiesNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="vertical-align: top;">
                        <table border="0" cellpadding="2" cellspacing="2" width="100%" style="vertical-align: top;">
                            <tr>
                                <th align="left" style="vertical-align: top;">
                                    <b>
                                        <asp:Literal ID="litHrdComplementaryServices" runat="server" Text="Complimentory Services"></asp:Literal></b>
                                    <hr />
                                </th>
                            </tr>
                            <tr>
                                <td style="vertical-align: top;">
                                    <div style="height: 300px; overflow: auto;">
                                        <asp:GridView ID="gvComplimentoryServices" Width="100%" runat="server" SkinID="gvNoPaging"
                                            ShowHeader="false">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "ItemName")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <asp:Label ID="lblgvComplimentoryServicesNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <%--<tr>
                    <td colspan="2" align="center" style="padding-bottom: 5px;">
                        <asp:Button ID="btnClear" runat="server" Text="Cancel" Style="display: inline;" />
                    </td>
                </tr>--%>
            </table>
        </div>
    </div>
</asp:Panel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
