<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestChart.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.TestChart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"> 
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="updInvestorList" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
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
                                        <td align="left" valign="top">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox" style="padding: 10px 0px;">
                                            <asp:GridView ID="grdInvestorList" runat="server" AutoGenerateColumns="False" Width="100%"
                                                OnRowDataBound="grdInvestorList_RowDataBound" >
                                                <Columns>
                                                    <asp:BoundField DataField="StartDate" HeaderText="Date" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left"  />
                                                    <asp:BoundField DataField="Amt4Interest" HeaderText="Amt 4 Intrst" HeaderStyle-HorizontalAlign="Right"
                                                        ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px" />
                                                    <asp:BoundField DataField="InterestAmt" HeaderText="Interest" HeaderStyle-HorizontalAlign="Right"
                                                        ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px" />
                                                    <asp:BoundField DataField="TotalAmtAtBank" HeaderText="Ttl Amt @ Bank" HeaderStyle-HorizontalAlign="Right"
                                                        ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px" />
                                                    <asp:BoundField DataField="AmtToAdd" HeaderText="Amt 2 Add" HeaderStyle-HorizontalAlign="Right"
                                                        ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px" />
                                                    <%--<asp:TemplateField HeaderText="Units" ItemStyle-Width="15px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkBtn" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "TotalUnit")%>'
                                                                CommandName="GETUNIT" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorID")%>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
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
                                    <%--<tr>
                                        <td align="right" valign="middle">
                                            <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" Style="float: right;" />
                                        </td>
                                    </tr>--%>
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
    </ContentTemplate>
</asp:UpdatePanel>

    </form>
</body>
</html>
