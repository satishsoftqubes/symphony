<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InfraServiceCharges.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Report.InfraServiceCharges" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
    function openViewer() {
        var Preview = '<%=IsPreview%>';
        window.open("../../ReportFiles/frmViewer.aspx?preview=" + Preview);
    }
</script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" >
            <tr>
                <td class="boxtopleft">
                    &nbsp;
                </td>
                <td class="boxtopcenter">
                    Infra Service Charge Report
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
                    <table cellpadding="3" cellspacing="2" style="background-color: #fff;">
                        <tr>
                            <td style="width: 50px;">
                                <asp:Literal ID="litStartDate" runat="server" Text="From"></asp:Literal>
                            </td>
                            <td style="width: 300px;">
                                <asp:TextBox ID="txtStartDate" runat="server" onkeypress="return false;" SkinID="Search"></asp:TextBox>
                                <asp:Image ID="imgSColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                    Height="20px" Width="20px" />
                                <ajx:CalendarExtender ID="calStartDate" runat="server" TargetControlID="txtStartDate"
                                    PopupButtonID="imgSColor">
                                </ajx:CalendarExtender>
                            </td>
                            <td style="width: 50px;">
                                <asp:Literal ID="litEndDate" runat="server" Text="To"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndDate" runat="server" onkeypress="return false;" SkinID="Search"></asp:TextBox>
                                <asp:Image ID="imgEColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                    Height="20px" Width="20px" />
                                <ajx:CalendarExtender ID="calEndDate" runat="server" TargetControlID="txtEndDate"
                                    PopupButtonID="imgEColor">
                                </ajx:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" style="width: 100px;">
                            </td>
                            <td>
                                <asp:RadioButtonList runat="server" ID="rdbReportType" RepeatDirection = "Horizontal">
                                    <asp:ListItem Text="Detail" Value="DETAIL"></asp:ListItem>
                                    <asp:ListItem Text="Summary" Value="SUMMARY" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <div style="float: Left;">
                                    <asp:Button ID="btnPreview" Text="View" Style="float: left; margin-left: 5px;" runat="server"
                                        ImageUrl="~/images/save.png" OnClick="btnPreview_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="box_head">
                                    <span>
                                        <asp:Literal ID="litInfraSrvcCharge" runat="server" Text="Infra Service Charge"></asp:Literal>
                                    </span>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="box_content">
                                    <asp:GridView ID="gvInfraServiceCharge" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                        Width="100%">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrMOP" runat="server" Text="Mode of Payment"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMOP" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "MOP")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrAmount" runat="server" Text="Amount"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Amount")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="padding: 10px;">
                                                <b>
                                                    <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label>
                                                </b>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <div style="float:right; padding-right:4px;">
                                        <b>Total</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Literal ID="ltrTotalAmount" runat="server" ></asp:Literal> </b>
                                    </div>
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
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
