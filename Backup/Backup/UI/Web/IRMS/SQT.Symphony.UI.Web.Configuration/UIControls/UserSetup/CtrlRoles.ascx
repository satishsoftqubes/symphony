<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlRoles.ascx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.UserSetup.CtrlRoles" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function SetCheckbox(Op, iRow) {
        if (Op == "View") {
            var obj = 'ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkIsCreate_' + iRow;
            var obj1 = 'ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkIsUpdate_' + iRow;
            var obj2 = 'ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkIsDelete_' + iRow;
            if (document.getElementById('ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkIsView_' + iRow).checked == false) {
                document.getElementById(obj).checked = false;
                document.getElementById(obj1).checked = false;
                document.getElementById(obj2).checked = false;
            }
        }
        else if (Op == "Create") {
            var obj = 'ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkIsView_' + iRow;
            var obj1 = 'ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkIsUpdate_' + iRow;
            var obj2 = 'ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkIsDelete_' + iRow;
            if (document.getElementById('ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkIsCreate_' + iRow).checked) {
                document.getElementById(obj).checked = true;
            }
            else {
                document.getElementById(obj1).checked = false;
                document.getElementById(obj2).checked = false;
            }
        }
        else if (Op == "Update") {
            var obj = 'ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkIsView_' + iRow;
            var obj2 = 'ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkIsCreate_' + iRow;
            var obj3 = 'ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkIsDelete_' + iRow;
            if (document.getElementById('ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkIsUpdate_' + iRow).checked) {
                document.getElementById(obj).checked = true;
                document.getElementById(obj2).checked = true;
            }
            else {
                document.getElementById(obj3).checked = false;
            }
        }
        else if (Op == "Delete") {

            var obj = 'ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkIsView_' + iRow;
            var obj2 = 'ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkIsCreate_' + iRow;
            var obj3 = 'ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkIsUpdate_' + iRow;
            if (document.getElementById('ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkIsDelete_' + iRow).checked) {
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
        var grid = document.getElementById("<%= gvRoleRightAssignemnt.ClientID %>");
        //variable to contain the cell of the grid
        var cell;
        var objView = 'ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkViewSelectAll';
        var objCreate = 'ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkCreateSelectAll';
        var objUpdate = 'ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkUpdateSelectAll';
        var objDelete = 'ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkDeleteSelectAll';

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
                    if (document.getElementById('ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkViewSelectAll').checked) {
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
                    if (document.getElementById('ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkCreateSelectAll').checked) {
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
                    if (document.getElementById('ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkUpdateSelectAll').checked) {
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
                    if (document.getElementById('ContentPlaceHolder1_ucRoleSetup_gvRoleRightAssignemnt_chkDeleteSelectAll').checked) {
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
            }
        }
    }
        

</script>
<script language="javascript" type="text/javascript">
    function fnConfirmDelete(id) {

        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnConfirmDelete.ClientID %>').value = id;
        $find('mpeConfirmDelete').show();
        return false;
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }       
</script>
<asp:UpdatePanel ID="updRoles" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="ltrMainHeader" runat="server"></asp:Literal>
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
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td>
                                                <%if (IsListMessage)
                                                  { %>
                                                <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Literal ID="ltrListMessage" runat="server"></asp:Literal></strong>
                                                    </p>
                                                </div>
                                                <%}%>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:MultiView ID="mvRoles" runat="server">
                                        <asp:View ID="vRolesList" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <th align="left">
                                                        <asp:Literal ID="litSearchRoleName" runat="server"></asp:Literal>
                                                    </th>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchRoleName" runat="server"></asp:TextBox>
                                                        <asp:ImageButton ID="btnSearchAmenities" CssClass="small_img" Style="border: 0px;
                                                            vertical-align: middle; margin: -4px 0 0 5px;" runat="server" ImageUrl="~/images/search-icon.png"
                                                            OnClick="btnSearchAmenities_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                        <asp:ImageButton ID="imgbtnClearSearch" CssClass="small_img" runat="server" ImageUrl="~/images/clearsearch.png"
                                                            Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClick="imgbtnClearSearch_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="right" valign="middle">
                                                        <asp:Button ID="btnAddTopRoles" runat="server" Style="float: right;" OnClick="btnAddTopRoles_Click"
                                                            OnClientClick="fnDisplayCatchErrorMessage();" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div class="box_head">
                                                            <span>
                                                                <asp:Literal ID="ltrRolesList" runat="server"></asp:Literal>
                                                            </span>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvRoles" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                ShowHeader="true" OnPageIndexChanging="gvRoles_PageIndexChanging" OnRowCommand="gvRoles_RowCommand"
                                                                OnRowDataBound="gvRoles_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHrdNo" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRoleName" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "RoleName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrRoleType" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "RoleType")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrAction" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RoleID")%>'
                                                                                CommandName="EDITDATA" OnClientClick="fnDisplayCatchErrorMessage();"><img src="../../images/file.png" /></asp:LinkButton>
                                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "RoleID")%>'
                                                                                CommandName="DELETEDATA"><img src="../../images/delete.png" /></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label></b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="right" valign="middle">
                                                        <asp:Button ID="btnAddBottomRoles" runat="server" OnClick="btnAddTopRoles_Click"
                                                            Style="float: right;" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vAddEditRoles" runat="server">
                                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="float: right; padding-bottom: 5px;">
                                                            <b>
                                                                <asp:Literal ID="litGeneralMandartoryFiledMessage" runat="server"></asp:Literal>
                                                            </b>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrRoleType" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlRoleType" runat="server" OnSelectedIndexChanged="ddlRoleType_SelectedIndexChanged"
                                                            AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rvfPropertyName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" InitialValue="00000000-0000-0000-0000-000000000000" ValidationGroup="IsRequire"
                                                                ControlToValidate="ddlRoleType"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Literal ID="ltrRoleName" runat="server"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRoleName" runat="server" MaxLength="27"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvAmanitiesName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtRoleName"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th valign="top" align="left">
                                                        <asp:Literal ID="ltrRoleDescription" runat="server"></asp:Literal>
                                                    </th>
                                                    <td style="padding-bottom: 15px;">
                                                        <asp:TextBox ID="txtRoleDescription" SkinID="BigInput" TextMode="MultiLine" Style="height: 85px;"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="trRights" runat="server" visible="false">
                                                    <td colspan="2" class="content_checkbox">
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <div style="height: 200px; overflow: auto;">
                                                                <asp:GridView ID="gvRoleRightAssignemnt" runat="server" AutoGenerateColumns="False"
                                                                    ShowHeader="true" SkinID="gvNoPaging" Width="100%" DataKeyNames="RightID" OnRowDataBound="gvRoleRightAssignemnt_RowDataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrMenuName" runat="server"></asp:Label>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGvMenuName" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrView" runat="server" Text="View" Style="vertical-align: middle;
                                                                                    padding: 0px; height: 12px; padding-bottom: 0px;"></asp:Label>
                                                                                <asp:CheckBox ID="chkViewSelectAll" runat="server" />
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkIsView" runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrCreate" runat="server" Text="Create" Style="vertical-align: middle;
                                                                                    padding: 0px; height: 12px; padding-bottom: 0px;"></asp:Label>
                                                                                <asp:CheckBox ID="chkCreateSelectAll" runat="server" />
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkIsCreate" runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrUpdate" runat="server" Text="Update" Style="vertical-align: middle;
                                                                                    padding: 0px; height: 12px; padding-bottom: 0px;"></asp:Label>
                                                                                <asp:CheckBox ID="chkUpdateSelectAll" runat="server" />
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkIsUpdate" runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                                                            <HeaderTemplate>
                                                                                <asp:Label ID="lblGvHdrDelete" runat="server" Text="Delete" Style="vertical-align: middle;
                                                                                    padding: 0px; height: 12px; padding-bottom: 0px;"></asp:Label>
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
                                                                                    <asp:Label ID="lblGvRoleRightNoRecordFound" runat="server"></asp:Label></h2>
                                                                            </div>
                                                                        </div>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="float: right; width: auto; display: inline-block;">
                                                            <asp:Button ID="btnCancel" Style="float: right; margin-left: 5px;" runat="server"
                                                                ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnCancel_Click"
                                                                OnClientClick="fnDisplayCatchErrorMessage();" />
                                                            <asp:Button ID="btnSave" Style="float: right; margin-left: 5px;" runat="server" ImageUrl="~/images/save.png"
                                                                ValidationGroup="IsRequire" CausesValidation="true" OnClick="btnSave_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                                            <asp:Button ID="btnBackToList" Style="float: right; margin-left: 5px;" runat="server"
                                                                ImageUrl="~/images/cancle.png" CausesValidation="false" OnClick="btnBackToList_Click"
                                                                OnClientClick="fnDisplayCatchErrorMessage();" />
                                                        </div>
                                                    </td>
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
                        <%--<uc1:MsgBox ID="MessageBox" runat="server" />--%>
                    </div>
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="mpeConfirmDelete" runat="server" TargetControlID="hdnConfirmDelete"
            PopupControlID="pnlDeleteData" BackgroundCssClass="mod_background" CancelControlID="btnNo"
            BehaviorID="mpeConfirmDelete">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
        <asp:Panel ID="pnlDeleteData" runat="server" Height="350px" Width="325px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="ltrHeaderConfirmDeletePopup" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="ltrConfirmDeleteMsg" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYes" runat="server" Style="display: inline; padding-right: 10px;"
                                    OnClientClick="fnDisplayCatchErrorMessage();" OnClick="btnYes_Click" />
                                <asp:Button ID="btnNo" runat="server" Style="display: inline;" />
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
