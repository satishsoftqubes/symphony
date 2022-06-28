<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSearchKeyandRoomNo.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlSearchKeyandRoomNo" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updSearchKeyAndRoom" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server" Text="Search Room/Key"></asp:Literal>
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
                                    <table width="80%">
                                        <tr>
                                            <td style="border-bottom: 1px solid Gray;">
                                                <b>Search key</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding-bottom: 100px;">
                                                <table cellpadding="2" cellspacing="2" border="0">
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litRoomNo" runat="server" Text="Room No"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRoomNo" runat="server" Style="width: 200px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <div>
                                                                <asp:Button ID="btnSearchKey" runat="server" Text="Search" OnClick="btnSearchKey_Click" /></div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:Literal ID="litKeyName" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border-bottom: 1px solid Gray;">
                                                <b>Search Room</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <table cellpadding="2" cellspacing="2" border="0">
                                                    <tr>
                                                        <td class="isrequire">
                                                            <asp:Literal ID="litKey" runat="server" Text="Key"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtKey" runat="server" Style="width: 200px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <div>
                                                                <asp:Button ID="btnsearchRoom" runat="server" Text="Search" OnClick="btnsearchRoom_Click" /></div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:Literal ID="litRoomName" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                </table>
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
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updSearchKeyAndRoom" ID="UpSearchKeyAndRoom"
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
