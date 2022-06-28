<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation.RegistrationForm" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link id="Link1" href="~/Styles/style.css" runat="server" rel="stylesheet" type="text/css" />
    <style type="text/css">
        h1, p
        {
            font-weight: normal;
            font-size: 13px;
            margin: 0px;
            padding: 0px;
            color: Black;
        }
    </style>
    <script type="text/javascript">
        function fnPrint() {
            document.getElementById('dvToHide').style.display = 'none';
            window.print();
            window.close();
        }
        function fnDisplayCatchErrorMessage() {
            document.getElementById('errormessage').style.display = "block";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="srcptRegistrationForm" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <div style="width: 800px; margin: 0; height: 60px; text-align: center;">
        <img src="<%=Page.ResolveUrl("~/images/Logo - registerd_small.jpg") %>" style="width: 175px;
            height: 54px" border="0" alt="" />
    </div>
    <div style="text-align: center; width: 800px;">
        <asp:Label runat="server" ID="lblPropertyaddress"></asp:Label></div>
    <div class="box_form">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr style="height:30px;">
                            <td colspan="5" style="border-bottom:solid 1px black;">
                                <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 75px;">
                                            <asp:Literal ID="litDate" runat="server" Text="Date"></asp:Literal>
                                        </td>
                                        <td style="width: 240px;">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="padding: 0px;">
                                                        <span style="font-size: x-small;">Date</span>
                                                        <br />
                                                        <asp:TextBox ID="TextBox12" Enabled="false" runat="server" Style="width: 40px !important; height:15px;"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <span style="font-size: x-small;">Month</span>
                                                        <br />
                                                        <asp:TextBox ID="TextBox13" Enabled="false" runat="server" Style="width: 40px !important; height:15px;"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <span style="font-size: x-small;">Year</span>
                                                        <br />
                                                        <asp:TextBox ID="TextBox14" Enabled="false" runat="server" Style="width: 80px !important; height:15px;"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 225px;">
                                            <b>Registration Form</b>
                                        </td>
                                        <td>
                                            <asp:Literal ID="litBooking" runat="server" Text="Booking#"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox15" Enabled="false" runat="server" Style="width: 80px !important; height:15px;"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <%--<tr>
                            <td colspan="5" style="width: 780px;">
                                <hr />
                            </td>
                        </tr>--%>
                        <tr>
                            <td style="width: 100px;">
                                &nbsp;<br />
                                <asp:Literal ID="litFormName" runat="server" Text="Name"></asp:Literal>
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="padding: 0px;">
                                            &nbsp;
                                            <br />
                                            <asp:TextBox ID="txtFormTitle" Enabled="false" runat="server" Style="width: 35px !important;height:15px;
                                                margin-top: -3px;"></asp:TextBox>
                                        </td>
                                        <td>
                                            <span style="font-size: x-small;">First Name</span>
                                            <br />
                                            <asp:TextBox ID="txtFormFirstName" Style="width: 110px;height:15px;" Enabled="false" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <span style="font-size: x-small;">Last Name</span>
                                            <br />
                                            <asp:TextBox ID="txtFormLastName" Style="width: 110px;height:15px;" Enabled="false" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 180px;">
                                &nbsp;<br />
                                <asp:Literal ID="litFormBirthDate" runat="server" Text="Date of Birth"></asp:Literal>
                            </td>
                            <td style="width: 180px;">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="padding: 0px;">
                                            <span style="font-size: x-small;">Date</span>
                                            <br />
                                            <asp:TextBox ID="TextBox2" Enabled="false" runat="server" Style="width: 40px !important;height:15px;"></asp:TextBox>
                                        </td>
                                        <td>
                                            <span style="font-size: x-small;">Month</span>
                                            <br />
                                            <asp:TextBox ID="TextBox3" Enabled="false" runat="server" Style="width: 40px !important;height:15px;"></asp:TextBox>
                                        </td>
                                        <td>
                                            <span style="font-size: x-small;">Year</span>
                                            <br />
                                            <asp:TextBox ID="TextBox4" Enabled="false" runat="server" Style="width: 80px !important;height:15px;"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litFormArrivalDate" runat="server" Text="Arrival Date"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFormArrivalDate" Enabled="false" runat="server" style="height:15px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Literal ID="litFormDepatureDate" runat="server" Text="Departure Date"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFormDepatureDate" Enabled="false" Style="width: 175px;height:15px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litRoomType" runat="server" Text="Room Type"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRoomType" Enabled="false" runat="server" style="height:15px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Literal ID="litRatecard" runat="server" Text="Rate Card"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRateCard" Enabled="false" Style="width: 175px;height:15px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litFormMobileNo" Text="Mobile No." runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFormCode" Enabled="false" Style="width: 35px !important;height:15px;" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtFormMobileNo" Enabled="false" runat="server" style="height:15px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Literal ID="litFormEmail" runat="server" Text="Email ID"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFormEmail" Style="width: 175px;height:15px;" Enabled="false" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litFormNationality" runat="server" Text="Nationality"></asp:Literal>
                            </td>
                            <td style="padding: 0px;">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="padding: 0px;">
                                            <asp:CheckBoxList ID="chklistFormNationality" Enabled="false" CellPadding="0" CellSpacing="0"
                                                runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Indian" Value="Indian"></asp:ListItem>
                                                <asp:ListItem Text="Other" Value="Foreign National"></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </td>
                                        <td style="padding-left: 10px;">
                                            <asp:TextBox ID="TextBox5" Enabled="false" Style="display: inline; width: 145px; height:15px;"
                                                runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Literal ID="litFormIDDocument" runat="server" Text="ID Document"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFormIDDoument" Style="width: 175px;height:15px;" Enabled="false" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litFormAddress" runat="server" Text="Address"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFormAddress1" Enabled="false" runat="server" style="height:15px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Literal ID="litFormIDDocumentNo" runat="server" Text="ID Document No"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFormIDDocumentNo" Style="width: 175px;height:15px;" Enabled="false" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFormAddress2" Enabled="false" runat="server" style="height:15px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Literal ID="litFormBloodGroup" runat="server" Text="Blood Group"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFormBloodGroup" Enabled="false" runat="server" Style="width: 40px !important;height:15px;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litFormCompany" runat="server" Text="Company"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFormCompany" Enabled="false" runat="server" style="height:15px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Literal ID="Literal4" runat="server" Text="Job Title"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox1" Style="width: 175px; height:15px;" Enabled="false" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litFormWorkTime" runat="server" Text="Work Timing"></asp:Literal>
                            </td>
                            <td style="padding: 0px;">
                                <asp:CheckBoxList ID="chklistFormWorkTime" Enabled="false" CellPadding="0" CellSpacing="0"
                                    runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Day shift" Value="Day shift"></asp:ListItem>
                                    <asp:ListItem Text="Night shift" Value="Night shift"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                            <td>
                                <asp:Literal ID="Literal5" runat="server" Text="Location"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox7" Enabled="false" Style="width: 175px; height:15px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Sector
                            </td>
                            <td style="padding: 0px;">
                                <asp:CheckBoxList ID="CheckBoxList1" Enabled="false" runat="server" CellPadding="0"
                                    CellSpacing="0" RepeatDirection="Horizontal" Style="display: inline;">
                                    <asp:ListItem Text="IT" Value="Err"></asp:ListItem>
                                    <asp:ListItem Text="BPO" Value="Err"></asp:ListItem>
                                    <asp:ListItem Text="Biotechnology" Value="Err"></asp:ListItem>
                                    <asp:ListItem Text="Manufactur" Value="Err"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkOtherSector" Enabled="false" runat="server" Text="Other" CellPadding="0"
                                    CellSpacing="0" />
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox6" Enabled="false" Style="width: 175px; height:15px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litFormMeal" runat="server" Text="Meal"></asp:Literal>
                            </td>
                            <td style="padding: 0px;">
                                <asp:CheckBoxList ID="chklistMeal" Enabled="false" runat="server" CellPadding="0"
                                    CellSpacing="0" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Veg." Value="Veg."></asp:ListItem>
                                    <asp:ListItem Text="Non Veg." Value="Non Veg."></asp:ListItem>
                                    <asp:ListItem Text="Egg." Value="Err"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                            <td>
                                <asp:Literal ID="litFormSmoking" runat="server" Text="Smoking"></asp:Literal>
                            </td>
                            <td style="padding: 0px;">
                                <asp:CheckBoxList ID="chklistFormSmoking" Enabled="false" CellPadding="0" CellSpacing="0"
                                    runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litParentName" runat="server" Text="Parent Name"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtParentName" Enabled="false" runat="server" style="height:15px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Literal ID="litParentContctNo" runat="server" Text="Parent Contact No."></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtParentContactNo" Enabled="false" Style="width: 175px; height:15px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litLocalContact" runat="server" Text="Local Contact"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLocalContaact" Enabled="false" runat="server" style="height:15px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Literal ID="litLocalContactNo" runat="server" Text="Local Contact No."></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtLocalContaactNo" Enabled="false" Style="width: 175px;height:15px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litPax" runat="server" Text="Pax"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPax" Enabled="false" runat="server" style="height:15px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Literal ID="litBookerContactNo" runat="server" Text="Booker Contact No"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox11" Enabled="false" Style="width: 175px; height:15px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litspInstruction" runat="server" Text="Instruction"></asp:Literal>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtspInstruction" Enabled="false" runat="server" Style="width: 100%; height:15px;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <b>For Foreign Nationals Only</b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litPassportNo" runat="server" Text="Passport No."></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassportNo" Enabled="false" runat="server" style="height:15px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Literal ID="litVisaNo" runat="server" Text="Visa No."></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtVisaNo" Enabled="false" Style="width: 175px; height:15px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litPassportDateOfIssue" runat="server" Text="Date Of Issue"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassportDateOfIssue" Enabled="false" runat="server" style="height:15px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Literal ID="litVisaDateOfIssue" runat="server" Text="Date Of Issue"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtVisaDateOfIssue" Enabled="false" Style="width: 175px; height:15px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litPassportDateOfExpiry" runat="server" Text="Date Of Expiry"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassportDateOfExpiry" Enabled="false" runat="server" style="height:15px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Literal ID="litVisaDateOfExpiry" runat="server" Text="Date Of Expiry"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtVisaDateOfExpiry" Enabled="false" Style="width: 175px; height:15px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litPassportPlaceOfIssue" runat="server" Text="Place Of Issue"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassportPlaceOfIssue" Enabled="false" runat="server" style="height:15px;"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Literal ID="litVisaPlaceOfIssue" runat="server" Text="Place Of Issue"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtVisaPlaceOfIssue" Enabled="false" Style="width: 175px; height:15px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Literal ID="litVisaType" runat="server" Text="Visa Type"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtVisaType" Enabled="false" runat="server" Style="width: 175px;height:15px;"></asp:TextBox>
                            </td>
                        </tr>
                        <%--<tr>
                            <td colspan="5" style="width: 780px;">
                                <hr />
                            </td>
                        </tr>--%>
                        <%--<tr>
                            <td align="center" colspan="5" style="width: 780px;">
                                <asp:Literal ID="litFormRules" runat="server" Text="UNIWORLD HOUSING RULES"></asp:Literal>
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="5" style="width: 780px; border-top:solid 1px black;">
                                <asp:Label ID="lblHousingRules" Font-Size="Small" runat="server"></asp:Label>
                                <%--<asp:Label ID="lblHousingRules" Style="font-weight: normal; color: black;" runat="server"></asp:Label>--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" style="width: 780px;">
                                <br />
                                ______________________________
                                <br />
                                <asp:Label ID="lblGuestSign" runat="server" Text="Resident / Guest Signature" Font-Size="Smaller"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" align="center">
                                <div id="dvToHide">
                                    <asp:Button ID="btnCancelPritnRegFrom" runat="server" Text="Print" OnClientClick="fnPrint();" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id="errormessage" class="clear">
        <uc1:MsgBox ID="MessageBox" runat="server" />
    </div>
    </form>
</body>
</html>
