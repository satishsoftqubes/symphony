<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="SQT.Symphony.UI.Web.Configuration.WebForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Page</title>    
    <style type="text/css">
        .maintable{border:1px solid gray; height:150px;}
        .tobookcell{background-color:#f3f3f5;}
        .header{background-color:#dddddf;text-align:center;width:35px;}
        .roomname{background-color:#dddddf;padding-left:5px;}
        .commonheader{background-color:Gray;text-align:center;width:100px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">    
    <script language="javascript" type="text/javascript">
        function fnClick(id) {
            document.getElementById(id).style.backgroundColor = 'Gray';
        }
    </script>
    <div>
        <div id="dvTest" runat="server">
            <%--<table cellpadding='0' cellspacing='1' class='maintable'>
                <tr>
                    <td class="commonheader">
                       <b>Room/Date</b>
                    </td>
                    <td class="header">
                        01<br />Mon
                    </td>
                    <td class="header">
                       02<br />Tue
                    </td>
                    <td class="header">
                        03<br />Wed
                    </td>
                    <td class="header">
                       04<br />Thu
                    </td>
                    <td class="header">
                        05<br />Fri
                    </td>
                    <td class="header">
                       06<br />Sat
                    </td>
                </tr>
                <tr>
                    <td class="roomname">
                       Room No. 1 
                    </td>
                    <td id='11' class='tobookcell' onclick="fnClick('11');">
                    </td>
                    <td id='12' class='tobookcell' onclick="fnClick('12');">
                    </td>
                    <td id='13' class='tobookcell' onclick="fnClick('13');">
                    </td>
                    <td id='14' class='tobookcell' onclick="fnClick('14');">
                    </td>
                    <td id='15' class='tobookcell' onclick="fnClick('15');">
                    </td>
                    <td id='16' class='tobookcell' onclick="fnClick('16');">
                    </td>
                </tr>
                <tr>
                    <td class="roomname">
                       Room No. 2 
                    </td>
                    <td id='21' class='tobookcell' onclick="fnClick('21');">
                    </td>
                    <td id='22' class='tobookcell' onclick="fnClick('22');">
                    </td>
                    <td id='23' class='tobookcell' onclick="fnClick('23');">
                    </td>
                    <td id='24' class='tobookcell' onclick="fnClick('24');">
                    </td>
                    <td id='25' class='tobookcell' onclick="fnClick('25');">
                    </td>
                    <td id='26' class='tobookcell' onclick="fnClick('26');">
                    </td>
                </tr>
                <tr>
                    <td class="roomname">
                       Room No. 3 
                    </td>
                    <td id='31' class='tobookcell' onclick="fnClick('31');">
                    </td>
                    <td id='32' class='tobookcell' onclick="fnClick('32');">
                    </td>
                    <td id='33' class='tobookcell' onclick="fnClick('33');">
                    </td>
                    <td id='34' class='tobookcell' onclick="fnClick('34');">
                    </td>
                    <td id='35' class='tobookcell' onclick="fnClick('35');">
                    </td>
                    <td id='36' class='tobookcell' onclick="fnClick('36');">
                    </td>
                </tr>
            </table>--%>
        </div>
    </div>
    </form>
</body>
</html>
