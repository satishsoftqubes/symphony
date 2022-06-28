<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlLedgerReport.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio.CtrlLedgerReport" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script src="../../Scripts/Common.js" type="text/javascript"></script>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function ClearDate(para1) {        
        document.getElementById(para1).value = '';
    }

    function fnCheckDate() {
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
    

</script>
<asp:UpdatePanel ID="updFolioList" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hfDateFormat" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server" Text="Folio List"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td align="left">
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td width="80px">
                                                <asp:Label ID="lblSearchCounterNo" runat="server" Text="Counter No."></asp:Label>
                                            </td>
                                            <td width="225px">
                                                <asp:DropDownList ID="ddlSearchCounterNo" runat="server" Style="width: 175px;">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="80px">
                                                <asp:Label ID="lblSearchResNo" runat="server" Text="Res No."></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSearchResNo" runat="server" Style="width: 175px;">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSearchAgent" runat="server" Text="Agent"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSearchAgent" runat="server" Style="width: 175px;">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="litSearchFolioNo" runat="server" Text="Folio No."></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSearchFolioNo" runat="server" Style="width: 175px;">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSearchItem" runat="server" Text="Item"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSearchItem" runat="server" Style="width: 175px;">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSearchUser" runat="server" Text="User"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSearchUser" runat="server" Style="width: 175px;">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSearchFromDate" runat="server" Text="From Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearchFromDate" runat="server" Style="width: 130px !important;"
                                                    SkinID="searchtextbox" onkeydown="return stopKey(event);"></asp:TextBox>
                                                <asp:Image ID="imgSearchFromDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                    Height="20px" Width="20px" />
                                                <ajx:CalendarExtender ID="calSearchFromDate" PopupButtonID="imgSearchFromDate" TargetControlID="txtSearchFromDate"
                                                    runat="server">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" id="imgclearDateFrom" style="vertical-align: middle;"
                                                    title="Clear Date" onclick="ClearDate('<%= txtSearchFromDate.ClientID %>');" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSearchToDate" runat="server" Text="To Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearchToDate" runat="server" Style="width: 130px !important;"
                                                    SkinID="searchtextbox" onkeydown="return stopKey(event);"></asp:TextBox>
                                                <asp:Image ID="imgSearchToDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                    Height="20px" Width="20px" />
                                                <ajx:CalendarExtender ID="calSearchToDate" PopupButtonID="imgSearchToDate" TargetControlID="txtSearchToDate"
                                                    runat="server">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" id="imgclearDateTo" style="vertical-align: middle;"
                                                    title="Clear Date" onclick="ClearDate('<%= txtSearchToDate.ClientID %>');" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSearchAccount" runat="server" Text="Account"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSearchAccount" runat="server" Style="width: 175px;">
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; margin: 2px 0 0 5px; vertical-align: middle;" OnClick="btnSearch_Click"
                                                    OnClientClick="return fnCheckDate();" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: 2px 0 0 10px;" OnClick="imgbtnClearSearch_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSearchBookNo" runat="server" Text="Book No."></asp:Label>
                                            </td>
                                            <td colspan="5">
                                                <asp:TextBox ID="txtSearchBookNo" runat="server" Style="width: 172px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="padding-bottom: 15px;">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litFolioList" runat="server" Text="Folio List"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvLedgerReport" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                        Width="100%" OnRowDataBound="gvLedgerReport_OnRowDataBound" OnPageIndexChanging="gvLedgerReport_PageIndexChanging">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <div style="float: left; width: 18px; border-right: 1px solid #ccc;">
                                                                        &nbsp;
                                                                    </div>
                                                                    <div style="float: left; width: 80px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        &nbsp;
                                                                        <asp:Label ID="lblGRGvHdrBookNo" runat="server" Text="Trans No."></asp:Label>
                                                                    </div>
                                                                    <div style="float: left; width: 90px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        &nbsp;
                                                                        <asp:Label ID="lblGRGvHdrResNo" runat="server" Text="Res No."></asp:Label>
                                                                    </div>
                                                                    <div style="float: left; width: 90px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        &nbsp;
                                                                        <asp:Label ID="lblGRGvHdrFolioNo" runat="server" Text="Folio No."></asp:Label></div>
                                                                    <div style="float: left; width: 90px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        &nbsp;<asp:Label ID="lblGRGvHdrSourceFolio" runat="server" Text="Source Folio"></asp:Label></div>
                                                                    <div style="float: left; width: 80px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        &nbsp;
                                                                        <asp:Literal ID="lblGRGvHdrEntryDate" runat="server" Text="Date"></asp:Literal></div>
                                                                    <%--<div style="float: left; width: 180px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        &nbsp;
                                                                        <asp:Label ID="lblGRGvHdrGeneralType" runat="server" Text="General Type"></asp:Label></div>--%>
                                                                    <div style="float: left; width: 200px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        &nbsp;
                                                                        <asp:Literal ID="lblGRGvHdrAccount" runat="server" Text="Account"></asp:Literal></div>

                                                                    <div style="float: left; width: 100px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        &nbsp;
                                                                        <asp:Literal ID="lblGRGvHdrCredit" runat="server" Text="Credit"></asp:Literal></div>
                                                                    <div style="float: left; padding-left: 1px;">
                                                                        &nbsp;
                                                                        <asp:Literal ID="lblGRGvHdrDebit" runat="server" Text="Debit"></asp:Literal></div>
                                                                    
                                                                    <%--<div style="float: left; padding-left: 1px;">
                                                                        &nbsp;
                                                                        <asp:Label ID="lblGRGvHdrDescription" runat="server" Text="Description"></asp:Label></div>--%>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <div style="float: left; width: 20px; border-right: 1px solid #ccc;">
                                                                        <img id="imgGR<%# Container.DataItemIndex %>" alt="" src="../../images/icon111.png"
                                                                            onclick="fnOnClickInnerGrid(this);" />
                                                                    </div>
                                                                    <div style="float: left; width: 80px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        &nbsp;<%# DataBinder.Eval(Container.DataItem, "BookNo")%></div>
                                                                    <div style="float: left; width: 90px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        &nbsp;
                                                                        <%# DataBinder.Eval(Container.DataItem, "ReservationNo")%></div>
                                                                    <div style="float: left; width: 90px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        &nbsp;
                                                                        <%# DataBinder.Eval(Container.DataItem, "FolioNo")%></div>
                                                                    <div style="float: left; width: 90px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        &nbsp;
                                                                        <%# DataBinder.Eval(Container.DataItem, "SrcFolioNo")%></div>
                                                                    <div style="float: left; width: 80px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        &nbsp;
                                                                        <asp:Literal ID="lblParentGvEntryDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Literal></div>
                                                                    <%-- <div style="float: left; width: 180px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        &nbsp;
                                                                        <%# DataBinder.Eval(Container.DataItem, "GeneralIDType_Term")%></div>--%>
                                                                    <div style="float: left; width: 200px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        &nbsp;
                                                                        <asp:Literal ID="lblGRGvAccount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Account")%>'></asp:Literal>
                                                                    </div>
                                                                    <div style="float: left; width: 100px; border-right: 1px solid #ccc; padding-left: 1px;">
                                                                        &nbsp;
                                                                        <asp:Literal ID="lblParentCR" runat="server"></asp:Literal>
                                                                    </div>
                                                                    <div style="float: left; padding-left: 1px;">
                                                                        &nbsp;
                                                                        <asp:Literal ID="lblParentDB" runat="server"></asp:Literal></div>
                                                                    
                                                                    <%--<div style="float: left; padding-left: 1px;">
                                                                        &nbsp;
                                                                        <%# DataBinder.Eval(Container.DataItem, "Description")%></div>--%>
                                                                    <div id="dvGR<%# Container.DataItemIndex %>" style="display: none; width: 100%; float: left;">
                                                                        <div class="box_content">
                                                                            <asp:GridView ID="InnerGridGRList" runat="server" Width="100%" ShowHeader="false"
                                                                                AutoGenerateColumns="false" OnRowDataBound="InnerGridGRList_OnRowDataBound" SkinID="gvNoPaging">
                                                                                <Columns>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <div style="float: left; width: 20px; border-right: 1px solid #ccc;">
                                                                                                &nbsp;
                                                                                            </div>
                                                                                            <div style="float: left; width: 81px; border-right: 1px solid #ccc;">
                                                                                                &nbsp;
                                                                                                <%#DataBinder.Eval(Container.DataItem, "BookNo")%>
                                                                                            </div>
                                                                                            <div style="float: left; width: 90px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                &nbsp;
                                                                                                <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                                                            </div>
                                                                                            <div style="float: left; width: 90px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                &nbsp;
                                                                                                <%#DataBinder.Eval(Container.DataItem, "FolioNo")%>
                                                                                            </div>
                                                                                            <div style="float: left; width: 90px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                &nbsp;<%#DataBinder.Eval(Container.DataItem, "SrcFolioNo")%>
                                                                                            </div>
                                                                                            <div style="float: left; width: 80px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                &nbsp;
                                                                                                <asp:Literal ID="lblChildGvEntryDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EntryDate")).ToString(clsSession.DateFormat)%>'></asp:Literal>
                                                                                            </div>
                                                                                            <%-- <div style="float: left; width: 180px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                &nbsp;
                                                                                                <%#DataBinder.Eval(Container.DataItem, "GeneralIDType_Term")%>
                                                                                            </div>--%>
                                                                                            <div style="float: left; width: 200px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                &nbsp;
                                                                                                <%#DataBinder.Eval(Container.DataItem, "Account")%>
                                                                                            </div>
                                                                                            <div style="float: left; width: 100px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                &nbsp;
                                                                                                <asp:Literal ID="lblChildGvCR" runat="server"></asp:Literal>
                                                                                            </div>
                                                                                            <div style="float: left; padding-left: 1px;">
                                                                                                &nbsp;
                                                                                                <asp:Literal ID="lblChildGvDB" runat="server"></asp:Literal>
                                                                                            </div>
                                                                                            
                                                                                            <%--<div style="float: left; width: 100px; padding-left: 1px; border-right: 1px solid #ccc;">
                                                                                                &nbsp;
                                                                                                <%#DataBinder.Eval(Container.DataItem, "Description")%>
                                                                                            </div>--%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </div>
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
                                    </table>
                                </div>
                            </td>
                            <td class="boxright">
                            </td>
                        </tr>
                        <tr>
                            <td class="boxbottomleft">
                            </td>
                            <td class="boxbottomcenter">
                            </td>
                            <td class="boxbottomright">
                            </td>
                        </tr>
                    </table>
                    <div class="clear_divider">
                    </div>
                    <div class="clear">
                        <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                    </div>
                </td>
            </tr>
        </table>
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
<script type="text/javascript">
    function fnOnClick(obj) {
        var imgID = obj.id;
        var divID = imgID.replace("imgid", "dvid");

        var toHidShowDiv = document.getElementById(divID);

        if (toHidShowDiv.style.display == 'none') {
            toHidShowDiv.style.display = 'block';
            document.getElementById(imgID).src = "../../images/icon222.png";
        }
        else if (toHidShowDiv.style.display == 'block') {
            toHidShowDiv.style.display = 'none';
            document.getElementById(imgID).src = "../../images/icon111.png";
        }
    }

    function fnOnClickInnerGrid(obj) {
        var imgID = obj.id;
        var divID = imgID.replace("imgGR", "dvGR");

        var toHidShowDiv = document.getElementById(divID);

        if (toHidShowDiv.style.display == 'none') {
            toHidShowDiv.style.display = 'block';
            document.getElementById(imgID).src = "../../images/icon222.png";
        }
        else if (toHidShowDiv.style.display == 'block') {
            toHidShowDiv.style.display = 'none';
            document.getElementById(imgID).src = "../../images/icon111.png";
        }
    }
</script>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updFolioList" ID="UpdateProgressFolioList"
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
