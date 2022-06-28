<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlockDetail.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Configurations.BlockDetail" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnRowCommand(unitValue) {

        document.getElementById('<%= hfUnitValue.ClientID %>').value = unitValue;

        __doPostBack('ctl00$ContentPlaceHolder1$ucBlockDetail$lnkToRedirect', '');
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
        z-index: 1000;
    }
    #processMessage
    {
        position: fixed;
        top: 50%;
        left: 50%;
        padding: 10px;
        width: 30px;
        border-radius: 10px;
        z-index: 1001;
        background-color: #fff;
        border: solid 1px #efefef;
    }
</style>
<asp:HiddenField ID="hfUnitValue" runat="server" />
<asp:UpdatePanel ID="updPropertyList" runat="server">
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
                                BLOCK INFORMATION
                                <div style="visibility: hidden;">
                                    <asp:LinkButton ID="lnkToRedirect" runat="server" OnClick="lnkToRedirect_OnClick" OnClientClick="fnDisplayCatchErrorMessage()"></asp:LinkButton>
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
                            <td>
                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                    <tr>
                                        <td style="padding-top: 15px;" width="140px">
                                            <b>Block :</b>
                                        </td>
                                        <td style="padding-top: 15px;">
                                            <b>
                                                <asp:Label ID="lblBlockName" runat="server"></asp:Label></b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Property :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPropertyName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="padding-bottom: 10px;">
                                            No. of Floors :
                                        </td>
                                        <td style="padding-bottom: 10px;">
                                            <asp:Label ID="lblNoOfFloors" Width="350px" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="pagesubheader">
                                            <asp:Literal ID="Literal1" runat="server" Text="Unit Information"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox" colspan="2" style="padding-bottom: 10px;">
                                            <div style="border: 1px solid #C9C9C9; padding: 4px;">
                                                FLOOR
                                            </div>
                                            <div style="overflow: auto; width: 720px;">
                                                <style type="text/css">
                                                    .dTableBox table
                                                    {
                                                        width: auto !important;
                                                    }
                                                    .dTableBox Table td
                                                    {
                                                        border-top: 0px;
                                                    }
                                                </style>
                                                <asp:GridView ID="grdUnitInfo" runat="server" SkinID="gvAutoColumns" ShowHeader="false"
                                                    Width="100%" OnRowDataBound="grdUnitInfo_RowDataBound" OnPageIndexChanging="grdUnitInfo_OnPageIndexChanging"
                                                    CssClass="grid_content">
                                                    <EmptyDataTemplate>
                                                        <div class="pagecontent_info">
                                                            <div class="NoItemsFound">
                                                                <h2>
                                                                    <asp:Literal ID="Literal5" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                            </div>
                                                        </div>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                    </tr>
                                </table>
                            </td>
                            <td class="boxright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td align="right">
                                <asp:Button ID="btnCancel" runat="server" Style="display: inline-block;" Text="Back"
                                    OnClick="btnCancel_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
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
                    <%-- <div class="clear">
                        <uc1:MsgBox ID="MessageBox" runat="server" />
                    </div>--%>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updPropertyList" ID="UpdateProgressPropertyList"
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
