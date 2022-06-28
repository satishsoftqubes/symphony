<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrGuestProfile.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls.CtrGuestProfile" %>
<%@ Register Src="~/UIControls/CommonControls/CtrlCommonGuestHistory.ascx" TagName="GuestHistory"
    TagPrefix="ucCtrlGuestHistory" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<link type="text/css" href="../../Styles/jquery-ui-1.8.5.custom.css" rel="stylesheet" />
<script type="text/javascript" src="../../Scripts/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-ui-1.8.5.custom.min.js"></script>
<script type="text/javascript">
    function pageLoad(sender, args) {
        var v1 = '<%=ConfigurationManager.AppSettings["IsUpperCase"].ToString() %>'
        if (v1 == "1") {
            $('input[type="text"],textarea').each(function () { $(this).css("text-transform", "uppercase") });
        }

        $("#tabs").tabs();

        $('#tabs').tabs({
            select: function (event, ui) {
                window.location.hash = ui.tab.hash;
            }
        });

    }
</script>
<script type="text/javascript">
    function fnClearDate(Date) {
        document.getElementById(Date).value = "";
    }
    function fnDisplayCatchErrorMessage() {
        document.getElementById('errormessage').style.display = "block";
    }
</script>
<asp:UpdatePanel ID="updGuestProfile" runat="server">
    <ContentTemplate>
        <asp:MultiView ID="mvGuestProfile" runat="server">
            <asp:View ID="vguestprofile" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="content" style="padding-left: 0px; width: 66.66%">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="boxtopleft">
                                        &nbsp;
                                    </td>
                                    <td class="boxtopcenter">
                                        <asp:Literal ID="litMainHeaderGuestProfile" runat="server" Text="Guest History"></asp:Literal>
                                    </td>
                                    <td class="boxtopright">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="boxleft">
                                    </td>
                                    <td align="left">
                                        <div class="box_form">
                                            <%if (IsMessage)
                                              { %>
                                            <div class="ResetSuccessfully">
                                                <div style="float: left; padding-top: 7px; width: 25px; height: 24px; margin-right: 10px;">
                                                    <img src="../../images/success.png" />
                                                </div>
                                                <div>
                                                    <asp:Label ID="lblFeedbackMsg" runat="server"></asp:Label></div>
                                                <div style="height: 10px;">
                                                </div>
                                            </div>
                                            <% }%>
                                            <div class="demo">
                                                <div id="tabs">
                                                    <ul>
                                                        <li><a href="#tabs-1" onclick="fnChangeValue('1015.00');">
                                                            <asp:Literal ID="littabProfile" runat="server" Text="Profile"></asp:Literal></a></li>
                                                        <li><a href="#tabs-2" onclick="fnChangeValue('200.00');">
                                                            <asp:Literal ID="littabStayHistory" runat="server" Text="Stay History"></asp:Literal></a></li>
                                                        <li><a href="#tabs-3" onclick="fnChangeValue('1000.00');">
                                                            <asp:Literal ID="littabPreference" runat="server" Text="Preference"></asp:Literal></a></li>
                                                        <li><a href="#tabs-4" onclick="fnChangeValue('1015.00');">
                                                            <asp:Literal ID="littabCashcardInfo" runat="server" Text="Cashcard Info."></asp:Literal></a></li>
                                                    </ul>
                                                    <div id="tabs-1">
                                                        <table width="100%" cellpadding="2" cellspacing="2">
                                                            <tr>
                                                                <td width="50%" style="vertical-align: top; border-right: 1px solid #ccccce;">
                                                                    <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td colspan="3">
                                                                                <b>Guest Info.</b>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="90px">
                                                                                <asp:Literal ID="litGuestNationality" runat="server" Text="Nationality"></asp:Literal>
                                                                            </td>
                                                                            <td colspan="2">
                                                                                <asp:DropDownList ID="ddlNationality" AutoPostBack="true" OnSelectedIndexChanged="ddlNationality_selectedindexchanged"
                                                                                    runat="server" Style="width: 165px;">
                                                                                </asp:DropDownList>
                                                                                <asp:LinkButton ID="linkForeignNationalpopup" Visible="false" runat="server" ForeColor="#0067a4"
                                                                                    Text="Foreign National Info" OnClick="linkForeignNationalpopup_Click"></asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litGuestName" runat="server" Text="Name"></asp:Literal>
                                                                            </td>
                                                                            <td colspan="2" class="isrequire">
                                                                                <asp:DropDownList ID="ddlTitel" runat="server" Style="width: 60px;">
                                                                                    <asp:ListItem Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                    <asp:ListItem Selected="True" Text="Mr." Value="Mr."></asp:ListItem>
                                                                                    <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                                                                                    <asp:ListItem Text="Ms" Value="Ms"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvTitel" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                        ValidationGroup="IsRequire" ControlToValidate="ddlTitel" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                </span>
                                                                                <asp:TextBox ID="txtGuestFirstName" Text="Anant" runat="server" Style="width: 120px;"></asp:TextBox><ajx:TextBoxWatermarkExtender
                                                                                    ID="txtwmeFirstName" runat="server" TargetControlID="txtGuestFirstName" WatermarkText="First Name">
                                                                                </ajx:TextBoxWatermarkExtender>
                                                                                <span>
                                                                                    <asp:RequiredFieldValidator ID="rfvGuestFirstName" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                        runat="server" ValidationGroup="IsRequire" ControlToValidate="txtGuestFirstName"
                                                                                        Display="Dynamic">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </span>
                                                                                <asp:TextBox ID="txtGuestLastName" Text="Aahuja" runat="server" Style="width: 120px;"></asp:TextBox><ajx:TextBoxWatermarkExtender
                                                                                    ID="txtwmeLastName" runat="server" TargetControlID="txtGuestLastName" WatermarkText="Last Name">
                                                                                </ajx:TextBoxWatermarkExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litGuestContact" runat="server" Text="Mobile No."></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCode" Style="width: 30px !important;" runat="server"></asp:TextBox>
                                                                                <ajx:FilteredTextBoxExtender ID="ftCountryMobileCode" runat="server" TargetControlID="txtCode"
                                                                                    ValidChars="+0123456789" FilterMode="ValidChars">
                                                                                </ajx:FilteredTextBoxExtender>
                                                                                <asp:TextBox ID="txtGuestContact" Text="7894560123" Style="width: 190px !important;"
                                                                                    runat="server"></asp:TextBox>
                                                                                <ajx:FilteredTextBoxExtender ID="ftMobile" runat="server" TargetControlID="txtGuestContact"
                                                                                    ValidChars="0123456789" FilterMode="ValidChars">
                                                                                </ajx:FilteredTextBoxExtender>
                                                                                <asp:RegularExpressionValidator ID="regMobileNo" Display="Dynamic" runat="server"
                                                                                    ControlToValidate="txtGuestContact" ErrorMessage="Mobile No. must be 10 digits."
                                                                                    ValidationGroup="IsRequire" ForeColor="Red" ValidationExpression="^[0-9]{10}"></asp:RegularExpressionValidator>
                                                                            </td>
                                                                            <td rowspan="2" style="vertical-align: top;">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litGuestEmail" runat="server" Text="E-Mail"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtGuestEmail" runat="server" Text="scsa@yahoo.com"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="revGuestEmail" Display="Dynamic" ValidationGroup="IsRequire"
                                                                                    runat="server" ErrorMessage="Please Enter Valid Email" ForeColor="Red" ControlToValidate="txtGuestEmail"
                                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                            </td>
                                                                            <td rowspan="2" style="vertical-align: top;">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litGuestAddress" runat="server" Text="Address"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtGuestAddress1" Text="30, Shri Shaishav Colony" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtGuestAddress2" Text="Jalnagar road, Ahmedabad-658556" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litGuestCity" runat="server" Text="City"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtGuestCity" Text="Ahmedabad" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            <td rowspan="5" align="center" style="vertical-align: top;">
                                                                                <div style="border: 1px solid Gray;">
                                                                                    <asp:Image ID="imgPhoto" runat="server" Width="140" Height="150" ImageUrl="~/images/UserBlankPhoto.jpg" />
                                                                                </div>
                                                                                <br />
                                                                                <asp:LinkButton ID="LnkGuestPhotoRemove" Visible="false" runat="server">Remove</asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litGuestZipCode" runat="server" Text="Zip Code"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtGuestZipCode" Text="658556" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litGuestState" runat="server" Text="State"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtGuestState" runat="server" Text="Gujarat"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litGuestCountry" runat="server" Text="Country"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCountry" Text="India" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="isrequire">
                                                                                <asp:Literal ID="litGuestPhoto" runat="server" Text="Photo"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <div class="browse_file_grid_test">
                                                                                    <asp:FileUpload ID="fuGuestPhoto" runat="server" /></div>
                                                                                <%--<asp:RequiredFieldValidator ID="rfvGuestPhoto" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                            runat="server" ValidationGroup="IsRequire" ControlToValidate="fuGuestPhoto" Display="Dynamic">
                                                                        </asp:RequiredFieldValidator>--%>
                                                                                <asp:RegularExpressionValidator ID="revGuestPhoto" runat="server" ControlToValidate="fuGuestPhoto"
                                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"
                                                                                    Display="Dynamic" ValidationExpression="^.+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|.gif|.GIF|.bmp|.BMP)$"></asp:RegularExpressionValidator>
                                                                                <a id="aViewGuestPhoto" runat="server" target="_blank" visible="false">
                                                                                    <img src="../../images/View.png" width="17px" alt="view photo" height="17px" /></a>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litGuestType" runat="server" Text="Guest Type"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlGuestType" runat="server">
                                                                                    <asp:ListItem Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                    <asp:ListItem Selected="True" Text="VIP" Value="Mr."></asp:ListItem>
                                                                                    <asp:ListItem Text="VVIP" Value="Mrs."></asp:ListItem>
                                                                                    <asp:ListItem Text="Celebrity" Value="Ms"></asp:ListItem>
                                                                                    <asp:ListItem Text="Black List" Value="Ms"></asp:ListItem>
                                                                                    <asp:ListItem Text="Other" Value="Ms"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="vertical-align: top;">
                                                                    <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <b>Guest Identification</b>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="110px">
                                                                                <asp:Literal ID="litGuestIDDocument" runat="server" Text="ID Document 1"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlGuestIDDocument" runat="server">
                                                                                    <asp:ListItem Selected="True" Text="-SELECT-"></asp:ListItem>
                                                                                    <asp:ListItem Text="PassPort" Value="PassPort"></asp:ListItem>
                                                                                    <asp:ListItem Text="License" Value="License"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvDocument1" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="ddlGuestIDDocument"
                                                                                    InitialValue="00000000-0000-0000-0000-000000000000" Display="Dynamic">
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litIDReferenceNo" runat="server" Text="Reference No."></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtIDRefNo" runat="server"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvDocRefNo1" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="txtIDRefNo" Display="Dynamic">
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litIDScancopy" runat="server" Text="Upload Document"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <div class="browse_file_grid_test">
                                                                                    <asp:FileUpload ID="fuIDScanCopy" runat="server" />
                                                                                </div>
                                                                                <%--<asp:RequiredFieldValidator ID="rfvIDScanCopy" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                                                                    runat="server" ValidationGroup="IsRequire" ControlToValidate="fuIDScanCopy" Display="Dynamic">
                                                                                </asp:RequiredFieldValidator>--%>
                                                                                <asp:RegularExpressionValidator ID="regGuestPhotoExtention" runat="server" ControlToValidate="fuIDScanCopy"
                                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"
                                                                                    Display="Dynamic" ValidationExpression="^.+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|.gif|.GIF|.bmp|.BMP)$"></asp:RegularExpressionValidator>
                                                                                <a id="aViewGuestDoc1" runat="server" target="_blank" visible="false">
                                                                                    <img src="../../images/View.png" width="17px" alt="view photo" height="17px" /></a>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litGuestIDDocument2" runat="server" Text="ID Document 2"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlGuestIDDocument2" runat="server">
                                                                                    <asp:ListItem Selected="True" Text="-SELECT-"></asp:ListItem>
                                                                                    <asp:ListItem Text="PassPort" Value="PassPort"></asp:ListItem>
                                                                                    <asp:ListItem Text="License" Value="License"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="litIDRefNo2" runat="server" Text="Reference No."></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtIDRefNo2" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="Literal2" runat="server" Text="Upload Document"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <div class="browse_file_grid_test">
                                                                                    <asp:FileUpload ID="fuIDDocument2" runat="server" />
                                                                                </div>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fuIDDocument2"
                                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" ValidationGroup="IsRequire"
                                                                                    Display="Dynamic" ValidationExpression="^.+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|.gif|.GIF|.bmp|.BMP)$"></asp:RegularExpressionValidator>
                                                                                <%--<asp:LinkButton ID="lnkViewDoc2" OnClick="lnkViewDoc2_OnClick" Visible="false" runat="server"> <img src="../../images/View.png" width="17px" alt="view photo" height="17px" /></asp:LinkButton>--%>
                                                                                <a id="aViewGuestDoc2" runat="server" target="_blank" visible="false">
                                                                                    <img src="../../images/View.png" width="17px" alt="view photo" height="17px" /></a>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding-top: 5px; padding-bottom: 0px;" colspan="2">
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Parent Name
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtParentName" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Parent Contact
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtGaurdianNumber" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Local Guardian
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtLocalContactPerson" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Guardian Contact
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtLocalContactNumber" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <b>Other Info.</b>
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="vertical-align: top; border-right: 1px solid #ccccce; font-size: 13px;">
                                                                    <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td width="110px" class="isrequire">
                                                                                <asp:Literal ID="litGuestDateOfBirth" runat="server" Text="Date of Birth"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlDOBDate" runat="server" Style="width: 80px; height: 25px;">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvDOBDate" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlDOBDate" Display="Dynamic">
                                                                                </asp:RequiredFieldValidator>
                                                                                <asp:DropDownList ID="ddlDOBMonth" runat="server" Style="width: 95px; height: 25px;">
                                                                                    <asp:ListItem Text="-MONTH-" Value="00000000-0000-0000-0000-000000000000" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                                                                                    <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                                                                                    <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                                                                                    <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                                                                    <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                                                                                    <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                                                                                    <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                                                                                    <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                                                                                    <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                                                                    <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                                                                    <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvDOBMonth" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlDOBMonth" Display="Dynamic">
                                                                                </asp:RequiredFieldValidator>
                                                                                <asp:DropDownList ID="ddlDOBYear" runat="server" Style="width: 80px; height: 25px;">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvDOBYear" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                                    ValidationGroup="IsRequire" ControlToValidate="ddlDOBYear" Display="Dynamic">
                                                                                </asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="display: none;">
                                                                            <td>
                                                                                <asp:Literal ID="litGuestAnniversary" runat="server" Text="Anniversary"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtGuestAnniversary" onkeypress="return false;" runat="server" Style="width: 180px !important;"></asp:TextBox>
                                                                                <asp:Image ID="imgGuestAnniversary" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                                                                    Height="20px" Width="20px" />
                                                                                <ajx:CalendarExtender ID="calGuestAnniversary" PopupButtonID="imgGuestAnniversary"
                                                                                    TargetControlID="txtGuestAnniversary" runat="server" Format="dd-MM-yyyy">
                                                                                </ajx:CalendarExtender>
                                                                                <img src="../../images/clear.png" id="img1" style="vertical-align: middle;" title="Clear Date"
                                                                                    onclick="fnClearDate('<%= txtGuestAnniversary.ClientID %>');" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="Literal4" runat="server" Text="Blood Group"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlBloodGroup" runat="server" Style="width: 95px; height: 25px;">
                                                                                    <asp:ListItem Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                    <asp:ListItem Text="A+" Value="01"></asp:ListItem>
                                                                                    <asp:ListItem Text="B+" Value="01"></asp:ListItem>
                                                                                    <asp:ListItem Text="AB+" Value="01"></asp:ListItem>
                                                                                    <asp:ListItem Text="O+" Value="01"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Literal ID="Literal3" runat="server" Text="Meal Preference"></asp:Literal>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlMealPreference" runat="server" Style="height: 25px;">
                                                                                    <asp:ListItem Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                    <asp:ListItem Text="Vegetarian" Value="01"></asp:ListItem>
                                                                                    <asp:ListItem Text="Non Vegetarian" Value="01"></asp:ListItem>
                                                                                    <asp:ListItem Text="Eggetarian" Value="01"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <%--<tr>
                                                            <td>
                                                                <asp:Literal ID="litGuestFavoriteRoom" runat="server" Text="Favourite Room"></asp:Literal>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtGuestFavoriteRoom" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="vertical-align: top;">
                                                                <asp:Literal ID="litGuestGuestNote" runat="server" Text="Guest Note"></asp:Literal>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtGuestGuestNote" runat="server" Width="325px" Height="50px" SkinID="nowidth"
                                                                    TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="vertical-align: top;">
                                                                <asp:Literal ID="litGuestOtherNote" runat="server" Text="Other Note"></asp:Literal>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtGuestOtherNote" runat="server" Width="325px" Height="50px" SkinID="nowidth"
                                                                    TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>--%>
                                                                    </table>
                                                                </td>
                                                                <td style="vertical-align: top;">
                                                                    <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                                                        <tr>
                                                                            <td width="110px">
                                                                                Company
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCompanyName" runat="server" Text="Accenture"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Job Title
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtJobTitle" runat="server" Text="Asst. Manager"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Department
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtDepartment" runat="server" MaxLength="150"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Employee ID
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtEmployeeID" runat="server" MaxLength="150"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Sector
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlCompanySector" runat="server" Style="width: 224px; height: 25px;">
                                                                                    <asp:ListItem Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                    <asp:ListItem Text="BPO" Value="Indian"></asp:ListItem>
                                                                                    <asp:ListItem Text="IT" Value="Indian" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Text="Biotechnology" Value="Indian"></asp:ListItem>
                                                                                    <asp:ListItem Text="Business" Value="Indian"></asp:ListItem>
                                                                                    <asp:ListItem Text="Other" Value="Indian"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Location
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtWorkLocation" runat="server" Text="E-City"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                Work Timing
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlWorkTiming" runat="server" Style="width: 224px; height: 25px;">
                                                                                    <asp:ListItem Text="-SELECT-" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
                                                                                    <asp:ListItem Text="Day" Value="Indian" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Text="Night" Value="Indian"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="padding: 0px;">
                                                                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                        <td width="250px" style="vertical-align: top; padding-top: 10px;">
                                                                                        </td>
                                                                                        <td style="vertical-align: top;">
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2" style="padding: 15px;">
                                                                    <asp:Button ID="btnGuestProfileSave" OnClick="btnGuestProfileSave_OnClick" runat="server"
                                                                        Text="Save" Style="display: inline;" ValidationGroup="IsRequire" />
                                                                    <asp:Button ID="btnGuestProfilePrint" runat="server" Text="Print" Visible="false"
                                                                        Style="display: inline;" />
                                                                    <asp:Button ID="btnGuestProfileCancel" OnClick="btnGuestProfileCancel_OnClick" runat="server"
                                                                        Text="Back To List" Style="display: inline;" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="tabs-2">
                                                        <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                                            <tr style="display: none;">
                                                                <td colspan="2" style="font-weight: bold; font-size: 13px; border: 1px solid #ccccce;">
                                                                    <div style="float: left; text-align: left;">
                                                                        <asp:Literal ID="litGuestHistoryName" runat="server"></asp:Literal>
                                                                    </div>
                                                                    <div style="float: right;">
                                                                        <asp:Literal ID="litGuestContactLable" runat="server" Text="Contact No."></asp:Literal>
                                                                        &nbsp;&nbsp;&nbsp;
                                                                        <asp:Literal ID="litGuestHistoryContactNo" runat="server"></asp:Literal>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr style="display: none;">
                                                                <td colspan="2">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <div class="box_head">
                                                                        <span>
                                                                            <asp:Literal ID="litStayHistoryList" runat="server" Text="Stay History"></asp:Literal>
                                                                        </span>
                                                                    </div>
                                                                    <div class="clear">
                                                                    </div>
                                                                    <div class="box_content">
                                                                        <asp:GridView ID="gvGuestHistory" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                            Width="100%" OnRowDataBound="gvGuestHistory_RowDataBound">
                                                                            <Columns>
                                                                                <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%# Container.DataItemIndex + 1 %>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrBookingNo" runat="server" Text="Booking #"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "ReservationNo")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrRoomCnf" runat="server" Text="Check In"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%--<%#DataBinder.Eval(Container.DataItem, "CheckInDate", "{0:dd-MM-yyyy}")%>--%>
                                                                                        <asp:Label ID="lblGvCheckInDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckInDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrCheckInDate" runat="server" Text="Check Out"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%--<%#DataBinder.Eval(Container.DataItem, "CheckOutDate", "{0:dd-MM-yyyy}")%>--%>
                                                                                        <asp:Label ID="lblGvCheckOutDate" runat="server" Text='<%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckOutDate")).ToString(clsSession.DateFormat)%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrCheckOutDate" runat="server" Text="Nights"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblGvNights" runat="server" Text='<%# Reservation_GetTotalDays(Eval("CheckInDate"),Eval("CheckOutDate")) %>'></asp:Label>
                                                                                        <%-- <%#DataBinder.Eval(Container.DataItem, "Nights")%>--%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrNights" runat="server" Text="Rate Card"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "RateCardName")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrRateCard" runat="server" Text="Room Type"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <%#DataBinder.Eval(Container.DataItem, "RoomTypeName")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrInvoiceAmt" runat="server" Text="Room No."></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblGvRoomNo" runat="server" Text='<%# GetFormatedRoomNumber(Eval("RoomNo")) %>'></asp:Label>
                                                                                        <%--<%#DataBinder.Eval(Container.DataItem, "RoomNo")%>--%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrStatus" runat="server" Text="Invoice Amt."></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblGvInvoiceAmount" runat="server"></asp:Label>
                                                                                        <%-- <%#DataBinder.Eval(Container.DataItem, "Amt")%>--%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                                    <HeaderTemplate>
                                                                                        <asp:Label ID="lblGvHdrFolioBalance" runat="server" Text="Folio Balance"></asp:Label>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        0.00
                                                                                        <%-- <%#DataBinder.Eval(Container.DataItem, "Amt")%>--%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <EmptyDataTemplate>
                                                                                <div style="padding: 10px;">
                                                                                    <b>
                                                                                        <asp:Label ID="lblNoRecordFound" Text="No Record Found." runat="server"></asp:Label>
                                                                                    </b>
                                                                                </div>
                                                                            </EmptyDataTemplate>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" align="center" style="padding-top: 15px;">
                                                                    <asp:Button ID="btnGuestHistoryPrint" runat="server" Visible="false" Text="Print"
                                                                        Style="display: inline;" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="tabs-3">
                                                        <table width="100%" border="0">
                                                            <tr>
                                                                <td width="50%" style="vertical-align: top;">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td style="padding: 0px;">
                                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <b>Guest Preferences</b>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Button ID="btnAddPreferences" runat="server" Text="Add" Height="24px" OnClick="btnAddPreferences_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div class="box_content">
                                                                                    <asp:GridView ID="gvGuestPreferences" runat="server" AutoGenerateColumns="false"
                                                                                        ShowHeader="true" Width="100%">
                                                                                        <Columns>
                                                                                            <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%# Container.DataItemIndex + 1 %>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrPreference" runat="server" Text="Preferences"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblGvPreference" runat="server" Text='<%#TruncateString(DataBinder.Eval(Container.DataItem, "Preference").ToString(), 35)%>'></asp:Label>
                                                                                                    <ajx:HoverMenuExtender ID="hmePreference" runat="server" TargetControlID="lblGvPreference"
                                                                                                        PopupControlID="pnlPreference" PopupPosition="Right">
                                                                                                    </ajx:HoverMenuExtender>
                                                                                                    <asp:Panel ID="pnlPreference" runat="server" Style="visibility: hidden; opacity: 100%"
                                                                                                        BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px">
                                                                                                        <table border="0" cellpadding="0" cellspacing="0" class="tooltip_hover_lettmenu_table">
                                                                                                            <tr>
                                                                                                                <td style="background-color: #FFFFF0">
                                                                                                                    <%#DataBinder.Eval(Container.DataItem, "Preference")%>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </asp:Panel>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <EmptyDataTemplate>
                                                                                            <div style="padding: 10px;">
                                                                                                <b>
                                                                                                    <asp:Label ID="lblNoRecordFound" Text="No Record Found." runat="server"></asp:Label>
                                                                                                </b>
                                                                                            </div>
                                                                                        </EmptyDataTemplate>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="border-left: 1px solid #CCCCCC;">
                                                                </td>
                                                                <td width="50%" style="vertical-align: top;">
                                                                    <table width="100%" style="vertical-align: top;">
                                                                        <tr>
                                                                            <td style="padding: 0px;">
                                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <b>Management Note</b>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Button ID="btnAddMgmtNote" runat="server" Text="Add" Height="24px" OnClick="btnAddMgmtNote_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div class="box_content">
                                                                                    <asp:GridView ID="gvFrontDesksNote" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                        Width="100%">
                                                                                        <Columns>
                                                                                            <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%# Container.DataItemIndex + 1 %>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrPreference" runat="server" Text="Notes"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblGvFrontDesksNote" runat="server" Text='<%#TruncateString(DataBinder.Eval(Container.DataItem, "Notes").ToString(), 25)%>'></asp:Label>
                                                                                                    <ajx:HoverMenuExtender ID="hmeFrontDesksNote" runat="server" TargetControlID="lblGvFrontDesksNote"
                                                                                                        PopupControlID="pnlFrontDesksNote" PopupPosition="Right">
                                                                                                    </ajx:HoverMenuExtender>
                                                                                                    <asp:Panel ID="pnlFrontDesksNote" runat="server" Style="visibility: hidden; opacity: 100%"
                                                                                                        BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px">
                                                                                                        <table border="0" cellpadding="0" cellspacing="0" class="tooltip_hover_lettmenu_table">
                                                                                                            <tr>
                                                                                                                <td style="background-color: #FFFFF0">
                                                                                                                    <%#DataBinder.Eval(Container.DataItem, "Notes")%>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </asp:Panel>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrPreference" runat="server" Text="Note By"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%#DataBinder.Eval(Container.DataItem, "UserDisplayName")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%#DataBinder.Eval(Container.DataItem, "NoteOn", "{0:dd-MM-yyyy}")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <EmptyDataTemplate>
                                                                                            <div style="padding: 10px;">
                                                                                                <b>
                                                                                                    <asp:Label ID="lblNoRecordFound" Text="No Record Found." runat="server"></asp:Label>
                                                                                                </b>
                                                                                            </div>
                                                                                        </EmptyDataTemplate>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="50%" style="vertical-align: top;">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td style="padding: 0px;">
                                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <b>Feedback</b>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Button ID="btnAddFeedBack" runat="server" Text="Add" Height="24px" OnClick="btnAddFeedBack_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div class="box_content">
                                                                                    <asp:GridView ID="gvFeedbacks" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                        Width="100%">
                                                                                        <Columns>
                                                                                            <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%# Container.DataItemIndex + 1 %>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrFeedback" runat="server" Text="Feedback"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblgvFeedbacks" runat="server" Text='<%#TruncateString(DataBinder.Eval(Container.DataItem, "Comment").ToString(), 25)%>'></asp:Label>
                                                                                                    <ajx:HoverMenuExtender ID="hmeFeedbacks" runat="server" TargetControlID="lblgvFeedbacks"
                                                                                                        PopupControlID="pnlFeedbacks" PopupPosition="Right">
                                                                                                    </ajx:HoverMenuExtender>
                                                                                                    <asp:Panel ID="pnlFeedbacks" runat="server" Style="visibility: hidden; opacity: 100%"
                                                                                                        BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px">
                                                                                                        <table border="0" cellpadding="0" cellspacing="0" class="tooltip_hover_lettmenu_table">
                                                                                                            <tr>
                                                                                                                <td style="background-color: #FFFFF0">
                                                                                                                    <%#DataBinder.Eval(Container.DataItem, "Comment")%>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </asp:Panel>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrDepartment" runat="server" Text="Department"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%#DataBinder.Eval(Container.DataItem, "DepartmentName")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%#DataBinder.Eval(Container.DataItem, "CreatedOn", "{0:dd-MM-yyyy}")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <EmptyDataTemplate>
                                                                                            <div style="padding: 10px;">
                                                                                                <b>
                                                                                                    <asp:Label ID="lblNoRecordFound" Text="No Record Found." runat="server"></asp:Label>
                                                                                                </b>
                                                                                            </div>
                                                                                        </EmptyDataTemplate>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="border-left: 1px solid #CCCCCC;">
                                                                </td>
                                                                <td width="50%" style="vertical-align: top;">
                                                                    <table width="100%" style="vertical-align: top;">
                                                                        <tr>
                                                                            <td style="padding: 0px;">
                                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <b>Complaint</b>
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <asp:Button ID="btnAddCompalin" runat="server" Text="Add" Height="24px" OnClick="btnAddCompalin_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div class="box_content">
                                                                                    <asp:GridView ID="gvComplains" runat="server" AutoGenerateColumns="false" ShowHeader="true"
                                                                                        Width="100%">
                                                                                        <Columns>
                                                                                            <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrSrNo" runat="server" Text="No."></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%# Container.DataItemIndex + 1 %>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrFeedback" runat="server" Text="Complain"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblgvComplains" runat="server" Text='<%#TruncateString(DataBinder.Eval(Container.DataItem, "ComplaintDescription").ToString(), 25)%>'></asp:Label>
                                                                                                    <ajx:HoverMenuExtender ID="hmeComplains" runat="server" TargetControlID="lblgvComplains"
                                                                                                        PopupControlID="pnlComplains" PopupPosition="Right">
                                                                                                    </ajx:HoverMenuExtender>
                                                                                                    <asp:Panel ID="pnlComplains" runat="server" Style="visibility: hidden; opacity: 100%"
                                                                                                        BorderColor="#000000" BorderStyle="Solid" BorderWidth="1px">
                                                                                                        <table border="0" cellpadding="0" cellspacing="0" class="tooltip_hover_lettmenu_table">
                                                                                                            <tr>
                                                                                                                <td style="background-color: #FFFFF0">
                                                                                                                    <%#DataBinder.Eval(Container.DataItem, "ComplaintDescription")%>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </asp:Panel>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrDepartment" runat="server" Text="Department"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%#DataBinder.Eval(Container.DataItem, "DepartmentName")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="60px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:Label ID="lblGvHdrDate" runat="server" Text="Date"></asp:Label>
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <%#DataBinder.Eval(Container.DataItem, "DateOfComplain", "{0:dd-MM-yyyy}")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <EmptyDataTemplate>
                                                                                            <div style="padding: 10px;">
                                                                                                <b>
                                                                                                    <asp:Label ID="lblNoRecordFound" Text="No Record Found." runat="server"></asp:Label>
                                                                                                </b>
                                                                                            </div>
                                                                                        </EmptyDataTemplate>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="tabs-4">
                                                        <br />
                                                        <br />
                                                        Guest Cash card Information
                                                        <br />
                                                        <br />
                                                        <br />
                                                    </div>
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
                            <div class="clear_divider">
                            </div>
                            <div class="clear">
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="vForeignNationalinfo" runat="server">
                <table cellpadding="2" cellspacing="2" border="0" width="100%">
                    <tr>
                        <td width="75px" class="isrequire">
                            <asp:Literal ID="litIdtypeForeignNatinal" runat="server" Text="ID Type"></asp:Literal>
                        </td>
                        <td style="padding-top: 10px;">
                            <asp:DropDownList ID="ddlIdtypeForeignNatinal" Enabled="false" Style="width: 120px !important;"
                                runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvIdtypeForeignNatinal" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="ddlIdtypeForeignNatinal"
                                InitialValue="00000000-0000-0000-0000-000000000000" Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 95px;" class="isrequire">
                            <asp:Literal ID="litPassportNumber" runat="server" Text="Passport No."></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassportNumber" Enabled="false" runat="server" Style="width: 135px !important;"></asp:TextBox>
                            <span>
                                <asp:RequiredFieldValidator ID="rfvPassportNumber" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                    runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="txtPassportNumber"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td class="isrequire">
                            <asp:Literal ID="litPassportDateOfIssue" runat="server" Text="Passport Date Of Issue"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassportDateOfIssue" Enabled="false" runat="server" Style="width: 90px !important;"
                                onkeypress="return false;"></asp:TextBox>
                            <asp:Image ID="imgPassportDateOfIssue" Enabled="false" CssClass="small_img" runat="server"
                                ImageUrl="~/images/CalanderIcon.png" Height="20px" Width="20px" />
                            <ajx:CalendarExtender ID="calPassportDateOfIssue" PopupButtonID="imgPassportDateOfIssue"
                                TargetControlID="txtPassportDateOfIssue" runat="server" Format="dd-MM-yyyy">
                            </ajx:CalendarExtender>
                            <img src="../../images/clear.png" id="img2" style="vertical-align: middle; display: none;"
                                title="Clear Date" onclick="fnClearDate('<%= txtPassportDateOfIssue.ClientID %>');" />
                            <span>
                                <asp:RequiredFieldValidator ID="rfvPassportDateOfIssue" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                    runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="txtPassportDateOfIssue"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </span>
                        </td>
                        <td class="isrequire" style="width: 175px !important;">
                            <asp:Literal ID="litPassportDateOfExpiry" runat="server" Text="Passport Date Of Expiry"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassportDateOfExpiry" Enabled="false" runat="server" Style="width: 90px !important;"
                                onkeypress="return false;"></asp:TextBox>
                            <asp:Image ID="imgPassportDateOfExpiry" Enabled="false" CssClass="small_img" runat="server"
                                ImageUrl="~/images/CalanderIcon.png" Height="20px" Width="20px" />
                            <ajx:CalendarExtender ID="calPassportDateOfExpiry" Enabled="false" PopupButtonID="imgPassportDateOfExpiry"
                                TargetControlID="txtPassportDateOfExpiry" runat="server" Format="dd-MM-yyyy">
                            </ajx:CalendarExtender>
                            <img src="../../images/clear.png" id="img3" style="vertical-align: middle; display: none;"
                                title="Clear Date" onclick="fnClearDate('<%= txtPassportDateOfExpiry.ClientID %>');" />
                            <span>
                                <asp:RequiredFieldValidator ID="rfvPassportDateOfExpiry" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                    runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="txtPassportDateOfExpiry"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td class="isrequire">
                            <asp:Literal ID="litPassportscan1" runat="server" Text="Passport scan1"></asp:Literal>
                        </td>
                        <td>
                            <div class="browse_file_grid_test">
                                <asp:FileUpload ID="fuPassportscan1" Enabled="false" runat="server" />
                            </div>
                            <asp:RegularExpressionValidator ID="revPassportscan1" runat="server" ControlToValidate="fuPassportscan1"
                                SetFocusOnError="true" CssClass="input-notification error png_bg" Display="Dynamic"
                                ValidationExpression="^.+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|.gif|.GIF|.bmp|.BMP)$"></asp:RegularExpressionValidator>
                            <a id="ancViewPassportScan1" runat="server" target="_blank" visible="false">
                                <img src="../../images/View.png" width="17px" alt="view Passport Scan1" height="17px" /></a>
                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/Delete.png"
                                Visible="false" Width="16px" Height="16px" BorderStyle="None" />
                        </td>
                        <td>
                            <asp:Literal ID="litPassportscan2" runat="server" Text="Passport scan2"></asp:Literal>
                        </td>
                        <td>
                            <div class="browse_file_grid_test">
                                <asp:FileUpload ID="fupPassportscan2" Enabled="false" runat="server" />
                            </div>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="fupPassportscan2"
                                SetFocusOnError="true" ValidationGroup="ForeignNatinal" CssClass="input-notification error png_bg"
                                Display="Dynamic" ValidationExpression="^.+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|.gif|.GIF|.bmp|.BMP)$"></asp:RegularExpressionValidator>
                            <a id="ancViewPassportScan2" runat="server" target="_blank" visible="false">
                                <img src="../../images/View.png" width="17px" alt="view photo" height="17px" /></a>
                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/Delete.png"
                                Visible="false" Width="16px" Height="16px" BorderStyle="None" />
                        </td>
                    </tr>
                    <tr>
                        <td class="isrequire">
                            <asp:Literal ID="litPassportPlaceOfIssue" runat="server" Text="Passport Place Of Issue"></asp:Literal>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtPassportPlaceOfIssue" Enabled="false" Style="width: 135px !important;"
                                runat="server"></asp:TextBox>
                            <span>
                                <asp:RequiredFieldValidator ID="rfvPassportPlaceOfIssue" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                    runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="txtPassportPlaceOfIssue"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td class="isrequire">
                            <asp:Literal ID="litVisatype" runat="server" Text="Visa Type"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox ID="txtVisatype" Style="width: 135px !important;" runat="server"></asp:TextBox>
                            <span>
                                <asp:RequiredFieldValidator ID="rfvVisatype" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                    runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="txtVisatype"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </span>
                        </td>
                        <td class="isrequire">
                            <asp:Literal ID="litVisanumber" runat="server" Text="Visa No."></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox ID="txtVisaNo" Style="width: 135px !important;" runat="server"></asp:TextBox>
                            <span>
                                <asp:RequiredFieldValidator ID="rfvVisaNo" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                    runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="txtVisaNo"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td class="isrequire" style="width: 175px !important;">
                            <asp:Literal ID="litVisaDateofIssue" runat="server" Text="Visa Date Of Issue"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox ID="txtVisaDateofIssue" runat="server" Style="width: 90px !important;"
                                onkeypress="return false;"></asp:TextBox>
                            <asp:Image ID="imgVisaDateofIssue" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                Height="20px" Width="20px" />
                            <ajx:CalendarExtender ID="calVisaDateofIssue" PopupButtonID="imgVisaDateofIssue"
                                TargetControlID="txtVisaDateofIssue" runat="server" Format="dd-MM-yyyy">
                            </ajx:CalendarExtender>
                            <img src="../../images/clear.png" id="img4" style="vertical-align: middle;" title="Clear Date"
                                onclick="fnClearDate('<%= txtVisaDateofIssue.ClientID %>');" />
                            <span>
                                <asp:RequiredFieldValidator ID="rfvVisaDateofIssue" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                    runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="txtVisaDateofIssue"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </span>
                        </td>
                        <td class="isrequire">
                            <asp:Literal ID="litVisaDateofExpiry" runat="server" Text="Visa Date Of Expiry"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox ID="txtVisaDateofExpiry" runat="server" Style="width: 90px !important;"
                                onkeypress="return false;"></asp:TextBox>
                            <asp:Image ID="imgVisaDateofExpiry" CssClass="small_img" runat="server" ImageUrl="~/images/CalanderIcon.png"
                                Height="20px" Width="20px" />
                            <ajx:CalendarExtender ID="calVisaDateofExpiry" PopupButtonID="imgVisaDateofExpiry"
                                TargetControlID="txtVisaDateofExpiry" runat="server" Format="dd-MM-yyyy">
                            </ajx:CalendarExtender>
                            <img src="../../images/clear.png" id="img5" style="vertical-align: middle;" title="Clear Date"
                                onclick="fnClearDate('<%= txtVisaDateofExpiry.ClientID %>');" />
                            <span>
                                <asp:RequiredFieldValidator ID="rfvVisaDateofExpiry" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                    runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="txtVisaDateofExpiry"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td class="isrequire">
                            <asp:Literal ID="litVisaplaceofissue" runat="server" Text="Visa Place Of Issue"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox ID="txtVisaplaceofissue" Style="width: 135px !important;" runat="server"></asp:TextBox>
                            <span>
                                <asp:RequiredFieldValidator ID="rfvVisaplaceofissue" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                    runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="txtVisaplaceofissue"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </span>
                        </td>
                        <td>
                            <asp:Literal ID="litVisaPurpose" runat="server" Text="Purpose Of Visa"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox ID="txtVisaPurpose" Style="width: 135px !important;" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="isrequire">
                            <asp:Literal ID="litVisaScan" runat="server" Text="Visa scan"></asp:Literal>
                        </td>
                        <td colspan="3">
                            <div class="browse_file_grid_test">
                                <asp:FileUpload ID="fupVisaScan" runat="server" />
                            </div>
                            <asp:RegularExpressionValidator ID="revVisaScan" runat="server" ControlToValidate="fupVisaScan"
                                SetFocusOnError="true" ValidationGroup="ForeignNatinal" CssClass="input-notification error png_bg"
                                Display="Dynamic" ValidationExpression="^.+(.jpg|.JPG|.jpeg|.JPEG|.png|.PNG|.gif|.GIF|.bmp|.BMP)$"></asp:RegularExpressionValidator>
                            <a id="ancViewVisaScan" runat="server" target="_blank" visible="false">
                                <img src="../../images/View.png" width="17px" alt="view photo" height="17px" /></a>
                            <asp:RequiredFieldValidator ID="rfvVisaScan" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                runat="server" ValidationGroup="ForeignNatinal" ControlToValidate="fupVisaScan"
                                Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:Button ID="btnSaveForeignNationalInfo" runat="server" ValidationGroup="ForeignNatinal"
                                Style="display: inline; padding-right: 10px;" Text="Save" OnClick="btnSaveForeignNationalInfo_Click" />
                            <asp:Button ID="btnBackGuestInfo" runat="server" Style="display: inline; padding-right: 10px;"
                                Text="Back To Gueest Profile" OnClick="btnBackGuestInfo_Click" />
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
        <ajx:ModalPopupExtender ID="mpePreference" runat="server" TargetControlID="hdnPreference"
            PopupControlID="pnlPreference" BackgroundCssClass="mod_background" CancelControlID="imgPreferenceCancel">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnPreference" runat="server" />
        <asp:Panel ID="pnlPreference" runat="server" Width="600px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="litHdrPreference" runat="server" Text="Preference"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="imgPreferenceCancel" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <%--<div class="box_head">
                    <span>
                        <asp:Literal ID="litHdrPreference" runat="server" Text="Preference"></asp:Literal></span></div>--%>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td class="isrequire">
                                <asp:Literal ID="litPreference" runat="server" Text="Preference"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPreference" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvPreference" InitialValue="00000000-0000-0000-0000-000000000000"
                                    SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                    ValidationGroup="IsRequirePreference" ControlToValidate="ddlPreference" Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litPreferenceDetails" runat="server" Text="Details"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPreferenceDetails" runat="server" Style="width: 450px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">
                                <asp:Literal ID="litPreferenceDescription" runat="server" Text="Description"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPreferenceDescription" runat="server" Style="width: 450px" TextMode="MultiLine"
                                    Rows="4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnPreferenceSave" OnClick="btnPreferenceSave_OnClick" runat="server"
                                    Text="Save" Style="display: inline;" ValidationGroup="IsRequirePreference" />
                                <%-- <asp:Button ID="btnPreferenceCancel" runat="server" Text="Cancel" Style="display: inline;" />--%>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeManagementNote" runat="server" TargetControlID="hdnManagementNote"
            PopupControlID="pnlManagementNote" BackgroundCssClass="mod_background" CancelControlID="imgManagementNoteCancel">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnManagementNote" runat="server" />
        <asp:Panel ID="pnlManagementNote" runat="server" Width="600px" Style="display: none;">
            <div class="box_col1">
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="litHdrManagementNote" runat="server" Text="Management Note"></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="imgManagementNoteCancel" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <%-- <div class="box_head">
                    <span>
                        <asp:Literal ID="litHdrManagementNote" runat="server" Text="Management Note"></asp:Literal></span></div>--%>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td class="isrequire" style="vertical-align: top; width: 60px;">
                                <asp:Literal ID="litManagementNote" runat="server" Text="Note"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtManagementNote" runat="server" Style="width: 450px" TextMode="MultiLine"
                                    Rows="5"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvManagementNote" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                    runat="server" ValidationGroup="IsRequireManagementNote" ControlToValidate="txtManagementNote"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnManagementNoteSave" OnClick="btnManagementNoteSave_OnClick" runat="server"
                                    Text="Save" Style="display: inline;" ValidationGroup="IsRequireManagementNote" />
                                <%--<asp:Button ID="btnManagementNoteCancel" runat="server" Text="Cancel" Style="display: inline;" />--%>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <ajx:ModalPopupExtender ID="mpeFeedBackAndComplain" runat="server" TargetControlID="hdnFeedBackAndComplain"
            PopupControlID="pnlFeedBackAndComplain" BackgroundCssClass="mod_background" CancelControlID="imgCancelFeedBackAndComplain">
        </ajx:ModalPopupExtender>
        <asp:HiddenField ID="hdnFeedBackAndComplain" runat="server" />
        <asp:Panel ID="pnlFeedBackAndComplain" runat="server" Width="600px" Style="display: none;">
            <div class="box_col1">
                <%-- <div class="box_head">
                    <span>
                        <asp:Literal ID="litHdrFeedBackAndComplain" runat="server" Text=""></asp:Literal></span></div>--%>
                <div class="box_head">
                    <div style="display: inline;">
                        <span>
                            <asp:Literal ID="litHdrFeedBackAndComplain" runat="server" Text=""></asp:Literal></span></div>
                    <div style="float: right; display: inline; padding-top: 12px; padding-right: 10px;">
                        <asp:ImageButton ID="imgCancelFeedBackAndComplain" runat="server" ImageUrl="~/images/closepopup.png"
                            Style="border: 0px; width: 16px; height: 16px; margin: -4px 0 0 5px; vertical-align: middle;" />
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box_form">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td>
                                <asp:Literal ID="litCategory" runat="server" Text="Category"></asp:Literal>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbtCategoryList" runat="server" Enabled="false" RepeatColumns="2"
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Feedback" Value="Feedback"></asp:ListItem>
                                    <asp:ListItem Text="Complaint" Value="Complaint"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" style="width: 130px !important;">
                                <asp:Literal ID="litComplainBy" runat="server" Text="Complain By"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtComplainBy" runat="server"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rfvComplainBy" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="IsRequireFeedBackAndComplain" ControlToValidate="txtComplainBy"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" style="width: 130px !important;">
                                <asp:Literal ID="litDepartment" runat="server" Text="Department"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDepartment" runat="server">
                                </asp:DropDownList>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfDepartment" InitialValue="00000000-0000-0000-0000-000000000000"
                                        SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                        ValidationGroup="IsRequireFeedBackAndComplain" ControlToValidate="ddlDepartment"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="isrequire" style="width: 130px !important;">
                                <asp:Literal ID="litNatureOfComplaint" runat="server" Text="Nature Of Complaint"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNatureOfComplaint" runat="server"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="rvfNatureOfComplaint" SetFocusOnError="true" CssClass="input-notification error png_bg"
                                        runat="server" ValidationGroup="IsRequireFeedBackAndComplain" ControlToValidate="txtNatureOfComplaint"
                                        Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litDescription" runat="server" Text="Description"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescription" runat="server" Rows="5" Style="width: 375px;" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSaveFeedBackAndComplain" OnClick="btnSaveFeedBackAndComplain_OnClick"
                                    runat="server" Text="Save" Style="display: inline;" ValidationGroup="IsRequireFeedBackAndComplain" />
                                <%--<asp:Button ID="btnCancelFeedBackAndComplain" runat="server" Text="Cancel" Style="display: inline;" />--%>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnGuestProfileSave" />
        <asp:PostBackTrigger ControlID="btnSaveForeignNationalInfo" />
        <asp:PostBackTrigger ControlID="linkForeignNationalpopup" />
    </Triggers>
</asp:UpdatePanel>
<div id="errormessage" class="clear" style="display: none;">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
