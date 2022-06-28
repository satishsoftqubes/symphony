<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CltrDashboardProperty.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.DashBoard.CltrDashboardProperty" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBoxProperty" TagPrefix="ucProperty" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessageForProperty() {
        document.getElementById('errormessageProperty').style.display = "block";
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
<asp:UpdatePanel ID="updtDashBoardProperty" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box" style="height: 100%;
            min-width: 225px;">
            <tr>
                <td class="boxtopleft">
                    &nbsp;
                </td>
                <td class="boxtopcenter">
                    Properties -
                    <asp:Label ID="lblPropertiesCount" runat="server"></asp:Label>
                    <a href="../../Applications/SetUp/PropertyList.aspx">
                        <img src="../../images/box_arrow.jpg" /></a>
                </td>
                <td class="boxtopright">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="boxleft">
                    &nbsp;
                </td>
                <td style="vertical-align: top;">
                    <div style="min-height: 175px;">
                        <asp:GridView ID="gvPropertyDashBoard" ShowHeader="false" Width="100%" runat="server"
                            AutoGenerateColumns="false" SkinID="gvNoPaging" OnRowCommand="gvPropertyDashBoard_RowCommand"
                            OnRowDataBound="gvPropertyDashBoard_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="box_content">
                                            <ul class="box_contentlist">
                                                <li>Name: <span>
                                                    <asp:LinkButton ID="lnkGo" runat="server" ForeColor="#0067A4" CommandName="propertyunits"
                                                        OnClientClick="fnDisplayCatchErrorMessageForProperty()" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PropertyID")%>'><%#DataBinder.Eval(Container.DataItem, "PropertyName")%></asp:LinkButton>
                                                </span></li>
                                                <%--<li>Name: <span>
                                                <%#DataBinder.Eval(Container.DataItem, "PropertyName")%></span></li>--%>
                                                <li>No. of Units: <span>
                                                    <%#DataBinder.Eval(Container.DataItem, "Units")%></span></li>
                                                <li>No. of Beds: <span>
                                                    <%#DataBinder.Eval(Container.DataItem, "Beds")%></span></li>
                                                <li>
                                                    <asp:Literal ID="lblNoOfInvestor" runat="server" Text="No. of Investors:"></asp:Literal><%--<span>--%>
                                                    <asp:Label ID="lblDisplayNoOfInvestor" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Investors")%>'></asp:Label>
                                                    <%--</span>--%></li>
                                                <li>
                                                    <asp:LinkButton ID="lnkCurrentMarketRate" ForeColor="#0067A4" Visible="false" runat="server" Text="Current Market Rate"
                                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PropertyID")%>' CommandName="CURRENTMARKETRATE"></asp:LinkButton>
                                                </li>
                                            </ul>
                                        </div>
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
        <%--<div id="errormessageChannelPartners" class="clear" style="display: none;">
            <ucProperty:MsgBoxProperty ID="MsgBoxProperty" runat="server" />
        </div>--%>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessageProperty" class="clear" style="display: none;">
    <ucProperty:MsgBoxProperty ID="MsgBoxProperty" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updtDashBoardProperty" ID="UpdateProgressupdEmployee"
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
