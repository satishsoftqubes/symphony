﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPurchaseScheduleList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Configurations.CtrlPurchaseScheduleList" %>

<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">

    function fnConfirmDelete(id) {
        debugger;
        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnPropertyData.ClientID %>').value = id;
        $find('DeletePropertyData').show();
        return false;
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<style type="text/css">
    #progressBackgroundFilter {
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

    #processMessage {
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

    /*.mod_background
    {
	    background:url(../images/bg_modal1.png);
    }*/
</style>
<asp:UpdatePanel ID="updPurchaseScheduleList" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopcenter">PURCHASE SCHEDULE
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td>
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td>
                                                <div style="height: 26px;">
                                                    <%if (IsMessage)
                                                        { %>
                                                    <div class="ResetSuccessfully">
                                                        <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                            <img src="../../images/success.png" />
                                                        </div>
                                                        <div>
                                                            <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                                                        </div>
                                                        <div style="height: 10px;">
                                                        </div>
                                                    </div>
                                                    <%}%>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <table cellpadding="2" cellspacing="2" border="0">
                                    <tr>
                                        <td width="150px">
                                            <asp:Literal ID="litPropertyName" runat="server" Text="Property Name"></asp:Literal>
                                        </td>
                                        <td width="250px">
                                            <asp:DropDownList ID="txtPropertyName" runat="server" Style="width: 165px;">
                                            </asp:DropDownList>
                                            <asp:ImageButton ID="btnSearch" CssClass="small_img" Style="border: 0px; vertical-align: middle; margin-left: 5px;"
                                                runat="server" ImageUrl="~/images/search-icon.png" OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="middle">
                                <asp:Button ID="btnAddPurchaseScheduleTop" runat="server" Text="Add New" OnClick="btnAdd_Click" Style="float: right;" />
                            </td>
                        </tr>
                        <tr>
                            <td class="dTableBox" style="padding: 10px 0px">
                                <asp:GridView ID="grdPurchaseScheduleList" runat="server" AutoGenerateColumns="False" Width="100%"
                                    OnPageIndexChanging="grdPurchaseScheduleList_OnPageIndexChanging" CssClass="grid_content"
                                    OnRowDataBound="grdPurchaseScheduleList_RowDataBound" OnRowCommand="grdPurchaseScheduleList_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Property Name" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnUnitInfo" Text='<%#DataBinder.Eval(Container.DataItem, "PropertyName")%>'
                                                    runat="server" CommandName="UNITINFO" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PropertyID")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit / View" ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEdit" runat="server" ToolTip="Edit" ImageUrl="~/images/edit.png"
                                                    Style="border: 0px; vertical-align: middle; margin-top: 2px;" CommandName="EDITDATA"
                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PropertyID")%>' OnClientClick="fnDisplayCatchErrorMessage()" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnDelete" runat="server" ToolTip="Delete" ImageUrl="~/images/delete_icon.png"
                                                    Style="border: 0px; vertical-align: middle; margin-top: 1px;" CommandName="DELETEDATA"
                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PropertyID")%>' OnClientClick="fnDisplayCatchErrorMessage()" />
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
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="middle">
                                <asp:Button ID="btnAddPurchaseSchedule" runat="server" Text="Add New" OnClick="btnAdd_Click" Style="float: right;" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

        <!-- Delete Popup Box-->
        <ajx:ModalPopupExtender ID="DeletePropertyData" runat="server" TargetControlID="hdnPropertyData"
            PopupControlID="pnlPropertyData" BackgroundCssClass="mod_background" CancelControlID="btnNo">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnPropertyData" runat="server" />
        <asp:Panel ID="pnlPropertyData" runat="server" Height="350px" Width="325px" style="display:none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litPropertyDataHeader" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="litPropertyDataMsg" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYes" runat="server" Style="display: inline; padding-right: 10px;"
                                   OnClick="btnYes_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                <asp:Button ID="btnNo" runat="server" Style="display: inline;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <!-- End Delete Popup Box-->

    </ContentTemplate>
</asp:UpdatePanel>

<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updPurchaseScheduleList" ID="UpdateProgressPropertyList"
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
