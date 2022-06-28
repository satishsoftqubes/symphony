<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlConference.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Configurations.CtrlConference" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript" src="../../fancybox/jquery.fancybox-1.3.4.pack.js"></script>
<link rel="stylesheet" type="text/css" href="../../fancybox/jquery.fancybox-1.3.4.css"
    media="screen" />
<script src="../../Javascript/jquery.MultiFile.js" type="text/javascript"></script>
<script type="text/javascript">
    function SelectAll(id) {
        //get reference of GridView control
        var grid = document.getElementById("<%= gvTypeArrangement.ClientID %>");
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

    function pageLoad(sender, args) {
        $(function () {
            $("#tabs").tabs();
        });

        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });
    }

    $(document).ready(function () {
        $("a[rel=example_group]").fancybox({
            'transitionIn': 'none',
            'transitionOut': 'none',
            'titlePosition': 'over',
            'titleFormat': function (title, currentArray, currentIndex, currentOpts) {
                return '<span id="fancybox-title-over">Image ' + (currentIndex + 1) + ' / ' + currentArray.length + (title.length ? ' &nbsp; ' + title : '') + '</span>';
            }
        });


    });

    function fnClearMessage() {
        document.getElementById('<%=lblSelectFileForRG.ClientID %>').innerHTML = "";
    }
