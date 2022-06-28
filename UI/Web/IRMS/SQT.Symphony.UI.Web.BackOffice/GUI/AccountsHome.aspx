<%@ Page Title="" Language="C#" MasterPageFile="~/Master/admin.Master" AutoEventWireup="true"
    CodeBehind="AccountsHome.aspx.cs" Inherits="SQT.Symphony.UI.Web.BackOffice.GUI.AccountsHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="content">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box" style="border: none;">
                    <tr>
                        <td class="boxtopleft">
                            &nbsp;
                        </td>
                        <td class="boxtopcenter">
                            <asp:Literal ID="litMainHeader" runat="server" Text="Dashboard"></asp:Literal>
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
                            <div align="center">
                                <div style="text-align:center; vertical-align:middle;height:400px;">
                                    <div style="padding-top:170px;">
                                        Welcome to Accounts Setup
                                    </div>
                                </div>
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
            </td>
        </tr>
    </table>
</asp:Content>
