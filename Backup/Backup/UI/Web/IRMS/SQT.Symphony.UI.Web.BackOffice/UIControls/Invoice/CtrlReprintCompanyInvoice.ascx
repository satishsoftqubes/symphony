<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlReprintCompanyInvoice.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.BackOffice.UIControls.Invoice.CtrlReprintCompanyInvoice" %>
<%@ Register Src="~/MsgBox/MsgBx.ascx" TagName="MsgBx" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function stopKey(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 8) && (node.type == "text")) { return false; }
        else if ((evt.keyCode == 9) && (node.type == "text")) { return true; }
        else if ((evt.keyCode == 46) && (node.type == "text")) { return false; }
        else { return false; }
    }
</script>
<script type="text/javascript">
    function fnCompanyInvoicePrint() {
        var hdnReservationID = document.getElementById('<%= hdnReservationID.ClientID %>').value;
        window.open("CompanyInvoicePrint.aspx?ReservationID=" + hdnReservationID, "Company Invoice", "height=600,width=800,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
    }
</script>
<asp:UpdatePanel ID="updCompanyinvoice" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnReservationID" runat="server" />
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
                                <asp:Literal ID="ltrMainHeader" Text="Reprint Company invoice" runat="server"></asp:Literal>
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
                                            <td width="215px">
                                                From&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtSearchFromDate" runat="server"
                                                    Style="width: 90px !important;" SkinID="searchtextbox" onkeydown="return stopKey(event);"></asp:TextBox>
                                                <asp:Image ID="imgSearchFromDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                    Height="20px" Width="20px" />
                                                <ajx:CalendarExtender ID="calSearchFromDate" PopupButtonID="imgSearchFromDate" TargetControlID="txtSearchFromDate"
                                                    runat="server" Format="dd-MM-yyyy">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" id="imgclearDateFrom" style="vertical-align: middle;"
                                                    title="Clear Date" onclick="fnClearDate('<%= txtSearchFromDate.ClientID %>');" />
                                                <asp:RequiredFieldValidator ID="rvfFromDate" runat="server" ControlToValidate="txtSearchFromDate"
                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireSearch"></asp:RequiredFieldValidator>
                                            </td>
                                            <td width="200px">
                                                To&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtSearchToDate" runat="server"
                                                    Style="width: 90px !important;" SkinID="searchtextbox" onkeydown="return stopKey(event);"></asp:TextBox>
                                                <asp:Image ID="imgSearchToDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                    Height="20px" Width="20px" />
                                                <ajx:CalendarExtender ID="calSearchToDate" PopupButtonID="imgSearchToDate" TargetControlID="txtSearchToDate"
                                                    runat="server" Format="dd-MM-yyyy">
                                                </ajx:CalendarExtender>
                                                <img src="../../images/clear.png" id="imgclearDateTo" style="vertical-align: middle;"
                                                    title="Clear Date" onclick="fnClearDate('<%= txtSearchToDate.ClientID %>');" />
                                                <asp:RequiredFieldValidator ID="rvfToDate" runat="server" ControlToValidate="txtSearchToDate"
                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequireSearch"></asp:RequiredFieldValidator>
                                            </td>
                                            <td width="270px">
                                                Billing Instr.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlBillingInstruction"
                                                    runat="server" SkinID="nowidth" Width="150px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                Company&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlSearchCompany" runat="server"
                                                    SkinID="nowidth" Width="170px">
                                                </asp:DropDownList>
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                    Style="border: 0px; margin: -1px 0 0 10px; vertical-align: middle;" OnClick="btnSearch_Click"
                                                    ValidationGroup="IsRequireSearch" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClick="imgbtnClearSearch_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage();" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="gvCompanyInvoiceList" runat="server" AutoGenerateColumns="False"
                                                        Width="100%" ShowHeader="true" DataKeyNames="BillingFromDate,BillingToDate,InvoiceNo,POSChargePerDay"
                                                        OnRowDataBound="gvCompanyInvoiceList_RowDataBound" OnRowCommand="gvCompanyInvoiceList_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHrdNo" Text="No." runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvInvoiceNo" runat="server" Text="Invoice No."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "InvoiceNo")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="160px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvCompanyName" Text="Company" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "CompanyName")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvReservationNo" runat="server" Text="Res. #"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvGuestName" Text="Guest Name" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "GuestFullName")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="160px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvRoomType" Text="RoomType" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvRoomNo" Text="Room No." runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#DataBinder.Eval(Container.DataItem, "DisplayRoomNo")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvCheckInDate" Text="Check In" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%--<%#DataBinder.Eval(Container.DataItem, "CheckInDate")%>--%>
                                                                    <asp:Literal ID="ltrCheckInDate" runat="server"></asp:Literal>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvCheckOutDate" Text="Check Out" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%--<%#DataBinder.Eval(Container.DataItem, "CheckOutDate")%>--%>
                                                                    <asp:Literal ID="ltrCheckOutDate" runat="server"></asp:Literal>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvBillingAmount" Text="Amount" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%--<%#DataBinder.Eval(Container.DataItem, "BillingAmount")%>--%>
                                                                    <asp:Literal ID="ltrBillingAmount" runat="server"></asp:Literal>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvAction" Text="Action" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkPrint" runat="server" Text="Print" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ReservationID")%>'
                                                                        CommandName="PRINT"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div style="padding: 10px;">
                                                                <b>
                                                                    <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label></b>
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
                    <div class="clear">
                    </div>
                </td>
            </tr>
        </table>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="gvCompanyInvoiceList" />
    </Triggers>
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
