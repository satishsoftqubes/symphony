<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CltrDashBoardChannelPartners.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.DashBoard.CltrDashBoardChannelPartners" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBoxChannelPartners" TagPrefix="ucCP" %>

<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessageForChannelPartners() {
        document.getElementById('errormessageChannelPartners').style.display = "block";
    }
</script>

<table width="100%" border="0" cellspacing="0" cellpadding="0" class="box" style="height: 100%;
    min-width: 225px;">
    <tr>
        <td class="boxtopleft">
            &nbsp;
        </td>
        <td class="boxtopcenter">
            Channel Partners -
            <asp:Label ID="lblCPCount" runat="server"></asp:Label><a href="../../Applications/Investors/ChannerlPartnerList.aspx"><img
                src="../../images/box_arrow.jpg" /></a>
        </td>
        <td class="boxtopright">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="boxleft">
            &nbsp;
        </td>
        <td style="vertical-align: top;">
        <div style="min-height: 175px;">
            <asp:GridView ID="gvChannelPartner" runat="server" ShowHeader="false" Width="100%"
                AutoGenerateColumns="false" SkinID="gvNoPaging" OnRowDataBound="gvChannelPartner_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="box_content">
                                <ul class="box_contentlist">
                                    <li>Name: <span>
                                        <%#DataBinder.Eval(Container.DataItem, "Name")%></span></li>
                                    <li>Name of Firm: <span>
                                        <%#DataBinder.Eval(Container.DataItem, "CompanyName")%></span></li>
                                    <li>Mobile: <span>
                                        <asp:Literal ID="litDBMobileNo" runat="server"></asp:Literal></span></li>
                                </ul>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div class="pagecontent_info">
                        <div class="NoItemsFound">
                            <h2>
                                <asp:Literal ID="ltrCPMsg" runat="server" Text="No Record Found"></asp:Literal></h2>
                        </div>
                    </div>
                </EmptyDataTemplate>
            </asp:GridView>
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
<div id="errormessageChannelPartners" class="clear" style="display: none;">
    <ucCP:MsgBoxChannelPartners ID="MsgBoxChannelPartners" runat="server" />
</div>
