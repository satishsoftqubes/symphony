<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAutoNo.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlAutoNo" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updAutoNo" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="left" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="ltrMainHeader" runat="server"></asp:Literal>
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
                                <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td>
                                            <%if ((IsMessage))
                                              { %>
                                            <div class="message finalsuccess">
                                                <p>
                                                    <strong>
                                                        <asp:Label ID="lblErrorMsg" runat="server"></asp:Label></strong>
                                                </p>
                                            </div>
                                            <%
                                                }%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="box_head">
                                                <span>
                                                    <asp:Literal ID="ltrStatutoryList" runat="server" Text="List"></asp:Literal></span></div>
                                            <div class="clear">
                                            </div>
                                            <div class="box_content">
                                                <asp:GridView ID="gvAutolNo" runat="server" AutoGenerateColumns="false" Width="100%"
                                                    ShowHeader="true" DataKeyNames="ControlNumberID,IdentifyName" OnRowDataBound="gvAutolNo_RowDataBound">
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
                                                                <asp:Literal ID="ltrItemHeader" Text="Identify Name" runat="server"></asp:Literal>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "IdentifyName")%>&nbsp;&nbsp;
                                                                <asp:Label ID="lblErrorMessage" runat="server" Style="color: Red;"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Literal ID="ltrPrefixHeader" Text="Prefix" runat="server"></asp:Literal>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtPreFix" Style="width: 100px;" Text='<%#DataBinder.Eval(Container.DataItem, "Prefix")%>'
                                                                    runat="server" MaxLength="5"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="175px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Literal ID="ltrControlNoHeader" Text="Control No" runat="server"></asp:Literal>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtControlNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ControlNumbers")%>'
                                                                    Style="width: 125px;" MaxLength="5"></asp:TextBox>
                                                                <asp:HiddenField ID="hdnControlNo" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "ControlNumbers")%>' />
                                                                <asp:RequiredFieldValidator ID="rvfControlNo" runat="server" ControlToValidate="txtControlNo"
                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Literal ID="ltrpostFixHeader" Text="Postfix" runat="server"></asp:Literal>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtPostfix" Text='<%#DataBinder.Eval(Container.DataItem, "Postfix")%>'
                                                                    Style="width: 100px;" runat="server" MaxLength="5"></asp:TextBox>
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
                                    <tr>
                                        <td>
                                            <div style="float: right; width: auto; display: inline-block;">
                                                <asp:Button ID="btnCancel" Text="Cancel" Style="float: right; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click" />
                                                <asp:Button ID="btnSave" Text="Save" Style="float: right; margin-left: 5px;" runat="server"
                                                    ImageUrl="~/images/save.png" CausesValidation="true" OnClick="btnSave_Click"
                                                    ValidationGroup="IsRequire" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updAutoNo" ID="UpdateProgressAutoNo"
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
