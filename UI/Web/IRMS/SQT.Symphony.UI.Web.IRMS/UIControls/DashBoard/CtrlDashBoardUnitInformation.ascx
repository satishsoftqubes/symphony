<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlDashBoardUnitInformation.ascx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.DashBoard.CtrlUnitInformation" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBoxProspects" TagPrefix="ucP" %>

<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessageForUnitInformation() {
        document.getElementById('errormessageUnitInformation').style.display = "block";
    }
</script>

<table width="100%" border="0" cellspacing="0" cellpadding="0" class="box" style="height: 100%; min-width:225px;">
    <tr>
        <td class="boxtopleft">
            &nbsp;
        </td>
        <td class="boxtopcenter">
            UNIT INFORMATION - <asp:Label ID="lblProspectsCount" runat="server"></asp:Label><a href="<%=Page.ResolveUrl("~/Applications/Investors/InvestorUnitList.aspx") %>"><img alt="View" src="../../images/box_arrow.jpg" /></a>
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
        <div style="min-height:175px;">
            <asp:GridView ID="gvProspects" runat="server" ShowHeader="false" Width="100%" AutoGenerateColumns="false"
                SkinID="gvNoPaging">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="box_content">
                                <ul class="box_contentlist">
                                    <li>Name: <span>
                                        <%#DataBinder.Eval(Container.DataItem, "PropertyName")%></span></li>
                                    <li>No. of Units: <span>
                                        <%#DataBinder.Eval(Container.DataItem, "TotalUnitCount")%></span></li>
                                </ul>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div class="pagecontent_info">
                        <div class="NoItemsFound">
                            <h2>
                                <asp:Literal ID="litNoRecordFound" runat="server" Text="No Record Found"></asp:Literal></h2>
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
<div id="errormessageUnitInformation" class="clear" style="display: none;">
    <ucP:MsgBoxProspects ID="MessageBox" runat="server" />
</div>
