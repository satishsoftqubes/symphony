<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTCompanyPostingPrint.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.BackOffice.GUI.Invoice.RPTCompanyPostingPrint" %>

<%@ Register Src="~/MsgBox/MsgBx.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link id="Link1" href="~/Style/style.css" runat="server" rel="stylesheet" type="text/css" />
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
    <asp:ScriptManager ID="srcptmanaCompPostPrint" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <table width="85%" border="0" cellspacing="0" cellpadding="0" style="margin: 15px 15px 15px 15px;">
        <tr>
            <td class="content">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="boxtopleft">
                            &nbsp;
                        </td>
                        <td class="boxtopcenter">
                            <asp:Literal ID="litMainHeader" runat="server" Text="Company Posting Report"></asp:Literal>
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
                                        <td align="left">
                                            Start Date:&nbsp;<asp:Label ID="lblStartDate" runat="server"></asp:Label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            End Date:&nbsp;<asp:Label ID="lblEndDate" runat="server"></asp:Label>
                                        </td>
                                        <td style="padding-top: 10px; text-align: right; padding-right: 12px;">
                                            <b>
                                                <asp:Literal ID="litTotalAmount" runat="server"></asp:Literal></b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div class="box_content">
                                                <asp:GridView ID="gvCompanyPosting" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                    Width="100%" OnPageIndexChanging="gvCompanyPosting_PageIndexChanging">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrInqSrNo" runat="server" Text="No."></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblCompanyName" runat="server" Text="Company Name"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "CompanyName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                                            ItemStyle-Width="125px">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvTotal" runat="server" Text="Total Amount"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "TotalAmount")%>
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
                    <asp:Button ID="btnCompPostPrint" runat="server" Style="display: inline;" Text="Print"
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
