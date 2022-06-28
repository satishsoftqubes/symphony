<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAdminOldRentPayout.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Activity.CtrlAdminOldRentPayout" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
    function pageLoad(sender, args) {
        $(function () {
            $("#tabs").tabs();
            $('#tabs').tabs({
                select: function (event, ui) {
                    window.location.hash = ui.tab.hash;
                }
            });
        });
    }
    function stopKey(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 8) && (node.type == "text")) { return false; }
        else if ((evt.keyCode == 9) && (node.type == "text")) { return true; }
        else if ((evt.keyCode == 46) && (node.type == "text")) { return false; }
        else { return false; }
    }
    function SelectTab(tabno) {
        if (tabno == '1') {
            window.location.hash = 'tabs-1';
        }
        else if (tabno == '2') {
            window.location.hash = 'tabs-2';
        }
    }
    function isNumber(evt) {
        evt = (evt) ? evt : window.event;
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
        return true;
    }

</script>
<style type="text/css">
    #progressBackgroundFilter
    {
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
    #processMessage
    {
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
<script type="text/javascript">
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("QuarterSetup")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= updateprogressRentPayout.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
        else {
            return false;
        }
    }
</script>
<asp:UpdatePanel ID="updAdminRentPayout" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                Rent Payout
                            </td>
                            <td class="boxtopright">
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td style="padding-top: 15px;">
                                <div class="demo">
                                    <div id="tabs">
                                        <ul>
                                            <li><a href="#tabs-1">Rent Payout</a></li>
                                            <li><a href="#tabs-2">Quarter Setup</a></li>
                                        </ul>
                                        <div id="tabs-1">
                                            <asp:MultiView ID="mpeRentPayOut" runat="server">
                                                <asp:View ID="vRentPayout" runat="server">
                                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td class="dTableBox" style="padding: 10px 0px 10px 0px;">
                                                                <div style="overflow: auto; width: 735px; height: 350px;">
                                                                    <style type="text/css">
                                                                        .mGrid td.topalign
                                                                        {
                                                                            vertical-align: top;
                                                                        }
                                                                    </style>
                                                                    <asp:DataList ID="dlRentPayOutQuarter" runat="server" CellPadding="0" CellSpacing="5"
                                                                        RepeatDirection="Horizontal" RepeatColumns="4" OnItemDataBound="dlRentPayOutQuarter_ItemDataBound"
                                                                        OnItemCommand="dlRentPayOutQuarter_ItemCommand">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblQuarterTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Title")%>'></asp:Label></br>
                                                                            <asp:LinkButton ID="lnkToViewQuarterDetail" CommandName="QUARTERDETAILS" runat="server"
                                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem, "QuarterID")%>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:DataList>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:View>
                                                <asp:View ID="vListRentPayout" runat="server">
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td colspan="2">
                                                                <div style="height: 26px;">
                                                                    <%if (IsInsertForDetails)
                                                                      { %>
                                                                    <div class="ResetSuccessfully">
                                                                        <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                                            <img src="../../images/success.png" />
                                                                        </div>
                                                                        <div>
                                                                            <asp:Label ID="lblRentDetailsmsg" runat="server"></asp:Label></div>
                                                                        <div style="height: 10px;">
                                                                        </div>
                                                                    </div>
                                                                    <% }%>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 39%; border-right: 1px solid #ccccce;">
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td style="width: 85px;">
                                                                            <asp:Literal ID="litPeriodFrom" Text="Period From :" runat="server"></asp:Literal>
                                                                        </td>
                                                                        <td style="width: 90px;">
                                                                            <asp:Literal ID="litDisplayPeriodFrom" runat="server"></asp:Literal>
                                                                        </td>
                                                                        <td style="width: 30px;">
                                                                            <asp:Literal ID="litTo" runat="server" Text="To :"></asp:Literal>
                                                                        </td>
                                                                        <td style="padding-right: 5px;">
                                                                            <asp:Literal ID="litDisplayTo" runat="server"></asp:Literal>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="padding-left: 10px;">
                                                                <asp:Literal ID="litNoOfays" runat="server"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <hr />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 43%; border-right: 1px solid #ccccce;">
                                                                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                                    <tr>
                                                                        <td style="border-bottom: 1px solid #ccccce;">
                                                                            <b>A)</b>
                                                                            <asp:Literal ID="litTotalAreaOfComplex" Text=" Total Area of Complex <b>(Sft)</b> :"
                                                                                runat="server"></asp:Literal>
                                                                        </td>
                                                                        <td style="text-align: right; padding-right: 17px; border-bottom: 1px solid #ccccce;">
                                                                            <asp:Literal ID="litDisplayTotalAreaOfComplex" runat="server" Visible="false"></asp:Literal>
                                                                            <asp:TextBox ID="txtDisplayTotalAreaOfComplex" runat="server" MaxLength="18" Style="width: 80px;
                                                                                text-align: right" OnTextChanged="txtDisplayTotalAreaOfComplex_TextChange" AutoPostBack="true"></asp:TextBox>
                                                                            <ajx:FilteredTextBoxExtender ID="fteDisplayTotalAreaOfComplex" runat="server" TargetControlID="txtDisplayTotalAreaOfComplex"
                                                                                ValidChars="0123456789" FilterMode="ValidChars">
                                                                            </ajx:FilteredTextBoxExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="border-bottom: 1px solid #ccccce;">
                                                                        <td style="border-bottom: 1px solid #ccccce;">
                                                                            <b>B)</b>
                                                                            <asp:Literal ID="litSelfOccupiedArea" Text=" Less Self Occupied Area <b>(Sft)</b> :"
                                                                                runat="server"></asp:Literal>
                                                                        </td>
                                                                        <td style="text-align: right; padding-right: 17px; border-bottom: 1px solid #ccccce;">
                                                                            <asp:Literal ID="litDisplaySelfOccupiedArea" runat="server" Visible="false"></asp:Literal>
                                                                            <asp:TextBox ID="txtDisplaySelfOccupiedArea" runat="server" MaxLength="18" Style="width: 80px;
                                                                                text-align: right" OnTextChanged="txtDisplaySelfOccupiedArea_TextChange" AutoPostBack="true"></asp:TextBox>
                                                                            <ajx:FilteredTextBoxExtender ID="fteDisplaySelfOccupiedArea" runat="server" TargetControlID="txtDisplaySelfOccupiedArea"
                                                                                ValidChars="0123456789" FilterMode="ValidChars">
                                                                            </ajx:FilteredTextBoxExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="border-bottom: 1px solid #ccccce;">
                                                                        <td style="border-bottom: 1px solid #ccccce;">
                                                                            <b>C)</b>
                                                                            <asp:Literal ID="litNetAreaUnderPMS" Text=" Net Area under PMS <b>(Sft)</b> :" runat="server"></asp:Literal>
                                                                        </td>
                                                                        <td style="text-align: right; padding-right: 17px; border-bottom: 1px solid #ccccce;">
                                                                            <asp:Literal ID="litDisplayNetAreaUnderPMS" runat="server" Visible="false"></asp:Literal>
                                                                            <asp:TextBox ID="txtDisplayNetAreaUnderPMS" runat="server" MaxLength="18" Style="width: 80px;
                                                                                text-align: right" OnTextChanged="txtDisplayNetAreaUnderPMS_TextChange" AutoPostBack="true"></asp:TextBox>
                                                                            <ajx:FilteredTextBoxExtender ID="fteDisplayNetAreaUnderPMS" runat="server" TargetControlID="txtDisplayNetAreaUnderPMS"
                                                                                ValidChars="0123456789" FilterMode="ValidChars">
                                                                            </ajx:FilteredTextBoxExtender>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                                    <tr>
                                                                        <td style="width: 300px; padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                                            <b>D)</b>
                                                                            <asp:Literal ID="litRoomRentForPeriod" Text=" Room rent collected for the period :"
                                                                                runat="server"></asp:Literal>
                                                                        </td>
                                                                        <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                                            <asp:Literal ID="litDisplayRoomRentForPeriod" runat="server" Visible="false"></asp:Literal>
                                                                            <asp:TextBox ID="txtDisplayRoomRentForPeriod" runat="server" MaxLength="18" Style="width: 80px;
                                                                                text-align: right" OnTextChanged="txtDisplayRoomRentForPeriod_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                            <ajx:FilteredTextBoxExtender ID="fteDisplayRoomRentForPeriod" runat="server" TargetControlID="txtDisplayRoomRentForPeriod"
                                                                                ValidChars="0123456789" FilterMode="ValidChars">
                                                                            </ajx:FilteredTextBoxExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding-left: 10px;">
                                                                            <b>E) Less :</b>
                                                                        </td>
                                                                        <td>
                                                                            
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding-left:24px;">
                                                                            <b>(1)</b>&nbsp;<asp:Literal ID="litLessPropertyManegefees" Text=" Property Mgmt. fees:" runat="server"></asp:Literal>
                                                                            <b>(<asp:Literal ID="litDisppropertymangeper" Text="" runat="server"></asp:Literal>
                                                                                % of D)</b>
                                                                        </td>
                                                                        <td style="text-align: right;">
                                                                            <%--<asp:Literal ID="litDisplayLessPropertyManegefees" runat="server" Text="250"></asp:Literal>--%>
                                                                            <asp:TextBox ID="txtPropertyMgmtFees" runat="server" MaxLength="18" Style="width: 80px;
                                                                                text-align: right" OnTextChanged="txtServiceTax_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                            <ajx:FilteredTextBoxExtender ID="ftbPropertyMgmtFees" runat="server" TargetControlID="txtPropertyMgmtFees"
                                                                                ValidChars="0123456789" FilterMode="ValidChars">
                                                                            </ajx:FilteredTextBoxExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding-left:24px;">
                                                                            <b>(2)</b>&nbsp;&nbsp;Service tax on Property Mgmt. fees @ 12.36%
                                                                        </td>
                                                                        <td style="text-align: right;">
                                                                            <asp:TextBox ID="txtServiceTax" runat="server" MaxLength="18" Style="width: 80px;
                                                                                text-align: right" OnTextChanged="txtServiceTax_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                            <ajx:FilteredTextBoxExtender ID="ftbServiceTax" runat="server" TargetControlID="txtServiceTax"
                                                                                ValidChars="0123456789" FilterMode="ValidChars">
                                                                            </ajx:FilteredTextBoxExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding-left:24px; border-bottom: 1px solid #ccccce;">
                                                                            <b>(3)</b>&nbsp;&nbsp;Credit Card / Bank Charges
                                                                        </td>
                                                                        <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                                            <asp:TextBox ID="txtBankCharges" runat="server" MaxLength="18" Style="width: 80px;
                                                                                text-align: right" OnTextChanged="txtServiceTax_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                            <ajx:FilteredTextBoxExtender ID="ftbBankCharges" runat="server" TargetControlID="txtBankCharges"
                                                                                ValidChars="0123456789" FilterMode="ValidChars">
                                                                            </ajx:FilteredTextBoxExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding-left:10px; border-bottom: 1px solid #ccccce;">
                                                                           <b>F)</b>&nbsp;Total amount to deduct <b>(1+2+3)</b>
                                                                        </td>
                                                                        <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                                            <asp:Label ID="ltrTotalAmountToDeduct" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                                            <b>G)</b>
                                                                            <asp:Literal ID="litTotalAmountTodistribute" Text=" Room rent to distribute" runat="server"></asp:Literal>
                                                                            <b>(D - F)</b>
                                                                        </td>
                                                                        <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                                            <asp:Literal ID="litDispTotalRoomRentTodistribute" runat="server"></asp:Literal>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                                            <b>H)</b>
                                                                            <asp:Literal ID="litInterestOnRoomRent" Text=" Interest earned for the period" runat="server"></asp:Literal>
                                                                            <span class="erroraleart">
                                                                                <asp:RequiredFieldValidator ID="rfvInterestOnRoomRent" SetFocusOnError="True" ControlToValidate="txtInterestOnRoomRent"
                                                                                    ValidationGroup="QuarterDetail" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                                            <asp:TextBox ID="txtInterestOnRoomRent" runat="server" MaxLength="18" Style="width: 85px;
                                                                                text-align: right" OnTextChanged="txtInterestOnRoomRent_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                            <ajx:FilteredTextBoxExtender ID="fteInterestOnRoomRent" runat="server" TargetControlID="txtInterestOnRoomRent"
                                                                                ValidChars="0123456789" FilterMode="ValidChars">
                                                                            </ajx:FilteredTextBoxExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                                            <b>I)</b>
                                                                            <asp:Literal ID="litRentToDistributed" Text=" Net amount to be distributed&nbsp;<b>(G + H)</b>"
                                                                                runat="server"></asp:Literal>
                                                                        </td>
                                                                        <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                                            <asp:Literal ID="litDisplayRentToDistributed" runat="server"></asp:Literal>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                                            <b>J)</b>
                                                                            <asp:Literal ID="litRentYieldPerSFT" Text=" Rent yield per Sft for period&nbsp;<b>(I/C)</b> :"
                                                                                runat="server"></asp:Literal>
                                                                        </td>
                                                                        <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                                            <asp:Literal ID="litDisplayRentYieldPerSFT" runat="server"></asp:Literal>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding-left: 10px; border-bottom: 1px solid #ccccce;">
                                                                            <b>K)</b>
                                                                            <asp:Literal ID="litRentYieldPerDay" Text=" Rent yield per Sft / day :" runat="server"></asp:Literal>
                                                                            &nbsp;<asp:Literal ID="litPercRentYieldPerDay" Text="<b>(J / No. of days)</b>" runat="server"></asp:Literal>
                                                                        </td>
                                                                        <td style="text-align: right; border-bottom: 1px solid #ccccce;">
                                                                            <asp:Literal ID="litDisplayRentYieldPerDay" runat="server"></asp:Literal>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr style="display: none;">
                                                            <td colspan="4" class="dTableBox" style="padding: 10px 0px;">
                                                                <div style="overflow: auto; width: 732px;">
                                                                    <asp:GridView ID="gvAdminRendPayoutDetails" runat="server" Width="1200px" ShowHeader="true"
                                                                        ShowFooter="true" AutoGenerateColumns="false">
                                                                        <Columns>
                                                                            <asp:TemplateField ItemStyle-Width="70px" FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                                                ItemStyle-HorizontalAlign="Center">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrUnitNo" runat="server" Text="Unit No"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "UnitNo")%>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <b>
                                                                                        <asp:Literal ID="litTotal" runat="server" Text="Total"></asp:Literal></b>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField FooterStyle-HorizontalAlign="Center" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center"
                                                                                ItemStyle-HorizontalAlign="Center">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrSFT" runat="server" Text="Sft"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "SFT")%>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <b>
                                                                                        <asp:Literal ID="litTotalSFT" runat="server" Text="300"></asp:Literal></b>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField FooterStyle-HorizontalAlign="Left" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left"
                                                                                ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrStartDate" runat="server" Text="Start Date"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "StartDate")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField FooterStyle-HorizontalAlign="Left" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left"
                                                                                ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrEndDate" runat="server" Text="End Date"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "EndDate")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField FooterStyle-HorizontalAlign="Center" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center"
                                                                                ItemStyle-HorizontalAlign="Center">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrNoofDays" runat="server" Text="No of Days"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "NoofDays")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField FooterStyle-HorizontalAlign="Center" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center"
                                                                                ItemStyle-HorizontalAlign="Center">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrYieldPerDay" runat="server" Text="Yield Per Day"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "YieldPerDay")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField FooterStyle-HorizontalAlign="Right" ItemStyle-Width="110px" HeaderStyle-HorizontalAlign="Right"
                                                                                ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrYieldAmount" runat="server" Text="Yield Amount (Rs.)"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "YieldAmount")%>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <b>
                                                                                        <asp:Literal ID="litTotalYieldAmount" runat="server" Text="300"></asp:Literal></b>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField FooterStyle-HorizontalAlign="Right" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Right"
                                                                                ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrTDS" runat="server" Text="TDS (Rs.)"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "TDS")%>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <b>
                                                                                        <asp:Literal ID="litTotalTDS" runat="server" Text="30"></asp:Literal></b>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField FooterStyle-HorizontalAlign="Right" ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Right"
                                                                                ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrNetAmountPayable" runat="server" Text="Net Amount Payable (Rs.)"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "NetAmountPayable")%>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <b>
                                                                                        <asp:Literal ID="litTotalNetAmountPayable" runat="server" Text="330"></asp:Literal></b>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField FooterStyle-HorizontalAlign="Left" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left"
                                                                                ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrPayOutDate" runat="server" Text="Pay Out Date"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "PayOutDate")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField FooterStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"
                                                                                ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrPaymentMode" runat="server" Text="Payment Mode"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "PaymentMode")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <EmptyDataTemplate>
                                                                            <div style="padding: 10px;">
                                                                                <b>
                                                                                    <asp:Label ID="lblGRNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                                </b>
                                                                            </div>
                                                                        </EmptyDataTemplate>
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" align="right" valign="middle" style="padding-top: 15px;">
                                                                <asp:Button ValidationGroup="QuarterDetail" ID="btnQuarterDetailSave" Text="Save"
                                                                    runat="server" ImageUrl="~/images/save.png" Style="display: inline-block;" OnClick="btnQuarterDetailSave_Click" />
                                                                <asp:Button ID="btnBackToQuarterList" Text="Back To List" runat="server" ImageUrl="~/images/save.png"
                                                                    Style="display: inline-block;" OnClick="btnBackToQuarterList_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:View>
                                            </asp:MultiView>
                                        </div>
                                        <div id="tabs-2">
                                            <asp:MultiView ID="mvRentPayoutHeader" runat="server">
                                                <asp:View ID="vRentList" runat="server">
                                                    <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td align="right" valign="middle">
                                                                <asp:Button ID="btnAddRentPayout" runat="server" Text="Add New" OnClick="btnAddRentPayout_Click"
                                                                    Style="float: right;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dTableBox" style="padding: 10px 0px;">
                                                                <style>
                                                                    .dTableBox td
                                                                    {
                                                                        padding: 0px 3px;
                                                                    }
                                                                </style>
                                                                <asp:GridView ID="gvRentPayoutQuarterSetup" runat="server" AutoGenerateColumns="False"
                                                                    Width="100%" CssClass="grid_content" OnPageIndexChanging="gvRentPayoutQuarterSetup_PageIndexChanging"
                                                                    OnRowDataBound="gvRentPayoutQuarterSetup_RowDatabound" OnRowCommand="gvRentPayoutQuarterSetup_RowCommand"
                                                                    DataKeyNames="StartDate,EndDate,QuarterID">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrQtrTitle" runat="server" Text="Title"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGvQtrTitle" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Title")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrStartDate" runat="server" Text="Start Date"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGvStartDate" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrEndDate" runat="server" Text="End Date"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGvEndDate" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="143px" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvhrrPropertyManagementCharge" runat="server" Text="Property mgmt charge"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGvPropertyManagementCharge" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Edit" ItemStyle-Width="12px" HeaderStyle-HorizontalAlign="Left"
                                                                            ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="btnEdit" ToolTip="Edit" CommandName="QUARTEREDIT" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "QuarterID")%>'
                                                                                    runat="server" ImageUrl="~/images/edit.png" Style="border: 0px; vertical-align: middle;
                                                                                    margin-top: 3px; margin-right: 7px;" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <div style="padding: 10px;">
                                                                            <b>
                                                                                <asp:Label ID="lblGRNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                            </b>
                                                                        </div>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:View>
                                                <asp:View ID="vRentAdd" runat="server">
                                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td colspan="2">
                                                                <div style="height: 26px;">
                                                                    <%if (IsInsert)
                                                                      { %>
                                                                    <div class="ResetSuccessfully">
                                                                        <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                                            <img src="../../images/success.png" />
                                                                        </div>
                                                                        <div>
                                                                            <asp:Label ID="lblRentPayoutmsg" runat="server"></asp:Label></div>
                                                                        <div style="height: 10px;">
                                                                        </div>
                                                                    </div>
                                                                    <% }%>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100px;">
                                                                <b>
                                                                    <asp:Literal ID="litQuarterTitle" Text="Quarter Title" runat="server"></asp:Literal></b>
                                                                <span class="erroraleart">
                                                                    <asp:RequiredFieldValidator ID="rfvQuarterTitle" SetFocusOnError="True" ControlToValidate="txtQuarterTitle"
                                                                        ValidationGroup="QuarterSetup" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator></span>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtQuarterTitle" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <b>
                                                                    <asp:Literal ID="litStartDate" runat="server" Text="Start Date"></asp:Literal></b>
                                                                <span class="erroraleart">
                                                                    <asp:RequiredFieldValidator ID="rfvStartDate" SetFocusOnError="True" ControlToValidate="txtStartDate"
                                                                        ValidationGroup="QuarterSetup" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                                </span>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtStartDate" SkinID="CmpTextbox" Style="width: 116px;" runat="server"
                                                                    onkeydown="return stopKey(event);"></asp:TextBox>
                                                                <%if (IsToHideDateImages == false)
                                                                  { %><asp:Image ID="imbStartDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png" />
                                                                <ajx:CalendarExtender ID="calStartDate" runat="server" PopupButtonID="imbStartDate"
                                                                    TargetControlID="txtStartDate" CssClass="MyCalendar">
                                                                </ajx:CalendarExtender>
                                                                <img src="../../images/clear.png" id="imgStartDate" style="vertical-align: middle;"
                                                                    onclick="fnClearDate('<%= txtStartDate.ClientID %>');" /><%} %>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <b>
                                                                    <asp:Literal ID="litEndDate" runat="server" Text="End Date"></asp:Literal></b>
                                                                <span class="erroraleart">
                                                                    <asp:RequiredFieldValidator ID="rfvEndDate" SetFocusOnError="True" ControlToValidate="txtEndDate"
                                                                        ValidationGroup="QuarterSetup" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                                </span>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEndDate" SkinID="CmpTextbox" runat="server" Style="width: 116px;"
                                                                    onkeydown="return stopKey(event);"></asp:TextBox>
                                                                <%if (IsToHideDateImages == false)
                                                                  { %><asp:Image ID="imbEndDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png" />
                                                                <ajx:CalendarExtender ID="calEndDate" runat="server" PopupButtonID="imbEndDate" TargetControlID="txtEndDate"
                                                                    CssClass="MyCalendar">
                                                                </ajx:CalendarExtender>
                                                                <img src="../../images/clear.png" id="imgEndDate" style="vertical-align: middle;"
                                                                    onclick="fnClearDate('<%= txtEndDate.ClientID %>');" /><% }%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 170px;">
                                                                <b>
                                                                    <asp:Literal ID="litPropertyManagementCharge" Text="Property Mgmt. charge(%)" runat="server"></asp:Literal></b>
                                                                <span class="erroraleart">
                                                                    <asp:RequiredFieldValidator ID="rfvPropertyManagementCharge" SetFocusOnError="True"
                                                                        ControlToValidate="txtPropertymgmtcharge" ValidationGroup="QuarterSetup" runat="server"
                                                                        ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator></span>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPropertymgmtcharge" runat="server" MaxLength="18" Style="width: 85px;"></asp:TextBox>
                                                                <ajx:FilteredTextBoxExtender ID="ftePropertymgmtcharge" runat="server" TargetControlID="txtPropertymgmtcharge"
                                                                    ValidChars="0123456789." FilterMode="ValidChars">
                                                                </ajx:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Literal ID="litNote" Text="Note" runat="server"></asp:Literal>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtNote" Style="width: 361px; height: 112px;" TextMode="MultiLine"
                                                                    runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Literal ID="litUploadCertificate" runat="server" Text="Upload Certificate"></asp:Literal>
                                                                <span class="erroraleart">
                                                                    <asp:RegularExpressionValidator ID="revuploadCertificate" runat="server" ControlToValidate="fuQuarterCertificate"
                                                                        SetFocusOnError="true" CssClass="rfv_ErrorStar" ValidationGroup="QuarterSetup"
                                                                        Display="Dynamic" ErrorMessage="*" ValidationExpression="^.+(.pdf|.jpg|.jpeg|.gif|.png|.bmp|.JPG|.JPEG|.GIF|.PNG|.BMP|.TIF|.tif|.PDF|.doc|.DOC|.docx|.DOCX|xlsx|XLSX)$"></asp:RegularExpressionValidator>
                                                                </span>
                                                            </td>
                                                            <td>
                                                                <div id='browse_file_grid' style="float: left;">
                                                                    <asp:FileUpload ID="fuQuarterCertificate" runat="server" Height="25px" ToolTip=".pdf|.jpg|.jpeg|.gif|.png|.bmp|.JPG|.JPEG|.GIF|.PNG|.BMP|.TIF|.tif|.PDF|.doc|.DOC|.docx|.DOCX|xlsx|XLSX" /></div>
                                                                &nbsp;&nbsp;<a id="aQuarterCertificate" runat="server" visible="false" target="_blank">
                                                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/images/View.png" /></a>
                                                                <asp:ImageButton ID="imgDelete" BorderStyle="None" runat="server" ImageUrl="~/images/DeleteFile.png"
                                                                    OnClick="imgDelete_OnClick" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="right" valign="middle">
                                                                <asp:Button ValidationGroup="QuarterSetup" ID="btnSave" Text="Save" runat="server"
                                                                    ImageUrl="~/images/save.png" Style="display: inline-block;" OnClick="btnSave_Click"
                                                                    OnClientClick="return postbackButtonClick();" />
                                                                <asp:Button ID="btnCancel" Text="Back To List" OnClick="btnCancel_OnClick" runat="server"
                                                                    ImageUrl="~/images/cancle.png" Style="display: inline-block;" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:View>
                                            </asp:MultiView>
                                        </div>
                                    </div>
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
                </td>
            </tr>
        </table>
        <div>
            <ajx:ModalPopupExtender ID="mpeMessageBox" runat="server" TargetControlID="hdnMessageBox"
                PopupControlID="pnlMessageBox" BackgroundCssClass="mod_background" CancelControlID="btnMessageBoxOk">
            </ajx:ModalPopupExtender>
            <asp:HiddenField ID="hdnMessageBox" runat="server" />
            <asp:Panel ID="pnlMessageBox" runat="server" Style="display: none;">
                <div style="width: 500px; height: 200px; margin-top: 25px;">
                    <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
                        <tr>
                            <td class="modelpopup_boxtopleft">
                                &nbsp;
                            </td>
                            <td class="modelpopup_boxtopcenter">
                                &nbsp;
                            </td>
                            <td class="modelpopup_boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="modelpopup_boxleft">
                                &nbsp;
                            </td>
                            <td class="modelpopup_box_bg">
                                <div style="width: 100px; float: left; margin-top: 10px;">
                                    <asp:HyperLink ID="HyperLink1" runat="server">
                                        <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                            ID="Image1" runat="server" />
                                    </asp:HyperLink>
                                </div>
                                <div style="float: left; width: 290px; margin-top: 40px; margin-left: 10px;">
                                    <asp:Label ID="litMessageBox" runat="server"></asp:Label>
                                </div>
                                <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                    <tr>
                                        <td align="center" valign="middle">
                                            <asp:Button ID="btnMessageBoxOk" runat="server" Text="OK" Style="display: inline;
                                                padding-right: 10px;" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="modelpopup_boxright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="modelpopup_boxbottomleft">
                                &nbsp;
                            </td>
                            <td class="modelpopup_boxbottomcenter">
                            </td>
                            <td class="modelpopup_boxbottomright">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSave" />
        <asp:PostBackTrigger ControlID="btnCancel" />
        <asp:PostBackTrigger ControlID="gvRentPayoutQuarterSetup" />
        <asp:PostBackTrigger ControlID="btnAddRentPayout" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updAdminRentPayout" ID="updateprogressRentPayout"
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