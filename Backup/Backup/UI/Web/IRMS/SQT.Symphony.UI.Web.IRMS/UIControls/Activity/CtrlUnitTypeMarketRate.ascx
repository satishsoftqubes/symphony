<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlUnitTypeMarketRate.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Activity.CtrlUnitTypeMarketRate" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function stopKey(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 8) && (node.type == "text")) { return false; }
        else if ((evt.keyCode == 9) && (node.type == "text")) { return true; }
        else if ((evt.keyCode == 46) && (node.type == "text")) { return false; }
        else { return false; }
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function SelectAll(id) {
        //get reference of GridView control
        var grid = document.getElementById("<%= gvUntiType.ClientID %>");
        //variable to contain the cell of the grid
        var cell;

        if (grid.rows.length > 0) {
            //loop starts from 1. rows[0] points to the header.
            for (i = 1; i < grid.rows.length; i++) {
                //get the reference of first column
                cell = grid.rows[i].cells[0];

                //loop according to the number of childNodes in the cell
                for (j = 0; j < cell.childNodes.length; j++) {
                    //if childNode type is CheckBox                 
                    if (cell.childNodes[j].type == "checkbox") {
                        //assign the status of the Select All checkbox to the cell checkbox within the grid
                        cell.childNodes[j].checked = document.getElementById(id).checked;
                    }
                }
            }
        }
    }

    function validateCheckBoxes() {
        if (Page_ClientValidate("IsRequire")) {
            document.getElementById('errormessage').style.display = "block";
            var isValid = false;
            var gridView = document.getElementById("<%= gvUntiType.ClientID %>");

            for (var i = 1; i < gridView.rows.length; i++) {
                var inputs = gridView.rows[i].getElementsByTagName('input');

                if (inputs != null) {

                    if (inputs[0].value == "") {
                        alert('Please Enter New Rate');
                        return false;
                    }
                }
            }
        }
        else {
            return false;
        }
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
    .newcalander
    {
    }
    
    .newcalander td
    {
        line-height:12px !important;
    }
</style>
<%--<asp:UpdatePanel ID="updMarketRate" runat="server">
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
                                MARKET VALUE OF UNIT
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
                                <table width="100%" cellpadding="3" cellspacing="3">
                                    <tr>
                                        <td colspan="2">
                                            <div style="height: 26px;">
                                                <%if (IsMessage)
                                                  { %>
                                                <div class="ResetSuccessfully">
                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                        <img src="../../images/success.png" /></div>
                                                    <div>
                                                        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <%}%>
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
                                        <td style="width: 125px;" valign="top">
                                            <asp:Label ID="litPropertyName" runat="server" Text="Property Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvPropertyName" SetFocusOnError="True" ControlToValidate="ddlPropertyName"
                                                    ValidationGroup="IsRequire" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPropertyName" runat="server" AutoPostBack="true" Style="width: 202px;"
                                                OnSelectedIndexChanged="ddlPropertyName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:Label ID="litDate" runat="server" Text="Date" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfDateOfRate" runat="server" ControlToValidate="txtDateOfRate"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:TextBox ID="txtDateOfRate" runat="server" SkinID="CmpTextbox" onkeydown="return stopKey(event);"></asp:TextBox>
                                            <asp:Image ID="imgCalendarDateOfRate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                Height="20px" Width="20px" />
                                            <ajx:CalendarExtender ID="ajxCalendarDateOfRate" PopupButtonID="imgCalendarDateOfRate" CssClass="MyCalendar"
                                                TargetControlID="txtDateOfRate" runat="server">
                                            </ajx:CalendarExtender>                                           
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox" colspan="2">
                                            <div style="height: 200px; overflow: auto;">
                                                <asp:GridView ID="gvUntiType" runat="server" AutoGenerateColumns="False" SkinID="gvNoPaging"
                                                    Width="100%" DataKeyNames="RoomTypeID" OnRowDataBound="gvUntiType_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-Width="15px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkSelectAll" runat="server" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                                                <asp:HiddenField ID="hdnMarketRateID" runat="server"/>                                                                
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="RoomTypeName" HeaderText="Unit Type" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="120px" />
                                                        <asp:TemplateField HeaderText="Previous price" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOldRate" Width="78px" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOldRateDate" Width="78px" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="New Rate" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtNewRate" Style="width: 70px; text-align:right;" runat="server" MaxLength="24"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="revNewRate" SetFocusOnError="True" runat="server"
                                                                    ValidationGroup="IsRequire" ControlToValidate="txtNewRate" ValidationExpression="^\d{0,24}(\.\d{0,2})?$"
                                                                    Display="Dynamic" ForeColor="Red" ErrorMessage="*"></asp:RegularExpressionValidator>
                                                                <ajx:FilteredTextBoxExtender ID="ftNewRate" runat="server" TargetControlID="txtNewRate"
                                                                    FilterType="Custom, Numbers" ValidChars="." />
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
                                        <td align="left" valign="top" colspan="2">
                                            <div style="float: right; width: auto; height: 160px; display: inline-block;">
                                                <asp:Button ID="btnCancel" Text="Cancel" Style="float: right; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:Button ID="btnSave" Text="Save" Style="float: right; margin-left: 5px;" runat="server"
                                                    ImageUrl="~/images/save.png" ValidationGroup="IsRequire" CausesValidation="true"
                                                    OnClick="btnSave_Click" OnClientClick="return validateCheckBoxes()" />
                                                <asp:Button ID="btnNew" runat="server" Style="float: right; margin-left: 5px; display: inline;"
                                                    Text="New" OnClick="btnNew_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
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
                                        <table cellpadding="2" cellspacing="0" width="100%" border="0" class="pageinfo">
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Property
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:DropDownList ID="ddlSearchProperty" runat="server" style="width:140px;">
                                                    </asp:DropDownList>
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; vertical-align: middle; margin-top: -4px; margin-left: 5px;"
                                                        OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Date
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:TextBox ID="txtSearchDate" runat="server" style="width:121px !important;" onkeydown="return stopKey(event);"></asp:TextBox>
                                                    <asp:Image ID="imgSearchDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                        Height="20px" Width="20px" />
                                                    <ajx:CalendarExtender ID="calSearchDate" PopupButtonID="imgSearchDate" TargetControlID="txtSearchDate" CssClass="MyCalendar"
                                                        runat="server">
                                                    </ajx:CalendarExtender>
                                                    <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" onclick="fnClearDate('<%= txtSearchDate.ClientID %>');" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="leftmarginbox_content">
                                        <div style="height: 350px; overflow: auto;">
                                            <asp:GridView ID="gvUnitTypeMarketRateList" runat="server" ShowHeader="false" AutoGenerateColumns="false"
                                                Width="100%" OnRowCommand="gvUnitTypeMarketRateList_RowCommand" OnRowDataBound="gvUnitTypeMarketRateList_RowDataBound">                                                
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea">
                                                                    <strong>
                                                                    <%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DateOfRate")).ToString(this.DateFormat)%>
                                                                        </strong><br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "PropertyName")%>
                                                                </div>
                                                                <div class="leftmargin_icons">
                                                                    <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
                                                                        CommandName="EditData" CommandArgument='<%#Eval("PropertyID") + "|" +Eval("DateOfRate")%>'
                                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                    <asp:ImageButton ID="btnDelete" ToolTip="Delete" runat="server" ImageUrl="~/images/delete_icon.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
                                                                        CommandName="DeleteData" CommandArgument='<%#Eval("PropertyID") + "|" +Eval("DateOfRate")%>'
                                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
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
        <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="Panel1"
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
                                        <asp:Button ID="btnUnitTypeMarketRateYes" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnUnitTypeMarketRateYes_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnUnitTypeMarketRateNo" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            Style="display: inline-block;" OnClick="btnUnitTypeMarketRateNo_Click" OnClientClick="fnDisplayCatchErrorMessage()"/>
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
</asp:UpdatePanel>--%>

