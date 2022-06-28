<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlAddGuest.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation.ctrlAddGuest" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
    function ReservationValidate() {
        var gvReservationList = document.getElementById("<%=gvReservationList.ClientID%>");
        var ResCheck = gvReservationList.getElementsByTagName("input");
        var flag = 0;
        for (var i = 0; i < ResCheck.length; i++) {
            if (ResCheck[i].type == "checkbox") {
                if (ResCheck[i].checked) {
                    flag++;
                }
            }
        }

        if (flag == 0) {
            document.getElementById('<%=lblCustomePopupMsg.ClientID %>').innerHTML = "Please Select Reservation";
            $find('mpeCustomePopup').show();
            return false;
        }
        else if (flag > 1) {
            document.getElementById('<%=lblCustomePopupMsg.ClientID %>').innerHTML = "Please Select only one Reservation";
            $find('mpeCustomePopup').show();
            return false;
        }

        var gvGuestList = document.getElementById("<%=gvGuestList.ClientID%>");
        var GuestCheck = gvGuestList.getElementsByTagName("input");
        var flagGuest = false;
        for (var i = 0; i < GuestCheck.length; i++) {
            if (GuestCheck[i].type == "checkbox") {
                if (GuestCheck[i].checked) {
                    flagGuest = true;
                    break;
                }
            }
        }

        if (flagGuest == false) {
            document.getElementById('<%=lblCustomePopupMsg.ClientID %>').innerHTML = "Please Select atlease one Guest";
            $find('mpeCustomePopup').show();
            return false;
        }
    }

    function fnTempGuest() {
        var gvTempGuestList = document.getElementById("<%=gvTempGuestList.ClientID%>");
        var TempCheck = gvTempGuestList.getElementsByTagName("input");
        var flag = 0;
        for (var i = 0; i < TempCheck.length; i++) {
            if (TempCheck[i].type == "checkbox") {
                if (TempCheck[i].checked) {
                    flag++;
                    break;
                }
            }
        }

        if (flag == 0) {
            document.getElementById('<%=lblCustomePopupMsg.ClientID %>').innerHTML = "Please Select atlease one Guest";
            $find('mpeCustomePopup').show();
            return false;
        }
    }
