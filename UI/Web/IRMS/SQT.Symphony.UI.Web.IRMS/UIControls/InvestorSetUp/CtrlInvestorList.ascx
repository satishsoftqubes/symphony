<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInvestorList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlInvestorList" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="../AlphaBet/CtrlAlphaBet.ascx" TagName="CtrlAlphaBet" TagPrefix="uc2" %>
<script language="javascript" type="text/javascript">

    function fnAlphabatsClick(alpha) {
        document.getElementById('<%= hfSelectedAlphabet.ClientID %>').value = alpha;

        __doPostBack('ctl00$ContentPlaceHolder1$CtrlInvestorList1$lnkAlphabet', '');
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function pageLoad(sender, args) {

        $(document).ready(function () {
            $("#<%=txtSLocation.ClientID%>").autocomplete('../SetUp/CityAutoComplete.ashx');
            $("#<%=txtSInvestorName.ClientID%>").autocomplete('InvestorAutoComplete.ashx');
        });
    }
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
<script type="text/javascript">

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
<script language="javascript">

    function openViewer() {
        var Preview = '<%=IsPreview%>';
        window.open("../../ReportFiles/frmViewer.aspx?preview=" + Preview);
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
<asp:UpdatePanel ID="updInvestorList" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <div>
                                    <div style="display: inline; float: left;">
                                        INVESTORS&nbsp;<asp:Literal ID="litInvestorsCount" runat="server"></asp:Literal>
                                        <div style="visibility: hidden;">
                                            <asp:LinkButton ID="lnkAlphabet" runat="server" OnClick="lnkAlphabet_OnClick"></asp:LinkButton>
                                        </div>
                                        <asp:HiddenField ID="hfSelectedAlphabet" runat="server" />
                                    </div>
                                    <div style="display: inline; float: right; padding-right:10px;">
                                        <asp:LinkButton ID="lnkInvestorStatus" runat="server" Text="Investor Status" PostBackUrl="~/Applications/Investors/InvestorStatus.aspx" ForeColor="#0067a4"></asp:LinkButton>
                                    </div>
                                </div>
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
                                <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td align="left" valign="top">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td class="alpha" colspan="4">
                                                        <a href="#" onclick="fnAlphabatsClick('ALL');">ALL</a>&nbsp;&nbsp;|&nbsp; <a href="#"
                                                            onclick="fnAlphabatsClick('A');">A</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('B');">
                                                                B</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('C');">C</a>&nbsp;&nbsp;|&nbsp;
                                                        <a href="#" onclick="fnAlphabatsClick('D');">D</a>&nbsp;&nbsp;|&nbsp; <a href="#"
                                                            onclick="fnAlphabatsClick('E');">E</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('F');">
                                                                F</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('G');">G</a>&nbsp;&nbsp;|&nbsp;
                                                        <a href="#" onclick="fnAlphabatsClick('H');">H</a>&nbsp;&nbsp;|&nbsp; <a href="#"
                                                            onclick="fnAlphabatsClick('I');">I</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('J');">
                                                                J</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('K');">K</a>&nbsp;&nbsp;|&nbsp;
                                                        <a href="#" onclick="fnAlphabatsClick('L');">L</a>&nbsp;&nbsp;|&nbsp; <a href="#"
                                                            onclick="fnAlphabatsClick('M');">M</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('N');">
                                                                N</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('O');">O</a>&nbsp;&nbsp;|&nbsp;
                                                        <a href="#" onclick="fnAlphabatsClick('P');">P</a>&nbsp;&nbsp;|&nbsp; <a href="#"
                                                            onclick="fnAlphabatsClick('Q');">Q</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('R');">
                                                                R</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('S');">S</a>&nbsp;&nbsp;|&nbsp;
                                                        <a href="#" onclick="fnAlphabatsClick('T');">T</a>&nbsp;&nbsp;|&nbsp; <a href="#"
                                                            onclick="fnAlphabatsClick('U');">U</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('V');">
                                                                V</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('W');">W</a>&nbsp;&nbsp;|&nbsp;
                                                        <a href="#" onclick="fnAlphabatsClick('X');">X</a>&nbsp;&nbsp;|&nbsp; <a href="#"
                                                            onclick="fnAlphabatsClick('Y');">Y</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('Z');">
                                                                Z</a>
                                                    </td>
                                                </tr>
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
                                                        <%--<asp:DropDownList ID="ddlManagerType" AutoPostBack="true" OnSelectedIndexChanged="ddlManagerType_SelectedIndexChanged"
                                                            runat="server" Style="width: 165px;">
                                                        </asp:DropDownList>--%>
                                                        <asp:TextBox ID="txtSearchChannelPartnerFirm" runat="server" AutoPostBack="true"></asp:TextBox>
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
                                                        <%--<asp:DropDownList ID="ddlRelationManagementID" runat="server" Style="width: 165px;">
                                                        </asp:DropDownList>--%>
                                                        <asp:TextBox ID="txtSearchExecutiveName" runat="server"></asp:TextBox>
                                                        <ajx:AutoCompleteExtender runat="server" ID="autoCompleteExtender2" BehaviorID="autoCompleteBehavior2"
                                                            ServiceMethod="GetExecutiveName" ServicePath="~/Applications/Investors/InvestorCascadingAutocomplete.asmx"
                                                            MinimumPrefixLength="1" TargetControlID="txtSearchExecutiveName" CompletionListCssClass="autocomplete_completionListElement"
                                                            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                            OnClientPopulating="ShowImage" OnClientPopulated="HideImage">
                                                        </ajx:AutoCompleteExtender>
                                                        <asp:ImageButton ID="btnSearch" runat="server" Style="border: 0px; vertical-align: middle;
                                                            margin-top: 0px; margin-left: 5px;" ImageUrl="~/images/search-icon.png" OnClick="btnSearch_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="pageinfodivider">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%if (IsInsert)
                                              { %>
                                            <div class="ResetSuccessfully">
                                                <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                    <img src="../../images/success.png" />
                                                </div>
                                                <div>
                                                    <asp:Label ID="lblInvestorMsg" runat="server"></asp:Label></div>
                                                <div style="height: 10px;">
                                                </div>
                                            </div>
                                            <% }%>
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td align="right" valign="middle">
                                            <asp:Button ID="btnAddUp" runat="server" Text="Add New" OnClick="btnAdd_Click" Style="float: right;" />
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="dTableBox" style="padding: 10px 0px;">
                                            <asp:GridView ID="grdInvestorList" runat="server" AutoGenerateColumns="False" Width="100%"
                                                OnRowCommand="grdInvestorList_RowCommand" OnRowDataBound="grdInvestorList_RowDataBound"
                                                OnPageIndexChanging="grdInvestorList_OnPageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="FullName" HeaderText="Name" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left"  />
                                                    <asp:TemplateField HeaderText="Mobile No" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                        ItemStyle-Width="110px">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="litMobileNo" runat="server"></asp:Literal>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="EMail" HeaderText="Email" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px" />
                                                    <asp:BoundField DataField="CityName" HeaderText="City" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" />
                                                    <asp:TemplateField HeaderText="Units" ItemStyle-Width="15px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkBtn" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "TotalUnit")%>'
                                                                CommandName="GETUNIT" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorID")%>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View/Edit" ItemStyle-Width="18px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" ToolTip="Edit" CommandName="EDITCMD" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorID")%>'
                                                                runat="server" ImageUrl="~/images/edit.png" Style="border: 0px; vertical-align: middle;
                                                                margin-top: 3px; margin-right: 7px;" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="18px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <a href="#" style="border: 0px;"> 
                                                                <asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandName="DELETECMD" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorID")%>'
                                                                    runat="server" ImageUrl="~/images/delete_icon.png" Style="border: 0px; vertical-align: middle;
                                                                    margin-top: 2px; margin-right: 7px;" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="E" ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="rdbACT" runat="server" Width="12px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="D" ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="rdbINACT" runat="server" Width="12px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="middle">
                                            <asp:ImageButton ID="imgbtnDOC" Text="" Style="float: left; margin-left: 5px; border: 0px;"
                                                ToolTip="ExportToDOC" runat="server" ImageUrl="~/images/report_word.png" OnClick="imgbtnDOC_Click"
                                                OnClientClick="fnDisplayCatchErrorMessage()" />
                                            <asp:ImageButton ID="imgbtnXLSX" Text="" Style="float: left; margin-left: 5px; border: 0px;"
                                                ToolTip="ExportToXLSX" runat="server" ImageUrl="~/images/report_xlsx.png" OnClick="imgbtnXLSX_Click"
                                                OnClientClick="fnDisplayCatchErrorMessage()" />
                                            <asp:ImageButton ID="imgbtnPDF" Text="" Style="float: left; margin-left: 5px; border: 0px;"
                                                ToolTip="ExportToPDF" runat="server" ImageUrl="~/images/report_pdf.png" OnClick="imgbtnPDF_Click"
                                                OnClientClick="fnDisplayCatchErrorMessage()" />
                                            <asp:Button ID="btnPreview" Visible="false" Text="Preview" Style="float: left; margin-left: 5px;"
                                                runat="server" ImageUrl="~/images/save.png" OnClick="btnPreview_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                            <asp:Button ID="btnPrint" Text="Print" Style="float: left; margin-left: 5px;" runat="server"
                                                ImageUrl="~/images/cancle.png" OnClick="btnPrint_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td align="right" valign="middle">
                                            <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" Style="float: right;" />
                                        </td>
                                    </tr>--%>
                                </table>
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
                    <%--<div class="clear">
                        <uc1:MsgBox ID="MessageBox" runat="server" />
                    </div>--%>
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="pnl"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="pnl" runat="server" Style="display: none;">
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
                                <asp:HyperLink ID="CloseModelPopup" runat="server">
                                    <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                        ID="btnImage" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div style="float: left; width: 225px; margin-top: 40px; margin-left: 10px;">
                                <asp:Label ID="lblErrorMessage" runat="server" Text="Sure you want to delete?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <div>
                                            <asp:Button ID="btnAddressSave" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                                OnClick="btnAddressSave_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                            <asp:Button ID="btnAddressCancel" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                                OnClick="btnAddressCancel_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
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
    </ContentTemplate>
    <Triggers>
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
<asp:UpdateProgress AssociatedUpdatePanelID="updInvestorList" ID="UpdateProgressInvestorList"
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
