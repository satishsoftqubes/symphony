<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPropertyInsuranceView.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp.CtrlPropertyInsuranceView" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
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
<asp:UpdatePanel ID="updPropertyInsuranceView" runat="server">
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
                                        <td style="padding: 10px 0px; border-bottom: 1px solid #ccccce; padding-right: 7px;">
                                            <div style="margin-bottom: 30px; font-weight: bold;">
                                                <asp:Literal ID="litInsuranceTitle" runat="server" Text="Insurance"></asp:Literal>
                                            </div>
                                            <div class="dTableBox">
                                                <%--<asp:GridView ID="gvPropertyInsuranceView" runat="server" AutoGenerateColumns="False"
                                                    SkinID="gvNoPaging" OnRowDataBound="gvPropertyInsuranceView_RowDataBound" OnRowCommand="gvPropertyInsuranceView_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Insurance Period" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkToViewInsuranceDetail" CommandName="INSURANCEDETAILS" runat="server"
                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem, "InsuranceID")%>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View Document" ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Left"
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
                                                </asp:GridView>--%>
                                                <asp:GridView ID="gvPropertyInsuranceView" runat="server" AutoGenerateColumns="False"
                                                    Width="100%" OnRowCommand="gvPropertyInsuranceView_RowCommand" OnPageIndexChanging="gvPropertyInsuranceView_OnPageIndexChanging" OnRowDataBound="gvPropertyInsuranceView_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField DataField="PropertyName" HeaderText="Property Name" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left" />
                                                        <asp:TemplateField HeaderText="Start Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                            ItemStyle-Width="90px">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="litStartDate" runat="server"></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Valid Upto" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                            ItemStyle-Width="90px">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="litValidUpto" runat="server"></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="CompanyName" HeaderText="Insurance Company" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="125px" />
                                                        <asp:BoundField DataField="PolicyNo" HeaderText="Policy No." HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="90px" />
                                                        <asp:TemplateField HeaderText="View Document" ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left"
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
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 10px 0px; padding-left: 7px; padding-top: 20px;">
                                            <div style="margin-bottom: 30px; font-weight: bold;">
                                                <asp:Literal ID="litPropertyTax" runat="server" Text="Tax"></asp:Literal>
                                            </div>
                                            <div class="pagecontent_info">
                                                <div class="NoItemsFound">
                                                    <h2>
                                                        <asp:Literal ID="Literal3" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                </div>
                                            </div>
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
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hfnInsuranceDetail" runat="server" />
        <ajx:ModalPopupExtender ID="mpeInsuranceDetails" runat="server" TargetControlID="hfnInsuranceDetail"
            PopupControlID="pnlInsuranceDetails" BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlInsuranceDetails" runat="server">
            <div style="width: 429px; height: 260px; margin-top: 25px;">
                <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
                    <tr>
                        <td class="modelpopup_boxtopleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxtopcenter">
                            <asp:Label ID="litInsuranceDetails" runat="server" Text="Insurance Details"></asp:Label>
                            <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                                <asp:ImageButton ID="imgCancelAddServices" runat="server" ImageUrl="~/images/closepopup.png"
                                    Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
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
                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                <tr>
                                    <td style="width: 200px">
                                        <asp:Label ID="litPropertyName" Font-Bold="true" runat="server" Text="Property Name"></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="litDispPropertyName" Text="-" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="litInsuranceperiod" Font-Bold="true" runat="server" Text="Insurance Period"></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="litDispInsuranceperiod" runat="server" Text="-"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCompanyName" Font-Bold="true" runat="server" Text="Company Name"></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="lblDispCompanyName" runat="server" Text="-"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPolicyNo" Font-Bold="true" runat="server" Text="Policy No."></asp:Label>
                                    </td>
                                    <td style="text-align: left; vertical-align: top">
                                        <asp:Label ID="lblDispPolicyNo" runat="server" Text="-"></asp:Label>
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
<asp:UpdateProgress AssociatedUpdatePanelID="updPropertyInsuranceView" ID="UpdateProgressPropertyInsuranceView"
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
