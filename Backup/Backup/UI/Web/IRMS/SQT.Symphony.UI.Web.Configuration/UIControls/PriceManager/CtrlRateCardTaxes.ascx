<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRateCardTaxes.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.CtrlRateCardTaxes" %>
<script type="text/javascript" language="javascript">
    function fnSetRowIndex(rowIndex) {
        document.getElementById('<%= hfRowIndex.ClientID %>').value = rowIndex;
    }
</script>
<asp:UpdatePanel ID="upnlRateCardTaxes" runat="server">
    <ContentTemplate>
        <div style="padding-bottom: 5px;">
            <h1>
                <asp:Literal ID="litHeaderTaxes" runat="server"></asp:Literal>
            </h1>
            <hr />
        </div>
        <div style="height: 155px; overflow: auto;" class="content_checkbox">
            <div class="clear">
            </div>
            <div class="box_content">
                <asp:HiddenField ID="hfRowIndex" runat="server" />
                <asp:GridView ID="gvTaxes" runat="server" AutoGenerateColumns="false" Width="100%"
                    ShowHeader="true" SkinID="gvNoPaging" DataKeyNames="AcctID" OnRowDataBound="gvTaxes_RowDataBound">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                <%--<asp:Literal ID="litGvHdrSelect" runat="server" Text="Select"></asp:Literal>--%>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrTax" runat="server"></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTax" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AcctName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrRate" runat="server"></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRate" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="padding: 10px;">
                            <b>
                                <asp:Literal ID="litNoRecordFound" runat="server"></asp:Literal>
                            </b>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
                <%--<div style="float: right; width: auto; display: inline-block;">
                    <asp:LinkButton runat="server" ID="lnkCalculateTax">
                        <asp:Literal ID="litCalculateTax" runat="server" Text="Calculate Tax"></asp:Literal>
                    </asp:LinkButton>
                </div>--%>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="upnlRateCardTaxes" ID="upgrsRateCardTaxes"
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
