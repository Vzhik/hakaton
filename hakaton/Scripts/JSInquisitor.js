﻿var JSInquisitorId = undefined;
window.onerror = function (msg, url, line) {
    if (JSInquisitorId != undefined) {
        $.ajax({
            url: "/api/jsinquisitor/PushError",
            type: "POST",
            data: JSON.stringify({ Message: msg, Agent: navigator.userAgent, FileUrl: url, Line: line, PageUrl: window.location.href, UserId: JSInquisitorId, Stack: event.error.stack, Events: events }),
            contentType: 'application/json; charset=utf-8'
        });
    }
};

function getError(msg, url, line) {
    JSON.stringify(
    {
        Message: msg, Agent: navigator.userAgent, Url: url, Line: line, PageUrl: window.location.href, UserId: JSInquisitorId
    });
}

var events = new Array();
var startTime = Date.now();
$(document).ready(function () {
    $(document).bind('click keypress', function (event) {
        addEvent(event);
    });
    $("form").submit(addEvent);
    $("input").bind('focus blur', function () { addEvent(event) });

    function addEvent(event) {
        events.push({ EventType: event.type, Target: $('<div/>').html($(event.target).clone()).html(), TimeAfterStart: Date.now() - startTime });
    }

});




//user's code move to layout
$(document).ready(function () {
    $("#errorButton1").click(function () {
        var qwe = a;
    });
    $("#errorButton2").click(function () {
        throw "Our test exception";
    });
    $("#errorButton3").click(function () {
        throw "Initializing is failed";
    });
    $("#errorButton4").click(function () {
        throw "Epic fail - there are no pizza";
    });
});



