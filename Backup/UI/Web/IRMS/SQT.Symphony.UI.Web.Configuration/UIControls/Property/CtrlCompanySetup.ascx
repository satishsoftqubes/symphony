<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCompanySetup.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Property.CtrlCompanySetup" %>
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
            updateProgress = $find("<%= upgrCompanyInfo.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
        else {
            return false;
        }
    }

    function Copyaddress(chk) {
        var obj = chk;
        if (obj.checked == true) {
            document.getElementById('ContentPlaceHolder1_CtrlCompanySetupstup_ucOfficeAddress_txtAddress').value = document.getElementById('ContentPlaceHolder1_CtrlCompanySetupstup_ucRegisteredAddress_txtAddress').value;
            document.getElementById('ContentPlaceHolder1_CtrlCompanySetupstup_ucOfficeAddress_txtCity').value = document.getElementById('ContentPlaceHolder1_CtrlCompanySetupstup_ucRegisteredAddress_txtCity').value;
            document.getElementById('ContentPlaceHolder1_CtrlCompanySetupstup_ucOfficeAddress_txtState').value = document.getElementById('ContentPlaceHolder1_CtrlCompanySetupstup_ucRegisteredAddress_txtState').value;
            document.getElementById('ContentPlaceHolder1_CtrlCompanySetupstup_ucOfficeAddress_txtCountry').value = document.getElementById('ContentPlaceHolder1_CtrlCompanySetupstup_ucRegisteredAddress_txtCountry').value;
            document.getElementById('ContentPlaceHolder1_CtrlCompanySetupstup_ucOfficeAddress_txtZipCode').value = document.getElementById('ContentPlaceHolder1_CtrlCompanySetupstup_ucRegisteredAddress_txtZipCode').value;
        }
        else {
            document.getElementById('ContentPlaceHolder1_CtrlCompanySetupstup_ucOfficeAddress_txtAddress').value = "";
            document.getElementById('ContentPlaceHolder1_CtrlCompanySetupstup_ucOfficeAddress_txtCity').value = "";
            document.getElementById('ContentPlaceHolder1_CtrlCompanySetupstup_ucOfficeAddress_txtState').value = "";
            document.getElementById('ContentPlaceHolder1_CtrlCompanySetupstup_ucOfficeAddress_txtCountry').value = "";
            document.getElementById('ContentPlaceHolder1_CtrlCompanySetupstup_ucOfficeAddress_txtZipCode').value = "";
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
                                                <% if (IsMessage)
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
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="ltrCompanyName" runat="server"></asp:Literal>
                                            </td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtCompanyName" runat="server" MaxLength="320" SkinID="nowidth"
                                                    Width="666px"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfCompanyName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCompanyName">
                                                    </asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="ltrDisplayName" runat="server"></asp:Literal>
                                            </td>
                                            <td style="width: 295px;">
                                                <asp:TextBox ID="txtDisplayName" runat="server" MaxLength="120"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfDisplayName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtDisplayName"></asp:RequiredFieldValidator></span>
                                            </td>
                                            <td style="width: 130px;" class="isrequire">
                                                <asp:Literal ID="ltrCompanyCode" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCompanyCode" runat="server" MaxLength="50"></asp:TextBox>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfCompanyCode" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCompanyCode"></asp:RequiredFieldValidator></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="isrequire">
                                                <asp:Literal ID="ltrCompanyType" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlTypeOfCompany" runat="server">
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        ControlToValidate="ddlTypeOfCompany"></asp:RequiredFieldValidator></span>
                                            </td>
                                            <td class="isrequire">
                                                <asp:Literal ID="ltrBusinessDomain" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlBusinessDomain" runat="server">
                                                </asp:DropDownList>
                                                <span>
                                                    <asp:RequiredFieldValidator ID="rvfBusinessDomain" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" ValidationGroup="IsRequire" InitialValue="00000000-0000-0000-0000-000000000000"
                                                        ControlToValidate="ddlBusinessDomain"></asp:RequiredFieldValidator></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="ltrContactNo" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtPhoneNo" runat="server" MaxLength="17"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="fltPhoneNo" runat="server" TargetControlID="txtPhoneNo"
                                                    FilterType="Numbers" />
                                            </td>
                                            <td class="isrequire">
                                                <asp:Literal ID="ltrEmail" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmail" runat="server" MaxLength="180"></asp:TextBox>
                                                <span>
                                                    <asp:RegularExpressionValidator ID="regEmailAd" Display="Dynamic" ValidationGroup="IsRequire"
                                                        runat="server" CssClass="input-notification error png_bg" ControlToValidate="txtEmail"
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="rfvEmail" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                        runat="server" Display="Dynamic" ValidationGroup="IsRequire" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left">
                                                <asp:Literal ID="ltrFax" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtFax" runat="server" MaxLength="17"></asp:TextBox>
                                                <ajx:FilteredTextBoxExtender ID="fltFax" runat="server" TargetControlID="txtFax"
                                                    FilterType="Numbers" />
                                            </td>
                                            <th align="left">
                                                <asp:Literal ID="ltrURL" runat="server"></asp:Literal>
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtURL" runat="server" MaxLength="180"></asp:TextBox>
                                                <span>
                                                    <asp:RegularExpressionValidator ID="rgvtxtURL" ValidationGroup="IsRequire" runat="server"
                                                        CssClass="input-notification error png_bg" ControlToValidate="txtURL" ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <h1>
                                                    <asp:Literal ID="litHeaderBillingDetails" runat="server"></asp:Literal>
                                                </h1>
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 295px;">
                                                <asp:Literal ID="litCreditlimit" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCreditLimit" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Literal ID="litBillSettlementDays" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBillSettlementDays" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litBillingFrequencyDays" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBillingFrequencyDays" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border-bottom: 1px solid #aca899;" colspan="4">
                                                <div style="padding-bottom: 5px;">
                                                    <h1>
                                                        <asp:Literal ID="ltrHeaderAddressInfo" runat="server"></asp:Literal>
                                                    </h1>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                            </td>
                                            <td colspan="2" class="checkbox_new" style="padding: 0px;">
                                                <asp:CheckBox ID="chkAsPermanenetAddress" runat="server" onclick="Copyaddress(this);" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <uc1:CtrlAddress ID="ucRegisteredAddress" runat="server" />
                                            </td>
                                            <td colspan="2">
                                                <uc1:CtrlAddress ID="ucOfficeAddress" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <h1>
                                                    <asp:Literal ID="ltrHeaderStatutoryRegistration" runat="server"></asp:Literal>
                                                </h1>
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="ltrStatutoryList" runat="server"></asp:Literal></span></div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvDocument" runat="server" AutoGenerateColumns="false" SkinID="gvNoPaging"
                                                        Width="100%" DataKeyNames="TermID" ShowHeader="true" OnRowDataBound="gvDocument_RowDataBound"
                                                        OnRowCommand="gvDocument_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrDocumentName" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDocumentName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DisplayTerm")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="150" HeaderStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrNumber" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtStatutoryName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Notes")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="150">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrFile" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <div id='browse_file_grid'>
                                                                        <asp:FileUpload ID="fuDocument" runat="server" />
                                                                    </div>
                                                                    <%-- <a id="aDocumentLink" runat="server" target="_blank" style="float: right; padding-top: 5px;">
                                                                        <asp:Image ID="imgView" runat="server" ImageUrl="~/images/file.png" /></a>--%>
                                                                    <asp:HiddenField ID="hdnDocumentName" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "DocumentName")%>' />
                                                                    <asp:RegularExpressionValidator ID="rfvDocument" runat="server" ControlToValidate="fuDocument"
                                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"
                                                                        Display="Dynamic" ValidationExpression="^.+(.pdf|.PDF|.doc|.DOC|.docx|.DOCX|xls|XLS|xlsx|XLSX|.jpg|.jpeg|.gif|.png|.bmp|.JPG|.JPEG|.GIF|.PNG|.BMP)$"></asp:RegularExpressionValidator>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                ItemStyle-VerticalAlign="Middle">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrAction" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <a id="aDocumentLink" runat="server" visible="false" target="_blank">
                                                                        <asp:Image ID="imgView" ToolTip="View" runat="server" ImageUrl="~/images/docviewer.png"
                                                                            Style="float: left; width: 19px;" /></a>
                                                                    <asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"DocumentID") %>'
                                                                        CommandName="DELETEDATA" runat="server" ImageUrl="~/images/DeleteFile.png" Style="float: right;
                                                                        width: 19px; margin-left: 3px; border: 0px;" OnClientClick="fnDisplayCatchErrorMessage()" />
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
                                            <td colspan="4">
                                                <h1>
                                                    <asp:Literal ID="ltrHeaderCompanyLogo" runat="server"></asp:Literal></h1>
                                                <hr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th align="left" style="vertical-align: top !important;">
                                                <span>
                                                    <asp:RegularExpressionValidator ID="rfvDocument" runat="server" ControlToValidate="fuCompanyLogo"
                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"
                                                        Display="Dynamic" ValidationExpression="^.+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|gif|GIF|.bmp|.BMP)$"></asp:RegularExpressionValidator>
                                                </span>
                                                <asp:Literal ID="ltrSelectLogo" runat="server"></asp:Literal>
                                            </th>
                                            <td style="vertical-align: top !important;">
                                                <div id='browse_file_grid'>
                                                    <asp:FileUpload ID="fuCompanyLogo" runat="server" />
                                                </div>
                                            </td>
                                            <td align="left" colspan="2">
                                                <asp:Image runat="server" Width="200px" ID="imgCompany" ImageUrl="~/images/BlankPhoto.jpg" />
                                                <div style="padding-left: 80px; padding-top: 5px;">
                                                    <b>
                                                        <asp:LinkButton ID="lnkRemoveLogo" runat="server" Visible="false" OnClick="lnkRemoveLogo_OnClick"></asp:LinkButton></b>
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
                    <%--<div class="clear">
                        <uc1:MsgBox ID="MessageBox" runat="server" />
                    </div>--%>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hfPopupCustomeMessage" runat="server" />
        <ajx:ModalPopupExtender ID="mpeCustomePopup" runat="server" TargetControlID="hfPopupCustomeMessage"
            PopupControlID="pnlCustomeMessage" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlCustomeMessage" runat="server" Width="350px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHeaderCustomePopupMessage" runat="server" Text="Message"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px; color: Red;">
                                <asp:Literal ID="litCustomePopupMsg" runat="server" Text="You have changed your email of company, it will be user name of company admin login."></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnOKCustomeMsgPopup" runat="server" Text="OK" Style="display: inline;
                                    padding-right: 10px;" OnClick="btnOKCustomeMsgPopup_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSave" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updtCompanyInfo" ID="upgrCompanyInfo"
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
