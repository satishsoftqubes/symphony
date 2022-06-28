<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRoom.ascx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Configurations.CtrlRoom" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>

<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function pageLoad(sender, args) {

        $(document).ready(function () {
            $("#<%=txtSearchUnitNo.ClientID%>").autocomplete('RoomAutoComplete.ashx');            
        });
    }
</script>

<style type="text/css">
    #progressBackgroundFilter
    {
        position: fixed;
        top: 0px;
        width:100%;
        height:100%;
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
        border-radius:10px;
        z-index: 1111112;
        background-color:#fff;
        border: solid 1px #efefef;
    }
</style>
<asp:UpdatePanel ID="updRoom" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                UNIT SETUP
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
                                                        <asp:Label ID="lblRoomErrorMsg" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <% }%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div style="float:right;">
                                                <b>All Bold Fields are Mandatory</b>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" style="width: 120px;">
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
                                            <asp:Label ID="Literal1" runat="server" Text="Unit Type" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfddlUnitType" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    InitialValue="00000000-0000-0000-0000-000000000000" runat="server" ControlToValidate="ddlUnitType"
                                                    ErrorMessage="*" ValidationGroup="RoomTypeForm"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlUnitType" runat="server" Style="width: 202px;" OnSelectedIndexChanged="ddlUnitType_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Literal23" runat="server" Text="Block" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfddlWing" SetFocusOnError="true" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    CssClass="rfv_ErrorStar" runat="server" ControlToValidate="ddlWing" ErrorMessage="*"
                                                    ValidationGroup="RoomTypeForm"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlWing" runat="server" Style="width: 202px;" OnSelectedIndexChanged="ddlWing_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Literal22" runat="server" Text="Floor" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfddlFloor" SetFocusOnError="true" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    CssClass="rfv_ErrorStar" runat="server" ControlToValidate="ddlFloor" ErrorMessage="*"
                                                    ValidationGroup="RoomTypeForm"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlFloor" Style="width: 202px;" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litRoomNo" runat="server" Text="Unit No." CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfRoomNo" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ControlToValidate="txtRoomNo" ErrorMessage="*" ValidationGroup="RoomTypeForm"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRoomNo" runat="server" MaxLength="9" SkinID="CmpTextbox"></asp:TextBox>
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
                                            <asp:TextBox ID="txtSBArea" runat="server" SkinID="CmpTextbox" MaxLength="12" Enabled="false"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FLTtxtSBArea" runat="server" FilterType="Custom, Numbers"
                                                ValidChars="." TargetControlID="txtSBArea" Enabled="True">
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
                                            <asp:TextBox ID="txtCarpetArea" runat="server" SkinID="CmpTextbox" MaxLength="12" Enabled="false"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FLTtxtCarpetArea" runat="server" FilterType="Custom, Numbers"
                                                ValidChars="." TargetControlID="txtCarpetArea" Enabled="True">
                                            </ajx:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                   <%-- <tr>
                                        <td>
                                            <asp:Literal ID="Literal21" runat="server" Text="Khata No."></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPropertyTaxAmt" runat="server" SkinID="CmpTextbox" MaxLength="300"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litLocationDetail" runat="server" Text="Unit Description"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLocationDetail" TextMode="MultiLine" runat="server" Height="60px"
                                                SkinID="Medium"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="trAmenities" runat="server" visible="false">
                                        <td>
                                            <asp:Literal ID="Literal2" runat="server" Text="Amenities"></asp:Literal>
                                        </td>
                                        <td class="checkbox_new">
                                            <div style="min-height: 25px; overflow: auto; height: 100px;">
                                                <asp:CheckBoxList ID="chklstRoomTypeAmenities" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                                                </asp:CheckBoxList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align:right;">
                                            <div style="float: right; vertical-align: middle; margin-top: 5px; width: auto; display: inline-block;">
                                                <asp:Button ID="btnNew" runat="server" style="display: inline-block;margin-left:5px;display:inline;" Text="New" OnClick="btnNew_Click" OnClientClick="fnDisplayCatchErrorMessage()"/>
                                                <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;" runat="server"
                                                    ImageUrl="~/images/save.png" ValidationGroup="RoomTypeForm" CausesValidation="true"
                                                    OnClick="btnSave_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <%--<asp:Button ID="btnCancel" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click" OnClientClick="fnDisplayCatchErrorMessage()" />--%>
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
                                        <table id="tbl" cellpadding="2" cellspacing="0" border="0" class="pageinfo">
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Property Name
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSProperty" runat="server" SkinID="Search" OnSelectedIndexChanged="ddlSProperty_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Unit Type
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSUnitType" runat="server" SkinID="Search">
                                                    </asp:DropDownList>                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Unit No.
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSearchUnitNo" runat="server" SkinID="Search"></asp:TextBox>
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; vertical-align: middle; margin: -4px 7px 0 5px;" OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <div style="height: 337px; overflow-x: hidden; overflow-y: auto;">
                                            <asp:GridView ID="grdRoomList" runat="server" ShowHeader="false" ShowFooter="false"
                                                SkinID="gvNoPaging" AutoGenerateColumns="false" Width="92%" OnRowCommand="grdRoomList_RowCommand"
                                                OnRowDataBound="grdRoomList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea">
                                                                    <strong>
                                                                        <%#DataBinder.Eval(Container.DataItem, "RoomNo")%></strong><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "PropertyName")%><br />
                                                                    <strong>
                                                                    <asp:LinkButton ID="lnkInvestorName" style="text-decoration:none;" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorID")%>' CommandName="INVESTOR" Text='<%#DataBinder.Eval(Container.DataItem, "InvestorName")%>'></asp:LinkButton></strong>
                                                                </div>
                                                                <div class="leftmargin_icons">
                                                                    <asp:ImageButton ID="btnEdit" ToolTip="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RoomID")%>'
                                                                        CommandName="EDITDATA" runat="server" ImageUrl="~/images/edit.png" Style="border: 0px;
                                                                        vertical-align: middle; margin-top: 7px; margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                    <asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RoomID")%>'
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
        <asp:Panel ID="pnl" runat="server" style="display:none;">
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
                            <div style="width: 100px;float:left;margin-top:10px;">
                                <asp:HyperLink ID="CloseModelPopup" runat="server">
                                    <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                        ID="btnImage" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div style="float:left;width:225px;margin-top:40px;margin-left:10px;">
                                <asp:Label ID="lblErrorMessage" runat="server" Text="Sure you want to delete?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px;margin-top:15px;">
                                <tr>
                                    <td align="center" valign="middle" >
                                        <asp:Button ID="btnAddressSave" Text="Yes" runat="server" ImageUrl="~/images/save.png" OnClick="btnAddressSave_Click" style="display:inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />                                    
                                        <asp:Button ID="btnAddressCancel" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png" OnClick="btnAddressCancel_Click" style="display:inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
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
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updRoom" ID="UpdateProgressRoom" runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
