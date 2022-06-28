<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlQuickRoomReservation.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.CtrlQuickRoomReservation" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%--<style type="text/css">
    .maintable
    {
        border: 1px solid gray;
        height: 150px;
    }
    .tobookcell
    {
        background-color: #f3f3f5;
    }
    .header
    {
        background-color: #dddddf;
        text-align: center;
        width: 35px;
    }
    .roomname
    {
        background-color: #dddddf;
        padding-left: 5px;
    }
    .commonheader
    {
        background-color: Gray;
        text-align: center;
        width: 100px;
    }
</style>--%>
<script language="javascript" type="text/javascript">
    function fnClick(id) {

        if (document.getElementById(id).style.backgroundColor == 'Gray') {
            document.getElementById(id).style.backgroundColor = '#f3f3f5';
        }
        else {
            document.getElementById(id).style.backgroundColor = 'Gray';
        }
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="content">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="boxtopleft">
                        &nbsp;
                    </td>
                    <td class="boxtopcenter">
                        <asp:Literal ID="litMainHeader" runat="server" Text="Quick Room Reservation"></asp:Literal>
                        <div style="float: right;">
                            View Type :
                            <asp:DropDownList ID="ddlViewType" runat="server" SkinID="nowidth" Width="150px"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlViewType_OnSelectedIndexChanged">
                                <asp:ListItem Text="Daily" Value="Daily"></asp:ListItem>
                                <asp:ListItem Text="Weekly" Value="Weekly"></asp:ListItem>
                                <asp:ListItem Text="Monthly" Value="Monthly"></asp:ListItem>
                                <asp:ListItem Text="Quarterly" Value="Quarterly"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
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
                            <asp:Label ID="lblCalanderToFrom" runat="server" Style="font-size: 13px; font-weight: bold;" Visible="false"></asp:Label>
                            <div style="padding-bottom: 2px;">
                            </div>
                            <%--<div style="height: 400px; overflow:scroll;">--%>
                            <div id="dvTest" runat="server">
                            </div>
                            <%--</div>--%>
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
            <div class="clear_divider">
            </div>
        </td>
    </tr>
</table>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
