<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlUsers.ascx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.UserSetUp.CtrlUsers" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnCheckDuplicateUser() {
        document.getElementById('lblshow').style.display = 'none';
        document.getElementById('<%= hfIsDuplicateUser.ClientID %>').value = '0'
        if (document.getElementById('<%= txtUserName.ClientID %>').value != '')
            PageMethods.GetUser(document.getElementById('<%= txtUserName.ClientID %>').value, document.getElementById('<%= hfUserIDToCheckDuplicate.ClientID %>').value, OnSucceeded);
    }

    function OnSucceeded(result, userContext, methodName) {
        if (result == "1") {
            document.getElementById('<%= hfIsDuplicateUser.ClientID %>').value = '1';
            document.getElementById('lblshow').style.display = 'block';
        }
    }

    function fnCustVlDuplicateUser(source, args) {
        if (document.getElementById('<%= hfIsDuplicateUser.ClientID %>').value == '1') {
            document.getElementById('lblshow').style.display = 'block';
            args.IsValid = false;
        }
        else {
            args.IsValid = true;
        }
    }

    function pageLoad(sender, args) {
        $(document).ready(function () {

            $("#<%=txtSUserName.ClientID%>").autocomplete('UserAutoComplete.ashx');
        });
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
<asp:UpdatePanel ID="UpdUsr" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hfUserIDToCheckDuplicate" runat="server" />
        <asp:HiddenField ID="hfIsDuplicateUser" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                USER SETUP
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
                                <table cellpadding="2" cellspacing="3" border="0" width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <div style="height: 26px;">
                                                <%if (IsMessage)
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
                                        <td colspan="2" id="trInvestorMsg" runat="server" visible="false">
                                            <div style="float: right; color:Red;">
                                                <b>You can't add Investor from here.</b>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="130px">
                                            <asp:Label ID="ltrRoleName" runat="server" Text="Role" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfUserType" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="User" ControlToValidate="ddlRoleName" ErrorMessage="*"
                                                    InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <%--<asp:DropDownList ID="ddlRoleName" runat="server" Style="width: 202px;" OnSelectedIndexChanged="ddlRoleName_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>--%>
                                            <asp:DropDownList ID="ddlRoleName" runat="server" Style="width: 202px;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litUserName" runat="server" Text="User Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="refEmail" SetFocusOnError="True" Display="Dynamic"
                                                    ControlToValidate="txtUserName" ValidationGroup="User" runat="server" ErrorMessage="*"
                                                    CssClass="rfv_ErrorStar" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="rvfUserName" Display="Dynamic" SetFocusOnError="true"
                                                    CssClass="rfv_ErrorStar" runat="server" ValidationGroup="User" ControlToValidate="txtUserName"
                                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td align="left">
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtUserName" runat="server" SkinID="CmpTextbox" MaxLength="180"
                                                            onblur='fnCheckDuplicateUser();'></asp:TextBox>
                                                        <asp:CustomValidator ID="cstvUserName" runat="server" ControlToValidate="txtUserName"
                                                            ErrorMessage="" Display="Dynamic" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                            ValidationGroup="User" ClientValidationFunction="fnCustVlDuplicateUser"></asp:CustomValidator>
                                                    </td>
                                                    <td align="left">
                                                        <div id="lblshow" style="font-size: 11px; padding-top: 4px; padding-left: 5px; color: Red;
                                                            display: none;">
                                                            User not available.
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litPassword" runat="server" Text="Password" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfPassword" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="User" ControlToValidate="txtPassword" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" SkinID="CmpTextbox"
                                                MaxLength="27"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litConfimPassword" runat="server" Text="Confirm Password" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="User" ControlToValidate="txtConfirmPwd" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtConfirmPwd" TextMode="Password" runat="server" SkinID="CmpTextbox"
                                                MaxLength="27"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:CompareValidator ID="cmpValidation" runat="server" ControlToValidate="txtConfirmPwd"
                                                Display="Dynamic" ControlToCompare="txtPassword" SetFocusOnError="true" ErrorMessage="Confirm Password not same as Password."
                                                CssClass="rfv_ErrorStar" ValidationGroup="User"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Literal1" runat="server" Text="Display Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="User" ControlToValidate="txtDisplayName" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDisplayName" runat="server" SkinID="CmpTextbox" MaxLength="67"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2">
                                            <div style="float: right; width: auto; height: 180px; display: inline-block;">
                                                <%--<asp:Button ID="btnCancel" Text="Cancel" Style="float: right; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage()" />--%>
                                                <asp:Button ID="btnSave" Text="Save" Style="float: right; margin-left: 5px;" runat="server"
                                                    ImageUrl="~/images/save.png" ValidationGroup="User" CausesValidation="true" OnClick="btnSave_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:Button ID="btnNew" runat="server" Style="float: right; margin-left: 5px; display: inline;"
                                                    Text="New" OnClick="btnNew_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
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
                                                    <td align="right" valign="bottom" rowspan="2" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                        User Name
                                                    </td>
                                                    <td style="vertical-align: middle;">
                                                        <asp:TextBox ID="txtSUserName" runat="server" Width="100" SkinID="Search"></asp:TextBox>
                                                        <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                            Style="border: 0px; vertical-align: middle; margin-top: -4px; margin-left: 5px;"
                                                            OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="leftmarginbox_content">
                                            <div style="height: 395px;  overflow-x: hidden; overflow-y: auto;">
                                                <asp:GridView ID="grdUserList" runat="server" ShowHeader="false" ShowFooter="false"
                                                    SkinID="gvNoPaging" AutoGenerateColumns="false" Width="100%" OnRowCommand="grdUserList_RowCommand"
                                                    OnRowDataBound="grdUserList_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <div class="rightmargin_grid">
                                                                    <div class="leftmargin_contentarea" style="width: 150px;">
                                                                        <strong>
                                                                            <%#DataBinder.Eval(Container.DataItem, "UserName")%></strong><br />
                                                                        <%#DataBinder.Eval(Container.DataItem, "RoleName")%><br />
                                                                    </div>
                                                                    <div class="leftmargin_icons">
                                                                        <asp:ImageButton ID="btnEdit" ToolTip="Edit" runat="server" ImageUrl="~/images/edit.png"
                                                                            Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
                                                                            CommandName="EditData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UsearID")%>'
                                                                            CausesValidation="false" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                        <asp:ImageButton ID="btnDelete" ToolTip="Delete" runat="server" ImageUrl="~/images/delete_icon.png"
                                                                            Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
                                                                            CommandName="DeleteData" CausesValidation="false" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "UsearID")%>'
                                                                            OnClientClick="fnDisplayCatchErrorMessage()" />
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
                                        ID="Image2" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div style="float: left; width: 225px; margin-top: 40px; margin-left: 10px;">
                                <asp:Label ID="Label1" runat="server" Text="Sure you want to delete?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <asp:Button ID="btnUserYes" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnUserYes_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnUserNo" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            OnClick="btnUserNo_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="UpdUsr" ID="UpdateProgressUsr" runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
