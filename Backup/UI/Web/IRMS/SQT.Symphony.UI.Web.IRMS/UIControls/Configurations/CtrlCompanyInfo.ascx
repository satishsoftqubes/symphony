<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCompanyInfo.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Configurations.CtrlCompanyInfo" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>

<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=txtCountryName.ClientID%>").autocomplete('AutoComplete.ashx');
        $("#<%=txtStateName.ClientID%>").autocomplete('StateAutoComplete.ashx');
        $("#<%=txtCityName.ClientID%>").autocomplete('CityAutoComplete.ashx');
        $("#<%=txtAdminCountry.ClientID%>").autocomplete('AutoComplete.ashx');
        $("#<%=txtAdminState.ClientID%>").autocomplete('StateAutoComplete.ashx');
        $("#<%=txtAdminCity.ClientID%>").autocomplete('CityAutoComplete.ashx');
    });

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>

<script type="text/javascript">
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("Configuration")) {

            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgressCompany.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
        else {
            return false;
        }
    }
    </script>

<style type="text/css">
    #progressBackgroundFilter
    {
        position: fixed;
        top: 0px;
        width:100%;
        height:100%;
        bottom: 0px;
        left: 0px;
        right: 0px;
        overflow: hidden;
        padding: 0;
        margin: 0;
        background-color: #000;
        filter: alpha(opacity=50);
        opacity: 0.5;
        z-index: 1000;
    }
    #processMessage
    {
        position: fixed;
        top: 50%;
        left: 50%;
        padding: 10px;
        width: 30px;
        border-radius:10px;
        z-index: 1001;
        background-color:#fff;
        border: solid 1px #efefef;
    }
