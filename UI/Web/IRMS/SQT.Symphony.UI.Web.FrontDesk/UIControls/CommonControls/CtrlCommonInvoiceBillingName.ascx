<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonInvoiceBillingName.ascx.cs" Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrInvoiceBillingName" %>
<ajx:ModalPopupExtender ID="mpeInvoiceBillingName" runat="server" TargetControlID="hdnInvoiceNameBilling"
    PopupControlID="pnlInvoiceBillingName" BackgroundCssClass="mod_background" CancelControlID="btnInvoiceCancel">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnInvoiceNameBilling" runat="server" />
<asp:Panel ID="pnlInvoiceBillingName" runat="server" Width="330px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="litQuickPostHeader" runat="server" Text="Invoice Billing Name"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2">
               <tr>
                    <td><asp:Literal ID="litInvoiceTo" runat="server" Text="Invoice To"></asp:Literal></td>
                    <td><asp:TextBox ID="txtInvoiceTo" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td><asp:Literal ID="litInvoiceContact" runat="server" Text="Contact"></asp:Literal></td>
                    <td><asp:TextBox ID="txtInvoiceContact"  runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td><asp:Literal ID="litInvoiceAddress" runat="server" Text="Address"></asp:Literal></td>
                    <td><asp:TextBox ID="txtInvoiceAddress"  runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td><asp:Literal ID="litInvoiceZipCode" runat="server" Text="ZipCode"></asp:Literal></td>
                    <td><asp:TextBox ID="txtInvoiceZipCode"  runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td><asp:Literal ID="litInvoiceCity" runat="server" Text="City"></asp:Literal></td>
                    <td><asp:TextBox ID="txtInvoiceCity" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td><asp:Literal ID="litInvoiceState" runat="server" Text="State"></asp:Literal></td>
                    <td><asp:TextBox ID="txtInvoiceState" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td><asp:Literal ID="litInvoiceCountry" runat="server" Text="Country"></asp:Literal></td>
                    <td><asp:TextBox ID="txtInvoiceCountry"  runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td align="center" colspan="2"><asp:Button ID="btnInvoiceSave" Style="display: inline;" runat="server" Text="Save" />
                     <asp:Button ID="btnInvoiceCancel" Style="display: inline;" runat="server" Text="Cancel"/></td>
                </tr>



            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>