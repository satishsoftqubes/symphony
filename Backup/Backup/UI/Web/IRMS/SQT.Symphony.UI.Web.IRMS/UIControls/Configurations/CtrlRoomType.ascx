<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRoomType.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Configurations.CtrlRoomType" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function pageLoad(sender, args) {
        $(document).ready(function () {

            $("#<%=txtUnitTypeSearch.ClientID%>").autocomplete('UnitTypeAutoComplete.ashx');
        });
    }

</script>
<script type="text/javascript">
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("RoomTypeForm")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgressRoomType.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
        else {
            return false;
        }
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
<asp:UpdatePanel ID="updRoomType" runat="server">
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
                                UNIT TYPE SETUP
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
                                <table width="100%" cellpadding="3" cellspacing="3">
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
                                                        <asp:Label ID="lblErrorMsg" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <%
                                                    }%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div style="float: right;">
                                                <b>All Bold Fields are Mandatory</b>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" style="width: 130px;">
                                            <asp:Label ID="litPropertyName" runat="server" Text="Property Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfPropertyName" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    InitialValue="00000000-0000-0000-0000-000000000000" runat="server" ControlToValidate="ddlPropertyName"
                                                    ErrorMessage="*" ValidationGroup="RoomTypeForm"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPropertyName" runat="server" Style="width: 202px;" OnSelectedIndexChanged="ddlPropertyName_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litRoomTypeName" runat="server" Text="Unit Type Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfRoomTypeName" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ControlToValidate="txtRoomTypeName" ErrorMessage="*" ValidationGroup="RoomTypeForm"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRoomTypeName" runat="server" SkinID="CmpTextbox" MaxLength="65"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" style="width: 25%;">
                                            <asp:Label ID="litRoomTypeCode" runat="server" Text="Unit Type Code" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfRoomTypeCode" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ControlToValidate="txtRoomTypeCode" ErrorMessage="*" ValidationGroup="RoomTypeForm"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td align="left" valign="top" style="width: 75%;">
                                            <asp:TextBox ID="txtRoomTypeCode" runat="server" MaxLength="7" SkinID="CmpTextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litSBArea" runat="server" Text="SBA (Sft)" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfSBArea" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ControlToValidate="txtSBArea" ErrorMessage="*" ValidationGroup="RoomTypeForm"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSBArea" runat="server" SkinID="CmpTextbox" MaxLength="10"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="fltCarpetArea" runat="server" FilterType="Numbers"
                                                TargetControlID="txtSBArea" Enabled="True">
                                            </ajx:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litCarpetArea" runat="server" Text="Carpet Area (Sft)" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfCarpetArea" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ControlToValidate="txtCarpetArea" ErrorMessage="*" ValidationGroup="RoomTypeForm"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCarpetArea" runat="server" SkinID="CmpTextbox" MaxLength="10"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FLTtxtCarpetArea" runat="server" FilterType="Numbers"
                                                TargetControlID="txtCarpetArea" Enabled="True">
                                            </ajx:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:Literal ID="litDescription" runat="server" Text="Unit Description"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAboutRoomType" TextMode="MultiLine" runat="server" SkinID="Medium"
                                                Height="60px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="trAmenities" runat="server" visible="false">
                                        <td>
                                            <asp:Literal ID="Literal1" runat="server" Text="Amenities"></asp:Literal>
                                        </td>
                                        <td class="checkbox_new">
                                            <div style="min-height: 25px; overflow: auto; height: 100px;">
                                                <asp:CheckBoxList ID="chklstAmenities" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                                                </asp:CheckBoxList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litElevationDrawing" runat="server" Text="Unit Layout"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="flEvaliationDrawing"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ValidationGroup="RoomTypeForm"
                                                    Display="Dynamic" ErrorMessage="*" ValidationExpression="^.+(.jpg|.JPG|.JPEG|.jpeg|.gif|.GIF|.png|.PNG)$"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <div id='browse_file_grid'>
                                                <asp:FileUpload ID="flEvaliationDrawing" runat="server" Height="25px" size="18" ToolTip=".jpg|.JPG|.JPEG|.jpeg|.gif|.GIF|.png|.PNG" /></div>
                                        </td>
                                    </tr>
                                    <tr id="trEvaliationDrawing" runat="server" visible="false">
                                        <td colspan="2">
                                            <div>
                                                <asp:Image ID="imbEvaliationDrawing" runat="server" ImageUrl="~/images/elevation.gif" />
                                            </div>
                                            <div style="float: right; padding-right: 10px; padding-top: 5px;">
                                                <b>
                                                    <asp:LinkButton ID="lnkRemoveEvaluationDrawing" runat="server" Visible="false" OnClick="lnkRemoveEvaluationDrawing_Click"
                                                        Text="Remove"></asp:LinkButton></b>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" style="text-align: right;">
                                            <div style="float: right; width: auto; display: inline-block;">
                                                <asp:Button ID="btnNew" runat="server" Style="display: inline-block; margin-left: 5px;
                                                    display: inline;" Text="New" OnClick="btnNew_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/save.png" ValidationGroup="RoomTypeForm" CausesValidation="true"
                                                    OnClick="btnSave_Click" OnClientClick="return postbackButtonClick();" />
                                                <%--<asp:Button ID="btnCancel" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage()" />--%>
                                            </div>
                                        </td>
                                    </tr>
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
                <td style="width: 2px;">
                    &#160;
                </td>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                QUICK SEARCH
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
                                <div class="box_leftmargin_content">
                                    <div>
                                        <table id="tbl" cellpadding="2" cellspacing="0" width="100%" border="0" class="pageinfo">
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Property Name
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSProperty" runat="server" SkinID="Search">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Unit Type
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUnitTypeSearch" SkinID="Search" runat="server" MaxLength="65"></asp:TextBox>
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; vertical-align: middle; margin: -3px 7px 0 5px;" OnClick="btnSearch_Click"
                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <div style="height: 441px; overflow-x: hidden; overflow-y: auto;">
                                            <asp:GridView ID="gvRoomTypeList" runat="server" ShowHeader="false" ShowFooter="false"
                                                SkinID="gvNoPaging" AutoGenerateColumns="false" Width="92%" OnRowCommand="gvRoomTypeList_RowCommand"
                                                OnRowDataBound="gvRoomTypeList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea">
                                                                    <strong>
                                                                        <%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%></strong><br />
                                                                    <asp:Label ID="lblPropertyName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PropertyName")%>'></asp:Label>
                                                                    <a id="aBreaker" runat="server"></a>Units :
                                                                    <%#DataBinder.Eval(Container.DataItem, "SeqNo")%>
                                                                </div>
                                                                <div class="leftmargin_icons">
                                                                    <asp:ImageButton ID="btnEdit" ToolTip="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RoomTypeID")%>'
                                                                        CommandName="EDITDATA" runat="server" ImageUrl="~/images/edit.png" Style="border: 0px;
                                                                        vertical-align: middle; margin-top: 7px; margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                    <asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RoomTypeID")%>'
                                                                        CommandName="DELETEDATA" runat="server" ImageUrl="~/images/delete_icon.png" Style="border: 0px;
                                                                        vertical-align: middle; margin-top: 7px; margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                </div>
                                                                <div class="clear">
                                                                </div>
                                                            </div>
                                                            <div class="clear">
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <div class="pagecontent_info" id="MsgRecFnd" runat="server">
                                                <div class="NoItemsFound" id="msgNoRecordFound" runat="server">
                                                    <h2>
                                                        <asp:Literal ID="Literal5" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                </div>
                                            </div>
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
                                    <td align="left" valign="middle" style="float: left; padding-top: 50px;">
                                        <td align="center" valign="middle">
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
        <asp:PostBackTrigger ControlID="btnSave" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updRoomType" ID="UpdateProgressRoomType"
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
