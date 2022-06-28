<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlTransferTransactionFolio.ascx.cs"
    Inherits="SQT.Symphony.UI.Web.FrontDesk.UIControls.Folio.ctrlTransferTransactionFolio" %>
<%@ Register Src="~/UIControls/CommonControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc1" %>
<style type="text/css">
    #footer
    {
        height: 30px;
        vertical-align: middle;
        text-align: right;
        clear: both;
        padding-right: 3px;
        background-color: #317082;
        margin-top: 2px;
        width: 790px;
    }
    #footer form
    {
        margin: 0px;
        margin-top: 2px;
    }
    #dhtmlgoodies_dragDropContainer
    {
        /* Main container for this script */
        width: 100%;
        height: 720px;
        background-color: #FFF;
        -moz-user-select: none;
    }
    #dhtmlgoodies_dragDropContainer ul
    {
        /* General rules for all <ul> */
        margin-top: 0px;
        margin-left: 0px;
        margin-bottom: 0px;
        padding: 2px;
        width: 98%;
    }
    
    #dhtmlgoodies_dragDropContainer li, #dragContent li, li#indicateDestination
    {
        /* Movable items, i.e. <LI> */
        list-style-type: none;
        background-color: #DFEFFC;
        border: 1px solid #C5DBEC;
        padding: 2px;
        margin-bottom: 2px;
        cursor: pointer;
        font-size: 0.9em;
        font-weight: bold;
        color: #2E6E9E;
        margin: 0 5px 5px;
    }
    
    li#indicateDestination
    {
        /* Box indicating where content will be dropped - i.e. the one you use if you don't use arrow */
        border: 1px solid #317082;
        background-color: #FFF;
    }
    
    /* LEFT COLUMN CSS */
    div#dhtmlgoodies_listOfItems
    {
        /* Left column "Available students" */
        float: left;
        padding-left: 10px;
        padding-right: 10px; /* CSS HACK */
        width: 98%; /* IE 5.x */
        width: /* */ /**/ 98%; /* Other browsers */
        width: /**/ 98%;
    }
    #dhtmlgoodies_listOfItems ul
    {
        /* Left(Sources) column <ul> */
        height: 560px;
    }
    
    div#dhtmlgoodies_listOfItems div
    {
        border: 1px solid #999;
    }
    div#dhtmlgoodies_listOfItems div ul
    {
        /* Left column <ul> */
        margin-left: 3px; /* Space at the left of list - the arrow will be positioned there */
    }
    #dhtmlgoodies_listOfItems div p
    {
        /* Heading above left column */
        margin: 0px;
        font-weight: bold;
        padding-left: 12px;
        background-color: #ECECEC; /*color: #FFF; */
        margin-bottom: 5px;
        line-height: 25px;
    }
    /* END LEFT COLUMN CSS */
    
    #dhtmlgoodies_dragDropContainer .mouseover
    {
        /* Mouse over effect DIV box in right column */
        background-color: #E2EBED;
        border: 1px solid #317082;
    }
    
    /* Start main container CSS */
    
    div#dhtmlgoodies_mainContainer
    {
        /* Right column DIV */
        width: 98%;
        float: left;
    }
    #dhtmlgoodies_mainContainer div
    {
        /* Parent <div> of small boxes */
        float: left;
        margin-right: 10px;
        margin-bottom: 10px;
        margin-top: 0px;
        border: 1px solid #999; /* CSS HACK */
        width: 98%; /* IE 5.x */
        width: /* */ /**/ 98%; /* Other browsers */
        width: /**/ 98%;
    }
    #dhtmlgoodies_mainContainer div ul
    {
        margin-left: 3px;
    }
    
    #dhtmlgoodies_mainContainer div p
    {
        /* Heading above small boxes */
        margin: 0px;
        padding: 0px;
        padding-left: 12px;
        font-weight: bold;
        background-color: #ECECEC; /* color: #FFF;*/
        margin-bottom: 5px;
        line-height: 25px;
    }
    
    #dhtmlgoodies_mainContainer ul
    {
        /* Small box in right column ,i.e <ul> */
        width: 98%;
        height: 80px;
        border: 0px;
        margin-bottom: 0px;
        overflow: hidden;
    }
    
    #dragContent
    {
        /* Drag container */
        position: absolute;
        width: 35%;
        height: 20px;
        display: none;
        margin: 0px;
        padding: 0px;
        z-index: 2000;
    }
    
    #dragDropIndicator
    {
        /* DIV for the small arrow */
        position: absolute;
        width: 7px;
        height: 10px;
        display: none;
        z-index: 1000;
        margin: 0px;
        padding: 0px;
    }
