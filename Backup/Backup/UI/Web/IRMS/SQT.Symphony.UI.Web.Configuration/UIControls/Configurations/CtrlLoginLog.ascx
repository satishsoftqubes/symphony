<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlLoginLog.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlLoginLog" %>
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
<asp:UpdatePanel ID="updLoginLog" runat="server">
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
                                                <asp:Literal ID="litSearchUserName" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:DropDownList ID="ddlSearchUserName" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <th align="left">
                                                <asp:Literal ID="litSearchDate" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtSearchDate" runat="server" onkeydown="return stopKey(event);"></asp:TextBox>
                                                <asp:Image ID="imgCalendarActionLog" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                    Height="20px" Width="20px" />
                                                <ajx:CalendarExtender ID="ajxCalendarLogInLog" PopupButtonID="imgCalendarActionLog"
                                                    TargetControlID="txtSearchDate" runat="server">                                                    
                                                </ajx:CalendarExtender>                                                
                                                <img src="../../images/clear.png" id="imgClearDate" title="<%= strClearDateTooltip %>" style="vertical-align: middle;"
                                                    onclick="fnClearDate('<%= txtSearchDate.ClientID %>');" />
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage();"  />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: -4px 0 0 10px;" OnClick="imgbtnClearSearch_Click" OnClientClick="fnDisplayCatchErrorMessage();"  />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litLoginLogList" runat="server"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvLogInLogList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                        Width="100%" OnPageIndexChanging="gvLogInLogList_PageIndexChanging"
                                                        OnRowDataBound="gvLogInLogList_RowDataBound" SkinID="gvMorePaging">
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
                                                                    <asp:Label ID="lblGvHdrUserName" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>                                                                
                                                                    <%# DataBinder.Eval(Container.DataItem, "UserName") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrLogIn" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "LogIn")).ToString(clsSession.DateFormat + " " + clsSession.TimeFormat)%>                                                                    
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrLogout" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("Logout") == DBNull.Value ? null : Convert.ToDateTime(Eval("Logout")).ToString(clsSession.DateFormat + " " + clsSession.TimeFormat)%>
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
                        <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                    </div>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updLoginLog" ID="UpdateProgressLoginLog"
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
