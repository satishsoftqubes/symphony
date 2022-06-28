<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RptInvestorDetailPrint.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Reports.RptInvestorDetailPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Style/style.css" rel="stylesheet" type="text/css" />
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
    <table cellpadding="2" cellspacing="0" border="0" width="100%">
        <tr>
            <td class="dTableBox">
                <div style="overflow: auto; width: 95%; height: 730px; margin: 10px 10px 10px 10px;">
                    <asp:GridView ID="gvInvestorDetailInformation" runat="server" AutoGenerateColumns="False"
                        Width="1200px" OnPageIndexChanging="gvInvestorDetailInformation_OnPageIndexChanging">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <HeaderTemplate>
                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="InvName" HeaderText="Investor Name" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" ItemStyle-Width="120px" />
                            <asp:BoundField DataField="PanNo" HeaderText="Pan No." HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70px" />
                            <asp:BoundField DataField="BankName" HeaderText="Bank Name" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px" />
                            <asp:BoundField DataField="AccountNo" HeaderText="Bank A/c No." HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" ItemStyle-Width="80px" />
                            <asp:BoundField DataField="IFSCCode" HeaderText="IFSC Code" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70px" />
                            <asp:BoundField DataField="TypeA" HeaderText="Type A" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="60px" />
                            <asp:BoundField DataField="TypeB" HeaderText="Type B" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="60px" />
                            <asp:BoundField DataField="TypeC" HeaderText="Type C" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="60px" />
                            <asp:BoundField DataField="Noofunit" HeaderText="Total units" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70px" />
                            <asp:BoundField DataField="Total" HeaderText="Total sft" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="60px" />
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
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div id="dvToHide">
                    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="fnPrint();" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
