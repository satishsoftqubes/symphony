<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlFloor.ascx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Configurations.CtrlFloor" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script>

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function pageLoad(sender, args) {
        $(function () {
            $("#tabs").tabs();
        });

        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });
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
<asp:UpdatePanel ID="updFloor" runat="server">
    <ContentTemplate>
    <asp:HiddenField ID="hdnProcessType" runat="server" />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <div class="demo">
                        <div id="tabs">
                            <ul>
                                <li><a href="#tabs-1">BLOCK</a></li>
                                <li><a href="#tabs-2">FLOOR</a></li>
                            </ul>
                            <div id="tabs-1">
                                <div style="height: 430px;">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="Table1" style="height: 430px;">
                                        <tr>
                                            <td class="content" style="padding-left: 0px; width: 66.66%">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                                                    <tr>
                                                        <td class="boxtopleft">
                                                            &nbsp;
                                                        </td>
                                                        <td class="boxtopcenter">
                                                            BLOCK SETUP
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
                                                            <div style="height: 355px;">
                                                                <table width="100%" cellpadding="3" cellspacing="3">
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <div style="height: 26px;">
                                                                                <%if (IsWInsert)
                                                                                  { %>
                                                                                <div class="ResetSuccessfully">
                                                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                                                        <img src="../../images/success.png" />
                                                                                    </div>
                                                                                    <div>
                                                                                        <asp:Label ID="lblWingMessage" runat="server"></asp:Label></div>
                                                                                    <div style="height: 10px;">
                                                                                    </div>
                                                                                </div>
                                                                                <%
                                                                                    }%>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <div style="float: right;">
                                                                                <b>All Bold Fields are Mandatory</b>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top" style="width: 120px;">
                                                                            <asp:Label ID="litPropertyName" runat="server" Text="Property Name" CssClass="RequireFile"></asp:Label>
                                                                            <span class="erroraleart">
                                                                                <asp:RequiredFieldValidator ID="rvfPropertyName" SetFocusOnError="True" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                    CssClass="rfv_ErrorStar" runat="server" ControlToValidate="ddlWPropertyName"
                                                                                    ErrorMessage="*" ValidationGroup="WingGroup"></asp:RequiredFieldValidator>
                                                                            </span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlWPropertyName" runat="server" Style="width: 202px;">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top" style="width: 125px;">
                                                                            <asp:Label ID="litWingName" runat="server" Text="Block Name" CssClass="RequireFile"></asp:Label>
                                                                            <span class="erroraleart">
                                                                                <asp:RequiredFieldValidator ID="reqWingName" runat="server" ControlToValidate="txtWingName"
                                                                                    ErrorMessage="*" ValidationGroup="WingGroup" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                                            </span>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtWingName" runat="server" MaxLength="17" SkinID="CmpTextbox"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="litWingCode" runat="server" Text="Block Code" CssClass="RequireFile"></asp:Label>
                                                                            <span class="erroraleart">
                                                                                <asp:RequiredFieldValidator ID="rvfWingCode" runat="server" ControlToValidate="txtWingCode"
                                                                                    ErrorMessage="*" ValidationGroup="WingGroup" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                                            </span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtWingCode" runat="server" MaxLength="3" SkinID="CmpTextbox"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="text-align: right;">
                                                                            <div style="float: right; width: auto; display: inline-block;">
                                                                                <asp:Button ID="btnNewWing" runat="server" Style="display: inline-block; margin-left: 5px;
                                                                                    display: inline;" Text="New" OnClick="btnNewWing_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                                <asp:Button ID="btnSaveWing" Text="Save" Style="display: inline-block; margin-left: 5px;"
                                                                                    runat="server" ImageUrl="~/images/save.png" ValidationGroup="WingGroup" OnClick="btnSaveWing_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                                <%--<asp:Button ID="btnCancelWing" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="False" OnClick="btnCancelWing_Click" OnClientClick="fnDisplayCatchErrorMessage()" />--%>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
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
                                                            QUICK SEARCH
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
                                                            <div style="height: 355px;">
                                                                <div class="box_leftmargin_content">
                                                                    <div>
                                                                        <table id="Table2" cellpadding="1" cellspacing="0" width="100%" border="0" class="pageinfo">
                                                                            <tr>
                                                                                <td align="left" valign="middle">
                                                                                    <p class="pageInformation">
                                                                                        Property Name</p>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlProperty" runat="server" SkinID="Search">
                                                                                    </asp:DropDownList>
                                                                                    <asp:ImageButton ID="btnSearchWing" runat="server" ImageUrl="~/images/search-icon.png"
                                                                                        Style="border: 0px; vertical-align: middle; margin-top: -4px; margin-left: 5px;"
                                                                                        OnClick="btnSearchWing_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div>
                                                                        <div style="height: 325px; overflow-x: hidden; overflow-y: auto;">
                                                                            <asp:GridView ID="grdWingList" runat="server" ShowHeader="False" AutoGenerateColumns="False"
                                                                                SkinID="gvNoPaging" Width="92%" OnRowCommand="grdWingList_RowCommand" OnRowDataBound="grdWingList_RowDataBound">
                                                                                <Columns>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <div class="rightmargin_grid">
                                                                                                <div class="leftmargin_contentarea" style="width: 125px;">
                                                                                                    <strong>
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "WingName")%></strong><br />
                                                                                                        <asp:Label ID="lblPropertyName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PropertyName")%>'></asp:Label>
                                                                                                        <a id="aBreaker" runat="server"></a>
                                                                                                    <div style="width: 80px; float: left;">
                                                                                                        Floors:
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "FloorCount")%></div>
                                                                                                    <%--<asp:LinkButton ID="lnkFloorCount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FloorCount")%>'
                                                                                                        CommandArgument='<%#Eval("WingID") +"," + Eval("PropertyID")%>' CommandName="FloorData"></asp:LinkButton>--%>
                                                                                                    Units:
                                                                                                    <%#DataBinder.Eval(Container.DataItem, "UnitCount")%><%--<asp:LinkButton ID="LinkButton1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "UnitCount")%>'
                                                                                                        CommandArgument='<%#Eval("WingID")+"," + Eval("PropertyID")%>' CommandName="UnitData"></asp:LinkButton>--%></div>
                                                                                                <div class="leftmargin_icons">
                                                                                                    <asp:ImageButton ID="btnWingEdit" ToolTip="Edit" CommandName="EDITDATA" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "WingID")%>'
                                                                                                        runat="server" ImageUrl="~/images/edit.png" Style="border: 0px; vertical-align: middle;
                                                                                                        margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                                                    <asp:ImageButton ID="btnWingDelete" ToolTip="Delete" CommandName="DELETEDATA" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "WingID")%>'
                                                                                                        runat="server" ImageUrl="~/images/delete_icon.png" Style="border: 0px; vertical-align: middle;
                                                                                                        margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                                                </div>
                                                                                                <div class="clear">
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="clear">
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
                            </div>
                            <div id="tabs-2">
                                <div style="height: 430px;">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tblFloor" style="height: 430px;">
                                        <tr>
                                            <td class="content" style="padding-left: 0px; width: 66.66%">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                                                    <tr>
                                                        <td class="boxtopleft">
                                                            &nbsp;
                                                        </td>
                                                        <td class="boxtopcenter">
                                                            FLOOR SETUP
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
                                                            <div style="height: 355px; overflow: auto;">
                                                                <table width="100%" cellpadding="3" cellspacing="3">
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <div style="height: 26px;">
                                                                                <%if (IsFInsert)
                                                                                  { %>
                                                                                <div class="ResetSuccessfully">
                                                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                                                        <img src="../../images/success.png" />
                                                                                    </div>
                                                                                    <div>
                                                                                        <asp:Label ID="lblFMessage" runat="server"></asp:Label></div>
                                                                                    <div style="height: 10px;">
                                                                                    </div>
                                                                                </div>
                                                                                <% 
                                                                                    }%>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <div style="float: right;">
                                                                                <b>All Bold Fields are Mandatory</b>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top" style="width: 120px;">
                                                                            <asp:Label ID="Literal1" runat="server" Text="Property Name" CssClass="RequireFile"></asp:Label>
                                                                            <span class="erroraleart">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                    SetFocusOnError="True" CssClass="rfv_ErrorStar" runat="server" ControlToValidate="ddlPropertyFloor"
                                                                                    ErrorMessage="*" ValidationGroup="FloorGroup"></asp:RequiredFieldValidator>
                                                                            </span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlPropertyFloor" runat="server" OnSelectedIndexChanged="ddlPropertyFloor_SelectedIndexChanged"
                                                                                AutoPostBack="True" Style="width: 202px;">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top" style="width: 125px;">
                                                                            <asp:Label ID="litFloorName" runat="server" Text="Floor" CssClass="RequireFile"></asp:Label>
                                                                            <span class="erroraleart">
                                                                                <asp:RequiredFieldValidator ID="reqFloorName" runat="server" ControlToValidate="txtFloorName"
                                                                                    ErrorMessage="*" ValidationGroup="FloorGroup" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                                                            </span>
                                                                        </td>
                                                                        <td align="left" valign="top">
                                                                            <asp:TextBox ID="txtFloorName" runat="server" MaxLength="3" SkinID="CmpTextbox"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Literal ID="ltrFloorBlocks" runat="server" Text="Block"></asp:Literal>
                                                                        </td>
                                                                        <td class="checkbox_new">
                                                                            <div style="min-height: 25px; overflow: auto; height: 160px;">
                                                                                <asp:CheckBoxList ID="chkFloorBlocks" runat="server" RepeatDirection="Horizontal"
                                                                                    RepeatColumns="2">
                                                                                </asp:CheckBoxList>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="text-align: right;">
                                                                            <div style="float: right; width: auto; display: inline-block;">
                                                                                <asp:Button ID="btnNewF" runat="server" Style="display: inline-block; margin-left: 5px;
                                                                                    display: inline;" Text="New" OnClick="btnNewF_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                                <asp:Button ID="btnSave" Text="Save" Style="display: inline-block; margin-left: 5px;"
                                                                                    runat="server" ImageUrl="~/images/save.png" ValidationGroup="FloorGroup" OnClick="btnSave_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                                <%--<asp:Button ID="btnCancel" Text="Cancel" Style="display: inline-block; margin-left: 5px;"
                                                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="False" OnClick="btnCancel_Click" OnClientClick="fnDisplayCatchErrorMessage()" />--%>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
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
                                                            QUICK SEARCH
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
                                                                    <table id="tbl" cellpadding="1" cellspacing="0" width="100%" border="0" class="pageinfo">
                                                                        <tr>
                                                                            <td align="left" valign="middle">
                                                                                <p class="pageInformation">
                                                                                    Property Name</p>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlSFloorSearch" runat="server" SkinID="Search">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                                                    Style="border: 0px; vertical-align: middle; margin-top: 4px; margin-left: 5px;"
                                                                                    OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <div>
                                                                    <div style="height: 325px; overflow-x: hidden; overflow-y: auto;">
                                                                        <asp:GridView ID="grdFloorList" runat="server" ShowHeader="False" AutoGenerateColumns="False"
                                                                            SkinID="gvNoPaging" Width="92%" OnRowCommand="grdFloorList_RowCommand" OnRowDataBound="grdFloorList_RowDataBound">
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <div class="rightmargin_grid">
                                                                                            <div class="leftmargin_contentarea" style="width: 120px;">
                                                                                                <strong>
                                                                                                    <%#DataBinder.Eval(Container.DataItem, "FloorName")%></strong>
                                                                                                    <a id="aBreaker" runat="server"></a>
                                                                                                    <asp:Label ID="lblPropertyName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PropertyName")%>'></asp:Label>
                                                                                            </div>
                                                                                            <div class="leftmargin_icons">
                                                                                                <asp:ImageButton ID="btnEdit" ToolTip="Edit" CommandName="EDITDATA" runat="server"
                                                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem, "FloorID")%>' ImageUrl="~/images/edit.png"
                                                                                                    Style="border: 0px; vertical-align: middle; margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                                                <asp:ImageButton ID="btnDelete" ToolTip="Delete" CommandName="DELETEDATA" runat="server"
                                                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem, "FloorID")%>' ImageUrl="~/images/delete_icon.png"
                                                                                                    Style="border: 0px; vertical-align: middle; margin-right: 7px;" OnClientClick="fnDisplayCatchErrorMessage()" />
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
                                                                        <div class="pagecontent_info" id="DVFloor" runat="server">
                                                                            <div class="NoItemsFound" id="DVFloorNo" runat="server">
                                                                                <h2>
                                                                                    <asp:Literal ID="Literal8" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                                            </div>
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
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
        <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="pnl"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
        <asp:Panel ID="pnl" runat="server" style="display:none;">
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
                                <asp:HyperLink ID="CloseModelPopup" runat="server">
                                    <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                        ID="btnImage" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div style="float: left; width: 225px; margin-top: 40px; margin-left: 10px;">
                                <asp:Label ID="lblErrorMessage" runat="server" Text="Sure you want to delete?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <asp:Button ID="btnAddressSave" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnAddressSave_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnAddressCancel" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            OnClick="btnAddressCancel_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updFloor" ID="UpdateProgressFloor" runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
