<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlControlNumber.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Configurations.CtrlControlNumber" %>
<%@ Register Src="~/MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>

<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:473px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                AUTO NUMBER SETUP
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
                                        <td colspan="2">
                                            <div style="height:26px;">
                                                <%if (IsInsert)
                                                    { %>
                                                <div class="ResetSuccessfully">
                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                        <img src="../../images/success.png" />
                                                    </div>
                                                    <div>
                                                        <asp:Label ID="lblErrorMsg" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <%
                                                }%>
                                            </div>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="dTableBox" style="padding: 10px 0px;">
                                            <asp:GridView ID="gvControlNo" runat="server" AutoGenerateColumns="False" SkinID="gvNoPaging"
                                                Width="100%">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Item" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIdentityName" Style="text-transform: uppercase;" runat="server" CssClass="RequireFile"
                                                                Text='<%#DataBinder.Eval(Container.DataItem, "IdentifyName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblControlNumberID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ControlNumberID")%>'></asp:Label>
                                                            <asp:Label ID="lblPropertyID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PropertyID")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Prefix" ItemStyle-Width="95px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtPreFix" runat="server" Style="margin-top: 12px;" MaxLength="5"
                                                                Text='<%#DataBinder.Eval(Container.DataItem, "Prefix")%>' ></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvPostfix" SetFocusOnError="true" ControlToValidate="txtPreFix"
                                                                CssClass="rfv_ErrorStar" ValidationGroup="CmpControlNumber" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Control No" ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtControlNo" runat="server" Style="margin-top: 12px;" MaxLength="5" Width="75%"
                                                                Text='<%#DataBinder.Eval(Container.DataItem, "ControlNumbers")%>'></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvControlNumberName" SetFocusOnError="true" ControlToValidate="txtControlNo"
                                                                CssClass="rfv_ErrorStar" ValidationGroup="CmpControlNumber" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Postfix" ItemStyle-Width="95px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtPostFix" runat="server" Style="margin-top: 12px;" MaxLength="5" Width="75%"
                                                                Text='<%#DataBinder.Eval(Container.DataItem, "Postfix")%>'></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvPrefix" SetFocusOnError="true" ControlToValidate="txtPostFix"
                                                                CssClass="rfv_ErrorStar" ValidationGroup="CmpControlNumber" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <div class="pagecontent_info" id="MsgRecFnd" runat="server">
                                                <div class="NoItemsFound" id="msgNoRecordFound" runat="server">
                                                    <h2>
                                                        <asp:Literal ID="Literal5" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:right;">
                                            <div style="float: right; width: auto; display: inline-block;">
                                                <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;" runat="server"
                                                    ImageUrl="~/images/save.png" ValidationGroup="CmpControlNumber" 
                                                    CausesValidation="true" onclick="btnSave_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:Button ID="btnCancel" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" 
                                                    onclick="btnCancel_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
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
                    <%--<div class="clear">
                        <uc1:MsgBox ID="MessageBox" runat="server" />
                    </div>--%>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>