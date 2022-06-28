<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PropertyUnits.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Configurations.PropertyUnits" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">
    
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
    
    function fnRowCommand(paramType, blockValue, unitValue) {
        if (paramType == 'BLOCK') {
            document.getElementById('<%= hfIsBlock.ClientID %>').value = "1";
        }
        else {
            document.getElementById('<%= hfIsBlock.ClientID %>').value = "0";
        }

        document.getElementById('<%= hfBlockValue.ClientID %>').value = blockValue;
        document.getElementById('<%= hfUnitValue.ClientID %>').value = unitValue;

        __doPostBack('ctl00$ContentPlaceHolder1$ucPropertyUnits$lnkToRedirect', '');
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

<asp:HiddenField ID="hfIsBlock" runat="server" />
<asp:HiddenField ID="hfBlockValue" runat="server" />
<asp:HiddenField ID="hfUnitValue" runat="server" />
<asp:UpdatePanel ID="updPropertyList" runat="server">
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
                                PROPERTY INFORMATION
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
                                                    <td width="50%" style="border-right:1px solid Gray;">
                                                        <table cellpadding="5" cellspacing="0" width="100%" border="0" class="propertyinfobox">
                                                            <tr>
                                                                <td width="155px">
                                                                    Property
                                                                </td>
                                                                <td width="5px">
                                                                    :
                                                                </td>
                                                                <td width="250px">
                                                                    <asp:Label ID="lblPropertyName" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Code
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblPropertyCode" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    Address
                                                                </td>
                                                                <td valign="top">
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    City
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
                                                                    Property Type
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
                                                                    SBA (Sft) Residential
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
                                                                    SBA (Sft) Commercial
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
                                                                    SBA (Sft) Total
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
                                                    <td width="50%" style="min-height: 200px; overflow: auto; padding-left:15px;" align="left">
                                                        Amenities<br /><br />
                                                        <asp:DataList ID="dtlstAmenities" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                                                            <ItemTemplate>
                                                                <div style="padding-right: 25px;">
                                                                    <%#DataBinder.Eval(Container.DataItem, "AmenitiesName")%></div>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                        <asp:Label ID="lblAmenitiesMsg" ForeColor="Red" Font-Size="14px" runat="server" Text="No Record Found"
                                                            Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="pagesubheader">
                                            <asp:Literal ID="Literal1" runat="server" Text="Block Information"></asp:Literal>
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
                                                        <div class="pagecontent_info">
                                                            <div class="NoItemsFound">
                                                                <h2>
                                                                    <asp:Literal ID="Literal5" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                            </div>
                                                        </div>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="pagesubheader">
                                            <asp:Literal ID="Literal4" runat="server" Text="Unit Type Information"></asp:Literal>
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
                                                        <asp:TemplateField HeaderText="Type of Unit" ItemStyle-Width="180px" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkRoomTypeName" Style="text-decoration: none;" runat="server"
                                                                    CommandName="EditData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RoomTypeID")%>'><%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SBA (Sft)" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSBArea" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Carpet Area (Sft)" ItemStyle-Width="115px" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCorpArea" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <b>Total</b>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="No. of Units" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "Units")%>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <b>
                                                                    <asp:Label ID="lblTotalUnits" runat="server"></asp:Label></b>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Units Sold" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "SoldUnits")%>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <b>
                                                                    <asp:Label ID="lblTotalSoldUnits" runat="server"></asp:Label></b>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit/View" ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center"
                                                            ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.png" Style="border: 0px;
                                                                    vertical-align: middle; margin-top: 2px; padding-left: 18px;" CommandName="EditData"
                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RoomTypeID")%>' OnClientClick="fnDisplayCatchErrorMessage()" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <div class="pagecontent_info">
                                                            <div class="NoItemsFound">
                                                                <h2>
                                                                    <asp:Literal ID="Literal5" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                            </div>
                                                        </div>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="btnCancel" runat="server" Style="display: inline-block;" Text="Back" OnClick="btnCancel_Click" />
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
        <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="Panel1"
            BackgroundCssClass="mod_background" CancelControlID="btnClose">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="Panel1" runat="server" style="display:none;">
            <div style="width: 500px; height: 200px; margin-top: 25px;">
                <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
                    <tr>
                        <td class="modelpopup_boxtopleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxtopcenter">
                            Amenities
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
                            <table cellpadding="3" cellspacing="3" width="400px" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="left" valign="middle" style="height: 200px; overflow: auto;">
                                        <asp:DataList ID="dtlstUnitTypeAmenities" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" Width="95%">
                                            <ItemTemplate>
                                                <div style="padding-right: 25px;">
                                                    <%#DataBinder.Eval(Container.DataItem, "AmenitiesName")%></div>
                                            </ItemTemplate>
                                        </asp:DataList>
                                        <asp:Label ID="lblMsgUnitTypeAmenities" ForeColor="Red" Font-Size="14px" runat="server"
                                            Text="No Any Amenities Available" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnClose" runat="server" Text="Close" style="text-align:center;" />
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
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div> 
<asp:UpdateProgress AssociatedUpdatePanelID="updPropertyList" ID="UpdateProgressPropertyList"
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
