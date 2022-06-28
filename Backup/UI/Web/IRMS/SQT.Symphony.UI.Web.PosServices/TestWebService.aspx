<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWebService.aspx.cs"
    Inherits="SQT.Symphony.UI.Web.PosServices.TestWebService" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
    <script src="Styles/script.js" type="text/javascript"></script>

    <script type="text/javascript">
        function fnGetStingWithXML() {
            CheckInGuestList.GetCheckInGuestListWithString(fnSuccess, fnFailure);
            return false;
        }
        function fnSuccess(data) {
            var xmlDoc = $.parseXML(data);            
            var xml = $(xmlDoc);
            var customers = xml.find("Table1");            
            var myObject = eval(customers);
            var v = '';

            for (i in myObject) {
                v += "<tr><td>" + myObject[i]["Name"] + "</td><td>" + myObject[i]["ID"] + "</td></tr>";
            }
            $("#divData").append("<table id='test'>" + v + "</table>");
        }
        function fnFailure() {
        }


        function fnReturnXMLData() {
            CheckInGuestList.GetCheckInGuestListWihtXML(fnSuccessWithXML, fnFailuteWithXML);
            return false;
        }

        function fnSuccessWithXML(data) {
            alert(data);
            alert(data.d);
        }

        function fnFailuteWithXML(data) {
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ajx:ToolkitScriptManager EnableScriptGlobalization="true" EnableScriptLocalization="true"
        ID="ToolkitScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="~/Services/CheckInGuestList.asmx" />
        </Services>
    </ajx:ToolkitScriptManager>
    <div>
        <asp:Button ID="btnCall" runat="server" Text="Call" OnClientClick="return fnGetStingWithXML();" />

        <asp:Button ID="bntReturnXMLData" runat="server" Text="Call XML" OnClientClick="return fnReturnXMLData();" />
    </div>
    <div id="divData">
    </div>
    </form>
</body>
</html>
