var days = new Array("so", "mo", "to", "we", "th", "fr", "sa");
var today = new Date();
var month_big = new Array("1", "3", "5", "7", "8", "10", "12");
var month_small = new Array("2", "4", "6", "9", "11");
var seperator = "-";
var calendar = document.getElementById("Calendar");
var cal_parent = calendar.parentNode;
var cal_width = ((calendar.clientWidth < 150) ? 150 : calendar.clientWidth);
var cal_height = calendar.clientHeight;
var cal_x = calendar.offsetLeft;
var cal_y = calendar.offsetTop;
calendar.style.cursor = "pointer";
calendar.onblur = hideCalendar;
calendar.onclick = showCalendar;
var pan_height = cal_width / 7 - 1;
var year;
//show the current time
var nowtime = new Date();
//find the current month
var thismonth = nowtime.getMonth().toString + "." + nowtime.getYear().toString();
document.getElementById("monthyear").innerHTML = thismonth;

function startTime(id) {
    var nowtime = new Date();
    var m = nowtime.getMinutes();
    var s = nowtime.getSeconds();
    m = checkTime(m);
    s = checkTime(s);
    document.getElementById("id").innerHTML = nowtime.getHours() + ":" + m + ":" + s;
}

function checkTime(i)
{
    if (i < 10)
    {
        i = "0" + i;
    }
}



function monthtype()
{
    var month = document.getElementById("monthyear").innerHTML.substring(0, document.getElementById("monthyear").innerHTML.indexOf('.'));
    if (month == "januar" || month == "mars" || month == "mai" || month == "juli" || month == "august" || month == "oktober" || month == "desember")
    {
        monthtype = "big";
    }
    else if (month == "februar")
    {
        if (year%400 == 0)
        {
            monthtype = "februn"
        }
        else
        {
            monthtype = "feb";
        }
    }
    else
    {
        monthtype = "small";
    }
    return monthtype;
}

function firstDay()
{
    var firstday = new Date("01." + document.getElementById("monthyear").innerHTML);
    var firstdate = firstday.getDay();
    if (firstdate == 1) {
        document.getElementById("ma0").innerHTML = "1";
    }
}

function mappingDate()
{
    var firstday = new Date("01." + document.getElementById("monthyear").innerHTML);
    var firstdate = firstday.getDay();
    if (firstdate == 1)
    {
        document.getElementById("ma0").innerHTML = "1";
    }
    /*var dayrow0 = ["so0", "ma0", "th0", "on0", "tu0", "fr0", "sa0"];
    for (i = 0; i < 6; i++) 
    {
        day = document.getElementById(dayrow0[i]).innerHTML;
        if (monthtype == "big" && day == 30)
        {
             document.getElementById(dayrow0[i + 1]).innerHTML = "1";
        }
        if (monthtype == "big" && day < 30) {
            document.getElementById(dayrow0[i + 1]).innerHTML = (parseInt(document.getElementById(dayrow0[i + 1]).innerHTML) + 1).toString();
        }
        if (monthtype == "small" && day == 31) {
            document.getElementById(dayrow0[i + 1]).innerHTML = "1";
        }
        if (monthtype == "small" && day < 31) {
            document.getElementById(dayrow0[i + 1]).innerHTML = (parseInt(document.getElementById(dayrow0[i + 1]).innerHTML) + 1).toString();
        }
        if (monthtype == "feb" && day == 2) {
            document.getElementById(dayrow0[i + 1]).innerHTML = "1";
        }
        if (monthtype == "big" && day < 30) {
            document.getElementById(dayrow0[i + 1]).innerHTML = (parseInt(document.getElementById(dayrow0[i + 1]).innerHTML) + 1).toString();
        }
    }
    var dayrow5 = ["so5", "ma5", "th5", "on5", "tu5", "fr5", "sa5"];
    for (i = 0; i < 6; i++) {
        day = document.getElementById(dayrow0[i]).innerHTML;
        if (monthtype == "big" && day == 31) {
            document.getElementById(dayrow0[i + 1]).innerHTML = "1";
        }
        if (monthtype == "big" && day < 31) {
            document.getElementById(dayrow0[i + 1]).innerHTML = (parseInt(document.getElementById(dayrow0[i + 1]).innerHTML) + 1).toString();
        }
    }
    for (i = 1; i < 5; i++)
    {
        document.getElementById("ma" + i.toString()).innerHTML = (parseInt(document.getElementById("ma" + i).innerHTML) + 1).toString();
        document.getElementById("th" + i.toString()).innerHTML = (parseInt(document.getElementById("th" + i).innerHTML) + 1).toString();
        document.getElementById("we" + i.toString()).innerHTML = (parseInt(document.getElementById("we" + i).innerHTML) + 1).toString();
        document.getElementById("tu" + i.toString()).innerHTML = (parseInt(document.getElementById("tu" + i).innerHTML) + 1).toString();
        document.getElementById("fr" + i.toString()).innerHTML = (parseInt(document.getElementById("fr" + i).innerHTML) + 1).toString();
        document.getElementById("sa" + i.toString()).innerHTML = (parseInt(document.getElementById("sa" + i).innerHTML) + 1).toString();
        document.getElementById("so" + (i+1).toString()).innerHTML = (parseInt(document.getElementById("so" + i).innerHTML) + 1).toString();
    }*/
}

