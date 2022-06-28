<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRoles.ascx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.UserSetUp.CtrlRoles" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<link href="../../Style/tab_control.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function SetCheckbox(Op, iRow) {
        if (Op == "View") {
            var obj = 'ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkIsCreate_' + iRow;
            var obj1 = 'ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkIsUpdate_' + iRow;
            var obj2 = 'ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkIsDelete_' + iRow;
            if (document.getElementById('ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkIsView_' + iRow).checked == false) {
                document.getElementById(obj).checked = false;
                document.getElementById(obj1).checked = false;
                document.getElementById(obj2).checked = false;
            }
        }
        else if (Op == "Create") {
            var obj = 'ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkIsView_' + iRow;
            var obj1 = 'ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkIsUpdate_' + iRow;
            var obj2 = 'ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkIsDelete_' + iRow;
            if (document.getElementById('ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkIsCreate_' + iRow).checked) {
                document.getElementById(obj).checked = true;
            }
            else {
                document.getElementById(obj1).checked = false;
                document.getElementById(obj2).checked = false;
            }
        }
        else if (Op == "Update") {
            var obj = 'ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkIsView_' + iRow;
            var obj2 = 'ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkIsCreate_' + iRow;
            var obj3 = 'ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkIsDelete_' + iRow;
            if (document.getElementById('ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkIsUpdate_' + iRow).checked) {
                document.getElementById(obj).checked = true;
                document.getElementById(obj2).checked = true;
            }
            else {
                document.getElementById(obj3).checked = false;
            }
        }
        else if (Op == "Delete") {

            var obj = 'ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkIsView_' + iRow;
            var obj2 = 'ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkIsCreate_' + iRow;
            var obj3 = 'ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkIsUpdate_' + iRow;
            if (document.getElementById('ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkIsDelete_' + iRow).checked) {
                document.getElementById(obj).checked = true;
                document.getElementById(obj2).checked = true;
                document.getElementById(obj3).checked = true;
            }
        }
    }
    
