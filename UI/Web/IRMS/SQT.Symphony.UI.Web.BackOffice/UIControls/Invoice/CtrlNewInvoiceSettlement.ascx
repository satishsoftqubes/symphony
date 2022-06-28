<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlNewInvoiceSettlement.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.BackOffice.UIControls.Invoice.CtrlNewInvoiceSettlement" %>
<%@ Register Src="~/MsgBox/MsgBx.ascx" TagName="MsgBx" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    
</script>
<asp:UpdatePanel ID="updCompanyinvoice" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hfDateFormat" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="ltrMainHeader" Text="Invoice Settlement" runat="server"></asp:Literal>
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
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td width="80px">
                                                <asp:Literal ID="litSearchCompanyName" Text="Company" runat="server"></asp:Literal>
                                            </td>
                                            <td width="280px">
                                                <asp:DropDownList ID="ddlSrchCompany" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="180px">
                                                <asp:RadioButtonList ID="rdblViewType" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                                                    Width="170px">
                                                    <asp:ListItem Text="Outstanding" Value="OUTSTANDING"></asp:ListItem>
                                                    <asp:ListItem Text="All" Value="ALL" Selected="True"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btnSearchAmenities" CssClass="small_img" Style="border: 0px;
                                                    vertical-align: middle; margin: -4px 0 0 5px;" runat="server" ImageUrl="~/images/search-icon.png"
                                                    OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClick="imgbtnClearSearch_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage();" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="7">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="7">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litCompanyInvoiceList" Text="Company invoice" runat="server"></asp:Literal>
                                                    </span>
                                                </div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvCompanyInvoiceList" runat="server" AutoGenerateColumns="False"
                                                        Width="100%" ShowHeader="true" OnPageIndexChanging="gvCompanyInvoiceList_OnPageIndexChanging" OnRowDataBound="gvCompanyInvoiceList_RowDataBound"
                                                                OnRowCommand="gvCompanyInvoiceList_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHrdNo" Text="No." runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvCompanyName" Text="Company" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "CorporateID")%>'
                                                                        CommandName="SETTLEINVOICE" Text='<%#DataBinder.Eval(Container.DataItem, "CompanyName")%>' ></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvContactPersonName" Text="Contact Person" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "ContactPersonName")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvREC" Text="REC" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Agent_Receipt")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvOSTD" Text="OSTD" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "Invoice_Amount_Pending")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div style="padding: 10px;">
                                                                <b>
                                                                    <asp:Label ID="lblNoRecordFound" runat="server" Text="No record found."></asp:Label></b>
                                                            </div>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
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
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBx ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updCompanyinvoice" ID="UpdateProgressCompanyInvoice"
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
