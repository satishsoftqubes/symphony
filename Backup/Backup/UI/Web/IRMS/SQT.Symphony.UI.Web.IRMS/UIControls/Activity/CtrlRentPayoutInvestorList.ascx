<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRentPayoutInvestorList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Activity.CtrlRentPayoutInvestorList" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function pageLoad(sender, args) {

        $(document).ready(function () {
            $("#<%=txtSLocation.ClientID%>").autocomplete('../SetUp/CityAutoComplete.ashx');
            $("#<%=txtSInvestorName.ClientID%>").autocomplete('../Investors/InvestorAutoComplete.ashx');
        });
    }
   
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function initCascadingAutoComplete() {
        var moviesAutoComplete = $find('autoCompleteBehavior1');
        var actorsAutoComplete = $find('autoCompleteBehavior2');
        actorsAutoComplete.set_contextKey(moviesAutoComplete.get_element().value);
        moviesAutoComplete.add_itemSelected(cascade);
    }

    function cascade(sender, ev) {
        var actorsAutoComplete = $find('autoCompleteBehavior2');
        actorsAutoComplete.set_contextKey(ev.get_text());
        actorsAutoComplete.get_element().value = '';

        if (actorsAutoComplete.get_element().disabled) {
            actorsAutoComplete.get_element().disabled = false;
        }
    }
    Sys.Application.add_load(initCascadingAutoComplete);
</script>

