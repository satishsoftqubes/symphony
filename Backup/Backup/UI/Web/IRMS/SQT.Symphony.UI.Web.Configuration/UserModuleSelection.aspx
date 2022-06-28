<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserModuleSelection.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UserModuleSelection" %>

<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Uniworld</title>
    <link id="Link1" href="~/Style/style.css" runat="server" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function fnDisplayCatchErrorMessage() {
            document.getElementById('errormessage').style.display = "block";
        }
        function fntest(id) {
            var sp = id.split("_"); 
            var sp_val = sp[2];
            document.getElementById('dtlstModule_divOperation_' + sp_val).style.display = 'block';
        }

        function fntestout(id) {
            var sp = id.split("_"); 
            var sp_val = sp[2];
            document.getElementById('dtlstModule_divOperation_' + sp_val).style.display = 'none';
        }
    </script>
    <style>
        .button_disable
        {
            background-position: top right !important;
        }
        
        .home_accounting_button
        {
            width: 142px !important;
            height: 130px !important;
            display: block;
            background: url(images/accounting_button.png) no-repeat;
            background-position: 0px 0px;
            border: 0px;
            margin: 0px;
        }
        
        .home_accounting_button:hover
        {
            display: block;
            background-position: -142px 0px;
        }
        
        
        .home_backoffice_button
        {
            width: 142px !important;
            height: 130px !important;
            display: block;
            background: url(images/backoffice_button.png) no-repeat;
            background-position: 0px 0px;
            border: 0px;
        }
        
        .home_backoffice_button:hover
        {
            display: block;
            background-position: -142px 0px;
        }
        
        .home_frontdesk_button
        {
            width: 142px !important;
            height: 130px !important;
            display: block;
            background: url(images/frontdesk_button.png) no-repeat;
            background-position: 0px 0px;
            border: 0px;
            float: left;
        }
        
        .home_frontdesk_button:hover
        {
            display: block;
            background-position: -142px 0px;
        }
        
        .home_housekeepingconfig_button
        {
            width: 142px !important;
            height: 130px !important;
            display: block;
            background: url(images/housekeepingconfig_button.png) no-repeat;
            background-position: 0px 0px;
            border: 0px;
            float: left;
        }
        
        .home_housekeepingconfig_button:hover
        {
            display: block;
            background-position: -142px 0px;
        }
        
        .home_housekeeping_button
        {
            width: 142px !important;
            height: 130px !important;
            display: block;
            background: url(images/housekeeping_button.png) no-repeat;
            background-position: 0px 0px;
            border: 0px;
        }
        
        .home_housekeeping_button:hover
        {
            display: block;
            background-position: -142px 0px;
        }
        
        .home_pms_button
        {
            width: 142px !important;
            height: 130px !important;
            display: block;
            background: url(images/pms_button.png) no-repeat;
            background-position: 0px 0px;
            border: 0px;
            float: left;
        }
        
        .home_pms_button:hover
        {
            display: block;
            background-position: -142px 0px;
        }
        
        .home_pos_button
        {
            width: 142px !important;
            height: 130px !important;
            display: block;
            background: url(images/pos_button.png) no-repeat;
            background-position: 0px 0px;
            border: 0px;
        }
        
        .home_pos_button:hover
        {
            display: block;
            background-position: -142px 0px;
        }
        
        
        .home_posconfig_button
        {
            width: 142px !important;
            height: 130px !important;
            display: block;
            background: url(images/posconfig_button.png) no-repeat;
            background-position: 0px 0px;
            border: 0px;
            float: left;
        }
        
        .home_posconfig_button:hover
        {
            display: block;
            background-position: -142px 0px;
        }
        
        .home_hr_button
        {
            width: 142px !important;
            height: 130px !important;
            display: block;
            background: url(images/hr_button.png) no-repeat;
            background-position: 0px 0px;
            border: 0px;
            float: left;
        }
        
        .home_hr_button:hover
        {
            display: block;
            background-position: -142px 0px;
        }
        
        .home_maintenance_button
        {
            width: 142px !important;
            height: 130px !important;
            display: block;
            background: url(images/maintenance_button.png) no-repeat;
            background-position: 0px 0px;
            border: 0px;
            float: left;
        }
        
        .home_maintenance_button:hover
        {
            display: block;
            background-position: -142px 0px;
        }
        
        .home_propertyadministrator_button
        {
            width: 142px !important;
            height: 130px !important;
            display: block;
            background: url(images/propertyadministrator_button.png) no-repeat;
            background-position: 0px 0px;
            border: 0px;
            float: left;
        }
        
        .home_propertyadministrator_button:hover
        {
            display: block;
            background-position: -142px 0px;
        }
        
        .home_security_button
        {
            width: 142px !important;
            height: 130px !important;
            display: block;
            background: url(images/security_button.png) no-repeat;
            background-position: 0px 0px;
            border: 0px;
            float: left;
        }
        
        .home_security_button:hover
        {
            display: block;
            background-position: -142px 0px;
        }
        
        .home_store_button
        {
            width: 142px !important;
            height: 130px !important;
            display: block;
            background: url(images/store_button.png) no-repeat;
            background-position: 0px 0px;
            border: 0px;
            float: left;
        }
        
        .home_store_button:hover
        {
            display: block;
            background-position: -142px 0px;
        }
        
        .home_corporate_button
        {
            width: 142px !important;
            height: 130px !important;
            display: block;
            background: url(images/corporate_button.png) no-repeat;
            background-position: 0px 0px;
            border: 0px;
            float: left;
        }
        
        .home_corporate_button:hover
        {
            display: block;
            background-position: -142px 0px;
        }
        
        .home_residentportal_button
        {
            width: 142px !important;
            height: 130px !important;
            display: block;
            background: url(images/residentportal_button.png) no-repeat;
            background-position: 0px 0px;
            border: 0px;
            float: left;
        }
        
        .home_residentportal_button:hover
        {
            display: block;
            background-position: -142px 0px;
        }
        
        .home_fnb_button
        {
            width: 142px !important;
            height: 130px !important;
            display: block;
            background: url(images/fnb_button.png) no-repeat;
            background-position: 0px 0px;
            border: 0px;
            float: left;
        }
        
        .home_fnb_button:hover
        {
            display: block;
            background-position: -142px 0px;
        }
        
        
        .module_subbg
        {
            background: url(images/mainmodule_subbg.png) no-repeat bottom left;
            width: 142px;
            min-height: 70px;
            text-align: center;
        }
        
        .module_subbg div
        {
            line-height: 32px;
            text-align: center;
            border-bottom: 1px solid #ccc;
        }
        
        .module_subbg div.lastmodulelink
        {
            border-bottom: none !important;
        }
        
        .module_subbg div a
        {
            padding: 5px;
            font-size: 12px;
            color: #363636;
        }
        
        .module_subbg a:hover
        {
            color: #105887;
        }
        #dtlstModule
        {
        }
        
        #dtlstModule td
        {
            vertical-align: top;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scptInnerHTML" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updModule" runat="server">
        <ContentTemplate>
            <div id="wrap">
                <div class="layout">
                    <div class="header">
                        <div class="header_left">
                            <a href="<%=Page.ResolveUrl("~/GUI/Index.aspx") %>">
                                <img src="<%=Page.ResolveUrl("~/images/logo.jpg") %>" border="0" alt="" class="logo" /></a>
                            <div style="display: inline-block; vertical-align: top; margin-top: 40px;">
                                <asp:UpdatePanel ID="uPnlMasterPropertyName" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblPropertyName" runat="server" Style="font-size: x-large;"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="header_right">
                            <div class="header_right_col2">
                                <div class="header_right_col2_content">
                                    <div class="header_right_col2_date">
                                        <asp:Literal ID="lblDate" runat="server"></asp:Literal>
                                        : <span>
                                            <asp:Literal ID="litDate" runat="server"></asp:Literal></span></div>
                                    <div class="clear">
                                    </div>
                                    <div class="header_right_col2_time">
                                        <asp:Literal ID="lblTime" runat="server"></asp:Literal>
                                        : <span>
                                            <asp:Literal ID="litTime" runat="server"></asp:Literal></span></div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <div class="header_right_logout">
                                    <asp:LinkButton runat="server" ID="lnkLogout" OnClick="lnkLogOut_Click"></asp:LinkButton>
                                </div>
                            </div>
                            <div class="header_right_col1">
                                <div class="header_right_col1_name">
                                    <asp:Literal ID="ltrModuleTitle" runat="server"></asp:Literal></div>
                                <div class="header_right_col1_link">
                                    <asp:Label ID="lblUserDisplayName" runat="server"></asp:Label>&nbsp;&nbsp;|&nbsp;&nbsp;<asp:Label
                                        ID="lblUserRoleType" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="main">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td class="main_content_td">
                                    <div class="main_content">
                                        <div class="mainmenu">
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <div class="mainbox">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td class="content">
                                                        <table width="850px" border="0" cellspacing="0" cellpadding="0" style="margin: 0 auto;">
                                                            <tr>
                                                                <td class="boxtopleft">
                                                                    &nbsp;
                                                                </td>
                                                                <td class="boxtopcenter">
                                                                    <asp:Literal ID="ltrMainHeader" runat="server" Text="Module"></asp:Literal>
                                                                    <%--<div style="float: left;">
                                                                        <asp:LinkButton ID="lnkTestMolule" runat="server" OnClick="lnkTestMolule_OnClick"
                                                                            Text="Module"></asp:LinkButton>
                                                                    </div>--%>
                                                                </td>
                                                                <td class="boxtopright">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="boxleft">
                                                                </td>
                                                                <td>
                                                                    <div class="box_form">
                                                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                                            <tr>
                                                                                <td style="vertical-align: top;">
                                                                                    <table cellspacing="0" style="border-collapse: collapse;">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Button ID="btnPMSModule" runat="server" SkinID="btnModule" CssClass="home_corporate_button button_disable" />
                                                                                                    <div class="module_subbg">
                                                                                                        <div>
                                                                                                            <asp:LinkButton ID="lnkPMSSetup" runat="server" Enabled="false" OnClick="lnkPMSSetup_Click">Setup</asp:LinkButton>
                                                                                                        </div>
                                                                                                        <div class="lastmodulelink">
                                                                                                            <asp:LinkButton ID="lnkPMSOperation" runat="server" Enabled="false">Operation</asp:LinkButton>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Button ID="btnFrontDeskModule" runat="server" SkinID="btnModule" CssClass="home_frontdesk_button button_disable" />
                                                                                                    <div class="module_subbg">
                                                                                                        <div>
                                                                                                            <asp:LinkButton ID="lnkFrontDeskSetup" runat="server" Enabled="false" OnClick="lnkFrontDeskSetup_Click">Setup</asp:LinkButton>
                                                                                                        </div>
                                                                                                        <div class="lastmodulelink">
                                                                                                            <asp:LinkButton ID="lnkFrontDeskOperation" runat="server" Enabled="false" OnClick="lnkFrontDeskOperation_Click">Operation</asp:LinkButton>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Button ID="btnPOSModule" runat="server" SkinID="btnModule" CssClass="home_pos_button button_disable" />
                                                                                                    <div class="module_subbg">
                                                                                                        <div>
                                                                                                            <asp:LinkButton ID="lnkPOSSetup" runat="server" Enabled="false">Setup</asp:LinkButton>
                                                                                                        </div>
                                                                                                        <div class="lastmodulelink">
                                                                                                            <asp:LinkButton ID="lnkPOSOperation" runat="server" Enabled="false">Operation</asp:LinkButton>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Button ID="btnFAndBModule" runat="server" SkinID="btnModule" CssClass="home_fnb_button button_disable" />
                                                                                                    <div class="module_subbg">
                                                                                                        <div>
                                                                                                            <asp:LinkButton ID="lnkFAndBSetup" runat="server" Enabled="false">Setup</asp:LinkButton>
                                                                                                        </div>
                                                                                                        <div class="lastmodulelink">
                                                                                                            <asp:LinkButton ID="lnkFAndBOperation" runat="server" Enabled="false">Operation</asp:LinkButton>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Button ID="btnHouseKeepingModule" runat="server" SkinID="btnModule" CssClass="home_housekeeping_button button_disable" />
                                                                                                    <div class="module_subbg">
                                                                                                        <div>
                                                                                                            <asp:LinkButton ID="lnkHouseKeepingSetup" runat="server" Enabled="false">Setup</asp:LinkButton>
                                                                                                        </div>
                                                                                                        <div class="lastmodulelink">
                                                                                                            <asp:LinkButton ID="lnkHouseKeepingOperation" runat="server" Enabled="false">Operation</asp:LinkButton>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Button ID="btnAccountsModule" runat="server" SkinID="btnModule" CssClass="home_accounting_button button_disable" />
                                                                                                    <div class="module_subbg">
                                                                                                        <div>
                                                                                                            <asp:LinkButton ID="lnkAccountsSetup" runat="server" Enabled="false" OnClick="lnkAccountsSetup_Click">Setup</asp:LinkButton>
                                                                                                        </div>
                                                                                                        <div class="lastmodulelink">
                                                                                                            <asp:LinkButton ID="lnkAccountsOperation" runat="server" Enabled="false" OnClick="lnkAccountsOperation_Click">Operation</asp:LinkButton>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Button ID="btnHRModule" runat="server" SkinID="btnModule" CssClass="home_hr_button button_disable" />
                                                                                                    <div class="module_subbg">
                                                                                                        <div>
                                                                                                            <asp:LinkButton ID="lnkHRSetup" runat="server" Enabled="false">Setup</asp:LinkButton>
                                                                                                        </div>
                                                                                                        <div class="lastmodulelink">
                                                                                                            <asp:LinkButton ID="lnkHROperation" runat="server" Enabled="false">Operation</asp:LinkButton>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Button ID="btnSecurityModule" runat="server" SkinID="btnModule" CssClass="home_security_button button_disable" />
                                                                                                    <div class="module_subbg">
                                                                                                        <div>
                                                                                                            <asp:LinkButton ID="lnkSecuritySetup" runat="server" Enabled="false">Setup</asp:LinkButton>
                                                                                                        </div>
                                                                                                        <div class="lastmodulelink">
                                                                                                            <asp:LinkButton ID="lnkSecurityOperation" runat="server" Enabled="false">Operation</asp:LinkButton>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Button ID="btnStoresModule" runat="server" SkinID="btnModule" CssClass="home_store_button button_disable" />
                                                                                                    <div class="module_subbg">
                                                                                                        <div>
                                                                                                            <asp:LinkButton ID="lnkStoresSetup" runat="server" Enabled="false">Setup</asp:LinkButton>
                                                                                                        </div>
                                                                                                        <div class="lastmodulelink">
                                                                                                            <asp:LinkButton ID="lnkStoresOperation" runat="server" Enabled="false">Operation</asp:LinkButton>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Button ID="btnMaintenanceModule" runat="server" SkinID="btnModule" CssClass="home_maintenance_button button_disable" />
                                                                                                    <div class="module_subbg">
                                                                                                        <div>
                                                                                                            <asp:LinkButton ID="lnkMaintenanceSetup" runat="server" Enabled="false">Setup</asp:LinkButton>
                                                                                                        </div>
                                                                                                        <div class="lastmodulelink">
                                                                                                            <asp:LinkButton ID="lnkMaintenanceOperation" runat="server" Enabled="false">Operation</asp:LinkButton>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Button ID="btnResidentPortalModule" runat="server" SkinID="btnModule" CssClass="home_residentportal_button button_disable" />
                                                                                                    <div class="module_subbg">
                                                                                                        <div>
                                                                                                            <asp:LinkButton ID="lnkResidentPortalSetup" runat="server" Enabled="false">Setup</asp:LinkButton>
                                                                                                        </div>
                                                                                                        <div class="lastmodulelink">
                                                                                                            <asp:LinkButton ID="lnkResidentPortalOperation" runat="server" Enabled="false">Operation</asp:LinkButton>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td>
                                                                                                </td>
                                                                                                <td>
                                                                                                </td>
                                                                                                <td>
                                                                                                </td>
                                                                                                <td>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
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
                                                        <div class="clear_divider">
                                                        </div>
                                                        <div class="clear">
                                                            <%--http://www.lq.com/lq/properties/propertyProfile.do?ident=LQ6302&propId=6302&IATA=99020569&savedSearchQuery=%2Flq%2FproxySearchRes.do%3FsearchCitygrand%2Bprairie%26searchStateTX%26searchRadius10%26indate%3D9%252F7%252F2012%26availability.palsra_IND_D%3D7%26availability.palsra_IND_M%3D9%26availability.palsra_IND_Y%3D2012%26outdate%3D9%252F8%252F2012%26availability.palsra_OTD_D%3D8%26availability.palsra_OTD_M%3D9%26availability.palsra_OTD_Y%3D2012%26availability.palsra_RPC1%3D%26availability.palsra_CCN1%3D%26availability.palsra_NRM1%26mapProvider%3DMapQuest%26searchType%3DGEO%26promocorp%26availability.palsra_NRM1%26availability.palsra_CCN1%26availability.palsra_ROC1%26availability.palsra_NCH0--%>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="errormessage" class="clear" style="display: none;">
        <uc1:MsgBox ID="MessageBox" runat="server" />
    </div>
    <asp:UpdateProgress AssociatedUpdatePanelID="updModule" ID="UpdateProgressModule"
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
    </form>
</body>
</html>
