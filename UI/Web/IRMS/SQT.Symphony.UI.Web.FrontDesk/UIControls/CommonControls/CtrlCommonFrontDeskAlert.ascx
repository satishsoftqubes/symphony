<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonFrontDeskAlert.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCommonFrontDeskAlert" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    var TargetBaseControl = null;

    window.onload = function () {
        try {
            //get target base control.
            TargetBaseControl =
           document.getElementById('<%= this.gvUserList.ClientID %>');
        }
        catch (err) {
            TargetBaseControl = null;
        }
    }

    function TestCheckBox() {
        if (TargetBaseControl == null) return false;

        //get target child control.
        var TargetChildControl = "chkSelectUser";

        //get all the control of the type INPUT in the base control.
        var Inputs = TargetBaseControl.getElementsByTagName("input");

        for (var n = 0; n < Inputs.length; ++n)
            if (Inputs[n].type == 'checkbox' &&
            Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 &&
            Inputs[n].checked)
                return true;

        alert('Select at least one User!');
        return false;
    }

</script>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="content">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="boxtopleft">
                        &nbsp;
                    </td>
                    <td class="boxtopcenter">
                        <asp:Literal ID="litMainHeader" runat="server" Text="Front Desk Alert"></asp:Literal>
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
                            <asp:MultiView ID="mvFrontDeskAlert" runat="server">
                                <asp:View ID="vFrontDeskAlertList" runat="server">
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td style="width: 90px;">
                                                <asp:Literal ID="litSearchPostBy" Text="Post By" runat="server"></asp:Literal>
                                            </td>
                                            <td style="width: 245px;">
                                                <asp:TextBox ID="txtSearchPostBy" runat="server" Style="width: 160px;"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Literal ID="litSearchDate" Text="Date" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearchDate" runat="server" Style="width: 90px !important;" onkeypress="return false;"></asp:TextBox>
                                                <asp:Image ID="imgSearchDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                    Height="20px" Width="20px" />
                                                <ajx:CalendarExtender ID="caltxtSearchDate" PopupButtonID="imgSearchDate" TargetControlID="txtSearchDate"
                                                    runat="server" Format="dd-MM-yyyy">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" id="imgAD" style="vertical-align: middle;" title="Clear Date"
                                                    onclick="fnClearDate('<%= txtSearchDate.ClientID %>');" />
                                                <asp:ImageButton ID="btnSearch" runat="server" ToolTip="Search" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" OnClick="btnSearch_Click" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ToolTip="Clear" OnClick="imgbtnClearSearch_OnClick" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Button ID="btnAddTop" runat="server" Style="float: right;" OnClick="btnAddTop_OnClick"
                                                    Text="Add" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top;" colspan="4">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litAlertList" runat="server" Text="Alert List"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvFrontDeskAlertList" runat="server" AutoGenerateColumns="false"
                                                        ShowHeader="true" Width="100%" OnRowCommand="gvFrontDeskAlertList_RowCommand"
                                                        OnPageIndexChanging="gvFrontDeskAlertList_PageIndexChanging">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrMoveUnitSrNo" runat="server" Text="No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrMessage" runat="server" Text="Message"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#TruncateString(DataBinder.Eval(Container.DataItem, "Messege").ToString(), 50)%>
                                                                    <%-- <%#DataBinder.Eval(Container.DataItem, "Messege")%>--%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrPostBy" runat="server" Text="Message By"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "MessageByName")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "MsgDateTime")).ToString(clsSession.DateFormat)%>
                                                                    <%-- <%#DataBinder.Eval(Container.DataItem, "MsgDateTime")%>--%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblActions" runat="server" Text="Action"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPopUp" runat="server" Text="Action"></asp:Label>
                                                                    <ajx:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lblPopUp"
                                                                        PopupControlID="Panel2" PopupPosition="Left">
                                                                    </ajx:HoverMenuExtender>
                                                                    <asp:Panel ID="Panel2" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                        <div class="actionsbuttons_hovermenu">
                                                                            <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                                <tr>
                                                                                    <td class="actionsbuttons_hover_lettmenu">
                                                                                    </td>
                                                                                    <td class="actionsbuttons_hover_centermenu">
                                                                                        <ul>
                                                                                            <li>
                                                                                                <asp:LinkButton Style="background: none !important; border: none;" ID="lnkEdit" runat="server"
                                                                                                    ToolTip="Edit" CommandName="ALERTEDIT" CommandArgument='<%#Eval("FrontDeskAlertMsgID") + "," +Eval("MessageBy") + "," +Eval("Messege")%>'><img src="../../images/edit.png" /></asp:LinkButton>
                                                                                            </li>
                                                                                            <li>
                                                                                                <asp:LinkButton Style="background: none !important; border: none;" ID="lnkDelete"
                                                                                                    OnClientClick="return confirm('Are you certain you want to delete this record ?');"
                                                                                                    runat="server" ToolTip="Delete" CommandName="ALERTDELETE" CommandArgument='<%#Eval("FrontDeskAlertMsgID") + "," +Eval("MessageBy") + "," +Eval("Messege")%>'><img src="../../images/delete_icon.png" /></asp:LinkButton>
                                                                                            </li>
                                                                                            <li>
                                                                                                <asp:LinkButton Style="background: none !important; border: none;" ID="lnkViewMsg"
                                                                                                    runat="server" ToolTip="VIEW" CommandName="ALERTVIEW" CommandArgument='<%#Eval("FrontDeskAlertMsgID") + "," +Eval("MessageBy") + "," +Eval("Messege")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                            </li>
                                                                                        </ul>
                                                                                    </td>
                                                                                    <td class="actionsbuttons_hover_rightmenu">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </asp:Panel>
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
                                                    <ajx:ModalPopupExtender ID="mpeMessege" runat="server" TargetControlID="hdnMessege"
                                                        PopupControlID="pnlMessege" BackgroundCssClass="mod_background">
                                                    </ajx:ModalPopupExtender>
                                                    <asp:HiddenField ID="hdnMessege" runat="server" />
                                                    <asp:Panel ID="pnlMessege" runat="server" Width="600px" Style="display: none;">
                                                        <div class="box_col1">
                                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="txtMessageToView" Style="width: 100%; height: 100%;" runat="server"
                                                                            TextMode="MultiLine"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="center">
                                                                        <div style="display: inline-block;">
                                                                            <asp:Button ID="btnCancelPopUp" runat="server" CausesValidation="false" ImageUrl="~/images/cancle.png"
                                                                                Style="float: right; margin-left: 5px;" Text="Close" OnClick="btnCancelPopUp_Click" />
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </asp:Panel>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Button ID="btnAddBottom" runat="server" Style="float: right;" OnClick="btnAddTop_OnClick"
                                                    Text="Add" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="vFrontDeskAlertDetail" runat="server">
                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <%if (IsFrontDeskAlertMessageMsg)
                                                  { %>
                                                <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Literal ID="litFrontDeskAlertMessageMsg" runat="server"></asp:Literal></strong>
                                                    </p>
                                                </div>
                                                <%}%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="litMessageBy" runat="server" Text="Message By"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlMassegeBy" runat="server">
                                                    <%--  <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                    <asp:ListItem Text="Mr. Pardip Patel" Value="Mr. Pardip Patel"></asp:ListItem>
                                                    <asp:ListItem Text="Miss. Payal Maru" Value="Miss. Payal Maru"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvMassegeBy" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                        ValidationGroup="IsRequire" ControlToValidate="ddlMassegeBy" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire" style="vertical-align: top;">
                                                <asp:Literal ID="litAlertMessage" runat="server" Text="Alert Message"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMessage" runat="server" Rows="5" TextMode="MultiLine" Style="width: 406px;"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvMessage" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtMessage" Display="Dynamic">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top;" class="isrequire">
                                                <asp:Literal ID="litSelectUser" runat="server" Text="Message For"></asp:Literal>
                                            </td>
                                            <td>
                                                <table width="50%" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td>
                                                            <div class="box_head">
                                                                <span>
                                                                    <asp:Literal ID="litUserList" runat="server" Text="User list"></asp:Literal>
                                                                </span>
                                                            </div>
                                                            <div class="clear">
                                                            </div>
                                                            <div class="box_content">
                                                                <asp:GridView ID="gvUserList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                    Width="100%" DataKeyNames="EmployeeID">
                                                                    <Columns>
                                                                        <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox runat="server" ID="chkSelectUser" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrUser" runat="server" Text="User Name"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "User")%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrDepartment" runat="server" Text="Department"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <%#DataBinder.Eval(Container.DataItem, "Department")%>
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
                                        <tr>
                                            <td colspan="2" align="right">
                                                <div style="display: inline-block;">
                                                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" ImageUrl="~/images/cancle.png"
                                                        Style="float: right; margin-left: 5px;" Text="Cancel" OnClick="btnCancel_OnClick" />
                                                    <asp:Button ID="btnSave" runat="server" CausesValidation="true" Text="Save" OnClientClick="javascript:return TestCheckBox();"
                                                        OnClick="btnSave_OnClick" ImageUrl="~/images/save.png" Style="float: right; margin-left: 5px;"
                                                        ValidationGroup="IsRequire" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
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
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
