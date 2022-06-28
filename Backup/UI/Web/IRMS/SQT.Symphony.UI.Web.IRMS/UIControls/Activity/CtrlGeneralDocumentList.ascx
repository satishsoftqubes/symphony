<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlGeneralDocumentList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Activity.CtrlGeneralDocumentList" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">
    function funCloseDocument() {
        document.getElementById('<%= lblMessage.ClientID %>').style.display = "none";
        document.getElementById('<%= tblDocument.ClientID %>').style.display = "none";
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function stopKey(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 8) && (node.type == "text")) { return false; }
        else if ((evt.keyCode == 9) && (node.type == "text")) { return true; }
        else if ((evt.keyCode == 46) && (node.type == "text")) { return false; }
        else { return false; }
    }

</script>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
    <tr>
        <td class="content" style="padding-left: 0px; width: 66.66%">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                <tr>
                    <td class="boxtopleft">
                        &nbsp;
                    </td>
                    <td class="boxtopcenter">
                        DOCUMENTS
                    </td>
                    <td class="boxtopright">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="boxleft">
                        &nbsp;
                    </td>
                    <td style="padding-top: 10px;">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                            <tr>
                                <%--<td align="left" valign="middle" style="width: 165px; padding-left:11px;">
                                    Document &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtSearchDocument" runat="server"></asp:TextBox>
                                </td>--%>
                                <td align="left" valign="middle">
                                    <table>
                                        <tr>
                                            <td width="100px">
                                                Category
                                            </td>
                                            <td colspan="3">
                                                <asp:DropDownList ID="ddlCategory" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                    <asp:ListItem Value="Company" Text="Company"></asp:ListItem>
                                                    <asp:ListItem Value="Property" Text="Property"></asp:ListItem>
                                                    <asp:ListItem Value="Investor" Text="Investor"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; vertical-align: middle; margin-left: 5px;" OnClick="btnSearch_Click"
                                                    Visible="false" />
                                            </td>
                                        </tr>
                                        <tr id="trPropandDoc" runat="server" visible="false">
                                            <td width="100px">
                                                Property Name
                                            </td>
                                            <td width="250px">
                                                <asp:DropDownList ID="ddlSearchPropertyName" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="100px">
                                                Document Type
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSearchDocumentType" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr id="trDate" runat="server" visible="false">
                                            <td>
                                                From Date
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearchFromDate" runat="server" onkeydown="return stopKey(event);"></asp:TextBox>
                                                <asp:Image ID="imgFromDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png" />
                                                <ajx:CalendarExtender ID="calFromDate" runat="server" PopupButtonID="imgFromDate"
                                                    TargetControlID="txtSearchFromDate" CssClass="MyCalendar">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" onclick="fnClearDate('<%= txtSearchFromDate.ClientID %>');" />
                                            </td>
                                            <td>
                                                To Date
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearchToDate" runat="server" onkeydown="return stopKey(event);"></asp:TextBox>
                                                &nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="lblDateErrorMsg" runat="server" Style="color: Red;"></asp:Label>&nbsp;&nbsp;
                                                <asp:Image ID="imgToDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png" />
                                                <ajx:CalendarExtender ID="calToDate" runat="server" PopupButtonID="imgToDate" TargetControlID="txtSearchToDate"
                                                    CssClass="MyCalendar">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" id="imgClearDate" style="vertical-align: middle;"
                                                    onclick="fnClearDate('<%= txtSearchToDate.ClientID %>');" />
                                                <asp:ImageButton ID="btnPropertySearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; vertical-align: middle; margin-left: 5px;" OnClick="btnSearch_Click"
                                                    Visible="false" />
                                            </td>
                                        </tr>
                                        <tr id="trInvandUnit" runat="server" visible="false">
                                            <td>
                                                Investor Name
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlInvestor" runat="server">
                                                </asp:DropDownList>
                                                <%--<asp:TextBox ID="txtSearchInvestorName" runat="server"></asp:TextBox>--%>
                                            </td>
                                            <td>
                                                Unit No.
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearchUnitNo" runat="server"></asp:TextBox>
                                                <asp:ImageButton ID="btnInvestorSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; vertical-align: middle; margin-left: 5px;" OnClick="btnSearch_Click"
                                                    Visible="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="dTableBox" style="padding: 10px 10px 10px 10px;" colspan="2">
                                    <div style="height: 335px; overflow: auto;">
                                        <asp:GridView ID="gvDocumentList" runat="server" AutoGenerateColumns="false" OnRowCommand="gvDocumentList_RowCommand"
                                            ShowHeader="true" ShowFooter="false" OnPageIndexChanging="gvDocumentList_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="InvestorName" HeaderText="Investor Name" ItemStyle-Width="150px" />
                                                <asp:BoundField DataField="PropertyName" HeaderText="Property" ItemStyle-Width="120px" />
                                                <%--<asp:TemplateField HeaderText="Document Name" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkViewDocument" runat="server" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "DocumentName")%>'
                                                            Style="border: 0px;" OnClientClick="return funCloseDocument();" Text='<%#GetName(DataBinder.Eval(Container.DataItem, "DocumentName"))%>'>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:BoundField DataField="UNITNUMBER" HeaderText="Unit No." ItemStyle-Width="55px" />
                                                <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    ItemStyle-Width="65px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDateOfSubmission" Width="65px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateOfSubmission") != DBNull.Value ? Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DateOfSubmission")).ToString(DateFormat) : ""%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="DocumentType" HeaderText="Type" ItemStyle-Width="100px" />
                                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Left"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkViewDocument" runat="server" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "DocumentName")%>'
                                                            Style="border: 0px;" Text="View / Download">
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
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
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-top: 15px; font: 15px; color: Red;" align="center">
                                    <asp:Label ID="lblMessage" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="boxright">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="boxleft">
                        &nbsp;
                    </td>
                    <td>
                        <table width="100%" cellpadding="3" cellspacing="3" id="tblDocument" runat="server">
                            <tr>
                                <td>
                                    <asp:MultiView ID="mvDocument" runat="server">
                                        <asp:View ID="vPDF" runat="server">
                                            <table style="padding-left: 5px;" width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <div style="overflow: auto; width: 720px;">
                                                            <iframe id="fileview" scrolling="auto" runat="server" height="500px" width="720px"
                                                                style="visibility: visible;"></iframe>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 5px;" align="center">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnPDFCancel" runat="server" Text="Cancel" OnClick="btnPDFCancel_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vImage" runat="server">
                                            <table style="padding-left: 5px;" width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="center" valign="middle" style="padding-bottom: 20px;">
                                                        <div style="width: 720px; overflow: auto;">
                                                            <asp:Image ID="imgImageDoc" runat="server" /></div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 5px;" align="right">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnImageCancel" runat="server" Text="Cancel" OnClick="btnImageCancel_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="boxright">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
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
                <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
            </div>
        </td>
    </tr>
</table>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
