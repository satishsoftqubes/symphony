function fnCleardate(para1) {
    document.getElementById(para1).value = '';
}

function fnCheckTabKey(e) {
    if (e.keyCode == 9) {
        return true
    }
    else {
        return false;
    }
}

function stopKey(evt) {
    var evt = (evt) ? evt : ((event) ? event : null);
    var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
    if ((evt.keyCode == 8) && (node.type == "text")) { return false; }
    else if ((evt.keyCode == 9) && (node.type == "text")) { return true; }
    else if ((evt.keyCode == 46) && (node.type == "text")) { return false; }
    else { return false; }
}

function fnGetValidDateFormat(date, dateFormat) {
    var dateToReturn = '';

    if (dateFormat == 'MM/dd/yyyy') {
        var arrDate = date.split('/');

        dateToReturn = arrDate[1] + ' ';
        dateToReturn = dateToReturn + fnGetMonthValue(arrDate[0]) + ' ';
        dateToReturn = dateToReturn + arrDate[2];
    }
    else if (dateFormat == 'MMM/dd/yyyy') {
        var arrDate = date.split('/');

        dateToReturn = arrDate[1] + ' ';
        dateToReturn = dateToReturn + arrDate[0] + ' ';
        dateToReturn = dateToReturn + arrDate[2];
    }
    else if (dateFormat == 'dd/MM/yyyy') {
        var arrDate = date.split('/');

        dateToReturn = arrDate[0] + ' ';
        dateToReturn = dateToReturn + fnGetMonthValue(arrDate[1]) + ' ';
        dateToReturn = dateToReturn + arrDate[2];
    }
    else if (dateFormat == 'dd/MMM/yyyy') {
        var arrDate = date.split('/');

        dateToReturn = arrDate[0] + ' ';
        dateToReturn = dateToReturn + arrDate[1] + ' ';
        dateToReturn = dateToReturn + arrDate[2];
    }
    else if (dateFormat == 'yyyy/MM/dd') {
        var arrDate = date.split('/');

        dateToReturn = arrDate[2] + ' ';
        dateToReturn = dateToReturn + fnGetMonthValue(arrDate[1]) + ' ';
        dateToReturn = dateToReturn + arrDate[0];
    }
    else if (dateFormat == 'yyyy/MMM/dd') {
        var arrDate = date.split('/');

        dateToReturn = arrDate[2] + ' ';
        dateToReturn = dateToReturn + arrDate[1] + ' ';
        dateToReturn = dateToReturn + arrDate[0];
    }
    else if (dateFormat == 'MM-dd-yyyy') {
        var arrDate = date.split('-');

        dateToReturn = arrDate[1] + ' ';
        dateToReturn = dateToReturn + fnGetMonthValue(arrDate[0]) + ' ';
        dateToReturn = dateToReturn + arrDate[2];
    }
    else if (dateFormat == 'MMM-dd-yyyy') {
        var arrDate = date.split('-');

        dateToReturn = arrDate[1] + ' ';
        dateToReturn = dateToReturn + arrDate[0] + ' ';
        dateToReturn = dateToReturn + arrDate[2];
    }
    else if (dateFormat == 'dd-MM-yyyy') {
        var arrDate = date.split('-');

        dateToReturn = arrDate[0] + ' ';
        dateToReturn = dateToReturn + fnGetMonthValue(arrDate[1]) + ' ';
        dateToReturn = dateToReturn + arrDate[2];
    }
    else if (dateFormat == 'dd-MMM-yyyy') {
        var arrDate = date.split('-');

        dateToReturn = arrDate[0] + ' ';
        dateToReturn = dateToReturn + arrDate[1] + ' ';
        dateToReturn = dateToReturn + arrDate[2];
    }
    else if (dateFormat == 'yyyy-MM-dd') {
        var arrDate = date.split('-');

        dateToReturn = arrDate[2] + ' ';
        dateToReturn = dateToReturn + fnGetMonthValue(arrDate[1]) + ' ';
        dateToReturn = dateToReturn + arrDate[0];
    }
    else if (dateFormat == 'yyyy-MMM-dd') {
        var arrDate = date.split('-');

        dateToReturn = arrDate[2] + ' ';
        dateToReturn = dateToReturn + arrDate[1] + ' ';
        dateToReturn = dateToReturn + arrDate[0];
    }

    return dateToReturn;
}

function fnGetMonthValue(monthNumber) {
    if (monthNumber == '1' || monthNumber == '01') {
        return 'Jan';
    }
    else if (monthNumber == '2' || monthNumber == '02') {
        return 'Feb';
    }
    else if (monthNumber == '3' || monthNumber == '03') {
        return 'Mar';
    }
    else if (monthNumber == '4' || monthNumber == '04') {
        return 'Apr';
    }
    else if (monthNumber == '5' || monthNumber == '05') {
        return 'May';
    }
    else if (monthNumber == '6' || monthNumber == '06') {
        return 'Jun';
    }
    else if (monthNumber == '7' || monthNumber == '07') {
        return 'Jul';
    }
    else if (monthNumber == '8' || monthNumber == '08') {
        return 'Aug';
    }
    else if (monthNumber == '9' || monthNumber == '09') {
        return 'Sep';
    }
    else if (monthNumber == '10') {
        return 'Oct';
    }
    else if (monthNumber == '11') {
        return 'Nov';
    }
    else if (monthNumber == '12') {
        return 'Dec';
    }
}