<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlServiceManager.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Banquet.CtrlServiceManager" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updServicemanager" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server" Text="Service manager"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                            </td>
                            <td>
                                <div class="box_form">
                                    <asp:MultiView ID="mvServiceManager" runat="server">
                                        <asp:View runat="server" ID="vServiceManagerList">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td style="width: 80px;">
                                                        <asp:Literal ID="litSearchManager" runat="server" Text="Manager"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchManager" runat="server" Style="width: 120px !important;"
                                                            SkinID="searchtextbox"></asp:TextBox>
                                                        <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                            Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" />
                                                        <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                            Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="right" valign="middle">
                                                        <asp:Button ID="btnAddTopServiceManager" runat="server" Style="float: right;" Text="Add"
                                                            OnClick="btnAddTopServiceManager_OnClick" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="litServiceManagerList" runat="server" Text="Service Manager List"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvServiceManagerList" runat="server" AutoGenerateColumns="false"
                                                                ShowHeader="true" Width="100%">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrManager" runat="server" Text="Manager"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "Manager")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAction" runat="server" Text="Action"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblServiceManagerListPopUp" runat="server" Text="Actions"></asp:Label>
                                                                            <ajx:HoverMenuExtender ID="hmeServiceManagerList" runat="server" TargetControlID="lblServiceManagerListPopUp"
                                                                                PopupControlID="panServiceManagerListPhone" PopupPosition="Left">
                                                                            </ajx:HoverMenuExtender>
                                                                            <asp:Panel ID="panServiceManagerListPhone" runat="server" Style="visibility: hidden;
                                                                                opacity: 100%">
                                                                                <div class="actionsbuttons_hovermenu">
                                                                                    <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                                        <tr>
                                                                                            <td class="actionsbuttons_hover_lettmenu">
                                                                                            </td>
                                                                                            <td class="actionsbuttons_hover_centermenu">
                                                                                                <ul>
                                                                                                    <li>
                                                                                                        <asp:LinkButton ID="lnkServiceManagerEdit" runat="server" Style="background: none !important;
                                                                                                            border: none;" ToolTip="Edit" CommandName="EDIT"><img src="../../images/edit.png" /></asp:LinkButton>
                                                                                                    </li>
                                                                                                    <li>
                                                                                                        <asp:LinkButton ID="lnkServiceManager" runat="server" Style="background: none !important;
                                                                                                            border: none;" ToolTip="Delete" CommandName="DELETE"><img src="../../images/delete_icon.png" /></asp:LinkButton>
                                                                                                    </li>
                                                                                                </ul>
                                                                                            </td>
                                                                                            <td class="actionsbuttons_hover_rightmenu">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </asp:Panel>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFoundForRoomReservation" runat="server" Text="No Record Found."></asp:Label>
                                                                        </b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="right" valign="middle">
                                                        <asp:Button ID="btnAddBottomServiceManager" runat="server" Style="float: right;"
                                                            Text="Add" OnClick="btnAddTopServiceManager_OnClick" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View runat="server" ID="vServiceManagerAdd">
                                            <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td style="vertical-align: top; border-right: 1px solid #ccccce;">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <h1>
                                                                        <asp:Literal ID="litManager" runat="server" Text="Manager Information"></asp:Literal></h1>
                                                                    <hr>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 80px !important;" class="isrequire">
                                                                    <asp:Literal ID="litName" runat="server" Text="Name"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <div style="float: left;">
                                                                        <asp:DropDownList ID="ddlTitle" runat="server" Style="width: 50px; height: 25px;">
                                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                            
                                                                            <asp:ListItem Text="Mr." Value="Mr."></asp:ListItem>
                                                                            <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                                                                            <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <span>
                                                                            <asp:RequiredFieldValidator ID="rvfTitle" ValidationGroup="IsRequire" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                ControlToValidate="ddlTitle" Display="Dynamic">
                                                                            </asp:RequiredFieldValidator>
                                                                        </span>
                                                                        <asp:TextBox ID="txtFirstName" runat="server" MaxLength="150" Style="width: 90px !important;"></asp:TextBox><ajx:TextBoxWatermarkExtender ID="txtwmeFirstName" runat="server" TargetControlID="txtFirstName"
                    WatermarkText="First Name">
                </ajx:TextBoxWatermarkExtender>
                                                                        <span>
                                                                            <asp:RequiredFieldValidator ID="rvfFirstName" ValidationGroup="IsRequire" SetFocusOnError="true"
                                                                                CssClass="input-notification error png_bg" runat="server" ControlToValidate="txtFirstName"
                                                                                Display="Dynamic">
                                                                            </asp:RequiredFieldValidator>
                                                                        </span>
                                                                        <asp:TextBox ID="txtLastName" runat="server" MaxLength="150" Style="width: 90px !important;"></asp:TextBox><ajx:TextBoxWatermarkExtender ID="txtwmeLastName" runat="server" TargetControlID="txtLastName"
                    WatermarkText="Last Name">
                </ajx:TextBoxWatermarkExtender>
                                                                        &nbsp;&nbsp;&nbsp;
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="isrequire">
                                                                    <asp:Literal ID="litServiceArea" Text="Service Area" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlServiceArea" runat="server" Style="width: 150px; height: 25px;">
                                                                        <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                        <asp:ListItem Text="Bartender" Value="Bartender"></asp:ListItem>
                                                                        <asp:ListItem Text="Entertainer" Value="Entertainer"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rvfServiceArea" ValidationGroup="IsRequire" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                            SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                            ControlToValidate="ddlServiceArea" Display="Dynamic">
                                                                        </asp:RequiredFieldValidator>
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litSupplier" Text="Supplier" runat="server"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlSupplier" runat="server" Style="width: 150px; height: 25px;">
                                                                        <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                        <asp:ListItem Text="Satish" Value="Satish"></asp:ListItem>
                                                                        <asp:ListItem Text="Dipen" Value="Dipen"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litCharge" runat="server" Text="Charge"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCharge" runat="server" Style="width: 150px;"></asp:TextBox>
                                                                    <ajx:FilteredTextBoxExtender ID="ftbCharge" runat="server" TargetControlID="txtCharge"
                                                                        FilterType="custom,Numbers" ValidChars="." />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="vertical-align: top;">
                                                                    <asp:Literal ID="litChargeType" runat="server" Text="Charge Type"></asp:Literal>
                                                                </td>
                                                                <td style="vertical-align: top;">
                                                                    <asp:RadioButtonList runat="server" ID="rblChargeType" RepeatColumns="2" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Per Person" Value="Per Rerson"></asp:ListItem>
                                                                        <asp:ListItem Text="On Event" Value="On Event"></asp:ListItem>
                                                                        <asp:ListItem Text="Per Hourly" Value="Per Hourly"></asp:ListItem>
                                                                        <asp:ListItem Text="Per Day" Value="Per Day"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="vertical-align: top;">
                                                                    <asp:Literal ID="litDescription" runat="server" Text="Description"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <h1>
                                                                        <asp:Literal ID="ltrHeaderAddress" runat="server" Text="Address Information"></asp:Literal></h1>
                                                                    <hr>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table border="0" cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td style="vertical-align: top;">
                                                                                <asp:Literal ID="litAddress" runat="server" Text="Address"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litContact" runat="server" Text="Contact"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtContact" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litFaxNo" runat="server" Text="Fax No."></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtFaxNo" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="isrequire">
                                                                                <asp:Literal ID="litEmail" runat="server" Text="Email"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rvfEmail" ValidationGroup="IsRequire" SetFocusOnError="true"
                                                                                        CssClass="input-notification error png_bg" runat="server" ControlToValidate="txtEmail"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span><span>
                                                                                    <asp:RegularExpressionValidator ID="refEmail" Display="Dynamic" SetFocusOnError="True"
                                                                                        ControlToValidate="txtEmail" ValidationGroup="IsRequire" runat="server" ErrorMessage="Email Is Not Valide"
                                                                                        ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="isrequire">
                                                                                <asp:Literal ID="litUrl" runat="server" Text="URL"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvUrl" ValidationGroup="IsRequire" SetFocusOnError="true"
                                                                                        CssClass="input-notification error png_bg" runat="server" ControlToValidate="txtUrl"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span><span>
                                                                                    <asp:RegularExpressionValidator ID="rgvtxtURL" ValidationGroup="IsRequire" runat="server"
                                                                                        ErrorMessage="URL Is Not Valide" ForeColor="Red" ControlToValidate="txtUrl" ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator></span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litZipCode" runat="server" Text="ZipCode"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litCityName" runat="server" Text="City"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCityName" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litStateName" runat="server" Text="State"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtStateName" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litCountryName" runat="server" Text="Country"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCountryName" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <tr>
                                                        <td colspan="2" style="padding-top: 8px;" align="right">
                                                            <asp:Button ID="btnSave" runat="server" ValidationGroup="IsRequire" Style="display: inline;
                                                                padding-right: 10px;" Text="Save" />
                                                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_OnClick" Style="display: inline;"
                                                                Text="Cancel" />
                                                        </td>
                                                    </tr>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
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
                    <div class="clear">
                    </div>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updServicemanager" ID="UpdateProgressServicemanager"
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
