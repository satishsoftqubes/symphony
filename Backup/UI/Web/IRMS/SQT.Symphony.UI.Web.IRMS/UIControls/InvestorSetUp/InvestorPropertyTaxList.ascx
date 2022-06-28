<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InvestorPropertyTaxList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.InvestorPropertyTaxList" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function pageLoad(sender, args) {
        $(document).ready(function () {
            $("#<%=txtUnitNo.ClientID%>").autocomplete('../SetUp/UnitAutoComplete.ashx');
            $("#<%=txtPropertyName.ClientID%>").autocomplete('../SetUp/PropertyAutoComplete.ashx');
        });
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function openViewer() {
        var Preview = '<%=IsPreview%>';
        window.open("../../ReportFiles/frmViewer.aspx?preview=" + Preview);
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
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
<asp:UpdatePanel ID="updIPTL" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                PROPERTY TAX & INSURANCE
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
                                <table cellpadding="2" cellspacing="0" border="0" width="99%">
                                    <tr>
                                        <td>
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litPropertyName" runat="server" Text="Property Name"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPropertyName" runat="server" Style="margin-right: 100px;"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litUserName" runat="server" Text="Unit No"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtUnitNo" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litFromDate" runat="server" Text="From Date"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFromDate" style="width:163px !important;" runat="server" onkeydown="return stopKey(event);"></asp:TextBox>
                                                        <asp:Image ID="imgFromDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png" />
                                                        <ajx:CalendarExtender ID="calFromDate" runat="server" PopupButtonID="imgFromDate"
                                                            TargetControlID="txtFromDate" CssClass="MyCalendar">
                                                        </ajx:CalendarExtender>
                                                        <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" onclick="fnClearDate('<%= txtFromDate.ClientID %>');" />
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litToDate" runat="server" Text="To Date"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtToDate" style="width:163px !important;" runat="server" onkeydown="return stopKey(event);"></asp:TextBox>
                                                        <asp:Label ID="lblDateErrorMsg" runat="server" style="color:Red;"></asp:Label>
                                                        <asp:Image ID="imgToDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png" />
                                                        <ajx:CalendarExtender ID="calToDate" runat="server" PopupButtonID="imgToDate" TargetControlID="txtToDate" CssClass="MyCalendar">
                                                        </ajx:CalendarExtender>
                                                        <img src="../../images/clear.png" id="imgClearDate" style="vertical-align: middle;"
                                                            onclick="fnClearDate('<%= txtToDate.ClientID %>');" />
                                                        <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                            OnClick="btnSearch_Click" Style="border: 0px; vertical-align: middle; margin-top: 0px;
                                                            margin-left: 5px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="pageinfodivider">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox" style="padding: 10px 0px;">
                                            <asp:GridView ID="gvPropertyTaxandList" runat="server" AutoGenerateColumns="False"
                                                Width="100%" SkinID="gvNoPaging" OnRowDataBound="gvPropertyTaxandList_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField DataField="PropertyName" HeaderText="Property" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="125px" />
                                                    <asp:BoundField DataField="RoomNo" HeaderText="Unit No." HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="80px" />
                                                    <asp:TemplateField HeaderText="Property Tax (Rs.)" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right"
                                                        ItemStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPropertyTax" Width="110px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PropertyTax") != DBNull.Value ? Convert.ToString(DataBinder.Eval(Container.DataItem, "PropertyTax")) : ""%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Property Insurance (Rs.)" ItemStyle-Width="130px" HeaderStyle-HorizontalAlign="Right"
                                                        ItemStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPropertyInsurance" Width="100px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PropertyInsurance") != DBNull.Value ? Convert.ToString(DataBinder.Eval(Container.DataItem, "PropertyInsurance")) : ""%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Period From" ItemStyle-Width="15px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPeriodFrom" Width="100px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FromDate") != DBNull.Value ? Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "FromDate")).ToString(DateFormat) : ""%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Period To" ItemStyle-Width="15px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPeriodTo" Width="100px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ToDate") != DBNull.Value ? Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "ToDate")).ToString(DateFormat) : ""%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:BoundField DataField="RoomTypeName" HeaderText="Unit Type" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60px" />--%>
                                                    <%--<asp:TemplateField HeaderText="SBA (sft)" ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%#Convert.ToInt32(DataBinder.Eval(Container.DataItem, "SBArea")).ToString()%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <%--<asp:BoundField DataField="PaidAmount" HeaderText="Paid Amt(Rs)" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="10px" />
                                                    <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price(Rs)" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="10px" />--%>
                                                    <%-- <asp:BoundField DataField="YearToPay" HeaderText="YEAR" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" />--%>
                                                    <%--<asp:BoundField DataField="Term" HeaderText="Receipt Type" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left"/>--%>
                                                    <asp:TemplateField HeaderText="Att." ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <a href='../../Document/<%# DataBinder.Eval(Container.DataItem, "DocumentName")%>'
                                                                target="_blank" style="border: 0px;">
                                                                <asp:Image ID="btnAttachment" ImageUrl="~/images/Attachment.png" runat="server" /></a>
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
                                            <asp:ImageButton ID="imgbtnDOC" Text="" Style="float: left; margin-left: 5px; border: 0px;"
                                                ToolTip="ExportToDOC" runat="server" ImageUrl="~/images/report_word.png" OnClick="imgbtnDOC_Click"
                                                OnClientClick="fnDisplayCatchErrorMessage()" />
                                            <asp:ImageButton ID="imgbtnXLSX" Text="" Style="float: left; margin-left: 5px; border: 0px;"
                                                ToolTip="ExportToXLSX" runat="server" ImageUrl="~/images/report_xlsx.png" OnClick="imgbtnXLSX_Click"
                                                OnClientClick="fnDisplayCatchErrorMessage()" />
                                            <asp:ImageButton ID="imgbtnPDF" Text="" Style="float: left; margin-left: 5px; border: 0px;"
                                                ToolTip="ExportToPDF" runat="server" ImageUrl="~/images/report_pdf.png" OnClick="imgbtnPDF_Click"
                                                OnClientClick="fnDisplayCatchErrorMessage()" />
                                            <asp:Button ID="btnPreview" Visible="false" Text="Preview" Style="float: left; margin-left: 5px;"
                                                runat="server" ImageUrl="~/images/save.png" OnClick="btnPreview_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                            <asp:Button ID="btnPrint" Text="Print" Style="float: left; margin-left: 5px;" runat="server"
                                                ImageUrl="~/images/cancle.png" OnClick="btnPrint_Click" OnClientClick="fnDisplayCatchErrorMessage()" />                                           
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
<asp:UpdateProgress AssociatedUpdatePanelID="updIPTL" ID="UpdateProgressIPTL" runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
