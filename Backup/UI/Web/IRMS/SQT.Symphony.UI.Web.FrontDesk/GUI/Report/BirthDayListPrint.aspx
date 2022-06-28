<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BirthDayListPrint.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Report.BirthDayListPrint" %>

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
                            <asp:Literal ID="litBirthDayHeader" runat="server" Text="Birthday List"></asp:Literal>
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
                                        <td align="right">
                                            <div style="float: right; margin-left: 5px; margin-bottom: 15px;">
                                                <b>
                                                    <asp:Label ID="litBirthDayMonthselected" runat="server"></asp:Label></b></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="clear">
                                            </div>
                                            <div class="clear">
                                            </div>
                                            <div class="box_content">
                                                <asp:GridView ID="gvBirthDayList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                    Width="100%" OnRowDataBound="gvBirthDayList_RowDataBound" OnPageIndexChanging="gvBirthDayList_PageIndexChanging">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrInqSrNo" runat="server" Text="No."></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrBirthDate" runat="server" Text="Birth date"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGvBirthDate" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrInqGuestName" runat="server" Text="Name"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGvInqGuestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrGuestEmail" runat="server" Text="Email"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "Email")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrInqGuestMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "Phone1")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrRoomNo" runat="server" Text="Room No"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGvRoomNo" runat="server" Text=' <%#DataBinder.Eval(Container.DataItem, "DisplayRoomNo")%>'></asp:Label>
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
                    <asp:Button ID="btnPrintBirthDayList" runat="server" Style="display: inline;" Text="Print"
                        OnClientClick="fnPrint();" />
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