</style>
<style type="text/css" media="print">
    div#dhtmlgoodies_listOfItems
    {
        display: none;
    }
    img
    {
        display: none;
    }
    #dhtmlgoodies_dragDropContainer
    {
        border: 0px;
        width: 100%;
    }
</style>
<script type="text/javascript">
    /************************************************************************************************************
    Textarea maxlength
    Copyright (C) November 2005  DTHMLGoodies.com, Alf Magne Kalleland

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA

    Dhtmlgoodies.com., hereby disclaims all copyright interest in this script
    written by Alf Magne Kalleland.

    Alf Magne Kalleland, 2010
    Owner of DHTMLgoodies.com

    ************************************************************************************************************/

    /* VARIABLES YOU COULD MODIFY */
    var boxSizeArray = [19, 4, 4, 3, 7]; // Array indicating how many items there is rooom for in the right column ULs


    var verticalSpaceBetweenListItems = 3; // Pixels space between one <li> and next
    // Same value or higher as margin bottom in CSS for #dhtmlgoodies_dragDropContainer ul li,#dragContent li


    var indicateDestionationByUseOfArrow = true; // Display arrow to indicate where object will be dropped(false = use rectangle)

    var cloneSourceItems = false; // Items picked from main container will be cloned(i.e. "copy" instead of "cut").
    var cloneAllowDuplicates = false; // Allow multiple instances of an item inside a small box(example: drag Student 1 to team A twice

    /* END VARIABLES YOU COULD MODIFY */

    var dragDropTopContainer = false;
    var dragTimer = -1;
    var dragContentObj = false;
    var contentToBeDragged = false; // Reference to dragged <li>
    var contentToBeDragged_src = false; // Reference to parent of <li> before drag started
    var contentToBeDragged_next = false; 	// Reference to next sibling of <li> to be dragged
    var destinationObj = false; // Reference to <UL> or <LI> where element is dropped.
    var dragDropIndicator = false; // Reference to small arrow indicating where items will be dropped
    var ulPositionArray = new Array();
    var mouseoverObj = false; // Reference to highlighted DIV

    var MSIE = navigator.userAgent.indexOf('MSIE') >= 0 ? true : false;
    var navigatorVersion = navigator.appVersion.replace(/.*?MSIE (\d\.\d).*/g, '$1') / 1;

    var arrow_offsetX = -5; // Offset X - position of small arrow
    var arrow_offsetY = 0; // Offset Y - position of small arrow

    if (!MSIE || navigatorVersion > 6) {
        arrow_offsetX = -6; // Firefox - offset X small arrow
        arrow_offsetY = -13; // Firefox - offset Y small arrow
    }

    var indicateDestinationBox = false;
    function getTopPos(inputObj) {
        var returnValue = inputObj.offsetTop;
        while ((inputObj = inputObj.offsetParent) != null) {
            if (inputObj.tagName != 'HTML') returnValue += inputObj.offsetTop;
        }
        return returnValue;
    }

    function getLeftPos(inputObj) {
        var returnValue = inputObj.offsetLeft;
        while ((inputObj = inputObj.offsetParent) != null) {
            if (inputObj.tagName != 'HTML') returnValue += inputObj.offsetLeft;
        }
        return returnValue;
    }

    function cancelEvent() {
        return false;
    }
    function initDrag(e)	// Mouse button is pressed down on a LI
    {
        if (document.all) e = event;
        var st = Math.max(document.body.scrollTop, document.documentElement.scrollTop);
        var sl = Math.max(document.body.scrollLeft, document.documentElement.scrollLeft);

        dragTimer = 0;
        dragContentObj.style.left = e.clientX + sl + 'px';
        dragContentObj.style.top = e.clientY + st + 'px';
        contentToBeDragged = this;
        contentToBeDragged_src = this.parentNode;
        contentToBeDragged_next = false;
        if (this.nextSibling) {
            contentToBeDragged_next = this.nextSibling;
            if (!this.tagName && contentToBeDragged_next.nextSibling) contentToBeDragged_next = contentToBeDragged_next.nextSibling;
        }
        timerDrag();
        return false;
    }

    function timerDrag() {
        if (dragTimer >= 0 && dragTimer < 10) {
            dragTimer++;
            setTimeout('timerDrag()', 10);
            return;
        }
        if (dragTimer == 10) {

            if (cloneSourceItems && contentToBeDragged.parentNode.id == 'allItems') {
                newItem = contentToBeDragged.cloneNode(true);
                newItem.onmousedown = contentToBeDragged.onmousedown;
                contentToBeDragged = newItem;
            }
            dragContentObj.style.display = 'block';
            dragContentObj.appendChild(contentToBeDragged);
        }
    }

    function moveDragContent(e) {
        if (dragTimer < 10) {
            if (contentToBeDragged) {
                if (contentToBeDragged_next) {
                    contentToBeDragged_src.insertBefore(contentToBeDragged, contentToBeDragged_next);
                } else {
                    contentToBeDragged_src.appendChild(contentToBeDragged);
                }
            }
            return;
        }
        if (document.all) e = event;
        var st = Math.max(document.body.scrollTop, document.documentElement.scrollTop);
        var sl = Math.max(document.body.scrollLeft, document.documentElement.scrollLeft);


        dragContentObj.style.left = e.clientX + sl + 'px';
        dragContentObj.style.top = e.clientY + st + 'px';

        if (mouseoverObj) mouseoverObj.className = '';
        destinationObj = false;
        dragDropIndicator.style.display = 'none';
        if (indicateDestinationBox) indicateDestinationBox.style.display = 'none';
        var x = e.clientX + sl;
        var y = e.clientY + st;
        var width = dragContentObj.offsetWidth;
        var height = dragContentObj.offsetHeight;

        var tmpOffsetX = arrow_offsetX;
        var tmpOffsetY = arrow_offsetY;

        for (var no = 0; no < ulPositionArray.length; no++) {
            var ul_leftPos = ulPositionArray[no]['left'];
            var ul_topPos = ulPositionArray[no]['top'];
            var ul_height = ulPositionArray[no]['height'];
            var ul_width = ulPositionArray[no]['width'];

            if ((x + width) > ul_leftPos && x < (ul_leftPos + ul_width) && (y + height) > ul_topPos && y < (ul_topPos + ul_height)) {
                var noExisting = ulPositionArray[no]['obj'].getElementsByTagName('LI').length;
                if (indicateDestinationBox && indicateDestinationBox.parentNode == ulPositionArray[no]['obj']) noExisting--;
                if (noExisting < boxSizeArray[no - 1] || no == 0) {
                    dragDropIndicator.style.left = ul_leftPos + tmpOffsetX + 'px';
                    var subLi = ulPositionArray[no]['obj'].getElementsByTagName('LI');

                    var clonedItemAllreadyAdded = false;
                    if (cloneSourceItems && !cloneAllowDuplicates) {
                        for (var liIndex = 0; liIndex < subLi.length; liIndex++) {
                            if (contentToBeDragged.id == subLi[liIndex].id) clonedItemAllreadyAdded = true;
                        }
                        if (clonedItemAllreadyAdded) continue;
                    }

                    for (var liIndex = 0; liIndex < subLi.length; liIndex++) {
                        var tmpTop = getTopPos(subLi[liIndex]);
                        if (!indicateDestionationByUseOfArrow) {
                            if (y < tmpTop) {
                                destinationObj = subLi[liIndex];
                                indicateDestinationBox.style.display = 'block';
                                subLi[liIndex].parentNode.insertBefore(indicateDestinationBox, subLi[liIndex]);
                                break;
                            }
                        } else {
                            if (y < tmpTop) {
                                destinationObj = subLi[liIndex];
                                dragDropIndicator.style.top = tmpTop + tmpOffsetY - Math.round(dragDropIndicator.clientHeight / 2) + 'px';
                                dragDropIndicator.style.display = 'block';
                                break;
                            }
                        }
                    }

                    if (!indicateDestionationByUseOfArrow) {
                        if (indicateDestinationBox.style.display == 'none') {
                            indicateDestinationBox.style.display = 'block';
                            ulPositionArray[no]['obj'].appendChild(indicateDestinationBox);
                        }

                    } else {
                        if (subLi.length > 0 && dragDropIndicator.style.display == 'none') {
                            dragDropIndicator.style.top = getTopPos(subLi[subLi.length - 1]) + subLi[subLi.length - 1].offsetHeight + tmpOffsetY + 'px';
                            dragDropIndicator.style.display = 'block';
                        }
                        if (subLi.length == 0) {
                            dragDropIndicator.style.top = ul_topPos + arrow_offsetY + 'px'
                            dragDropIndicator.style.display = 'block';
                        }
                    }

                    if (!destinationObj) destinationObj = ulPositionArray[no]['obj'];
                    mouseoverObj = ulPositionArray[no]['obj'].parentNode;
                    mouseoverObj.className = 'mouseover';
                    return;
                }
            }
        }
    }

    /* End dragging
    Put <LI> into a destination or back to where it came from.
    */
    function dragDropEnd(e) {
        if (dragTimer == -1) return;
        if (dragTimer < 10) {
            dragTimer = -1;
            return;
        }
        dragTimer = -1;
        if (document.all) e = event;


        if (cloneSourceItems && (!destinationObj || (destinationObj && (destinationObj.id == 'allItems' || destinationObj.parentNode.id == 'allItems')))) {
            contentToBeDragged.parentNode.removeChild(contentToBeDragged);
        } else {

            if (destinationObj) {
                if (destinationObj.tagName == 'UL') {
                    destinationObj.appendChild(contentToBeDragged);
                } else {
                    destinationObj.parentNode.insertBefore(contentToBeDragged, destinationObj);
                }

                var strallItems = "";
                var strbox1 = ""
                var saveString = "";

                var uls = dragDropTopContainer.getElementsByTagName('UL');
                for (var no = 0; no < uls.length; no++) {	// LOoping through all <ul>
                    var lis = uls[no].getElementsByTagName('LI');
                    for (var no2 = 0; no2 < lis.length; no2++) {
                        if (saveString.length > 0) saveString = saveString + ";";

                        var strULName = uls[no].id;
                        saveString = saveString + uls[no].id + '|' + lis[no2].id;

                        if (strULName == 'allItems') {

                            if (strallItems.length > 0) strallItems = strallItems + ";";
                            strallItems = strallItems + lis[no2].id;
                        }
                        else {

                            if (strbox1.length > 0) strbox1 = strbox1 + ";";
                            strbox1 = strbox1 + lis[no2].id;
                        }
                    }
                }

                var mySplitallItemTotal = 0;

                if (strallItems.length > 0) {
                    var mySplitallItems = strallItems.split(";");
                    for (var i = 0; i < mySplitallItems.length; i++) {

                        var mySplitallItemWithDash = mySplitallItems[i].split("|");
                        mySplitallItemTotal = mySplitallItemTotal + parseFloat(mySplitallItemWithDash[1]);
                    }
                }

                var mySplitbox1Total = 0;

                if (strbox1.length > 0) {
                    var mySplitbox1 = strbox1.split(";");
                    for (var i = 0; i < mySplitbox1.length; i++) {

                        var mySplitbox1WithDash = mySplitbox1[i].split("|");
                        mySplitbox1Total = mySplitbox1Total + parseFloat(mySplitbox1WithDash[1]);
                    }
                }

                //document.getElementById('saveContent').innerHTML = '<h1>Ready to save these nodes:</h1> ' + saveString.replace(/;/g, ';<br>') + '<p>Format: ID of ul |(pipe) ID of li;(semicolon)</p><p>You can put these values into a hidden form fields, post it to the server and explode the submitted value there</p>';

                document.getElementById('<%=lblDisplayTotalBalanceFromDB.ClientID %>').innerHTML = mySplitallItemTotal.toFixed(2);
                document.getElementById('<%=lblTransferBalance.ClientID %>').innerHTML = mySplitbox1Total.toFixed(2);

                mouseoverObj.className = '';
                destinationObj = false;
                dragDropIndicator.style.display = 'none';
                if (indicateDestinationBox) {
                    indicateDestinationBox.style.display = 'none';
                    document.body.appendChild(indicateDestinationBox);
                }
                contentToBeDragged = false;
                return;
            }
            if (contentToBeDragged_next) {
                contentToBeDragged_src.insertBefore(contentToBeDragged, contentToBeDragged_next);
            } else {
                contentToBeDragged_src.appendChild(contentToBeDragged);
            }
        }
        contentToBeDragged = false;
        dragDropIndicator.style.display = 'none';
        if (indicateDestinationBox) {
            indicateDestinationBox.style.display = 'none';
            document.body.appendChild(indicateDestinationBox);

        }

        mouseoverObj = false;


    }

    /*
    Preparing data to be saved
    */
    function saveDragDropNodes() {
        var saveString = "";
        var uls = dragDropTopContainer.getElementsByTagName('UL');
        for (var no = 0; no < uls.length; no++) {	// LOoping through all <ul>
            var lis = uls[no].getElementsByTagName('LI');
            for (var no2 = 0; no2 < lis.length; no2++) {
                if (saveString.length > 0) saveString = saveString + ";";
                saveString = saveString + uls[no].id + '|' + lis[no2].id;
            }
        }

        //document.getElementById('saveContent').innerHTML = '<h1>Ready to save these nodes:</h1> ' + saveString.replace(/;/g, ';<br>') + '<p>Format: ID of ul |(pipe) ID of li;(semicolon)</p><p>You can put these values into a hidden form fields, post it to the server and explode the submitted value there</p>';
        //alert(document.getElementById('saveContent').innerHTML);


        //WebService1.Save(document.getElementById('saveContent').innerHTML);
        return false;
        //return true;
    }

    function initDragDropScript() {
        dragContentObj = document.getElementById('dragContent');
        dragDropIndicator = document.getElementById('dragDropIndicator');
        dragDropTopContainer = document.getElementById('dhtmlgoodies_dragDropContainer');
        document.documentElement.onselectstart = cancelEvent; ;
        var listItems = dragDropTopContainer.getElementsByTagName('LI'); // Get array containing all <LI>
        var itemHeight = false;
        for (var no = 0; no < listItems.length; no++) {
            listItems[no].onmousedown = initDrag;
            listItems[no].onselectstart = cancelEvent;
            if (!itemHeight) itemHeight = listItems[no].offsetHeight;
            if (MSIE && navigatorVersion / 1 < 6) {
                listItems[no].style.cursor = 'hand';
            }
        }

        var mainContainer = document.getElementById('dhtmlgoodies_mainContainer');
        var uls = mainContainer.getElementsByTagName('UL');
        itemHeight = itemHeight + verticalSpaceBetweenListItems;
        for (var no = 0; no < uls.length; no++) {
            uls[no].style.height = itemHeight * boxSizeArray[no] + 'px';
        }

        var leftContainer = document.getElementById('dhtmlgoodies_listOfItems');
        var itemBox = leftContainer.getElementsByTagName('UL')[0];

        document.documentElement.onmousemove = moveDragContent; // Mouse move event - moving draggable div
        document.documentElement.onmouseup = dragDropEnd; // Mouse move event - moving draggable div

        var ulArray = dragDropTopContainer.getElementsByTagName('UL');
        for (var no = 0; no < ulArray.length; no++) {
            ulPositionArray[no] = new Array();
            ulPositionArray[no]['left'] = getLeftPos(ulArray[no]);
            ulPositionArray[no]['top'] = getTopPos(ulArray[no]);
            ulPositionArray[no]['width'] = ulArray[no].offsetWidth;
            ulPositionArray[no]['height'] = ulArray[no].clientHeight;
            ulPositionArray[no]['obj'] = ulArray[no];
        }

        if (!indicateDestionationByUseOfArrow) {
            indicateDestinationBox = document.createElement('LI');
            indicateDestinationBox.id = 'indicateDestination';
            indicateDestinationBox.style.display = 'none';
            document.body.appendChild(indicateDestinationBox);
        }
    }
    window.onload = initDragDropScript;
