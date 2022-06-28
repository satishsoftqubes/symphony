<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AmenitiesSetup.aspx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.Applications.SetUp.AmenitiesSetup" %>

<%@ Register src="~/UIControls/Configurations/CtrlAmenities.ascx" tagname="CtrlAmenities" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CtrlAmenities ID="CtrlAmenities1" runat="server" />
</asp:Content>
