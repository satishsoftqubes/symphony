<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlAccessDenied.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.IRMS.MsgBox.CtrlAccessDenied" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="content">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="box">
                <tr>
                    <td class="boxtopleft">
                        &nbsp;
                    </td>
                    <td class="boxtopcenter">
                        ACCESS DEINED
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
                            <div align="center" style="width: 600px; margin: 100px 0px; border: solid 1px #CCCCCE;
                                background: #F4F4F4;">
                                <table border="0" width="600" cellspacing="0" cellpadding="7">
                                    <tr>
                                        <td width="200">
                                            <p align="center">
                                                <img border="0" src="<%=Page.ResolveUrl("~/images/accessDenied.gif") %>" width="128"
                                                    height="128">
                                        </td>
                                        <td width="800"> <br />
                                            <p align="left">
                                                <font face="Arial" style="font-weight:bold; color:#0067A4;" size="5">Access Denied</font> <br /> <br />
                                                <p align="left">
                            <font face="Arial" style="color:#909092;" size="4">You don't have the required permission to access this
                                page.<br/>
                                &nbsp;</font>
                                </p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <h>
                        
                                </h>
                                        </td>
                                    </tr>
                                </table>
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
