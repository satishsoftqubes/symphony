<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlBlockRoom.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlBlockRoom" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script src="../../Javascript/Common.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnConfirmDelete(id) {

        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnConfirmDelete.ClientID %>').value = id;
        $find('mpeConfirmDelete').show();
        return false;
    }

    function BlockRoomValidate() {
        if (Page_ClientValidate("IsRequire")) {

            document.getElementById('errormessage').style.display = "block";
            var varDateValidationFlag = true;
            var varDateFrom = document.getElementById('<%= txtStartDate.ClientID %>').value;
            var varDateTo = document.getElementById('<%= txtEndDate.ClientID %>').value;

            if (varDateFrom != '' && varDateTo != '') {
                var dateFormat = document.getElementById('<%= hfDateFormat.ClientID %>').value;

                var dateFrom = fnGetValidDateFormat(varDateFrom, dateFormat);
                var dateTo = fnGetValidDateFormat(varDateTo, dateFormat);

                dateFrom = Date.parse(dateFrom, 'MM/dd/yyyy');
                dateTo = Date.parse(dateTo, 'MM/dd/yyyy');

                if (dateFrom > dateTo) {
                    varDateValidationFlag = false;
                }
                else {
                    varDateValidationFlag = true;
                }
            }
            else {
                varDateValidationFlag = true;
            }

            var flag = 0;
            var hdncnt = document.getElementById("<%= hdncnt.ClientID %>").value;
            if (hdncnt != '') {
                for (var i = 0; i < hdncnt; i++) {
                    if (flag == 0) {
                        var childDatalistName = "ContentPlaceHolder1_ucCtrlBlockRoom_gvRoomTypes_dtlstRoom_" + i;
                        var dtlst = document.getElementById(childDatalistName);
                        var chk = dtlst.getElementsByTagName("input");
                        for (var j = 0; j < chk.length; j++) {
                            if (chk[j].type == "checkbox") {
                                if (chk[j].checked) {
                                    flag = 1;
                                }
                            }
                        }
                    }
                }
            }
            else {
                flag = 1;
            }

            if (flag == 0 || varDateValidationFlag == false) {
                if (flag == 0) {
                    $find('mpeCustomePopup').show();
                    return false;
                }
                else if (varDateValidationFlag == false) {
                    document.getElementById('dvDateMessage').style.display = "block";
                    return false;
                }
            }
        }
        else {
            return false;
        }
    }

    function fnCheckSearchDate() {

        document.getElementById('errormessage').style.display = "block";
        var varDateFrom = document.getElementById("<%= txtSearchSD.ClientID %>").value;
        var varDateTo = document.getElementById('<%= txtSearchED.ClientID %>').value;

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
<script language="javascript" type="text/javascript">
    function pageLoad(sender, args) {
        $(document).ready(function () {
            $("#<%=txtSearchBlockBy.ClientID%>").autocomplete('UserAutoComplete.ashx');
        });
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function ValidateBlockRoom() {
        document.getElementById('errormessage').style.display = "block";
        var isChecked = false;
        var c = document.getElementsByTagName('input');
        for (var i = 1; i < c.length; i++) {
            if (c[i].type == 'checkbox') {
                if (c[i].checked) {
                    isChecked = true;
                    break;
                }
            }
        }

        if (isChecked == false) {
            $find('mpeCustomePopup').show();
            return false;
        }
    }
</script>
<script type="text/javascript" language="javascript" src="../../JS/script.js"></script>
<style type="text/css">
    .hotspot
    {
        color: #900;
        padding-bottom: 1px;
        cursor: pointer;
    }
    #tt
    {
        position: absolute;
        display: block;
        background: url(../../JS/tt_left.gif) top left no-repeat;
    }
    #tttop
    {
        display: block;
        height: 5px;
        margin-left: 5px;
        background: url(../../JS/tt_top.gif) top right no-repeat;
        overflow: hidden;
    }
    #ttcont
    {
        display: block;
        padding: 2px 12px 3px 7px;
        margin-left: 5px;
        background: #666;
        color: Red;
        font-size: 15px;
    }
    #ttbot
    {
        display: block;
        height: 5px;
        margin-left: 5px;
        background: url(../../JS/tt_bottom.gif) top right no-repeat;
        overflow: hidden;
    }
</style>
<asp:UpdatePanel ID="updBlockRoomList" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdncnt" runat="server" />
        <asp:HiddenField ID="hfDateFormat" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="ltrMainHeader" runat="server"></asp:Literal>
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
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td>
                                                <%if (IsListMessage)
                                                  { %>
                                                <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Literal ID="ltrListMessage" runat="server"></asp:Literal></strong>
                                                    </p>
                                                </div>
                                                <%}%>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:MultiView ID="mvBlockRoom" runat="server">
                                        <asp:View ID="vBlockRoomList" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td width="90px">
                                                        <asp:Literal ID="litSearchBlockBy" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchBlockBy" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td width="80px">
                                                        <asp:Literal ID="litDate" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchSD" runat="server" SkinID="nowidth" Width="130px" onkeydown="return stopKey(event);"></asp:TextBox>
                                                        <asp:Image ID="imdSSD" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                            Height="20px" Width="20px" />
                                                        <ajx:CalendarExtender ID="calSSD" PopupButtonID="imdSSD" TargetControlID="txtSearchSD"
                                                            runat="server">
                                                        </ajx:CalendarExtender>
                                                        <img src="../../images/clear.png" id="imgSearchSD" style="vertical-align: middle;"
                                                            title="<%= strClearDateTooltip %>" onclick="fnClearDate('<%= txtSearchSD.ClientID %>');" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; To &nbsp;&nbsp;
                                                        <asp:TextBox ID="txtSearchED" runat="server" SkinID="nowidth" Width="130px" onkeydown="return stopKey(event);"></asp:TextBox>
                                                        <asp:Image ID="imgSED" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                            Height="20px" Width="20px" />
                                                        <ajx:CalendarExtender ID="calSED" PopupButtonID="imgSED" TargetControlID="txtSearchED"
                                                            runat="server">
                                                        </ajx:CalendarExtender>
                                                        <img src="../../images/clear.png" id="img3" style="vertical-align: middle;" title="<%= strClearDateTooltip %>"
                                                            onclick="fnClearDate('<%= txtSearchED.ClientID %>');" />
                                                        <asp:ImageButton ID="imtbtnSearchBlockRoom" runat="server" ImageUrl="~/images/search-icon.png"
                                                            ValidationGroup="BlockRoom" Style="border: 0px; vertical-align: middle; margin: -4px 0 0 10px;"
                                                            OnClientClick="return fnCheckSearchDate();" OnClick="imtbtnSearchBlockRoom_Click" />
                                                        <asp:ImageButton ID="imtbtnSearchClearBlockRoom" runat="server" ImageUrl="~/images/clearsearch.png"
                                                            Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClick="imtbtnSearchClearBlockRoom_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <hr>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="right" valign="middle">
                                                        <asp:Button ID="btnAddTopBlockRoom" runat="server" Style="float: right;" OnClick="btnAddTopBlockRoom_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litBlockRoomList" runat="server"></asp:Literal></span></div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvBlockRoomList" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                ShowHeader="true" OnRowDataBound="gvBlockRoomList_RowDataBound" OnPageIndexChanging="gvBlockRoomList_PageIndexChanging"
                                                                OnRowCommand="gvBlockRoomList_RowCommand" DataKeyNames="BlockRoomDetailID,RoomID,BlockRoomID">
                                                                <Columns>                                                                    
                                                                    <asp:TemplateField ItemStyle-Width="35px">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSrNo" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="35px">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSelect" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrDate" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "StartDate")).ToString(clsSession.DateFormat)%>
                                                                            &nbsp; - &nbsp;
                                                                            <%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EndDate")).ToString(clsSession.DateFormat)%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        ItemStyle-Width="75px">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRoomNo" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvRoomNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RoomNo")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        ItemStyle-Width="125px">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRoomTypeName" runat="server" Text="Room Type"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvRoomTypeName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        ItemStyle-Width="100px">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrNoOfRooms" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvNoOfRooms" runat="server"></asp:Label>                                                                            | 
                                                                                <asp:Label ID="lnkView" runat="server" ForeColor="#0067a4"></asp:Label></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrReason" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvReason" runat="server" Text='<%#TruncateString(DataBinder.Eval(Container.DataItem, "BlockReason").ToString(), 50)%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                        ItemStyle-Width="200px">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrBlockBy" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvBlockBy" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BlockBy")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--<asp:TemplateField ItemStyle-Width="35px">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAction" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkBREdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "BlockRoomID")%>'
                                                                                CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" /></asp:LinkButton>
                                                                            <asp:LinkButton ID="lnkBRDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "BlockRoomID")%>'
                                                                                CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label>
                                                                        </b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="right" valign="middle">
                                                        <asp:Button ID="btnEnableBlockRoom" runat="server" style="display:inline;" OnClientClick="return ValidateBlockRoom();" OnClick="btnEnableBlockRoom_Click" />&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnAddBottomBlockRoom" runat="server" Style="float: right; display:inline;" OnClick="btnAddTopBlockRoom_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" />
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vAddEditBlockRoom" runat="server">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td colspan="4">
                                                        <div style="float: right; padding-bottom: 5px;">
                                                            <b>
                                                                <asp:Literal ID="litGeneralMandartoryFiledMessage" runat="server"></asp:Literal>
                                                            </b>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire" align="left" valign="top">
                                                        <asp:Literal ID="litStartDate" runat="server"></asp:Literal>
                                                    </td>
                                                    <td align="left" valign="top" width="300px">
                                                        <asp:TextBox ID="txtStartDate" runat="server" SkinID="nowidth" Width="150px" onkeydown="return stopKey(event);"></asp:TextBox>
                                                        <asp:Image ID="imgCalStartDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                            Height="20px" Width="20px" />
                                                        <ajx:CalendarExtender ID="calStartDate" PopupButtonID="imgCalStartDate" TargetControlID="txtStartDate"
                                                            runat="server">
                                                        </ajx:CalendarExtender>
                                                        <img src="../../images/clear.png" id="imgClearDate" style="vertical-align: middle;"
                                                            title="<%= strClearDateTooltip %>" onclick="fnClearDate('<%= txtStartDate.ClientID %>');" />
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rvfStartDate" runat="server" ControlToValidate="txtStartDate"
                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                                        </span>&nbsp;&nbsp; To &nbsp;&nbsp;
                                                    </td>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="litEndDate" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEndDate" runat="server" SkinID="nowidth" Width="150px" onkeydown="return stopKey(event);"></asp:TextBox>
                                                        <asp:Image ID="imgCalEndDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                            Height="20px" Width="20px" />
                                                        <ajx:CalendarExtender ID="calEndDate" PopupButtonID="imgCalEndDate" TargetControlID="txtEndDate"
                                                            runat="server">
                                                        </ajx:CalendarExtender>
                                                        <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" title="<%= strClearDateTooltip %>"
                                                            onclick="fnClearDate('<%= txtEndDate.ClientID %>');" />
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvEndDate" runat="server" ControlToValidate="txtEndDate"
                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="3" align="left">
                                                        <div id="dvDateMessage" style="display: none;">
                                                            <asp:Label ID="lblBRDateMsg" ForeColor="Red" Font-Size="14px" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th align="left" style="vertical-align: top;" valign="top">
                                                        <asp:Literal ID="litBlockFor" runat="server"></asp:Literal>
                                                    </th>
                                                    <td colspan="3">
                                                        <asp:RadioButtonList ID="rbtBlockFor" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th align="left" style="vertical-align: top;" valign="top">
                                                        <asp:Literal ID="litBlockReason" runat="server"></asp:Literal>
                                                    </th>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="txtBlockReason" runat="server" TextMode="MultiLine" SkinID="BigInput"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire" style="vertical-align: top;" valign="top">
                                                        <asp:Literal ID="litRooms" runat="server"></asp:Literal>
                                                    </td>
                                                    <td colspan="3" class="checkbox_new">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litGvRoomsPopupHeader" runat="server"></asp:Literal></span></div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content" style="height: 300px; overflow: auto;">
                                                            <asp:GridView ID="gvRoomTypes" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                SkinID="gvNoPaging" ShowHeader="false" DataKeyNames="RoomTypeID" OnRowDataBound="gvRoomTypes_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <b>
                                                                                <%# DataBinder.Eval(Container.DataItem, "RoomTypeName")%></b>
                                                                            <br />
                                                                            <div class="datalisting">
                                                                                <asp:DataList RepeatColumns="10" DataKeyField="RoomID" RepeatDirection="Horizontal"
                                                                                    ID="dtlstRoom" runat="server" Width="100%" Style="border: 0 none;">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chkRptRoomNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RoomNo")%>' />
                                                                                    </ItemTemplate>
                                                                                </asp:DataList>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblGVNoRecordFound" runat="server"></asp:Label>
                                                                        </b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <div style="float: right; width: auto; display: inline-block;">
                                                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Style="float: right;
                                                                margin-left: 5px;" CausesValidation="false" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                            <asp:Button ID="btnSave" runat="server" CausesValidation="true" ValidationGroup="IsRequire"
                                                                OnClick="btnSave_Click" Style="float: right; margin-left: 5px;" OnClientClick="return BlockRoomValidate();" />
                                                            <asp:Button ID="btnBackToList" runat="server" OnClick="btnBackToList_Click" Style="float: right;
                                                                margin-left: 5px;" CausesValidation="false" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
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
                        <asp:Literal ID="ltrHeaderDateValidate" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="ltrMsgDateValidate" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnDateMessageOK" runat="server" Style="display: inline; padding-right: 10px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnNo"
            BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="350px" Width="325px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderConfirmDeletePopup" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="ltrConfirmDeleteMsg" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYes" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClientClick="fnDisplayCatchErrorMessage();" OnClick="btnYes_Click" />
                                <asp:Button ID="btnNo" runat="server" Style="display: inline;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <asp:HiddenField ID="hfPopupCustomeMessage" runat="server" />
        <ajx:ModalPopupExtender ID="mpeCustomePopup" runat="server" TargetControlID="hfPopupCustomeMessage"
            PopupControlID="pnlCustomeMessage" BackgroundCssClass="mod_background" CancelControlID="btnOKCustomeMsgPopup"
            DropShadow="true" BehaviorID="mpeCustomePopup">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlCustomeMessage" runat="server" Width="350px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHeaderCustomePopupMessage" runat="server" Text="Message"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px; color: Red;">
                                <asp:Literal ID="litCustomePopupMsg" runat="server" Text=""></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnOKCustomeMsgPopup" runat="server" Text="OK" Style="display: inline;
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
<asp:UpdateProgress AssociatedUpdatePanelID="updBlockRoomList" ID="UpdateProgressBlockRoomList"
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
