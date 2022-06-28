<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlChartOfAccount.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.BackOffice.UIControls.AccountSetup.CtrlChartOfAccount" %>
<%@ Register Src="../../MsgBox/MsgBx.ascx" TagName="MsgBx" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnAlphabatsClick(alpha) {
        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hfSelectedAlphabet.ClientID %>').value = alpha;

        __doPostBack('ctl00$ContentPlaceHolder1$ctrlChartOfAccount$lnkAlphabet', '');
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
<script language="javascript">

    function openViewer() {
        var Preview = '<%=IsPreview%>';
        window.open("../../ReportFiles/frmViewer.aspx?preview=" + Preview);
    }
</script>
<asp:UpdatePanel ID="updChartOfAccount" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                Ledger Accounts&nbsp;<asp:Literal ID="litAccountCount" runat="server"></asp:Literal>
                                <div style="visibility: hidden;">
                                    <asp:LinkButton ID="lnkAlphabet" runat="server" OnClick="lnkAlphabet_OnClick"></asp:LinkButton>
                                </div>
                                <asp:HiddenField ID="hfSelectedAlphabet" runat="server" />
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
                                <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td class="alpha">
                                            <a href="#" onclick="fnAlphabatsClick('ALL');">ALL</a>&nbsp;&nbsp;|&nbsp; <a href="#"
                                                onclick="fnAlphabatsClick('A');">A</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('B');">
                                                    B</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('C');">C</a>&nbsp;&nbsp;|&nbsp;
                                            <a href="#" onclick="fnAlphabatsClick('D');">D</a>&nbsp;&nbsp;|&nbsp; <a href="#"
                                                onclick="fnAlphabatsClick('E');">E</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('F');">
                                                    F</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('G');">G</a>&nbsp;&nbsp;|&nbsp;
                                            <a href="#" onclick="fnAlphabatsClick('H');">H</a>&nbsp;&nbsp;|&nbsp; <a href="#"
                                                onclick="fnAlphabatsClick('I');">I</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('J');">
                                                    J</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('K');">K</a>&nbsp;&nbsp;|&nbsp;
                                            <a href="#" onclick="fnAlphabatsClick('L');">L</a>&nbsp;&nbsp;|&nbsp; <a href="#"
                                                onclick="fnAlphabatsClick('M');">M</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('N');">
                                                    N</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('O');">O</a>&nbsp;&nbsp;|&nbsp;
                                            <a href="#" onclick="fnAlphabatsClick('P');">P</a>&nbsp;&nbsp;|&nbsp; <a href="#"
                                                onclick="fnAlphabatsClick('Q');">Q</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('R');">
                                                    R</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('S');">S</a>&nbsp;&nbsp;|&nbsp;
                                            <a href="#" onclick="fnAlphabatsClick('T');">T</a>&nbsp;&nbsp;|&nbsp; <a href="#"
                                                onclick="fnAlphabatsClick('U');">U</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('V');">
                                                    V</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('W');">W</a>&nbsp;&nbsp;|&nbsp;
                                            <a href="#" onclick="fnAlphabatsClick('X');">X</a>&nbsp;&nbsp;|&nbsp; <a href="#"
                                                onclick="fnAlphabatsClick('Y');">Y</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('Z');">
                                                    Z</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="ltrName" runat="server" Text="Name"></asp:Literal>
                                                        &nbsp;&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchAccountName" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litSGroup" runat="server" Text="Account Group"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSGroup" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                            Style="border: 0px; vertical-align: middle; margin-top: 0px; margin-left: 5px;"
                                                            OnClick="btnSearch_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="pageinfodivider">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%if (IsInsert)
                                              { %>
                                            <div class="ResetSuccessfully">
                                                <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                    <img src="~/images/success.png" />
                                                </div>
                                                <div>
                                                    <asp:Label ID="lblAccountMsg" runat="server"></asp:Label></div>
                                                <div style="height: 10px;">
                                                </div>
                                            </div>
                                            <% }%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="middle">
                                            <asp:Button ID="btnAddUp" runat="server" Text="Add New" OnClick="btnAdd_Click" Style="float: right;"
                                                OnClientClick="fnDisplayCatchErrorMessage()" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox" style="padding: 10px 0px;">
                                            <asp:GridView ID="grdAccountList" runat="server" AutoGenerateColumns="False" Width="100%"
                                                OnRowCommand="grdAccountList_RowCommand" OnRowDataBound="grdAccountList_RowDataBound"
                                                DataKeyNames="AcctNo,AcctName" OnPageIndexChanging="grdAccountList_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="AcctNo" HeaderText="Account No." HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" Visible="false" ItemStyle-Width="75px" />
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblAcctName" runat="server" Text="Account"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkAccountName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AcctName")%>'
                                                                CommandName="EDITCMD" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "AcctID")%>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="GroupName" HeaderText="Group" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="125px" />
                                                    <asp:BoundField DataField="BalancyType_Term" HeaderText="Bal. Type" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px" />
                                                    <asp:BoundField DataField="OpeningBalance" HeaderText="Op. Balance" HeaderStyle-HorizontalAlign="Right"
                                                        ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px" Visible="false" />
                                                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblCurrentBalance" runat="server" Text="Cur. Balance"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCurrBalance" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="IsDefaultAccount" HeaderText="Default" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="0px" />
                                                    <%--<asp:TemplateField HeaderText="View/Edit" ItemStyle-Width="18px" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" ToolTip="Edit" CommandName="EDITCMD" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "AcctID")%>'
                                                                runat="server" ImageUrl="~/images/edit.png" Style="border: 0px; vertical-align: middle;
                                                                margin-top: 3px; margin-right: 7px;" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="18px" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <a href="#" style="border: 0px;">
                                                                <asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandName="DELETECMD" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "AcctID")%>'
                                                                    runat="server" ImageUrl="~/images/delete_icon.png" Style="border: 0px; vertical-align: middle;
                                                                    margin-top: 1px; margin-right: 7px;" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Statement" ItemStyle-Width="18px" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <a href="#" style="border: 0px;">
                                                                <asp:ImageButton ID="btnStmt" ToolTip="Statement" CommandName="RPTCMD" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "AcctID")%>'
                                                                    runat="server" ImageUrl="~/images/viewdoc2222.png" Style="border: 0px; vertical-align: middle;
                                                                    margin-top: 1px; margin-right: 7px;" />
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
                                    <tr>
                                        <td align="right" valign="middle">
                                            <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" Style="float: right;"
                                                OnClientClick="fnDisplayCatchErrorMessage()" />
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
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="mepConfirmDelete" runat="server" TargetControlID="hfConfirmDelete"
             PopupControlID="pnlConfirmDelete" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfConfirmDelete" runat="server" />
        <asp:Panel ID="pnlConfirmDelete" runat="server" Width="400px">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="Literal2" Text="Message" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align:center;" align="center">
                                <div style="text-align:center;">
                                    <asp:Button ID="btnDeleteOK" Text="Yes" Style="margin-left: 5px; display: inline;" runat="server"
                                        OnClick="btnDeleteOK_OnClick" ImageUrl="~/images/save.png" />
                                    <asp:Button ID="btnDeleteCancel" runat="server" Text="Cancel" Style=" margin-left: 5px; display: inline;" OnClick="btnDeleteCancel_OnClick" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <div id="errormessage" class="clear">
            <uc1:MsgBx ID="MessageBox" runat="server" />
        </div>
        <ajx:ModalPopupExtender ID="mpeStatement" runat="server" TargetControlID="hdnStmt"
            CancelControlID="btnCancelBankDetail" PopupControlID="pnlStmt" BackgroundCssClass="mod_background"
            BehaviorID="mpeStmt">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnStmt" runat="server" />
        <asp:Panel ID="pnlStmt" runat="server" Width="800px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="Literal1" Text="Account Statement" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td style="padding-bottom: 15px;">
                                <div style="padding-bottom: 5px;">
                                    <h1>
                                        <asp:Literal ID="litHeading" Text="Statement for Account : " runat="server"></asp:Literal>
                                    </h1>
                                </div>
                                <table cellpadding="2" cellspacing="2" width="100%">
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litStartDate" runat="server" Text="From"></asp:Literal>
                                        </td>
                                        <td style="width: 300px;">
                                            <asp:TextBox ID="txtStartDate" runat="server" onkeypress="return false;" SkinID="Search"></asp:TextBox>
                                            <asp:Image ID="imgSColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                Height="20px" Width="20px" />
                                            <ajx:CalendarExtender ID="calStartDate" runat="server" TargetControlID="txtStartDate"
                                                PopupButtonID="imgSColor">
                                            </ajx:CalendarExtender>
                                        </td>
                                        <td style="width: 50px;">
                                            <asp:Literal ID="litEndDate" runat="server" Text="To"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEndDate" runat="server" onkeypress="return false;" SkinID="Search"></asp:TextBox>
                                            <asp:Image ID="imgEColor" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                Height="20px" Width="20px" />
                                            <ajx:CalendarExtender ID="calEndDate" runat="server" TargetControlID="txtEndDate"
                                                PopupButtonID="imgEColor">
                                            </ajx:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" style="width: 100px;">
                                            <asp:Literal ID="litCounterNo" runat="server" Text="Counter No"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCounter" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" style="width: 100px;">
                                            <asp:Literal ID="ltUser" runat="server" Text="User"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlUser" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <div style="float: Left;">
                                    <asp:Button ID="btnPreview" Text="View" Style="float: left; margin-left: 5px;" runat="server"
                                        ImageUrl="~/images/save.png" OnClick="btnPreview_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                    <asp:ImageButton ID="imgbtnPDF" Text="" Style="float: left; margin-left: 5px;" ToolTip="ExportToPDF"
                                        runat="server" ImageUrl="~/images/report_pdf.png" OnClick="imgbtnPDF_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                    <asp:ImageButton ID="imgbtnXLSX" Text="" Style="float: left; margin-left: 5px;" ToolTip="ExportToXLSX"
                                        runat="server" ImageUrl="~/images/report_xlsx.png" OnClick="imgbtnXLSX_Click"
                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                    <asp:Button ID="btnCancelBankDetail" runat="server" Text="Cancel" Style="float: left;
                                        margin-left: 5px; display: inline;" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnPreview" />
        <asp:PostBackTrigger ControlID="imgbtnPDF" />
        <asp:PostBackTrigger ControlID="imgbtnXLSX" />
    </Triggers>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="updChartOfAccount" ID="UpdateProgressChannelPartnerList"
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
