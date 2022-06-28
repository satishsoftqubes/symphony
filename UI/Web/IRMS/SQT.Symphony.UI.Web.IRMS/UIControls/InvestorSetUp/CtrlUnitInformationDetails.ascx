<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlUnitInformationDetails.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlUnitInformationDetails" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="content" style="padding-left: 0px; width: 66.66%">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                <tr>
                    <td class="boxtopleft">
                        &nbsp;
                    </td>
                    <td class="boxtopcenter">
                        UNIT INFORMATION
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
                        <table width="100%" cellpadding="2" cellspacing="2">
                            <tr>
                                <td style="width: 50%; border-right: 1px solid #ccccce;">
                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td align="left" valign="top" style="width: 155px;">
                                                <asp:Literal ID="litInvestor" runat="server" Text="Investor Name"></asp:Literal>
                                            </td>
                                            <td align="left" valign="top" style="color: #A9A9A9;">
                                                <asp:Literal ID="litInvestorName" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <asp:Literal ID="litPropertyID" runat="server" Text="Property Name"></asp:Literal>
                                            </td>
                                            <td align="left" valign="top" style="color: #A9A9A9;">
                                                <asp:Literal ID="LitPropertyName" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <asp:Literal ID="litUnitNo" runat="server" Text="Unit No"></asp:Literal>
                                            </td>
                                            <td align="left" valign="top" style="color: #A9A9A9;">
                                                <asp:Literal ID="LitUniteNo" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litUnitType" runat="server" Text="Unit Type"></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="ltUnitType" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litSBA" runat="server" Text="SBA (sft)"></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="ltSBArea" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litUnitPrice" runat="server" Text="Unit Price"></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="litUnitPrise" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litTotalCosts" runat="server" Text="Total Purchase Value"></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="litDisplayTotalCosts" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litRatePerSqtFt" runat="server" Text="Rate Per Sft"></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="litRatePerST" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td style="width: 155px;">
                                                <asp:Literal ID="ltrDateOfBookingLabel" runat="server" Text="Date of Booking"></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="ltrDateOfBooking" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="ltrSellerCompanyLable" runat="server" Text="Seller Company"></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="ltrSellerCompany" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litDateOfPossession" runat="server" Text="Date Of Possession"></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="litDateOFPoss" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr style="display:none;">
                                            <td>
                                                <asp:Literal ID="Literal1" runat="server" Text="Is Interest Applicable"></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="litInterestRate" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr style="display:none;">
                                            <td>
                                                <asp:Literal ID="litRateOfInterest" runat="server" Text="Rate of Interest"></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="litRateOfINte" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" class="pagesubheader">
                                    Land Value
                                </td>
                                <td align="left" valign="top" class="pagesubheader">
                                    Construction Agreement
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%; border-right: 1px solid #ccccce;">
                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td style="width: 155px;">
                                                <asp:Literal ID="litAggToSellValue" runat="server" Text="Land Value"></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="ltAgreementSellValue" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litStmpDutyOnAgrToSell" runat="server" Text="Stamp Duty on Agr. to Sell"></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="litStmpDutyOnArgeToSell" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litStampDutyonSaleDeed" runat="server" Text="Stamp Duty on Sale Deed "></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="litStmpdutyonsaledeedl" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litRegistrationCharges" runat="server" Text="Registration Charges"></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="litRegistrationChrg" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litOtherCosts" runat="server" Text="Other Costs"></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="litOtherCst" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td style="width: 155px;">
                                                <asp:Literal ID="litConstructionCost" runat="server" Text="Construction Value"></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="litConstructionCostValue" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litVAT" runat="server" Text="VAT."></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="litVATValue" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litSTax" runat="server" Text="STax"></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="litSTaxValue" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="litOtherConstructorCost" runat="server" Text="Other Costs"></asp:Literal>
                                            </td>
                                            <td style="color: #A9A9A9;">
                                                <asp:Literal ID="litOtherConstructorcostValue" runat="server" Text="-"></asp:Literal>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%">
                            <tr>
                                <td align="left" valign="top" class="pagesubheader">
                                    Unit Documents
                                </td>
                            </tr>
                            <tr>
                                <td class="dTableBox">
                                    <div class="leftmarginbox_content">
                                        <asp:GridView ID="gvDocument" runat="server" AutoGenerateColumns="false" SkinID="gvNoPaging"
                                            OnRowDataBound="gvDocument_RowDataBound" OnRowCommand="gvDocument_RowCommand"
                                            ShowHeader="true" DataKeyNames="DocumentName">
                                            <Columns>
                                                <asp:BoundField DataField="Term" HeaderText="Document Name" HeaderStyle-HorizontalAlign="Left" />
                                                <%--<asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField ItemStyle-Width="60px" HeaderText="View/Download" HeaderStyle-HorizontalAlign="Left"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <%--<a id="aDocumentLink" runat="server" visible="false" target="_blank">
                                                            <asp:Image ID="imgView" ToolTip="View" runat="server" ImageUrl="~/images/View.png"
                                                                Style="float: left; width: 19px;" /></a>--%>
                                                        <asp:ImageButton ID="imgViewDoc" runat="server" BorderWidth="0px" Visible="false"
                                                            ImageUrl="~/images/View.png" CommandName="VIEWDOC" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "DocumentName")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: right;">
                                    <asp:Button ID="btnBack" runat="server" Text="Cancel" Style="float: right;"
                                        OnClick="btnBack_Click" />
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
            <div id="errormessage" class="clear" style="display: none;">
                <uc1:MsgBox ID="MessageBox" runat="server" />
            </div>
        </td>
    </tr>
</table>