function getDayCell() {
    var today = new Date();
    if (today.getDay() == 0) {
        if (today.getDate() < 8)
        {
            document.getElementById("so1").focus();
        }
        else if (today.getDate() > 7 && today.getDate() < 15) {
            document.getElementById("so2").focus();
        }
        else if (today.getDate() > 14 && today.getDate() < 22) {
            document.getElementById("so3").focus();
        }
        else if (today.getDate() > 21 && today.getDate() < 29) {
            document.getElementById("so4").focus();
        }
        else {
            document.getElementById("so5").focus();
        }
    }
    else if (today.getDay() == 1) {
        if (today.getDate() < 8) {
            document.getElementById("ma1").focus();
        }
        else if (today.getDate() > 7 && today.getDate() < 15) {
            document.getElementById("ma2").focus();
        }
        else if (today.getDate() > 14 && today.getDate() < 22) {
            document.getElementById("ma3").focus();
        }
        else if (today.getDate() > 21 && today.getDate() < 29) {
            document.getElementById("ma4").focus();
        }
        else {
            document.getElementById("ma5").focus();
        }
    }
    else if (today.getDay() == 1) {
        if (today.getDate() < 8) {
            document.getElementById("th1").focus();
        }
        else if (today.getDate() > 7 && today.getDate() < 15) {
            document.getElementById("th2").focus();
        }
        else if (today.getDate() > 14 && today.getDate() < 22) {
            document.getElementById("th3").focus();
        }
        else if (today.getDate() > 21 && today.getDate() < 29) {
            document.getElementById("th4").focus();
        }
        else {
            document.getElementById("th5").focus();
        }
    }
}

function hideCalendar() {
    var cal_body = document.getElementById("cal_body");
    if (cal_body != undefined) {
        cal_body.parentNode.removeChild(cal_body);
    }
}

function showCalendar() {
    var cal_body = document.getElementById("cal_body");
    if (cal_body != undefined) {
        cal_body.parentNode.removeChild(cal_body);
    }
    else
    {
        var cal_body = document.getElementById("cal_body");
        cal_body.style.id = "cal_body";
        cal_body.style.height = "auto";
        cal_body.style.width = cal_width + "px";
        cal_body.style.overflow = cal_width + "px";
        cal_body.style.position = "absolute";
        cal_body.style.zIndex = "9";
        cal_body.style.left = cal_x + "px";
        cal_body.style.top = (cal_y + cal_height + 5) + "px";
        cal_body.style.border = "solid 1px #CCCCCC";
    }

    cal_body.onmousemove = function ()
    {
        calendar.onblur() = undefined;
        
    }

    cal_body.onmouseout = function ()
    {
        calendar.focus();
        calendar.onblur = hideCalendar;
    }

    cal_parent.appendChild(cal_body);

    var line1 = document.createElement("DIV");
    line1.style.width = cal_width + "px";
    line1.style.height = pane_height + "px";
    line1.style.backgroundColor = "#0FF";

    var btn1 = document.createElement("DIV");
    btn1.style.width = (cal_width / 3 - 3) + "px";
    btn1.style.height = pane_height + "px";
    btn1.style.lineHeight = pane_height + "px";
    btn1.style.textAlign = "center";
    btn1.innerHTML = "<";
    btn1.style.cursor = "pointer";
    btn1.style.cssFloat = "left";
    btn1.onclick = function () {
        if (isValidated()) {
            var old_year = parseInt(document.getElementById("input_year").value);
            if (old_year > 1960) {
                var year = old_year - 1;
                var month = parseInt(document.getElementById("input_month").value);
                var val = year + separator + month + separator + 1;
                init(val);
            }
        }
    };
    line1.appendChild(btn1);

    var input_year = document.createElement("INPUT");
    input_year.id = "input_year";
    input_year.style.width = (cal_width / 3) + "px";
    input_year.style.height = "70%";
    input_year.style.cssFloat = "left";
    input_year.style.textAlign = "center";
    input_year.onchange = function () {
        changed();
    };
    line1.appendChild(input_year);

    var btn2 = document.createElement("DIV");
    btn2.style.width = (cal_width / 3 - 3) + "px";
    btn2.style.height = pane_height + "px";
    btn2.style.lineHeight = pane_height + "px";
    btn2.style.textAlign = "center";
    btn2.innerHTML = ">";
    btn2.style.cursor = "pointer";
    btn2.style.cssFloat = "left";
    btn2.onclick = function () {
        if (isValidated()) {
            var old_year = parseInt(document.getElementById("input_year").value);
            if (old_year < 2050) {
                var year = old_year + 1;
                var month = parseInt(document.getElementById("input_month").value);
                var val = year + separator + month + separator + 1;
                init(val);
            }
        }
    };
    line1.appendChild(btn2);

    var line2 = document.createElement("DIV");
    line2.style.width = cal_width + "px";
    line2.style.height = pane_height + "px";
    line2.style.backgroundColor = "#0FF";

    var input_month = document.createElement("INPUT");
    input_month.id = "input_month";
    input_month.style.width = (cal_width / 3) + "px";
    input_month.style.height = "70%";
    input_month.style.cssFloat = "left";
    input_month.style.textAlign = "center";
    input_month.onchange = function () {
        changed();
    };
    line2.appendChild(input_month);

    cal_body.appendChild(line1);
    cal_body.appendChild(line2);

    for (var i = 0; i < 7; i++) {
        var pane = document.createElement("DIV");
        pane.className = "pane";
        pane.style.width = pane_height + "px";
        pane.style.height = pane_height + "px";
        pane.style.lineHeight = pane_height + "px";
        pane.style.textAlign = "center";
        pane.style.cssFloat = "left";
        pane.innerHTML = days[i];
        cal_body.appendChild(pane);
    }
    init(calendar.value);    
}    

