<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.Applications.Index" %>

<%--<%@ Register Src="~/UIControls/DashBoard/CltrDahsBoardProspects.ascx" TagName="CltrDahsBoardProspects"
    TagPrefix="DashBoard" %>
<%@ Register Src="~/UIControls/DashBoard/CltrDashBoardChannelPartners.ascx" TagName="CltrDashBoardChannelPartners"
    TagPrefix="DashBoard" %>--%>
<%@ Register Src="~/UIControls/DashBoard/CltrDashBoardInvestors.ascx" TagName="CltrDashBoardInvestors"
    TagPrefix="DashBoard" %>
<%@ Register Src="~/UIControls/DashBoard/CltrDashboardProperty.ascx" TagName="CltrDashboardProperty"
    TagPrefix="DashBoard" %>
<%@ Register src="../UIControls/DashBoard/CtrlDashBoardOccupationStatus.ascx" tagname="CtrlDashBoardOccupationStatus" tagprefix="uc2" %>
<%@ Register src="../UIControls/DashBoard/CtrlDashBoardYieldReport.ascx" tagname="CtrlDashBoardYieldReport" tagprefix="uc3" %>
<asp:content id="Content1" contentplaceholderid="head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellspacing="15" cellpadding="0" height="100%">
        <tr>
			<td style="width:50%;">
            <DashBoard:CltrDashboardProperty ID="CltrDashboardProperty1" runat="server"></DashBoard:CltrDashboardProperty>
			</td>
			<td style="width:50%;">
            <DashBoard:CltrDashBoardInvestors ID="CltrDashBoardInvestors1" runat="server"></DashBoard:CltrDashBoardInvestors>
            
			</td>
		</tr>
		<tr>
			<td style="width:50%;">
            <%--<DashBoard:CltrDahsBoardProspects ID="CltrDahsBoardProspects1" runat="server"></DashBoard:CltrDahsBoardProspects>--%>
            <uc2:CtrlDashBoardOccupationStatus ID="CtrlDashBoardOccupationStatusStup" 
                    runat="server" />
			</td>
			<td style="width:50%;">
            <%--<DashBoard:CltrDashBoardChannelPartners ID="CltrDashBoardChannelPartners1" runat="server"></DashBoard:CltrDashBoardChannelPartners>--%>
            <uc3:CtrlDashBoardYieldReport ID="CtrlDashBoardYieldReportStup" runat="server" />
			</td>
		</tr>
	</table>
</asp:content>
