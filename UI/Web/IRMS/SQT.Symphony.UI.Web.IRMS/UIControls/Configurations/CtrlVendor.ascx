<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlVendor.ascx.cs" 
    Inherits="SQT.Symphony.UI.Web.IRMS.UIControls.Configurations.CtrlVendor" %>
<%@ Register Src="../../MsgBox/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<style type="text/css">
    #progressBackgroundFilter
    {
        position: fixed;
        top: 0px;
        width: 100%;
        height: 100%;
        bottom: 0px;
        left: 0px;
        right: 0px;
        overflow: hidden;
        padding: 0;
        margin: 0;
        background-color: #000;
        filter: alpha(opacity=50);
        opacity: 0.5;
        z-index: 1111111;
    }
    #processMessage
    {
        position: fixed;
        top: 50%;
        left: 50%;
        padding: 10px;
        width: 30px;
        border-radius: 10px;
        z-index: 1111112;
        background-color: #fff;
        border: solid 1px #efefef;
    }
</style>
<asp:UpdatePanel ID="updPropertyList" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 473px;">
            <tr>
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                               VENDOR SETUP
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
                                <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td>
                                            <div style="height: 26px;">
                                               <%if (IsMessage)
                                                  { %>
                                                <div class="ResetSuccessfully">
                                                    <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                        <img src="../../images/success.png" /></div>
                                                    <div>
                                                        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label></div>
                                                    <div style="height: 10px;">
                                                    </div>
                                                </div>
                                                 <%}%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtSearchVendorName" placeholder="Please Enter Vendor Name" runat="server" SkinID="CmpTextbox" MaxLength="137"></asp:TextBox>
                                            <asp:TextBox ID="txtSearchMobileNo" placeholder="Please Enter Mobile No" runat="server" SkinID="CmpTextbox" MaxLength="137"></asp:TextBox>
                                            <asp:ImageButton ID="btnSearch" CssClass="small_img" Style="border: 0px; vertical-align: middle;
                                            margin-left: 5px;" runat="server" ImageUrl="~/images/search-icon.png" OnClick="btnSearch_Click"   OnClientClick="fnDisplayCatchErrorMessage()" />
                                            <asp:ImageButton ID="btnClear" CssClass="small_img" Style="border: 0px; vertical-align: middle;
                                            margin-left: 5px;" runat="server" ImageUrl="~/images/clear.png" OnClick="btnclear_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                            </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="middle">
                                            <asp:Button ID="btnAdd" runat="server" OnClick="AddNew"  Text="Add New" Style="float: right;" />
                                        </td>
                                    </tr>
                                    
                                        <td class="dTableBox" style="padding: 10px 0px">
                                            <%--<div style="height: 310px; overflow: auto;">--%>
                                            <asp:GridView ID="grdVendorList" runat="server" AutoGenerateColumns="False" Width="100%" 
                                                OnPageIndexChanging="grdVendorList_OnPageIndexChanging" OnRowCommand="grdVendorList_RowCommand">
                                                <Columns>
                                                  
                                                    <asp:TemplateField HeaderText="Vendor Name" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkbtnvendorName" Text='<%#DataBinder.Eval(Container.DataItem, "VendorName")%>'
                                                                runat="server" CommandName="VENDORNAME" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "VendorID")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Contact Name" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkbtncontactName" Text='<%#DataBinder.Eval(Container.DataItem, "ContactName")%>'
                                                                runat="server" CommandName="CONTACTNAME" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "VendorID")%>'/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Type" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkbtntype" Text='<%#DataBinder.Eval(Container.DataItem, "DisplayTerm")%>' 
                                                                runat="server" CommandName="TYPE" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "VendorID")%>'/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mobile No" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Left"
                                                        ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkbtnmobileNo" Text='<%#DataBinder.Eval(Container.DataItem, "MobileNo")%>'
                                                                runat="server" CommandName="MOBILENO" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "VendorID")%>'/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Edit/View" ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" runat="server" ToolTip="Edit" ImageUrl="~/images/edit.png"
                                                                Style="border: 0px; vertical-align: middle; margin-top: 2px;" CommandName="EDITDATA"
                                                                 OnClientClick="fnDisplayCatchErrorMessage()" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "VendorID")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="20px" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnDelete" runat="server" ToolTip="Delete" ImageUrl="~/images/delete_icon.png"
                                                                Style="border: 0px; vertical-align: middle; margin-top: 1px;" CommandName="DELETEDATA"
                                                                 OnClientClick="fnDisplayCatchErrorMessage()" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "VendorID")%>'/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <div class="pagecontent_info">
                                                        <div class="NoItemsFound">
                                                            <h2>
                                                                <asp:Literal ID="Literal5" runat="server" Text="No Record Found"></asp:Literal></h2>
                                                        </div>
                                                    </div>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                            <%--</div>--%>
                                        </td>
                                        <tr>
                                        <td align="right" valign="middle">
                                            <asp:Button ID="Button1" runat="server" OnClick="AddNew" Text="Add New" Style="float: right;" />
                                        </td>
                                    </tr>
                                    </tr>
                                    
                                </table>
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
                    <%--<div id="errormessage" class="clear" style="display: none;">
                        <uc1:MsgBox ID="MessageBox" runat="server" />
                    </div>--%>
                </td>
            </tr>
        </table>
        <ajx:ModalPopupExtender ID="Deletemsgbx" runat="server" TargetControlID="hfMessage" PopupControlID="Panel1"
            BackgroundCssClass="mod_background">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hfMessage" runat="server" />
       <asp:Panel ID="Panel1" runat="server" Style="display: none;">
            <div style="width: 500px; height: 200px; margin-top: 25px;">
                <table border="0" cellspacing="0" cellpadding="0" class="modelpopup_box">
                    <tr>
                        <td class="modelpopup_boxtopleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxtopcenter">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxtopright">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="modelpopup_boxleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_box_bg">
                            <div style="width: 100px; float: left; margin-top: 10px;">
                                <asp:HyperLink ID="HyperLink1" runat="server">
                                    <asp:Image ImageUrl="~/images/error.png" AlternateText="" Height="75px" Width="75px"
                                        ID="Image1" runat="server" />
                                </asp:HyperLink>
                            </div>
                            <div style="float: left; width: 225px; margin-top: 40px; margin-left: 10px;">
                                <asp:Label ID="Label1" runat="server" Text="Sure you want to delete?"></asp:Label>
                            </div>
                            <table cellpadding="3" cellspacing="3" width="100%" style="margin-left: 5px; margin-top: 15px;">
                                <tr>
                                    <td align="center" valign="middle">
                                        <asp:Button ID="btnVendorYes" Text="Yes" runat="server" ImageUrl="~/images/save.png"
                                            OnClick="btnVendorYes_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                        <asp:Button ID="btnVendorNo" Text="Cancel" runat="server" ImageUrl="~/images/cancle.png"
                                              OnClick="btnVendorNo_Click" Style="display: inline-block;" OnClientClick="fnDisplayCatchErrorMessage()" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="modelpopup_boxright">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="modelpopup_boxbottomleft">
                            &nbsp;
                        </td>
                        <td class="modelpopup_boxbottomcenter">
                        </td>
                        <td class="modelpopup_boxbottomright">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<asp:UpdateProgress AssociatedUpdatePanelID="updPropertyList" ID="UpdateProgressPropertyList"
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