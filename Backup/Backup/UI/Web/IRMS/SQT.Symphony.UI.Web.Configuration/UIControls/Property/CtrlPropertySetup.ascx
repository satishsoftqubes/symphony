<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPropertySetup.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Property.CtrlPropertySetup" %>
<%@ Register Src="../CommonControls/CtrlAddress.ascx" TagName="CtrlAddress" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<script type="text/javascript">
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("IsRequire")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgressProperty.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
        else {
            return false;
        }
    }
</script>
<asp:UpdatePanel ID="updtCompanyInfo" runat="server">
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
                                <asp:Literal ID="ltrMainHeader" runat="server"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                            </td>
                            <td>
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td colspan="4">
                                                <% if (IsInsert)
                                                   { %>
                                                <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Literal ID="litSuccessfully" runat="server"></asp:Literal></strong>
                                                    </p>
                                                </div>
                                                <% }%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div style="float: right; padding-bottom: 5px;">
                                                    <b>
                                                        <asp:Literal ID="litGeneralMandartoryFiledMessage" runat="server"></asp:Literal>
                                                    </b>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="trLicenceNumber" runat="server" visible="false">
                                            <td>
                                                <asp:Literal ID="ltrLicenceNumber" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblLicenceNumber" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="ltrPropertyName" runat="server"></asp:Literal>
                                            </td>
                                            <td style="width: 295px;">
                                                <asp:TextBox ID="txtPropertyName" runat="server" MaxLength="60"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfPropertyName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        Display="Dynamic" runat="server" ValidationGroup="IsRequire" ControlToValidate="txtPropertyName"></asp:RequiredFieldValidator></span>
                                            </td>
                                            <td class="isrequire">
                                                <asp:Literal ID="ltrPropertyCode" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPropertyCode" runat="server" MaxLength="7"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvPropertyCode" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        Display="Dynamic" runat="server" ValidationGroup="IsRequire" ControlToValidate="txtPropertyCode"></asp:RequiredFieldValidator></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="ltrPropertyType" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlPropertyType" runat="server">
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvPropertyType" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        Display="Dynamic" runat="server" ValidationGroup="IsRequire" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        ControlToValidate="ddlPropertyType"></asp:RequiredFieldValidator></span>
                                            </td>
                                            <th align="left">
                                                <asp:Literal ID="ltrSBAreaResidential" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtSBAreaResidential" runat="server" MaxLength="18" Style="text-align: right;"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="filtxtSBAreaResidential" runat="server" TargetControlID="txtSBAreaResidential"
                                                    FilterType="Custom, Numbers" ValidChars="." />
                                                <div>
                                                    <asp:RegularExpressionValidator Display="Dynamic" ID="regSBAreaResidential" runat="server"
                                                        ForeColor="Red" ControlToValidate="txtSBAreaResidential" SetFocusOnError="true"
                                                        ValidationGroup="IsRequire">
                                                    </asp:RegularExpressionValidator>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="ltrSBAreaCommercial" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtSbAreaCommercial" runat="server" MaxLength="18" Style="text-align: right;"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="ftSbAreaCommercial" runat="server" TargetControlID="txtSbAreaCommercial"
                                                    FilterType="Custom, Numbers" ValidChars="." />
                                                <div>
                                                    <asp:RegularExpressionValidator Display="Dynamic" ID="regSBAreaCommercial" runat="server"
                                                        ForeColor="Red" ControlToValidate="txtSBAreaCommercial" SetFocusOnError="true"
                                                        ValidationGroup="IsRequire">
                                                    </asp:RegularExpressionValidator>
                                                </div>
                                            </td>
                                            <td class="isrequire">
                                                <asp:Literal ID="ltrTotalBuiltUpArea" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalBuiltUpArea" runat="server" MaxLength="18" Style="text-align: right;"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="filtxtTotalBuiltUpArea" runat="server" TargetControlID="txtTotalBuiltUpArea"
                                                    FilterType="Custom, Numbers" ValidChars="." />
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvTotalBuiltUpArea" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        Display="Dynamic" runat="server" ValidationGroup="IsRequire" ControlToValidate="txtTotalBuiltUpArea"></asp:RequiredFieldValidator></span>
                                                <div>
                                                    <asp:RegularExpressionValidator Display="Dynamic" ID="regTotalBuiltUpArea" runat="server"
                                                        ForeColor="Red" ControlToValidate="txtTotalBuiltUpArea" SetFocusOnError="true"
                                                        ValidationGroup="IsRequire">
                                                    </asp:RegularExpressionValidator>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <h1>
                                                    <asp:Literal ID="ltrHeaderContactInformation" runat="server"></asp:Literal></h1>
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="ltrContactName" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtContactName" runat="server" MaxLength="150"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvContactName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        Display="Dynamic" runat="server" ValidationGroup="IsRequire" ControlToValidate="txtContactName"></asp:RequiredFieldValidator></span>
                                            </td>
                                            <td id="tdContactNo" runat="server">
                                                <asp:Literal ID="ltrContactNumber" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtContactNo" runat="server" MaxLength="15"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="ftContactNo" runat="server" TargetControlID="txtContactNo"
                                                    FilterType="Numbers" />
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rfvtxtContactNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        Display="Dynamic" runat="server" ValidationGroup="IsRequire" ControlToValidate="txtContactNo"></asp:RequiredFieldValidator></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="ltrEmail" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtContactEmail" runat="server" MaxLength="150"></asp:TextBox>
                                                <span>
                                                    <asp:RegularExpressionValidator ID="regEmailAd" ValidationGroup="IsRequire" runat="server"
                                                        Display="Dynamic" CssClass="input-notification error png_bg" ControlToValidate="txtContactEmail"
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="rfvContactEmail" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        Display="Dynamic" runat="server" ValidationGroup="IsRequire" ControlToValidate="txtContactEmail"></asp:RequiredFieldValidator></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <h1>
                                                    <asp:Literal ID="ltrHeaderAddress" runat="server"></asp:Literal></h1>
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <uc1:CtrlAddress ID="ucAddress" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litStatutoryList" runat="server"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvDocumentList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                        Width="100%" OnRowCommand="gvDocumentList_RowCommand" OnRowDataBound="gvDocumentList_RowDataBound"
                                                        DataKeyNames="TermID" SkinID="gvNoPaging">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="litGvHrdDocumentName" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "DisplayTerm")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="litGvHrdNumber" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtStatutoryName" SkinID="Search" Style="width: 100px !important;"
                                                                        runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Notes")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="135px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="litGvHrdFile" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <span class="erroraleart">
                                                                        <asp:RegularExpressionValidator ID="rfvDocument" runat="server" ControlToValidate="fuDocument"
                                                                            SetFocusOnError="true" ValidationGroup="Configuration" Display="Dynamic" CssClass="input-notification error png_bg"
                                                                            ValidationExpression="^.+(.pdf|.PDF|.doc|.jpg|.jpeg|.gif|.png|.bmp|.JPG|.JPEG|.GIF|.PNG|.BMP|.TIF|.tif|.DOC|.docx|.DOCX|xlsx|XLSX)$"></asp:RegularExpressionValidator>
                                                                    </span>
                                                                    <div id='browse_file_grid'>
                                                                        <asp:FileUpload ID="fuDocument" runat="server" Height="22px" size="4" Style="float: left;
                                                                            width: 100px;" />
                                                                    </div>
                                                                    <asp:HiddenField ID="hdnDocumentName" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "DocumentName")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="lblGvHdrActions" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <a id="aDocumentLink" runat="server" visible="false" target="_blank">
                                                                        <asp:Image ID="imgView" runat="server" Style="float: left;" ImageUrl="~/images/docviewer.png" /></a>
                                                                    <asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"DocumentID") %>'
                                                                        CommandName="DELETEDATA" runat="server" ImageUrl="~/images/DeleteFile.png" Style="float: right;
                                                                        width: 19px; margin-left: 3px; border: 0px;" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div style="padding: 10px;">
                                                                <b>
                                                                    <asp:Label ID="lblDocumentNoRecordFound" runat="server"></asp:Label>
                                                                </b>
                                                            </div>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div style="float: right; width: auto; display: inline-block;">
                                                    <asp:Button ID="btnCancel" Style="float: right; margin-left: 5px;" runat="server"
                                                        ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click" />
                                                    <asp:Button ID="btnSave" Style="float: right; margin-left: 5px;" runat="server" ImageUrl="~/images/save.png"
                                                        ValidationGroup="IsRequire" CausesValidation="true" OnClick="btnSave_Click" OnClientClick="postbackButtonClick();" />
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
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSave" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updtCompanyInfo" ID="UpdateProgressProperty"
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
