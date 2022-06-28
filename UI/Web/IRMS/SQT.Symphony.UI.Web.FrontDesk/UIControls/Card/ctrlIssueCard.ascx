<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlIssueCard.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Card.ctrlIssueCard" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonGuestHistory.ascx" TagName="GuestHistory"
    TagPrefix="ucCtrlGuestHistory" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript">
    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function fnClearDate(para1) {
        document.getElementById(para1).value = '';
    }

    function ChangeImage(imgID) {
        var imgURL = document.getElementById(imgID).src.split('/');
        if (imgURL[imgURL.length - 1] == 'downarrow.jpg') {
            document.getElementById(imgID).src = "../../images/uparrow.jpg";
        }
        else {
            document.getElementById(imgID).src = '../../images/downarrow.jpg';
        }
        var cnt = 1;
        while (cnt <= 5) {
            var imgIdRec = "imgAcc" + cnt;
            if (document.getElementById(imgIdRec) != 'null' && imgIdRec != imgID) {
                var imgURL = document.getElementById(imgIdRec).src.split('/');
                document.getElementById(imgIdRec).src = "../../images/uparrow.jpg";
            }
            cnt = cnt + 1;
        }
    }

</script>
<asp:UpdatePanel ID="updIssueCard" runat="server">
    <ContentTemplate>
        <%-- <div class="box_col1">
            <div class="box_head">
                <span>
                    <asp:Literal ID="litGuestMaster" runat="server" Text="Issue Card"></asp:Literal></span></div>
            <div class="clear">
            </div>
            <div class="box_form">--%>
        <table width="100%" cellspacing="0" cellpadding="0">
            <%-- <td width="25%" style="padding-right: 5px; vertical-align: top;">
                            <ajx:Accordion ID="accrGuestSearchMaster" runat="server" SelectedIndex="0" HeaderCssClass="leftmargin_head_accordianpanel"
                                HeaderSelectedCssClass="leftmargin_head_accordianpanel" FadeTransitions="false"
                                FramesPerSecond="40" TransitionDuration="250" AutoSize="none" RequireOpenedPane="false"
                                SuppressHeaderPostbacks="true">
                                <Panes>
                                    <ajx:AccordionPane ID="AcPnGuestMaster" runat="server">
                                        <Header>
                                            <div class="leftmargin_head" onclick="ChangeImage('imgAcc1');">
                                                <div style="float: left;">
                                                    <a href="" class="accordionLink" onclick="ChangeImage('imgAcc1');">
                                                        <asp:Literal ID="litLHdrPersonalInfo" runat="server" Text="Personal Info"></asp:Literal></a>                                                        
                                                </div>
                                                <div style="float: right; margin: 6px -50px 0 0;">
                                                    <a href="" onclick="ChangeImage('imgAcc1');">
                                                        <img src="../../images/downarrow.jpg" id="imgAcc1" /></a>
                                                </div>
                                            </div>
                                        </Header>
                                        <Content>
                                            <table width="100%" cellspacing="2" cellpadding="2" style="border-right: 1px dotted #DDDDDF;
                                                border-left: 1px dotted #DDDDDF;">
                                                <tr>
                                                    <td width="80px">
                                                        <asp:Literal ID="litSearchLastName" runat="server" Text="Last Name"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchLastName" runat="server" Style="width: 150px !important;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litSearchFirstName" runat="server" Text="First Name"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchFirstName" runat="server" Style="width: 150px !important;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litSearchGender" runat="server" Text="Gender"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSearchGender" runat="server" Style="width: 152px !important;">
                                                            <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                                            <asp:ListItem Text="FeMale" Value="FeMale"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litSearchDateOfBirth" runat="server" Text="Date Of Birth"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchDateOfBirth" onkeypress="return false;" runat="server"
                                                            Style="width: 105px !important;"></asp:TextBox>
                                                        <asp:Image ID="imgGuestDOB" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                            Height="20px" Width="20px" />
                                                        <ajx:CalendarExtender ID="calGuestDOB" PopupButtonID="imgGuestDOB" TargetControlID="txtSearchDateOfBirth"
                                                            runat="server" Format="dd/MMM/yyyy">
                                                        </ajx:CalendarExtender>
                                                        <img src="../../images/clear.png" id="imgClearDOB" style="vertical-align: middle;"
                                                            title="Clear Date" onclick="fnClearDate('<%= txtSearchDateOfBirth.ClientID %>');" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" style="padding: 5px;">
                                                        <asp:Button ID="btnPersonalInfoSearch" runat="server" Text="Search" Style="display: inline;" />
                                                        <asp:Button ID="btnPersonalInfoClear" runat="server" Text="Clear" Style="display: inline;" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </Content>
                                    </ajx:AccordionPane>
                                    <ajx:AccordionPane ID="AcPnAddressInfo" runat="server">
                                        <Header>
                                            <div class="leftmargin_head" onclick="ChangeImage('imgAcc2');">
                                                <div style="float: left;">
                                                    <a href="" class="accordionLink" onclick="ChangeImage('imgAcc2');">
                                                        <asp:Literal ID="litLHdrAddressInfo" runat="server" Text="Address Info"></asp:Literal></a>
                                                </div>
                                                <div style="float: right; margin: 6px -50px 0 0;">
                                                    <a href="" onclick="ChangeImage('imgAcc2');">
                                                        <img src="../../images/uparrow.jpg" id="imgAcc2" /></a>
                                                </div>
                                            </div>
                                        </Header>
                                        <Content>
                                            <table width="100%" cellspacing="2" cellpadding="2" style="border-right: 1px dotted #DDDDDF;
                                                border-left: 1px dotted #DDDDDF;">
                                                <tr>
                                                    <td width="65px">
                                                        <asp:Literal ID="litSearchCity" runat="server" Text="City"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchCity" runat="server" Style="width: 170px !important;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litSearchState" runat="server" Text="State"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchState" runat="server" Style="width: 170px !important;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litSearchAddress" runat="server" Text="Address"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchAddress" runat="server" TextMode="MultiLine" Style="width: 170px !important;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Zipcode" runat="server" Text="Zipcode"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchZipcode" runat="server" Style="width: 170px !important;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Country" runat="server" Text="Country"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchCountry" runat="server" Style="width: 170px !important;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" style="padding: 5px;">
                                                        <asp:Button ID="btnSeaachAddressInfo" runat="server" Text="Search" Style="display: inline;" />
                                                        <asp:Button ID="btnClearAddressInfo" runat="server" Text="Clear" Style="display: inline;" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </Content>
                                    </ajx:AccordionPane>
                                    <ajx:AccordionPane ID="acPnIdentification" runat="server">
                                        <Header>
                                            <div class="leftmargin_head" onclick="ChangeImage('imgAcc3');">
                                                <div style="float: left;">
                                                    <a href="" class="accordionLink" onclick="ChangeImage('imgAcc3');">
                                                        <asp:Literal ID="litLHdrIdentification" runat="server" Text="Identification"></asp:Literal></a>
                                                </div>
                                                <div style="float: right; margin: 6px -50px 0 0;">
                                                    <a href="" onclick="ChangeImage('imgAcc3');">
                                                        <img src="../../images/uparrow.jpg" id="imgAcc3" /></a>
                                                </div>
                                            </div>
                                        </Header>
                                        <Content>
                                            <table width="100%" cellspacing="2" cellpadding="2" style="border-right: 1px dotted #DDDDDF;
                                                border-left: 1px dotted #DDDDDF;">
                                                <tr>
                                                    <td width="70px">
                                                        <asp:Literal ID="litSearchIDType" runat="server" Text="ID Type"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchIDType" runat="server" Style="width: 170px !important;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litSearchIDDetails" runat="server" Text="ID Details"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchIDDetails" runat="server" Style="width: 170px !important;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" style="padding: 5px;">
                                                        <asp:Button ID="btnSearchIdentification" runat="server" Text="Search" Style="display: inline;" />
                                                        <asp:Button ID="btnClearIdentification" runat="server" Text="Clear" Style="display: inline;" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </Content>
                                    </ajx:AccordionPane>
                                    <ajx:AccordionPane ID="AcPnContactInfo" runat="server">
                                        <Header>
                                            <div class="leftmargin_head" onclick="ChangeImage('imgAcc4');">
                                                <div style="float: left;">
                                                    <a href="" class="accordionLink" onclick="ChangeImage('imgAcc4');">
                                                        <asp:Literal ID="litLHdrContactInfo" runat="server" Text="Contact Info"></asp:Literal></a>
                                                </div>
                                                <div style="float: right; margin: 6px -50px 0 0;">
                                                    <a href="" onclick="ChangeImage('imgAcc4');">
                                                        <img src="../../images/uparrow.jpg" id="imgAcc4" /></a>
                                                </div>
                                            </div>
                                        </Header>
                                        <Content>
                                            <table width="100%" cellspacing="2" cellpadding="2" style="border-right: 1px dotted #DDDDDF;
                                                border-left: 1px dotted #DDDDDF;">
                                                <tr>
                                                    <td width="80px">
                                                        <asp:Literal ID="litSearchMobileNo" runat="server" Text="Mobile No."></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchMobileNo" runat="server" Style="width: 170px !important;"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftMobileNo" runat="server" TargetControlID="txtSearchMobileNo"
                                                            FilterType="Numbers" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litSearchEmail" runat="server" Text="Email"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchEmail" runat="server" Style="width: 170px !important;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" style="padding: 5px;">
                                                        <asp:Button ID="btnSearchContactInfo" runat="server" Text="Search" Style="display: inline;" />
                                                        <asp:Button ID="btnClearContactInfo" runat="server" Text="Clear" Style="display: inline;" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </Content>
                                    </ajx:AccordionPane>
                                    <ajx:AccordionPane ID="AcPnStayInfo" runat="server">
                                        <Header>
                                            <div class="leftmargin_head" onclick="ChangeImage('imgAcc5');">
                                                <div style="float: left;">
                                                    <a href="" class="accordionLink" onclick="ChangeImage('imgAcc5');">
                                                        <asp:Literal ID="litLHdrStayInfo" runat="server" Text="Stay Info"></asp:Literal></a>
                                                </div>
                                                <div style="float: right; margin: 6px -50px 0 0;">
                                                    <a href="" onclick="ChangeImage('imgAcc5');">
                                                        <img src="../../images/uparrow.jpg" id="imgAcc5" /></a>
                                                </div>
                                            </div>
                                        </Header>
                                        <Content>
                                            <table width="100%" cellspacing="2" cellpadding="2" style="border-right: 1px dotted #DDDDDF;
                                                border-left: 1px dotted #DDDDDF; border-bottom: 1px dotted #DDDDDF;">
                                                <tr>
                                                    <td width="80px">
                                                        <asp:Literal ID="litSearchBySIResNo" runat="server" Text="Res No."></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchBySIResNo" runat="server" Style="width: 170px !important;"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftSearchBySIResNo" runat="server" TargetControlID="txtSearchBySIResNo"
                                                            FilterType="Numbers" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litSearchBySIRoomNo" runat="server" Text="Room No."></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchBySIRoomNo" runat="server" Style="width: 170px !important;"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftSearchBySIRoomNo" runat="server" TargetControlID="txtSearchBySIRoomNo"
                                                            FilterType="Numbers" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litSearchBySIStayType" runat="server" Text="Stay Type"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSearchBySIStayType" runat="server" Style="width: 172px !important;">
                                                            <asp:ListItem Selected="True" Text="-Select-" Value="-Select-"></asp:ListItem>
                                                            <asp:ListItem Text="Long Stay" Value="Long Stay"></asp:ListItem>
                                                            <asp:ListItem Text="Short Stay" Value="Short Stay"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litSearchBySIArrival" runat="server" Text="Arrival"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchBySIArrival" runat="server" Style="width: 125px !important;"></asp:TextBox>
                                                        <asp:Image ID="imgSearchBySIArrival" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                            Height="20px" Width="20px" />
                                                        <ajx:CalendarExtender ID="calSearchBySIArrival" PopupButtonID="imgSearchBySIArrival"
                                                            TargetControlID="txtSearchBySIArrival" runat="server" Format="dd/MMM/yyyy">
                                                        </ajx:CalendarExtender>
                                                        <img src="../../images/clear.png" id="imgClearSearchBySIArrival" style="vertical-align: middle;"
                                                            title="Clear Date" onclick="fnClearDate('<%= txtSearchBySIArrival.ClientID %>');" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="litSearchBySIDepature" runat="server" Text="Depature"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSearchBySIDepature" runat="server" Style="width: 125px !important;"></asp:TextBox>
                                                        <asp:Image ID="imgSearchBySIDepature" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                            Height="20px" Width="20px" />
                                                        <ajx:CalendarExtender ID="calSearchBySIDepature" PopupButtonID="imgSearchBySIDepature"
                                                            TargetControlID="txtSearchBySIDepature" runat="server" Format="dd/MMM/yyyy">
                                                        </ajx:CalendarExtender>
                                                        <img src="../../images/clear.png" id="imgClearSearchBySIDepature" style="vertical-align: middle;"
                                                            title="Clear Date" onclick="fnClearDate('<%= txtSearchBySIDepature.ClientID %>');" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" style="padding: 5px;">
                                                        <asp:Button ID="btnSearchStayInfo" runat="server" Text="Search" Style="display: inline;" />
                                                        <asp:Button ID="btnCancelStayInfo" runat="server" Text="Clear" Style="display: inline;" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </Content>
                                    </ajx:AccordionPane>
                                </Panes>
                            </ajx:Accordion>
                        </td>--%>
            <td width="75%" colspan="4" style="vertical-align: top;">
                <asp:MultiView ID="mvIssueCard" runat="server">
                    <asp:View ID="vGuestList" runat="server">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="content">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="boxtopleft">
                                                &nbsp;
                                            </td>
                                            <td class="boxtopcenter">
                                                <asp:Literal ID="litGuestMaster" runat="server" Text="Issue Card List"></asp:Literal>
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
                                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:Literal ID="litSearchGuestName" runat="server" Text="Name"></asp:Literal>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtSearchGuestName" runat="server" SkinID="searchtextbox"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Literal ID="litSearchCardNo" runat="server" Text="Card No."></asp:Literal>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtSearchCardNo" runat="server" SkinID="searchtextbox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Literal ID="litSearchFolioNo" runat="server" Text="Folio No."></asp:Literal>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtSearchFolioNo" runat="server" SkinID="searchtextbox"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Literal ID="litSearchBookingNo" runat="server" Text="Booking #"></asp:Literal>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtSearchResNo" runat="server" SkinID="searchtextbox"></asp:TextBox>
                                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                                                    Style="border: 0px; margin: 2px 0 0 5px; vertical-align: middle;" />
                                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                                    Style="border: 0px; vertical-align: middle; margin: 2px 0 0 10px;" />
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
                                                                        <asp:Literal ID="litGuestList" runat="server" Text="Guest List"></asp:Literal>
                                                                    </span>
                                                                </div>
                                                                <div class="clear">
                                                                </div>
                                                                <div class="box_content">
                                                                    <asp:GridView ID="gvGuestList" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                        Width="100%" OnRowCommand="gvGuestList_RowCommand">
                                                                        <Columns>
                                                                            <asp:TemplateField ItemStyle-Width="25px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1 %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrName" runat="server" Text="Card No."></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "CardNo")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="125px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrName" runat="server" Text="Name"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "GuestName")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrBookingNo" runat="server" Text="Booking #"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "ResNo")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrRoomNo" runat="server" Text="Room No."></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "RoomNo")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrCheckInDate" runat="server" Text="Check In"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Arrival")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrCheckOutDate" runat="server" Text="Check Out"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Depature")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="65px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrBalance" runat="server" Text="Balance"></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "Balance")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                <HeaderTemplate>
                                                                                    <asp:Label ID="lblGvHdrMobileNo" runat="server" Text="Mobile No."></asp:Label>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <%#DataBinder.Eval(Container.DataItem, "MobileNo")%>
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
                                                                            <asp:TemplateField ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
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
                                                                                                                <asp:LinkButton ID="lnkIssueCard" runat="server" ToolTip="Issue Card" CommandName="ISSUECARD"
                                                                                                                    Style="background: none !important; border: none;" Text="Issue Card"><img src="../../images/file.png" /></asp:LinkButton>
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
                                                                                    <asp:Label ID="lblNoRecordFoundForService" runat="server" Text="No Record Found."></asp:Label>
                                                                                </b>
                                                                            </div>
                                                                        </EmptyDataTemplate>
                                                                    </asp:GridView>
                                                                </div>
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
                                    <div class="clear_divider">
                                    </div>
                                    <div class="clear">
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="vIssueCard" runat="server">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="content">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="boxtopleft">
                                                &nbsp;
                                            </td>
                                            <td class="boxtopcenter">
                                                <asp:Literal ID="litIssueCardHeader" runat="server" Text="Issue Card"></asp:Literal>
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
                                                            <td class="isrequire" style="width: 80px !important;">
                                                                <asp:Literal ID="litCardNo" runat="server" Text="Card No."></asp:Literal>
                                                            </td>
                                                            <td>
                                                                <div style="float: left; width: 300px;">
                                                                    <asp:TextBox ID="txtCardNo" runat="server" Enabled="false"></asp:TextBox>
                                                                    <span>
                                                                        <asp:RequiredFieldValidator ID="rfvCardNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                            runat="server" ValidationGroup="IsRequire" ControlToValidate="txtCardNo" Display="Dynamic">
                                                                        </asp:RequiredFieldValidator>
                                                                    </span>
                                                                </div>
                                                                <div style="float: left;">
                                                                    <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="isrequire" style="width: 80px !important;">
                                                                <asp:Literal ID="litAmount" runat="server" Text="Amount"></asp:Literal>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtAmount" runat="server" Style="text-align: right;"></asp:TextBox>
                                                                <ajx:FilteredTextBoxExtender ID="ftCredit" runat="server" TargetControlID="txtAmount"
                                                                    FilterType="Custom, Numbers" ValidChars="." />
                                                                <span>
                                                                    <asp:RequiredFieldValidator ID="rfvCredit" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtAmount" Display="Dynamic">
                                                                    </asp:RequiredFieldValidator>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <%--<tr>
                                        <td style="vertical-align: top;">
                                            <asp:Literal ID="litAccessibility" runat="server" Text="Accessibility"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:CheckBoxList ID="chklstAccessibility" RepeatColumns="3" RepeatDirection="Horizontal"
                                                runat="server">
                                                <asp:ListItem Text="Accomodation" Value="Accomodation"></asp:ListItem>
                                                <asp:ListItem Text="Laundry" Value="Laundry"></asp:ListItem>
                                                <asp:ListItem Text="Miscellaneous" Value="Miscellaneous"></asp:ListItem>
                                                <asp:ListItem Text="POS" Value="POS"></asp:ListItem>
                                                <asp:ListItem Text="Restaurant" Value="Restaurant"></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </td>
                                    </tr>--%>
                                                        <tr>
                                                            <td>
                                                                <asp:Literal ID="litNotes" runat="server" Text="Notes"></asp:Literal>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Style="width: 400px !important;"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" colspan="2">
                                                                <asp:Button ID="btnIssueCardSave" runat="server" Text="Save" Style="display: inline;"
                                                                    ValidationGroup="IsRequire" />
                                                                <asp:Button ID="btnIssueCardCancel" runat="server" Text="Cancel" Style="display: inline;"
                                                                    OnClick="btnIssueCardCancel_Click" />
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
                                    <div class="clear_divider">
                                    </div>
                                    <div class="clear">
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
            </tr>
        </table>
        <%-- </div>
            <div class="clear">
            </div>
        </div>--%>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updIssueCard" ID="UpdateProgressIssueCard"
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
