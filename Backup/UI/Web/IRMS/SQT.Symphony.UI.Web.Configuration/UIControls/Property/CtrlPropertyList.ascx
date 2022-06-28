<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPropertyList.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.Configuration.UIControls.Property.CtrlPropertyList" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<script language="javascript" type="text/javascript">
    function fnConfirmDelete(id) {
        document.getElementById('errormessage').style.display = "block";
        document.getElementById('<%= hdnPropertyData.ClientID %>').value = id;
        $find('DeletePropertyData').show();
        return false;
    }

    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }

    function pageLoad(sender, args) {

        $(document).ready(function () {
            $("#<%=txtPropertyName.ClientID%>").autocomplete('PropertyAutoComplete.ashx');
            $("#<%=txtLocation.ClientID%>").autocomplete('../../GUI/Configurations/CityAutoComplete.ashx');            
        });
    }
       
    </script>    
<asp:UpdatePanel ID="updPropertyList" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">        
            <tr>            
                <td class="content" style="padding-left: 0px; width: 66.66%">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="ltrMainHeader" runat="server"></asp:Literal>
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
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                        <tr>
                                            <td colspan="6">
                                                <%if (IsMessage)
                                                  { %>
                                                  <div class="message finalsuccess">
                                                    <p>
                                                        <strong>
                                                            <asp:Label ID="lblErrorMessage" runat="server"></asp:Label></strong>
                                                    </p>
                                                </div>
                                                <%}%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100px">
                                                <asp:Literal ID="ltrPropertyName" runat="server"></asp:Literal>
                                            </td>
                                            <td width="220px">
                                                <asp:TextBox ID="txtPropertyName" runat="server" SkinID="searchtextbox" MaxLength="65"></asp:TextBox>
                                            </td>
                                            <td width="90px">
                                                <asp:Literal ID="ltrPropertyType" runat="server"></asp:Literal>
                                            </td>
                                            <td width="220px">
                                                <asp:DropDownList ID="ddlPropertyType" SkinID="searchddl" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="70px">
                                                <asp:Literal ID="ltrLocation" runat="server"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLocation" runat="server" SkinID="searchtextbox" MaxLength="65"></asp:TextBox>
                                                <asp:ImageButton ID="btnSearch" Style="border: 0px; vertical-align: middle; margin: -4px 0 0 5px;"
                                                    runat="server" ImageUrl="~/images/search-icon.png" OnClick="btnSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                                <asp:ImageButton ID="imgbtnClearSearch" runat="server" ImageUrl="~/images/clearsearch.png"
                                                    Style="border: 0px; vertical-align: middle; margin: -2px 0 0 10px;" OnClick="imgbtnClearSearch_Click" OnClientClick="fnDisplayCatchErrorMessage()" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" align="right" valign="middle">
                                                <asp:Button ID="btnAddTop" runat="server" Visible="false" OnClick="btnAdd_Click" Style="float: right;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <div class="box_head">
                                                    <span>
                                                        <asp:Literal ID="litPropertyList" runat="server"></asp:Literal></span></div>
                                                <div class="clear">
                                                </div>
                                                <div class="box_content">
                                                    <asp:GridView ID="grdPropertyList" runat="server" AutoGenerateColumns="False" Width="100%"
                                                        OnPageIndexChanging="grdPropertyList_OnPageIndexChanging" CssClass="grid_content"
                                                        OnRowDataBound="grdPropertyList_RowDataBound" OnRowCommand="grdPropertyList_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="30px">
                                                                <HeaderTemplate>
                                                                    <asp:Literal ID="litGvfNo" runat="server"></asp:Literal>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrPropertyName" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkbtnUnitInfo" Text='<%#DataBinder.Eval(Container.DataItem, "PropertyName")%>'
                                                                        runat="server" CommandName="UNITINFO" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PropertyID")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="110px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrPropertyType" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPropertyType" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ProperyType")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="110px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrLocation" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCity" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CityName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrSBA" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCarpetArea" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Carpetarea")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrBlocks" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkbtnWingCount" Text='<%#DataBinder.Eval(Container.DataItem, "WingCount")%>'
                                                                        runat="server" CommandName="TOTALWING" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PropertyID")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrFloors" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkbtnFloorCount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FloorCount")%>'
                                                                        CommandName="TOTALFLOOR" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PropertyID")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrUnitTypes" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkbtnUnitTypes" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "UnitTypesCount")%>'
                                                                        CommandName="TOTALUNITTYPES" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PropertyID")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrUnits" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkbtnUnits" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "UnitsCount")%>'
                                                                        CommandName="TOTALUNIT" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PropertyID")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrHotelLicenceNumber" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblHotelLicenceNumber" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "LicenceNo")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="85px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblGvHdrView" runat="server" Text="Property Info."></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PropertyID")%>' CommandName="VIEWPROPERTYDATA" Text="View"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrEditView" runat="server"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/file.png" CommandName="EDITDATA"
                                                                        Style="border: 0px; vertical-align: middle;" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PropertyID")%>' />
                                                                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="../../images/delete.png"
                                                                        Style="border: 0px; vertical-align: middle;" CommandName="DELETEDATA" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "PropertyID")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div style="padding:10px;">
                                                                <h2>
                                                                    <asp:Label ID="lblNoRecordFound" runat="server"></asp:Label></h2>
                                                            </div>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" align="right" valign="middle">
                                                <asp:Button ID="btnAdd" runat="server" Visible="false" OnClick="btnAdd_Click" Style="float: right;" />
                                            </td>
                                        </tr>
                                    </table>
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
                    <%--<div class="clear">
                        <uc1:MsgBox ID="MessageBox" runat="server" />
                    </div>--%>
                </td>
            </tr>
        </table>
        <!-- Delete Popup Box-->
        <ajx:ModalPopupExtender ID="DeletePropertyData" runat="server" TargetControlID="hdnPropertyData"
            PopupControlID="pnlPropertyData" BackgroundCssClass="mod_background" CancelControlID="btnNo">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnPropertyData" runat="server" />
        <asp:Panel ID="pnlPropertyData" runat="server" Height="350px" Width="325px" style="display:none;">
            <div class="box_col1">
                <div class="box_head">
                    <span>
                        <asp:Literal ID="litPropertyDataHeader" runat="server"></asp:Literal></span></div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td align="center" style="padding-bottom: 15px;">
                                <asp:Literal ID="litPropertyDataMsg" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnYes" runat="server" Style="display: inline; padding-right: 10px;"
                                   OnClick="btnYes_Click" OnClientClick="fnDisplayCatchErrorMessage();" />
                                <asp:Button ID="btnNo" runat="server" Style="display: inline;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <!-- End Delete Popup Box-->
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
