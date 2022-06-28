<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="grid.ascx.cs" Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.grid" %>
<%@ Register Src="~/MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script type="text/javascript" language="javascript">
    function funCloseDocument() {
        document.getElementById('<%= lblMessage.ClientID %>').style.display = "none";
        document.getElementById('<%= tblDocument.ClientID %>').style.display = "none";
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<style type="text/css">
     .grid
     {
         font-family: Arial;
         font-size: 10pt;
         width: 650px;
     }
     .grid THEAD
     {
         background-color: Green;
         color: White;
     }
 </style>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
    <tr>
        <td class="content" style="padding-left: 0px; width: 66.66%">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                <tr>
                    <td class="boxtopleft">
                        &nbsp;
                    </td>
                    <td class="boxtopcenter">
                        DOCUMENTS
                    </td>
                    <td class="boxtopright">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="boxleft">
                        &nbsp;
                    </td>
                    <td style="padding-top: 10px;">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                            <tr>
                                <td align="left" valign="middle" style="width: 165px;">
                                    Document &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtSearchDocument" runat="server"></asp:TextBox>
                                </td>
                                <td align="left" valign="middle">
                                    Category&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="ddlCategory" runat="server">
                                        <asp:ListItem Selected="True" Text="-Select-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                        <asp:ListItem Value="Company" Text="Company"></asp:ListItem>
                                        <asp:ListItem Value="Property" Text="Property"></asp:ListItem>
                                        <asp:ListItem Value="Investor" Text="Investor"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search-icon.png"
                                        Style="border: 0px; vertical-align: middle; margin-left: 5px;" OnClick="btnSearch_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table rules="all" border="1" id="dummyHeader" class = "grid" style="border-collapse:collapse">
                                        <thead>
                                            <tr>
                                                <th scope="col" width="250px">
                                                    CustomerId
                                                </th>
                                                <th scope="col" width="250px">
                                                    City
                                                </th>
                                                <th scope="col" width="100px">
                                                    Country
                                                </th>
                                                <th scope="col" width="50px">
                                                    Country
                                                </th>
                                            </tr>
                                        </thead>
                                    </table>
                                    <div id="container" style="height: 200px; overflow: auto; width: 667px">
                                        <asp:GridView ID="gvDocumentList" runat="server" AutoGenerateColumns="false" OnRowCommand="gvDocumentList_RowCommand"
                                            ShowHeader="true" ShowFooter="false" CssClass="grid" SkinID="gvNoPaging" border="1">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Document Name" HeaderStyle-HorizontalAlign="Left"
                                                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDocumentName" Width="250px" runat="server" Text='<%#GetName(DataBinder.Eval(Container.DataItem, "DocumentName"))%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Information" ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <div style="height: 5px;">
                                                        </div>
                                                        <div style="float: left; width: 90px; padding-top: 2px;">
                                                            Property :
                                                        </div>
                                                        <%#DataBinder.Eval(Container.DataItem, "PropertyName")%><br />
                                                        <div style="height: 3px; border-bottom: 1px solid #c9c9c9;">
                                                        </div>
                                                        <div style="float: left; width: 90px; padding-top: 2px;">
                                                            Type :
                                                        </div>
                                                        <%#DataBinder.Eval(Container.DataItem, "AssociationType")%><br />
                                                        <div style="height: 3px; border-bottom: 1px solid #c9c9c9;">
                                                        </div>
                                                        <div style="float: left; width: 90px; padding-top: 2px;">
                                                            Investor Name:
                                                        </div>
                                                        <%#DataBinder.Eval(Container.DataItem, "InvestorName")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDateOfSubmission" Width="100px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateOfSubmission") != DBNull.Value ? Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DateOfSubmission")).ToString(DateFormat) : ""%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="View" ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkViewDocument" runat="server" CommandName="View" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "DocumentName")%>'
                                                            Style="border: 0px;" OnClientClick="return funCloseDocument();">
                                                            <asp:Image ID="btnView" ImageUrl="~/images/view.png" runat="server" /></asp:LinkButton>
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
                                <td style="padding-top: 15px; font: 15px; color: Red;" align="center">
                                    <asp:Label ID="lblMessage" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="boxright">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="boxleft">
                        &nbsp;
                    </td>
                    <td>
                        <table width="100%" cellpadding="3" cellspacing="3" id="tblDocument" runat="server">
                            <tr>
                                <td>
                                    <asp:MultiView ID="mvDocument" runat="server">
                                        <asp:View ID="vPDF" runat="server">
                                            <table style="padding-left: 5px;" width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <div style="overflow: auto; width: 720px;">
                                                            <iframe id="fileview" scrolling="auto" runat="server" height="500px" width="720px"
                                                                style="visibility: visible;"></iframe>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 5px;" align="center">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnPDFCancel" runat="server" Text="Cancel" OnClick="btnPDFCancel_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vImage" runat="server">
                                            <table style="padding-left: 5px;" width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="center" valign="middle" style="padding-bottom: 20px;">
                                                        <div style="width: 720px; overflow: auto;">
                                                            <asp:Image ID="imgImageDoc" runat="server" /></div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-top: 5px;" align="right">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnImageCancel" runat="server" Text="Cancel" OnClick="btnImageCancel_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="boxright">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
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
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