<asp:UpdatePanel ID="updMarketRate" runat="server">
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
                                MARKET VALUE OF UNIT
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
                                <table width="100%" cellpadding="3" cellspacing="3">
                                    <tr>
                                        <td colspan="2">
                                            <div style="height: 26px;">
                                                <%if (IsMessage)
                                                  { %>
                                                <div class="ResetSuccessfully">
                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                        <img src="../../images/success.png" /></div>
                                                    <div>
                                                        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                <%}%>
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
                                        <td style="width: 125px;" valign="top">
                                            <asp:Label ID="litPropertyName" runat="server" Text="Property Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rfvPropertyName" SetFocusOnError="True" ControlToValidate="ddlPropertyName"
                                                    ValidationGroup="IsRequire" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    runat="server" ErrorMessage="*" CssClass="rfv_ErrorStar"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPropertyName" runat="server" AutoPostBack="true" Style="width: 202px;"
                                                OnSelectedIndexChanged="ddlPropertyName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:Label ID="litDate" runat="server" Text="Date" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfDateOfRate" runat="server" ControlToValidate="txtDateOfRate"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="IsRequire"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td align="left" valign="top">
                                            <asp:TextBox ID="txtDateOfRate" runat="server" SkinID="CmpTextbox" onkeydown="return stopKey(event);"></asp:TextBox>
                                            <asp:Image ID="imgCalendarDateOfRate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                Height="20px" Width="20px" />
                                            <ajx:CalendarExtender ID="ajxCalendarDateOfRate" PopupButtonID="imgCalendarDateOfRate" CssClass="MyCalendar"
                                                TargetControlID="txtDateOfRate" runat="server">
                                            </ajx:CalendarExtender>
                                            <%-- <img src="../../images/clear.png" id="imgClearDate" style="vertical-align: middle;"
                                                onclick="fnClearDate('<%= txtDateOfRate.ClientID %>');" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dTableBox" colspan="2">
                                            <div style="height: 200px; overflow: auto;">
                                                <asp:GridView ID="gvUntiType" runat="server" AutoGenerateColumns="False" SkinID="gvNoPaging"
                                                    Width="100%" DataKeyNames="RoomTypeID" OnRowDataBound="gvUntiType_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField DataField="RoomTypeName" HeaderText="Unit Type" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="120px" />
                                                        <%--<asp:TemplateField HeaderText="Previous price" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOldRate" Width="78px" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Date" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOldRateDate" Width="78px" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="New Rate" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtNewRate" Style="width: 100px; text-align: right;" runat="server"
                                                                    MaxLength="24"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="revNewRate" SetFocusOnError="True" runat="server"
                                                                    ValidationGroup="IsRequire" ControlToValidate="txtNewRate" ValidationExpression="^\d{0,24}(\.\d{0,2})?$"
                                                                    Display="Dynamic" ForeColor="Red" ErrorMessage="*"></asp:RegularExpressionValidator>
                                                                <ajx:FilteredTextBoxExtender ID="ftNewRate" runat="server" TargetControlID="txtNewRate"
                                                                    FilterType="Custom, Numbers" ValidChars="." />
                                                                    <asp:HiddenField ID="hdnMarketRateID" runat="server"/>
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
                                        <td align="left" valign="top" colspan="2">
                                            <div style="float: right; width: auto; height: 160px; display: inline-block;">
                                                <asp:Button ID="btnCancel" Text="Cancel" Style="float: right; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:Button ID="btnSave" Text="Save" Style="float: right; margin-left: 5px;" runat="server"
                                                    ImageUrl="~/images/save.png" ValidationGroup="IsRequire" CausesValidation="true"
                                                    OnClick="btnSave_Click" OnClientClick="return validateCheckBoxes()" />
                                                <asp:Button ID="btnNew" runat="server" Style="float: right; margin-left: 5px; display: inline;"
                                                    Text="New" OnClick="btnNew_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
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
                                        <table cellpadding="2" cellspacing="0" width="100%" border="0" class="pageinfo">
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Property
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:DropDownList ID="ddlSearchProperty" runat="server" Style="width: 140px;">
                                                    </asp:DropDownList>
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; vertical-align: middle; margin-top: -4px; margin-left: 5px;"
                                                        OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Date
                                                </td>
                                                <td style="vertical-align: middle;" class="newcalander">
                                                    <asp:TextBox ID="txtSearchDate" runat="server" Style="width: 121px !important;" onkeydown="return stopKey(event);"></asp:TextBox>
                                                    <asp:Image ID="imgSearchDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                        Height="20px" Width="20px" />
                                                    <ajx:CalendarExtender ID="calSearchDate" PopupButtonID="imgSearchDate" TargetControlID="txtSearchDate"
                                                        runat="server" CssClass="MyCalendar">
                                                    </ajx:CalendarExtender>
                                                    <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" onclick="fnClearDate('<%= txtSearchDate.ClientID %>');" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="leftmarginbox_content">
                                        <div style="height: 442px; overflow: auto;">
                                            <asp:GridView ID="gvUnitTypeMarketRateList" runat="server" ShowHeader="false" AutoGenerateColumns="false"
                                                Width="100%" OnRowCommand="gvUnitTypeMarketRateList_RowCommand" OnRowDataBound="gvUnitTypeMarketRateList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea">
                                                                    <strong>
                                                                        <%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DateOfRate")).ToString(this.DateFormat)%>
                                                                    </strong>
                                                                    <br />
                                                                    <%#DataBinder.Eval(Container.DataItem, "PropertyName")%>
                                                                </div>
                                                                <div class="leftmargin_icons">
                                                                    <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit.png" Style="border: 0px;
                                                                        vertical-align: middle; margin-top: 7px; margin-right: 7px;" CommandName="EditData"
                                                                        CommandArgument='<%#Eval("PropertyID") + "|" +Eval("DateOfRate")%>' OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                    <asp:ImageButton ID="btnDelete" ToolTip="Delete" runat="server" ImageUrl="~/images/delete_icon.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
                                                                        CommandName="DeleteData" CommandArgument='<%#Eval("PropertyID") + "|" +Eval("DateOfRate")%>'
                                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
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
        <ajx:ModalPopupExtender ID="msgbx" runat="server" TargetControlID="hfMessage" PopupControlID="Panel1"
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
                                        <asp:Button ID="btnUnitTypeMarketRateYes" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnUnitTypeMarketRateYes_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnUnitTypeMarketRateNo" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            Style="display: inline-block;" OnClick="btnUnitTypeMarketRateNo_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updMarketRate" ID="UpdateProgressMarketRate"
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
