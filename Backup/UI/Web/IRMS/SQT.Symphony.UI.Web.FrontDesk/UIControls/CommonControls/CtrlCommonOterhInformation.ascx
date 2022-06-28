<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlCommonOterhInformation.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrlCommonOterhInformation" %>
<div class="box_col1">
    <div class="box_head">
        <span>
            <asp:Literal ID="litOtherInformation" runat="server" Text="Other Information"></asp:Literal></span></div>
    <div class="clear">
    </div>
    <div class="box_form">
        <table cellpadding="2" cellspacing="2" border="0" width="100%">
            <tr>
                <td>
                    <fieldset style="border: 1px solid #ccc !important;">
                        <legend>
                            <asp:Literal ID="litGeneral" Text="General" runat="server"></asp:Literal>
                        </legend>
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td width="100px">
                                    <asp:Literal ID="litVIPType" runat="server" Text="VIP Type"></asp:Literal>
                                </td>
                                <td width="190px">
                                    <asp:DropDownList ID="ddlVIPType" runat="server" Style="width: 150px !important;">
                                        <asp:ListItem Selected="True" Value="-Select-" Text="-Select-"></asp:ListItem>
                                        <asp:ListItem Text="Free" Value="Free"></asp:ListItem>
                                        <asp:ListItem Text="VIP" Value="VIP"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Literal ID="litSourceOfBusiness" runat="server" Text="Source Of Business"></asp:Literal>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSourceOfBusiness" runat="server" Style="width: 150px !important;">
                                        <asp:ListItem Selected="True" Value="-Select-" Text="-Select-"></asp:ListItem>
                                        <asp:ListItem Text="Television" Value="Television"></asp:ListItem>
                                        <asp:ListItem Text="Web" Value="Web"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="litReasonForStay" runat="server" Text="Reason For Stay"></asp:Literal>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlReasonForStay" runat="server" Style="width: 150px !important;">
                                        <asp:ListItem Selected="True" Value="-Select-" Text="-Select-"></asp:ListItem>
                                        <asp:ListItem Text="Business" Value="Business"></asp:ListItem>
                                        <asp:ListItem Text="Vacation" Value="Vacation"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td colspan="2">
                                    <asp:CheckBox ID="chkDoNotMove" runat="server" Text="Do Not Move" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset style="border: 1px solid #ccc !important;">
                        <legend>
                            <asp:Literal ID="litReservationNotes" Text="Reservation Notes" runat="server"></asp:Literal>
                        </legend>
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtReservationNotes" runat="server" style="width:600px !important;" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset style="border: 1px solid #ccc !important;">
                        <legend>
                            <asp:Literal ID="litHouseKeepingNotes" Text="HouseKeeping Notes" runat="server"></asp:Literal>
                        </legend>
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtHouseKeepingNotes" runat="server" style="width:600px !important;" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset style="border: 1px solid #ccc !important;">
                        <legend>
                            <asp:Literal ID="litAccountNotes" Text="Account Notes" runat="server"></asp:Literal>
                        </legend>
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtAccountNotes" runat="server" style="width:600px !important;" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset style="border: 1px solid #ccc !important;">
                        <legend>
                            <asp:Literal ID="litGeneralNotes" Text="General Notes" runat="server"></asp:Literal>
                        </legend>
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtGeneralNotes" runat="server" style="width:600px !important;" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset style="border: 1px solid #ccc !important;">
                        <legend>
                            <asp:Literal ID="litOtherNotes" Text="Other Notes" runat="server"></asp:Literal>
                        </legend>
                        <table cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtOtherNotes" runat="server" style="width:600px !important;" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnOtherInfoSave" runat="server" Text="Save" Style="display: inline;" />
                    <asp:Button ID="btnOtherInfoCancel" runat="server" Text="Cancel" Style="display: inline;" />
                </td>
            </tr>
        </table>
    </div>
    <div class="clear">
    </div>
</div>
