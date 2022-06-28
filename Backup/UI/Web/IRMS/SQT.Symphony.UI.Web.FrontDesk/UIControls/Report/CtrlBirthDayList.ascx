<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlBirthDayList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Report.CtrlBirthDayList" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script src="../../Scripts/Common.js" type="text/javascript"></script>
<script src="../../Scripts/jquery-1.8.2.js"></script>
<script src="../../Scripts/jquery-ui.js"></script>
<script type="text/javascript" language="javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function stopKey(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 8) && (node.type == "text")) { return false; }
        else if ((evt.keyCode == 9) && (node.type == "text")) { return true; }
        else if ((evt.keyCode == 46) && (node.type == "text")) { return false; }
        else { return false; }
    }
    function CheckMonthConflict() {
        document.getElementById('errormessage').style.display = "block";
        var ddlDOBFromMonthCheck = $('#<%= ddlDOBFromMonth.ClientID  %>').val();
        var ddlDOBToMonthCheck = $('#<%= ddlDOBToMonth.ClientID  %>').val();
        if (ddlDOBFromMonthCheck != null && ddlDOBToMonthCheck != null && ddlDOBFromMonthCheck > ddlDOBToMonthCheck) {
            $find('mpeSelectedMonth').show();
            return false;
        }
        else {
            return true;
        }
    }
