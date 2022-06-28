<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlVoidReport.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Report.CtrlVoidReport" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnVoidReportPrint() {
        window.open("VoidReportPrint.aspx", "Void Report", "height=600,width=1000,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
    }
</script>
<asp:UpdatePanel ID="uPnlRoomNights" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="boxtopleft">
                    &nbsp;
                </td>
                <td class="boxtopcenter">
                    Void Report
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
                    <table width="100%" cellpadding="3" cellspacing="2" style="background-color: #fff;"
                        border="0">
                        <tr>
                            <td style="width: 50px; padding-top: 15px;">
                                <asp:Literal ID="litStartDate" runat="server" Text="From"></asp:Literal>
                            </td>
                            <td style="width: 220px; padding-top: 15px;">
                                <asp:TextBox ID="txtStartDate" runat="server" onkeypress="return false;" SkinID="Search"></asp:TextBox>
                                <asp:Image ID="imgSColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                    Height="20px" Width="20px" />
                                <ajx:CalendarExtender ID="calStartDate" runat="server" TargetControlID="txtStartDate"
                                    PopupButtonID="imgSColor">
                                </ajx:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvStartDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtStartDate" Display="Static">
                                </asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 30px; padding-top: 15px;">
                                <asp:Literal ID="litEndDate" runat="server" Text="To"></asp:Literal>
                            </td>
                            <td style="padding-top: 15px; width: 220px;">
                                <asp:TextBox ID="txtEndDate" runat="server" onkeypress="return false;" SkinID="Search"></asp:TextBox>
                                <asp:Image ID="imgEColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                    Height="20px" Width="20px" />
                                <ajx:CalendarExtender ID="calEndDate" runat="server" TargetControlID="txtEndDate"
                                    PopupButtonID="imgEColor">
                                </ajx:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvEndDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtEndDate" Display="Static">
                                </asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 100px; padding-top: 15px;">
                                <asp:Literal ID="ltrSrchGuestName" runat="server" Text="Guest Name"></asp:Literal>
                            </td>
                            <td style="width: 230px; padding-top: 15px;">
                                <asp:TextBox ID="txtSrchGuestName" runat="server"></asp:TextBox>
                            </td>
                            <td style="padding-top: 15px;">
                                <asp:ImageButton ID="imtbtnSearch" ToolTip="Search" runat="server" ImageUrl="~/images/search-icon.png"
                                    Style="border: 0px; vertical-align: middle; display: inline" ValidationGroup="IsRequire"
                                    OnClick="imtbtnSearch_OnClick" />
                                &nbsp;&nbsp;
                                <asp:ImageButton ID="imgbtnXLSX" Text="" Style="vertical-align: middle; display: inline;"
                                    ValidationGroup="IsRequire" ToolTip="ExportToXLSX" runat="server" OnClick="imgbtnXLSX_OnClick"
                                    ImageUrl="~/images/report_xlsx.png" OnClientClick="fnDisplayCatchErrorMessage()" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnPrintVoidTrnas" runat="server" OnClick="btnPrintVoidReport_OnClick" Style="vertical-align: middle; display: inline;" Text="Print" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" style="padding-top: 15px;">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="vertical-align: top;">
                                            <div class="box_head">
                                                <span>
                                                    <asp:Literal ID="litRoomNights" runat="server" Text="Void Transactions"></asp:Literal>
                                                </span>
                                            </div>
                                            <div class="clear">
                                            </div>
                                            <div class="box_content">
                                                <asp:GridView ID="gvVoidTrnasactions" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                    Width="100%" OnPageIndexChanging="gvVoidTrnasactions_PageIndexChanging">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrInqSrNo" runat="server" Text="No."></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrReservationNo" runat="server" Text="Booking #"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="55px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrBookNo" runat="server" Text="Trnas. #"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "BookNo")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="65px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrAmount" runat="server" Text="Amount"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "Amount")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="130px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrEntryDate" runat="server" Text="Void Date"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "EntryDate", "{0:dd-MM-yyyy hh:mm tt}")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Guest Name"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrRoomNo" runat="server" Text="Room No."></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "DisplayRoomNo")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrVoidReason" runat="server" Text="Void Reason"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "VoidReason")%>
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
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="imgbtnXLSX" />
        <asp:PostBackTrigger ControlID="btnPrintVoidTrnas" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="uPnlRoomNights" ID="UpdateProgressRoomNight"
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
