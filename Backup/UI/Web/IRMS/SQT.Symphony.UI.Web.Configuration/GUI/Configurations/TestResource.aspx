<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestResource.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.GUI.Configurations.TestResource" %>

<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link id="Link1" href="~/Style/style.css" runat="server" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updResourceManagement" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:55px; margin-left:25px;">
                <tr>
                    <td class="content">
                        <table width="96%" border="0" cellspacing="0" cellpadding="0">
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
                                    <div class="box_form">
                                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                            <tr>
                                                <td colspan="2">
                                                    <%if (IsMessage)
                                                      { %>
                                                    <div class="message finalsuccess">
                                                        <p>
                                                            <strong>
                                                                <asp:Label ID="lblMessage" runat="server"></asp:Label></strong>
                                                        </p>
                                                    </div>
                                                    <%}%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table>
                                                        <tr>
                                                            <td id="tdlblCompany" runat="server" visible="false">
                                                                <asp:Literal ID="ltrCompany" runat="server" Text="Company"></asp:Literal>
                                                            </td>
                                                            <td id="tdddlCompany" runat="server" visible="false">
                                                                <asp:DropDownList ID="ddlCompany" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCompany_OnSelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <span>
                                                                    <asp:RequiredFieldValidator ID="rfvCompany" runat="server" ControlToValidate="ddlCompany"
                                                                        Enabled="false" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                        ValidationGroup="vgResourceFiles" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                                                </span>
                                                            </td>
                                                            <td id="tdlblProperty" runat="server" visible="false">
                                                                <asp:Literal ID="ltrProperty" runat="server"></asp:Literal>
                                                            </td>
                                                            <td id="tdddlProperty" runat="server" visible="false">
                                                                <asp:DropDownList ID="ddlProperty" runat="server">
                                                                </asp:DropDownList>
                                                                <span>
                                                                    <asp:RequiredFieldValidator ID="rfvProperty" runat="server" ControlToValidate="ddlProperty"
                                                                        Enabled="false" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                        ValidationGroup="vgResourceFiles" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                                                </span>
                                                            </td>
                                                            <td>
                                                                <asp:Literal ID="ltrResourceFile" runat="server"></asp:Literal>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlResourceFile" runat="server">
                                                                </asp:DropDownList>
                                                                <span>
                                                                    <asp:RequiredFieldValidator ID="rfvResourceFile" runat="server" ControlToValidate="ddlResourceFile"
                                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="vgResourceFiles"
                                                                        InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                                                </span>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnGo" runat="server" CausesValidation="true" ValidationGroup="vgResourceFiles"
                                                                    OnClick="btnGo_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <div class="box_head">
                                                        <span>
                                                            <asp:Literal ID="ltrResourceFieldListHeader" runat="server"></asp:Literal></span></div>
                                                    <div class="clear">
                                                    </div>
                                                    <div class="box_content">
                                                        <asp:GridView ID="gvResourceElements" runat="server" AutoGenerateColumns="False"
                                                            Width="100%" OnRowDataBound="gvResourceElements_RowDataBound" SkinID="gvNoPaging">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrSrNo" runat="server"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="25%">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrFieldName" runat="server"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblResourceElementName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "name")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="75%">
                                                                    <HeaderTemplate>
                                                                        <asp:Label ID="lblGvHdrFieldValue" runat="server"></asp:Label>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtValue" runat="server" SkinID="nowidth" Width="350px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfvValue" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                            runat="server" ValidationGroup="IsRequire" ControlToValidate="txtValue"></asp:RequiredFieldValidator>
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
                                                <td colspan="2">
                                                    <div style="float: right; width: auto; display: inline-block;">
                                                        <asp:Button ID="btnCancel" Style="float: right; margin-left: 5px;" runat="server"
                                                            ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_OnClick" />
                                                        <asp:Button ID="btnSave" Style="float: right; margin-left: 5px;" runat="server" ImageUrl="~/images/save.png"
                                                            ValidationGroup="IsRequire" CausesValidation="true" OnClick="btnSave_OnClick" />
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
                            <uc1:MsgBox ID="MessageBox" runat="server" />
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress AssociatedUpdatePanelID="updResourceManagement" ID="UpdateProgressResourceManagement"
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
    </form>
</body>
</html>
