<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonRoomAvailabilityChart.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCommonRoomAvailabilityChart" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<link type="text/css" href="../../Styles/jquery-ui-1.8.5.custom.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Scripts/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.5.custom.min.js"></script>
    <link rel="stylesheet" href="../../Styles/jquery.ui.timepicker.css" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui-timepicker-addon.js"></script>

<script src="../../Scripts/jquery-1.4.3.min.js" type="text/javascript"></script>
<style type="text/css">
    .availableroom
    {
        background-color: #2e8b57;
    }
    
    .bookedroom
    {
        background-color: #0080FF;
    }
    
    .oosroom
    {
        background-color: Maroon;
    }
    
    .checkinroom
    {
        background-color: #0101DF;
    }
</style>
<style>
    fieldset, img
    {
        border: 0 none;
        vertical-align: middle;
    }
    .img
    {
        vertical-align: middle;
    }
</style>
<script src="../../Scripts/jquery-1.8.2.js"></script>
<script src="../../Scripts/jquery-ui.js"></script>
<script src="../../Scripts/Common.js" type="text/javascript"></script>
<script>
    function pageLoad(sender, args) {

        $(function () {
            var dateToday = new Date();

            $("#<%= txtSearchFromDate.ClientID %>").datepicker({
                changeMonth: true,
                numberOfMonths: 1,
                minDate: dateToday,
                showOn: "button",
                dateFormat: "dd-mm-yy",
                buttonImage: "../../images/CalanderIcon.png",
                buttonImageOnly: true,
                onSelect: function (selectedDate) {
                    $("#<%= txtSearchToDate.ClientID %>").datepicker("option", "minDate", selectedDate);
                }
            });
            $("#<%= txtSearchToDate.ClientID %>").datepicker({
                changeMonth: true,
                numberOfMonths: 1,
                minDate: dateToday,
                dateFormat: "dd-mm-yy",
                showOn: "button",
                buttonImage: "../../images/CalanderIcon.png",
                buttonImageOnly: true,
                onSelect: function (selectedDate) {
                    $("#<%= txtSearchFromDate.ClientID %>").datepicker("option", "maxDate", selectedDate);
                }
            });
        });
    }
</script>
<script>
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnCheckDate() {
        if (Page_ClientValidate("IsRequireSearch")) {

            document.getElementById('errormessage').style.display = "block";
            var varDateFrom = document.getElementById('<%= txtSearchFromDate.ClientID %>').value;
            var varDateTo = document.getElementById('<%= txtSearchToDate.ClientID %>').value;

            if (varDateFrom != '' && varDateTo != '') {
                var dateFormat = document.getElementById('<%= hfDateFormat.ClientID %>').value;

                var dateFrom = fnGetValidDateFormat(varDateFrom, dateFormat);
                var dateTo = fnGetValidDateFormat(varDateTo, dateFormat);

                dateFrom = Date.parse(dateFrom, 'MM/dd/yyyy');
                dateTo = Date.parse(dateTo, 'MM/dd/yyyy');


                if (dateFrom > dateTo) {
                    $find('mpeDateMessage').show();
                    return false;
                }
                else {
                    return true;
                }
            }
            else {
                return true;
            }
        }
        else {
            return false;
        }
    }
</script>
<style type="text/css">
    #div1
    {
        width: 100%;
        display: none;
        border: 2px solid #EFEFEF;
        background-color: #FEFEFE;
    }
