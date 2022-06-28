<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCounterCloseHistoryOnThisMachine.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCounterCloseHistoryOnThisMachine" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript">

    function openViewer() {
        var Preview = '<%=IsPreview%>';
        window.open("../../ReportFiles/frmViewer.aspx?preview=" + Preview);
    }
</script>
<asp:UpdatePanel ID="updCounterCloseHistory" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeaderCounterCloseHistory" runat="server" Text="Counter Close History"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                            </td>
                            <td align="left">
                                <div class="box_form">
                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td style="width: 25%; vertical-align: top; border-right: 1px solid #ccccce;">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblGvHdrFilterRow" runat="server" Text="Filter Row"></asp:Label>
                                                        </td>
                                                        <td style="width: 60px;">
                                                            <asp:TextBox ID="txtRow" runat="server" MaxLength="3"></asp:TextBox>
                                                            <ajx:NumericUpDownExtender ID="nudeRow" runat="server" TargetControlID="txtRow" Width="60"
                                                                Minimum="0" Maximum="999" />
                                                            <ajx:FilteredTextBoxExtender ID="ftRow" runat="server" TargetControlID="txtRow" FilterType="Numbers" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <div class="box_head">
                                                                <span>
                                                                    <asp:Literal ID="litCloseCounterList" runat="server" Text="Close Counter List"></asp:Literal>
                                                                </span>
                                                            </div>
                                                            <div class="clear">
                                                            </div>
                                                            <div class="box_content">
                                                                <div style="height: 500px; overflow: auto;">
                                                                    <asp:GridView ID="gvCloseCounterList" runat="server" AutoGenerateColumns="false"
                                                                        ShowHeader="true" Width="100%" OnRowCommand="gvCloseCounterList_RowCommand" OnRowDataBound="gvCloseCounterList_RowDataBound"
                                                                        SkinID="gvNoPaging" DataKeyNames="CloseID">
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
                                                                                    <asp:Label ID="lblGvHdrCounterNo" runat="server" Text="Counter No"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkCounterNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CounterNo")%>' CommandArgument='<%#DataBinder.Eval(Container.DataItem, "CloseID")%>' CommandName="SHOWDATA"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrDateTime" runat="server" Text="Date"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblGvCounterDate" runat="server"></asp:Label>
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
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="vertical-align:top;">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litCounterCloseHistory" runat="server" Text="Counter Close History List"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvCounterDetails" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                        ShowFooter="false" Width="100%" OnRowDataBound="gvCounterDetails_RowDataBound" DataKeyNames="PayType,Code,AcctID,isReadOnly,NewTransID,OldTransID,AdjustedAmount"
                                                        OnPageIndexChanging="gvCounterDetails_PageIndexChanging">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrDescription" runat="server" Text="Description"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "PayType")%>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblGvFooterDescription" Text="INR Rs." runat="server"></asp:Label></b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="100px" FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                                ItemStyle-HorizontalAlign="Right">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrAmount" runat="server" Text="Amount"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvHistoryAmount" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblGvFooterAmount" runat="server"></asp:Label></b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="100px" FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                                ItemStyle-HorizontalAlign="Right">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrNetAmount" runat="server" Text="Net Amount"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvHistoryNetAmount" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>
                                                                        <asp:Label ID="lblGvFooterNetAmount" runat="server"></asp:Label></b>
                                                                </FooterTemplate>
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
                                            <td align="right" colspan="2">
                                                <div style="width: auto; display: inline-block; text-align: center;">
                                                    <asp:Button ID="btnPrint" runat="server" Text="Print" Style="float: right; margin-left: 5px;" onClick="btnPrint_Click" />
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Style="float: right; margin-left: 5px;" OnClick="btnCancel_Click" />
                                                </div>
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
                    <div class="clear">
                    </div>
                </td>
            </tr>
        </table>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger  ControlID="btnPrint"/>
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
