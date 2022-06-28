<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MarketRateList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Activity.MarketRateList" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function stopKey(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 8) && (node.type == "text")) { return false; }
        else if ((evt.keyCode == 9) && (node.type == "text")) { return true; }
        else if ((evt.keyCode == 46) && (node.type == "text")) { return false; }
        else { return false; }
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function pageLoad(sender, args) {
        $(function () {
            $("#tabs").tabs();
        });

        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });
    }
</script>
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
<asp:UpdatePanel ID="updUnitTypeMarketList" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 100%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                MARKET VALUE OF UNIT
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
                                <table cellpadding="2" cellspacing="0" width="100%" border="0">
                                    <tr>
                                        <td colspan="6" style="padding: 5px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="middle" style="vertical-align: middle; width: 65px; padding-left: 16px;">
                                            Property
                                        </td>
                                        <td style="vertical-align: middle;" width="150px">
                                            <asp:DropDownList ID="ddlSearchProperty" runat="server" Style="width: 140px;">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvSearchProperty" SetFocusOnError="True" ControlToValidate="ddlSearchProperty"
                                                ValidationGroup="IsRequired" InitialValue="00000000-0000-0000-0000-000000000000"
                                                runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left" valign="middle" style="vertical-align: middle; margin-top: 15px;
                                            width: 65px;">
                                            From Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFromDate" runat="server" SkinID="Search" onkeydown="return stopKey(event);"></asp:TextBox>
                                            <asp:Image ID="imgFromDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                Height="20px" Width="20px" />
                                            <ajx:CalendarExtender ID="calFromDate" PopupButtonID="imgFromDate" TargetControlID="txtFromDate"
                                                runat="server">
                                            </ajx:CalendarExtender>
                                            <img src="../../images/clear.png" id="img2" style="vertical-align: middle;" onclick="fnClearDate('<%= txtFromDate.ClientID %>');" />
                                        </td>
                                        <td align="left" valign="middle" style="vertical-align: middle; width: 50px;">
                                            To Date
                                        </td>
                                        <td align="left" valign="middle" style="vertical-align: middle;">
                                            <asp:TextBox ID="txtToDate" runat="server" SkinID="Search" onkeydown="return stopKey(event);"></asp:TextBox>
                                            <asp:Image ID="imgToDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                Height="20px" Width="20px" />
                                            <ajx:CalendarExtender ID="calToDate" PopupButtonID="imgToDate" TargetControlID="txtToDate"
                                                runat="server">
                                            </ajx:CalendarExtender>
                                            <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" onclick="fnClearDate('<%= txtToDate.ClientID %>');" />
                                            <asp:ImageButton ID="imgbtnRateListSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                Style="border: 0px; vertical-align: middle; margin-top: -1px; margin-left: 5px;"
                                                OnClick="imgbtnRateListSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()"
                                                ValidationGroup="IsRequired" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" style="padding: 15px;">
                                            <div class="demo">
                                                <div id="tabs">
                                                    <ul>
                                                        <li><a href="#tabs-1">View List</a></li>
                                                        <li><a href="#tabs-2">View Graph</a></li>
                                                    </ul>
                                                    <div id="tabs-1">
                                                        <table cellpadding="2" cellspacing="0" width="100%" border="0">
                                                            <tr>
                                                                <td>
                                                                    <div>
                                                                        <table width="100%" cellpadding="3" cellspacing="3">
                                                                            <tr>
                                                                                <td>
                                                                                    <div>
                                                                                        <%if (IsMessage)
                                                                                          { %>
                                                                                        <div class="ResetSuccessfully">
                                                                                            <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                                                                <img src="../../images/success.png" />
                                                                                            </div>
                                                                                            <div>
                                                                                                <asp:Label ID="lblErrorMessage" runat="server"></asp:Label></div>
                                                                                            <div style="height: 10px;">
                                                                                            </div>
                                                                                        </div>
                                                                                        <%
                                                                                            }%>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="middle">
                                                                                    <asp:Button ID="btnAddUp" runat="server" Text="Add New" OnClick="btnAdd_Click" Style="float: right;"
                                                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="dTableBox">
                                                                                    <div style="overflow-x: auto; width: 650px">
                                                                                        <style type="text/css">
                                                                                            .dTableBox table tr td, .dTableBox table tr th
                                                                                            {
                                                                                                text-align: center !important;
                                                                                                min-width: 50px !important;
                                                                                            }
                                                                                        </style>
                                                                                        <asp:GridView ID="gvUnitTypeMarketRateList" runat="server" SkinID="gvAutoColumns"
                                                                                            CssClass="grid_content" Width="100%" OnPageIndexChanging="gvUnitTypeMarketRateList_PageIndexChanging"
                                                                                            OnRowDataBound="gvUnitTypeMarketRateList_RowDataBound">
                                                                                            <EmptyDataTemplate>
                                                                                                <div class="pagecontent_info">
                                                                                                    <div class="NoItemsFound">
                                                                                                        <h2>
                                                                                                            <asp:Literal ID="Literal3" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </EmptyDataTemplate>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="middle" style="padding-top: 10px;">
                                                                                    <asp:Button ID="btnAddBottom" runat="server" Text="Add New" OnClick="btnAdd_Click"
                                                                                        Style="float: right;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="tabs-2">
                                                        <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <div class="pagecontent_info" id="message" runat="server" visible="false">
                                                                        <div class="NoItemsFound">
                                                                            <h2>
                                                                                <asp:Literal ID="Literal3" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div style="overflow: auto; width: 450px;">
                                                                        <%--<asp:Chart ID="mstChartPosition" runat="server" BorderlineColor="#E8E9EA"
                                                                            BorderlineWidth="1" BorderlineDashStyle="Solid" BackImageAlignment="TopRight">
                                                                            <ChartAreas>
                                                                                <asp:ChartArea Name="ChartArea1">
                                                                                    <AxisY LineColor="64, 64, 64, 64">
                                                                                        <MajorGrid Enabled="false"></MajorGrid>
                                                                                    </AxisY>
                                                                                    <AxisX LineColor="64, 64, 64, 64" IsStartedFromZero="true">
                                                                                        <MajorGrid Enabled="false"></MajorGrid>
                                                                                    </AxisX>
                                                                                    <Area3DStyle Enable3D="false" />
                                                                                </asp:ChartArea>
                                                                            </ChartAreas>
                                                                        </asp:Chart>--%>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
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
                    <div class="clear">
                    </div>
                </td>
                <td style="width: 2px;">
                    &#160;
                </td>
            </tr>
        </table>        
        <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="Panel1"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="Panel1" runat="server" Style="display: none;">
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
                                <asp:HyperLink ID="HyperLink1" runat="server">
                                    <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                        ID="Image1" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div style="float: left; width: 225px; margin-top: 40px; margin-left: 10px;">
                                <asp:Label ID="Label1" runat="server" Text="Sure you want to delete?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <asp:Button ID="btnUnitTypeMarketRateYes" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnUnitTypeMarketRateYes_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnUnitTypeMarketRateNo" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            Style="display: inline-block;" OnClick="btnUnitTypeMarketRateNo_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
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
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updUnitTypeMarketList" ID="UpdateProgressUnitTypeMarketList"
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