</script>
<script type="text/javascript">
    function fnBirthDayListPrint() {
        window.open("BirthDayListPrint.aspx", "Birthday List", "height=600,width=1000,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
    }
</script>
<asp:UpdatePanel ID="updGuestPrintBirthDayList" runat="server">
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
                                <asp:Literal ID="litBirthDayList" runat="server" Text="Guest Birthday List"></asp:Literal>
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
                                    <%if (IsMessage)
                                      { %>
                                    <div class="ResetSuccessfully">
                                        <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                            <img src="../../images/success.png" />
                                        </div>
                                        <div>
                                            <asp:Label ID="lblBirthDayListMsg" runat="server"></asp:Label></div>
                                        <div style="height: 10px;">
                                        </div>
                                    </div>
                                    <% }%>
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td>
                                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                    <tr>
                                                        <td style="width: 30px;">
                                                            <asp:CheckBox ID="chkMonthOnly" runat="server" OnCheckedChanged="chkMonthOnly_OnCheckedChanged"
                                                                AutoPostBack="true" />
                                                        </td>
                                                        <td style="width: 55px;">
                                                            <asp:Literal ID="litSameMonth" Text="Month" runat="server"></asp:Literal>
                                                        </td>
                                                        <td style="width: 300px;">
                                                            <asp:DropDownList ID="ddlMonthOnly" runat="server" Style="width: 105px; height: 25px;">
                                                                <asp:ListItem Text="--MONTH--" Value="00000000-0000-0000-0000-000000000000" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                                                <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                                                                <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                                                                <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                                                                <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                                                                <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                                                <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                                                <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvMonthOnly" SetFocusOnError="true" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequire"
                                                                Enabled="false" ControlToValidate="ddlMonthOnly" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="width: 30px;">
                                                            <asp:CheckBox ID="chkMonthRange" runat="server" OnCheckedChanged="chkMonthRange_OnCheckedChanged"
                                                                AutoPostBack="true" />
                                                        </td>
                                                        <td style="width: 50px;">
                                                            <asp:Literal ID="litSearchBirthDayFromDate" Text="From" runat="server"></asp:Literal>
                                                        </td>
                                                        <td style="width: 150px;">
                                                            <asp:DropDownList ID="ddlDOBFromMonth" runat="server" Style="width: 105px; height: 25px;">
                                                                <asp:ListItem Text="--MONTH--" Value="00000000-0000-0000-0000-000000000000" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                                                <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                                                                <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                                                                <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                                                                <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                                                                <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                                                <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                                                <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvDOBFromMonth" SetFocusOnError="true" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequire"
                                                                Enabled="false" ControlToValidate="ddlDOBFromMonth" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="width: 25px;">
                                                            <asp:Literal ID="litSearchSearchBirthDayToDate" Text="To " runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlDOBToMonth" runat="server" Style="width: 105px; height: 25px;">
                                                                <asp:ListItem Text="--MONTH--" Value="00000000-0000-0000-0000-000000000000" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                                                <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                                                                <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                                                                <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                                                                <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                                                                <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                                                <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                                                <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvDOBToMonth" SetFocusOnError="true" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequire"
                                                                Enabled="false" ControlToValidate="ddlDOBToMonth" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                            &nbsp;&nbsp;&nbsp;
                                                            <asp:ImageButton ID="imtbtnSearchBirthDayList" ToolTip="Search" runat="server" ImageUrl="~/images/search-icon.png"
                                                                Style="border: 0px; vertical-align: middle; display: inline" OnClick="imtbtnSearchBirthDayList_Click"
                                                                ValidationGroup="IsRequire" />
                                                            <asp:ImageButton ID="imtbtnSearchClearBirthDayList" Visible="false" ToolTip="Reset"
                                                                runat="server" ImageUrl="~/images/clearsearch.png" Style="border: 0px; vertical-align: middle;
                                                                margin: -2px 0 0 10px;" OnClientClick="fnDisplayCatchErrorMessage();" OnClick="imtbtnSearchClearBirthDayList_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" align="right">
                                                <asp:Button ID="btnPrintBirthDayList" runat="server" Text="Print" OnClick="btnPrintBirthDayList_OnClick"
                                                    Style="float: right; margin-left: 5px;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; height: 200px; overflow: auto;" colspan="8">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="vertical-align: top;">
                                                            <div class="box_head">
                                                                <span>
                                                                    <asp:Literal ID="litBirthDayListGrid" runat="server" Text="Birthday List"></asp:Literal>
                                                                </span>
                                                            </div>
                                                            <div class="clear">
                                                            </div>
                                                            <div class="box_content">
                                                                <asp:GridView ID="gvBirthDayList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                    Width="100%" OnRowCommand="gvBirthDayList_RowCommand" OnRowDataBound="gvBirthDayList_RowDataBound"
                                                                    OnPageIndexChanging="gvBirthDayList_PageIndexChanging">
                                                                    <Columns>
                                                                        <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrInqSrNo" runat="server" Text="No."></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1 %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrBirthDate" runat="server" Text="Birth date"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGvBirthDate" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrInqGuestName" runat="server" Text="Name"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGvInqGuestName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrGuestEmail" runat="server" Text="Email"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Email")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrInqGuestMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Phone1")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrRoomNo" runat="server" Text="Room No"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGvRoomNo" runat="server" Text=' <%#DataBinder.Eval(Container.DataItem, "DisplayRoomNo")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <div style="padding: 10px;">
                                                                            <b>
                                                                                <asp:Label ID="lblNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                            </b>
                                                                        </div>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
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
                    </div>
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="mpeSelectedMonth" runat="server" TargetControlID="hfDateMessage"
            PopupControlID="pnlMonthMessage" BackgroundCssClass="mod_background" CancelControlID="btnDateMessageOK"
            BehaviorID="mpeSelectedMonth">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfDateMessage" runat="server" />
        <asp:Panel ID="pnlMonthMessage" runat="server" Width="350px">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderDateValidate" Text="Message" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="ltrMsgDateValidate" Text="From Month must be greater than To Month."
                                    runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnDateMessageOK" Text="Ok" runat="server" Style="display: inline;
                                    padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <div id="errormessage" class="clear">
            <uc1:MsgBox ID="MessageBox" runat="server" />
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnPrintBirthDayList" />
    </Triggers>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="updGuestPrintBirthDayList" ID="UpdateBirthDayList"
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
