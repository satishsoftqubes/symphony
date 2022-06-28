<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlDocumentList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlDocumentList" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>

<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="content" style="padding-left: 0px; width: 66.66%">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                <tr>
                    <td class="boxtopleft">
                        &nbsp;
                    </td>
                    <td class="boxtopcenter">
                        DOCUMENTATION
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
                        <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                        <table cellpadding="2" cellspacing="0" border="0" width="99%">
                            <%-- <tr>
                                        <td>
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td align="left" valign="top" style="width: 15%;">
                                                        <asp:Literal ID="litPropertyName" runat="server" Text="Document Name"></asp:Literal>
                                                    </td>
                                                    <td align="left" valign="top" style="width: 20%;">
                                                        <asp:TextBox ID="txtPropertyName" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="left" valign="bottom">
                                                        <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                            OnClick="btnSearch_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="pagesubheader">
                                            <asp:Literal ID="litList" runat="server" Text="DOCUMENT INFORMATION"></asp:Literal>
                                        </td>
                                    </tr>--%>
                            <tr>
                                <td class="dTableBox" style="padding: 10px 10px 10px 10px;">
                                    <asp:GridView ID="grdDocuemtnList" runat="server" AutoGenerateColumns="False" Width="100%"
                                        SkinID="gvNoPaging" OnRowDataBound="grdDocuemtnList_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Document Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                ItemStyle-Width="350px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDocumentName" runat="server" Text='<%#GetName(DataBinder.Eval(Container.DataItem, "DocumentName"))%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="AssociationType" HeaderText="Type" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px" />
                                            <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDateOfSubmission" Width="150px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateOfSubmission") != DBNull.Value ? Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DateOfSubmission")).ToString(DateFormat) : ""%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="View" ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <a href='../../Document/<%# DataBinder.Eval(Container.DataItem, "DocumentName")%>'
                                                        target="_blank" style="border: 0px;">
                                                        <asp:Image ID="btnView" ImageUrl="~/images/view.png" runat="server" /></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div class="pageinfo">
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
                                        <td align="left" valign="top" class="pagecontent_info">
                                            <p class="pageInformation">
                                                <b>Fill Control Number SetUp have four different part</b><br />
                                                <br />
                                            </p>
                                            1) Manage Control Number Information
                                        </td>
                                    </tr>--%>
                        </table>
                        <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
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
            <div id="errormessage" class="clear" style="display: none;">
                <uc1:MsgBox ID="MessageBox" runat="server" />
            </div>
        </td>
    </tr>
</table>
