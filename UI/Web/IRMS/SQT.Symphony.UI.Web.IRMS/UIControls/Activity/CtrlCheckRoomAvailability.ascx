<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCheckRoomAvailability.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Activity.CtrlCheckRoomAvailability" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<style type="text/css">
    .availableroom
    {
        background-color: #2e8b57;
    }
    
    .bookedroom
    {
        background-color: #0080FF;
    }
    
    .oosroom
    {
        background-color: Maroon;
    }
    
    .checkinroom
    {
        background-color: #0101DF;
    }
    
    .maintable
    {
        border: 1px solid gray;
        min-height: 500px;
        overflow: scroll;
    }
    
    .cellheader
    {
        background-color: #dcdddf;
        border-left: 1px solid Gray;
        border-bottom: 1px solid Gray;
        text-align: center;
        width: 35px;
    }
    .roomname
    {
        background-color: #dcdddf; /*border-bottom: 1px solid Gray;*/
        padding-left: 5px;
    }
    .commonheader
    {
        background-color: #dcdddf;
        border-bottom: 1px solid Gray;
        text-align: center;
        width: 100px;
    }
</style>
<style type="text/css">
    #progressBackgroundFilter
    {
        position: fixed;
        top: 0px;
        width: 100%;
        height: 100%;
        bottom: 0px;
        left: 0px;
        right: 0px;
        overflow: hidden;
        padding: 0;
        margin: 0;
        background-color: #000;
        filter: alpha(opacity=50);
        opacity: 0.5;
        z-index: 1111111;
    }
    #processMessage
    {
        position: fixed;
        top: 50%;
        left: 50%;
        padding: 10px;
        width: 30px;
        border-radius: 10px;
        z-index: 1111112;
        background-color: #fff;
        border: solid 1px #efefef;
    }
</style>
<asp:UpdatePanel ID="updCheckRoomAvailability" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                ROOM AVAILABILITY
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
                                <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td>
                                            <%if (IsInsert)
                                              { %>
                                            <div class="ResetSuccessfully">
                                                <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                    <img src="../../images/success.png" />
                                                </div>
                                                <div>
                                                    <asp:Label ID="lblRoomAvailmsg" runat="server"></asp:Label></div>
                                                <div style="height: 10px;">
                                                </div>
                                            </div>
                                            <% }%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td style="width: 88px;">
                                                        <asp:Literal ID="litSRoomType" runat="server" Text="Room Type"></asp:Literal>&nbsp;&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSearchRoomType" runat="server" Style="width: 180px;">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rvfddlSearchRoomType" runat="server" ControlToValidate="ddlSearchRoomType"
                                                            SetFocusOnError="true" CssClass="rfv_ErrorStar" InitialValue="00000000-0000-0000-0000-000000000000"
                                                            ErrorMessage="*" ValidationGroup="RoomAvailability"></asp:RequiredFieldValidator>
                                                        <asp:ImageButton ID="btnSearch" Style="border: 0px; vertical-align: middle; margin-top: 0px;
                                                            margin-left: 5px;" runat="server" ImageUrl="~/images/search-icon.png" OnClick="btnSearch_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage()" ValidationGroup="RoomAvailability" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="pageinfodivider">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div>
                                                <div style="padding-bottom: 10px;">
                                                    Room Type: <b>
                                                        <asp:Literal ID="litDisplayRoomType" runat="server" Text="-"></asp:Literal></b><br />
                                                    <div style="height: 5px;">
                                                    </div>
                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td>
                                                                <div style="float: right;">
                                                                    <table width="380px">
                                                                        <tr style="height: 30px;">
                                                                            <td align="center" style="font-weight: bold; color: White; background-color: #2e8b57;">
                                                                                Available
                                                                            </td>
                                                                            <td align="center" style="font-weight: bold; color: White; background-color: #0101DF;">
                                                                                Occupied
                                                                            </td>
                                                                            <td align="center" style="font-weight: bold; color: White; background-color: #0080FF;">
                                                                                Booked
                                                                            </td>
                                                                            <td align="center" style="font-weight: bold; color: White; background-color: Maroon;">
                                                                                Out of Service
                                                                            </td>
                                                                            <td align="center" style="font-weight: bold; color: White; background-color: Gray;">
                                                                                Under Cleaning
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div id="dvChart" visible="false" runat="server" style="height: 500px; width: 1000px;
                                                    overflow: auto; padding: 10px;">
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
                </td>
            </tr>
        </table>
        <div style="float: right; padding-right: 10px;">
            <asp:Button ID="btnNotAvailable" runat="server" Text="Not Available" Style="display: inline;"
                OnClick="btnNotAvailable_Click" />
            <asp:Button ID="btnSendEmailToFDE" runat="server" Text="Send Email To FDE" Style="display: inline;"
                OnClick="btnSendEmailToFDE_Click" ValidationGroup="RoomAvailability" OnClientClick="fnDisplayCatchErrorMessage()" />
            <asp:Button ID="btnBackToList" runat="server" Text="Back To List" Style="display: inline;"
                OnClick="btnBackToList_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updCheckRoomAvailability" ID="UpdateProgressCheckRoomAvailability"
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
