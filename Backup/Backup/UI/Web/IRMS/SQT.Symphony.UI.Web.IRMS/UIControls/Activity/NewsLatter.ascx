<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsLatter.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Activity.NewsLatter" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
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
<script language="javascript" type="text/javascript">

    function CheckBoxListSelectProspects(checkbox) {

        var chkBoxList = document.getElementById('<%= chkProspectList.ClientID%>');
        var chkBoxCount = chkBoxList.getElementsByTagName("input");

        for (var i = 0; i < chkBoxCount.length; i++) {
            chkBoxCount[i].checked = checkbox.checked;
        }

        return false;

    }

    function CheckBoxListSelectInvestor(checkbox) {

        var chkBoxList = document.getElementById('<%= chkInvestorList.ClientID%>');
        var chkBoxCount = chkBoxList.getElementsByTagName("input");

        for (var i = 0; i < chkBoxCount.length; i++) {
            chkBoxCount[i].checked = checkbox.checked;
        }

        return false;

    }

    function CheckBoxListSelectChannelPartner(checkbox) {

        var chkBoxList = document.getElementById('<%= chkChannelPartnerList.ClientID%>');
        var chkBoxCount = chkBoxList.getElementsByTagName("input");

        for (var i = 0; i < chkBoxCount.length; i++) {
            chkBoxCount[i].checked = checkbox.checked;
        }

        return false;

    }

    function CheckBoxListSelectSales(checkbox) {

        var chkBoxList = document.getElementById('<%= chkSalesList.ClientID%>');
        var chkBoxCount = chkBoxList.getElementsByTagName("input");

        for (var i = 0; i < chkBoxCount.length; i++) {
            chkBoxCount[i].checked = checkbox.checked;
        }

        return false;

    }

    function CheckBoxListSelectAllDatabase(checkbox) {

        document.getElementById('<%= chkSelectAllProspects.ClientID%>').checked = checkbox.checked;
        document.getElementById('<%= chkSelectAllInvestors.ClientID%>').checked = checkbox.checked;
        document.getElementById('<%= chkSelectAllChannelPartner.ClientID%>').checked = checkbox.checked;
        document.getElementById('<%= chkSelectAllSales.ClientID%>').checked = checkbox.checked;


        var chkBoxProspectList = document.getElementById('<%= chkProspectList.ClientID%>');
        var chkBoxProspectCount = chkBoxProspectList.getElementsByTagName("input");

        var chkBoxInvestorList = document.getElementById('<%= chkInvestorList.ClientID%>');
        var chkBoxInvestorCount = chkBoxInvestorList.getElementsByTagName("input");

        var chkBoxChannelPartnerList = document.getElementById('<%= chkChannelPartnerList.ClientID%>');
        var chkBoxChannelPartnerCount = chkBoxChannelPartnerList.getElementsByTagName("input");

        var chkBoxSalesList = document.getElementById('<%= chkSalesList.ClientID%>');
        var chkBoxSalesCount = chkBoxSalesList.getElementsByTagName("input");

        for (var i = 0; i < chkBoxProspectCount.length; i++) {
            chkBoxProspectCount[i].checked = checkbox.checked;
        }

        for (var i = 0; i < chkBoxInvestorCount.length; i++) {
            chkBoxInvestorCount[i].checked = checkbox.checked;
        }

        for (var i = 0; i < chkBoxChannelPartnerCount.length; i++) {
            chkBoxChannelPartnerCount[i].checked = checkbox.checked;
        }

        for (var i = 0; i < chkBoxSalesCount.length; i++) {
            chkBoxSalesCount[i].checked = checkbox.checked;
        }

        return false;

    }
    