</style>
<asp:UpdatePanel ID="updtCompanyInfo" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                COMPANY SETUP
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
                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                    <tr>
                                        <td colspan="4">
                                            <div style="height: 26px;">
                                                <%if (IsInsert)
                                                  { %>
                                                <div class="ResetSuccessfully">
                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                        <img src="../../images/success.png" /></div>
                                                    <div>
                                                        <asp:Label ID="lblInsert" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <%}%>
                                                <%if (IsUpdate)
                                                  { %>
                                                <div class="ResetSuccessfully">
                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                        <img src="../../images/success.png" /></div>
                                                    <div>
                                                        <asp:Label ID="lblUpdate" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <%}%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <div style="float:right;">
                                                <b>All Bold Fields are Mandatory</b>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 125px;">
                                            <asp:Label ID="litCompanyName" runat="server" Text="Company Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfCompanyName" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtCompanyName"
                                                    ErrorMessage="*">
                                                </asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td width="270px">
                                            <asp:TextBox ID="txtCompanyName" runat="server" SkinID="CmpTextbox" MaxLength="320"></asp:TextBox>
                                        </td>
                                        <td style="width: 125px">
                                            <asp:Label ID="litCompanyCode" runat="server" Text="Company Code" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfCompanyCode" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtCompanyCode"
                                                    ErrorMessage="*"></asp:RequiredFieldValidator></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCompanyCode" runat="server" SkinID="CmpTextbox" MaxLength="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litDisplayName" runat="server" Text="Display Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfDisplayName" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtDisplayName"
                                                    ErrorMessage="*"></asp:RequiredFieldValidator></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDisplayName" runat="server" SkinID="CmpTextbox" MaxLength="120"></asp:TextBox>
                                        </td>
                                        <td>
                                            Company Type
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTypeOfCompany" Style="width: 202px;" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td>
                                            <asp:Label ID="litBusinessDomain" runat="server" Text="Business Domain" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfBusinessDomain" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="ddlBusinessDomain"
                                                    InitialValue="00000000-0000-0000-0000-000000000000" ErrorMessage="*"></asp:RequiredFieldValidator></span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBusinessDomain" Style="width: 202px;" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="litPhone" runat="server" Text="Contact No" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfContactNo" SetFocusOnError="true" ControlToValidate="txtPhoneNo"
                                                    ValidationGroup="Configuration" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPhoneNo" runat="server" MaxLength="17" SkinID="CmpTextbox"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="fltPhoneNo" runat="server" TargetControlID="txtPhoneNo"
                                                FilterMode="ValidChars" ValidChars="1234567890+-" />
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td>
                                            <asp:Label ID="litEmail" runat="server" Text="Email" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfEmail" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtEmail"
                                                    ValidationGroup="Configuration" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="regEmailAd" Display="Dynamic" ValidationGroup="Configuration" runat="server"
                                                    CssClass="rfv_ErrorStar" ControlToValidate="txtEmail" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmail" runat="server" SkinID="CmpTextbox" MaxLength="180"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litFax" runat="server" Text="Fax"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFax" runat="server" MaxLength="17" SkinID="CmpTextbox"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="fltFax" runat="server" TargetControlID="txtFax"
                                                FilterMode="ValidChars" ValidChars="1234567890+-" />
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td>
                                            <asp:Label ID="litURL" runat="server" Text="URL" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfURL" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtURL"
                                                    ValidationGroup="Configuration" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="rgvtxtURL" Display="Dynamic" ValidationGroup="Configuration" runat="server"
                                                    CssClass="rfv_ErrorStar" ControlToValidate="txtURL" ErrorMessage="*" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator></span>
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtURL" runat="server" SkinID="CmpTextbox" MaxLength="180"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" class="pagesubheader">
                                            <asp:Literal ID="Literal4" runat="server" Text="Address"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litAddressLine1" runat="server" Text="Registered Office" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfAddressLine1" SetFocusOnError="true" ControlToValidate="txtAddressLine1"
                                                    ValidationGroup="Configuration" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddressLine1" runat="server" TextMode="MultiLine" Height="60px"
                                                SkinID="CmpTextbox" MaxLength="280"></asp:TextBox>
                                        </td>
                                        <td style="width: 146px">
                                            <asp:Literal ID="litAddressLine2" runat="server" Text="Admin Office"></asp:Literal>
                                        </td>
                                        <td align="right">
                                            <asp:TextBox ID="txtAddressLine2" runat="server" TextMode="MultiLine" Height="60px"
                                                SkinID="CmpTextbox" MaxLength="280"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litCity" runat="server" Text="City" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfCity" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtCityName"
                                                    ErrorMessage="*"></asp:RequiredFieldValidator></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCityName" runat="server" SkinID="CmpTextbox" MaxLength="78"></asp:TextBox>
                                        </td>
                                        <td style="width: 146px">
                                            <asp:Literal ID="Literal2" runat="server" Text="City"></asp:Literal>
                                        </td>
                                        <td align="right">
                                            <asp:TextBox ID="txtAdminCity" runat="server" SkinID="CmpTextbox" MaxLength="120"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litPostCode" runat="server" Text="ZipCode"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPostCode" runat="server" MaxLength="13" SkinID="CmpTextbox"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPostCode" FilterMode="ValidChars" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"></ajx:FilteredTextBoxExtender>
                                        </td>
                                        <td style="width: 146px">
                                            <asp:Literal ID="Literal5" runat="server" Text="ZipCode"></asp:Literal>
                                        </td>
                                        <td align="right">
                                            <asp:TextBox ID="txtAdminPostCode" runat="server" MaxLength="13" SkinID="CmpTextbox"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtAdminPostCode" FilterMode="ValidChars" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"></ajx:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litState" runat="server" Text="State" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfState" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtStateName"
                                                    ErrorMessage="*"></asp:RequiredFieldValidator></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStateName" runat="server" SkinID="CmpTextbox" MaxLength="120"></asp:TextBox>
                                        </td>
                                        <td style="width: 146px">
                                            <asp:Literal ID="Literal6" runat="server" Text="State"></asp:Literal>
                                        </td>
                                        <td align="right">
                                            <asp:TextBox ID="txtAdminState" SkinID="CmpTextbox" runat="server" MaxLength="120"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litCountry" runat="server" Text="Country" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfCountry" SetFocusOnError="true" ControlToValidate="txtCountryName"
                                                    ValidationGroup="Configuration" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCountryName" runat="server" SkinID="CmpTextbox" MaxLength="120"></asp:TextBox>
                                        </td>
                                        <td style="width: 125px">
                                            <asp:Literal ID="Literal7" runat="server" Text="Country"></asp:Literal>
                                        </td>
                                        <td align="right">
                                            <asp:TextBox ID="txtAdminCountry" runat="server" SkinID="CmpTextbox" MaxLength="120"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" class="pagesubheader">
                                            <asp:Literal ID="Literal1" runat="server" Text="Statutory Registration"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" class="dTableBox1">
                                            <div class="leftmarginbox_content">
                                                <style type="text/css">
                                                    .dTableBox1 td
                                                    {
                                                        border-color: #EFEFEF;
                                                    }
                                                </style>
                                                <asp:GridView ID="gvDocument" runat="server" AutoGenerateColumns="false" SkinID="gvNoPaging"
                                                    OnRowDataBound="gvDocument_RowDataBound" DataKeyNames="TermID" 
                                                    ShowHeader="true" onrowcommand="gvDocument_RowCommand">
                                                    <Columns>
                                                        <asp:BoundField DataField="DisplayTerm" HeaderText="Document Name"
                                                            HeaderStyle-HorizontalAlign="Left" />
                                                        <asp:TemplateField ItemStyle-Width="150px" HeaderText="Number" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtStatutoryName" Style="width: 150px;" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Notes")%>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="105px" HeaderText="File" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <div id='browse_file_grid'>
                                                                <asp:FileUpload ID="fuDocument" ToolTip=".pdf|.PDF|.doc|.jpg|.jpeg|.gif|.png|.bmp|.JPG|.JPEG|.GIF|.PNG|.BMP|.TIF|.tif|.DOC|.docx|.DOCX|xlsx|XLSX" runat="server" Height="22px" size="4" Style="float: left;" />
                                                                </div>
                                                                <asp:HiddenField ID="hdnDocumentName" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "DocumentName")%>' />
                                                                <asp:RegularExpressionValidator ID="rfvDocument" runat="server" ControlToValidate="fuDocument"
                                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ValidationGroup="Configuration"
                                                                    Display="Dynamic" ErrorMessage="*" ValidationExpression="^.+(.pdf|.jpg|.jpeg|.gif|.png|.bmp|.JPG|.JPEG|.GIF|.PNG|.BMP|.TIF|.tif|.PDF|.doc|.DOC|.docx|.DOCX|xlsx|XLSX)$"></asp:RegularExpressionValidator>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderText="View" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <a id="aDocumentLink" runat="server" visible="false" target="_blank">
                                                                    <asp:Image ID="imgView" ToolTip="View" runat="server" ImageUrl="~/images/View.png" style="float:left; width:19px;"/></a>
                                                                <asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"DocumentID") %>' CommandName="DELETEDATA" runat="server" ImageUrl="~/images/DeleteFile.png" style="float:right;width:19px;margin-left:3px;border:0px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" class="pagesubheader">
                                            <asp:Literal ID="LitPhotoInfo" runat="server" Text="Image / Company Logo"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="Literal3" runat="server" Text="Select Logo"></asp:Literal>
                                            <span class="erroraleart">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="UplodFile"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ValidationGroup="Configuration"
                                                    Display="Dynamic" ErrorMessage="*" ValidationExpression="^.+(.jpg|JPG|.gif|.GIF|.png|.PNG)$"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <div id="browse_file_grid">
                                            <asp:FileUpload ID="UplodFile" runat="server" Height="25px" /></div>
                                        </td>
                                        <td align="left" valign="top" colspan="2">
                                            <asp:Image runat="server" Width="200px" ID="imgCompany" /><br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top" colspan="4" style="padding-left: 280px;">
                                            <b>
                                                <asp:LinkButton ID="HypRemove" runat="server" Text="Remove" Style="padding-right: 45px;"
                                                    OnClick="HypRemove_Click"></asp:LinkButton></b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="text-align:right;">
                                            <div style="float: right; width: auto; display: inline-block;">
                                                <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;" runat="server"
                                                    ImageUrl="~/images/save.png" ValidationGroup="Configuration" CausesValidation="true"
                                                    OnClick="btnSave_Click" OnClientClick="return postbackButtonClick();" />
                                                <asp:Button ID="btnCancel" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
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
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSave" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updtCompanyInfo" ID="UpdateProgressCompany"
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