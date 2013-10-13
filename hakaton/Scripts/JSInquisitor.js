var JSInquisitorId = undefined;
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
    $(document).bind('click mousedown mouseup', function (event) {
        events.push({ EventType: event.type, Target: $('<div/>').html($(event.target).clone()).html(), TimeAfterStart: Date.now() - startTime });
    });
});




//user's code move to layout
$(document).ready(function () {
    $("#errorButton").click(function () {
        var qwe = a;
        throw 123;
    });
});



