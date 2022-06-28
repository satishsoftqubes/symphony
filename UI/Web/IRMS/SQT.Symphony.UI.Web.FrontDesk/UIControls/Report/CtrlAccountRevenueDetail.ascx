<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAccountRevenueDetail.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Report.CtrlAccountRevenueDetail" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
            <tr>
                <td class="boxtopleft">
                    &nbsp;
                </td>
                <td class="boxtopcenter">
                    Account Revenue Report
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
                    <table width="100%" cellpadding="3" cellspacing="2" style="background-color: #fff;">
                        <tr>
                            <td style="width:100px;">
                                <asp:Literal ID="litStartDate" runat="server" Text="End Date"></asp:Literal>
                            </td>
                            <td>                               
                                <asp:TextBox ID="txtStartDate" runat="server" onkeypress="return false;" SkinID="Search"></asp:TextBox>
                                <asp:Image ID="imgSColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                    Height="20px" Width="20px" />
                                <ajx:CalendarExtender ID="calStartDate" runat="server" TargetControlID="txtStartDate"
                                    PopupButtonID="imgSColor">
                                </ajx:CalendarExtender>
                            </td>                        
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                <asp:Literal ID="litAccountGroup" runat="server" Text="Account Group" ></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlAcctGroup" runat="server" AutoPostBack="true"
                                    onselectedindexchanged="ddlAcctGroup_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                          <tr>
                            <td align="left" valign="top">
                                <asp:Literal ID="litAccountName" runat="server" Text="Account Name"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlAccountName" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                <asp:Literal ID="ltPeriod" runat="server" Text="Period"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPeriod" runat="server">
                                    <asp:ListItem Selected="True" Text="DAILY"></asp:ListItem>
                                    <asp:ListItem Text="WEEKLY"></asp:ListItem>
                                    <asp:ListItem Text="MONTHLY"></asp:ListItem>
                                    <asp:ListItem Text="YEARLY"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>                       
                        <tr>
                            <td>
                            </td>
                            <td>
                                <div style="float: Left;">
                                    <asp:Button ID="btnPreview" Text="View" Style="float: left; margin-left: 5px;" runat="server"
                                        ImageUrl="~/images/save.png" OnClick="btnPreview_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                   <%-- <asp:ImageButton ID="imgbtnPDF" Text="" Style="float: left; margin-left: 5px;" ToolTip="ExportToPDF"
                                        runat="server" ImageUrl="~/images/report_pdf.png" OnClick="imgbtnPDF_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                    <asp:ImageButton ID="imgbtnXLSX" Text="" Style="float: left; margin-left: 5px;" ToolTip="ExportToXLSX"
                                        runat="server" ImageUrl="~/images/report_xlsx.png" OnClick="imgbtnXLSX_Click"
                                        OnClientClick="fnDisplayCatchErrorMessage()" />--%>
                                </div>
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
        <asp:PostBackTrigger ControlID="btnPreview" />
        <%--<asp:PostBackTrigger ControlID="imgbtnPDF" />
        <asp:PostBackTrigger ControlID="imgbtnXLSX" />--%>
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
