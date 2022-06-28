<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MsgBx.ascx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.MsgBox.MsgBx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<asp:UpdatePanel ID="uPnlErrorMessage" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<div>
    <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="MessageBox"
        BackgroundCssClass="mod_background" OkControlID="btnOk" CancelControlID="btnCancel">
    </ajx:ModalPopupExtender>
    <asp:HiddenField ID="hfMessage" runat="server" />
    <asp:Panel ID="MessageBox" runat="server">
        <div style="width: 500px; margin-top: 25px;">
            <div style="margin:3px;">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="boxtopleft">
                        &nbsp;
                    </td>
                    <td class="boxtopcenter">
                        MESSAGE
                    </td>
                    <td class="boxtopright">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="boxleft">
                    </td>
                    <td>
                        <div class="box_form" style="background-color:White;">
                            <table width="100%">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblErrorMessage" runat="server" Text="Error Message Generate"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="center" valign="middle">
                                                    <asp:Button ID="btnOk" runat="server" Text="Ok" Style="display:inline-block;" />
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Style="display:inline-block;" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
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
            </div>
        </div>
    </asp:Panel>
</div>
    </ContentTemplate>
</asp:UpdatePanel>