</script>
<asp:UpdatePanel ID="updAddGroupGuest" runat="server">
    <ContentTemplate>
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="3">
                    <table width="100%" cellpadding="2" cellspacing="2">
                        <tr>
                            <td class="isrequire" style="width: 75px;">
                                <asp:Literal ID="litName" runat="server" Text="Name"></asp:Literal>
                            </td>
                            <td width="110px">
                                <asp:DropDownList ID="ddlTitle" runat="server" Style="width: 75px; height: 25px;">
                                    <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                    <asp:ListItem Text="Mr." Value="Mr."></asp:ListItem>
                                    <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                                    <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfTitle" InitialValue="00000000-0000-0000-0000-000000000000"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                        ValidationGroup="IsRequire" ControlToValidate="ddlTitle" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td width="265px">
                                <asp:TextBox ID="txtFirstName" runat="server" MaxLength="200"></asp:TextBox>
                                <ajx:TextBoxWatermarkExtender ID="txtwmeFirstName" runat="server" TargetControlID="txtFirstName"
                                    WatermarkText="First Name">
                                </ajx:TextBoxWatermarkExtender>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfFirstName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtFirstName" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLastName" runat="server" MaxLength="200"></asp:TextBox>
                                <ajx:TextBoxWatermarkExtender ID="txtwmeLastName" runat="server" TargetControlID="txtLastName"
                                    WatermarkText="Last Name">
                                </ajx:TextBoxWatermarkExtender>
                                <asp:ImageButton ID="imgbtnSearchaGuest" runat="server" ImageUrl="~/images/search-icon.png"
                                    Style="border: 0px; vertical-align: middle; margin: -4px 0 0 10px;" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="3" class="chekcbox_new">
                                <asp:CheckBox ID="chkNotAssigned" runat="server" Text="Not-Assigned" />
                                <asp:CheckBox ID="chkReservationLeader" runat="server" Text="Reservation Leader" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-bottom: 10px;" align="center">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Style="display: inline;" ValidationGroup="IsRequire" />
                    <asp:Button ID="btnNew" runat="server" Text="New" Style="display: inline;" />
                    <asp:Button ID="btnProfile" runat="server" Text="Profile" Style="display: inline;"
                        ValidationGroup="IsRequire" />
                </td>
            </tr>
            <tr>
                <td style="height: 300px; overflow: auto; vertical-align: top;" colspan="3">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="litgvHdrReservationList" runat="server" Text="Reservation List"></asp:Literal>
                        </span>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="box_content">
                        <asp:GridView ID="gvReservationList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrReservationListSelect" runat="server" Text="Select"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelectReservation" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrReservationNo" runat="server" Text="RES No."></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrUnitType" runat="server" Text="Room Type"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "RoomType")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrUnitNo" runat="server" Text="Room No."></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrGuestName" runat="server" Text="GST[4/2]"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "Guest")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="padding: 10px;">
                                    <b>
                                        <asp:Label ID="lblNoRecordFound" runat="server" Text="No Record Found"></asp:Label>
                                    </b>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td width="48%" style="vertical-align: top;">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="ligGuestList" runat="server" Text="Guest List"></asp:Literal>
                        </span>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="box_content">
                        <asp:GridView ID="gvGuestList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                            Width="100%" DataKeyNames="ID">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrReservationListSelect" runat="server" Text="Select"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkGuestListSelect" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrGuestName" runat="server" Text="GST[5]"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGuest" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Guest")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrStatus" runat="server" Text="Status"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "Status")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblLegend" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Legend")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="padding: 10px;">
                                    <b>
                                        <asp:Label ID="lblNoRecordFoundForGuestList" runat="server" Text="No Record Found"></asp:Label>
                                    </b>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </td>
                <td width="4%" style="padding-left: 5px; padding-right: 5px;">
                    <asp:Button ID="btnTransfer" runat="server" Text=">" OnClick="btnTransfer_Click"
                        OnClientClick="return ReservationValidate();" /><br />
                    <asp:Button ID="btnReverseTranser" runat="server" Text="<" OnClick="btnReverseTranser_Click"
                        OnClientClick="return fnTempGuest();" />
                </td>
                <td width="48%" style="vertical-align: top;">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="litTempGuestList" runat="server" Text="Guest List"></asp:Literal>
                        </span>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="box_content">
                        <asp:GridView ID="gvTempGuestList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                            Width="100%" DataKeyNames="ID">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrReservationListSelect" runat="server" Text="Select"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkTempGuestListSelect" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrTempGuestName" runat="server" Text="GST"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTempGuest" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Guest")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:Label ID="lblGvHdrTempStatus" runat="server" Text="Status"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#DataBinder.Eval(Container.DataItem, "Status")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTempLegend" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Legend")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="padding: 10px;">
                                    <b>
                                        <asp:Label ID="lblNoRecordFoundForTempGuestList" runat="server" Text="No Record Found"></asp:Label>
                                    </b>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hfPopupCustomeMessage" runat="server" />
        <ajx:ModalPopupExtender ID="mpeCustomePopup" runat="server" TargetControlID="hfPopupCustomeMessage"
            PopupControlID="pnlCustomeMessage" BackgroundCssClass="mod_background" CancelControlID="btnOKCustomeMsgPopup"
            DropShadow="true" BehaviorID="mpeCustomePopup">
        </ajx:ModalPopupExtender>
        <asp:Panel ID="pnlCustomeMessage" runat="server" Width="350px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litHeaderCustomePopupMessage" runat="server" Text="Message"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px; color: Red;">
                                <asp:Label ID="lblCustomePopupMsg" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnOKCustomeMsgPopup" runat="server" Text="OK" Style="display: inline;
                                    padding-right: 10px;" />
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
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updAddGroupGuest" ID="UpdateProgressAddGroupGuest"
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
