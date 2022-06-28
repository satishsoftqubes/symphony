<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonAddServices.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCommonAddServices" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function pageLoad(sender, args) {
//        $('#<%=txtServiceTime.ClientID %>').timepicker({ ampm: false });

        $("#tabs").tabs();

        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });

    }

    function fnClearServiceDate(para1) {
        document.getElementById(para1).value = '';
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<ajx:ModalPopupExtender ID="mpeAddServices" runat="server" TargetControlID="hdnServices"
    PopupControlID="pnlServices" BackgroundCssClass="mod_background" CancelControlID="btnServiceCancel">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnServices" runat="server" />
<asp:Panel ID="pnlServices" runat="server" Width="825px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="litAddServices" runat="server" Text="Add Services"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                <tr>
                    <td colspan="2" width="320">
                        <div style="width: 180px; float: left;">
                            <asp:RadioButtonList ID="rdblServicePackage" AutoPostBack="true" OnSelectedIndexChanged="rdblServicePackage_SelectedIndexChanged"
                                runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Services" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Packages" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div style="float: left; margin-top: 7px;">
                            <asp:DropDownList ID="ddlServicesAndPackages" runat="server" SkinID="nowidth" Style="width: 110px;">
                                <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                <asp:ListItem Text="Tea" Value="Tea"></asp:ListItem>
                                <asp:ListItem Text="Coffe" Value="Coffe"></asp:ListItem>
                                <asp:ListItem Text="Cold Drink" Value="Cold Drink"></asp:ListItem>
                            </asp:DropDownList>
                            <span>
                                <asp:RequiredFieldValidator ID="rfvServicesAndPackages" InitialValue="00000000-0000-0000-0000-000000000000"
                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                    ValidationGroup="AddService" ControlToValidate="ddlServicesAndPackages" Display="Static">
                                </asp:RequiredFieldValidator>
                            </span>
                        </div>
                    </td>
                    <td style="width: 50px !important;" class="isrequire">
                        <asp:Literal ID="litDate" runat="server" Text="Date"></asp:Literal>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtServiceDate" runat="server" SkinID="nowidth" Style="width: 100px;"></asp:TextBox>
                        <asp:Image ID="imgCalServiceDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                            Height="20px" Width="20px" />
                        <ajx:CalendarExtender ID="calExtServiceDate" PopupButtonID="imgCalServiceDate" TargetControlID="txtServiceDate"
                            runat="server" Format="dd/MMM/yyyy">
                        </ajx:CalendarExtender>
                        <img src="../../images/clear.png" id="imgClrExt" style="vertical-align: middle;"
                            title="Clear Date" onclick="fnClearServiceDate('<%= txtServiceDate.ClientID %>');" />
                        <span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                runat="server" ValidationGroup="AddService" ControlToValidate="txtServiceDate"
                                Display="Static">
                            </asp:RequiredFieldValidator>
                        </span>
                        <asp:TextBox ID="txtServiceTime" runat="server" Style="width: 50px !important;" MaxLength="5"></asp:TextBox>
                        <span>
                            <asp:RequiredFieldValidator ID="rfvServiceTime" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                runat="server" ValidationGroup="AddService" ControlToValidate="txtServiceTime"
                                Display="Static">
                            </asp:RequiredFieldValidator>
                        </span>
                        <ajx:FilteredTextBoxExtender ID="ftServiceTime" runat="server" TargetControlID="txtServiceTime"
                            FilterType="Custom, Numbers" ValidChars=":0123456789" />
                    </td>
                </tr>
                <tr>
                    <td class="isrequire" style="width: 80px !important;">
                        <asp:Literal ID="litServiceFrequency" runat="server" Text="Frequency"></asp:Literal>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlServiceFrequency" runat="server" SkinID="nowidth" Style="width: 125px;">
                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                            <asp:ListItem Text="Daily" Value="Daily"></asp:ListItem>
                            <asp:ListItem Text="Once" Value="Daily"></asp:ListItem>
                            <asp:ListItem Text="Weekly" Value="Weekly"></asp:ListItem>
                            <asp:ListItem Text="Monthly" Value="Monthly"></asp:ListItem>
                        </asp:DropDownList>
                        <span>
                            <asp:RequiredFieldValidator ID="rfvServiceFrequency" InitialValue="00000000-0000-0000-0000-000000000000"
                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                ValidationGroup="AddService" ControlToValidate="ddlServiceFrequency" Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </span>
                    </td>
                    <td style="width: 40px !important;" class="isrequire">
                        <asp:Literal ID="ltrQuentity" runat="server" Text="Qty"></asp:Literal>
                    </td>
                    <td class="isrequire" style="width: 90px !important;">
                        <asp:TextBox ID="txtQty" runat="server" Style="width: 60px;"></asp:TextBox>
                        <ajx:FilteredTextBoxExtender ID="fteQty" runat="server" TargetControlID="txtQty"
                            FilterMode="ValidChars" ValidChars="1234567890">
                        </ajx:FilteredTextBoxExtender>
                        <span>
                            <asp:RequiredFieldValidator ID="rfvQty" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                runat="server" ValidationGroup="AddService" ControlToValidate="txtQty" Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </span>
                    </td>
                    <td class="isrequire" style="width: 40px !important;">
                        <asp:Literal ID="litAmount" runat="server" Text="Amount"></asp:Literal>
                    </td>
                    <td>
                        <div style="float: left; padding-right: 10px;">
                            <asp:TextBox ID="txtAmount" runat="server" Style="width: 100px; text-align: right;"></asp:TextBox>
                            <ajx:FilteredTextBoxExtender ID="ftbAmount" runat="server" TargetControlID="txtAmount"
                                FilterMode="ValidChars" ValidChars="1234567890.">
                            </ajx:FilteredTextBoxExtender>
                            <span>
                                <asp:RequiredFieldValidator ID="rfvAmount" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                    runat="server" ValidationGroup="AddService" ControlToValidate="txtAmount" Display="Static">
                                </asp:RequiredFieldValidator>
                            </span>
                        </div>
                        <div style="float: left;">
                            <asp:Button ID="btnAddServices" runat="server" Text="+" ValidationGroup="AddService"
                                OnClick="btnAddServices_Click" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" width="100%" style="height: 150px; overflow: auto;">
                        <div class="box_head">
                            <span>
                                <asp:Literal ID="litServiceList" runat="server" Text="Service List"></asp:Literal>
                            </span>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="box_content">
                            <asp:GridView ID="gvServiceList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                Width="100%" OnRowCommand="gvServiceList_RowCommand">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrService" runat="server" Text="Service"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Service")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrServiceDate" runat="server" Text="Date"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrServiceTime" runat="server" Text="Time"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Time")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrServicesNotes" runat="server" Text="Notes"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Notes")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrQty" runat="server" Text="Qty"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Qty")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrAmount" runat="server" Text="Amount"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Amount")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrServiceRate" runat="server" Text="Srv Rate"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "ServiceRate")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrTax" runat="server" Text="Tax"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Tax")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrSrvTax" runat="server" Text="Srv Tax"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "SrvTax")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrTotal" runat="server" Text="Total"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Total")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblActions" runat="server" Text="Actions"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPopUp" runat="server" Text="Actions"></asp:Label>
                                            <ajx:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lblPopUp"
                                                PopupControlID="Panel2" PopupPosition="Left">
                                            </ajx:HoverMenuExtender>
                                            <asp:Panel ID="Panel2" runat="server" Style="visibility: hidden; opacity: 100%">
                                                <div class="actionsbuttons_hovermenu">
                                                    <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                        <tr>
                                                            <td class="actionsbuttons_hover_lettmenu">
                                                            </td>
                                                            <td class="actionsbuttons_hover_centermenu">
                                                                <ul>
                                                                    <li>
                                                                        <asp:LinkButton ID="lnkPost" runat="server" Style="background: none !important; border: none;"
                                                                            ToolTip="Post" CommandName="POSTDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                    </li>
                                                                    <li>
                                                                        <asp:LinkButton ID="lnkDelete" runat="server" Style="background: none !important;
                                                                            border: none;" ToolTip="Delete" CommandName="DELETEDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                    </li>
                                                                </ul>
                                                            </td>
                                                            <td class="actionsbuttons_hover_rightmenu">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </asp:Panel>
                                            <%--<asp:Label ID="lblPopUp" runat="server" Text="Actions"></asp:Label>
                                            <ajx:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lblPopUp"
                                                PopupControlID="Panel2" PopupPosition="Left">
                                            </ajx:HoverMenuExtender>
                                            <asp:Panel ID="Panel2" runat="server" Style="visibility: hidden; opacity: 100%">
                                                <div>
                                                    <div>
                                                        <asp:LinkButton ID="lnkPost" runat="server" ToolTip="Post" CommandName="POSTDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                    </div>
                                                    <div>
                                                        <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" CommandName="DELETEDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </asp:Panel>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div style="padding: 10px;">
                                        <b>
                                            <asp:Label ID="lblNoRecordFoundForService" runat="server" Text="No Record Found."></asp:Label>
                                        </b>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="right" style="background-color: #DCDDDF; color: #0083CE; font-size: 15px;
                        font-weight: bold; padding: 9px;">
                        <asp:Literal ID="litTotalServiceRate" runat="server" Text="0.00"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 8px;" align="center" colspan="6">
                        <asp:Button ID="btnServiceSave" runat="server" Style="display: inline; padding-right: 10px;"
                            OnClientClick="fnDisplayCatchErrorMessage();" ValidationGroup="AddService" Text="Save" />
                        <asp:Button ID="btnServiceSaveAndClose" runat="server" Style="display: inline;" Text="Save And Close"
                            ValidationGroup="AddService" />
                        <asp:Button ID="btnServiceCancel" runat="server" Style="display: inline;" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