<script type="text/javascript">
    function ShowImage() {

        document.getElementById('<%=txtSearchExecutiveName.ClientID%>').style.backgroundImage = 'url(images/loading.gif)';
        document.getElementById('<%=txtSearchExecutiveName.ClientID%>').style.backgroundRepeat = 'no-repeat';
        document.getElementById('<%=txtSearchExecutiveName.ClientID%>').style.backgroundPosition = 'right';

    }
    function HideImage() {
        document.getElementById('<%=txtSearchChannelPartnerFirm.ClientID%>').style.backgroundImage = 'none';
    }

    function ShowImageForChannelPartner() {
        document.getElementById('<%=txtSearchChannelPartnerFirm.ClientID%>').style.backgroundImage = 'url(images/loading.gif)';
        document.getElementById('<%=txtSearchChannelPartnerFirm.ClientID%>').style.backgroundRepeat = 'no-repeat';
        document.getElementById('<%=txtSearchChannelPartnerFirm.ClientID%>').style.backgroundPosition = 'right';
    }

    function HideImageForChannelPartner() {
        document.getElementById('<%=txtSearchChannelPartnerFirm.ClientID%>').style.backgroundImage = 'none';
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
    
    .autocomplete_completionListElement
    {
        visibility: hidden;
        margin: 0px !important;
        background-color: inherit;
        color: windowtext;
        border: buttonshadow;
        border-width: 1px;
        border-style: solid;
        cursor: 'default';
        overflow: auto;
        height: auto;
        text-align: left;
        list-style-type: none;
    }
    .autocomplete_completionListElement li a:hover
    {
        color: White !important;
    }
    /* AutoComplete highlighted item */
    
    .autocomplete_highlightedListItem
    {
        background-color: #0A246A;
        color: white;
        padding: 1px;
    }
    
    /* AutoComplete item */
    
    .autocomplete_listItem
    {
        background-color: window;
        color: windowtext;
        padding: 1px;
    }
</style>
<script type="text/javascript">
    function GetSelectedQuarterID() {
        var e = document.getElementById('<%= ddlQuarterList.ClientID %>');
        if (e.selectedIndex != 0) {
            document.getElementById('<%= QuarterIDTopassForPrint.ClientID %>').value = e.options[e.selectedIndex].value;
        }
        else {
            document.getElementById('<%= QuarterIDTopassForPrint.ClientID %>').value = '';
        }

    }
    function fnRentPayoutInvestorListPrint() {
        var InvName = '';
        var CityName = '';
        var CPName = '';
        var CPFirm = '';

        InvName = document.getElementById('<%= txtSInvestorName.ClientID %>').value;
        CityName = document.getElementById('<%= txtSLocation.ClientID %>').value;
        CPFirm = document.getElementById('<%= txtSearchChannelPartnerFirm.ClientID %>').value;
        CPName = document.getElementById('<%= txtSearchExecutiveName.ClientID %>').value;

        var QuarterID = document.getElementById('<%= QuarterIDTopassForPrint.ClientID %>').value;
        if (QuarterID != '') {
            window.open("RentPayoutInvestorListPrint.aspx?QID=" + QuarterID + "&InvName=" + InvName + "&CityName=" + CityName + "&CPFirm=" + CPFirm + "&CPName=" + CPName, "Investor List", "height=600,width=1000,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
        }
    }
    function openViewer() {
        var Preview = '<%=IsPreview%>';
        window.open("../../ReportFiles/frmViewer.aspx?preview=" + Preview);
    }
</script>
<asp:UpdatePanel ID="updRentPayoutInvestorList" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="QuarterIDTopassForPrint" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                RENT PAYOUT INVESTOR LIST
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td>
                                <asp:MultiView ID="mvRentPayout" runat="server">
                                    <asp:View ID="vInvestorListForRentPayout" runat="server">
                                        <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td>
                                                    <%if (IsInsert)
                                                      { %>
                                                    <div class="ResetSuccessfully">
                                                        <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                            <img src="../../images/success.png" />
                                                        </div>
                                                        <div>
                                                            <asp:Label ID="lblResVoucherMsg" runat="server"></asp:Label></div>
                                                        <div style="height: 10px;">
                                                        </div>
                                                    </div>
                                                    <% }%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" valign="top">
                                                    <table cellpadding="2" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td style="width: 75px;">
                                                                <asp:Literal ID="litSInvList" runat="server" Text="Quarter List"></asp:Literal>&nbsp;&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlQuarterList" runat="server" Style="width: 203px;">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvddlQuarterList" runat="server" ControlToValidate="ddlQuarterList"
                                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                    ErrorMessage="*" ValidationGroup="InvestorListPrint"></asp:RequiredFieldValidator>
                                                                <asp:ImageButton ID="btnSearch" Style="border: 0px; vertical-align: middle; margin-top: 0px;
                                                                    margin-left: 5px;" runat="server" ImageUrl="~/images/search-icon.png" OnClick="btnSearch_Click"
                                                                    OnClientClick="fnDisplayCatchErrorMessage()" Visible="true" />
                                                            </td>
                                                            <td>
                                                                <div style="display: inline;">
                                                                    <asp:Button ID="btnViewAllRentPayoutInvestor" ValidationGroup="InvestorListPrint"
                                                                        runat="server" Text="View Detail" OnClientClick="fnRentPayoutInvestorListPrint()"
                                                                        Style="display: inline;" />
                                                                    <asp:Button ID="btnShowReport" ValidationGroup="InvestorListPrint" runat="server"
                                                                        Text="Show Report" OnClick="btnShowReport_Click" Style="display: none;" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="2" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td style="width: 150px;">
                                                                <asp:Literal ID="litSInvestorName" runat="server" Text="Name"></asp:Literal>&nbsp;&nbsp;
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:TextBox ID="txtSInvestorName" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 105px;">
                                                                <asp:Literal ID="litSLocation" runat="server" Text="City"></asp:Literal>&nbsp;&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtSLocation" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 135px;">
                                                                <asp:Literal ID="Literal1" runat="server" Text="Channel Partner (Firm)"></asp:Literal>&nbsp;&nbsp;
                                                            </td>
                                                            <td style="width: 200px;">
                                                                <asp:TextBox ID="txtSearchChannelPartnerFirm" runat="server"></asp:TextBox>
                                                                <ajx:AutoCompleteExtender runat="server" ID="autoCompleteExtender1" BehaviorID="autoCompleteBehavior1"
                                                                    ServiceMethod="GetChannelPartnerFirm" ServicePath="~/Applications/Investors/InvestorCascadingAutocomplete.asmx"
                                                                    MinimumPrefixLength="1" TargetControlID="txtSearchChannelPartnerFirm" CompletionListCssClass="autocomplete_completionListElement"
                                                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                    OnClientPopulating="ShowImageForChannelPartner" OnClientPopulated="HideImageForChannelPartner">
                                                                </ajx:AutoCompleteExtender>
                                                            </td>
                                                            <td style="width: 155px;">
                                                                <asp:Literal ID="Literal2" runat="server" Text="Channel Partner (Person)"></asp:Literal>&nbsp;&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtSearchExecutiveName" runat="server"></asp:TextBox>
                                                                <ajx:AutoCompleteExtender runat="server" ID="autoCompleteExtender2" BehaviorID="autoCompleteBehavior2"
                                                                    ServiceMethod="GetExecutiveName" ServicePath="~/Applications/Investors/InvestorCascadingAutocomplete.asmx"
                                                                    MinimumPrefixLength="1" TargetControlID="txtSearchExecutiveName" CompletionListCssClass="autocomplete_completionListElement"
                                                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                    OnClientPopulating="ShowImage" OnClientPopulated="HideImage">
                                                                </ajx:AutoCompleteExtender>
                                                                <asp:ImageButton ID="btnSearchMore" runat="server" Style="border: 0px; vertical-align: middle;
                                                                    margin-top: 0px; margin-left: 5px;" ImageUrl="~/images/search-icon.png" OnClick="btnSearch_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <div class="pageinfodivider">
                                                    </div>
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
                                                    <div style="width: 850px; overflow: auto;">
                                                        <asp:GridView ID="grdInvestorList" runat="server" AutoGenerateColumns="False" Width="1250px"
                                                            OnRowCommand="grdInvestorList_RowCommand" OnRowDataBound="grdInvestorList_RowDataBound"
                                                            OnPageIndexChanging="grdInvestorList_OnPageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%--<asp:TemplateField HeaderText="Name" ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkBtn" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FullName")%>'
                                                                            CommandName="GETRENTPAYOUTDETAILS" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorID")%>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>--%>
                                                                <asp:BoundField DataField="FullName" HeaderText="Name" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="150px" />
                                                                <asp:BoundField DataField="BankAcctName" HeaderText="Bank A/c Holder Name" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="135px" />
                                                                <asp:BoundField DataField="TotalUnit" HeaderText="Units" ItemStyle-Width="15px" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="TotalSqftForInvestor" HeaderText="Total Sft" ItemStyle-Width="70px"
                                                                    HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                                                                <asp:BoundField DataField="TotalRentPayoutByInvestor" HeaderText="Rent Amount" ItemStyle-Width="65px"
                                                                    HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                                                                <asp:BoundField DataField="BankName" HeaderText="Bank Name" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="125px" />
                                                                <asp:BoundField DataField="AccountNo" HeaderText="Bank A/c No." HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="85px" />
                                                                <asp:BoundField DataField="IFSCCode" HeaderText="IFSC Code" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" />
                                                                <asp:BoundField DataField="PanNo" HeaderText="Pan No." HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="90px" />
                                                                <asp:BoundField DataField="EMail" HeaderText="Email" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px" />
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <div class="pagecontent_info">
                                                                    <div class="NoItemsFound">
                                                                        <h2>
                                                                            <asp:Literal ID="Literal3" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                                    </div>
                                                                </div>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div style="float: Left;">
                                                        <asp:Button ID="btnPrint" Text="Print" Style="float: left; margin-left: 5px;" runat="server" Visible="false"
                                                            ImageUrl="~/images/cancle.png" OnClick="btnPrint_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                        <asp:Button ID="btnPreview" Visible="false" Text="Preview" Style="float: left; margin-left: 5px;"
                                                            runat="server" ImageUrl="~/images/save.png" OnClick="btnPreview_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                        <asp:ImageButton ID="imgbtnPDF" Text="" Style="float: left; margin-left: 5px;" ToolTip="ExportToPDF"
                                                            runat="server" ImageUrl="~/images/report_pdf.png" OnClick="imgbtnPDF_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                        <asp:ImageButton ID="imgbtnXLSX" Text="" Style="float: left; margin-left: 5px;" ToolTip="ExportToXLSX"
                                                            runat="server" ImageUrl="~/images/report_xlsx.png" OnClick="imgbtnXLSX_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage()" />
                                                        <asp:ImageButton ID="imgbtnDOC" Text="" Style="float: left; margin-left: 5px;" ToolTip="ExportToDOC"
                                                            runat="server" ImageUrl="~/images/report_word.png" OnClick="imgbtnDOC_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage()" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                    <asp:View ID="vRentPayoutDetails" runat="server">
                                        <div style="font-size: 12px; font-weight: bold; margin-left: 10px; padding-top: 10px;">
                                            <asp:Literal ID="litQuarterTitle" runat="server" Text="Quarter Title :"> </asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal
                                                ID="litDispQuarterTitle" Text="First Quarter" runat="server"></asp:Literal>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Literal ID="litDuspQuarterPeriod" runat="server" Text="Quarter period :"> </asp:Literal>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal
                                                ID="litQuarterPeriod" runat="server"></asp:Literal>
                                        </div>
                                        <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                            <tr>
                                                <td class="dTableBox" style="padding: 10px 10px 10px 10px;">
                                                    <style>
                                                        .dTableBox td
                                                        {
                                                            padding: 0px 3px;
                                                        }
                                                    </style>
                                                    <div style="width: 725px; overflow: auto;">
                                                        <asp:GridView ID="gvAdminRendPayoutDetails" runat="server" Width="1000px" ShowHeader="true"
                                                            ShowFooter="true" AutoGenerateColumns="false" OnRowDataBound="gvAdminRendPayoutDetails_RowDatabound">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField FooterStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                                    ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrUnitNo" runat="server" Text="Unit No"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>
                                                                            <asp:Literal ID="litTotal" runat="server" Text="Total"></asp:Literal></b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField FooterStyle-HorizontalAlign="Left" ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrStartDate" runat="server" Text="Start Date"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "StartDate")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField FooterStyle-HorizontalAlign="Left" ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrEndDate" runat="server" Text="End Date"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "EndDate")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField FooterStyle-HorizontalAlign="Left" ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrFinalPaymentDate" runat="server" Text="Final Payment Date"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "FinalPaymentDate")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField FooterStyle-HorizontalAlign="Left" ItemStyle-Width="85px" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-HorizontalAlign="Left" Visible="false">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrFinalPaymentDate" runat="server" Text="Sell Date"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "SellDate")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField FooterStyle-HorizontalAlign="Right" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center"
                                                                    ItemStyle-HorizontalAlign="Right">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrSFT" runat="server" Text="Sft"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "TotalSqft")%>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>
                                                                            <asp:Literal ID="litTotalSFT" runat="server"></asp:Literal></b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField FooterStyle-HorizontalAlign="Center" ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Center"
                                                                    ItemStyle-HorizontalAlign="Right">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrNoofDays" runat="server" Text="No of Days"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "NoofDays")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField FooterStyle-HorizontalAlign="Center" ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Center"
                                                                    ItemStyle-HorizontalAlign="Right">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrYieldPerDay" runat="server" Text="Yield Per day"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "YieldPerDay")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField FooterStyle-HorizontalAlign="Center" ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Center"
                                                                    ItemStyle-HorizontalAlign="Right">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrYieldPersft" runat="server" Text="Yield Per sft"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "RentYieldPerSqft")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField FooterStyle-HorizontalAlign="Right" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Right"
                                                                    ItemStyle-HorizontalAlign="Right">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrYieldAmount" runat="server" Text="Yield Amount"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "YieldAmount")%>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>
                                                                            <asp:Literal ID="litTotalYieldAmount" runat="server"></asp:Literal></b>
                                                                    </FooterTemplate>
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
                                                <td align="right" valign="middle" style="padding: 10px 10px 10px 10px;">
                                                    <asp:Button ID="btnBackToList" runat="server" Style="float: right;" Text="Back To List"
                                                        OnClick="btnBackToList_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                </asp:MultiView>
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
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnShowReport" />
        <asp:PostBackTrigger ControlID="btnPreview" />
        <asp:PostBackTrigger ControlID="btnPrint" />
        <asp:PostBackTrigger ControlID="imgbtnPDF" />
        <asp:PostBackTrigger ControlID="imgbtnXLSX" />
        <asp:PostBackTrigger ControlID="imgbtnDOC" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updRentPayoutInvestorList" ID="UpdateProgressRentPayoutInvestorList"
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
