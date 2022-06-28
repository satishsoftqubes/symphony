<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlBanquetManagement.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Banquet.ctrlBanquetManagement" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonGuestHistory.ascx" TagName="GuestHistory"
    TagPrefix="ucCtrlGuestHistory" %>
<%@ Register Src="~/UIControls/Banquet/CtrlControlNotes.ascx" TagName="ControlNotes"
    TagPrefix="ucCtrlControlNotes" %>
<script type="text/javascript">
    function pageLoad(sender, args) {
        $('#<%=txtTime.ClientID %>').timepicker({ ampm: false });
        $(document).ready(function () {

            $("#tabs").tabs();


            $('#tabs').tabs({
                select: function (event, ui) {
                    window.location.hash = ui.tab.hash;
                }
            });
        });

    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updBanquetMgmt" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server" Text="Banquet Management"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td align="left">
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" width="100%">
                                        <tr>
                                            <td colspan="3">
                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                    <tr>
                                                        <td align="left" style="padding-top: 10px; background-color: #fff !important;">
                                                            <div class="demo">
                                                                <div id="tabs">
                                                                    <ul>
                                                                        <li><a href="#tabs-1">
                                                                            <asp:Literal ID="littabPlanner" runat="server" Text="Planner"></asp:Literal></a></li>
                                                                        <li><a href="#tabs-2">
                                                                            <asp:Literal ID="littabProposal" runat="server" Text="Proposal"></asp:Literal></a></li>
                                                                        <li><a href="#tabs-3">
                                                                            <asp:Literal ID="littabContacts" runat="server" Text="Contacts"></asp:Literal></a></li>
                                                                    </ul>
                                                                    <div id="tabs-1">
                                                                        <asp:MultiView ID="mvPlanner" runat="server">
                                                                            <asp:View runat="server" ID="vPlanner">
                                                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                                                    <tr>
                                                                                        <td colspan="2" width="100%">
                                                                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                                                                <tr>
                                                                                                    <td width="100px">
                                                                                                        <asp:Literal ID="litPlannerSearchReservationNo" runat="server" Text="Booking #"></asp:Literal>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtPlannerSearchReservationNo" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td width="100px">
                                                                                                        <asp:Literal ID="litPlannerSearchBanquet" runat="server" Text="Banquet"></asp:Literal>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlPlannerSearchBanquet" runat="server">
                                                                                                            <asp:ListItem Selected="True" Text="-Select-" Value="-Select-"></asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Literal ID="litPlannerSearchArrivalDate" runat="server" Text="Check In"></asp:Literal>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtPlannerSearchArrivalDate" runat="server"></asp:TextBox>
                                                                                                        <asp:Image ID="imgPlannerSearchArrivalDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                                                            Height="20px" Width="20px" />
                                                                                                        <ajx:CalendarExtender ID="calPlannerSearchArrivalDate" PopupButtonID="imgPlannerSearchArrivalDate"
                                                                                                            TargetControlID="txtPlannerSearchArrivalDate" runat="server" Format="dd/MMM/yyyy">
                                                                                                        </ajx:CalendarExtender>
                                                                                                        <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" title="Clear Date"
                                                                                                            onclick="fnClearDate('<%= txtPlannerSearchArrivalDate.ClientID %>');" />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:Literal ID="litPlannerSearchDepatureDate" runat="server" Text="Check Out"></asp:Literal>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtPlannerSearchDepatureDate" runat="server"></asp:TextBox>
                                                                                                        <asp:Image ID="imgPlannerSearchDepatureDate" CssClass="small_img" runat="server"
                                                                                                            ImageUrl="~/images/CalanderIcon.png" Height="20px" Width="20px" />
                                                                                                        <ajx:CalendarExtender ID="calPlannerSearchDepatureDate" PopupButtonID="imgPlannerSearchDepatureDate"
                                                                                                            TargetControlID="txtPlannerSearchDepatureDate" runat="server" Format="dd/MMM/yyyy">
                                                                                                        </ajx:CalendarExtender>
                                                                                                        <img src="../../images/clear.png" id="img2" style="vertical-align: middle;" title="Clear Date"
                                                                                                            onclick="fnClearDate('<%= txtPlannerSearchDepatureDate.ClientID %>');" />
                                                                                                        <asp:ImageButton ID="imgbtnPlannerSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                                                                            Style="border: 0px; margin: -4px 0 0 15px; vertical-align: middle;" ToolTip="Search" />
                                                                                                        <asp:ImageButton ID="imgbtnPlannerClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                                                                            Style="border: 0px; vertical-align: middle; margin: -4px 0 0 10px;" ToolTip="Clear Search" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="4">
                                                                                                        <hr />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td rowspan="2" style="vertical-align: top; border-right: 1px solid  #ccccce; height: 400px;"
                                                                                            width="67%">
                                                                                            <div class="box_head">
                                                                                                <span>
                                                                                                    <asp:Literal ID="litHdrPlannerList" runat="server" Text="Planner List"></asp:Literal>
                                                                                                </span>
                                                                                            </div>
                                                                                            <div class="clear">
                                                                                            </div>
                                                                                            <div class="box_content">
                                                                                                <asp:GridView ID="gvPlannerList" OnRowCommand="gvPlannerList_OnRowCommand" runat="server"
                                                                                                    AutoGenerateColumns="false" ShowHeader="true" Width="100%">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrPlannerListSrNo" runat="server" Text="No."></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%# Container.DataItemIndex + 1 %>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrPlannerListReservationNo" runat="server" Text="Booking #"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrPlannerListStatus" runat="server" Text="Status"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "Status")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="65px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrAdultAndChild" runat="server" Text="Adult/Child"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "AdultChild")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrBanquet" runat="server" Text="Banquet"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "Banquet")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrArrange" runat="server" Text="Arrange"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "Arrange")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="85px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrPlannerListStartDate" runat="server" Text="Start Date"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "StartDate")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="85px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrPlannerListEndDate" runat="server" Text="End Date"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "EndDate")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrEvent" runat="server" Text="Event"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "Event")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblActions" runat="server" Text="Action"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblPopUp" runat="server" Text="Action"></asp:Label>
                                                                                                                <ajx:HoverMenuExtender ID="HoverMenuExtender2" runat="server" TargetControlID="lblPopUp"
                                                                                                                    PopupControlID="Panel2" PopupPosition="Left">
                                                                                                                </ajx:HoverMenuExtender>
                                                                                                                <asp:Panel ID="Panel2" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                                                                    <div class="actionsbuttons_hovermenu">
                                                                                                                        <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                                                                            <tr>
                                                                                                                                <td class="actionsbuttons_hover_lettmenu">
                                                                                                                                </td>
                                                                                                                                <td class="actionsbuttons_hover_centermenu">
                                                                                                                                    <ul>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton Style="background: none !important; border: none;" ID="lnkPlannerListEdit"
                                                                                                                                                runat="server" ToolTip="Edit" CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton Style="background: none !important; border: none;" ID="lnkToDoTask"
                                                                                                                                                runat="server" ToolTip="To Do Task" CommandName="TODOTASK"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkControlNotes" runat="server" Style="background: none !important;
                                                                                                                                                border: none;" ToolTip="Control Notes" CommandName="CONTROLNOTES"><img src="../../images/file.png" /></asp:LinkButton>
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
                                                                                                                <asp:Label ID="lblPlannerListNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                                                            </b>
                                                                                                        </div>
                                                                                                    </EmptyDataTemplate>
                                                                                                </asp:GridView>
                                                                                            </div>
                                                                                        </td>
                                                                                        <td style="height: 200px; overflow: auto; vertical-align: top;" width="35%">
                                                                                            <div class="box_head">
                                                                                                <span>
                                                                                                    <asp:Literal ID="litHdrToDoTaskList" runat="server" Text="ToDo Task List"></asp:Literal>
                                                                                                </span>
                                                                                            </div>
                                                                                            <div class="clear">
                                                                                            </div>
                                                                                            <div class="box_content">
                                                                                                <asp:GridView ID="gvToDoTaskList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                                    Width="100%">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrToDoTaskListSrNo" runat="server" Text="No."></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%# Container.DataItemIndex + 1 %>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrToDoTaskListReservationNo" runat="server" Text="Booling #"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrToDoTask" runat="server" Text="ToDo Task"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "ToDoTask")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrToDoTaskListStatus" runat="server" Text="Status"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "Status")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <EmptyDataTemplate>
                                                                                                        <div style="padding: 10px;">
                                                                                                            <b>
                                                                                                                <asp:Label ID="lblToDoTaskListNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                                                            </b>
                                                                                                        </div>
                                                                                                    </EmptyDataTemplate>
                                                                                                </asp:GridView>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="vertical-align: top; height: 200px; overflow: auto;">
                                                                                            <div class="box_head">
                                                                                                <span>
                                                                                                    <asp:Literal ID="litHdrNotes" runat="server" Text="Notes"></asp:Literal>
                                                                                                </span>
                                                                                            </div>
                                                                                            <div class="clear">
                                                                                            </div>
                                                                                            <div class="box_content">
                                                                                                <asp:GridView ID="gvNotesList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                                    Width="100%">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrNotesListSrNo" runat="server" Text="No."></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%# Container.DataItemIndex + 1 %>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrNotesListReservationNo" runat="server" Text="Booking #"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrNotesListNotes" runat="server" Text="Notes"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "Notes")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrNotesListStatus" runat="server" Text="Status"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "Status")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <EmptyDataTemplate>
                                                                                                        <div style="padding: 10px;">
                                                                                                            <b>
                                                                                                                <asp:Label ID="lblNotesListNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                                                                            </b>
                                                                                                        </div>
                                                                                                    </EmptyDataTemplate>
                                                                                                </asp:GridView>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:View>
                                                                            <asp:View runat="server" ID="vToDoTask">
                                                                                <div class="box_col1">
                                                                                    <div class="box_head">
                                                                                        <span>
                                                                                            <asp:Literal ID="litTODoTask" runat="server" Text="To Do Task"></asp:Literal></span></div>
                                                                                    <div class="clear">
                                                                                    </div>
                                                                                    <div class="box_form">
                                                                                        <%--<ucCtrlToDoStask:ToDoStask ID="ToDoStask1" runat="server" OnbtnToDoStaskCallParent_Click="btnToDoStaskCallParent_Click"  />--%>
                                                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                                                            <tr>
                                                                                                <td style="width: 70px;" class="isrequire">
                                                                                                    <asp:Literal ID="litTime" runat="server" Text="Time"></asp:Literal>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtTime" runat="server" Style="width: 50px !important;" onkeypress="return false;"
                                                                                                        MaxLength="5"></asp:TextBox><span>
                                                                                                            <asp:RequiredFieldValidator ID="rfvTime" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                                                runat="server" ValidationGroup="IsRequireTODoTask" ControlToValidate="txtTime"
                                                                                                                Display="Dynamic">
                                                                                                            </asp:RequiredFieldValidator></span>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="isrequire">
                                                                                                    <asp:Literal ID="litTask" runat="server" Text="Task"></asp:Literal>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtTask" runat="server"></asp:TextBox><span>
                                                                                                        <asp:RequiredFieldValidator ID="rfvTask" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                                            runat="server" ValidationGroup="IsRequireTODoTask" ControlToValidate="txtTask"
                                                                                                            Display="Dynamic">
                                                                                                        </asp:RequiredFieldValidator></span>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" style="padding-top: 8px;" align="right">
                                                                                                    <asp:Button ID="btnSave" runat="server" Style="display: inline; padding-right: 10px;"
                                                                                                        ValidationGroup="IsRequireTODoTask" Text="Save" />
                                                                                                    <asp:Button ID="btnCancel" runat="server" Style="display: inline;" Text="Cancel"
                                                                                                        OnClick="btnCancel_Click" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                    <div class="clear">
                                                                                    </div>
                                                                                </div>
                                                                            </asp:View>
                                                                            <asp:View runat="server" ID="vControlNotes">
                                                                                <div class="box_col1">
                                                                                    <div class="box_head">
                                                                                        <span>
                                                                                            <asp:Literal ID="litControlNotes" runat="server" Text="Control Notes"></asp:Literal></span></div>
                                                                                    <div class="clear">
                                                                                    </div>
                                                                                    <div class="box_form">
                                                                                        <ucCtrlControlNotes:ControlNotes ID="ControlNotes1" runat="server" OnbtnControlNotesCallParent_Click="btnControlNotesCallParent_Click" />
                                                                                    </div>
                                                                                    <div class="clear">
                                                                                    </div>
                                                                                </div>
                                                                            </asp:View>
                                                                        </asp:MultiView>
                                                                    </div>
                                                                    <div id="tabs-2">
                                                                        <table cellpadding="2" cellspacing="2" width="100%">
                                                                            <tr>
                                                                                <td width="100px">
                                                                                    <asp:Literal ID="litProposalSearchReservationNo" runat="server" Text="Booking #"></asp:Literal>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtProposalSearchReservationNo" runat="server"></asp:TextBox>
                                                                                </td>
                                                                                <td width="100px">
                                                                                    <asp:Literal ID="litProposalSearchBanquet" runat="server" Text="Banquet"></asp:Literal>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlProposalSearchBanquet" runat="server">
                                                                                        <asp:ListItem Selected="True" Text="-Select-" Value="-Select-"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Literal ID="litProposalSearchArrivalDate" runat="server" Text="Check In"></asp:Literal>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtProposalSearchArrivalDate" runat="server"></asp:TextBox>
                                                                                    <asp:Image ID="imgProposalSearchArrivalDate" CssClass="small_img" runat="server"
                                                                                        ImageUrl="~/images/CalanderIcon.png" Height="20px" Width="20px" />
                                                                                    <ajx:CalendarExtender ID="calProposalSearchArrivalDate" PopupButtonID="imgProposalSearchArrivalDate"
                                                                                        TargetControlID="txtProposalSearchArrivalDate" runat="server" Format="dd/MMM/yyyy">
                                                                                    </ajx:CalendarExtender>
                                                                                    <img src="../../images/clear.png" id="img3" style="vertical-align: middle;" title="Clear Date"
                                                                                        onclick="fnClearDate('<%= txtProposalSearchArrivalDate.ClientID %>');" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Literal ID="litProposalSearchDepatureDate" runat="server" Text="Check Out"></asp:Literal>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtProposalSearchDepatureDate" runat="server"></asp:TextBox>
                                                                                    <asp:Image ID="imgProposalSearchDepatureDate" CssClass="small_img" runat="server"
                                                                                        ImageUrl="~/images/CalanderIcon.png" Height="20px" Width="20px" />
                                                                                    <ajx:CalendarExtender ID="calProposalSearchDepatureDate" PopupButtonID="imgProposalSearchDepatureDate"
                                                                                        TargetControlID="txtProposalSearchDepatureDate" runat="server" Format="dd/MMM/yyyy">
                                                                                    </ajx:CalendarExtender>
                                                                                    <img src="../../images/clear.png" id="img4" style="vertical-align: middle;" title="Clear Date"
                                                                                        onclick="fnClearDate('<%= txtProposalSearchDepatureDate.ClientID %>');" />
                                                                                    <asp:ImageButton ID="imgbtnProposalSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                                                        Style="border: 0px; margin: -4px 0 0 15px; vertical-align: middle;" ToolTip="Search" />
                                                                                    <asp:ImageButton ID="imgbtnProposalClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                                                        Style="border: 0px; vertical-align: middle; margin: -4px 0 0 10px;" ToolTip="Clear Search" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4">
                                                                                    <hr />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4" align="right">
                                                                                    <asp:Button ID="btnTopAddProposal" runat="server" Text="Add" OnClick="btnTopAddProposal_Click" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4">
                                                                                    <div class="box_head">
                                                                                        <span>
                                                                                            <asp:Literal ID="litHdrProposalList" runat="server" Text="Proposal List"></asp:Literal>
                                                                                        </span>
                                                                                    </div>
                                                                                    <div class="clear">
                                                                                    </div>
                                                                                    <div class="box_content">
                                                                                        <asp:GridView ID="gvProposalList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                            Width="100%">
                                                                                            <Columns>
                                                                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrProposalListSrNo" runat="server" Text="No."></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <%# Container.DataItemIndex + 1 %>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrProposalListReservationNo" runat="server" Text="Booking #"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrProposalListStatus" runat="server" Text="Status"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "Status")%>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrProposalListAdultAndChild" runat="server" Text="Adult/Child"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "AdultChild")%>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrProposalListBanquet" runat="server" Text="Banquet"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "Banquet")%>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrProposalListArrange" runat="server" Text="Arrange"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "Arrange")%>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField ItemStyle-Width="85px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrProposalListStartDate" runat="server" Text="Start Date"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "StartDate")%>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField ItemStyle-Width="85px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrProposalListEndDate" runat="server" Text="End Date"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "EndDate")%>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblGvHdrProposalListEvent" runat="server" Text="Event"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "Event")%>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:Label ID="lblProposalListActions" runat="server" Text="Action"></asp:Label>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblProposalListPopUp" runat="server" Text="Action"></asp:Label>
                                                                                                        <ajx:HoverMenuExtender ID="hmelblProposal" runat="server" TargetControlID="lblProposalListPopUp"
                                                                                                            PopupControlID="pnlProposalList" PopupPosition="Left">
                                                                                                        </ajx:HoverMenuExtender>
                                                                                                        <asp:Panel ID="pnlProposalList" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                                                            <div class="actionsbuttons_hovermenu">
                                                                                                                <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                                                                    <tr>
                                                                                                                        <td class="actionsbuttons_hover_lettmenu">
                                                                                                                        </td>
                                                                                                                        <td class="actionsbuttons_hover_centermenu">
                                                                                                                            <ul>
                                                                                                                                <li>
                                                                                                                                    <asp:LinkButton Style="background: none !important; border: none;" ID="lnkProposalListEdit"
                                                                                                                                        runat="server" ToolTip="Edit" CommandName="EDITDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                </li>
                                                                                                                                <li>
                                                                                                                                    <asp:LinkButton Style="background: none !important; border: none;" ID="lnkProposalListDelete"
                                                                                                                                        runat="server" ToolTip="Delete" CommandName="DELETEDATA"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                </li>
                                                                                                                                <li>
                                                                                                                                    <asp:LinkButton ID="lnkProposalListCancel" runat="server" Style="background: none !important;
                                                                                                                                        border: none;" ToolTip="Cancel" CommandName="CANCEL"><img src="../../images/file.png" /></asp:LinkButton>
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
                                                                                                        <asp:Label ID="lblNoRecordFoundForProposalList" runat="server" Text="No Record Found."></asp:Label>
                                                                                                    </b>
                                                                                                </div>
                                                                                            </EmptyDataTemplate>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4" align="right">
                                                                                    <asp:Button ID="btnBottomAddProposal" runat="server" Text="Add" OnClick="btnTopAddProposal_Click" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div id="tabs-3">
                                                                        <asp:MultiView ID="mvContact" runat="server">
                                                                            <asp:View ID="vContactList" runat="server">
                                                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                                                    <tr>
                                                                                        <td width="80px">
                                                                                            <asp:Literal ID="litSearchLastName" runat="server" Text="Last Name"></asp:Literal>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtSearchLastName" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                        <td width="80px">
                                                                                            <asp:Literal ID="litSearchFirstName" runat="server" Text="First Name"></asp:Literal>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtSearchFirstName" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Literal ID="litSearchIDDetails" runat="server" Text="ID Details"></asp:Literal>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtSearchIDDetails" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Literal ID="litSearchDate" runat="server" Text="Date"></asp:Literal>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtSearchDate" runat="server"></asp:TextBox>
                                                                                            <asp:Image ID="imgSearchDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                                                Height="20px" Width="20px" />
                                                                                            <ajx:CalendarExtender ID="calDate" PopupButtonID="imgSearchDate" TargetControlID="txtSearchDate"
                                                                                                runat="server" Format="dd/MMM/yyyy">
                                                                                            </ajx:CalendarExtender>
                                                                                            <img src="../../images/clear.png" id="imgClearDate" style="vertical-align: middle;"
                                                                                                title="Clear Date" onclick="fnClearDate('<%= txtSearchDate.ClientID %>');" />
                                                                                            <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                                                                Style="border: 0px; margin: -4px 0 0 15px; vertical-align: middle;" ToolTip="Search" />
                                                                                            <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                                                                Style="border: 0px; vertical-align: middle; margin: -4px 0 0 10px;" ToolTip="Clear Search" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="4">
                                                                                            <hr />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="4">
                                                                                            <div class="box_head">
                                                                                                <span>
                                                                                                    <asp:Literal ID="litHdrContactsList" runat="server" Text="Contacts List"></asp:Literal>
                                                                                                </span>
                                                                                            </div>
                                                                                            <div class="clear">
                                                                                            </div>
                                                                                            <div class="box_content">
                                                                                                <asp:GridView ID="gvContactsList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                                    Width="100%" OnRowCommand="gvContactsList_RowCommand">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrRestaurantnSrNo" runat="server" Text="No."></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%# Container.DataItemIndex + 1 %>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Guest Name"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "GuestName")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrCountry" runat="server" Text="Country"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "Country")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrState" runat="server" Text="State"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "State")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrCity" runat="server" Text="City"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "City")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrIDDetails" runat="server" Text="ID Details"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "IDDetails")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrEmail" runat="server" Text="Email"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <%#DataBinder.Eval(Container.DataItem, "Email")%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:Label ID="lblGvHdrContactAction" runat="server" Text="Action"></asp:Label>
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblContactPopUp" runat="server" Text="Action"></asp:Label>
                                                                                                                <ajx:HoverMenuExtender ID="hmeContact" runat="server" TargetControlID="lblContactPopUp"
                                                                                                                    PopupControlID="panContact" PopupPosition="Left">
                                                                                                                </ajx:HoverMenuExtender>
                                                                                                                <asp:Panel ID="panContact" runat="server" Style="visibility: hidden; opacity: 100%">
                                                                                                                    <div class="actionsbuttons_hovermenu">
                                                                                                                        <table border="0" cellpadding="0" cellspacing="0" class="actionsbuttons_hover_lettmenu_table">
                                                                                                                            <tr>
                                                                                                                                <td class="actionsbuttons_hover_lettmenu">
                                                                                                                                </td>
                                                                                                                                <td class="actionsbuttons_hover_centermenu">
                                                                                                                                    <ul>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkContactProfile" Style="background: none !important; border: none;"
                                                                                                                                                runat="server" ToolTip="Profile" CommandName="PROFILE"><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkContactHistory" Style="background: none !important; border: none;"
                                                                                                                                                runat="server" ToolTip="History" CommandName="HISTORY" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "GuestName")%>'><img src="../../images/file.png" /></asp:LinkButton>
                                                                                                                                        </li>
                                                                                                                                        <li>
                                                                                                                                            <asp:LinkButton ID="lnkContactMessage" Style="background: none !important; border: none;"
                                                                                                                                                runat="server" ToolTip="Message" CommandName="MESSAGE"><img src="../../images/file.png" /></asp:LinkButton>
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
                                                                                                                <asp:Label ID="lblNoRecordFoundForRestaurant" runat="server" Text="No Record Found."></asp:Label>
                                                                                                            </b>
                                                                                                        </div>
                                                                                                    </EmptyDataTemplate>
                                                                                                </asp:GridView>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:View>
                                                                            <asp:View ID="vGuestHistory" runat="server">
                                                                                <div class="box_col1">
                                                                                    <div class="box_head">
                                                                                        <span>
                                                                                            <asp:Literal ID="litHistory" runat="server" Text="History"></asp:Literal></span></div>
                                                                                    <div class="clear">
                                                                                    </div>
                                                                                    <div class="box_form">
                                                                                        <ucCtrlGuestHistory:GuestHistory ID="ctrlCommonGuestHistory" runat="server" OnbtnGuestHistoryCallParent_Click="btnGuestHistoryCallParent_Click" />
                                                                                    </div>
                                                                                    <div class="clear">
                                                                                    </div>
                                                                                </div>
                                                                            </asp:View>
                                                                        </asp:MultiView>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td class="boxright">
                            </td>
                        </tr>
                        <tr>
                            <td class="boxbottomleft">
                            </td>
                            <td class="boxbottomcenter">
                            </td>
                            <td class="boxbottomright">
                            </td>
                        </tr>
                    </table>
                    <div style="height: 10px;">
                    </div>
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
<asp:UpdateProgress AssociatedUpdatePanelID="updBanquetMgmt" ID="UpdateProgressBanquetMgmt"
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
