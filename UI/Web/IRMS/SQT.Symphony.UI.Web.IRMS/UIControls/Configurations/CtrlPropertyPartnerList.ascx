<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPropertyPartnerList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Configurations.CtrlPropertyPartnerList" %>

<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">

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
</style>

<asp:UpdatePanel ID="updPropertyPartnerList" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">&nbsp;
                            </td>
                            <td class="boxtopcenter">PROPERTY PARTNER
                            </td>
                            <td class="boxtopright">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">&nbsp;
                            </td>
                            <td>
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
                                    <tr>
                                        <td align="left">
                                            <table cellpadding="2" cellspacing="2" border="0">
                                                <tr>
                                                    <td width="150px">
                                                        <asp:Literal ID="litPropertyName" runat="server" Text="Property Name"></asp:Literal>
                                                    </td>
                                                    <td width="250px">
                                                        <asp:DropDownList ID="ddlPropertyName" runat="server" Style="width: 165px;">
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
                                            <asp:Button ID="btnAddTop" runat="server" Text="Add New" OnClick="btnAdd_Click" Style="float: right;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox" style="padding: 10px 0px">
                                            <asp:GridView ID="grdSalerList" runat="server" AutoGenerateColumns="False" Width="100%"
                                                OnPageIndexChanging="grdSalerList_OnPageIndexChanging" OnRowCommand="grdSalerList_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="First Name" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkbtnfirstName" Text='<%#DataBinder.Eval(Container.DataItem, "FirstName")%>'
                                                                runat="server" CommandName="FIRSTNAME" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PartnerID")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Middle Name" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkbtnmiddleName" Text='<%#DataBinder.Eval(Container.DataItem, "MiddleName")%>'
                                                                runat="server" CommandName="MIDDLENAME" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PartnerID")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Last Name" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkbtnlastName" Text='<%#DataBinder.Eval(Container.DataItem, "LastName")%>'
                                                                runat="server" CommandName="LASTNAME" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PartnerID")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mobile No" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkbtnmobileNo" Text='<%#DataBinder.Eval(Container.DataItem, "MobileNo")%>'
                                                                runat="server" CommandName="UNITINFO" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PartnerID")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit/View" ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" runat="server" ToolTip="Edit" ImageUrl="~/images/edit.png"
                                                                Style="border: 0px; vertical-align: middle; margin-top: 2px;" CommandName="EDITDATA"
                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PartnerID")%>' OnClientClick="fnDisplayCatchErrorMessage()" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnDelete" runat="server" ToolTip="Delete" ImageUrl="~/images/delete_icon.png"
                                                                Style="border: 0px; vertical-align: middle; margin-top: 1px;" CommandName="DELETEDATA"
                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PartnerID")%>' OnClientClick="fnDisplayCatchErrorMessage()" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="middle">
                                            <asp:Button ID="btnAdd" runat="server" Text="Add New" OnClick="btnAdd_Click" Style="float: right;" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="boxright">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxbottomleft">&nbsp;
                            </td>
                            <td class="boxbottomcenter">&nbsp;
                            </td>
                            <td class="boxbottomright">&nbsp;
                            </td>
                        </tr>
                    </table>
                    <div class="clear_divider">
                    </div>
                </td>
            </tr>
        </table>
        <%--<ajx:ModalPopupExtender ID="Deletemsgbx" runat="server" TargetControlID="hfMessage" PopupControlID="Panel1"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="Panel1" runat="server" Style="display: none;">
            <div style="width: 500px; height: 200px; margin-top: 25px;">
                <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
                    <tr>
                        <td class="modelpopup_boxtopleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxtopcenter">
                            &nbsp;
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
                            <div style="width: 100px; float: left; margin-top: 10px;">
                                <asp:HyperLink ID="HyperLink1" runat="server">
                                    <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                        ID="Image1" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div style="float: left; width: 225px; margin-top: 40px; margin-left: 10px;">
                                <asp:Label ID="Label1" runat="server" Text="Sure you want to delete?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <asp:Button ID="btnSalerYes" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                           OnClick="btnSalerYes_Click"  Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnSalerNo" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                             OnClick="btnSalerNo_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
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
        </asp:Panel>--%>
    </ContentTemplate>
</asp:UpdatePanel>

<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updPropertyPartnerList" ID="UpdateProgressPropertyPartnerList"
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
