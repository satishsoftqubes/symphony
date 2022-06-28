<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SelectInvestor.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.DashBoard.SelectInvestor" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="content" style="padding-left: 0px;">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                <tr>
                    <td class="boxtopleft">
                        &nbsp;
                    </td>
                    <td class="boxtopcenter">
                        <div>
                            <div style="display: inline; float: left;">
                                INVESTORS
                            </div>
                        </div>
                    </td>
                    <td class="boxtopright">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="boxleft">
                        &nbsp;
                    </td>
                    <td>
                        <table cellpadding="2" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td class="dTableBox" style="padding: 10px 0px;">
                                    <asp:GridView ID="grdInvestorList" runat="server" AutoGenerateColumns="False" Width="100%"
                                        OnRowDataBound="grdInvestorList_RowDataBound" OnRowCommand="grdInvestorList_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="" ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkSelect" runat="server" Text="Select" CommandName="SELECTINVESTOR"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorID")%>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="InvestorName" HeaderText="Name" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200px" />
                                            <asp:TemplateField HeaderText="Mobile No" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                ItemStyle-Width="100px">
                                                <ItemTemplate>
                                                    <asp:Literal ID="litMobileNo" runat="server"></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="EMail" HeaderText="Email" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px" />
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
