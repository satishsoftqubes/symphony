<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAddOnsServices.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.CtrlAddOnsServices" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
    function fnConfirmDelete(id) {

        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnConfirmDelete.ClientID %>').value = id;
        $find('mpeConfirmDelete').show();
        return false;
    }
    function stopKey(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 8) && (node.type == "text")) { return false; }
        else if ((evt.keyCode == 9) && (node.type == "text")) { return true; }
        else if ((evt.keyCode == 46) && (node.type == "text")) { return false; }
        else { return false; }
    }

    function AddServicesValidate() {
        if (Page_ClientValidate("IsRequire")) {
            document.getElementById('errormessage').style.display = "block";
            var varServiceName = document.getElementById('<%= txtServiceName.ClientID %>').value;
            if (varDateFrom != '' && varDateTo != '') {

                var dateFormat = document.getElementById('<%= hfDateFormat.ClientID %>').value;                
            }
            else {
                return true;
            }
        }
    }
</script>
<asp:UpdatePanel ID="upAddServices" runat="server">
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
                                <asp:Literal ID="litMainHeader" runat="server" Text="Add Services"></asp:Literal>
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
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="btnAddTop" runat="server" Text="Add" Style="float: right;"
                                                    CssClass="add_content_inner" onclick="btnAddTop_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litAddOnServicesGuestList" runat="server" Text="Services"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                <asp:GridView ID="gvAddOnsServicesList" runat="server" AutoGenerateColumns="false" 
                                                        ShowHeader="true" Width="100%" 
                                                        onpageindexchanging="gvAddOnsServicesList_PageIndexChanging" 
                                                        onrowcommand="gvAddOnsServicesList_RowCommand" 
                                                        onrowdatabound="gvAddOnsServicesList_RowDataBound" >
                                                        <Columns>                                                        
                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrServiceName" runat="server" Text="Service Name"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvServiceName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ItemName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="litGvViewEdit" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ItemID")%>'
                                                                        CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" /></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ItemID")%>'
                                                                        CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div style="padding: 10px;">
                                                                <b>
                                                                    <asp:Label ID="lblNoRecordFound" runat="server" Text="No record found."></asp:Label>
                                                                </b>
                                                            </div>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <%--<asp:Button ID="btnBack" runat="server" Text="Back" CssClass="add_content_inner" />--%>
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
        <ajx:ModalPopupExtender ID="mpeOpenAddServices" runat="server" TargetControlID="hdnAddServices"
            PopupControlID="pnlAddServices" BackgroundCssClass="mod_background" CancelControlID="imgCancelAddServices">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnAddServices" runat="server" />
        <asp:Panel ID="pnlAddServices" runat="server" Width="450px">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="litAddServices" runat="server" Text="Add Services"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="imgCancelAddServices" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td class="isrequire" style="width: 140px !important;">
                                <asp:Literal ID="litServiceName" runat="server" Text="Service Name"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtServiceName" Width="180px" SkinID="nowidth" runat="server"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvServiceName" runat="server" ControlToValidate="txtServiceName"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnSave" runat="server" Style="display: inline; padding-right: 10px;"
                                    Text="Save" ValidationGroup="IsRequire" 
                                    OnClientClick="return AddServicesValidate();" onclick="btnSave_Click" />
                                <asp:Button ID="btnCancel" runat="server" Style="display: inline;" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>

        <ajx:ModalPopupExtender ID="mpeDateMessage" runat="server" TargetControlID="hfDateMessage"
            PopupControlID="pnlDateMessage" BackgroundCssClass="mod_background" CancelControlID="btnDateMessageOK"
            BehaviorID="mpeDateMessage">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfDateMessage" runat="server" />
        <asp:Panel ID="pnlDateMessage" runat="server" Width="350px">
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
                                <asp:Literal ID="ltrMsgDateValidate" Text="Date from should be less than or equal to Date to."
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

        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnCancelDelete"
            BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="350px" Width="325px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderConfirmDeletePopup" Text="Services" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="ltrConfirmDeleteMsg" Text="Sure you want to delete?" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYes" Text="Yes" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClientClick="fnDisplayCatchErrorMessage();" onclick="btnYes_Click" />
                                <asp:Button ID="btnCancelDelete" Text="Cancel" runat="server" Style="display: inline;" />
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
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="upAddServices" ID="UpdateProgressAddServices"
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