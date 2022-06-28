<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MsgBox.ascx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.MsgBox.MsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<link href="../Style/modelpopup.css" rel="Stylesheet" type="text/css" />
<asp:UpdatePanel ID="uPnlMessage" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div>
            <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="MessageBox"
                BackgroundCssClass="mod_background" OkControlID="btnOk" CancelControlID="btnOk">
            </ajx:ModalPopupExtender>
            <asp:HiddenField ID="hfMessage" runat="server" />
            <asp:Panel ID="MessageBox" runat="server">
                <div style="width: 500px; height: 200px; margin-top: 25px;">
                    <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
                        <tr>
                            <td class="modelpopup_boxtopleft">
                                &nbsp;
                            </td>
                            <td class="modelpopup_boxtopcenter">
                                &nbsp;
                            </td>
                            <td class="modelpopup_boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="modelpopup_boxleft">
                                &nbsp;
                            </td>
                            <td class="modelpopup_box_bg">
                                <div style="width: 100px; float: left; margin-top: 10px;">
                                    <asp:HyperLink ID="CloseModelPopup" runat="server">
                                        <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                            ID="btnImage" runat="server" />
                                    </asp:HyperLink>
                                </div>
                                <div style="float: left; width: 350px; margin-top: 40px; margin-left: 10px;">
                                    <asp:Label ID="lblErrorMessage" runat="server" Text="Something goes wrong, please try again later."></asp:Label>
                                </div>
                                <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                    <tr>
                                        <td align="center" valign="middle">
                                            <asp:Button ID="btnOk" runat="server" Text="Ok" Style="display: inline-block;" />
                                            <%--<asp:Button ID="btnCancel" runat="server" Text="Cancel" Style="display: inline-block;"/>--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="modelpopup_boxright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="modelpopup_boxbottomleft">
                                &nbsp;
                            </td>
                            <td class="modelpopup_boxbottomcenter">
                            </td>
                            <td class="modelpopup_boxbottomright">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
