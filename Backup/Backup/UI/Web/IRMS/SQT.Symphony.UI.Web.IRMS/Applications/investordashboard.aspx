<%@ Page Language="C#" MasterPageFile="~/Master/investor.Master" AutoEventWireup="true" CodeBehind="investordashboard.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.investordashboard" %>
<%@ Register src="../UIControls/DashBoard/CtrlDashBoardUnitInformation.ascx" tagname="CtrlDashBoardUnitInformation" tagprefix="uc1" %>
<%@ Register src="../UIControls/DashBoard/CtrlDashBoardOccupationStatus.ascx" tagname="CtrlDashBoardOccupationStatus" tagprefix="uc2" %>
<%@ Register src="../UIControls/DashBoard/CtrlDashBoardYieldReport.ascx" tagname="CtrlDashBoardYieldReport" tagprefix="uc3" %>
<%@ Register Src="~/UIControls/DashBoard/CltrDashboardProperty.ascx" TagName="CltrDashboardProperty"
    TagPrefix="DashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellspacing="15" cellpadding="0" >
		<tr>
			<td style="width:50%;" >
			    <DashBoard:CltrDashboardProperty ID="CltrDashboardProperty1" runat="server"></DashBoard:CltrDashboardProperty>
			</td>
			<td style="width:50%;">
			    <uc1:CtrlDashBoardUnitInformation ID="CtrlDashBoardUnitInformation1" 
                    runat="server" />
			</td>
		</tr>
		<tr>
			<td style="width:50%;">
			    <uc2:CtrlDashBoardOccupationStatus ID="CtrlDashBoardOccupationStatusStup" 
                    runat="server" />
			</td>
            <td style="width:50%;">
                <uc3:CtrlDashBoardYieldReport ID="CtrlDashBoardYieldReportStup" runat="server" />
            </td>
		</tr>
	</table>
</asp:Content>
