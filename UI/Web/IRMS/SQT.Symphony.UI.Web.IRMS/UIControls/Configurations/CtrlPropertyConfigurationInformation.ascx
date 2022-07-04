<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPropertyConfigurationInformation.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Configurations.CtrlPropertyConfigurationInformation" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function pageLoad(sender, args) {
        $(document).ready(function () {
            $("#<%=txtCountryName.ClientID%>").autocomplete('AutoComplete.ashx');
            $("#<%=txtStateName.ClientID%>").autocomplete('StateAutoComplete.ashx');
            $("#<%=txtCityName.ClientID%>").autocomplete('CityAutoComplete.ashx');

            $("#<%=txtSPropertyName.ClientID%>").autocomplete('PropertyAutoComplete.ashx');
        });
    }
</script>

<script type="text/javascript">
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("Configuration")) {
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

<style type="text/css">
    #progressBackgroundFilter
    {
        position: fixed;
        top: 0px;
        width: 100%;
        height: 100%;
        bottom: 0px;
        left: 0px;
        right: 0px;
        overflow: hidden;
        padding: 0;
        margin: 0;
        background-color: #000;
        filter: alpha(opacity=50);
        opacity: 0.5;
        z-index: 1111111;
    }
    #processMessage
    {
        position: fixed;
        top: 50%;
        left: 50%;
        padding: 10px;
        width: 30px;
        border-radius: 10px;
        z-index: 1111112;
        background-color: #fff;
        border: solid 1px #efefef;
    }
</style>
<asp:UpdatePanel ID="updProperty" runat="server">
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
                                PROPERTY SETUP
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
                                <table cellpadding="3" cellspacing="3" border="0" width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <div style="height: 26px;">
                                                <%if (IsMessage)
                                                  { %>
                                                <div class="ResetSuccessfully">
                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                        <img src="../../images/success.png" /></div>
                                                    <div>
                                                        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <%}%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div style="float: right;">
                                                <b>All Bold Fields are Mandatory</b>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 160px">
                                            <asp:Label ID="litPropertyName" runat="server" Text="Property Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfCompanyCode" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtPropertyName"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPropertyName" runat="server" SkinID="CmpTextbox" MaxLength="65"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litPropertyCode" runat="server" Text="Property Code" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfDisplayName" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtPropertyCode"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPropertyCode" SkinID="CmpTextbox" runat="server" MaxLength="7"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litPropertyTypeName" runat="server" Text="Property Type" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfCompanyName" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    InitialValue="00000000-0000-0000-0000-000000000000" runat="server" ValidationGroup="Configuration"
                                                    ControlToValidate="ddlPropertyType" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPropertyType" Style="width: 202px;" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Purchase Option" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfPurchaseOption" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    InitialValue="00000000-0000-0000-0000-000000000000" runat="server" ValidationGroup="Configuration"
                                                    ControlToValidate="ddlPurchaseOption" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPurchaseOption" Style="width: 202px;" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litSBArea" runat="server" Text="SBA (Sft) (Residential)"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSBAreaResidential" SkinID="CmpTextbox" runat="server" MaxLength="10"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="filtxtSBAreaResidential" runat="server" TargetControlID="txtSBAreaResidential"
                                                FilterType="Numbers" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="Literal1" runat="server" Text="SBA (Sft) (Commercial)"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSbAreaCommercial" SkinID="CmpTextbox" runat="server" MaxLength="10"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="ftSbAreaCommercial" runat="server" TargetControlID="txtSbAreaCommercial"
                                                FilterType="Numbers" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litCarpetArea" runat="server" Text="Total Built Up Area" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvCarpetArea" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtCarpetArea"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCarpetArea" SkinID="CmpTextbox" runat="server" MaxLength="10"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="filtxtCarpetArea" runat="server" TargetControlID="txtCarpetArea"
                                                FilterType="Numbers" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="pagesubheader">
                                            <asp:Literal ID="Literal2" runat="server" Text="Contact Information"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litPropertyManagerName" runat="server" Text="Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfPrimoryEmailAddress" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtPropertyManagerName"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPropertyManagerName" SkinID="CmpTextbox" runat="server" MaxLength="180"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litPrimaryContactNo" runat="server" Text="Contact No." CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfPrimoryContactNo" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtPrimaryContactNo"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPrimaryContactNo" SkinID="CmpTextbox" runat="server" MaxLength="17"></asp:TextBox>
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtPrimaryContactNo"
                                                FilterMode="ValidChars" ValidChars="1234567890+-" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litPrimaryEmail" runat="server" Text="Email" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfEmail" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtPrimaryEmail"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="*" ControlToValidate="txtPrimaryEmail"
                                                    CssClass="rfv_ErrorStar" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ValidationGroup="Configuration" Display="Dynamic"></asp:RegularExpressionValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPrimaryEmail" SkinID="CmpTextbox" runat="server" MaxLength="180"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="pagesubheader">
                                            <asp:Literal ID="Literal4" runat="server" Text="Address"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="tdAddress" runat="server">
                                            <asp:Label ID="litAddressLine1" runat="server" Text="Address"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvAdd1" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtAddressLine1"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddressLine1" runat="server" SkinID="Medium" Height="60px" TextMode="MultiLine"
                                                MaxLength="380"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="tdCity" runat="server">
                                            <asp:Label ID="litCity" runat="server" Text="City"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvCityName" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtCityName"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCityName" SkinID="CmpTextbox" runat="server" MaxLength="78"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="tdZipCode" runat="server">
                                            <asp:Label ID="litZipCode" runat="server" Text="ZipCode"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtZipCode" runat="server" SkinID="CmpTextbox" MaxLength="13"></asp:TextBox>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvZipCode" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtZipCode"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator></span>
                                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtZipCode"
                                                FilterMode="ValidChars" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890">
                                            </ajx:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="tdState" runat="server">
                                            <asp:Label ID="litState" runat="server" Text="State"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfState" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtStateName"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStateName" SkinID="CmpTextbox" runat="server" MaxLength="120"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="tdCountry" runat="server">
                                            <asp:Label ID="litCountry" runat="server" Text="Country"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfCountry" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration" ControlToValidate="txtCountryName"
                                                    ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCountryName" SkinID="CmpTextbox" runat="server" MaxLength="120"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="pagesubheader">
                                            <asp:Literal ID="Literal5" runat="server" Text="Document Upload"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="dTableBox1">
                                            <div class="leftmarginbox_content">
                                                <asp:GridView ID="gvDocument" runat="server" AutoGenerateColumns="false" SkinID="gvNoPaging"
                                                    OnRowDataBound="gvDocument_RowDataBound" DataKeyNames="TermID" ShowHeader="true"
                                                    OnRowCommand="gvDocument_RowCommand">
                                                    <Columns>
                                                        <asp:BoundField DataField="DisplayTerm" HeaderText="Document Name" HeaderStyle-HorizontalAlign="Left" />
                                                        <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" HeaderText="Number">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtStatutoryName" SkinID="Search" Style="width: 100px !important;"
                                                                    runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Notes")%>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="95px" HeaderText="File" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <span class="erroraleart">
                                                                    <asp:RegularExpressionValidator ID="rfvDocument" runat="server" ControlToValidate="fuDocument"
                                                                        SetFocusOnError="true" CssClass="rfv_ErrorStar" ValidationGroup="Configuration"
                                                                        Display="Dynamic" ErrorMessage="*" ValidationExpression="^.+(.pdf|.PDF|.doc|.jpg|.jpeg|.gif|.png|.bmp|.JPG|.JPEG|.GIF|.PNG|.BMP|.TIF|.tif|.DOC|.docx|.DOCX|xlsx|XLSX)$"></asp:RegularExpressionValidator>
                                                                </span>
                                                                <div id='browse_file_grid'>
                                                                    <asp:FileUpload ID="fuDocument" ToolTip=".pdf|.PDF|.doc|.jpg|.jpeg|.gif|.png|.bmp|.JPG|.JPEG|.GIF|.PNG|.BMP|.TIF|.tif|.DOC|.docx|.DOCX|xlsx|XLSX"
                                                                        runat="server" Height="22px" size="4" Style="float: left; width: 100px;" />
                                                                </div>
                                                                <asp:HiddenField ID="hdnDocumentName" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "DocumentName")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="40px" HeaderText="View" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <a id="aDocumentLink" runat="server" visible="false" target="_blank">
                                                                    <asp:Image ID="imgView" runat="server" Style="float: left;" ImageUrl="~/images/View.png" /></a>
                                                                <asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"DocumentID") %>'
                                                                    CommandName="DELETEDATA" runat="server" ImageUrl="~/images/DeleteFile.png" Style="float: right;
                                                                    width: 19px; margin-left: 3px; border: 0px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" style="text-align: right;">
                                            <div style="float: right; width: auto; display: inline-block;">
                                                <asp:Button ID="btnNew" runat="server" Style="display: inline-block; margin-left: 5px;
                                                    display: inline;" Text="New" OnClick="btnNew_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/save.png" ValidationGroup="Configuration" CausesValidation="true"
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
                <td style="width: 2px;">
                    &#160;
                </td>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                QUICK SEARCH
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
                                <div class="box_leftmargin_content">
                                    <div>
                                        <table id="tbl" cellpadding="2" cellspacing="0" width="100%" border="0" class="pageinfo">
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Property Name
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSPropertyName" runat="server" Style="vertical-align: middle;
                                                        margin-top: 7px; width: 125px !important;" MaxLength="65"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; line-height: 17px;
                                                    height: 19px;">
                                                    City
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="txtQSLocation" runat="server" Style="width: 127px !important;">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle;">
                                                    Property Type
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drpQSPropertyType" runat="server" SkinID="Search">
                                                    </asp:DropDownList>
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; vertical-align: middle; margin-left: 5px;" OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <div style="height: 775px; overflow: auto;">
                                            <asp:GridView ID="grdPropertyList" runat="server" ShowHeader="false" ShowFooter="false"
                                                SkinID="gvNoPaging" AutoGenerateColumns="false" Width="92%" OnRowCommand="grdPropertyList_RowCommand"
                                                OnRowDataBound="grdPropertyList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea">
                                                                    <strong>
                                                                        <%#DataBinder.Eval(Container.DataItem, "PropertyName")%></strong><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "City")%><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "ProperyType")%>
                                                                </div>
                                                                <div class="leftmargin_icons">
                                                                    <asp:ImageButton ID="btnEdit" ToolTip="Edit" runat="server" ImageUrl="~/images/edit.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
                                                                        CommandName="EditData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PropertyID")%>' OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                    <asp:ImageButton ID="btnDelete" ToolTip="Delete" runat="server" ImageUrl="~/images/delete_icon.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
                                                                        CommandName="DeleteData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PropertyID")%>' OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                </div>
                                                                <div class="clear">
                                                                </div>
                                                            </div>
                                                            <div class="clear">
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <div class="pagecontent_info">
                                                        <div class="NoItemsFound">
                                                            <h2>
                                                                <asp:Literal ID="Literal5" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                        </div>
                                                    </div>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                    </div>
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
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="Panel1"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="Panel1" runat="server" style="display:none;">
            <div style="width: 500px; height: 200px; margin-top: 25px;">
                <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
                    <tr>
                        <td class="modelpopup_boxtopleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxtopcenter">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxtopright">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="modelpopup_boxleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_box_bg">
                            <div style="width: 100px; float: left; margin-top: 10px;">
                                <asp:HyperLink ID="HyperLink1" runat="server">
                                    <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                        ID="Image1" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div style="float: left; width: 225px; margin-top: 40px; margin-left: 10px;">
                                <asp:Label ID="Label1" runat="server" Text="Sure you want to delete?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <asp:Button ID="btnPropertyYes" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnPropertyYes_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnPropertyNo" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            OnClick="btnPropertyNo_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="modelpopup_boxright">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="modelpopup_boxbottomleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxbottomcenter">
                        </td>
                        <td class="modelpopup_boxbottomright">
                            &nbsp;
                        </td>
                    </tr>
                </table>
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
<asp:UpdateProgress AssociatedUpdatePanelID="updProperty" ID="UpdateProgressProperty"
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