</script>
<script>
    function fnTransferTransaction() {
        if (Page_ClientValidate("IsRequire")) {
            var strallItems = "";
            var strbox1 = ""
            var saveString = "";

            var uls = dragDropTopContainer.getElementsByTagName('UL');
            for (var no = 0; no < uls.length; no++) {	// LOoping through all <ul>
                var lis = uls[no].getElementsByTagName('LI');
                for (var no2 = 0; no2 < lis.length; no2++) {
                    if (saveString.length > 0) saveString = saveString + ";";

                    var strULName = uls[no].id;
                    saveString = saveString + uls[no].id + '|' + lis[no2].id;

                    if (strULName == 'allItems') {

                        if (strallItems.length > 0) strallItems = strallItems + ";";
                        strallItems = strallItems + lis[no2].id;
                    }
                    else {

                        if (strbox1.length > 0) strbox1 = strbox1 + ";";
                        strbox1 = strbox1 + lis[no2].id;
                    }
                }
            }


            var mySplitbox1Total = '';

            if (strbox1.length > 0) {
                var mySplitbox1 = strbox1.split(";");
                for (var i = 0; i < mySplitbox1.length; i++) {

                    var mySplitbox1WithDash = mySplitbox1[i].split("|");
                    if (i == 0) {
                        mySplitbox1Total = mySplitbox1WithDash[2];
                    }
                    else {
                        mySplitbox1Total += "," + mySplitbox1WithDash[2];
                    }
                }
            }


            var pageUrl = '<%=ResolveUrl("~/GUI/Folio/TransferFolioTransaction.asmx")%>';

            var reservationno = document.getElementById('<%=ddlReservationNo.ClientID %>');
            var valreservationno = reservationno.options[reservationno.selectedIndex].value;

            var foliono = document.getElementById('<%=ddlFolioNo.ClientID %>');
            var valfoliono = foliono.options[foliono.selectedIndex].value;


            if (mySplitbox1Total != '') {
                $.ajax({
                    type: "POST",
                    url: pageUrl + "/TransferTransaction",
                    data: JSON.stringify({ Dest_ResID: valreservationno, DestnationFolioID: valfoliono, strID: mySplitbox1Total }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccessCall,
                    error: OnErrorCall
                });
            }
            else {
                document.getElementById('<%=lblErrorMessage.ClientID %>').innerHTML = "Please Transfer atleast one Transaction.";
                $find('mpeErrorMessage').show();
                return false;
            }
        }
        else {
            return false;
        }
    }

    function OnSuccessCall(response) {        
        if (response.d == false) {
            alert(response.d);
            return false;
        }
        else if (response.d == true) {            
            $find('mpeSuccessMsg').show();
        }
    }


    function OnErrorCall(response) {
        alert(response.d);
        return false;
    }
</script>
<asp:UpdatePanel ID="u" runat="server">
    <ContentTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="content">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="boxtopleft">
                                &nbsp;
                            </td>
                            <td class="boxtopcenter">
                                <asp:Literal ID="litMainHeader" runat="server" Text="Transfer Transaction Folio"></asp:Literal>
                                <%--<asp:HiddenField ID="HdnDestRestID" runat="server" />
                        <asp:HiddenField ID="HdnDestFolioID" runat="server" />--%>
                            </td>
                            <td class="boxtopright">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="boxleft">
                                &nbsp;
                            </td>
                            <td align="left">
                                <div class="box_form">
                                    <table cellpadding="2" cellspacing="2" width="100%" style="padding-bottom: 15px;">
                                        <tr style="background-color: #F3F3F5;">
                                            <td width="40%" style="vertical-align: top; border: 1px solid #ccccce !important;">
                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Literal ID="litName" runat="server"></asp:Literal>
                                                        </td>
                                                        <td width="100px">
                                                            <asp:Literal ID="litCRLimit" runat="server" Text="Balance"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDisplayCRLimit" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="100px">
                                                            <asp:Literal ID="litReservationNo" runat="server" Text="Booking #"></asp:Literal>
                                                        </td>
                                                        <td width="150px">
                                                            <asp:Literal ID="litDisplayReservationNo" runat="server"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litFolioNo" runat="server" Text="Folio No."></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="litDisplayFolioNo" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" align="right" style="font-weight: bold;">
                                                            <asp:Label ID="lblDisplayTotalBalanceFromDB" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="60%" style="vertical-align: top; border: 1px solid #ccccce !important;">
                                                <table cellpadding="2" cellspacing="2" width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="litRoomNo" runat="server" Text="Room No."></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlSearchRoomNo" runat="server" Style="width: 155px !important;"
                                                                AutoPostBack="true" OnSelectedIndexChanged="ddlSearchRoomNo_OnSelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                            <%-- <asp:Literal ID="lit1stCRLimit" runat="server" Text="CR Limit"></asp:Literal>--%>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                            <%--<asp:Literal ID="litDisplay1stCRLimit" runat="server" Text="1000.00"></asp:Literal>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="lit1stReservationNo" runat="server" Text="Booking #"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlReservationNo" runat="server" Style="width: 155px !important;"
                                                                AutoPostBack="true" OnSelectedIndexChanged="ddlReservationNo_OnSelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvReservationNo" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                ValidationGroup="IsRequire" ControlToValidate="ddlReservationNo" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <asp:Literal ID="lit1stFolioNo" runat="server" Text="Folio No."></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlFolioNo" runat="server" Style="width: 155px !important;">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvFolioNo" InitialValue="00000000-0000-0000-0000-000000000000"
                                                                SetFocusOnError="true" CssClass="input-notification error png_bg" runat="server"
                                                                ValidationGroup="IsRequire" ControlToValidate="ddlFolioNo" Display="Dynamic">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <%--<asp:Literal ID="litTransferType" runat="server" Text="Transfer Type"></asp:Literal>--%>
                                                        </td>
                                                        <td>
                                                            <%--<asp:DropDownList ID="ddlTransferType" runat="server" Style="width: 175px !important;">
                                                        <asp:ListItem Selected="True" Text="-Select-" Value="-Select-"></asp:ListItem>
                                                        <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                                    </asp:DropDownList>--%>
                                                        </td>
                                                        <td colspan="2" align="right" style="font-weight: bold;">
                                                            <asp:Label ID="lblTransferBalance" runat="server" Text="0.00"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="dhtmlgoodies_dragDropContainer">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr id="tr1" runat="server" visible="false">
                                                <td width="50%" style="border-right: 1px solid #DCDDDF; padding-left: 5px; padding-right: 5px;
                                                    vertical-align: top;">
                                                    <div id="dhtmlgoodies_listOfItems">
                                                        <div style="height: 500px !important; overflow: auto;">
                                                            <p>
                                                                <asp:Label ID="lblGvHdr1TransNo" runat="server" Text="Book No." Style="padding-right: 22px;"></asp:Label>
                                                                <asp:Label ID="lblGvHdr1Date" runat="server" Text="Date" Style="padding-right: 51px;"></asp:Label>
                                                                <asp:Label ID="lblGvHdr1Amount" runat="server" Text="Amount" Style="padding-right: 50px;"></asp:Label>
                                                                <asp:Label ID="lblGvHdr1Description" runat="server" Text="Description"></asp:Label>
                                                            </p>
                                                            <ul id="allItems">
                                                                <asp:ListView ID="lstTransactionData" runat="server" ItemPlaceholderID="myItemPlaceHolder"
                                                                    DataKeyNames="BookID">
                                                                    <LayoutTemplate>
                                                                        <asp:PlaceHolder ID="myItemPlaceHolder" runat="server"></asp:PlaceHolder>
                                                                    </LayoutTemplate>
                                                                    <ItemTemplate>
                                                                        <li id='<%# Eval("New_SeqNo") %>'>
                                                                            <table>
                                                                                <tr>
                                                                                    <td width="70px">
                                                                                        <%# Eval("BookNo")%>
                                                                                    </td>
                                                                                    <td width="70px">
                                                                                        <%# Eval("New_Date")%>
                                                                                    </td>
                                                                                    <td width="100px">
                                                                                        <%# Eval("New_Amount")%>
                                                                                    </td>
                                                                                    <td>
                                                                                        <%# Eval("Description")%>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </li>
                                                                    </ItemTemplate>
                                                                </asp:ListView>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td width="50%" style="padding-left: 5px; vertical-align: top;">
                                                    <div id="dhtmlgoodies_mainContainer">
                                                        <div style="height: 500px !important; overflow: auto;">
                                                            <p>
                                                                <asp:Label ID="lblGvHdr2TransNo" runat="server" Text="Book No." Style="padding-right: 22px;"></asp:Label>
                                                                <asp:Label ID="lblGvHdr2Date" runat="server" Text="Date" Style="padding-right: 51px;"></asp:Label>
                                                                <asp:Label ID="lblGvHdr2Amount" runat="server" Text="Amount" Style="padding-right: 52px;"></asp:Label>
                                                                <asp:Label ID="lblGvHdr2Description" runat="server" Text="Description"></asp:Label>
                                                            </p>
                                                            <ul id="box1">
                                                                <asp:ListView ID="lstTransgerTransactionData" runat="server" ItemPlaceholderID="myItemPlaceHolder1"
                                                                    DataKeyNames="BookID">
                                                                    <LayoutTemplate>
                                                                        <asp:PlaceHolder ID="myItemPlaceHolder1" runat="server"></asp:PlaceHolder>
                                                                    </LayoutTemplate>
                                                                    <ItemTemplate>
                                                                        <li id='<%# Eval("New_SeqNo") %>'>
                                                                            <table>
                                                                                <tr>
                                                                                    <td width="70px">
                                                                                        <%# Eval("BookNo")%>
                                                                                    </td>
                                                                                    <td width="70px">
                                                                                        <%# Eval("New_Date")%>
                                                                                    </td>
                                                                                    <td width="100px">
                                                                                        <%# Eval("New_Amount")%>
                                                                                    </td>
                                                                                    <td>
                                                                                        <%# Eval("Description")%>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                    </ItemTemplate>
                                                                </asp:ListView>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding: 15px" align="center">
                                                    <%--<asp:Button ID="btnSave" OnClientClick="return saveDragDropNodes()" runat="server"
                    Text="Save" />--%>
                                                    <%--<asp:Button ID="btnSave" runat="server" Text="Transfer Balance" OnClientClick="return saveDragDropNodes()" OnClick="btnSave_Click" />--%>
                                                    <asp:Button ID="btnSave" runat="server" Text="Transfer Balance" ValidationGroup="IsRequire"
                                                        OnClientClick="return fnTransferTransaction();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="divMsg" runat="server" visible="false">
                                        <asp:Label ID="lblNoRecordFoundMsg" runat="server" Text="No Record Found."></asp:Label>
                                    </div>
                                    <ul id="dragContent">
                                    </ul>
                                    <div id="dragDropIndicator">
                                        <%--<img src="images/insert.gif">--%></div>
                                    <%--<div id="saveContent" runat="server">--%>
                                    <div id="saveContent">
                                        <!-- THIS ID IS ONLY NEEDED FOR THE DEMO -->
                                    </div>
                                </div>
                            </td>
                            <td class="boxright">
                            </td>
                        </tr>
                        <tr>
                            <td class="boxbottomleft">
                            </td>
                            <td class="boxbottomcenter">
                            </td>
                            <td class="boxbottomright">
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
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="ddlSearchRoomNo" />
        <asp:PostBackTrigger ControlID="ddlFolioNo" />
        <asp:PostBackTrigger ControlID="ddlReservationNo" />        
    </Triggers>
</asp:UpdatePanel>
<%--document.getelementbyid('<%=savecontent.clientid %>').innerhtml = '<h1>ready to save these nodes:</h1> ' + savestring.replace(/;/g, ';<br>') + '<p>format: id of ul |(pipe) id of li;(semicolon)</p><p>you can put these values into a hidden form fields, post it to the server and explode the submitted value there</p>';        
alert(document.getelementbyid('<%=savecontent.clientid %>').innerhtml);--%>
<div id="errormessage" class="clear">
    <uc1:MsgBox ID="MessageBox" runat="server" />
</div>
<ajx:ModalPopupExtender ID="mpeErrorMessage" runat="server" TargetControlID="hfDateMessage"
    PopupControlID="pnlErrorMessage" BackgroundCssClass="mod_background" CancelControlID="btnErrorMessageOK"
    BehaviorID="mpeErrorMessage">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hfDateMessage" runat="server" />
<asp:Panel ID="pnlErrorMessage" runat="server" Width="350px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="ltrHeaderDateValidate" runat="server" Text="Message"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td align="center" style="padding-bottom: 15px;">
                        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnErrorMessageOK" Text="OK" runat="server" Style="display: inline;
                            padding-right: 10px;" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
<ajx:ModalPopupExtender ID="mpeSuccessMsg" runat="server" TargetControlID="hdnSuccessMsg"
    PopupControlID="pnlSuccessMsg" BackgroundCssClass="mod_background" BehaviorID="mpeSuccessMsg">
</ajx:ModalPopupExtender>
<asp:HiddenField ID="hdnSuccessMsg" runat="server" />
<asp:Panel ID="pnlSuccessMsg" runat="server" Width="350px" Style="display: none;">
    <div class="box_col1">
        <div class="box_head">
            <span>
                <asp:Literal ID="Literal1" runat="server" Text="Message"></asp:Literal></span></div>
        <div class="clear">
        </div>
        <div class="box_form">
            <table cellpadding="2" cellspacing="2" width="100%">
                <tr>
                    <td align="center" style="padding-bottom: 15px;">
                        <asp:Label ID="Label1" runat="server" Text="Transfer Transaction Successfully."></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnSuccessOk" Text="OK" runat="server" OnClick="btnSuccessOk_Click"
                            Style="display: inline; padding-right: 10px;" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Panel>
