<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlExpenseConfigurationInformation.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Configurations.CtrlExpenseConfigurationInformation" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>

<script type="text/javascript">
    var updateProgress = null;

    <%--function postbackButtonClick() {
        if (Page_ClientValidate("Configuration")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgresSaler%>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
        else {
            return false;
        }
    }--%>

    function CalculateTotalAmount(obj)
    {
        var Amount = 0;
        $.each($(".TotalSum"), function () {
        Amount = parseInt(Amount) + parseInt($(this).val() || 0);
        });
        $("#ctl00_ContentPlaceHolder1_CtrlExpenseConfigurationInformation_txtTotalAmountID").val(Amount);
    }
    function ExpenseDocumentUpload() {
        debugger
        var FileDocument = $(".ExDocument").val().substring($(".ExDocument").val().lastIndexOf("\\") + 1, $(".ExDocument").val().length);
        $("#ctl00_ContentPlaceHolder1_CtrlExpenseConfigurationInformation_gvExpenseModification_ctl02_expenseDocumentName").val(FileDocument);
    }
</script>
<style type="text/css">
    #progressBackgroundFilter {
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

    #processMessage {
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
<asp:UpdatePanel ID="updSaler" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">&nbsp;
                            </td>
                            <td class="boxtopcenter">EXPENSE SETUP
                            </td>
                            <td class="boxtopright">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">&nbsp;
                            </td>
                            <td>
                                <table width="100%" cellpadding="3" cellspacing="3">
                                    <tr>
                                        <td colspan="2">
                                            <div style="height: 26px;">
                                                 <%if (IsMessage)
                                                  { %>
                                                <div class="ResetSuccessfully">
                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                        <img src="../../images/success.png" />
                                                    </div>
                                                    <div>
                                                        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                                                    </div>
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
                                        <td>
                                            <asp:Label ID="PropertyID" runat="server" Text="Property Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvPropertyID" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    InitialValue="00000000-0000-0000-0000-000000000000" runat="server" ValidationGroup="Configuration"
                                                    ControlToValidate="ddlPropertyID" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPropertyID" Style="width: 202px;" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvDateOfExpense" runat="server" ControlToValidate="txtDateOfExpense"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="Configuration"></asp:RequiredFieldValidator>
                                            </span>
                                            <b>
                                                <asp:Literal ID="litDateOfExpense" runat="server" Text="Payment Due Date"></asp:Literal></b>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDateOfExpense" runat="server" SkinID="CmpTextbox" Enabled="false"></asp:TextBox>
                                            <ajx:CalendarExtender ID="txtDateOfExpense_ColorPickerExtender" runat="server" CssClass="MyCalendar"
                                                Enabled="True" TargetControlID="txtDateOfExpense" PopupButtonID="imgColor">
                                            </ajx:CalendarExtender>
                                            <asp:Image ID="imgColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                Height="20px" Width="20px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="AssociationTypeTerm" runat="server" Text="AssociationType_Term" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvAssociationTypeTerm" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    InitialValue="00000000-0000-0000-0000-000000000000" runat="server" ValidationGroup="Configuration"
                                                    ControlToValidate="ddlAssociationTypeTerm" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlAssociationTypeTerm" Style="width: 202px;" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="ExpenseTypeTerm" runat="server" Text="ExpenseType_Term" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvExpenseTypeTerm" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    InitialValue="00000000-0000-0000-0000-000000000000" runat="server" ValidationGroup="Configuration"
                                                    ControlToValidate="ddlExpenseTypeTerm" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlExpenseTypeTerm" Style="width: 202px;" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="ModeOfPaymentTerm" runat="server" Text="ModeOfPayment_Term" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvModeOfPaymentTerm" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    InitialValue="00000000-0000-0000-0000-000000000000" runat="server" ValidationGroup="Configuration"
                                                    ControlToValidate="ddlModeOfPaymentTerm" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlModeOfPaymentTerm" Style="width: 202px;" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="ExpenseAmt" runat="server" Text="Expense Amt" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvExpenseAmt" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                    runat="server" ValidationGroup="Configuration"
                                                    ControlToValidate="txtExpenseAmt" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtExpenseAmt" Style="width: 202px;" runat="server">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="ExpenseDetail" runat="server" Text="Expense Detail" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvExpenseDetail" runat="server" ControlToValidate="txtExpenseDetail"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="Configuration" Display="Dynamic">
                                                </asp:RequiredFieldValidator></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtExpenseDetail" TextMode="multiline" SkinID="CmpTextbox" Columns="10" Rows="3" runat="server" />

                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="dTableBox1">
                                            <div class="leftmarginbox_content">
                                                <div class="pagesubheader" style="padding: 1px 0px; margin-top: 10px;">
                                                    <asp:Literal ID="Literal3" runat="server" Text="ExpensesDetail/Modification"></asp:Literal>
                                                    <asp:ImageButton ID="ButtonAdd" ToolTip="Add" OnClick="fnAddNewExpenseDetail"
                                                        CommandName="ADDDATA" runat="server" ImageUrl="~/images/add_icon.png" Style="border-radius: 50%; float: right; width: 19px; margin-bottom: 10px; border: 0px;"
                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                                </div>
                                                <asp:GridView ID="gvExpenseModification" AutoGenerateColumns="false" SkinID="gvNoPaging"
                                                    runat="server" 
                                                    OnRowDataBound="gvExpense_RowDataBound" OnRowCommand="gvExpense_RowCommand" DataKeyNames="TermID" ShowHeader="true"
                                                    OnRowCreated="gvExpenseRowCreated">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Vendor">
                                                            <ItemTemplate>
                                                               <asp:Label ID="Vendor" runat="server">
                                                                <span class="erroraleart">
                                                                    <asp:RequiredFieldValidator ID="rfvVendorID" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                                        InitialValue="00000000-0000-0000-0000-000000000000" runat="server" ValidationGroup="Configuration"
                                                                        ControlToValidate="ddlvendorID" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <asp:DropDownList ID="ddlvendorID" runat="server" >
                                                                    </asp:DropDownList>
                                                                      </asp:Label>
                                                                 <asp:HiddenField ID="txtExpenseDetaileID" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>  
                                                        <asp:TemplateField HeaderText="Purchase">
                                                            <ItemTemplate>
                                                               <asp:Label ID="PurchaseID" runat="server">
                                                                <span class="erroraleart">
                                                                    <asp:RequiredFieldValidator ID="rfvPurchaseID" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                                        InitialValue="00000000-0000-0000-0000-000000000000" runat="server" ValidationGroup="Configuration"
                                                                        ControlToValidate="ddlPurchaseID" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <asp:DropDownList ID="ddlPurchaseID" runat="server">
                                                                    </asp:DropDownList>
                                                                      </asp:Label>  
                                                            </ItemTemplate>
                                                        </asp:TemplateField>  
                                                        <asp:TemplateField HeaderText="Item">
                                                            <ItemTemplate>
                                                               <asp:Label ID="ItemID" runat="server">
                                                                <span class="erroraleart">
                                                                    <asp:RequiredFieldValidator ID="rfvItemID" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                                        InitialValue="00000000-0000-0000-0000-000000000000" runat="server" ValidationGroup="Configuration"
                                                                        ControlToValidate="ddlItemID" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <asp:DropDownList ID="ddlItemID" runat="server">
                                                                    </asp:DropDownList>
                                                                      </asp:Label>  
                                                            </ItemTemplate>
                                                        </asp:TemplateField>  
                                                        <asp:TemplateField HeaderText="Amount">
                                                            <ItemTemplate>
                                                                <span class="erroralert">
                                                                    <asp:RequiredFieldValidator ID="txtAmount" SkinID="Search" SetFocusOnError="true" runat="server" ValidationGroup="Configuration" 
                                                                        ControlToValidate="txtAmountID" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                </span>
                                                                <asp:TextBox ID="txtAmountID" Class="TotalSum" value="0.00" SkinID="Search" runat="server" onkeyUp="CalculateTotalAmount(this)" Text='<%#DataBinder.Eval(Container.DataItem, "TotalAmount")%>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Note">
                                                            <ItemTemplate>
                                                                <span class="erroralert">
                                                                    <asp:RequiredFieldValidator ID="txtPurchaseNote" SkinID="Search" SetFocusOnError="true" runat="server" ValidationGroup="Configuration" 
                                                                        ControlToValidate="txtPurchaseNoteID" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                </span>
                                                                <asp:TextBox ID="txtPurchaseNoteID"  SkinID="Search" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PurchaseNote")%>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            </asp:TemplateField>
                                                        <asp:TemplateField  HeaderText="File">
                                                            <ItemTemplate>
                                                                <span class="erroraleart">
                                                                    <asp:RegularExpressionValidator ID="rfvExpenseDocument" runat="server" ControlToValidate="fileExpenseDocument"
                                                                        SetFocusOnError="true" CssClass="rfv_ErrorStar" ValidationGroup="Configuration"
                                                                        Display="Dynamic" ErrorMessage="*" ValidationExpression="^.+(.pdf|.PDF|.doc|.jpg|.jpeg|.gif|.png|.bmp|.JPG|.JPEG|.GIF|.PNG|.BMP|.TIF|.tif|.DOC|.docx|.DOCX|xlsx|XLSX)$"></asp:RegularExpressionValidator>
                                                                </span>
                                                                <div id='browse_file_grid'>
                                                                    <asp:FileUpload ID="fileExpenseDocument" Class="ExDocument" ToolTip=".pdf|.PDF|.doc|.jpg|.jpeg|.gif|.png|.bmp|.JPG|.JPEG|.GIF|.PNG|.BMP|.TIF|.tif|.DOC|.docx|.DOCX|xlsx|XLSX"
                                                                        runat="server" Height="22px" size="4" Style="float: left; width: 100px;" onChange="ExpenseDocumentUpload()" />
                                                                </div>
                                                                <asp:HiddenField ID="expenseDocumentName"  runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "DocumentName")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         
                                                        <asp:TemplateField ItemStyle-Width="40px" HeaderText="View" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <a id="aLandIssueDocumentLink" runat="server" visible="false" target="_blank">
                                                                    <asp:Image ID="imgView" runat="server" Style="float: left;" ImageUrl="~/images/View.png" /></a>
                                                                <asp:ImageButton ID="btnRemoveRow" ToolTip="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"DocumentID") %>'
                                                                    CommandName="DELETEDATA" runat="server" ImageUrl="~/images/DeleteFile.png" Style="float: right; width: 19px; margin-left: 3px; border: 0px;"
                                                                    OnClientClick="fnDisplayCatchErrorMessage()" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                 <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Total Amount" style="margin-left: 564px;"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    <asp:TextBox ID="txtTotalAmountID" SkinID="Search" runat="server" style="margin-left: 564px;" disabled></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" style="text-align: right;">
                                            <div>
                                                <asp:Button ID="btnNew" runat="server" Style="display: inline-block; margin-left: 5px; display: inline;"
                                                    Text="New" OnClick="btnNew_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:Button ID="btnSave" OnClick="SaveExpense" Text="Save" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/save.png" CausesValidation="true" />
                                                <asp:Button ID="btnCancel" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" OnClick="btnCancel_Click" CausesValidation="false" OnClientClick="fnDisplayCatchErrorMessage()" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="boxright">&nbsp;
                            </td>
                        </tr>

                        <tr>
                            <td class="boxbottomleft">&nbsp;
                            </td>
                            <td class="boxbottomcenter">&nbsp;
                            </td>
                            <td class="boxbottomright">&nbsp;
                            </td>
                        </tr>
                    </table>
                    <div class="clear_divider">
                    </div>

                </td>
                <td style="width: 2px;">&#160;
                </td>
                <%--QuickSearch--%>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="Deletemsgbx" runat="server" TargetControlID="hfMessage" PopupControlID="Panel1"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="Panel1" runat="server" Style="display: none;">
            <div style="width: 500px; height: 200px; margin-top: 25px;">
                <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
                    <tr>
                        <td class="modelpopup_boxtopleft">&nbsp;
                        </td>
                        <td class="modelpopup_boxtopcenter">&nbsp;
                        </td>
                        <td class="modelpopup_boxtopright">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="modelpopup_boxleft">&nbsp;
                        </td>
                        <td class="modelpopup_box_bg">
                            <div style="width: 100px; float: left; margin-top: 10px;">
                                <asp:HyperLink ID="HyperLink1" runat="server">
                                    <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                        ID="Image1" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div style="float: left; width: 225px; margin-top: 40px; margin-left: 10px;">
                                <asp:Label ID="Label4" runat="server" Text="Sure you want to delete?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <%-- <td align="center" valign="middle">
                                        <asp:Button ID="btnVendorYes" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnVendorYes_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnVendorNo" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            OnClick="btnVendorNo_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                    </td>--%>
                                </tr>
                            </table>
                        </td>
                        <td class="modelpopup_boxright">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="modelpopup_boxbottomleft">&nbsp;
                        </td>
                        <td class="modelpopup_boxbottomcenter"></td>
                        <td class="modelpopup_boxbottomright">&nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>

<asp:UpdateProgress AssociatedUpdatePanelID="updSaler" ID="UpdateProgresSaler"
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
