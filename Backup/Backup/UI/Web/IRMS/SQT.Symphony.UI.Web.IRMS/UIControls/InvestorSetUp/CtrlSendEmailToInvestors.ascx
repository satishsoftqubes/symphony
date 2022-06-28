<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSendEmailToInvestors.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlSendEmailToInvestors" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script type="text/javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<script type="text/javascript">
    function SelectAll(id, col) {
        var grid = document.getElementById("<%= grdInvestorList.ClientID %>");
        var cell;
        var objView = 'ContentPlaceHolder1_CtrlSendEmailToInvestors1_grdInvestorList_chkViewSelectAll';
        if (grid.rows.length > 0) {
            for (i = 1; i < grid.rows.length; i++) {
                var cell1 = grid.rows[i].cells[0];
                if (col == '1') {
                    for (j = 0; j < cell1.childNodes.length; j++) {
                        if (cell1.childNodes[j].type == "checkbox") {
                            cell1.childNodes[j].checked = document.getElementById(id).checked;
                        }
                    }
                }
            }
        }
    }
</script>
<script type="text/javascript">
    function OpenInvestorList() {
        alert('Test');
        $find('mpeInvestorListTosendEmail').show();
    }

    function GetSelectedValues() {
        var EmailAddressToSend = '';
        var grid = document.getElementById("<%= grdInvestorList.ClientID %>");
        if (grid.rows.length > 0) {
            for (i = 1; i < grid.rows.length; i++) {
                var cellSelectAll = grid.rows[i].cells[0];
                for (j = 0; j < cellSelectAll.childNodes.length; j++) {
                    if (cellSelectAll.childNodes[j].type == "checkbox" && cellSelectAll.childNodes[j].checked == true) {
                        var strReplaceEmail = grid.rows[i].cells[3].innerHTML;
                        if (strReplaceEmail.replace(/&nbsp;/g, '') != '') {
                            EmailAddressToSend = EmailAddressToSend + '|' + strReplaceEmail.replace(/&nbsp;/g, '');
                        }
                    }
                }
            }
        }
        if (EmailAddressToSend != '') {
            alert(EmailAddressToSend);
            SendEmailToinvestor(EmailAddressToSend);
        }
    }

    function SendEmailToinvestor(InvestorEmailAddress) {
        var pageUrl = '<%=ResolveUrl("~/Applications/Investors/SendEmailToInvestor.asmx")%>';
        var subjectForEmailToPass = 'Investor Email';
        var CompanyID = document.getElementById('<%= hdnComapnyIDForSendEmail.ClientID %>').value;
        alert(CompanyID);
        //var CompanyID = '14F1A0DC-3A5B-4E7E-9869-96979A03EA3A';
        var pdata = { "EmailAddress": InvestorEmailAddress, "subjectForEmail": subjectForEmailToPass, "CompanyIDToPass": CompanyID };
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: pageUrl + "/SendMailTo",
            data: JSON.stringify(pdata),
            dataType: "json",
            async: true,
            success: OnSuccessCall,
            error: OnErrorCall
        });
    }
    function OnSuccessCall(response) {
        alert(response.d);
    }
    function OnErrorCall(response) {
        alert(response.d);
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
<asp:UpdatePanel ID="updInvestorListForSendEmail" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdnComapnyIDForSendEmail" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <div>
                                    <div style="display: inline; float: left;">
                                        INVESTORS&nbsp;<asp:Literal ID="litInvestorsCount" runat="server"></asp:Literal>
                                        <div style="visibility: hidden;">
                                            <asp:LinkButton ID="lnkAlphabet" runat="server" OnClick="lnkAlphabet_OnClick"></asp:LinkButton>
                                        </div>
                                        <asp:HiddenField ID="hfSelectedAlphabet" runat="server" />
                                    </div>
                                    <div style="display: inline; float: right; padding-right: 10px;">
                                        <asp:LinkButton ID="lnkInvestorStatus" runat="server" Text="Investor Status" PostBackUrl="~/Applications/Investors/InvestorStatus.aspx"
                                            ForeColor="#0067a4"></asp:LinkButton>
                                    </div>
                                </div>
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
                                    <tr style="display: none;">
                                        <td align="left" valign="top">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td class="alpha" colspan="4">
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
                                                    <td style="width: 150px;">
                                                        <asp:Literal ID="litSInvestorName" runat="server" Text="Name"></asp:Literal>&nbsp;&nbsp;
                                                    </td>
                                                    <td style="width: 200px;">
                                                        <asp:TextBox ID="txtSInvestorName" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 105px;">
                                                        <asp:Literal ID="litSLocation" runat="server" Text="City"></asp:Literal>&nbsp;&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSLocation" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px;">
                                                        <asp:Literal ID="Literal1" runat="server" Text="Channel Partner Firm"></asp:Literal>&nbsp;&nbsp;
                                                    </td>
                                                    <td style="width: 200px;">
                                                        <asp:TextBox ID="txtSearchChannelPartnerFirm" runat="server" AutoPostBack="true"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 105px;">
                                                        <asp:Literal ID="Literal2" runat="server" Text="Executive Name"></asp:Literal>&nbsp;&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchExecutiveName" runat="server" Style="width: 220px !important;"></asp:TextBox>
                                                        <asp:ImageButton ID="btnSearch" runat="server" Style="border: 0px; vertical-align: middle;
                                                            margin-top: 0px; margin-left: 5px;" ImageUrl="~/images/search-icon.png" OnClick="btnSearch_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="pageinfodivider">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtInvSendEmail" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnSelectInvestor" runat="server" Text="Select Investor" OnClientClick="return OpenInvestorList();" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <CKEditor:CKEditorControl ID="ckInvEmailBody" runat="server">
                                            </CKEditor:CKEditorControl>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox" style="padding: 10px 0px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">
                                            <asp:Button ID="btnSendEmailToInvestors" runat="server" Text="Send Email" OnClientClick="return GetSelectedValues();" />
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
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="mpeInvestorListTosendEmail" runat="server" TargetControlID="hdnInvListEmail"
            PopupControlID="pnlInvListEmail" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnInvListEmail" runat="server" />
        <asp:Panel ID="pnlInvListEmail" runat="server" Style="display: none;">
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
                                <asp:HyperLink ID="HyperLink1" runat="server">
                                    <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                        ID="Image1" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div style="height: 550px !important; overflow: auto;" class="dTableBox">
                                <asp:GridView ID="grdInvestorList" runat="server" AutoGenerateColumns="False" Width="100%"
                                    OnRowDataBound="grdInvestorList_RowDataBound" SkinID="gvNoPaging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select" ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left">
                                            <HeaderTemplate>
                                                <asp:Label ID="lView" runat="server" Text="Select"></asp:Label>
                                                <asp:CheckBox ID="chkViewSelectAll" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkIsView" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FullName" HeaderText="Name" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200px" />
                                        <asp:TemplateField HeaderText="Mobile No" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                            ItemStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Literal ID="litMobileNo" runat="server"></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="EMail" HeaderText="Email" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px" />
                                        <asp:BoundField DataField="CityName" HeaderText="City" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" />
                                        <asp:TemplateField HeaderText="Units" ItemStyle-Width="15px" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBtn" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "TotalUnit")%>'
                                                    CommandName="GETUNIT" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorID")%>'></asp:LinkButton>
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
                            </div>
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
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updInvestorListForSendEmail" ID="UpdateProgressInvestorListForSendEmail"
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
