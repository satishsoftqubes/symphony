<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRPTCompanyPosting.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.BackOffice.UIControls.Invoice.CtrlRPTCompanyPosting" %>
<%@ Register Src="~/MsgBox/MsgBx.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script src="../../Scripts/jquery-1.7.1.js"></script>
<script src="../../Scripts/jquery.ui.core.js"></script>
<script type="text/javascript" language="javascript">

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
    function openViewer() {
        var Preview = '<%=IsPreview%>';
        window.open("../../GUI/Invoice/RPTCompanyPostingPrint.aspx");
    }
</script>
<asp:UpdatePanel ID="updCompayPostingReport" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hfDateFormat" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litCompanyPostingReport" runat="server" Text="Company Posting Report"></asp:Literal>
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
                                    <%if (IsMessage)
                                      { %>
                                    <div class="ResetSuccessfully">
                                        <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                            <img src="../../images/success.png" />
                                        </div>
                                        <div>
                                            <asp:Label ID="lblCompanyPostingPost" runat="server"></asp:Label></div>
                                        <div style="height: 10px;">
                                        </div>
                                    </div>
                                    <% }%>
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td>
                                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                    <tr>
                                                        <td style="width: 60px;">
                                                            <asp:Literal ID="litSearchInqGuestarrivalDate" Text="Start Date" runat="server"></asp:Literal>
                                                        </td>
                                                        <td style="width: 181px;">
                                                            <asp:TextBox ID="txtSearchInqGuestarrivalDate" Width="100px" runat="server" SkinID="nowidth"
                                                                onkeydown="return stopKey(event);"></asp:TextBox>
                                                            <asp:Image ID="imgCalInqGuestarrivalDate" ToolTip="Choose Arrival Date" CssClass="small_img"
                                                                runat="server" ImageUrl="~/images/CalanderIcon.png" Height="20px" Width="20px" />
                                                            <ajx:CalendarExtender ID="calInqGuestarrivalDate" PopupButtonID="imgCalInqGuestarrivalDate"
                                                                TargetControlID="txtSearchInqGuestarrivalDate" runat="server">
                                                            </ajx:CalendarExtender>
                                                            <img src="../../images/clear.png" title="Clear Date" id="imgClearDate" style="vertical-align: middle;"
                                                                onclick="fnClearDate('<%= txtSearchInqGuestarrivalDate.ClientID %>');" />
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvStartDate" Style="color: Red;" ValidationGroup="SearchCompany"
                                                                    Display="Dynamic" runat="server" ControlToValidate="txtSearchInqGuestarrivalDate"
                                                                    CssClass="input-notification error png_bg" SetFocusOnError="true"></asp:RequiredFieldValidator></span>
                                                        </td>
                                                        <td style="width: 60px;">
                                                            <asp:Literal ID="litSearchInqGuestDeptDate" Text="End Date" runat="server"></asp:Literal>
                                                        </td>
                                                        <td style="width: 181px;">
                                                            <asp:TextBox ID="txtSearchInqGuestDeptDate" runat="server" SkinID="nowidth" Width="100px"
                                                                onkeydown="return stopKey(event);"></asp:TextBox>
                                                            <asp:Image ID="imgCalSearchInqGuestDeptDate" ToolTip="Choose Departure Date" CssClass="small_img"
                                                                runat="server" ImageUrl="~/images/CalanderIcon.png" Height="20px" Width="20px" />
                                                            <ajx:CalendarExtender ID="calSearchInqGuestDeptDate" PopupButtonID="imgCalSearchInqGuestDeptDate"
                                                                TargetControlID="txtSearchInqGuestDeptDate" runat="server">
                                                            </ajx:CalendarExtender>
                                                            <img src="../../images/clear.png" title="Clear Date" id="imgClearSearchInqGuestDeptDate"
                                                                style="vertical-align: middle;" onclick="fnClearDate('<%= txtSearchInqGuestDeptDate.ClientID %>');" />
                                                            <span>
                                                                <asp:RequiredFieldValidator ID="rfvEndDate" Style="color: Red;" ValidationGroup="SearchCompany"
                                                                    Display="Dynamic" runat="server" ControlToValidate="txtSearchInqGuestDeptDate"
                                                                    CssClass="input-notification error png_bg" SetFocusOnError="true"></asp:RequiredFieldValidator></span>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litSearchInqStatus" Text="Company" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlSearchCompany" runat="server" Style="width: 350px; height: 25px;">
                                                            </asp:DropDownList>
                                                            <asp:ImageButton ID="imtbtnSearCompanyPosting" ToolTip="Search" runat="server" ImageUrl="~/images/search-icon.png"
                                                                Style="border: 0px; vertical-align: middle; display: inline" ValidationGroup="SearchCompany"
                                                                OnClick="imtbtnSearCompanyPosting_Click" />
                                                            <asp:ImageButton ID="imtbtnRefreshCompanyPosting" ToolTip="Reset" runat="server"
                                                                ImageUrl="~/images/clearsearch.png" Style="border: 0px; vertical-align: middle;
                                                                margin: -2px 0 0 10px;" OnClientClick="fnDisplayCatchErrorMessage();" OnClick="imtbtnRefreshCompanyPosting_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="8">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="8" style="padding-top: 13px; text-align: right; padding-right: 9px;">
                                                            <b>
                                                                <asp:Literal ID="litTotalAmount" runat="server"></asp:Literal></b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; height: 200px; overflow: auto;" colspan="8">
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td style="vertical-align: top;">
                                                                        <div class="box_head">
                                                                            <span>
                                                                                <asp:Literal ID="litCompanyPostingGrid" runat="server" Text="Company Posting Report"></asp:Literal>
                                                                            </span>
                                                                        </div>
                                                                        <div class="clear">
                                                                        </div>
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
                                                                                        ItemStyle-Width="125px" >
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
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" style="padding-left: 12px;">
                                                <asp:Button ID="btnPrintCompPosting" Text="Print" runat="server" OnClick="btnPrintCompPosting_Click" />
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
        </table>
        <div id="errormessage" class="clear">
            <uc1:MsgBox ID="MessageBox" runat="server" />
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnPrintCompPosting" />
    </Triggers>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="updCompayPostingReport" ID="UpdateCompanyPosting"
    runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
