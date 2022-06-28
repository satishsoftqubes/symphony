<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlVendorMaster.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlVendorMaster" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script src="../../Javascript/Common.js" type="text/javascript"></script>
<script type="text/javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnConfirmDelete(id) {
        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnConfirmDelete.ClientID %>').value = id;
        $find('mpeConfirmDelete').show();
        return false;
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }  
</script>
<asp:UpdatePanel ID="updVendorMaster" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" style="padding-left: 0px; width: 66.66%">
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
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td>
                                                <%if (IsListMessage)
                                                  { %>
                                                <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Literal ID="ltrListMessage" runat="server"></asp:Literal></strong>
                                                    </p>
                                                </div>
                                                <%}%>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:MultiView ID="mvVendor" runat="server">
                                        <asp:View ID="vVendorList" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <th align="left">
                                                        <asp:Literal ID="ltrSearchVendorName" runat="server"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchVendorName" runat="server"></asp:TextBox>
                                                    </td>
                                                    <th align="left">
                                                        <asp:Literal ID="ltrSearchCompanyName" runat="server"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchCompanyName" runat="server"></asp:TextBox>
                                                        <asp:ImageButton ID="btnSearchVendor" CssClass="small_img" Style="border: 0px; vertical-align: middle;
                                                            margin: -4px 0 0 5px;" runat="server" ImageUrl="~/images/search-icon.png" OnClick="btnSearch_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" />
                                                        <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                            OnClick="imgbtnClearSearch_Click" Style="border: 0px; vertical-align: middle;
                                                            margin: -2px 0 0 10px;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="right" valign="middle">
                                                        <asp:Button ID="btnTopAddVendor" OnClick="btnTopAddVendor_Click" runat="server" Style="float: right;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="ltrVendorList" runat="server"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvVendorList" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                CssClass="grid_content" ShowHeader="true" OnRowDataBound="gvVendor_RowDataBound"
                                                                OnPageIndexChanging="gvVendor_OnPageIndexChanging" OnRowCommand="gvVendor_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHrdNo" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCompanyName" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvCompanyName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CompanyName")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRegistrationNo" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvRegistrationNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RegistrationNo")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--  <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRegistrationDate" Text="Registration Date" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvRegistrationDate" runat="server" Width="75px" Text='<%# DataBinder.Eval(Container.DataItem, "RegistrationDate") != DBNull.Value ? Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "RegistrationDate")).ToString(clsSession.DateFormat) : ""%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrVatRegNo" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvVatRegNoe" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "VATRegNo")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--<asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrVatRegistrationDate" Text="Vat Reg. Date" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvVatRegistrationDate" runat="server" Width="75px" Text='<%# DataBinder.Eval(Container.DataItem, "VATRegistrationDate") != DBNull.Value ? Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "VATRegistrationDate")).ToString(clsSession.DateFormat) : ""%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrContactPersonName" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvContactPersonName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ContactPersonName")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrContact" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvContact" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ContactNo")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrEmail" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblGvEmail" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Email")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAction" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "VendorID")%>'
                                                                                CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "VendorID")%>'
                                                                                CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFound" Text="Data Not Found" runat="server"></asp:Label></b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="right" valign="middle">
                                                        <asp:Button ID="btnAddBottomVendor" OnClick="btnTopAddVendor_Click" runat="server"
                                                            Style="float: right;" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vAddEditVendor" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td colspan="4">
                                                        <div style="float: right; padding-bottom: 5px;">
                                                            <b>
                                                                <asp:Literal ID="ltrGeneralMandartoryFiledMessage" runat="server"></asp:Literal>
                                                            </b>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrCompanyName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td style="width: 320px;">
                                                        <asp:TextBox ID="txtCompanyName" runat="server" MaxLength="150" TabIndex="1"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvCompanyName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCompanyName"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrContactPersonName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtContactPersonName" runat="server" MaxLength="150" 
                                                            TabIndex="8"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvContactPersonName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtContactPersonName"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="ltrRegistrationNo" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRegistrationNo" runat="server" MaxLength="150" TabIndex="2"></asp:TextBox>
                                                    </td>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrContactNo" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtContactNo" runat="server" MaxLength="17" TabIndex="9"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="fltContactNo" runat="server" TargetControlID="txtContactNo"
                                                            FilterType="Numbers" />
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvContactNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtContactNo"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="ltrRegistrationDate" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRegistrationDate" onkeydown="return stopKey(event);" runat="server"
                                                            Style="width: 182px !important;" SkinID="searchtextbox" TabIndex="3"></asp:TextBox>
                                                        <asp:Image ID="imgRegistrationDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                            Height="20px" Width="20px" />
                                                        <ajx:CalendarExtender ID="calRegistrationDate" PopupButtonID="imgRegistrationDate"
                                                            TargetControlID="txtRegistrationDate" runat="server" Format="dd/MMM/yyyy">
                                                        </ajx:CalendarExtender>
                                                        <img src="../../images/clear.png" id="imgSearchSD" style="vertical-align: middle;"
                                                            title="Clear Date" onclick="fnClearDate('<%= txtRegistrationDate.ClientID %>');" />
                                                    </td>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrEmail" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="150" TabIndex="10"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvPrimaryEmail" runat="server" ControlToValidate="txtEmail"
                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"
                                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="refEmail" SetFocusOnError="True" ControlToValidate="txtEmail"
                                                                ValidationGroup="IsRequire" runat="server" CssClass="input-notification error png_bg"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator></span>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrContactPersonName"  runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtContactPersonName" runat="server" MaxLength="150"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvContactPersonName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtContactPersonName"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>--%>
                                                <%--<tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrContactNo"  runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtContactNo" runat="server" MaxLength="17"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="fltContactNo" runat="server" TargetControlID="txtContactNo"
                                                            FilterType="Numbers" />
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvContactNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtContactNo"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>--%>
                                                <%-- <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrEmail"  runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="150"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvPrimaryEmail" runat="server" ControlToValidate="txtEmail"
                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"
                                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="refEmail" SetFocusOnError="True" ControlToValidate="txtEmail"
                                                                ValidationGroup="IsRequire" runat="server" CssClass="input-notification error png_bg"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator></span>
                                                    </td>
                                                </tr>--%>
                                                <%-- <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrUrl"  runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtUrl" runat="server" MaxLength="150"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvURL" runat="server" ControlToValidate="txtUrl"
                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"
                                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="rgvtxtURL" ValidationGroup="IsRequire" ForeColor="Red"  runat="server"
                                                        ControlToValidate="txtUrl" ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" Display="Dynamic"></asp:RegularExpressionValidator></span>
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="ltrVatRegNo" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtVatRegNo" runat="server" MaxLength="150" TabIndex="4"></asp:TextBox>
                                                    </td>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrUrl" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtUrl" runat="server" MaxLength="150" TabIndex="11"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvURL" runat="server" ControlToValidate="txtUrl"
                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"
                                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="rgvtxtURL" ValidationGroup="IsRequire" ForeColor="Red"
                                                                runat="server" ControlToValidate="txtUrl" ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"
                                                                Display="Dynamic"></asp:RegularExpressionValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="ltrVatRegDate" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtVatRegDate" runat="server" onkeydown="return stopKey(event);"
                                                            Style="width: 182px !important;" SkinID="searchtextbox" TabIndex="5"></asp:TextBox>
                                                        <asp:Image ID="imgVatRegDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                            Height="20px" Width="20px" />
                                                        <ajx:CalendarExtender ID="calVatRegDate" PopupButtonID="imgVatRegDate" TargetControlID="txtVatRegDate"
                                                            runat="server" Format="dd/MMM/yyyy">
                                                        </ajx:CalendarExtender>
                                                        <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" title="Clear Date"
                                                            onclick="fnClearDate('<%= txtVatRegDate.ClientID %>');" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top">
                                                        <asp:Literal ID="ltrBillingAddress" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBillingAddress" runat="server" Rows="3" MaxLength="280" 
                                                            TextMode="MultiLine" TabIndex="6"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top">
                                                        <asp:Literal ID="ltrPosDetails" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPosDetails" runat="server" Rows="3" MaxLength="280" 
                                                            TextMode="MultiLine" TabIndex="7"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <div style="float: right; width: auto; display: inline-block;">
                                                            <asp:Button ID="btnCancel" Style="float: right; margin-left: 5px;" runat="server"
                                                                ImageUrl="~/images/cancle.png" OnClick="btnCancel_OnClick" TabIndex="12" />
                                                            <asp:Button ID="btnSave" Style="float: right; margin-left: 5px;" runat="server" ImageUrl="~/images/save.png"
                                                                ValidationGroup="IsRequire" CausesValidation="true" OnClick="btnSave_OnClick"
                                                                OnClientClick="fnDisplayCatchErrorMessage();" TabIndex="13" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
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
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnNo"
            BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="350px" Width="325px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderConfirmDeletePopup" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="ltrConfirmDeleteMsg" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYes" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClick="btnYes_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                <asp:Button ID="btnNo" runat="server" Style="display: inline;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updVendorMaster" ID="UpdateProgressVendorList"
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
