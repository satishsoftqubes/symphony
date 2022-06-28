<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CltrDashBoardInvestors.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.DashBoard.CltrDashBoardInvestors" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBoxInvestors" TagPrefix="ucI" %>

<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessageForInvestors() {
        document.getElementById('errormessageInvestors').style.display = "block";
    }
</script>

<table width="100%" border="0" cellspacing="0" cellpadding="0" class="box" style="height: 100%; min-width:225px;">
    <tr>
        <td class="boxtopleft">
            &nbsp;
        </td>
        <td class="boxtopcenter">
            Investors -
            <asp:Label ID="lblInvestorsCount" runat="server"></asp:Label><a href="../../Applications/Investors/InvestorList.aspx"><img
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
            <asp:GridView ID="gvInvestors" runat="server" ShowHeader="false" Width="100%" AutoGenerateColumns="false"
                SkinID="gvNoPaging" OnRowDataBound="gvInvestors_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="box_content">
                                <ul class="box_contentlist">
                                    <li>Name: <span>
                                        <%#DataBinder.Eval(Container.DataItem, "Name")%></span></li>
                                    <li>Mobile: <span>
                                        <asp:Literal ID="litDBMobileNo" runat="server"></asp:Literal></span></li>
                                    <li>No. of Units: <span>
                                        <%#DataBinder.Eval(Container.DataItem, "Units")%></span></li>
                                </ul>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div class="pagecontent_info">
                        <div class="NoItemsFound">
                            <h2>
                                <asp:Literal ID="ltrIMsg" runat="server" Text="No Record Found"></asp:Literal></h2>
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
<div id="errormessageInvestors" class="clear" style="display: none;">
    <ucI:MsgBoxInvestors ID="MsgBoxInvestors" runat="server" />
</div>
