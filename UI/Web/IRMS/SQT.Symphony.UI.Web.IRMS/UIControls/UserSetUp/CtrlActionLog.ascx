<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlActionLog.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.UserSetUp.CtrlActionLog" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="content" style="padding-left: 0px; width: 66.66%">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                <tr>
                    <td class="boxtopleft">
                        &nbsp;
                    </td>
                    <td class="boxtopcenter">
                        ACTION LOG INFORMATION
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
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table cellpadding="2" cellspacing="0" border="0" width="99%">
                                    <tr>
                                        <td align="left" valign="top">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td align="left" valign="top" style="width: 20%;">
                                                        <asp:Literal ID="litActionObject" runat="server" Text="Action Object Name"></asp:Literal>
                                                    </td>
                                                    <td align="left" valign="top" style="width: 25%;">
                                                        <asp:TextBox ID="txtActionObjectName" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="left" valign="top" style="width: 20%;">
                                                        <asp:Literal ID="Literal2" runat="server" Text="Action Type"></asp:Literal>
                                                    </td>
                                                    <td align="left" valign="top" style="width: 25%;">
                                                        <asp:TextBox ID="txtActionType" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="left" valign="top" rowspan="2">
                                                        <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                            />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litStartDate" runat="server" Text="Start Date"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtStartDate" SkinID="Search" runat="server"></asp:TextBox>
                                                        <asp:Image ID="imbStartDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                            />
                                                        <ajx:CalendarExtender ID="calStartDate" runat="server" PopupButtonID="imbStartDate" CssClass="MyCalendar"
                                                            TargetControlID="txtStartDate">
                                                        </ajx:CalendarExtender>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litEndDate" runat="server" Text="End Date"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEndDate" SkinID="Search" runat="server"></asp:TextBox>
                                                        <asp:Image ID="imgEndDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png" />
                                                        <ajx:CalendarExtender ID="calEndDate" runat="server" PopupButtonID="imgEndDate" TargetControlID="txtEndDate" CssClass="MyCalendar">
                                                        </ajx:CalendarExtender>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="pagesubheader">
                                            <asp:Literal ID="litList" runat="server" Text="Action Log List"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox" style="padding: 10px 10px 10px 10px;">
                                            <asp:GridView ID="gvLoginLogList" runat="server" AutoGenerateColumns="False" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="ActionPerformedBy" HeaderText="Action Perform" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField DataField="ActionPerformedOn" HeaderText="Create Date" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="80px" />
                                                    <asp:BoundField DataField="ActionObject" HeaderText="Action Object" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="80px" />
                                                    <asp:BoundField DataField="ActionType" HeaderText="Action Type" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="80px" />
                                                    <asp:BoundField DataField="LoginInLogID" HeaderText="User" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60px" />
                                                    <asp:TemplateField HeaderText="View" ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:Image ID="btnView" ImageUrl="~/images/View.png" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" class="pagecontent_info">
                                            <p class="pageInformation">
                                                <b>Fill Control Number SetUp have four different part</b><br />
                                                <br />
                                            </p>
                                            1) Manage Control Number Information
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
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
            <div class="clear">
                <uc1:MsgBox ID="MessageBox" runat="server" />
            </div>
        </td>
    </tr>
</table>
