<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRoomList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlRoomList" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">

    function pageLoad(sender, args) {
        $(function () {
            $("#tabs").tabs();
        });

        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });

        $(document).ready(function () {
            $("#<%= txtSUnitNo.ClientID %>").autocomplete('../Configurations/UnitAutoComplete.ashx');
        });

        $(function () {
            $('#sortable').sortable({
                placeholder: 'ui-state-highlight',
                update: OnSortableUpdate
            });
            $('#sortable').disableSelection();

            var progressMessage = 'Saving changes... <img src="images/ajax-loader.gif"/>';
            var successMessage = 'Saved successfully !!!';
            var errorMessage = 'There was some error in processing your request';
            var messageContainer = $('#message').find('p');

            function OnSortableUpdate(event, ui) {
                var order = $('#sortable').sortable('toArray').join(',').replace(/id_/gi, '')
                //console.info(order);                
                messageContainer.html(progressMessage);

                $.ajax({
                    type: 'POST',
                    url: 'Sortable.asmx/UpdateRoomSellOrder',
                    data: '{itemOrder: \'' + order + '\'}',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: OnSortableUpdateSuccess,
                    error: OnSortableUpdateError
                });
            }

            function OnSortableUpdateSuccess(response) {
                if (response != null && response.d != null) {
                    var data = response.d;
                    if (data == true) {
                        messageContainer.html(successMessage);
                    }
                    else {
                        messageContainer.html(errorMessage);
                    }
                    //console.info(data);
                }
            }

            function OnSortableUpdateError(xhr, ajaxOptions, thrownError) {
                messageContainer.html(errorMessage);
            }

        });
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnConfirmDelete(id) {

        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnConfirmDelete.ClientID %>').value = id;
        $find('mpeConfirmDelete').show();
        return false;
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<style type="text/css">
    #sortable
    {
        list-style-type: none;
        margin: 0;
        padding: 0;
        width: 200px;
    }
    #sortable li
    {
        margin: 0 5px 5px 5px;
        padding: 5px;
        font-size: 1.2em;
        height: 1.5em;
        cursor: move;
        background: none repeat scroll 0 0 #DFEFFC;
        border: 1px solid #C5DBEC;
        color: #2E6E9E;
        font-weight: bold;
    }
    html > body #sortable li
    {
        height: 1.5em;
        line-height: 1.2em;
    }
</style>
<asp:UpdatePanel ID="upnlRoomList" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server"></asp:Literal>
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
                                </div>
                                <div class="demo">
                                    <div id="tabs">
                                        <ul>
                                            <li><a href="#tabs-1">
                                                <asp:Literal ID="ltiTabUnitList" runat="server"></asp:Literal>
                                            </a></li>
                                            <li><a href="#tabs-2">
                                                <asp:Literal ID="litTabSellOrder" runat="server"></asp:Literal></a></li>
                                            <li><a href="#tabs-3">
                                                <asp:Literal ID="litTabCopyRoom" runat="server"></asp:Literal></a></li>
                                        </ul>
                                        <div id="tabs-1">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="left">
                                                        <div class="box_form">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td colspan="4">
                                                                        <%if (IsListMessage)
                                                                          { %>
                                                                        <div class="message finalsuccess">
                                                                            <p>
                                                                                <strong>
                                                                                    <asp:Literal ID="ltrMsgList" runat="server"></asp:Literal></strong>
                                                                            </p>
                                                                        </div>
                                                                        <%}%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th align="left">
                                                                        <asp:Label ID="lblSUnitNo" runat="server"></asp:Label>
                                                                    </th>
                                                                    <td>
                                                                        <asp:TextBox ID="txtSUnitNo" runat="server" MaxLength="15"></asp:TextBox>
                                                                    </td>
                                                                    <th align="left">
                                                                        <asp:Label ID="lblSearchRoomListWingName" runat="server"></asp:Label>
                                                                    </th>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlSearchRoomListWingName" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th align="left">
                                                                        <asp:Label ID="lblSUnitTypeName" runat="server"></asp:Label>
                                                                    </th>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlSearchUnitType" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <th align="left">
                                                                        <asp:Label ID="lblSearchRoomListFloorName" runat="server"></asp:Label>
                                                                    </th>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlSearchRoomListFloorName" runat="server">
                                                                        </asp:DropDownList>
                                                                        <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                                            Style="border: 0px; vertical-align: middle; margin: -1px 0 0 5px;" OnClick="btnSearch_Click"
                                                                            OnClientClick="fnDisplayCatchErrorMessage();" />
                                                                        <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                                            Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClick="imgbtnClearSearch_Click"
                                                                            OnClientClick="fnDisplayCatchErrorMessage();" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4">
                                                                        <hr>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4" align="right">
                                                                        <asp:Button ID="btnAddTopRoomList" runat="server" Style="float: right;" OnClick="btnAddTopRoomList_Click" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4" class="content_checkbox">
                                                                        <div class="box_head">
                                                                            <span>
                                                                                <asp:Literal ID="litRoomList" runat="server"></asp:Literal>
                                                                            </span>
                                                                            <div style="float: right; width: auto; display: inline-block; margin-right: 10px;">
                                                                                <span>
                                                                                    <asp:Literal ID="litTotalNoofRoom" runat="server"></asp:Literal>
                                                                                </span><span>
                                                                                    <asp:Literal ID="litTotalOnofBed" runat="server" Text="Total No of Bed"></asp:Literal>
                                                                                </span>
                                                                            </div>
                                                                        </div>
                                                                        <div class="clear">
                                                                        </div>
                                                                        <div class="box_content">
                                                                            <asp:GridView ID="gvRoomList" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                                OnPageIndexChanging="gvRoomList_PageIndexChanging" OnRowCommand="gvRoomList_RowCommand"
                                                                                OnRowDataBound="gvRoomList_RowDataBound">
                                                                                <Columns>
                                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrSrNo" runat="server"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%# Container.DataItemIndex + 1 %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrUnitNo" runat="server" ItemStyle-Width="125px"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblUnitNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ROOMNUMBER")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrUnitType" runat="server"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblUnitType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrBlockName" runat="server" Text="Block"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblGvBlockName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "WingName")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrFloorName" runat="server" Text="Floor"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblGvFloorName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FloorName")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrKeyNo" runat="server"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblGvKeyNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "KeyNo")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrExtentionNo" runat="server"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblGvExtentionNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ExtentionNo")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrCRV" runat="server"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <img runat="server" id="imgIsAvailableOnIRS" />
                                                                                            <asp:HiddenField ID="hdnRoomListIsAvailableOnIRS" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "IsAvailableOnIRS")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <%--<asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrDiscount" runat="server"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <img runat="server" id="imgIsDiscountApplicable" />
                                                                                            <asp:HiddenField ID="hdnRoomListDiscount" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "IsDiscountApplicable")%>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>--%>
                                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblGvHdrAction" runat="server"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RoomID")%>'
                                                                                                CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" alt="" /></asp:LinkButton>
                                                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RoomID")%>'
                                                                                                CommandName="DELETEDATA"><img src="../../images/delete.png" alt="" /></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
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
                                                                        <asp:Button ID="btnAddBottomRoomList" runat="server" Style="float: right;" OnClick="btnAddTopRoomList_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="tabs-2">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="left">
                                                        <div class="box_form">
                                                            <div class="ui-widget" id="message">
                                                                <div class="ui-state-highlight ui-corner-all" style="margin-top: -5px; padding: 0 .7em;
                                                                    padding-bottom: 3px; padding-top: 3px;">
                                                                    <p>
                                                                        <asp:Literal ID="litSellOrderHeaderMsg" runat="server"></asp:Literal>
                                                                    </p>
                                                                </div>
                                                            </div>
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <th align="left" style="width: 125px; padding-top: 15px;">
                                                                        <asp:Literal ID="litSellOrderRoomType" runat="server"></asp:Literal>
                                                                    </th>
                                                                    <td style="padding-top: 15px;">
                                                                        <asp:DropDownList ID="ddlSellOrderRoomType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSellOrderRoomType_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <ul id="sortable">
                                                                            <asp:ListView ID="ItemsListView" runat="server" ItemPlaceholderID="myItemPlaceHolder">
                                                                                <LayoutTemplate>
                                                                                </LayoutTemplate>
                                                                                <LayoutTemplate>
                                                                                    <asp:PlaceHolder ID="myItemPlaceHolder" runat="server"></asp:PlaceHolder>
                                                                                </LayoutTemplate>
                                                                                <ItemTemplate>
                                                                                    <li class="ui-state-default" id='id_<%# Eval("SeqNo") %>'>
                                                                                        <%# Eval("RoomNo")%></li>
                                                                                </ItemTemplate>
                                                                            </asp:ListView>
                                                                        </ul>
                                                                        <div style="padding: 10px;">
                                                                            <b>
                                                                                <asp:Label ID="lblMsg" runat="server" Visible="false" Text="No record found."></asp:Label>
                                                                            </b>
                                                                        </div>
                                                                        <div class="clear">
                                                                        </div>
                                                                        <div class="box_content">
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trRoomSellOrder" runat="server" visible="false">
                                                                    <td colspan="2" class="content_checkbox">
                                                                        <div class="box_head">
                                                                            <span>
                                                                                <asp:Literal ID="litSellOrderRoomList" runat="server"></asp:Literal></span></div>
                                                                        <div class="clear">
                                                                        </div>
                                                                        <div class="box_content">
                                                                            <asp:GridView ID="gvSellOrderRoom" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                                SkinID="gvNoPaging" OnRowDataBound="gvSellOrderRoom_RowDataBound">
                                                                                <Columns>
                                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblSORGvHdrSrNo" runat="server"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%# Container.DataItemIndex + 1 %>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <HeaderTemplate>
                                                                                            <asp:Label ID="lblSORGvHdrUnitNo" runat="server"></asp:Label>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <EmptyDataTemplate>
                                                                                    <div style="padding: 10px;">
                                                                                        <b>
                                                                                            <asp:Label ID="lblNoRecordFoundMsgForSellOrder" runat="server"></asp:Label>
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
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="tabs-3">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="left">
                                                        <div class="box_form">
                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <%if (IsListMessageForCR)
                                                                          { %>
                                                                        <div class="message finalsuccess">
                                                                            <p>
                                                                                <strong>
                                                                                    <asp:Literal ID="litListMsgForCR" runat="server"></asp:Literal></strong>
                                                                            </p>
                                                                        </div>
                                                                        <%}%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="isrequire" style="width: 175px;">
                                                                        <asp:Literal ID="litCRRoomType" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlCRRoomType" runat="server" OnSelectedIndexChanged="ddlCRRoomType_SelectedIndexChanged"
                                                                            AutoPostBack="true">
                                                                        </asp:DropDownList>
                                                                        <span>
                                                                            <asp:RequiredFieldValidator ID="rfvCRRoomType" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                SetFocusOnError="True" CssClass="input-notification error png_bg" runat="server"
                                                                                ValidationGroup="CopyRoom" ControlToValidate="ddlCRRoomType" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        </span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="isrequire">
                                                                        <asp:Literal ID="litCRRoomNo" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlCRRoomNo" runat="server">
                                                                        </asp:DropDownList>
                                                                        <span>
                                                                            <asp:RequiredFieldValidator ID="rfvCRRoomNo" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                SetFocusOnError="True" CssClass="input-notification error png_bg" runat="server"
                                                                                ValidationGroup="CopyRoom" ControlToValidate="ddlCRRoomNo" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        </span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="isrequire">
                                                                        <asp:Literal ID="litCRNewRoomCreate" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtCRNewRoomCreate" runat="server" TextMode="MultiLine" SkinID="BigInput"></asp:TextBox>
                                                                        <ajx:FilteredTextBoxExtender ID="ftCRNewRoomCreate" runat="server" TargetControlID="txtCRNewRoomCreate"
                                                                            FilterType="Custom, Numbers" ValidChars=",-" />
                                                                        <span>
                                                                            <asp:RequiredFieldValidator ID="rfvCRNewRoomCreate" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                                runat="server" ValidationGroup="CopyRoom" ControlToValidate="txtCRNewRoomCreate"></asp:RequiredFieldValidator>
                                                                        </span>
                                                                        <br />
                                                                        (ex. 101-110,115,117,118,200-201 etc.)
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th>
                                                                        &nbsp;
                                                                    </th>
                                                                    <td class="checkbox_new">
                                                                        <asp:CheckBox ID="chkCRCopyAmenities" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <div style="float: right; width: auto; display: inline-block;">
                                                                            <asp:Button ID="btnCancelCopyRoom" runat="server" CausesValidation="False" ImageUrl="~/images/cancle.png"
                                                                                Style="float: right; margin-left: 5px;" OnClick="btnCancelCopyRoom_Click" />
                                                                            <asp:Button ID="btnSaveCopyRoom" runat="server" ImageUrl="~/images/save.png" Style="float: right;
                                                                                margin-left: 5px;" OnClick="btnSaveCopyRoom_Click" ValidationGroup="CopyRoom"
                                                                                OnClientClick="fnDisplayCatchErrorMessage();" />
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
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
                    <div class="clear">
                        <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                    </div>
                </td>
            </tr>
        </table>
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
                                    OnClick="btnYes_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
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
            PopupControlID="pnlCustomeMessage" BackgroundCssClass="modalBackground" OkControlID="btnOKCustomeMsgPopup"
            CancelControlID="btnOKCustomeMsgPopup" DropShadow="true" BehaviorID="mpeCustomePopup">
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
<asp:UpdateProgress AssociatedUpdatePanelID="upnlRoomList" ID="UpdateProgressRoomList"
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
