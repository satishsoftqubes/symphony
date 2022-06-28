<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlStayType.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.CtrlStayType" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/PriceManager/CtrlAdddEditStayType.ascx" TagName="CtrlAddEditStayType"
    TagPrefix="uc" %>
<script language="javascript" type="text/javascript">
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
<asp:UpdatePanel ID="updDepartment" runat="server">
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
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td colspan="5">
                                                <%if (IsListMessage)
                                                  { %>
                                                <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Literal ID="litMsgList" runat="server"></asp:Literal></strong>
                                                    </p>
                                                </div>
                                                <%}%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="litSearchStayName" runat="server"></asp:Literal>
                                            </th>
                                            <td style="width: 290px">
                                                <asp:TextBox ID="txtSrchStayName" runat="server" MaxLength="65"></asp:TextBox>
                                            </td>
                                            <th align="left">
                                                <asp:Literal ID="litSearchStayCode" runat="server"></asp:Literal>
                                            </th>
                                            <td style="width: 300px">
                                                <asp:TextBox ID="txtSrchStayCode" runat="server" MaxLength="7"></asp:TextBox>
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" ToolTip="Search"
                                                    OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" ToolTip="Reset"
                                                    OnClick="imgbtnClearSearch_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                            </td>
                                            <td align="left">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" align="right" valign="middle">
                                                <asp:Button ID="btnAddTop" runat="server" Style="float: right;" OnClick="btnAddTop_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage();" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litStayList" runat="server"></asp:Literal></span></div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvStayList" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        ShowHeader="true" OnRowCommand="gvStayList_RowCommand" OnRowDataBound="gvStayList_RowDataBound"
                                                        OnPageIndexChanging="gvStayList_PageIndexChanging">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="litGvHdrNumber" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="litGvHdrName" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "StayTypeName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="litGvHdrCode" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Code")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="litGvHdrActions" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "StayTypeID")%>'
                                                                        CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" /></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "StayTypeID")%>'
                                                                        CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div style="padding: 10px;">
                                                                <b>
                                                                    <asp:Literal ID="litNoRecordFound" runat="server"></asp:Literal>
                                                                </b>
                                                            </div>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" align="right" valign="middle">
                                                <asp:Button ID="btnAddBottom" runat="server" Style="float: right;" OnClick="btnAddTop_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage();" />
                                            </td>
                                        </tr>
                                    </table>
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
        <uc:CtrlAddEditStayType ID="ucAddEditStayType" runat="server" OnbtnCallParent_Click="btnCallParent_Click" />
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnCancelDelete"
            BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="350px" Width="325px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHeaderConfirmDeletePopup" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="litConfirmDeleteMsg" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYes" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClientClick="fnDisplayCatchErrorMessage();" OnClick="btnYes_Click" />
                                <asp:Button ID="btnCancelDelete" runat="server" Style="display: inline;" />
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
                        <asp:Literal ID="litHeaderCustomePopupMessage" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px; color: Red;">
                                <asp:Literal ID="litCustomePopupMsg" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnOKCustomeMsgPopup" runat="server" Style="display: inline; padding-right: 10px;" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updDepartment" ID="UpdateProgressDepartment"
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