</script>
<asp:UpdatePanel ID="updNewsLatter" runat="server">
    <ContentTemplate>
        <script language="javascript" type="text/javascript">
            function validation() {

                document.getElementById('errormessage').style.display = "block";

                var title = document.getElementById('<%= txtTitle.ClientID%>').value;
                var NewsFor = document.getElementById('<%= ddlNewsFor.ClientID%>').value;
                var issuccess = true;
                if (title == '') {
                    document.getElementById("starTitle").style.display = "block";
                    issuccess = false;
                }
                else {
                    document.getElementById("starTitle").style.display = "none";
                }
                if (NewsFor == '00000000-0000-0000-0000-000000000000') {
                    document.getElementById("starNewsfor").style.display = "block";
                    issuccess = false;
                }
                else {
                    document.getElementById("starNewsfor").style.display = "none";
                }
                return issuccess;
            }
        </script>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                NEWS LETTER
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
                                                        <asp:Label ID="lblNewsMsg" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <% }%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <div style="float: right;">
                                                <b>All Bold Fields are Mandatory</b>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litTitle" runat="server" Text="Title" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart" id="starTitle" style="display: none; color: Red;">* </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTitle" runat="server" SkinID="Long" MaxLength="20"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litNewsFor" runat="server" Text="News For" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart" id="starNewsfor" style="display: none; color: Red;">*
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlNewsFor" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Literal ID="litDetails" runat="server" Text="Detail"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <CKEditor:CKEditorControl ID="edtrDetail" runat="server" ToolbarStartupExpanded="false"
                                                ResizeMaxWidth="450" Height="500"></CKEditor:CKEditorControl>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div style="text-align: right; margin-top: 5px; width: 100%;">
                                                <asp:Button ID="btnNew" runat="server" Style="margin-left: 5px; display: inline-block;"
                                                    Text="New" OnClick="btnNew_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:Button ID="btnSave" Text="Save" Style="margin-left: 5px; display: inline-block;"
                                                    runat="server" ImageUrl="~/images/save.png" ValidationGroup="NewLatter" CausesValidation="true"
                                                    OnClientClick="return validation();" OnClick="btnSave_Click" />
                                                <asp:Button ID="btnPublish" Text="Save & Publish" Style="margin-left: 5px; display: inline-block;"
                                                    runat="server" ImageUrl="~/images/cancle.png" ValidationGroup="Publish" CausesValidation="true"
                                                    OnClick="btnPublish_Click" OnClientClick="return validation();" />
                                                <%--<asp:Button ID="btnCancel" Text="Cancel" Style="margin-left: 5px; display: inline-block;"
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
                    <%-- <div class="clear">
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
                                                    Title
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSTitle" runat="server" SkinID="Search"></asp:TextBox>
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; vertical-align: middle; margin-top: -4px; margin-left: 5px;"
                                                        OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <div style="height: 725px;">
                                            <asp:GridView ID="grdNewList" runat="server" ShowHeader="false" ShowFooter="false"
                                                SkinID="gvNoPaging" AutoGenerateColumns="false" Width="92%" OnRowCommand="grdNewList_RowCommand"
                                                OnRowDataBound="grdNewList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea">
                                                                    <strong>
                                                                        <%#DataBinder.Eval(Container.DataItem, "Title")%></strong><br />
                                                                </div>
                                                                <div class="leftmargin_icons">
                                                                    <asp:ImageButton ID="btnEdit" ToolTip="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "NewsLetterID")%>'
                                                                        CommandName="EDITDATA" runat="server" ImageUrl="~/images/edit.png" Style="border: 0px;
                                                                        vertical-align: middle; margin-top: 7px; margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                    <asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "NewsLetterID")%>'
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
                                                <EmptyDataTemplate>
                                                    <div class="pagecontent_info" id="MsgRecFnd" runat="server">
                                                        <div class="NoItemsFound" id="msgNoRecordFound" runat="server">
                                                            <h2>
                                                                <asp:Literal ID="Literal5" runat="server" Text="No Record Found"></asp:Literal></h2>
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
                                        <asp:Button ID="btnAddressSave" Text="Yes" Style="display: inline-block;" runat="server"
                                            ImageUrl="~/images/save.png" OnClick="btnAddressSave_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnAddressCancel" Text="Cancel" Style="display: inline-block;" runat="server"
                                            ImageUrl="~/images/cancle.png" OnClick="btnAddressCancel_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
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
        <ajx:ModalPopupExtender ID="MailMsg" runat="server" TargetControlID="hfInvPros" PopupControlID="pnlInvPros"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfInvPros" runat="server" />
        <asp:Panel ID="pnlInvPros" runat="server" Style="display: none;">
            <div style="width: 800px; height: 250px; margin-top: 25px;">
                <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box" style="margin-top: -300px !important;">
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
                            <table cellpadding="2" cellspacing="3" width="100%">
                                <tr>
                                    <td align="left" valign="top" colspan="4" style="padding-bottom:5px;">
                                        <h2>
                                            <asp:CheckBox ID="chkSelectAllDatabase" runat="server" onclick="CheckBoxListSelectAllDatabase(this)" /><b>All Database</b></h2>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="width: 25%;">
                                        <h2>
                                            <asp:CheckBox ID="chkSelectAllProspects" runat="server" onclick="CheckBoxListSelectProspects(this)" /><b>Prospects</b></h2>
                                    </td>
                                    <td align="left" valign="top" style="width: 25%;">
                                        <h2>
                                            <asp:CheckBox ID="chkSelectAllInvestors" runat="server" onclick="CheckBoxListSelectInvestor(this)" /><b>Investors</b></h2>
                                    </td>
                                    <td align="left" valign="top" style="width: 25%;">
                                        <h2>
                                            <asp:CheckBox ID="chkSelectAllChannelPartner" runat="server" onclick="CheckBoxListSelectChannelPartner(this)" /><b>Channel
                                                Partner</b></h2>
                                    </td>
                                    <td align="left" valign="top" style="width: 25%;">
                                        <h2>
                                            <asp:CheckBox ID="chkSelectAllSales" runat="server" onclick="CheckBoxListSelectSales(this)" /><b>Sales</b></h2>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" style="width: 25%;">
                                        <div style="height: 250px; overflow: auto;">
                                            <asp:CheckBoxList ID="chkProspectList" runat="server" RepeatColumns="1">
                                            </asp:CheckBoxList>
                                        </div>
                                    </td>
                                    <td align="left" valign="top" style="width: 25%;">
                                        <div style="height: 250px; overflow: auto;">
                                            <asp:CheckBoxList ID="chkInvestorList" runat="server" RepeatColumns="1">
                                            </asp:CheckBoxList>
                                        </div>
                                    </td>
                                    <td align="left" valign="top" style="width: 25%;">
                                        <div style="height: 250px; overflow: auto;">
                                            <asp:CheckBoxList ID="chkChannelPartnerList" runat="server" RepeatColumns="1">
                                            </asp:CheckBoxList>
                                        </div>
                                    </td>
                                    <td align="left" valign="top" style="width: 25%;">
                                        <div style="height: 250px; overflow: auto;">
                                            <asp:CheckBoxList ID="chkSalesList" runat="server" RepeatColumns="1">
                                            </asp:CheckBoxList>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="middle" colspan="4">
                                        <div style="text-align: center;">
                                            <asp:Button ID="btnInvProsSend" Text="Send" Style="float: right; margin-left: 5px;
                                                display: inline-block;" runat="server" ImageUrl="~/images/save.png" OnClick="btnInvProsSend_Click"
                                                OnClientClick="fnDisplayCatchErrorMessage()" />
                                            <asp:Button ID="btnInvProsCancel" Text="Cancel" Style="float: right; margin-left: 5px;
                                                display: inline-block;" runat="server" ImageUrl="~/images/cancle.png" OnClick="btnInvProsCancel_Click"
                                                OnClientClick="fnDisplayCatchErrorMessage()" />
                                        </div>
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
<asp:UpdateProgress AssociatedUpdatePanelID="updNewsLatter" ID="UpdateProgressNewsLatter"
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
