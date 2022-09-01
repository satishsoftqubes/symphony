<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPropertyPartnerConfigurationInformation.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Configurations.CtrlPropertyPartnerConfigurationInformation" %>

<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>

<%--<script type="text/javascript">
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("Configuration")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgressProperty.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
        else {
            return false;
        }
    }
</script>--%>

<style type="text/css">
    #progressBackgroundFilter {
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

    #processMessage {
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

<asp:UpdatePanel ID="updPropertyPartner" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>Property partner form</td>
            </tr>
        </table>

    </ContentTemplate>
</asp:UpdatePanel>

<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updPropertyPartner" ID="UpdateProgressPropertyPartner"
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

