<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlFolioAssignPackage.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio.CtrlFolioAssignPackage" %>
\<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnClearDate(Date) {
        document.getElementById(Date).value = "";
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<ajx:ModalPopupExtender ID="mpeFolioAssignPackage" runat="server" TargetControlID="hdnFolioAssignPackage"
    PopupControlID="pnlFolioAssignPackage" BackgroundCssClass="mod_background" CancelControlID="imgInvoiceCancel">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnFolioAssignPackage" runat="server" />
<asp:Panel ID="pnlFolioAssignPackage" runat="server" Width="800px"
    Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
           <div style="display:inline;"> <span>
                <asp:Literal ID="litQuickPostHeader" runat="server" Text="Assign Package"></asp:Literal></span></div>
                  <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                                <asp:ImageButton ID="imgInvoiceCancel" runat="server" ImageUrl="~/images/closepopup.png"
                                    Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                            </div>
                
                </div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td colspan="2" style="padding-left: 0px;">
                        <table cellpadding="2" cellspacing="2" width="100%" style="border: 1px solid #ccccce !important;">
                            <tr>
                                <td style="width: 120px;";">
                                    <asp:Literal ID="litAssingPackageReservationNo" runat="server" Text="Reservation No."></asp:Literal> :
                                </td>
                                <td>
                                    <asp:Literal ID="litDisplayAssingPackageReservationNo" runat="server" Text="30311"></asp:Literal>
                                </td>
                                <td style="width: 120px;">
                                    <asp:Literal ID="litAssingPackageName" runat="server" Text="Name"></asp:Literal> :
                                </td>
                                <td>
                                    <asp:Literal ID="litDisplayAssingPackageJacName" runat="server" Text="Sognetur"></asp:Literal>
                                </td>
                                <td style="width: 120px;"">
                                    <asp:Literal ID="litAssingPackageUnitNo" runat="server" Text="Room No."></asp:Literal> :
                                </td>
                                <td>
                                    <asp:Literal ID="litDisplayAssingPackageUnitNo" runat="server" Text="37 - DBSTD"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 120px;">
                                    <asp:Literal ID="litAssingPackageFolioNo" runat="server" Text="Folio No."></asp:Literal> :
                                </td>
                                <td>
                                    <asp:Literal ID="litDisplayAssingPackageFolioNo" runat="server" Text="30311"></asp:Literal>
                                </td>
                                <td style="width: 120px;">
                                    <asp:Literal ID="litAssingPackageGruopeName" runat="server" Text="Gruope Name"></asp:Literal> :
                                </td>
                                <td>
                                    <asp:Literal ID="litDisplayAssingPackageJacGruope" runat="server" Text="Sognetur"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; border: 1px solid #ccccce !important; height: 250px;
                        overflow: auto; width:300px;">
                        <div class="box_head">
                            <span>
                                <asp:Literal ID="litAssingPackageItemList" runat="server" Text="Item List"></asp:Literal>
                            </span>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="box_content">
                            <asp:GridView ID="gvAssignPackage" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                Width="100%" SkinID="gvNoPaging">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrPackageName" runat="server" Text="Package Name"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "PackageName")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblGvHdrCost" runat="server" Text="Cost"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "Cost")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div style="padding: 10px;">
                                        <b>
                                            <asp:Label ID="lblItemNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                        </b>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </td>
                    <td>
                        <table width="100%" cellpadding="2" cellspacing="2" style="vertical-align: top; border: 1px solid #ccccce !important;">
                            <tr>
                                <td>
                                    <asp:Literal ID="litAssignPackageSrvPkg" runat="server" Text="SRV PKG"></asp:Literal>
                                    <asp:DropDownList ID="ddlAssignPackageSrvPkg" runat="server" Style="width: 150px !important;">
                                        <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                        <asp:ListItem Text="HP Conference 1" Value="HP Conference 1"></asp:ListItem>
                                        <asp:ListItem Text="HP Conference 2" Value="HP Conference 2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <span>
                                        <asp:RequiredFieldValidator ID="rfvAssignPackageSrvPkg" InitialValue="00000000-0000-0000-0000-000000000000"
                                            SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server" ValidationGroup="IsRequire" ControlToValidate="ddlAssignPackageSrvPkg" Display="Static">
                                        </asp:RequiredFieldValidator>
                                    </span>
                                    <asp:TextBox ID="txtAssignPackageDate" onkeypress="return false;" runat="server"
                                        Style="width: 100px !important;"></asp:TextBox>
                                    <span>
                                         <asp:RequiredFieldValidator ID="rfvAssignPackageDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                             runat="server" ValidationGroup="IsRequire" ControlToValidate="txtAssignPackageDate" Display="Static">
                                         </asp:RequiredFieldValidator>
                                    </span>
                                    <asp:Image ID="imgAssignPackageSDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                        Height="20px" Width="20px" />
                                    <ajx:CalendarExtender ID="calAssignPackageSDate" PopupButtonID="imgAssignPackageSDate"
                                        TargetControlID="txtAssignPackageDate" runat="server" Format="dd/MMM/yyyy">
                                    </ajx:CalendarExtender>
                                    <img src="../../images/clear.png" id="imgAD" style="vertical-align: middle;" title="Clear Date"
                                        onclick="fnClearDate('<%= txtAssignPackageDate.ClientID %>');" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnAssignPackageAdd" runat="server" Text="Add" OnClick="btnAssignPackageAdd_OnClick"
                                         ValidationGroup="IsRequire" Style="display: inline;"/>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 250px; overflow: auto; vertical-align: top;">
                                    <div class="box_head">
                                        <span>
                                            <asp:Literal ID="litAssignPackagePackageList" runat="server" Text="Package List"></asp:Literal>
                                        </span>
                                    </div>
                                    <div class="clear">
                                    </div>
                                    <div class="box_content" style="width: 480px;">
                                        <asp:GridView ID="gvAssignPackageItem" runat="server" AutoGenerateColumns="false"
                                            ShowHeader="true" Width="100%" SkinID="gvNoPaging">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrItemName" runat="server" Text="Item Name"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "ItemName")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrAmount" runat="server" Text="Amount"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "Amount")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrQty" runat="server" Text="QTY"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "Qty")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrTotal" runat="server" Text="Total"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "Total")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="padding: 10px;">
                                                    <b>
                                                        <asp:Label ID="lblPackageNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                    </b>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAssignPackageSave" OnClick="btnAssignPackageSave_Onclick" Style="display: inline;"
                            runat="server" Text="Save" ValidationGroup="IsRequire" />
                        
                    </td>
                    <td style="float: right; background-color: #DCDDDF; color: #0083CE; font-size: 15px;
                        font-weight: bold; padding: 9px; width: 250px; text-align: right;">
                      
                        <asp:Literal ID="litAssignPackageTotal" runat="server" Text="0.00"></asp:Literal>
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
