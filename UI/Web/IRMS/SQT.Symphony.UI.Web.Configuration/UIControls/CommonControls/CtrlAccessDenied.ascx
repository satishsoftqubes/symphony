<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAccessDenied.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.CommonControls.CtrlAccessDenied" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<asp:UpdatePanel ID="updAccessDenied" runat="server">
    <ContentTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="content">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box" style="border: none;">
                <tr>
                    <td class="boxtopleft">
                        &nbsp;
                    </td>
                    <td class="boxtopcenter">
                        <asp:Literal ID="litMainHeader" runat="server"></asp:Literal>
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
                        <div align="center">
                            <asp:MultiView ID="mvAccessDenied" runat="server">
                                <asp:View ID="vGemeralMessage" runat="server">
                                    <div align="center" style="width: 600px; margin: 100px 0px; border: solid 1px #CCCCCE;
                                        background: #F4F4F4;">
                                        <table border="0" width="600" cellspacing="0" cellpadding="7">
                                            <tr>
                                                <td width="200">
                                                    <p align="center">
                                                        <img border="0" src="<%=Page.ResolveUrl("~/images/accessDenied.gif") %>" width="128"
                                                            height="128">
                                                </td>
                                                <td width="800">
                                                    <br />
                                                    <p align="left">
                                                        <font face="Arial" style="font-weight: bold; color: #0067A4;" size="5">
                                                            <asp:Literal ID="litHeaderAccessDenied" runat="server"></asp:Literal></font>
                                                        <br />
                                                        <br />
                                                        <p align="left">
                                                            <font face="Arial" style="color: #909092;" size="4">
                                                                <asp:Literal ID="litMsgAccessDeniedM" runat="server"></asp:Literal><br />
                                                                &nbsp;</font>
                                                        </p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:View>
                                <asp:View ID="vCompanyList" runat="server">
                                    <div class="box_form">
                                    <div style="padding-top: 5px;">
                                        <font face="Arial" style="color: #909092;" size="4">
                                            <asp:Literal ID="ltrCompanyListMessage" runat="server"></asp:Literal><br />
                                            &nbsp;</font>
                                    </div>
                                    <div class="box_head" style="text-align: left;">
                                        <span>
                                            <asp:Literal ID="litCompanyList" runat="server" Text="Company List"></asp:Literal>
                                        </span>
                                    </div>
                                    <div class="clear">
                                    </div>
                                    <div class="box_content">
                                        <asp:GridView ID="gvCompanyList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                            Width="100%" OnPageIndexChanging="gvCompanyList_PageIndexChanging" OnRowCommand="gvCompanyList_RowCommand"
                                            OnRowDataBound="gvCompanyList_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrSrNo" runat="server"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrCompanyName" runat="server"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkPropertyName" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "CompanyID")%>'
                                                            CommandName="EDITDATA" Text='<%#DataBinder.Eval(Container.DataItem, "CompanyName")%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrCompanyCode" runat="server"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "CompanyCode")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrDisplayName" runat="server"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "DisplayName")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrCompanyType" runat="server"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "CompanyType")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="padding: 10px;">
                                                    <b>
                                                        <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label>
                                                    </b>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                    </div>
                                </asp:View>
                                <asp:View ID="vPropertyList" runat="server">
                                    <div class="box_form">
                                    <div style="padding-top: 5px;">
                                        <font face="Arial" style="color: #909092;" size="4">
                                            <asp:Literal ID="ltrPropertyListMessage" runat="server"></asp:Literal><br />
                                            &nbsp;</font>
                                    </div>
                                    <div class="box_head" style="text-align:left;">
                                        <span>
                                            <asp:Literal ID="litPropertyList" runat="server" Text="Property List"></asp:Literal></span></div>
                                    <div class="clear">
                                    </div>
                                    <div class="box_content">
                                        <asp:GridView ID="grdPropertyList" runat="server" AutoGenerateColumns="False" Width="100%"
                                            OnPageIndexChanging="grdPropertyList_OnPageIndexChanging" CssClass="grid_content"
                                            OnRowDataBound="grdPropertyList_RowDataBound" OnRowCommand="grdPropertyList_RowCommand">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="30px">
                                                    <HeaderTemplate>
                                                        <asp:Literal ID="litGvfNo" runat="server"></asp:Literal>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHdrPropertyName" runat="server"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnUnitInfo" Text='<%#DataBinder.Eval(Container.DataItem, "PropertyName")%>'
                                                            runat="server" CommandName="EDITDATA" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PropertyID")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="180px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHdrPropertyType" runat="server"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPropertyType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ProperyType")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="180px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHdrLocation" runat="server"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCity" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CityName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblHdrHotelLicenceNumber" runat="server"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblHotelLicenceNumber" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "LicenceNo")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="padding: 10px;">
                                                    <h2>
                                                        <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label></h2>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                    </div>
                                </asp:View>
                            </asp:MultiView>
                            <uc1:MsgBox ID="MessageBox" runat="server" />
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
        </td>
    </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress AssociatedUpdatePanelID="updAccessDenied" ID="updProgAccessDenied"
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