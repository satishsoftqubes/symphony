<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MsgBox.ascx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.MsgBox.MsgBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajx" %>
<link href="../Style/modelpopup.css" rel="Stylesheet" type="text/css" />
<asp:UpdatePanel ID="uPnlErrorMessage" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div>
            <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="MessageBox"
                BackgroundCssClass="mod_background" OkControlID="btnOk" CancelControlID="btnOk">
            </ajx:ModalPopupExtender>
            <asp:HiddenField ID="hfMessage" runat="server" />
            <asp:Panel ID="MessageBox" runat="server">
                <div style="width: 500px; height: 200px; margin-top: 25px;">
                    <div class="box_col1">
                        <div class="box_head">
                            <span>
                                <asp:Literal ID="litHeaderCustomeMessage" runat="server"></asp:Literal></span>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="box_form">
                            <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <asp:Button ID="btnOk" runat="server" />
                                    </td>
                                    <%--<td align="left" valign="middle">
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                                </td>--%>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
