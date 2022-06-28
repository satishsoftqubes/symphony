<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAccessDenied.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.BackOffice.UIControls.CommonControls.CtrlAccessDenied" %>
<%@ Register Src="~/MsgBox/MsgBx.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<asp:UpdatePanel ID="updAccessDenied" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box" style="border: none;">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server"></asp:Literal>
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
                                <div align="center">
                                    <asp:MultiView ID="mvAccessDenied" runat="server">
                                        <asp:View ID="vGemeralMessage" runat="server">
                                            <div align="center" style="width: 600px; margin: 100px 0px; border: solid 1px #CCCCCE;
                                                background: #F4F4F4;">
                                                <table border="0" width="600" cellspacing="0" cellpadding="7">
                                                    <tr>
                                                        <td width="200">
                                                            <p align="center">
                                                                <img border="0" src="<%=Page.ResolveUrl("~/images/accessDenied.gif") %>" width="128"
                                                                    height="128">
                                                        </td>
                                                        <td width="800">
                                                            <br />
                                                            <p align="left">
                                                                <font face="Arial" style="font-weight: bold; color: #0067A4;" size="5">
                                                                    <asp:Literal ID="litHeaderAccessDenied" runat="server"></asp:Literal></font>
                                                                <br />
                                                                <br />
                                                                <p align="left">
                                                                    <font face="Arial" style="color: #909092;" size="4">
                                                                        <asp:Literal ID="litMsgAccessDeniedM" runat="server"></asp:Literal><br />
                                                                        &nbsp;</font>
                                                                </p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </asp:View>
                                    </asp:MultiView>
                                    <uc1:MsgBox ID="MessageBox" runat="server" />
                                </div>
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
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="updAccessDenied" ID="updProgAccessDenied"
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
