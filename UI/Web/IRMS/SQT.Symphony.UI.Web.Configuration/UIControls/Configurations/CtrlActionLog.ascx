<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlActionLog.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlActionLog" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script src="../../Javascript/Common.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updActionLog" runat="server">
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
                                            <th align="left">
                                                <asp:Literal ID="litSearchActionDate" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtSearchActionDate" SkinID="searchtextbox" onkeydown="return stopKey(event);"
                                                    runat="server" />
                                                <asp:Image ID="imgCalendarActionLog" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                    Height="20px" Width="20px" />
                                                <ajx:CalendarExtender ID="ajxCalendarActionLog" PopupButtonID="imgCalendarActionLog"
                                                    TargetControlID="txtSearchActionDate" runat="server">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" id="imgClearDate" title="<%= strClearDateTooltip %>"
                                                    style="vertical-align: middle;" onclick="fnClearDate('<%= txtSearchActionDate.ClientID %>');" />
                                            </td>
                                            <th align="left">
                                                <asp:Literal ID="litSearchActionType" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="ddlSearchActionType" runat="server">
                                                    <asp:ListItem Selected="True" Text="-All-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                    <asp:ListItem Text="Save" Value="Save"></asp:ListItem>
                                                    <asp:ListItem Text="Update" Value="Update"></asp:ListItem>
                                                    <asp:ListItem Text="Delete" Value="Delete"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="litSearchUserName" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="ddlSearchUserName" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <th align="left">
                                                <asp:Literal ID="litSearchActionObject" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtSearchActionObject" runat="server"></asp:TextBox>
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; vertical-align: middle; margin: -4px 0 0 5px;" OnClick="btnSearch_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage();" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: -3px 0 0 10px;" OnClick="imgbtnClearSearch_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage();" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litActionLogList" runat="server"></asp:Literal></span></div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvActionLogList" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        ShowHeader="true" SkinID="gvMorePaging" OnRowCommand="gvActionLogList_RowCommand"
                                                        OnRowDataBound="gvActionLogList_RowDataBound" OnPageIndexChanging="gvActionLogList_PageIndexChanging">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrActionType" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvActionType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ActionType")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                ItemStyle-Width="150px">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrActionObject" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvActionObject" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ActionObject")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                ItemStyle-Width="150px">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrActionPerformedOn" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "ActionPerformedOn")).ToString(this.DateFormat)%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrUser" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGvUser" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "UserName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrAction" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#Eval("ActionLogID") + "|" +Eval("ActionObject")%>'
                                                                        CommandName="VIEWDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/actionlog.png" /></asp:LinkButton>
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
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConference"
            PopupControlID="pnlConference" BackgroundCssClass="mod_background" CancelControlID="btnClose">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConference" runat="server" />
        <asp:Panel ID="pnlConference" runat="server" Height="400px" Width="680px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHeaderGvMsg" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="left" style="padding-bottom: 15px;">
                                <div class="clear">
                                </div>
                                <div class="box_content" style="height: 300px; width: 650px; overflow:auto;">
                                    <asp:GridView ID="gvActionLogData" runat="server" AutoGenerateColumns="false" Width="100%"
                                        SkinID="gvNoPaging" ShowHeader="true" OnRowDataBound="gvActionLogData_RowDataBound">
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
                                                    <asp:Label ID="lblGvHdrColumnName" runat="server" ItemStyle-Width="100px"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGvColumnName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ColumnName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrOldValue" runat="server"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGvOldValue" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "OldValue")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblGvHdrNewValue" runat="server" Text="Block Name"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGvNewValue" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "NewValue")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>                                            
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div style="padding: 10px;">
                                                <b>
                                                    <asp:Label ID="lblGvNoRecordFound" runat="server"></asp:Label>
                                                </b>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                   
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnClose" runat="server" Style="display: inline; padding-right: 10px;" />    
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
<asp:UpdateProgress AssociatedUpdatePanelID="updActionLog" ID="UpdateProgressActionLog"
    runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" />
            </center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
