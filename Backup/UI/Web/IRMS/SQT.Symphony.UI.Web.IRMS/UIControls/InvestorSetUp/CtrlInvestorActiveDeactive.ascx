<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInvestorActiveDeactive.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlInvestorActiveDeactive" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="../AlphaBet/CtrlAlphaBet.ascx" TagName="CtrlAlphaBet" TagPrefix="uc2" %>
<script language="javascript" type="text/javascript">

    function fnAlphabatsClick(alpha) {
        document.getElementById('<%= hfSelectedAlphabet.ClientID %>').value = alpha;

        __doPostBack('ctl00$ContentPlaceHolder1$CtrlActiveDeactiveInvestor$lnkAlphabet', '');
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function pageLoad(sender, args) {

        $(document).ready(function () {
            $("#<%=txtSLocation.ClientID%>").autocomplete('../SetUp/CityAutoComplete.ashx');
            $("#<%=txtSInvestorName.ClientID%>").autocomplete('InvestorAutoComplete.ashx');
        });
    }
</script>
<script type="text/javascript">
    function fnInvestorListPrint() {
        window.open("InvestorActDeactPrint.aspx", "Investor List", "height=600,width=1000,status=1,toolbar=no,menubar=no,scrollbars=1,location=0");
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
    
    .autocomplete_completionListElement
    {
        visibility: hidden;
        margin: 0px !important;
        background-color: inherit;
        color: windowtext;
        border: buttonshadow;
        border-width: 1px;
        border-style: solid;
        cursor: 'default';
        overflow: auto;
        height: auto;
        text-align: left;
        list-style-type: none;
    }
    .autocomplete_completionListElement li a:hover
    {
        color: White !important;
    }
    /* AutoComplete highlighted item */
    
    .autocomplete_highlightedListItem
    {
        background-color: #0A246A;
        color: white;
        padding: 1px;
    }
    
    /* AutoComplete item */
    
    .autocomplete_listItem
    {
        background-color: window;
        color: windowtext;
        padding: 1px;
    }
</style>
<asp:UpdatePanel ID="updInvestorList" runat="server">
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
                                INVESTORS&nbsp;<asp:Literal ID="litInvestorsCount" runat="server"></asp:Literal>
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
                                        <td align="left" valign="top">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td class="alpha" colspan="6">
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
                                                    <td style="width: 50px;">
                                                        <asp:Literal ID="litSInvestorName" runat="server" Text="Name"></asp:Literal>
                                                    </td>
                                                    <td style="width: 180px;">
                                                        <asp:TextBox ID="txtSInvestorName" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 50px;">
                                                        <asp:Literal ID="litSLocation" runat="server" Text="City"></asp:Literal>
                                                    </td>
                                                    <td style="width: 180px;">
                                                        <asp:TextBox ID="txtSLocation" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 50px;">
                                                        <asp:Literal ID="litSStatus" runat="server" Text="Status"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSStatus" runat="server" SkinID="Search">
                                                            <asp:ListItem Text="ALL" Value="ALL" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="Active" Value="ACTIVE"></asp:ListItem>
                                                            <asp:ListItem Text="Inactive" Value="INACTIVE"></asp:ListItem>
                                                        </asp:DropDownList>
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
                                            <%if (IsMessage)
                                              { %>
                                            <div class="ResetSuccessfully">
                                                <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                    <img src="../../images/success.png" />
                                                </div>
                                                <div>
                                                    <asp:Label ID="lblInvestorMsg" runat="server"></asp:Label></div>
                                                <div style="height: 10px;">
                                                </div>
                                            </div>
                                            <% }%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="btnPrintInvList" runat="server" OnClick="btnPrintInvList_Click" Text="Print" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox" style="padding: 10px 0px;">
                                            <asp:GridView ID="grdInvestorList" runat="server" AutoGenerateColumns="False" Width="100%"
                                                OnRowCommand="grdInvestorList_RowCommand" OnRowDataBound="grdInvestorList_RowDataBound"
                                                DataKeyNames="UserID,FullName" OnPageIndexChanging="grdInvestorList_OnPageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                        ItemStyle-Width="200px">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblGvHdrFullName" runat="server" Text="Name"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGvFullName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FullName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mobile No" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                        ItemStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="litMobileNo" runat="server"></asp:Literal>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="EMail" HeaderText="Email" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="120px" />
                                                    <asp:TemplateField HeaderText="Active(A) / Deactive(D)" ItemStyle-Width="130px" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:RadioButtonList ID="rdblInvestorStatus" runat="server" RepeatColumns="2" Width="110px"
                                                                RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rdblInvestorStatus_OnSelectedIndexChanged">
                                                                <asp:ListItem Text="A" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="D" Value="0"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Act. Mail" ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkResendActivationMail" runat="server" Visible="false" Text="Resend"
                                                                CommandName="RESENDACTMAIL" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorID")%>'
                                                                ToolTip="Resend activation mail"></asp:LinkButton>
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
        <ajx:ModalPopupExtender ID="mpeAskConfirmation" runat="server" TargetControlID="hfAskConfirmation"
            PopupControlID="pnlAskConfirmation" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfAskConfirmation" runat="server" />
        <asp:Panel ID="pnlAskConfirmation" runat="server">
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
                            <div style="float: left; width: 330px; margin-top: 40px; margin-left: 10px;">
                                <asp:Label ID="lblAskConfirmation" runat="server"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <div>
                                            <asp:Button ID="btnYes" Text="Yes" runat="server" ImageUrl="~/images/save.png" OnClick="btnYes_Click"
                                                Style="display: inline-block;" />
                                            <asp:Button ID="btnNo" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                                OnClick="btnNo_Click" Style="display: inline-block;" />
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
        <asp:PostBackTrigger ControlID="btnPrintInvList" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updInvestorList" ID="UpdateProgressInvestorList"
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
