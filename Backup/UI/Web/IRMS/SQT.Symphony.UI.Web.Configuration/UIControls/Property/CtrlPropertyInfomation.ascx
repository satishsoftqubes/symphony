<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPropertyInfomation.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Property.CtrlPropertyInfomation" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnRowCommand(paramType, blockValue, unitValue) {
        if (paramType == 'BLOCKTYPE') {
            document.getElementById('<%= hfIsBlock.ClientID %>').value = "1";
        }
        else {
            document.getElementById('<%= hfIsBlock.ClientID %>').value = "0";
        }

        document.getElementById('<%= hfBlockValue.ClientID %>').value = blockValue;
        document.getElementById('<%= hfUnitValue.ClientID %>').value = unitValue;

        __doPostBack('ctl00$ContentPlaceHolder1$ucCtrlPropertyInfomation$lnkToRedirect', '');
    }

</script>
<asp:HiddenField ID="hfIsBlock" runat="server" />
<asp:HiddenField ID="hfBlockValue" runat="server" />
<asp:HiddenField ID="hfUnitValue" runat="server" />
<asp:UpdatePanel ID="updPropertyInformation" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server"></asp:Literal>
                                <div style="visibility: hidden;">
                                    <asp:LinkButton ID="lnkToRedirect" runat="server" OnClick="lnkToRedirect_OnClick"></asp:LinkButton>
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
                                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                    <tr>
                                        <td width="50%">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="50%">
                                                        <table cellpadding="5" cellspacing="0" width="100%" border="0" class="propertyinfobox">
                                                            <tr>
                                                                <td width="270px" style="width: 126px; display: block;">
                                                                    <asp:Literal ID="litProperty" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td style="width: 100px; display: block;">
                                                                    <asp:Label ID="lblPropertyName" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 250px;">
                                                                    <asp:Literal ID="litCode" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td style="width: 250px;">
                                                                    <asp:Label ID="lblPropertyCode" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    <asp:Literal ID="litAddress" runat="server"></asp:Literal>
                                                                </td>
                                                                <td valign="top">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblAddress" Width="350px" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litLocation" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litPropertyType" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblPropertyType" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litSbaSftResidential" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblSBAResidential" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litSbaSftCommercial" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblSBACommercial" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding-bottom: 15px;">
                                                                    <asp:Literal ID="litSbaSftTotal" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td style="padding-bottom: 15px;">
                                                                    <asp:Label ID="lblSBATotal" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%" style="min-height: 200px; overflow: auto; vertical-align: top;" align="left">
                                                        Amenities<br />
                                                        <br />
                                                        <asp:DataList ID="dtlstAmenities" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                                                            <ItemTemplate>
                                                                <div style="padding-right: 25px;">
                                                                    <%#DataBinder.Eval(Container.DataItem, "AmenitiesName")%></div>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                        <asp:Label ID="lblAmenitiesMsg" ForeColor="Red" Font-Size="14px" runat="server" Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="pagesubheader">
                                            <asp:Literal ID="litMainBlockInformation" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox" style="padding-bottom: 10px;">
                                            <div style="overflow: auto; width: 720px;">
                                                <style type="text/css">
                                                    .dTableBox table
                                                    {
                                                        width: auto !important;
                                                    }
                                                    
                                                    .dTableBox table tr td, .dTableBox table tr th
                                                    {
                                                        text-align: center !important;
                                                    }
                                                </style>
                                                <asp:GridView ID="grdPropertyList" runat="server" SkinID="gvAutoColumns" Width="100%"
                                                    OnRowDataBound="grdPropertyList_RowDataBound" OnPageIndexChanging="grdPropertyList_OnPageIndexChanging"
                                                    CssClass="grid_content">
                                                    <EmptyDataTemplate>
                                                        <div style="padding: 10px;">
                                                            <b>
                                                                <asp:Label ID="lblNoPropertyFound" runat="server"></asp:Label>
                                                            </b>
                                                        </div>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="pagesubheader">
                                            <asp:Literal ID="litMainUnitTypeInformation" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox">
                                            <div style="overflow: auto; width: 720px;">
                                                <style type="text/css">
                                                    .dTableBox table tr td, .dTableBox table tr th
                                                    {
                                                        text-align: left !important;
                                                    }
                                                </style>
                                                <asp:GridView ID="gvBlockInfo" runat="server" SkinID="gvNoPaging" Width="100%" OnRowDataBound="gvBlockInfo_RowDataBound"
                                                    CssClass="grid_content" ShowFooter="true" OnRowCommand="gvBlockInfo_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="180px" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Literal ID="litGvHdrUnitType" runat="server"></asp:Literal>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkRoomTypeName" Style="text-decoration: none;" runat="server"
                                                                    CommandName="ViewData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RoomTypeID")%>'><%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <b>
                                                                    <asp:Label ID="litGvFtrTotal" runat="server"></asp:Label></b>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Literal ID="litGvHdrNoOfUnits" runat="server"></asp:Literal>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "Units")%>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <b>
                                                                    <asp:Label ID="lblTotalUnits" runat="server"></asp:Label></b>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrSoldUnit" runat="server"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "SoldUnits")%>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <b>
                                                                    <asp:Label ID="lblTotalSoldUnits" runat="server"></asp:Label></b>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblGvHdrActions" runat="server" ></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.png" Style="border: 0px;
                                                                    margin-top: 2px;" CommandName="EditData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RoomTypeID")%>'
                                                                    OnClientClick="fnDisplayCatchErrorMessage()" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <div style="padding: 10px;">
                                                            <b>
                                                                <asp:Label ID="litNoBlockFound" runat="server"></asp:Label>
                                                            </b>
                                                        </div>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="btnCancel" runat="server" Style="display: inline-block;" OnClick="btnCancel_Click" />
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
                    <div class="clear">
                    </div>
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="Panel1"
            BackgroundCssClass="mod_background" CancelControlID="btnClose">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="Panel1" runat="server" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litAmenities" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>
                                <table cellpadding="3" cellspacing="3" width="400px" style="margin-left: 5px;">
                                    <tr>
                                        <td align="left" style="height: 250px; overflow: auto; vertical-align: top;">
                                            <asp:DataList ID="dtlstUnitTypeAmenities" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                                Width="95%">
                                                <ItemTemplate>
                                                    <div style="padding-right: 25px;">
                                                        <%#DataBinder.Eval(Container.DataItem, "AmenitiesName")%></div>
                                                </ItemTemplate>
                                            </asp:DataList>
                                            <asp:Label ID="lblMsgUnitTypeAmenities" ForeColor="Red" Font-Size="14px" runat="server" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btnClose" runat="server" Style="text-align: center;" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updPropertyInformation" ID="UpdateProgressPropertyInformation"
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
