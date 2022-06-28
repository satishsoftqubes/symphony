<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRateCardCorporates.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.CtrlRateCardCorporates" %>
<script type="text/javascript" language="javascript">
    function fnSetCorporateRowIndex(rowIndex) {
        document.getElementById('<%= hfCorporateRowIndex.ClientID %>').value = rowIndex;
    }
</script>
<asp:UpdatePanel ID="upnlCorporates" runat="server">
    <ContentTemplate>
        <div>
            <h1>
                <asp:Literal ID="litHeaderCorporates" runat="server"></asp:Literal></h1>
            <hr />
        </div>
        <div style="height: 180px; overflow: auto;">
            <div class="box_content">
                <asp:HiddenField ID="hfCorporateRowIndex" runat="server" />
                <asp:GridView ID="gvCorporates" runat="server" AutoGenerateColumns="false" Width="100%"
                    ShowHeader="true" SkinID="gvNoPaging" DataKeyNames="CorporateID" OnRowDataBound="gvCorporates_RowDataBound">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrNumber" runat="server" ></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrSelect" runat="server" ></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%--<asp:CheckBox ID="chkSelect" runat="server" />--%>
                                <asp:CheckBox ID="chkSelect" runat="server" OnCheckedChanged="chkSelect_OnCheckedChanged"
                                    AutoPostBack="true" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrAgentCorporate" runat="server"></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblAgentCorporate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DisplayName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrConpanyName" runat="server"></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCompanyName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CompanyName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="120px">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrCorporateType" runat="server" ></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCorporateType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CorporateTypeName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="65px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrIsDefault" runat="server"></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsDefault" runat="server" Enabled="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200px">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrDefaultRateCardName" runat="server"></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDefaultRateCardName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DefaultRateCardName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="padding: 10px;">
                            <b>
                                <asp:Literal ID="lblNoRecordFound" runat="server"></asp:Literal>
                            </b>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="upnlCorporates" ID="upgrsCorporates"
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
