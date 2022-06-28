<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true"
    CodeBehind="Test1.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Test1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updInvestorList" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
                <tr>
                    <td class="content" style="padding-left: 0px; width: 66.66%">
                        <asp:MultiView ID="mvCalculator" runat="server">
                            <asp:View ID="vFDCalc" runat="server">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                                    <tr>
                                        <td class="boxtopleft">
                                            &nbsp;
                                        </td>
                                        <td class="boxtopcenter">
                                            <div>
                                                <div style="display: inline; float: left;">
                                                    <asp:Button ID="btnGo2ITCalc" runat="server" Text="INVESTORS" OnClick="btnGo2ITCalc_Click" />
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
                                                    <td>
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    Amount:&nbsp;&nbsp;<asp:TextBox ID="txtAmtToAddEveryYear" runat="server" SkinID="TextBoxDate"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    Interest %:&nbsp;&nbsp;<asp:TextBox ID="txtInterest" runat="server" SkinID="TextBoxDate"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    No. of Years:&nbsp;&nbsp;<asp:TextBox ID="txtNoOfYears" runat="server" SkinID="TextBoxDate"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkIsAmtToAddEveryYear" runat="server" Text="Amt 2 Add every Year" />
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" class="dTableBox">
                                                                    <asp:GridView ID="grdInvestorList" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                        ShowFooter="true" OnRowDataBound="grdInvestorList_RowDataBound" SkinID="gvNoPaging">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="StartDate" HeaderText="Date" HeaderStyle-HorizontalAlign="Left"
                                                                                ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px" />
                                                                            <asp:BoundField DataField="Amt4Interest" HeaderText="Amt 4 Intrst" HeaderStyle-HorizontalAlign="Right"
                                                                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px" />
                                                                            <asp:TemplateField FooterStyle-HorizontalAlign="Right" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right"
                                                                                ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderTemplate>
                                                                                    Interest
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "InterestAmt")%>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <b>
                                                                                        <asp:Literal ID="litFtrTotalInterestEarned" runat="server"></asp:Literal></b>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="TotalAmtAtBank" HeaderText="Ttl Amt @ Bank" HeaderStyle-HorizontalAlign="Right"
                                                                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px" />
                                                                            <asp:TemplateField FooterStyle-HorizontalAlign="Right" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right"
                                                                                ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderTemplate>
                                                                                    Amt 2 Add
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "AmtToAdd")%>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <b>
                                                                                        <asp:Literal ID="litFtrTotalAmountAdded" runat="server"></asp:Literal></b>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
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
                            </asp:View>
                            <asp:View ID="vIncomeTaxCalc" runat="server">
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
                                                    <td>
                                                        <table >
                                                            <tr>
                                                                <td width="200px">
                                                                    Yearly Income:&nbsp;&nbsp;<asp:TextBox ID="txtYearlyIncome" runat="server" SkinID="TextBoxDate"></asp:TextBox>
                                                                </td>
                                                                <td width="220px">
                                                                    Yearly Saving ( < 100,000):&nbsp;&nbsp;<asp:TextBox ID="txtYearlySaving" runat="server"
                                                                        SkinID="TextBoxDate"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnITCalcGo" runat="server" Text="Go" OnClick="btnITCalcGo_Click" />
                                                                </td>
                                                            </tr>
                                                            <td>
                                                                <tr>
                                                                    <td colspan="3" style="padding-top:20px;">
                                                                        <table cellpadding = "2" cellspacing="2">
                                                                            <tr>
                                                                                <td width="150px">
                                                                                    Your Yearly Income :
                                                                                </td>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblYearlyIncomeToDisplay" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Your Income tax amount :
                                                                                </td>
                                                                                <td align="right">
                                                                                   <b><asp:Label ID="lblIncomeTaxAmount" runat="server"></asp:Label></b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" style="padding:0px;">
                                                                                    <hr />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Your Net Income :
                                                                                </td>
                                                                                <td align="right">
                                                                                    <asp:Label ID="lblNetIncome" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </td>
                                                        </table>
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
                            </asp:View>
                        </asp:MultiView>
                        <div class="clear_divider">
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
