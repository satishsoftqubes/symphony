<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckInLogPrint.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.CheckInLogPrint" %>

<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <asp:ScriptManager ID="scptInnerHTML" runat="server">
    </asp:ScriptManager>
    <div style="width: 800px; margin: 0; height: 40px; text-align: center;">
        <img src="<%=Page.ResolveUrl("~/images/Logo - registerd_small.jpg") %>" style="width: 100px;"
            border="0" alt="" />
    </div>
    <div style="text-align: center; width: 800px; margin-bottom: 35px;">
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
                            <asp:Literal ID="litMainHeader" runat="server" Text="Check In log"></asp:Literal>
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
                                        <td align="right" style="font-size: 15px; padding-right: 15px;">
                                            <b>Average time taken:
                                                <asp:Literal ID="ltrAverageTimeTaken" runat="server"></asp:Literal></b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="clear">
                                            </div>
                                            <div class="clear">
                                            </div>
                                            <div class="box_content">
                                                <asp:GridView ID="gvCheckInLog" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                    OnRowDataBound="gvCheckInLog_RowDataBound" Width="100%" SkinID="gvNoPaging">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrFolioDetailsSrNo" runat="server" Text="No."></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGvOperationDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckInStartTime")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrName" runat="server" Text="Guest Name"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrSrFolioNo" runat="server" Text="Folio No."></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "FolioNo")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrFrontDeskPersonName" runat="server" Text="Front Desk Exec."></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "UserName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrStratTime" runat="server" Text="Strat Time"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGvStartTime" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckInStartTime")).ToString("hh:mm:ss:tt")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrEndTime" runat="server" Text="End Time"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGvEndTime" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckInEndTime")).ToString("hh:mm:ss:tt")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrTimeTaken" runat="server" Text="Time Taken"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Literal ID="ltrTimetaken" runat="server"></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <div style="padding: 10px;">
                                                            <b>
                                                                <asp:Label ID="lblNoRecordFound" runat="server" Text="No record found."></asp:Label>
                                                            </b>
                                                        </div>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
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
            <td>
                <div id="dvToHide" style="padding-bottom: 10px; padding-top: 10px; padding-left: 10px;
                    padding-right: 10px;" align="center">
                    <asp:Button ID="btnCancelPritnRegFrom" runat="server" Style="display: inline;" Text="Print"
                        OnClientClick="fnPrint();" />
                    <asp:Button ID="btnBack" Visible="false" runat="server" Text="Back" Style="display: inline;" />
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
