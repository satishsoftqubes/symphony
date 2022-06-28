<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlLoginLog.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.UserSetUp.CtrlLoginLog" %>
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
                        LOGIN LOG INFORMATION
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
                                                        <asp:Literal ID="litPropertyName" runat="server" Text="Property Name"></asp:Literal>
                                                    </td>
                                                    <td align="left" valign="top" style="width: 25%;">
                                                        <asp:TextBox ID="txtPropertyName" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="left" valign="top" style="width: 20%;">
                                                        <asp:Literal ID="litUserName" runat="server" Text="User Name"></asp:Literal>
                                                    </td>
                                                    <td align="left" valign="top" style="width: 25%;">
                                                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="left" valign="bottom" rowspan="3">
                                                        <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                            />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litCounterName" runat="server" Text="Counter Name"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCounterName" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litTokenNo" runat="server" Text="Token No"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTokenNo" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litStartDate" runat="server" Text="Start Date"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtStartDate" SkinID="Simple" runat="server"></asp:TextBox>
                                                        <asp:Image ID="imbStartDate" runat="server" CssClass="small_img" ImageUrl="~/images/CalanderIcon.png"/>
                                                        <ajx:CalendarExtender ID="calStartDate" runat="server" PopupButtonID="imbStartDate" CssClass="MyCalendar"
                                                            TargetControlID="txtStartDate">
                                                        </ajx:CalendarExtender>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litEndDate" runat="server" Text="End Date"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEndDate" SkinID="Simple" runat="server"></asp:TextBox>
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
                                            <asp:Literal ID="litList" runat="server" Text="Login Log List"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox" style="padding: 10px 10px 10px 10px;">
                                            <asp:GridView ID="gvLoginLogList" runat="server" AutoGenerateColumns="False" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="PropertyName" HeaderText="Property Name" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="85px" />
                                                    <asp:BoundField DataField="UserName" HeaderText="User Name" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="65px" />
                                                    <asp:BoundField DataField="CounterName" HeaderText="Counter Name" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="90px"/>
                                                    <asp:BoundField DataField="TokenNo" HeaderText="Token No" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left"  />
                                                    <asp:BoundField DataField="LogIn" HeaderText="Login Date" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" />
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
