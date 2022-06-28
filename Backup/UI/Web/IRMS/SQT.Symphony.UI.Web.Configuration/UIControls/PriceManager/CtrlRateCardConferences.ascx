<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRateCardConferences.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager.CtrlRateCardConferences" %>
<script type="text/javascript" language="javascript">
    function fnSetRowIndex(rowIndex) {
        document.getElementById('<%= hfRowIndex.ClientID %>').value = rowIndex;
    }
</script>
<asp:UpdatePanel ID="upnlConferences" runat="server">
    <ContentTemplate>
        <div>
            <h1>
                <asp:Literal ID="litHeaderConferences" runat="server"></asp:Literal></h1>
            <hr />
        </div>
        <div style="height: 180px; overflow: auto;">
            <div class="box_content">
                <asp:HiddenField ID="hfRowIndex" runat="server" />
                <asp:GridView ID="gvConferences" runat="server" AutoGenerateColumns="false" Width="70%"
                    ShowHeader="true" SkinID="gvNoPaging" DataKeyNames="ConferenceID" OnRowDataBound="gvConferences_RowDataBound">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrNumber" runat="server"></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrSelect" runat="server"></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" OnCheckedChanged="chkSelect_OnCheckedChanged"
                                    AutoPostBack="true" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrConferenceName" runat="server" ></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblConferenceName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ConferenceName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrRackRate" runat="server" ></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtRackRate" runat="server" Enabled="false" MaxLength="13" style="text-align:right;" SkinID="nowidth" Width="70px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvRackRate" Display="Dynamic" runat="server" SetFocusOnError="true"
                                    CssClass="input-notification error png_bg" ValidationGroup="IsRequire" Enabled="false" ControlToValidate="txtRackRate"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display="Dynamic" ID="regRackRate" runat="server"
                                    CssClass="input-notification error png_bg" ControlToValidate="txtRackRate" SetFocusOnError="true"
                                    ValidationGroup="IsRequire">
                                </asp:RegularExpressionValidator>
                                <ajx:FilteredTextBoxExtender ID="ftbRackRate" runat="server" TargetControlID="txtRackRate"
                                    FilterMode="ValidChars" ValidChars="0123456789.">
                                </ajx:FilteredTextBoxExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrExtraAdult" runat="server" ></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtExtraAdult" runat="server" SkinID="nowidth" Enabled="false" style="text-align:right;" MaxLength="13" Width="70px"></asp:TextBox>
                                <asp:RegularExpressionValidator Display="Dynamic" ID="regExtraAdult" runat="server"
                                    CssClass="input-notification error png_bg" ControlToValidate="txtExtraAdult" SetFocusOnError="true"
                                    ValidationGroup="IsRequire">
                                </asp:RegularExpressionValidator>
                                <ajx:FilteredTextBoxExtender ID="ftbExtraAdult" runat="server" TargetControlID="txtExtraAdult"
                                    FilterMode="ValidChars" ValidChars="0123456789.">
                                </ajx:FilteredTextBoxExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <asp:Literal ID="litGvHdrExtChild" runat="server" ></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtExtraChild" runat="server" SkinID="nowidth" MaxLength="13" style="text-align:right;" Enabled="false" Width="70px"></asp:TextBox>
                                <asp:RegularExpressionValidator Display="Dynamic" ID="regExtraChild" runat="server"
                                    CssClass="input-notification error png_bg" ControlToValidate="txtExtraChild" SetFocusOnError="true"
                                    ValidationGroup="IsRequire">
                                </asp:RegularExpressionValidator>
                                <ajx:FilteredTextBoxExtender ID="ftbExtraChild" runat="server" TargetControlID="txtExtraChild"
                                    FilterMode="ValidChars" ValidChars="0123456789.">
                                </ajx:FilteredTextBoxExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="padding: 10px;">
                            <b>
                                <asp:Literal ID="litNoRecordFound" runat="server"></asp:Literal>
                            </b>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="upnlConferences" ID="upgrsConferences" runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
