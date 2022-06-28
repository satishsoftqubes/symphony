<%@ Page Title="" Language="C#" MasterPageFile="~/Master/sales.Master" AutoEventWireup="true"
    CodeBehind="SalesDashBoard.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.SalesDashBoard" %>

<%--<%@ Register Src="~/UIControls/DashBoard/CltrDahsBoardProspects.ascx" TagName="CltrDahsBoardProspects"
    TagPrefix="DashBoard" %>--%>
<%--<%@ Register Src="~/UIControls/DashBoard/CltrDashBoardChannelPartners.ascx" TagName="CltrDashBoardChannelPartners"
    TagPrefix="DashBoard" %>--%>
<%@ Register src="../UIControls/DashBoard/CtrlDashBoardOccupationStatus.ascx" tagname="CtrlDashBoardOccupationStatus" tagprefix="uc2" %>
<%@ Register src="../UIControls/DashBoard/CtrlDashBoardYieldReport.ascx" tagname="CtrlDashBoardYieldReport" tagprefix="uc3" %>
<%@ Register Src="~/UIControls/DashBoard/CltrDashBoardInvestors.ascx" TagName="CltrDashBoardInvestors"
    TagPrefix="DashBoard" %>
<%@ Register Src="~/UIControls/DashBoard/CltrDashboardProperty.ascx" TagName="CltrDashboardProperty"
    TagPrefix="DashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
        <tr>
            <td>
                
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="15" cellpadding="0" height="100%">
        <tr>
            <td id="col11" runat="server" style="width:50%; padding-right:5px; padding-bottom:15px;">
                <DashBoard:CltrDashboardProperty ID="CltrDashboardProperty1" runat="server"></DashBoard:CltrDashboardProperty>
            </td>
            <td id="col12" runat="server" style="width:50%;  padding-bottom:5px;">
                <%--<DashBoard:CltrDahsBoardProspects ID="CltrDahsBoardProspects1" runat="server"></DashBoard:CltrDahsBoardProspects>--%>
                <DashBoard:CltrDashBoardInvestors ID="CltrDashBoardInvestors1" runat="server"></DashBoard:CltrDashBoardInvestors>
            </td>
        </tr>
        <tr>
            <td id="col21" runat="server" style="width:50%; padding-right:5px;">
                <uc2:CtrlDashBoardOccupationStatus ID="CtrlDashBoardOccupationStatusStup" 
                    runat="server" />
            </td>
            <td id="col22" runat="server" style="width:50%;">
                <uc3:CtrlDashBoardYieldReport ID="CtrlDashBoardYieldReportStup" runat="server" />
                <%--<DashBoard:CltrDashBoardChannelPartners ID="CltrDashBoardChannelPartners1" runat="server">
                </DashBoard:CltrDashBoardChannelPartners>--%>
            </td>
        </tr>
    </table>
</asp:Content>
