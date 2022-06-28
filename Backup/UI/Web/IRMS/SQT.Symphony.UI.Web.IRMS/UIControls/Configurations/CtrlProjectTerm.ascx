<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProjectTerm.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Configurations.CtrlProjectTerm" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
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
<asp:UpdatePanel ID="updProjectTerm" runat="server">
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
                                INFILL SETUP
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
                                        <td colspan="4">
                                            <div style="height: 26px;">
                                                <%if (IsInsert)
                                                  { %>
                                                <div class="ResetSuccessfully">
                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                        <img src="../../images/success.png" /></div>
                                                    <div>
                                                        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <%}%>
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
                                        <td align="left" valign="top" style="width: 25%;">
                                            <asp:Label ID="litCategory" runat="server" Text="Label Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfCategory" runat="server" ControlToValidate="ddlCategory"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    ErrorMessage="*" ValidationGroup="RoomTypeForm"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td align="left" valign="top" style="width: 75%;">
                                            <asp:DropDownList ID="ddlCategory" runat="server" Style="width: 202px;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litTermName" runat="server" Text="Infill Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfTermName" runat="server" ControlToValidate="txtTermName"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="RoomTypeForm"></asp:RequiredFieldValidator></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTermName" runat="server" SkinID="CmpTextbox" MaxLength="137"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litTermCode" runat="server" Text="Infill Code" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfTermCode" runat="server" ControlToValidate="txtTermCode"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="RoomTypeForm"></asp:RequiredFieldValidator></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTermCode" runat="server" MaxLength="7" SkinID="CmpTextbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td>
                                            <asp:Literal ID="litForColor" runat="server" Text="Font Color"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtForeColor" runat="server" Text="FFFFFF" Enabled="false" SkinID="CmpTextbox"
                                                MaxLength="180"></asp:TextBox>
                                            <ajx:ColorPickerExtender ID="txtForeColor_ColorPickerExtender" runat="server" Enabled="True"
                                                TargetControlID="txtForeColor" PopupButtonID="imgColor">
                                            </ajx:ColorPickerExtender>
                                            <asp:Image ID="imgColor" CssClass="small_img" runat="server" ImageUrl="~/images/colorfill.png"
                                                Height="20px" Width="20px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litBackColor" runat="server" Text="Background Color"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBackColor" runat="server" Text="FFFFFF" Enabled="false" SkinID="CmpTextbox"
                                                MaxLength="180"></asp:TextBox>
                                            <ajx:ColorPickerExtender ID="clrBackColor" runat="server" Enabled="True" TargetControlID="txtBackColor"
                                                PopupButtonID="imgBackCOlor">
                                            </ajx:ColorPickerExtender>
                                            <asp:Image ID="imgBackCOlor" CssClass="small_img" runat="server" ImageUrl="~/images/colorfill.png"
                                                Height="20px" Width="20px" />
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" style="text-align: right;">
                                            <div style="float: right; height: 196px; width: auto; display: inline-block;">
                                                <asp:Button ID="btnNew" runat="server" Style="display: inline-block; margin-left: 5px;
                                                    display: inline;" Text="New" OnClick="btnNew_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/save.png" ValidationGroup="RoomTypeForm" CausesValidation="true"
                                                    OnClick="btnSave_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
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
                                                    Label Infill
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlsCategory" runat="server" SkinID="Search">
                                                    </asp:DropDownList>
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; vertical-align: middle; margin: 2px 0 0 5px" OnClick="btnSearch_Click"
                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <div style="height: 368px; overflow: auto;">
                                            <asp:GridView ID="grdProjectTermList" runat="server" ShowHeader="false" ShowFooter="false"
                                                SkinID="gvNoPaging" AutoGenerateColumns="false" Width="92%" OnRowCommand="grdProjectTermList_RowCommand"
                                                OnRowDataBound="grdProjectTermList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea" style="width: 94px !important;">
                                                                    <strong>
                                                                        <%#DataBinder.Eval(Container.DataItem, "DisplayTerm")%></strong>
                                                                </div>
                                                                <div class="leftmargin_icons" style="width: 90px;">
                                                                    <div style="float: right;">
                                                                        <asp:ImageButton ID="btnDelete" ToolTip="Delete" runat="server" ImageUrl="~/images/delete_icon.png"
                                                                            Style="border: 0px; vertical-align: middle; margin-top: 2px; margin-right: 7px;"
                                                                            CommandName="DeleteData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "TermID")%>'
                                                                            OnClientClick="fnDisplayCatchErrorMessage()" /></div>
                                                                    <div style="float: right;">
                                                                        <asp:ImageButton ID="btnEdit" ToolTip="Edit" runat="server" ImageUrl="~/images/edit.png"
                                                                            Style="border: 0px; vertical-align: middle; margin-top: 2px; margin-right: 7px;"
                                                                            CommandName="EditData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "TermID")%>'
                                                                            OnClientClick="fnDisplayCatchErrorMessage()" /></div>
                                                                </div>
                                                                <div class="clear">
                                                                </div>
                                                            </div>
                                                            <div class="clear">
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
        <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="Panel1"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="Panel1" runat="server" Style="display: none;">
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
                            <div style="float: left; width: 225px; margin-top: 40px; margin-left: 10px;">
                                <asp:Label ID="Label1" runat="server" Text="Sure you want to delete?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <asp:Button ID="btnProjectTermYes" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnProjectTermYes_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnProjectTermNo" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            OnClick="btnProjectTermNo_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
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
        <ajx:ModalPopupExtender ID="DeleteMsg" runat="server" TargetControlID="hfDeleteMsg"
            PopupControlID="pnlDeleteMsg" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfDeleteMsg" runat="server" />
        <asp:Panel ID="pnlDeleteMsg" runat="server" Style="display: none;">
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
                                <asp:Label ID="Label2" runat="server" Text="Sure you want to delete?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle" style="padding-top: 50px;">
                                        <asp:Button ID="btnYesDelete" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnYesDelete_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnCancelDelete" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            OnClick="btnCancelDelete_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updProjectTerm" ID="UpdateProgressProjectTerm"
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
