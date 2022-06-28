<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPropertyBlockInformation.ascx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Property.CtrlPropertyBlockInformation" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnRowCommand(unitValue) {

        document.getElementById('<%= hfUnitValue.ClientID %>').value = unitValue;

        __doPostBack('ctl00$ContentPlaceHolder1$ucCtrlPropertyBlockInformation$lnkToRedirect', '');
    }

</script>
<asp:HiddenField ID="hfUnitValue" runat="server" />
<asp:UpdatePanel ID="updPropertyList" runat="server">
    <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litBlockInformation" runat="server"></asp:Literal>
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
                                        <td style="padding-top: 15px;width:45px;">
                                            <b><asp:Literal ID="litBlock" runat="server"></asp:Literal> :</b>
                                        </td>
                                        <td style="padding-top: 15px;">
                                            <b>
                                                <asp:Label ID="lblBlockName" runat="server"></asp:Label></b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litProperty" runat="server"></asp:Literal> :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPropertyName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="padding-bottom: 10px;">
                                            <asp:Literal ID="litNoOfFloors" runat="server"></asp:Literal> :
                                        </td>
                                        <td style="padding-bottom: 10px;">
                                            <asp:Label ID="lblNoOfFloors" Width="350px" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="pagesubheader">
                                            <asp:Literal ID="litUnitInformation" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox" colspan="2" style="padding-bottom: 10px;">
                                            <div style="border: 1px solid #C9C9C9; padding: 4px;">
                                                <asp:Literal ID="litFloor" runat="server"></asp:Literal>
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
                                                                    <asp:Label ID="lblNoUnitFound" runat="server"></asp:Label></h2>
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
                                <asp:Button ID="btnBack" runat="server" Style="display: inline-block;" 
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