</script>
<script type="text/javascript">
    function SelectAll(id, col) {
        //get reference of GridView control
        var grid = document.getElementById("<%= grdRightRoleAssignemnt.ClientID %>");
        //variable to contain the cell of the grid
        var cell;
        var objView = 'ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkViewSelectAll';
        var objCreate = 'ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkCreateSelectAll';
        var objUpdate = 'ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkUpdateSelectAll';
        var objDelete = 'ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkDeleteSelectAll';

        if (grid.rows.length > 0) {
            //loop starts from 1. rows[0] points to the header.
            for (i = 1; i < grid.rows.length; i++) {
                //get the reference of first column
                var cell1 = grid.rows[i].cells[1];
                var cell2 = grid.rows[i].cells[2];
                var cell3 = grid.rows[i].cells[3];
                var cell4 = grid.rows[i].cells[4];
                //loop according to the number of childNodes in the cell
                if (col == '1') {
                    if (document.getElementById('ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkViewSelectAll').checked) {
                        for (j = 0; j < cell1.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell1.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell1.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }
                    }
                    else {
                        document.getElementById(objCreate).checked = false;
                        document.getElementById(objUpdate).checked = false;
                        document.getElementById(objDelete).checked = false;
                        for (j = 0; j < cell1.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell1.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell1.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }
                        for (j = 0; j < cell2.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell2.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell2.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }
                        for (j = 0; j < cell3.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell3.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell3.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }

                        for (j = 0; j < cell4.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell4.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell4.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }
                    }
                }
                if (col == '2') {
                    if (document.getElementById('ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkCreateSelectAll').checked) {
                        document.getElementById(objView).checked = true;
                        for (j = 0; j < cell2.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell2.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell2.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }

                        for (j = 0; j < cell1.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell1.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell1.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }
                    }
                    else {
                        document.getElementById(objUpdate).checked = false;
                        document.getElementById(objDelete).checked = false;
                        for (j = 0; j < cell2.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell2.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell2.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }

                        for (j = 0; j < cell3.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell3.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell3.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }

                        for (j = 0; j < cell4.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell4.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell4.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }
                    }
                }

                if (col == '3') {
                    if (document.getElementById('ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkUpdateSelectAll').checked) {
                        document.getElementById(objCreate).checked = true;
                        document.getElementById(objView).checked = true;
                        for (j = 0; j < cell3.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell3.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell3.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }

                        for (j = 0; j < cell2.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell2.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell2.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }
                        for (j = 0; j < cell1.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell1.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell1.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }
                    }
                    else {
                        document.getElementById(objDelete).checked = false;
                        for (j = 0; j < cell3.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell3.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell3.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }
                        for (j = 0; j < cell4.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell4.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell4.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }
                    }

                }

                if (col == '4') {
                    if (document.getElementById('ContentPlaceHolder1_CtrlRolesSetUUP_grdRightRoleAssignemnt_chkDeleteSelectAll').checked) {
                        document.getElementById(objUpdate).checked = true;
                        document.getElementById(objCreate).checked = true;
                        document.getElementById(objView).checked = true;
                        for (j = 0; j < cell4.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell4.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell4.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }
                        for (j = 0; j < cell3.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell3.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell3.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }
                        for (j = 0; j < cell2.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell2.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell2.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }
                        for (j = 0; j < cell1.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell1.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell1.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }
                    }
                    else {
                        for (j = 0; j < cell4.childNodes.length; j++) {
                            //if childNode type is CheckBox                 
                            if (cell4.childNodes[j].type == "checkbox") {
                                //assign the status of the Select All checkbox to the cell checkbox within the grid
                                cell4.childNodes[j].checked = document.getElementById(id).checked;
                            }
                        }
                    }

                }

                //                cell = grid.rows[i].cells[col];
                //                for (j = 0; j < cell.childNodes.length; j++) 
                //                {
                //                    //if childNode type is CheckBox                 
                //                    if (cell.childNodes[j].type == "checkbox")
                //                     {
                //                        //assign the status of the Select All checkbox to the cell checkbox within the grid
                //                        cell.childNodes[j].checked = document.getElementById(id).checked;
                //                    }
                //                }
            }
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
</style>
<asp:UpdatePanel ID="updRoles" runat="server">
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
                                ROLE SETUP
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
                                        <td align="left" valign="top" style="width: 25%;">
                                            <asp:Label ID="Literal1" runat="server" Text="Role Type" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfRoleType" runat="server" ControlToValidate="ddlRoleType"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" InitialValue="00000000-0000-0000-0000-000000000000"
                                                    ErrorMessage="*" ValidationGroup="Rol"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td align="left" valign="top" style="width: 75%;">
                                            <asp:DropDownList ID="ddlRoleType" runat="server" Style="width: 202px;" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlRoleType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="litRoleName" runat="server" Text="Role Name" CssClass="RequireFile"></asp:Label>
                                            <span class="erroraleart">
                                                <asp:RequiredFieldValidator ID="rvfTermName" runat="server" ControlToValidate="txtRoleName"
                                                    SetFocusOnError="true" CssClass="rfv_ErrorStar" ErrorMessage="*" ValidationGroup="Rol"></asp:RequiredFieldValidator>
                                            </span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRoleName" runat="server" SkinID="CmpTextbox" MaxLength="27"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <asp:Literal ID="litThumb" runat="server" Text="Description"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRoleDescription" TextMode="MultiLine" runat="server" SkinID="Medium"
                                                Height="60px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="trRights" runat="server" visible="false">
                                        <td class="dTableBox" colspan="2">
                                            <div style="height: 200px; overflow: auto;">
                                                <asp:GridView ID="grdRightRoleAssignemnt" runat="server" AutoGenerateColumns="False"
                                                    SkinID="gvNoPaging" Width="100%" DataKeyNames="RightID" OnRowDataBound="grdRightRoleAssignemnt_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField DataField="MenuName" HeaderText="Form Name" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left" />
                                                        <asp:TemplateField HeaderText="View" ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lView" runat="server" Text="View"></asp:Label>
                                                                <asp:CheckBox ID="chkViewSelectAll" runat="server" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkIsView" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Create" ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblCreate" runat="server" Text="Create"></asp:Label>
                                                                <asp:CheckBox ID="chkCreateSelectAll" runat="server" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkIsCreate" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Update" ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblUpdate" runat="server" Text="Update"></asp:Label>
                                                                <asp:CheckBox ID="chkUpdateSelectAll" runat="server" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkIsUpdate" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblDelete" runat="server" Text="Delete"></asp:Label>
                                                                <asp:CheckBox ID="chkDeleteSelectAll" runat="server" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkIsDelete" runat="server" />
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
                                            <div style="float: right; width: auto; height:160px; display: inline-block;">
                                                <%--<asp:Button ID="btnCancel" Text="Cancel" Style="float: right; margin-left: 5px;"
                                                    runat="server" ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage()" />--%>
                                                <asp:Button ID="btnSave" Text="Save" Style="float: right; margin-left: 5px;" runat="server"
                                                    ImageUrl="~/images/save.png" ValidationGroup="Rol" CausesValidation="true" OnClick="btnSave_Click"
                                                    OnClientClick="fnDisplayCatchErrorMessage()" />
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
                                        <table id="tbl" cellpadding="2" cellspacing="0" width="100%" border="0" class="pageinfo">
                                            <tr>
                                                <td align="left" valign="middle" style="vertical-align: middle; margin-top: 7px;">
                                                    Role Name
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <asp:TextBox ID="txtSRoleName" runat="server" SkinID="Search"></asp:TextBox>
                                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                        Style="border: 0px; vertical-align: middle; margin-top: -4px; margin-left: 5px;"
                                                        OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="leftmarginbox_content">
                                        <div style="height: 350px; overflow: auto;">
                                            <asp:GridView ID="grdRoleList" runat="server" ShowHeader="false" ShowFooter="false"
                                                SkinID="gvNoPaging" AutoGenerateColumns="false" Width="100%" OnRowCommand="grdRoleList_RowCommand"
                                                OnRowDataBound="grdRoleList_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="rightmargin_grid">
                                                                <div class="leftmargin_contentarea">
                                                                    <strong>
                                                                        <%#DataBinder.Eval(Container.DataItem, "RoleName")%></strong><br />
                                                                </div>
                                                                <div class="leftmargin_icons">
                                                                    <asp:ImageButton ID="btnEdit" runat="server" ToolTip="Edit" ImageUrl="~/images/edit.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
                                                                        CommandName="EditData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RoleID")%>'
                                                                        OnClientClick="fnDisplayCatchErrorMessage()" />
                                                                    <asp:ImageButton ID="btnDelete" ToolTip="Delete" runat="server" ImageUrl="~/images/delete_icon.png"
                                                                        Style="border: 0px; vertical-align: middle; margin-top: 7px; margin-right: 7px;"
                                                                        CommandName="DeleteData" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RoleID")%>'
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
        <asp:Panel ID="Panel1" runat="server" style="display:none;">
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
                                        <asp:Button ID="btnRoleYes" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnRoleYes_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnRoleNo" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                            OnClick="btnRoleNo_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
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
<asp:UpdateProgress AssociatedUpdatePanelID="updRoles" ID="UpdateProgressRoles" runat="server">
    <ProgressTemplate>
        <div id="progressBackgroundFilter">
        </div>
        <div id="processMessage">
            <center>
                <img src="../../images/ajax-loader.gif" /></center>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
