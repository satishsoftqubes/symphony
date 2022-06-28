<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddress.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.CommonControls.CtrlAddress" %>
<script type="text/javascript" language="javascript">
    function pageLoad(sender, args) {

        $(document).ready(function () {
            $("#ContentPlaceHolder1_CtrlEmployee1_ucPermanentAddress_txtCountry").autocomplete('AutoComplete.ashx');
            $("#ContentPlaceHolder1_CtrlEmployee1_ucPermanentAddress_txtCity").autocomplete('CityAutoComplete.ashx');
            $("#ContentPlaceHolder1_CtrlEmployee1_ucPermanentAddress_txtState").autocomplete('StateAutoComplete.ashx');

            $("#ContentPlaceHolder1_CtrlEmployee1_ucCurrentAddress_txtCity").autocomplete('CityAutoComplete.ashx');
            $("#ContentPlaceHolder1_CtrlEmployee1_ucCurrentAddress_txtState").autocomplete('StateAutoComplete.ashx');
            $("#ContentPlaceHolder1_CtrlEmployee1_ucCurrentAddress_txtCountry").autocomplete('AutoComplete.ashx');


            $("#ContentPlaceHolder1_ucCtrlPropertySetup_ucAddress_txtCity").autocomplete('../Configurations/CityAutoComplete.ashx');
            $("#ContentPlaceHolder1_ucCtrlPropertySetup_ucAddress_txtState").autocomplete('../Configurations/StateAutoComplete.ashx');
            $("#ContentPlaceHolder1_ucCtrlPropertySetup_ucAddress_txtCountry").autocomplete('../Configurations/AutoComplete.ashx');

            $("#ContentPlaceHolder1_CtrlCompanySetupstup_ucRegisteredAddress_txtCountry").autocomplete('../Configurations/AutoComplete.ashx');
            $("#ContentPlaceHolder1_CtrlCompanySetupstup_ucRegisteredAddress_txtCity").autocomplete('../Configurations/CityAutoComplete.ashx');
            $("#ContentPlaceHolder1_CtrlCompanySetupstup_ucRegisteredAddress_txtState").autocomplete('../Configurations/StateAutoComplete.ashx');

            $("#ContentPlaceHolder1_CtrlCompanySetupstup_ucOfficeAddress_txtCity").autocomplete('../Configurations/CityAutoComplete.ashx');
            $("#ContentPlaceHolder1_CtrlCompanySetupstup_ucOfficeAddress_txtState").autocomplete('../Configurations/StateAutoComplete.ashx');
            $("#ContentPlaceHolder1_CtrlCompanySetupstup_ucOfficeAddress_txtCountry").autocomplete('../Configurations/AutoComplete.ashx');

            $("#ContentPlaceHolder1_CtrlCorporate_ucCtrlAddress_txtCity").autocomplete('../Configurations/CityAutoComplete.ashx');
            $("#ContentPlaceHolder1_CtrlCorporate_ucCtrlAddress_txtState").autocomplete('../Configurations/StateAutoComplete.ashx');
            $("#ContentPlaceHolder1_CtrlCorporate_ucCtrlAddress_txtCountry").autocomplete('../Configurations/AutoComplete.ashx');

            $("#ContentPlaceHolder1_idCtrlBookingAgent_ucCtrlAddress_txtCity").autocomplete('../Configurations/CityAutoComplete.ashx');
            $("#ContentPlaceHolder1_idCtrlBookingAgent_ucCtrlAddress_txtState").autocomplete('../Configurations/StateAutoComplete.ashx');
            $("#ContentPlaceHolder1_idCtrlBookingAgent_ucCtrlAddress_txtCountry").autocomplete('../Configurations/AutoComplete.ashx');
        });
    }

</script>
<table width="100%" cellpadding="2" cellspacing="0">
    <tr>
        <td id="tdAddress" runat="server" class="addresstd" style="vertical-align:top;">
            <asp:Literal ID="ltrAddress" runat="server"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="3" MaxLength="280"></asp:TextBox>
            <span>
                <asp:RequiredFieldValidator ID="rvfAddress" SetFocusOnError="true" CssClass="input-notification error png_bg"
                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtAddress"></asp:RequiredFieldValidator></span>
        </td>
    </tr>
    <tr>
        <td id="tdCity" runat="server" class="addresstd">
            <asp:Literal ID="ltrCity" runat="server"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtCity" runat="server" MaxLength="78"></asp:TextBox>
            <span>
                <asp:RequiredFieldValidator ID="rvfCity" SetFocusOnError="true" CssClass="input-notification error png_bg"
                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCity"></asp:RequiredFieldValidator></span>
        </td>
    </tr>
    <tr>
        <td id="tdState" runat="server" class="addresstd">
            <asp:Literal ID="ltrState" runat="server"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtState" runat="server" MaxLength="120"></asp:TextBox>
            <span>
                <asp:RequiredFieldValidator ID="rvfState" SetFocusOnError="true" CssClass="input-notification error png_bg"
                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtState"></asp:RequiredFieldValidator></span>
        </td>
    </tr>
    <tr>
        <td id="tdCountry" runat="server" class="addresstd">
            <asp:Literal ID="ltrCountry" runat="server"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtCountry" runat="server" MaxLength="120"></asp:TextBox>
            <span>
                <asp:RequiredFieldValidator ID="rvfCountry" SetFocusOnError="true" CssClass="input-notification error png_bg"
                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCountry"></asp:RequiredFieldValidator></span>
        </td>
    </tr>
    <tr>
        <td id="tdZipcode" runat="server" class="addresstd">
            <asp:Literal ID="ltrZipCode" runat="server"></asp:Literal>
        </td>
        <td>
            <asp:TextBox ID="txtZipCode" runat="server" MaxLength="13"></asp:TextBox>
            <ajx:FilteredTextBoxExtender ID="fttxtZipCode" runat="server" TargetControlID="txtZipCode" FilterMode="ValidChars" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"></ajx:FilteredTextBoxExtender>
            <span>
                <asp:RequiredFieldValidator ID="rvfZipCode" SetFocusOnError="true" CssClass="input-notification error png_bg"
                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtZipCode"></asp:RequiredFieldValidator></span>
        </td>
    </tr>
</table>
