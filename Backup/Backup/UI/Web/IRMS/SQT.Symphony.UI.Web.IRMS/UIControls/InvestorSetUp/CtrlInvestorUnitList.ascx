<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInvestorUnitList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlInvestorUnitList" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function pageLoad(sender, args) {
        $(document).ready(function () {
            $("#<%=txtSearchUnitType.ClientID%>").autocomplete('../SetUp/UnitTypeAutoComplete.ashx');
        });
    }

    function openViewer() {
        var Preview = '<%=IsPreview%>';
        window.open("../../ReportFiles/frmViewer.aspx?preview=" + Preview);
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
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td>
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litPropertyName" runat="server" Text="Property Name"></asp:Literal>
                                                        &nbsp;&nbsp;<asp:DropDownList ID="drpPropertyName" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="litUserName" runat="server" Text="Unit Type"></asp:Literal>
                                                        &nbsp;&nbsp;<asp:TextBox ID="txtSearchUnitType" runat="server"></asp:TextBox>
                                                        <asp:ImageButton ID="btnSearch" runat="server" Style="border: 0px; vertical-align: middle;
                                                            margin-top: 0px; margin-left: 5px;" ImageUrl="~/images/search-icon.png" OnClick="btnSearch_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage()" />
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox" style="padding: 10px 0px 10px 0px;">
                                            <div style="overflow: auto; width: 735px; height: 350px;">
                                                <style type="text/css">
                                                    .mGrid td.topalign
                                                    {
                                                        vertical-align: top;
                                                    }
                                                </style>
                                                <asp:GridView ID="gvInvestorUnitList" runat="server" AutoGenerateColumns="False"
                                                    Width="100%" SkinID="gvNoPaging" OnRowDataBound="gvInvestorUnitList_RowDataBound"
                                                    OnRowCommand="gvInvestorUnitList_RowCommand" ShowFooter="true">
                                                    <Columns>
                                                        
                                                        <asp:TemplateField HeaderText="Property" ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">                                                                                                
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "PropertyName")%>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                Total :
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unit No." ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkRoomNo" Style="text-decoration: none;" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "RoomNo")%>'
                                                                    CommandName="EditData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InvestorRoomID")%>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="RoomTypeName" HeaderText="Unit Type"  HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"/>
                                                        <asp:BoundField DataField="SBArea" HeaderText="SBA (sft)" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                                                        <asp:BoundField DataField="UnitPrice" HeaderText="Basic Price (Rs.)" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                                                        <%--<asp:TemplateField HeaderText="Unit Information" ItemStyle-Width="300px" ItemStyle-CssClass="topalign">
                                                            <ItemTemplate>
                                                                <div style="height: 5px;">
                                                                </div>
                                                                <div style="float: left; width: 70px; padding-top: 2px;">
                                                                    Property :
                                                                </div>
                                                                <%#DataBinder.Eval(Container.DataItem, "PropertyName")%><br />
                                                                <div style="height: 3px; border-bottom: 1px solid #c9c9c9;">
                                                                </div>
                                                                <div style="float: left; width: 70px; padding-top: 2px;">
                                                                    Unit Type :
                                                                </div>
                                                                <%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%><br />
                                                                <div style="height: 3px; border-bottom: 1px solid #c9c9c9;">
                                                                </div>
                                                                <div style="float: left; width: 70px; padding-top: 2px;">
                                                                    SBA (sft):
                                                                </div>
                                                                <%#Convert.ToInt32(DataBinder.Eval(Container.DataItem, "SBArea")).ToString()%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <%--<asp:TemplateField HeaderText="Financial Information" ItemStyle-Width="290px" ItemStyle-CssClass="topalign">
                                                            <ItemTemplate>
                                                                <div style="height: 5px;">
                                                                </div>
                                                                <div style="float: left; width: 170px; padding-top: 2px;">
                                                                    Basic price(Rs) :
                                                                </div>
                                                                <%#DataBinder.Eval(Container.DataItem, "UnitPrice")%><br />
                                                                <div style="height: 3px; border-bottom: 1px solid #c9c9c9;">
                                                                </div>
                                                                <div style="float: left; width: 170px; padding-top: 2px;">
                                                                    st. duty on ag. To sell (Rs.) :
                                                                </div>
                                                                <%#DataBinder.Eval(Container.DataItem, "StmpDutyOnAgrToSell")%><br />
                                                                <div style="height: 3px; border-bottom: 1px solid #c9c9c9;">
                                                                </div>
                                                                <div style="float: left; width: 170px; padding-top: 2px;">
                                                                    st. duty on sale deed (Rs.) :
                                                                </div>
                                                                <%#DataBinder.Eval(Container.DataItem, "StmpDutyOnSaleDeed")%><br />
                                                                <div style="height: 3px; border-bottom: 1px solid #c9c9c9;">
                                                                </div>
                                                                <div style="float: left; width: 170px; padding-top: 2px;">
                                                                    Reg. charges (Rs.) :
                                                                </div>
                                                                <%#DataBinder.Eval(Container.DataItem, "RegistrationCharges")%><br />
                                                                <div style="height: 3px; border-bottom: 1px solid #c9c9c9;">
                                                                </div>
                                                                <div style="float: left; width: 170px; padding-top: 2px;">
                                                                    VAT (Rs.) :
                                                                </div>
                                                                <%#DataBinder.Eval(Container.DataItem, "Vat")%><br />
                                                                <div style="height: 3px; border-bottom: 1px solid #c9c9c9;">
                                                                </div>
                                                                <div style="float: left; width: 170px; padding-top: 2px;">
                                                                    S.Tax (Rs.) :
                                                                </div>
                                                                <%#DataBinder.Eval(Container.DataItem, "STax")%><br />
                                                                <div style="height: 3px; border-bottom: 1px solid #c9c9c9;">
                                                                </div>
                                                                <div style="float: left; width: 170px; padding-top: 2px;">
                                                                    Other costs(Rs.) :
                                                                </div>
                                                                <%#DataBinder.Eval(Container.DataItem, "OtherConstructionCost")%><br />
                                                                <div style="height: 5px;">
                                                                    &nbsp;
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Total Cost (Rs.)" ItemStyle-Width="100px" FooterStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "TotalCost")%>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblTotalFooter" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:BoundField DataField="TotalCost" HeaderText="Total Cost" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left" />--%>
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
                                            <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" Style="float: right;"
                                                OnClientClick="fnDisplayCatchErrorMessage()" />
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td align="left" valign="top" class="pagecontent_info">
                                            <p class="pageInformation">
                                                <b>Fill Control Number SetUp have four different part</b><br />
                                                <br />
                                            </p>
                                            1) Manage Control Number Information
                                        </td>
                                    </tr>--%>
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
            <div id="errormessage" class="clear" style="display: none;">
                <uc1:MsgBox ID="MessageBox" runat="server" />
            </div>
        </td>
    </tr>
</table>