</style>
<asp:UpdatePanel ID="updRoomAvailabilityChart" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hfDateFormat" runat="server" />        
        <ajx:ModalPopupExtender ID="mpeRoomAvailabilityChart" runat="server" TargetControlID="hdnRoomAvailabilityChart"
            PopupControlID="pnlRoomAvailabilityChart" BackgroundCssClass="mod_background" CancelControlID="iBtnCacelRoomAvailabilityChart">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnRoomAvailabilityChart" runat="server" />
        <asp:Panel ID="pnlRoomAvailabilityChart" runat="server" Width="1000px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="litRoomAvailabilityHeader" runat="server" Text="Room Availability"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="iBtnCacelRoomAvailabilityChart" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%" border="0">
                        <tr>
                            <td width="225px">
                                From&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtSearchFromDate" runat="server"
                                    Style="width: 100px !important;" SkinID="searchtextbox" onkeydown="return stopKey(event);"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="rvfFromDate" runat="server" ControlToValidate="txtSearchFromDate"
                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireSearch"></asp:RequiredFieldValidator>
                            </td>
                            <td width="210px">
                                To&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtSearchToDate" runat="server"
                                    Style="width: 100px !important;" SkinID="searchtextbox" onkeydown="return stopKey(event);"></asp:TextBox>
                               
                                <asp:RequiredFieldValidator ID="rvfToDate" runat="server" ControlToValidate="txtSearchToDate"
                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireSearch"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                Room Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlSearchRoomType" runat="server"
                                    SkinID="nowidth" Width="180px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rvfSearchRoomType" InitialValue="00000000-0000-0000-0000-000000000000"
                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                    ValidationGroup="IsRequireSearch" ControlToValidate="ddlSearchRoomType" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                    Style="border: 0px; margin: -1px 0 0 10px; vertical-align: middle;" OnClick="btnSearch_Click"
                                    ValidationGroup="IsRequireSearch" OnClientClick="return fnCheckDate();" />
                            </td>
                            <td align="left">
                               
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <hr />
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td width="135px">
                                            &nbsp;&nbsp;&nbsp;&nbsp;Block
                                        </td>
                                        <td width="135px">
                                            &nbsp;&nbsp;&nbsp;&nbsp;Floor
                                        </td>
                                        <td width="135px">
                                            &nbsp;&nbsp;&nbsp;&nbsp;Work Timing
                                        </td>
                                        <td width="135px">
                                            &nbsp;&nbsp;&nbsp;&nbsp;Smoking
                                        </td>
                                        <td width="210px">
                                            &nbsp;&nbsp;&nbsp;&nbsp;Company
                                        </td>
                                        <td width="110px">
                                            &nbsp;&nbsp;&nbsp;&nbsp;Occupancy
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="DropDownList2" runat="server" SkinID="nowidth" Width="100px">
                                                <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Block A" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Block B" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Block C" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="Block D" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="Block E" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="Block F" Value="4"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownList3" runat="server" SkinID="nowidth" Width="100px">
                                                <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Ground Floor" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="1st" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="2nd" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="3rd" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="4th" Value="4"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownList4" runat="server" SkinID="nowidth" Width="100px">
                                                <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Day Shift" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Night Shift" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownList6" runat="server" SkinID="nowidth" Width="100px">
                                                <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownList5" runat="server" SkinID="nowidth" Width="180px">
                                                <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Infosys" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Wipro" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownList7" runat="server" SkinID="nowidth" Width="100px">
                                                <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Single" Value="1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" Text="Advanced Search" Style="display: inline;" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <hr />
                    </div>
                    <div>
                        <div style="padding-bottom: 10px;">
                            Room Type: <b>
                                <asp:Literal ID="litDisplayRoomType" runat="server" Text="-"></asp:Literal></b><br />
                            <div style="height: 5px;">
                            </div>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <div style="float: right;">
                                            <table width="380px">
                                                <tr style="height: 25px;">
                                                    <td align="center" style="font-weight: bold; color: White; background-color: #2e8b57;">
                                                        Available
                                                    </td>
                                                    <td align="center" style="font-weight: bold; color: White; background-color: #0101DF;">
                                                        Occupied
                                                    </td>
                                                    <td align="center" style="font-weight: bold; color: White; background-color: #0080FF;">
                                                        Booked
                                                    </td>
                                                    <td align="center" style="font-weight: bold; color: White; background-color: Maroon;">
                                                        Out of Service
                                                    </td>
                                                    <td align="center" style="font-weight: bold; color: White; background-color: Gray;">
                                                        Under Cleaning
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div id="dvChart" visible="false" runat="server" style="height: 500px; width: 970px;
                        overflow: auto;">
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>        
        <ajx:ModalPopupExtender ID="mpeDateMessage" runat="server" TargetControlID="hfDateMessage"
            PopupControlID="pnlDateMessage" BackgroundCssClass="mod_background" CancelControlID="btnDateMessageOK"
            BehaviorID="mpeDateMessage">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfDateMessage" runat="server" />
        <asp:Panel ID="pnlDateMessage" runat="server" Width="350px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderDateValidate" runat="server" Text="Message"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="ltrMsgDateValidate" runat="server" Text="From Date is greater than or equal to To Date."></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnDateMessageOK" Text="OK" runat="server" Style="display: inline;
                                    padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updRoomAvailabilityChart" ID="uprgRoomAvailabilityChart"
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