</script>
<script language="javascript">
    function SelectTab() {
        window.location.hash = 'tabs-2';
    }

    function SelectTabIndex(tabIndex) {
        var tabOpts = {
            disabled: [1]
        };

        $("#tabs").tabs(tabOpts);
        if (tabIndex == '0') {
            $("#tabs").tabs("disable", 1);
        }
        else if (tabIndex == '1') {
            $("#tabs").tabs("enable", 1);
        }
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<script type="text/javascript">
    var updateProgress = null;

    function postbackButtonClick() {
        if (Page_ClientValidate("IsRequire")) {
            document.getElementById('errormessage').style.display = "block";
            updateProgress = $find("<%= UpdateProgressConference.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
    }
</script>
<asp:UpdatePanel ID="upnlConference" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#fff">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server"></asp:Literal>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td align="left" style="padding-top: 10px; background-color: #fff !important;">
                                <div class="demo">
                                    <div id="tabs">
                                        <ul>
                                            <li><a href="#tabs-1">
                                                <asp:Literal ID="litTabBasicInformation" runat="server"></asp:Literal>
                                            </a></li>
                                            <li><a href="#tabs-2">
                                                <asp:Literal ID="litTabGallary" runat="server"></asp:Literal></a></li>
                                        </ul>
                                        <div id="tabs-1">
                                            <table cellpadding="2" cellspacing="2" width="100%">
                                                <tr>
                                                    <td colspan="3">
                                                        <%if (IsListMessage)
                                                          { %>
                                                        <div class="message finalsuccess">
                                                            <p>
                                                                <strong>
                                                                    <asp:Literal ID="ltrListMessage" runat="server"></asp:Literal>
                                                                </strong>
                                                            </p>
                                                        </div>
                                                        <%}%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <div style="float: right; padding-bottom: 5px;">
                                                            <b>
                                                                <asp:Literal ID="litGeneralMandartoryFiledMessage" runat="server"></asp:Literal>
                                                            </b>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire" width="150px">
                                                        <asp:Label ID="lbltpConferenceName" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtConferenceName" SkinID="searchtextbox" runat="server" MaxLength="120"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvConferenceName" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtConferenceName"
                                                                Display="Dynamic"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Label ID="lbltpConferenceCode" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtConferenceCode" SkinID="searchtextbox" runat="server" MaxLength="5"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rvfConferenceCode" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtConferenceCode"
                                                                Display="Dynamic"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Label ID="lbltpHWL" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="isrequire" colspan="2">
                                                        <asp:TextBox ID="txtH" SkinID="searchtextbox" Style="text-align: right;" MaxLength="18"
                                                            runat="server"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftHeight" runat="server" TargetControlID="txtH"
                                                            FilterType="Custom, Numbers" ValidChars="." />
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rvfH" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtH" Display="Dynamic"></asp:RequiredFieldValidator></span>
                                                        &nbsp;&nbsp;&nbsp;x&nbsp;
                                                        <asp:TextBox ID="txtW" Style="width: 125px; text-align: right;" MaxLength="18" runat="server"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftWeight" runat="server" TargetControlID="txtW"
                                                            FilterType="Custom, Numbers" ValidChars="." />
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rvfW" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtW" Display="Dynamic"></asp:RequiredFieldValidator></span>
                                                        &nbsp;&nbsp;&nbsp;x&nbsp;
                                                        <asp:TextBox ID="txtL" Style="width: 125px; text-align: right;" MaxLength="18" runat="server"></asp:TextBox>
                                                        <ajx:FilteredTextBoxExtender ID="ftLength" runat="server" TargetControlID="txtL"
                                                            FilterType="Custom, Numbers" ValidChars="." />
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rvfL" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtL" Display="Dynamic"></asp:RequiredFieldValidator></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:RegularExpressionValidator ID="revHeight" SetFocusOnError="True" runat="server"
                                                            ValidationGroup="IsRequire" ControlToValidate="txtH" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="revWidth" SetFocusOnError="True" runat="server"
                                                            ValidationGroup="IsRequire" ControlToValidate="txtW" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                                        <asp:RegularExpressionValidator ID="revLength" SetFocusOnError="True" runat="server"
                                                            ValidationGroup="IsRequire" ControlToValidate="txtL" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Label ID="lbltpKeyExtNo" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="isrequire" colspan="2">
                                                        <asp:TextBox ID="txtKeyNo" SkinID="searchtextbox" runat="server" MaxLength="10"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rvfKeyNo" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtKeyNo" Display="Dynamic"></asp:RequiredFieldValidator></span>
                                                        <ajx:FilteredTextBoxExtender ID="ftKeyNo" runat="server" TargetControlID="txtKeyNo"
                                                            FilterType="Numbers" />
                                                        &nbsp;&nbsp;&nbsp; /&nbsp;
                                                        <asp:TextBox ID="txtExtNo" Style="width: 125px" runat="server" MaxLength="10"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rvfExtNo" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtExtNo" Display="Dynamic"></asp:RequiredFieldValidator></span>
                                                        <ajx:FilteredTextBoxExtender ID="ftExtNo" runat="server" TargetControlID="txtExtNo"
                                                            FilterType="Numbers" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="isrequire">
                                                        <asp:Label ID="lblRackRate" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtRackRate" runat="server" MaxLength="18" Style="text-align: right;"
                                                            SkinID="searchtextbox"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="rfvRackRate" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtRackRate" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="revRackRate" SetFocusOnError="True" runat="server"
                                                                ValidationGroup="IsRequire" ControlToValidate="txtRackRate" Display="Dynamic"
                                                                ForeColor="Red"></asp:RegularExpressionValidator>
                                                        </span>
                                                        <ajx:FilteredTextBoxExtender ID="flRackRate" runat="server" TargetControlID="txtRackRate"
                                                            FilterType="Custom, Numbers" ValidChars="." />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top;">
                                                        <asp:Label ID="lbltpDetail" runat="server"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="txtDetail" SkinID="BigInput" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th align="left" colspan="3">
                                                        <asp:Literal ID="litTypeArrangement" runat="server"></asp:Literal>
                                                        <hr />
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" class="content_checkbox">
                                                        <div class="clear">
                                                        </div>
                                                        <div class="box_content">
                                                            <asp:GridView ID="gvTypeArrangement" runat="server" AutoGenerateColumns="False" Width="50%"
                                                                SkinID="gvNoPaging" OnRowDataBound="gvTypeArrangement_RowDataBound" DataKeyNames="ConferenceTypeID">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="35px">
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="chkGvType" runat="server" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkType" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="35px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrSrNo" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="250px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrType" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ConferenceTypeName")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <asp:Label ID="lblGvHdrCapacity" runat="server"></asp:Label>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtGvCapacity" runat="server" MaxLength="8" SkinID="nowidth" Width="80px"
                                                                                Style="text-align: right;" Text='<%#DataBinder.Eval(Container.DataItem, "MaximumCapacity")%>'></asp:TextBox>
                                                                            <ajx:FilteredTextBoxExtender ID="ftCapacity" runat="server" TargetControlID="txtGvCapacity"
                                                                                FilterType="Numbers" />
                                                                            <asp:RequiredFieldValidator ID="rfvtxtCapacity" SetFocusOnError="True" CssClass="input-notification error png_bg"
                                                                                runat="server" ValidationGroup="IsRequire" ControlToValidate="txtGvCapacity"
                                                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div style="padding: 10px;">
                                                                        <b>
                                                                            <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label>
                                                                        </b>
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <div style="float: right; width: auto; display: inline-block;">
                                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" ImageUrl="~/images/cancle.png"
                                                                Style="float: right; margin-left: 5px;" OnClick="btnCancel_Click" />
                                                            <asp:Button ID="btnSave" runat="server" ImageUrl="~/images/save.png" Style="float: right;
                                                                margin-left: 5px;" ValidationGroup="IsRequire" OnClick="btnSave_Click" OnClientClick="return postbackButtonClick();" />
                                                            <asp:Button ID="btnBackToList" runat="server" CausesValidation="False" ImageUrl="~/images/cancle.png"
                                                                Style="float: right; margin-left: 5px;" OnClick="btnBackToList_Click" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="tabs-2">
                                            <asp:UpdatePanel ID="updConferencePhoto" runat="server">
                                                <ContentTemplate>
                                                    <table cellpadding="2" cellspacing="2" width="100%">
                                                        <tr>
                                                            <td>
                                                                <%if (IsListMessageForGallary)
                                                                  { %>
                                                                <div class="message finalsuccess">
                                                                    <p>
                                                                        <strong>
                                                                            <asp:Literal ID="ltrListMessageGallary" runat="server"></asp:Literal></strong>
                                                                    </p>
                                                                </div>
                                                                <%}%>
                                                            </td>
                                                        </tr>
                                                        <tr id="trPhoto" runat="server">
                                                            <td>
                                                                <div style="float: left; width: 250px;">
                                                                    <div id='browse_file' style="float: left; padding-right: 25px;">
                                                                        <asp:FileUpload ID="fuRoomPhoto" runat="server" class="multi" onchange="fnClearMessage();" />
                                                                    </div>
                                                                    <div style="float: left;">
                                                                        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" OnClientClick="return postbackButtonClick();" />
                                                                    </div>
                                                                    <br />
                                                                    <br />
                                                                    <asp:Label ID="lblSelectFileForRG" Style="font-size: 14px; color: Red; margin-left: 10px;"
                                                                        runat="server"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <hr />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DataList ID="dtlstConferenceGallary" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                                                    RepeatLayout="Table" OnItemCommand="dtlstConferenceGallary_ItemCommand" DataKeyField="DocumentName"
                                                                    OnItemDataBound="dtlstConferenceGallary_ItemDataBound">
                                                                    <ItemTemplate>
                                                                        <a rel="example_group" id="aLinkImage" runat="server" style="height: 125px; width: 100px;
                                                                            padding-right: 25px;" href='<%#GetImage(DataBinder.Eval(Container.DataItem, "DocumentName"))%>'>
                                                                            <img id="imgOfGallary" alt="" runat="server" style="height: 150px; width: 125px;
                                                                                padding-right: -25px;" src='<%#GetImage(DataBinder.Eval(Container.DataItem, "DocumentName"))%>' /></a>
                                                                        <br />
                                                                        <div style="text-align: center; border: 0px;">
                                                                            <asp:LinkButton ID="lnkConferenceGallaryDelete" runat="server" CommandName="DELETEPHOTO"
                                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem, "DocumentID")%>' OnClientClick="return postbackButtonClick();"
                                                                                OnDataBinding="lnkConferenceGallaryDelete_DataBinding"><img style="border:0 !important; text-align:center; margin-left:-25px;" border="0" src="../../images/delete.png" /></asp:LinkButton>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:DataList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="btnUpload" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </td>
                            <td class="boxright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #fff;">
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
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSave" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="upnlConference" ID="UpdateProgressConference"
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
