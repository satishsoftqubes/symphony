<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRoomLayoutPlane.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.IRMSCofiguration.CtrlRoomLayoutPlane" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<link href="../../Style/tab_control.css" rel="stylesheet" type="text/css" />

<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <ajx:TabContainer ID="tbl98765" runat="server" ActiveTabIndex="0" Width="100%">
                <ajx:TabPanel HeaderText="ROOM PAYOUT PLANE SETUP" ID="tb789" runat="server" Width="100%">
                    <ContentTemplate>
                        <div style="height:440px">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="content" style="padding-left: 0px; width: 66.66%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                                        <tr>
                                            <td class="boxtopleft">
                                                &nbsp;
                                            </td>
                                            <td class="boxtopcenter">
                                                ROOM PAYOUT PLANE SETUP
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
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <table width="100%" cellpadding="3" cellspacing="3">
                                                            <tr>
                                                                <td align="left" valign="top" style="width: 25%;">
                                                                    <asp:Literal ID="litPropertyName" runat="server" Text="Property Name"></asp:Literal>
                                                                </td>
                                                                <td align="left" valign="top" style="width: 75%;">
                                                                    <asp:DropDownList ID="ddlPropertyName" runat="server">
                                                                        <asp:ListItem Text="-ALL-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rvfCategory" runat="server" ControlToValidate="ddlPropertyName"
                                                                        SetFocusOnError="true" CssClass="rfv_ErrorStar" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                        ErrorMessage="*" ValidationGroup="RoomTypeForm"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litPlanName" runat="server" Text="Plan Name"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPlanName" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rvfTermName" runat="server" ControlToValidate="txtPlanName"
                                                                        SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="RoomTypeForm"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litPlanCode" runat="server" Text="Plan Code"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPlanCode" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rvfTermCode" runat="server" ControlToValidate="txtPlanCode"
                                                                        SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="RoomTypeForm"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="Literal4" runat="server" Text="Select Photo"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:FileUpload ID="UplodFile" runat="server" Height="25px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" valign="top" colspan="2" style="padding-left:200px;">
                                                                    <asp:Image ID="imgThumb" runat="server" ImageUrl="~/UploadPhoto/BlankPhoto.jpg" Height="125px"
                                                                        Width="125px" /><br />
                                                                    <b>
                                                                        <asp:LinkButton ID="hypThumb" runat="server" Text="Remove" Style="padding-right: 5px;"></asp:LinkButton></b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top" colspan="2">
                                                                    <div style="float: right; width: auto; display: inline-block;">
                                                                        <asp:Button ID="btnCancel" Text="Cancel" Style="float: right; margin-left: 5px;"
                                                                            runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" />
                                                                        <asp:Button ID="btnSave" Text="Save" Style="float: right; margin-left: 5px;" runat="server"
                                                                            ImageUrl="~/images/save.png" ValidationGroup="RoomTypeForm" CausesValidation="true" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top" colspan="2" class="pagecontent_info">
                                                                    <p class="pageInformation">
                                                                        <b>Fill General Term Information have four different part</b><br />
                                                                        <br />
                                                                    </p>
                                                                    1) Manage Project Fix Term Information
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>                                                    
                                                </asp:UpdatePanel>
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
                                <td style="width: 2px;">
                                    &#160;
                                </td>
                                <td class="content">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                                        <tr>
                                            <td class="boxtopleft">
                                                &nbsp;
                                            </td>
                                            <td class="boxtopcenter">
                                                ROOM LIST
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
                                                <div class="box_leftmargin_content">
                                                    <div>
                                                        <table id="tbl" cellpadding="2" cellspacing="0" width="100%" border="0" class="pageinfo">
                                                            <tr>
                                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                                    Plan Name
                                                                </td>
                                                                <td style="vertical-align:middle;">
                                                                    <asp:TextBox ID="txtSPlanName" runat="server" SkinID="Search"></asp:TextBox>
                                                                </td>
                                                                <td align="right" valign="middle">
                                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div>
                                                    <div style="height:305px">
                                                        <asp:GridView ID="grdRoomLayoutPlaneList" runat="server" ShowHeader="false" ShowFooter="false"
                                                            SkinID="gvNoPaging" AutoGenerateColumns="false" Width="100%">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <div class="rightmargin_grid">
                                                                            <div class="leftmargin_contentarea">
                                                                                <strong><%#DataBinder.Eval(Container.DataItem, "PropertyName")%></strong>
                                                                                <br />
                                                                                <%#DataBinder.Eval(Container.DataItem, "PlanName")%><br />
                                                                                <%#DataBinder.Eval(Container.DataItem, "PlanCode")%><br />
                                                                            </div>
                                                                            <div class="leftmargin_icons">
                                                                                <asp:ImageButton ID="btnView" runat="server" ToolTip="View" ImageUrl="~/images/View.png" Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;" />
                                                                                <asp:ImageButton ID="btnEdit" runat="server" ToolTip="Edit" ImageUrl="~/images/edit.png" Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;" />
                                                                                <asp:ImageButton ID="btnDelete" runat="server" ToolTip="Delete" ImageUrl="~/images/delete_icon.png"
                                                                                    Style="border: 0px; vertical-align: middle; margin-top: 7px;
                                                                                    margin-right: 7px;" />
                                                                            </div>
                                                                            <div class="clear">
                                                                            </div>
                                                                        </div>
                                                                        <div class="clear">
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                        <div class="pageinfo" style="visibility:hidden;">
                                                            <div class="NoItemsFound" id="msgNoRecordFound" runat="server">
                                                                <h2>
                                                                    <asp:Literal ID="Literal3" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                            </div>
                                                        </div>
                                                    </div>
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
                        </div>
                    </ContentTemplate>
                </ajx:TabPanel>
                <ajx:TabPanel HeaderText="ROOM LAYOUT PLANE DETAILS" ID="bt0ok" runat="server" Width="100%">
                    <ContentTemplate>
                        <div style="height:440px">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="content" style="padding-left: 0px; width: 66.66%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                                        <tr>
                                            <td class="boxtopleft">
                                                &nbsp;
                                            </td>
                                            <td class="boxtopcenter">
                                                ROOM PAYOUT PLANE DETAILS
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
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <table width="100%" cellpadding="3" cellspacing="3">
                                                            <tr>
                                                                <td align="left" valign="top" style="width: 25%;">
                                                                    <asp:Literal ID="litRLPropertyName" runat="server" Text="Property Name"></asp:Literal>
                                                                </td>
                                                                <td align="left" valign="top" style="width: 75%;">
                                                                    <asp:DropDownList ID="ddlRLPropertyName" runat="server">
                                                                        <asp:ListItem Text="-ALL-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rvfPropertyName" runat="server" ControlToValidate="ddlRLPropertyName"
                                                                        SetFocusOnError="true" CssClass="rfv_ErrorStar" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                        ErrorMessage="*" ValidationGroup="RPPDGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litRLPlaneID" runat="server" Text="Plane Name"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlPlaneName" runat="server">
                                                                        <asp:ListItem Text="-ALL-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rvfPlaneName" runat="server" ControlToValidate="ddlPlaneName"
                                                                        SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="RPPDGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Literal ID="litWing" runat="server" Text="Wing Name"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlWingName" runat="server">
                                                                        <asp:ListItem Text="-ALL-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rvfddlWingName" runat="server" ControlToValidate="ddlWingName"
                                                                        SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="RPPDGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    <asp:Literal ID="litFloor" runat="server" Text="Floor Name"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlFLoor" runat="server">
                                                                        <asp:ListItem Text="-ALL-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rvfddlFLoor" runat="server" ControlToValidate="ddlFLoor"
                                                                        SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="RPPDGroup"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    <asp:Literal ID="litCarpetArea" runat="server" Text="Carpet Area"></asp:Literal>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCarpetArea" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top" colspan="2">
                                                                    <div style="float: right; width: auto; display: inline-block;">
                                                                        <asp:Button ID="btnRLCancel" Text="Cancel" Style="float: right; margin-left: 5px;"
                                                                            runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" />
                                                                        <asp:Button ID="btnRLSave" Text="Save" Style="float: right; margin-left: 5px;" runat="server"
                                                                            ImageUrl="~/images/save.png" ValidationGroup="RPPDGroup" CausesValidation="true" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top" colspan="2" class="pagecontent_info">
                                                                    <p class="pageInformation">
                                                                        <b>Fill General Term Information have four different part</b><br />
                                                                        <br />
                                                                    </p>
                                                                    1) Manage Project Fix Term Information
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                    </Triggers>
                                                </asp:UpdatePanel>
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
                                        <uc1:MsgBox ID="MsgBox1" runat="server" />
                                    </div>
                                </td>
                                <td style="width: 2px;">
                                    &#160;
                                </td>
                                <td class="content">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                                        <tr>
                                            <td class="boxtopleft">
                                                &nbsp;
                                            </td>
                                            <td class="boxtopcenter">
                                                ROOM PAYOUT LIST
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
                                                <div class="box_leftmargin_content">
                                                    <div>
                                                        <table id="Table1" cellpadding="2" cellspacing="0" width="100%" border="0" class="pageinfo">
                                                            <tr>
                                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                                    Name
                                                                </td>
                                                                <td style="vertical-align:middle;">
                                                                    <asp:TextBox ID="txtSPropertyName" runat="server" SkinID="Search"></asp:TextBox>
                                                                </td>
                                                                <td align="right" valign="middle">
                                                                    <asp:ImageButton ID="btnRLSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div>
                                                        <div style="height:198px">
                                                        <asp:GridView ID="grdRoomLayoutPlaneDetailsList" runat="server" ShowHeader="false"
                                                            ShowFooter="false" SkinID="gvNoPaging" AutoGenerateColumns="false" Width="100%">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <div class="rightmargin_grid">
                                                                            <div class="leftmargin_contentarea">
                                                                                <strong><%#DataBinder.Eval(Container.DataItem, "PropertyName")%></strong>
                                                                                <br />
                                                                                <%#DataBinder.Eval(Container.DataItem, "WingName")%><br />
                                                                                <%#DataBinder.Eval(Container.DataItem, "FloorName")%><br />
                                                                                <%#DataBinder.Eval(Container.DataItem, "CarpetArea")%><br />
                                                                            </div>
                                                                            <div class="leftmargin_icons">
                                                                                <asp:ImageButton ID="btnRLView" runat="server" ImageUrl="~/images/View.png" Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;" />
                                                                                <asp:ImageButton ID="btnRLEdit" runat="server" ImageUrl="~/images/edit.png" Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;" />
                                                                                <asp:ImageButton ID="btnRLDelete" runat="server" ImageUrl="~/images/delete_icon.png"
                                                                                    Style="border: 0px; vertical-align: middle; margin-top: 7px;
                                                                                    margin-right: 7px;" />
                                                                            </div>
                                                                            <div class="clear">
                                                                            </div>
                                                                        </div>
                                                                        <div class="clear">
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                        </div>
                                                        <div class="pageinfo" style="visibility:hidden;">
                                                            <div class="NoItemsFound" id="Div1" runat="server">
                                                                <h2>
                                                                    <asp:Literal ID="Literal8" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                            </div>
                                                        </div>
                                                    </div>
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
                        </div>
                    </ContentTemplate>
                </ajx:TabPanel>
            </ajx:TabContainer>
        </td>
    </tr>
</table>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>