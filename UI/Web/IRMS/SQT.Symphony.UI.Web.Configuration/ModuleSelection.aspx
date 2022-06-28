<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModuleSelection.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.ModuleSelection" %>

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
            float: left;
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
            float: left;
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
            background: url(images/housekeeping_button.png) no-repeat;
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
            background: url(images/housekeepingconfig_button.png) no-repeat;
            background-position: 0px 0px;
            border: 0px;
            float: left;
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
            float: left;
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
            background: url(images/propertyadministrato_button.png) no-repeat;
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
                                                                                <td>
                                                                                    <asp:DataList ID="dtlstModule" runat="server" RepeatColumns="5" RepeatDirection="Horizontal"
                                                                                        OnItemCommand="dtlstModule_ItemCommand" OnItemDataBound="dtlstModule_ItemDataBound"
                                                                                        DataKeyField="RoleType">
                                                                                        <ItemTemplate>
                                                                                            <asp:Button ID="btnModuleName" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RoleType")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:DataList>
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
