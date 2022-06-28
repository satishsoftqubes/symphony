<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProspectsList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlProspectsList" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="../AlphaBet/CtrlAlphaBet.ascx" TagName="CtrlAlphaBet" TagPrefix="uc2" %>

<script language="javascript" type="text/javascript">
    function pageLoad(sender, args) {
        $(document).ready(function () {
            $("#<%=txtSProspectName.ClientID%>").autocomplete('ProspectsAutoComplete.ashx');            
        });
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnAlphabatsClick(alpha) {
        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hfSelectedAlphabet.ClientID %>').value = alpha;

        __doPostBack('ctl00$ContentPlaceHolder1$CtrlPropertyList1$lnkAlphabet', '');
    }
</script>
<style type="text/css">
    #progressBackgroundFilter
    {
        position: fixed;
        top: 0px;
        width:100%;
        height:100%;
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
        border-radius:10px;
        z-index: 1111112;
        background-color:#fff;
        border: solid 1px #efefef;
    }
</style>
<script language="javascript">

    function openViewer() {
        var Preview = '<%=IsPreview%>';
        window.open("../../ReportFiles/frmViewer.aspx?preview=" + Preview);
    }
</script>
<asp:UpdatePanel ID="updProspectsList" runat="server">
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
                                PROSPECTS&nbsp;<asp:Literal ID="litProspectsCount" runat="server"></asp:Literal>
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
                                                    <td class="alpha" colspan="4">
                                                       <a href="#" onclick="fnAlphabatsClick('ALL');">ALL</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('A');">
                                                            A</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('B');">B</a>&nbsp;&nbsp;|&nbsp;
                                                        <a href="#" onclick="fnAlphabatsClick('C');">C</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('D');">
                                                            D</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('E');">E</a>&nbsp;&nbsp;|&nbsp;
                                                        <a href="#" onclick="fnAlphabatsClick('F');">F</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('G');">
                                                            G</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('H');">H</a>&nbsp;&nbsp;|&nbsp;
                                                        <a href="#" onclick="fnAlphabatsClick('I');">I</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('J');">
                                                            J</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('K');">K</a>&nbsp;&nbsp;|&nbsp;
                                                        <a href="#" onclick="fnAlphabatsClick('L');">L</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('M');">
                                                            M</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('N');">N</a>&nbsp;&nbsp;|&nbsp;
                                                        <a href="#" onclick="fnAlphabatsClick('O');">O</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('P');">
                                                            P</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('Q');">Q</a>&nbsp;&nbsp;|&nbsp;
                                                        <a href="#" onclick="fnAlphabatsClick('R');">R</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('S');">
                                                            S</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('T');">T</a>&nbsp;&nbsp;|&nbsp;
                                                        <a href="#" onclick="fnAlphabatsClick('U');">U</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('V');">
                                                            V</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('W');">W</a>&nbsp;&nbsp;|&nbsp;
                                                        <a href="#" onclick="fnAlphabatsClick('X');">X</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('Y');">
                                                            Y</a>&nbsp;&nbsp;|&nbsp; <a href="#" onclick="fnAlphabatsClick('Z');">Z</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litSProspectName" runat="server" Text="Name"></asp:Literal>&nbsp;&nbsp;
                                                    </td>
                                                    <td>                                                        
                                                        <asp:TextBox ID="txtSProspectName" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal1" runat="server" Text="Status"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlProspectStatus" runat="server" Style="width: 165px;">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px;">
                                                        <asp:Literal ID="litMobileNo" runat="server" Text="City"></asp:Literal>
                                                    </td>
                                                    <td style="width: 250px;">
                                                        <asp:DropDownList ID="txtsLocation" runat="server" style="width:165px;"></asp:DropDownList>
                                                    </td>
                                                    <td style="width: 100px;">
                                                        <asp:Literal ID="litSEmail" runat="server" Text="Reference"></asp:Literal>
                                                    </td>
                                                    <td style="width: 250px;">
                                                        <asp:DropDownList ID="txtRefernce" runat="server" style="width:165px;"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:150px;">
                                                        <asp:Literal ID="litRegion" runat="server" Text="Region"></asp:Literal>
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:DropDownList ID="ddlRegion" runat="server" style="width:165px;"></asp:DropDownList>
                                                        <asp:ImageButton ID="btnSearch" Style="border: 0px; vertical-align: middle; margin-top: 0px;
                                                            margin-left: 5px;" runat="server" ImageUrl="~/images/search-icon.png" OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()"/>
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
                                                    <img src="../../images/success.png" />
                                                </div>
                                                <div>
                                                    <asp:Label ID="lblProspctLstMsg" runat="server"></asp:Label></div>
                                                <div style="height: 10px;">
                                                </div>
                                            </div>
                                            <% }%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="middle">
                                            <asp:Button ID="btnAddTop" runat="server" Text="Add New" OnClick="btnAdd_Click" Style="float: right;" OnClientClick="fnDisplayCatchErrorMessage()"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox" style="padding: 10px 0px;">
                                            <style>
                                                .dTableBox td
                                                {
                                                    padding: 0px 3px;
                                                }
                                            </style>
                                            <asp:GridView ID="grdProspect" runat="server" AutoGenerateColumns="False" Width="100%"
                                                OnRowCommand="grdProspect_RowCommand" OnRowDataBound="grdProspect_RowDataBound"
                                                OnPageIndexChanging="grdProspect_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="FullName" HeaderText="Name" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left"/>
                                                    <asp:TemplateField HeaderText="Mobile No." ItemStyle-Width="110px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGvMobileNo" style="width:100px;" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "MobileNo")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <%--<asp:BoundField DataField="MobileNo" HeaderText="Mobile No." ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left"/>--%>
                                                    <asp:BoundField DataField="Email" HeaderText="Email" ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left"/>
                                                    <%--<asp:TemplateField HeaderText="Other Information" ItemStyle-Width="290px" ItemStyle-CssClass="topalign">
                                                        <ItemTemplate>
                                                            <div style="height:5px;"></div>
                                                                <div style="float:left; width:100px; padding-top:2px;">Region Name : </div><%#DataBinder.Eval(Container.DataItem, "RegionName")%><br />
                                                                <div style="height:3px; border-bottom:1px solid #c9c9c9;" ></div>
                                                                <div style="float:left; width:100px; padding-top:2px;">Email : </div><%#DataBinder.Eval(Container.DataItem, "Email")%><br />
                                                                <div style="height:3px; border-bottom:1px solid #c9c9c9;" ></div>
                                                                <div style="float:left; width:100px; padding-top:2px;">Reference : </div><%#DataBinder.Eval(Container.DataItem, "Reference")%><br />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:BoundField DataField="CityName" HeaderText="City" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="80px" />
                                                    <asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="45px" />
                                                    <%--<asp:BoundField DataField="Reference" HeaderText="Reference" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" />
                                                    <asp:BoundField DataField="RegionName" HeaderText="Region" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="75px" />
                                                    <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px" />--%>
                                                    <asp:TemplateField HeaderText="View/Edit/Delete" ItemStyle-Width="45px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" ToolTip="Edit" CommandName="EDITCMD" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ProspectID")%>'
                                                                runat="server" ImageUrl="~/images/edit.png" style="border: 0px;" OnClientClick="fnDisplayCatchErrorMessage()"/>
                                                            <asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandName="DELETECMD" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ProspectID")%>'
                                                                    runat="server" ImageUrl="~/images/delete_icon.png" style="border: 0px;" OnClientClick="fnDisplayCatchErrorMessage()"/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnConverttoInvestor" ToolTip="Convert To Investor" CommandName="INVESTOR" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "ProspectID")%>'
                                                                runat="server" ImageUrl="~/images/Investor.png" Style="border: 0px; vertical-align: middle;
                                                                margin-top: 3px; margin-right: 7px;" />
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
                                            <asp:ImageButton ID="imgbtnDOC" Text="" Style="float: left; margin-left: 5px;border:0px;" ToolTip="ExportToDOC"
                                                runat="server" ImageUrl="~/images/report_word.png" 
                                                onclick="imgbtnDOC_Click" OnClientClick="fnDisplayCatchErrorMessage()"/> 
                                            <asp:ImageButton ID="imgbtnXLSX" Text="" Style="float: left; margin-left: 5px;border:0px;" ToolTip="ExportToXLSX"
                                                runat="server" ImageUrl="~/images/report_xlsx.png" 
                                                onclick="imgbtnXLSX_Click" OnClientClick="fnDisplayCatchErrorMessage()"/>
                                            <asp:ImageButton ID="imgbtnPDF" Text="" Style="float: left; margin-left: 5px;border:0px;" ToolTip="ExportToPDF"
                                                runat="server" ImageUrl="~/images/report_pdf.png" 
                                                onclick="imgbtnPDF_Click" OnClientClick="fnDisplayCatchErrorMessage()"/> 
                                            <asp:Button ID="btnPreview" Visible="false" Text="Preview" Style="float: left; margin-left: 5px;"
                                                runat="server" ImageUrl="~/images/save.png" OnClick="btnPreview_Click" />
                                            <asp:Button ID="btnPrint" Text="Print" Style="float: left; margin-left: 5px;" runat="server"
                                                ImageUrl="~/images/cancle.png" OnClick="btnPrint_Click" OnClientClick="fnDisplayCatchErrorMessage()"/>
                                            <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" Style="float: right;" OnClientClick="fnDisplayCatchErrorMessage()"/>
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
        <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="pnl"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="pnl" runat="server" style="display:none;">
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
                            <div style="float: left; width: 225px; margin-top: 40px; margin-left: 10px;">
                                <asp:Label ID="lblErrorMessage" runat="server" Text="Sure you want to delete?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">                                        
                                        <asp:Button ID="btnAddressSave" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnAddressSave_Click" Style="display:inline-block;" OnClientClick="fnDisplayCatchErrorMessage()"/>
                                        <asp:Button ID="btnAddressCancel" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            OnClick="btnAddressCancel_Click" Style="display:inline-block;" OnClientClick="fnDisplayCatchErrorMessage()"/>
                                        </div>
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
        <asp:PostBackTrigger ControlID="btnPreview" />
        <asp:PostBackTrigger ControlID="btnPrint" />
        <asp:PostBackTrigger ControlID="imgbtnPDF" />
        <asp:PostBackTrigger ControlID="imgbtnXLSX" />
        <asp:PostBackTrigger ControlID="imgbtnDOC" />
    </Triggers>
</asp:UpdatePanel>

<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>

<asp:UpdateProgress AssociatedUpdatePanelID="updProspectsList" ID="UpdateProgressProspectsList"
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
