<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPropertyInsuranceNew.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlPropertyInsuranceNew" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
    function stopKey(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 8) && (node.type == "text")) { return false; }
        else if ((evt.keyCode == 9) && (node.type == "text")) { return true; }
        else if ((evt.keyCode == 46) && (node.type == "text")) { return false; }
        else { return false; }
    }

    function fnConfirmDelete(id) {

        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hfMessageDelete.ClientID %>').value = id;
        $find('mpeConfirmDelete').show();
        return false;
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
<script type="text/javascript">
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("PaymentReceipt")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgressPropertyInsurance.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
        else {
            return false;
        }
    }
</script>
<asp:UpdatePanel ID="updtInsurnace" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td style="padding-left: 0px; width: 100%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                PROPERTY INSURANCE
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
                                <asp:MultiView ID="mvInsuranceDetails" runat="server">
                                    <asp:View ID="vInsuranceList" runat="server">
                                        <table width="100%" cellpadding="3" cellspacing="3">
                                            <tr>
                                                <td align="right" valign="middle">
                                                    <asp:Button ID="btnAddTopInsurance" Text="Add New" runat="server" Style="float: right;"
                                                        OnClick="btnAddTopInsurance_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dTableBox" style="padding: 10px 0px;">
                                                    <asp:GridView ID="gvInsuranceDetails" runat="server" AutoGenerateColumns="False"
                                                        Width="100%" OnRowCommand="gvInsuranceDetails_RowCommand" OnRowDataBound="gvInsuranceDetails_RowDataBound"
                                                        OnPageIndexChanging="gvInsuranceDetails_OnPageIndexChanging">
                                                        <Columns>
                                                            <asp:BoundField DataField="PropertyName" HeaderText="Property Name" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px" />
                                                            <asp:TemplateField HeaderText="Start Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                ItemStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:Literal ID="litStartDate" runat="server"></asp:Literal>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Valid Upto" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                ItemStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:Literal ID="litValidUpto" runat="server"></asp:Literal>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="CompanyName" HeaderText="Insurance Company" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" />
                                                            <asp:BoundField DataField="PolicyNo" HeaderText="Policy No." HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" />
                                                            <asp:TemplateField HeaderText="Action" ItemStyle-Width="18px" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <div>
                                                                        <asp:ImageButton ID="btnView" ToolTip="View" CommandName="VIEWISNURANCE" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InsuranceID")%>'
                                                                            runat="server" ImageUrl="~/images/edit.png" Style="display: inline; border: 0px;" />
                                                                        <asp:ImageButton ID="btnEdit" ToolTip="Edit" CommandName="EDITISNURANCE" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InsuranceID")%>'
                                                                            runat="server" ImageUrl="~/images/edit.png" Style="display: inline; border: 0px;" />
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete" ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Center" Visible="false">
                                                                <ItemTemplate>
                                                                    <a href="#" style="border: 0px;">
                                                                        <asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandName="DELETEINSURANCE" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InsuranceID")%>'
                                                                            runat="server" ImageUrl="~/images/delete_icon.png" Style="border: 0px; vertical-align: middle;
                                                                            margin-top: 2px; margin-right: 7px;" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div class="pagecontent_info">
                                                                <div class="NoItemsFound">
                                                                    <h2>
                                                                        <asp:Literal ID="Literal3" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                                </div>
                                                            </div>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                    <asp:View ID="vInsuranceInsert" runat="server">
                                        <table width="100%" cellpadding="3" cellspacing="3">
                                            <tr>
                                                <td colspan="2">
                                                    <div style="height: 26px;">
                                                        <%if (IsInsert)
                                                          { %>
                                                        <div class="ResetSuccessfully">
                                                            <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                                <img src="../../images/success.png" />
                                                            </div>
                                                            <div>
                                                                <asp:Label ID="lblInsurnaceReceiptMsg" runat="server"></asp:Label></div>
                                                            <div style="height: 10px;">
                                                            </div>
                                                        </div>
                                                        <% }%>
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
                                                <td align="left" width="125px">
                                                    <asp:Label ID="lblPropertyName" runat="server" Text="Property Name" CssClass="RequireFile"></asp:Label>
                                                    <span class="erroraleart">
                                                        <asp:RequiredFieldValidator ID="rfvPropertyName" SetFocusOnError="True" ControlToValidate="ddlPropertyName"
                                                            ValidationGroup="PaymentReceipt" InitialValue="00000000-0000-0000-0000-000000000000"
                                                            runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                    </span>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlPropertyName" runat="server" AutoPostBack="true" Style="width: 203px;">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="litPaymentScheduleID" runat="server" Text="Insurance Period" CssClass="RequireFile"></asp:Label>
                                                    <span class="erroraleart">
                                                        <asp:RequiredFieldValidator ID="rfvPaymentSchedule" SetFocusOnError="True" ControlToValidate="ddlDate"
                                                            ValidationGroup="PaymentReceipt" runat="server" InitialValue="00000000-0000-0000-0000-000000000000"
                                                            ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <b>Start Date</b>
                                                </td>
                                                <td align="left">
                                                    <div style="display: inline-block;">
                                                        <div style="display: inline-block;">
                                                            <asp:DropDownList ID="ddlDate" runat="server" Style="width: 65px;">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rvfMonth" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                                Display="Dynamic" ControlToValidate="ddlMonth" ValidationGroup="PaymentReceipt"
                                                                runat="server" ErrorMessage="*" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                                            <asp:DropDownList ID="ddlMonth" runat="server" Style="width: 70px;">
                                                                <asp:ListItem Text="-Month-" Value="00000000-0000-0000-0000-000000000000" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                                                                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                                                <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                                                                <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                                                                <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                                                                <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                                                                <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                                                <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                                                <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rvfYear" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                                Display="Dynamic" ControlToValidate="ddlYear" ValidationGroup="PaymentReceipt"
                                                                runat="server" ErrorMessage="*" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                                            <asp:DropDownList ID="ddlYear" runat="server" Style="width: 60px;">
                                                            </asp:DropDownList>
                                                            <div id="FromValidDate" runat="server" class="rfv_ErrorStar" visible="false" style="float: right;">
                                                                <asp:Label ID="litFromValidDate" runat="server"></asp:Label></div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <b>Valid Upto</b>
                                                </td>
                                                <td align="left">
                                                    <div style="display: inline-block;">
                                                        <asp:DropDownList ID="ddlToDate" runat="server" Style="width: 65px;">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rvfToMonth" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                            Display="Dynamic" ControlToValidate="ddlToMonth" ValidationGroup="PaymentReceipt"
                                                            runat="server" ErrorMessage="*" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                                        <asp:DropDownList ID="ddlToMonth" runat="server" Style="width: 70px;">
                                                            <asp:ListItem Text="-Month-" Value="00000000-0000-0000-0000-000000000000" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                                                            <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                                                            <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                                                            <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                                                            <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                                            <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                                            <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rvfToYear" SetFocusOnError="true" CssClass="rfv_ErrorStar"
                                                            Display="Dynamic" ControlToValidate="ddlYear" ValidationGroup="PaymentReceipt"
                                                            runat="server" ErrorMessage="*" InitialValue="00000000-0000-0000-0000-000000000000"></asp:RequiredFieldValidator>
                                                        <asp:DropDownList ID="ddlToYear" runat="server" Style="width: 60px;">
                                                        </asp:DropDownList>
                                                        <div id="ToValidDate" runat="server" class="rfv_ErrorStar" visible="false" style="float: right;">
                                                            <asp:Label ID="litToValidDate" runat="server"></asp:Label></div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblComapnyName" runat="server" Text="Insurance Company" CssClass="RequireFile"></asp:Label>
                                                    <span class="erroraleart">
                                                        <asp:RequiredFieldValidator ID="rfvCompanyName" SetFocusOnError="True" ControlToValidate="txtCompanyName"
                                                            ValidationGroup="PaymentReceipt" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                    </span>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCompanyName" SkinID="CmpTextbox" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblPolicyNo" runat="server" Text="Policy No." CssClass="RequireFile"></asp:Label>
                                                    <span class="erroraleart">
                                                        <asp:RequiredFieldValidator ID="rfvpolicyno" SetFocusOnError="True" ControlToValidate="txtPolicyNo"
                                                            ValidationGroup="PaymentReceipt" runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                    </span>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPolicyNo" SkinID="CmpTextbox" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="Literal6" runat="server" Text="Upload Policy"></asp:Literal>
                                                    <span class="erroraleart">
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="fuLicenseNo"
                                                            SetFocusOnError="true" CssClass="rfv_ErrorStar" ValidationGroup="PaymentReceipt"
                                                            Display="Dynamic" ErrorMessage="*" ValidationExpression="^.+(.pdf|.jpg|.jpeg|.gif|.png|.bmp|.JPG|.JPEG|.GIF|.PNG|.BMP|.TIF|.tif|.PDF|.doc|.DOC|.docx|.DOCX|xlsx|XLSX)$"></asp:RegularExpressionValidator>
                                                    </span>
                                                </td>
                                                <td>
                                                    <div id='browse_file_grid' style="float: left;">
                                                        <asp:FileUpload ID="fuLicenseNo" runat="server" Height="25px" ToolTip=".pdf|.jpg|.jpeg|.gif|.png|.bmp|.JPG|.JPEG|.GIF|.PNG|.BMP|.TIF|.tif|.PDF|.doc|.DOC|.docx|.DOCX|xlsx|XLSX" /></div>
                                                    &nbsp;&nbsp;<a id="aLicenseNo" runat="server" visible="false" target="_blank">
                                                        <asp:Image ID="Image6" runat="server" ImageUrl="~/images/View.png" /></a>
                                                    <asp:ImageButton ID="imgDelete" BorderStyle="None" runat="server" ImageUrl="~/images/DeleteFile.png" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" colspan="2" style="text-align: right;">
                                                    <div style="float: right; width: auto; height: 33px; display: inline-block;">
                                                        <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;"
                                                            runat="server" ImageUrl="~/images/save.png" ValidationGroup="PaymentReceipt"
                                                            CausesValidation="true" OnClientClick="return postbackButtonClick();" OnClick="btnSave_Click" />
                                                        <asp:Button ID="btnCancel" runat="server" Style="display: inline-block; margin-left: 5px;
                                                            display: inline;" Text="Back to List" OnClick="btnCancelInsuranceDetail_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage()" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:View>
                                </asp:MultiView>
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
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hfMessageDelete" runat="server" />
        <ajx:ModalPopupExtender ID="msgbxDelete" runat="server" TargetControlID="hfMessageDelete"
            PopupControlID="pnl" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnl" runat="server" Style="display: none;">
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
                                <asp:HyperLink ID="CloseModelPopup" runat="server">
                                    <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                        ID="btnImage" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div style="float: left; width: 225px; margin-top: 40px; margin-left: 10px;">
                                <asp:Label ID="lblErrorMessage" runat="server" Text="Sure you want to delete?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <asp:Button ID="btnYes" Text="Yes" runat="server" ImageUrl="~/images/save.png" OnClick="btnYes_Click"
                                            Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnNo" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            OnClick="btnNo_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
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
        <asp:HiddenField ID="hfnInsuranceDetail" runat="server" />
        <ajx:ModalPopupExtender ID="mpeInsuranceDetails" runat="server" TargetControlID="hfnInsuranceDetail"
            PopupControlID="pnlInsuranceDetails" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlInsuranceDetails" runat="server">
            <div style="width: 429px; height: 260px; margin-top: 25px;">
                <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
                    <tr>
                        <td class="modelpopup_boxtopleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxtopcenter">
                            <asp:Label ID="litInsuranceDetails" runat="server" Text="Insurance Details"></asp:Label>
                            <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                                <asp:ImageButton ID="imgCancelAddServices" runat="server" ImageUrl="~/images/closepopup.png"
                                    Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
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
                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                <tr>
                                    <td style="width: 200px">
                                        <asp:Label ID="litPropertyName" Font-Bold="true" runat="server" Text="Property Name"></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="litDispPropertyName" Text="-" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="litInsuranceperiod" Font-Bold="true" runat="server" Text="Insurance Period"></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="litDispInsuranceperiod" runat="server" Text="-"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCompanyName" Font-Bold="true" runat="server" Text="Company Name"></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="lblDispCompanyName" runat="server" Text="-"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" Font-Bold="true" runat="server" Text="Policy No."></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="lblDispPolicyNo" runat="server" Text="-"></asp:Label>
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
<asp:UpdateProgress AssociatedUpdatePanelID="updtInsurnace" ID="UpdateProgressPropertyInsurance"
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
