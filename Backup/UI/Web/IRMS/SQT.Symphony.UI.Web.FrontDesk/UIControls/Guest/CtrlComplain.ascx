<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlComplain.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest.CtrlComplain" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function pageLoad(sender, args) {
        $('#<%=txtTime.ClientID %>').timepicker({ ampm: false });

        $("#tabs").tabs();

        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });

    }

    function fnClearServiceDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
    
</script>
<asp:UpdatePanel ID="updComplain" runat="server">
    <ContentTemplate>
        <asp:MultiView ID="mvMessage" runat="server">
            <asp:View ID="vMessageList" runat="server">
                <div class="box_col1">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="Literal1" runat="server" Text="Complatin"></asp:Literal></span></div>
                    <div class="clear">
                    </div>
                    <div class="box_form">
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td>
                                    <asp:Literal ID="litSearchDepartment" runat="server" Text="Department"></asp:Literal>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSearchDepartment" runat="server">
                                        <asp:ListItem Selected="True" Value="-Select-" Text="-Select-"></asp:ListItem>
                                        <asp:ListItem Value="FrontDesk" Text="FrontDesk"></asp:ListItem>
                                        <asp:ListItem Value="HouseKeeping" Text="HouseKeeping"></asp:ListItem>
                                        <asp:ListItem Value="POS" Text="POS"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Literal ID="litSearchGuestName" runat="server" Text="Name"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSearchGuestName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="litSearchStartDate" runat="server" Text="Start Date"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSearchStartDate" runat="server"></asp:TextBox>
                                    <asp:Image ID="imgStartDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                        Height="20px" Width="20px" />
                                    <ajx:CalendarExtender ID="calStartDate" PopupButtonID="imgStartDate" TargetControlID="txtSearchStartDate"
                                        runat="server" Format="dd/MMM/yyyy">
                                    </ajx:CalendarExtender>
                                    <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" title="Clear Date"
                                        onclick="fnClearServiceDate('<%= txtSearchStartDate.ClientID %>');" />
                                </td>
                                <td>
                                    <asp:Literal ID="litSearchEndDate" runat="server" Text="End Date"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSearchEndDate" runat="server"></asp:TextBox>
                                    <asp:Image ID="imgEndDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                        Height="20px" Width="20px" />
                                    <ajx:CalendarExtender ID="calEndDate" PopupButtonID="imgEndDate" TargetControlID="txtSearchEndDate"
                                        runat="server" Format="dd/MMM/yyyy">
                                    </ajx:CalendarExtender>
                                    <img src="../../images/clear.png" id="img2" style="vertical-align: middle;" title="Clear Date"
                                        onclick="fnClearServiceDate('<%= txtSearchEndDate.ClientID %>');" />
                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                        Style="border: 0px; margin: -4px 0 0 5px; vertical-align: middle;" />
                                    <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                        Style="border: 0px; vertical-align: middle; margin: 0 0 0 10px;" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="padding-bottom: 10px;" colspan="4">
                                    <asp:Button ID="btnTopAddMessage" runat="server" Text="Add" OnClick="btnTopAddMessage_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top;" colspan="4">
                                    <div class="box_head">
                                        <span>
                                            <asp:Literal ID="litMessageList" runat="server" Text="Message List"></asp:Literal>
                                        </span>
                                    </div>
                                    <div class="clear">
                                    </div>
                                    <div class="box_content">
                                        <asp:GridView ID="gvComplainList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                            SkinID="gvNoPaging" Width="100%">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrDepartment" runat="server" Text="Department"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "Department")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "Date")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrGuestName" runat="server" Text="Name"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "Guest")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblGvHdrERUnitRate" runat="server" Text="Nature Of Complaint"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "NatureOfComplain")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div style="padding: 10px;">
                                                    <b>
                                                        <asp:Label ID="lblNoRecordFound" runat="server" Text="No Record Found."></asp:Label>
                                                    </b>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="padding-top: 10px;" colspan="4">
                                    <asp:Button ID="btnBottomAddMessage" runat="server" Text="Add" OnClick="btnTopAddMessage_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="clear">
                    </div>
                    <div>
            </asp:View>
            <asp:View ID="vMessage" runat="server">
                <div class="box_col1">
                    <div class="box_head">
                        <span>
                            <asp:Literal ID="litComplatin" runat="server" Text="Complatin"></asp:Literal></span></div>
                    <div class="clear">
                    </div>
                    <div class="box_form">
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td class="isrequire" style="width: 130px !important;">
                                    <asp:Literal ID="litComplainBy" runat="server" Text="Complain By"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtComplainBy" runat="server"></asp:TextBox>
                                    <span>
                                        <asp:RequiredFieldValidator ID="rfvComplainBy" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                            runat="server" ValidationGroup="IsRequire" ControlToValidate="txtComplainBy"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td class="isrequire" style="width: 130px !important;">
                                    <asp:Literal ID="litDepartment" runat="server" Text="Department"></asp:Literal>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDepartment" runat="server">
                                        <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000" Text="-Select-"></asp:ListItem>
                                        <asp:ListItem Value="FrontDesk" Text="FrontDesk"></asp:ListItem>
                                        <asp:ListItem Value="HouseKeeping" Text="HouseKeeping"></asp:ListItem>
                                        <asp:ListItem Value="POS" Text="POS"></asp:ListItem>
                                    </asp:DropDownList>
                                    <span>
                                        <asp:RequiredFieldValidator ID="rvfDepartment" InitialValue="00000000-0000-0000-0000-000000000000"
                                            SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                            ValidationGroup="IsRequire" ControlToValidate="ddlDepartment" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td class="isrequire" style="width: 130px !important;">
                                    <asp:Literal ID="litNatureOfComplaint" runat="server" Text="Nature Of Complaint"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNatureOfComplaint" runat="server"></asp:TextBox>
                                    <span>
                                        <asp:RequiredFieldValidator ID="rvfNatureOfComplaint" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                            runat="server" ValidationGroup="IsRequire" ControlToValidate="txtNatureOfComplaint"
                                            Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="litDescription" runat="server" Text="Description"></asp:Literal>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="isrequire" style="width: 130px !important;">
                                    <asp:Literal ID="litDate" runat="server" Text="Date"></asp:Literal>
                                </td>
                                <td>
                                    <div style="float: left;">
                                        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                        <asp:Image ID="imgDate" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                            Height="20px" Width="20px" />
                                        <ajx:CalendarExtender ID="calDate" PopupButtonID="imgDate" TargetControlID="txtDate"
                                            runat="server" Format="dd/MMM/yyyy">
                                        </ajx:CalendarExtender>
                                        <img src="../../images/clear.png" id="imgClrExt" style="vertical-align: middle;"
                                            title="Clear Date" onclick="fnClearServiceDate('<%= txtDate.ClientID %>');" />
                                        <span>
                                            <asp:RequiredFieldValidator ID="rfvDate" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtDate" Display="Static">
                                            </asp:RequiredFieldValidator>
                                        </span>
                                    </div>
                                    <div style="float: left; padding-left: 35px; padding-right: 15px;">
                                        <asp:Literal ID="litTime" runat="server" Text="Time"></asp:Literal>
                                    </div>
                                    <div style="float: left;">
                                        <asp:TextBox ID="txtTime" runat="server" Style="width: 50px !important;" onkeypress="return false;"
                                            MaxLength="5"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" Style="display: inline;" ValidationGroup="IsRequire" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Style="display: inline;"
                                        OnClick="btnCancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updComplain" ID="UpdateProgressComplain"
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
