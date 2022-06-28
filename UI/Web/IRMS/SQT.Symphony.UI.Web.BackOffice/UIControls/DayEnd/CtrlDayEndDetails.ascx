<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlDayEndDetails.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.BackOffice.UIControls.DayEnd.CtrlDayEndDetails" %>
<script type="text/javascript" language="javascript">

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function pageLoad(sender, args) {
        $(function () {
            $("#tabs").tabs();
        });

        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });
    }

    function SelectTab(tabno) {
        if (tabno == '1') {
            window.location.hash = 'tabs-1';x
        }
        else if (tabno == '2') {
            window.location.hash = 'tabs-2';
        }
        else if (tabno == '3') {
            window.location.hash = 'tabs-3';
        }
        else if (tabno == '4') {
            window.location.hash = 'tabs-4';
        }
        else if (tabno == '5') {
            window.location.hash = 'tabs-5';
        }
        else if (tabno == '6') {
            window.location.hash = 'tabs-6';
        }
        else if (tabno == '7') {
            window.location.hash = 'tabs-7';
        }

    }

</script>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="left" valign="top">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="boxtopleft">
                        &nbsp;
                    </td>
                    <td class="boxtopcenter">
                        <asp:Literal ID="litMainHeader" runat="server"></asp:Literal>
                    </td>
                    <td class="boxtopright">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="boxleft">
                        &nbsp;
                    </td>
                    <td align="left" valign="top">
                        <div class="box_form">
                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                <tr>
                                    <td style="width: 15%; height: 500px; vertical-align: top;">
                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                            <tr>
                                                <td>
                                                    <div class="box_head">
                                                        <span>
                                                            <asp:Literal ID="litHdrDateHistory" Text="History" runat="server"></asp:Literal>
                                                        </span>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <div style="overflow: scroll; width: 140px; height: 460px;">
                                                                <asp:TreeView ExpandDepth=0 ID="tvDate" runat="server" ImageSet="Arrows">
                                                                    <%--<HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                                                                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                                                        NodeSpacing="0px" VerticalPadding="0px" />
                                                                    <ParentNodeStyle Font-Bold="False" />
                                                                    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                                                                        VerticalPadding="0px" />--%>
                                                                </asp:TreeView>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="vertical-align: top;">
                                        <div class="demo">
                                            <div id="tabs">
                                                <ul>
                                                    <li><a href="#tabs-1">
                                                        <asp:Literal ID="litPreCheck" Text="Pre-Check" runat="server"></asp:Literal></a></li>
                                                    <li><a href="#tabs-2">
                                                        <asp:Literal ID="litBookKeeping" Text="Book Keeping" runat="server"></asp:Literal></a></li>
                                                    <li><a href="#tabs-3">
                                                        <asp:Literal ID="litCollection" Text="Collection" runat="server"></asp:Literal></a></li>
                                                    <li><a href="#tabs-4">
                                                        <asp:Literal ID="litTax" Text="Tax" runat="server"></asp:Literal></a></li>
                                                    <li><a href="#tabs-5">
                                                        <asp:Literal ID="litHistory" Text="History" runat="server"></asp:Literal></a></li>
                                                    <li><a href="#tabs-6">
                                                        <asp:Literal ID="litBillInvoice" Text="Bill / Invoice" runat="server"></asp:Literal></a></li>
                                                    <li><a href="#tabs-7">
                                                        <asp:Literal ID="litCounters" Text="Counters" runat="server"></asp:Literal></a></li>
                                                </ul>
                                                <div id="tabs-1">
                                                    <table width="100%" border="0" cellspacing="2" cellpadding="2">
                                                        <tr>
                                                            <td style="width: 30%; vertical-align: top; border-right: 1px solid #ccccce;">
                                                                <table width="100%" border="0" cellspacing="2" cellpadding="2">
                                                                    <tr>
                                                                        <td style="vertical-align: top; border: 1px solid #ccccce;">
                                                                            <asp:LinkButton ID="lnkCheckOut" runat="server" Text="CHECK-OUT" OnClick="lnkCheckOut_OnClick"></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="vertical-align: top; border: 1px solid #ccccce;">
                                                                            <asp:LinkButton ID="lnkCheckIn" runat="server" Text="CHECK-IN" OnClick="lnkCheckIn_OnClick"></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="vertical-align: top; border: 1px solid #ccccce;">
                                                                            <asp:LinkButton ID="lnkDepositTranferred" runat="server" Text="Deposit Tranferred"
                                                                                OnClick="lnkDepositTranferred_OnClick"></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="vertical-align: top; border: 1px solid #ccccce;">
                                                                            <asp:LinkButton ID="lnkPOSTAccomodationCharges" OnClick="lnkPOSTAccomodationCharges_OnClick"
                                                                                runat="server" Text="POST Accomodation Charges"></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="vertical-align: top; border: 1px solid #ccccce;">
                                                                            <asp:LinkButton ID="lnkPOSTServiceCharges" runat="server" OnClick="lnkPOSTServiceCharges_OnClick"
                                                                                Text="POST Service Charges"></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="vertical-align: top; border: 1px solid #ccccce;">
                                                                            <asp:LinkButton ID="lnkACBalanceSheet" runat="server" OnClick="lnkACBalanceSheet_OnClick"
                                                                                Text="A/C Balance Sheet"></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="vertical-align: top; border: 1px solid #ccccce;">
                                                                            <asp:LinkButton ID="lnkCloseCounter" runat="server" OnClick="lnkCloseCounter_OnClick"
                                                                                Text="CLOSE Counter"></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="vertical-align: top;">
                                                                <div class="box_head">
                                                                    <span>
                                                                        <asp:Literal ID="litPreCheckGvHdr" runat="server"></asp:Literal>
                                                                    </span>
                                                                </div>
                                                                <div class="clear">
                                                                </div>
                                                                <div class="box_content">
                                                                    <asp:GridView ID="gvPreCheckDetails" runat="server" AutoGenerateColumns="false" ShowHeader="true"
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
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrDescription" runat="server" Text="Description"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Description")%>
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
                                                    </table>
                                                </div>
                                                <div id="tabs-2">
                                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td style="vertical-align: top;">
                                                                <div class="box_head">
                                                                    <span>
                                                                        <asp:Literal ID="litHdrBookKeeping" Text="Book Keeping List" runat="server"></asp:Literal>
                                                                    </span>
                                                                </div>
                                                                <div class="clear">
                                                                </div>
                                                                <div class="box_content">
                                                                    <asp:GridView ID="gvBookKeeping" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                        Width="100%">
                                                                        <Columns>
                                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:CheckBox ID="ChkHdrBookKeeping" runat="server" />
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="ChkBookKeeping" runat="server" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvBookKeepingHdrBookID" runat="server" Text="BookID"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "BookID")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvBookKeepingHdrEnteryDate" runat="server" Text="Entery Date"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "EntryDate")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvBookKeepingHdrRes" runat="server" Text="Res #"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Res")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvBookKeepingHdrRmNOCNF" runat="server" Text="Rm No/CNF"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvBookKeepingHdrGuest" runat="server" Text="Guest"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Guest")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvBookKeepingHdrAmount" runat="server" Text="Amount"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Amount")%>
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
                                                    </table>
                                                </div>
                                                <div id="tabs-3">
                                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td style="vertical-align: top;">
                                                                <div class="box_head">
                                                                    <span>
                                                                        <asp:Literal ID="litHdrCollection" Text="Collection List" runat="server"></asp:Literal>
                                                                    </span>
                                                                </div>
                                                                <div class="clear">
                                                                </div>
                                                                <div class="box_content">
                                                                    <asp:GridView ID="gvCollection" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                        Width="100%">
                                                                        <Columns>
                                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:CheckBox ID="ChkHdrCollection" runat="server" />
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="ChkCollection" runat="server" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvCollectionHdrBookID" runat="server" Text="BookID"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "BookID")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvCollectionHdrEnteryDate" runat="server" Text="Entery Date"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "EntryDate")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblCollectionGvHdrRes" runat="server" Text="Res #"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Res")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblCollectionGvHdrRmNOCNF" runat="server" Text="Rm No/CNF"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblCollectionGvHdrGuest" runat="server" Text="Guest"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Guest")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblCollectionGvHdrAmount" runat="server" Text="Amount"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Amount")%>
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
                                                    </table>
                                                </div>
                                                <div id="tabs-4">
                                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td style="vertical-align: top;">
                                                                <div class="box_head">
                                                                    <span>
                                                                        <asp:Literal ID="litHdrTax" Text="Tax List" runat="server"></asp:Literal>
                                                                    </span>
                                                                </div>
                                                                <div class="clear">
                                                                </div>
                                                                <div class="box_content">
                                                                    <asp:GridView ID="gvTax" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                        Width="100%">
                                                                        <Columns>
                                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:CheckBox ID="ChkHdrTax" runat="server" />
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="ChkTax" runat="server" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvTaxHdrBookID" runat="server" Text="BookID"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "BookID")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvTaxHdrEnteryDate" runat="server" Text="Entery Date"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "EntryDate")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblTaxGvHdrRes" runat="server" Text="Res #"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Res")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblTaxGvHdrRmNOCNF" runat="server" Text="Rm No/CNF"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblTaxGvHdrGuest" runat="server" Text="Guest"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Guest")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblTaxGvHdrAmount" runat="server" Text="Amount"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Amount")%>
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
                                                    </table>
                                                </div>
                                                <div id="tabs-5">
                                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td style="vertical-align: top;">
                                                                <div class="box_head">
                                                                    <span>
                                                                        <asp:Literal ID="litHdrHistory" Text="History List" runat="server"></asp:Literal>
                                                                    </span>
                                                                </div>
                                                                <div class="clear">
                                                                </div>
                                                                <div class="box_content">
                                                                    <asp:GridView ID="gvHistory" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                        Width="100%">
                                                                        <Columns>
                                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:CheckBox ID="ChkHdrHistory" runat="server" />
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="ChkHistory" runat="server" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHistoryHdrBookID" runat="server" Text="BookID"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "BookID")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHistoryHdrEnteryDate" runat="server" Text="Entery Date"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "EntryDate")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHistoryHdrOperation" runat="server" Text="Operation"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Operation")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblHistoryGvHdrRes" runat="server" Text="Res #"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Res")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblHistoryGvHdrRmNOCNF" runat="server" Text="Rm No/CNF"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblHistoryGvHdrGuest" runat="server" Text="Guest"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Guest")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblHistoryGvHdrAmount" runat="server" Text="Actual Amt"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Amount")%>
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
                                                    </table>
                                                </div>
                                                <div id="tabs-6">
                                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td style="vertical-align: top;">
                                                                <div class="box_head">
                                                                    <span>
                                                                        <asp:Literal ID="litHdrBillInvoice" Text="Bill/Invoice List" runat="server"></asp:Literal>
                                                                    </span>
                                                                </div>
                                                                <div class="clear">
                                                                </div>
                                                                <div class="box_content">
                                                                    <asp:GridView ID="gvBillInvoice" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                        Width="100%">
                                                                        <Columns>
                                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:CheckBox ID="ChkHdrBillInvoice" runat="server" />
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="ChkBillInvoice" runat="server" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvBillInvoiceHdrBillNo" runat="server" Text="Inv/Bill No"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "BillNo")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblBillInvoiceHdrDate" runat="server" Text="Date"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblBillInvoiceGvHdrRes" runat="server" Text="Res #"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Res")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblBillInvoiceGvHdrRmNOCNF" runat="server" Text="Rm No/CNF"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblBillInvoiceGvHdrName" runat="server" Text="Name"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Name")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblBillInvoiceGvHdrAmount" runat="server" Text="Amount"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Amount")%>
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
                                                    </table>
                                                </div>
                                                <div id="tabs-7">
                                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td style="width: 20%; vertical-align: top;">
                                                                <div class="box_head">
                                                                    <span>
                                                                        <asp:Literal ID="Literal1" Text="Counters List" runat="server"></asp:Literal>
                                                                    </span>
                                                                </div>
                                                                <div class="clear">
                                                                </div>
                                                                <div class="box_content">
                                                                    <asp:GridView ID="gvCounters" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                        Width="100%">
                                                                        <Columns>
                                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:CheckBox ID="ChkHdrCounter" runat="server" />
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="ChkCounters" runat="server" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvCounters" runat="server" Text="Counters"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Counters")%>
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
                                                            <td style="vertical-align: top;">
                                                                <div class="box_head">
                                                                    <span>
                                                                        <asp:Literal ID="litHdrCountersDetails" Text="Counters Details List" runat="server"></asp:Literal>
                                                                    </span>
                                                                </div>
                                                                <div class="clear">
                                                                </div>
                                                                <div class="box_content">
                                                                    <asp:GridView ID="gvCountersDetails" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                        Width="100%">
                                                                        <Columns>
                                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:CheckBox ID="ChkHdrCounterDetails" runat="server" />
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="ChkCountersDetails" runat="server" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvCountersDetailsHdrBookID" runat="server" Text="BookID"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "BookID")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblCountersDetailsHdrEnteryDate" runat="server" Text="Entery Date"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "EntryDate")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblCountersDetailsGvHdrRes" runat="server" Text="Res #"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Res")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblCountersDetailsGvHdrRmNOCNF" runat="server" Text="Rm No/CNF"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblCountersDetailsGvHdrGuest" runat="server" Text="Guest"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Guest")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblCountersDetailsGvHdrAmount" runat="server" Text="Amount"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Amount")%>
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
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table width="100%" border="0" cellspacing="2" cellpadding="2">
                                            <tr>
                                                <td style="vertical-align: top; width: 65px;">
                                                    <asp:Literal ID="litNote" runat="server" Text="Note"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNote" Style="width: 700px;" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="litAuditDate" runat="server" Text="Audit Date"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAuditDate" runat="server" Style="width: 90px !important;" onkeypress="return false;"></asp:TextBox>
                                                    <asp:Image ID="imgAuditDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                        Height="20px" Width="20px" />
                                                    <ajx:CalendarExtender ID="calAuditDate" PopupButtonID="imgAuditDate" TargetControlID="txtAuditDate"
                                                        runat="server" Format="dd/MM/yyyy">
                                                    </ajx:CalendarExtender>
                                                    <img src="../../images/clear.png" id="imgAD" style="vertical-align: middle;" title="Clear Date"
                                                        onclick="fnClearDate('<%= txtAuditDate.ClientID %>');" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <div style="float: right; width: auto; display: inline-block;">
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" ImageUrl="~/images/cancle.png"
                                                            Style="float: right; margin-left: 5px;" />
                                                        <asp:Button ID="btnDayEnd" runat="server" ImageUrl="~/images/save.png" Style="float: right;
                                                            margin-left: 5px;" Text="Day End" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
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
        </td>
    </tr>
</table>
