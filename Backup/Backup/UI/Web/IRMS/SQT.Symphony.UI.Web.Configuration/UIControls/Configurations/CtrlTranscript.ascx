<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlTranscript.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlTranscript" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
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

    function validation() {
        document.getElementById('errormessage').style.display = "block";
        var title = document.getElementById('<%= txtTitle.ClientID%>').value;
        var type = document.getElementById('<%= ddlTranscriptType.ClientID%>').value;
        var ModuleName = document.getElementById('<%= ddlModuleName.ClientID%>').value;
        var issuccess = true;

        if (title == '') {
            document.getElementById("spnTitle").style.display = "inline-block";
            document.getElementById("spnTitle").style.float = "left";
            document.getElementById("spnTitle").style.height = "18px";
            issuccess = false;
        }
        else {
            document.getElementById("spnTitle").style.display = "none";
        }

        if (type == '00000000-0000-0000-0000-000000000000') {
            document.getElementById("spnType").style.display = "inline-block";
            document.getElementById("spnType").style.float = "left";
            document.getElementById("spnType").style.height = "18px";
            issuccess = false;
        }
        else {
            document.getElementById("spnType").style.display = "none";
        }

        if (ModuleName == '00000000-0000-0000-0000-000000000000') {
            document.getElementById("spnModule").style.display = "inline-block";
            document.getElementById("spnModule").style.float = "left";
            document.getElementById("spnModule").style.height = "18px";
            issuccess = false;
        }
        else {
            document.getElementById("spnModule").style.display = "none";
        }
        return issuccess;
    }
            
</script>
<asp:UpdatePanel ID="updTranscript" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeaderTranscript" runat="server"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                            </td>
                            <td align="left">
                                <div class="box_form">
                                    <asp:MultiView ID="mvTranscript" runat="server">
                                        <asp:View ID="vTranscriptList" runat="server">
                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td colspan="6">
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
                                                    <td>
                                                        <asp:Literal ID="litSearchTitle" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox Style="width: 130px;" ID="txtSearchTitle" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litSearchType" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlSearchType" Style="width: 130px;">
                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                            <asp:ListItem Text="SOP" Value="SOP"></asp:ListItem>
                                                            <asp:ListItem Text="Transcript" Value="Transcript"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 100px;">
                                                        <asp:Literal ID="litSearchModulName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchModuleName" Style="width: 130px;" runat="server"></asp:TextBox>
                                                        <asp:ImageButton ID="btnSearch" OnClick="btnSearch_Click" runat="server" ImageUrl="~/images/search-icon.png"
                                                            Style="border: 0px; margin: 2px 0 0 5px; vertical-align: middle;" />
                                                        <asp:ImageButton ID="imgbtnClearSearch" OnClick="imgbtnClearSearch_Click" runat="server"
                                                            ImageUrl="~/images/clearsearch.png" Style="border: 0px; vertical-align: middle;
                                                            margin: 2px 0 0 10px;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <asp:Button ID="btnTopAdd" runat="server" Style="float: right;" OnClick="btnTopAdd_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6" style="padding-bottom: 15px;">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litTranscript" runat="server" Text="Transcript List"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvTranscriptList" OnRowDataBound="gvTranscript_RowDataBound" OnRowCommand="gvTranscript_RowCommand"
                                                                runat="server" AutoGenerateColumns="false" ShowHeader="true" Width="100%">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSrNo" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrTitle" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Title")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrType" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "TranscriptType")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrModuleName" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "ModulName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAction" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "TranscriptID")%>'
                                                                                CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" /></asp:LinkButton>
                                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "TranscriptID")%>'
                                                                                CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFound" Text="Data Not Found" runat="server"></asp:Label>
                                                                        </b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <asp:Button ID="btnButtomAdd" OnClick="btnTopAdd_Click" runat="server" Style="float: right;" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vTranscriptAdd" runat="server">
                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td style="width: 130px;" class="isrequire">
                                                        <asp:Literal ID="litTitle" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtTitle" Style="float: left;"></asp:TextBox>
                                                        <span class="input-notification error png_bg" id="spnTitle" style="display: none;">
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="litTranscriptType" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlTranscriptType" Style="float: left;">
                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                            <asp:ListItem Text="SOP" Value="SOP"></asp:ListItem>
                                                            <asp:ListItem Text="Transcript" Value="Transcript"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <span class="input-notification error png_bg" id="spnType" style="display: none;">
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="litModuleName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <%--<asp:TextBox runat="server" ID="txtModuleName" Style="float: left;"></asp:TextBox>--%>
                                                        <asp:DropDownList runat="server" ID="ddlModuleName" Style="float: left;">
                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                            <asp:ListItem Text="Front Desk" Value="Front Desk"></asp:ListItem>
                                                            <asp:ListItem Text="POS" Value="POS"></asp:ListItem>
                                                            <asp:ListItem Text="House Keeping" Value="House Keeping"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <span class="input-notification error png_bg" id="Span1" style="display: none;">
                                                        </span><span class="input-notification error png_bg" id="spnModule" style="display: none;">
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top;">
                                                        <asp:Literal ID="litContent" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <CKEditor:CKEditorControl ID="ckDetail" runat="server">
                                                        </CKEditor:CKEditorControl>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="float: right; width: auto; display: inline-block;">
                                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" ImageUrl="~/images/cancle.png"
                                                                Style="float: right; margin-left: 5px;" OnClick="btnCancel_OnClick" />
                                                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" OnClientClick="return validation();"
                                                                ImageUrl="~/images/save.png" Style="float: right; margin-left: 5px;" />
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
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
