window.onerror = function (msg, url, line) {
    $.ajax({
        url: "api/jsinquisitor/PushError",
        type: "POST",
        data: JSON.stringify({ Message: msg, Agent: navigator.userAgent, FileUrl: url, Line: line, PageUrl: window.location.href, UserId: "7f9e812d-807b-4773-a9ce-854f11c408c3", Stack: event.error.stack, Events: events  }),
        contentType: 'application/json; charset=utf-8'
    });
};

function getError(msg, url, line) {
    JSON.stringify(
    {
        Message: msg, Agent: navigator.userAgent, Url: url, Line: line, PageUrl: window.location.href, UserId: "7f9e812d-807b-4773-a9ce-854f11c408c3"
    });
}

var events = new Array();
var startTime = Date.now();
$(document).ready(function () {
    $(document).bind('click mousedown mouseup', function (event) {
        events.push({ EventType: event.type, Target: $('<div/>').html($(event.target).clone()).html(), TimeAfterStart: Date.now() - startTime });
    });
});




//user's code
$(document).ready(function () {
    $("#errorButton").click(function () {
        var qwe = a;
        throw 123;
    });
});
//window.qbaka || (function(a,c){a.__qbaka_eh=a.onerror;a.__qbaka_reports=[];a.onerror=function(){a.__qbaka_reports.push(arguments);if(a.__qbaka_eh)try{a.__qbaka_eh.apply(a,arguments)}catch(b){}};a.onerror.qbaka=1;a.qbaka={report:function(){a.__qbaka_reports.push([arguments, new Error()]);},customParams:{},set:function(a,b){qbaka.customParams[a]=b},exec:function(a){try{a()}catch(b){qbaka.reportException(b)}},reportException:function(){}};var b=c.createElement("script"),e=c.getElementsByTagName("script")[0],d=function(){e.parentNode.insertBefore(b,e)};b.type="text/javascript";b.async=!0;b.src="//cdn.qbaka.net/reporting.js";"[object Opera]"==a.opera?c.addEventListener("DOMContentLoaded",d):d();qbaka.key="ae77b7cddf08f8f2d85bd34a5501b3b2"})(window,document);qbaka.options={autoStacktrace:1,trackEvents:1};




//(function(){extend(qbaka,{report:reportAny,reportException:reportAny});
//if(!qbaka.options){qbaka.options={}
//}qbaka.custom=qbaka.custom||{};
//var LIB_NODE_ID="qbaka";
//var REPORTING_URL=!qbaka.options.reportingUrl?("https:"==document.location.protocol?"https:":"http:")+"//report.qbaka.net/":qbaka.options.reportingUrl;
//var KEY_PARAM_NAME="key";
//var VERSION=5;
//var MAX_STACKTRACE_LENGTH=2000;
//var MAX_CONTENT_LENGTH=128;
//var MAX_STACKTRACE_LINES=64;
//var MAX_STACKTRACE_URL_LENGTH=128;
//var READY_STATES={uninitialized:1,loading:1,interactive:2,complete:3};
//READY_STATES[null]=null;
//var _lastEvent=null;
//var _eventsQueue=[];
//var EVENTS_QUEUE_SIZE=5;
//var functionNameRegexp=/function ([\w\d\-_]+)\s*\(/;
//var XMLHTTPREQUEST_CALLBACKS_NAMES=["onreadystatechange","onerror","onload","onprogress","ontimeout"];
//var NATIVE_JSON_SUPPORT=window.JSON&&isNative(JSON.stringify);
//var lastExceptionSent={at:0};
//if(window.onerror&&!window.onerror.qbaka){window.__qbaka_eh=window.onerror
//}window.onerror=onError;
//if(qbaka.options.trackEvents){registerListener(window,"click",trackEvent);
//registerListener(window,"submit",trackEvent)
//}if(qbaka.options.autoTryCatch||qbaka.options.autoStacktrace){wrapAllWithTryCatch()
//}handleData([]);
//registerListener(window,"load",onLoad);
//if(!qbaka.key){var libNode=document.getElementById(LIB_NODE_ID);
//if(!libNode){return
//}var keyIndex=libNode.src.indexOf(KEY_PARAM_NAME+"=");
//qbaka.key=libNode.src.substr(keyIndex+KEY_PARAM_NAME.length+1)
//}var pingImage=window.Image?new Image():document.createElement("img");
//pingImage.src=REPORTING_URL+qbaka.key+"/ping";
//var userAgent=navigator.userAgent.toLowerCase();
//if(window.__qbaka_reports&&__qbaka_reports.length>0){var result=[];
//for(var i=0;
//i<__qbaka_reports.length;
//i++){var report=__qbaka_reports[i];
//if(report.splice){reportString(report[0][0],report[1])
//}else{result.push(buildOnErrorReport(report[0],report[1],report[2]))
//}}sendReports(result)
//}var ie=/msie/i.test(userAgent);
//var chrome=/chrome/i.test(userAgent);
//var firefox=/firefox/i.test(userAgent);
//var mobile=/(android|ios|mobi|symbian|midp)/i.test(userAgent);
//var checkAdBlock=false;
//var adBlock=null;
//if(checkAdBlock){detectAdBlock();
//document.addEventListener("DOMContentLoaded",function(){if(!adBlock){setTimeout(function(){detectAdBlock()
//},100)
//}},false)
//}function safe(f,c){try{if(!f||typeof(f)=="undefined"){return f
//}if(typeof(f)=="string"){f=new Function(f)
//}if(!isFunction(f)){return f
//}if(f.$afe){return f.$afe
//}var $safeFunc=function $safeFunc(){try{return f.apply(this,arguments)
//}catch(e){if(c){try{c.apply(this,arguments)
//}catch(ignored){}}if(isString(e)){e={message:e}
//}else{if(e instanceof Error){if(reportException(e)){logException(e)
//}}else{log("Unknown exception type thrown by user code: "+e)
//}}log("Rethrowing exception, following exception IS NOT QBAKA ERROR");
//throw e
//}};
//f.$afe=$safeFunc;
//return $safeFunc
//}catch(e){return f
//}}function logException(e){log("Exception in callback occurred, sent to qbaka servers");
//var stack=e.stack;
//if(!stack||!/Error: /.test(stack.split("\n")[0])){log(e.message)
//}if(stack){log(stack)
//}}function wrapMethod(obj,name){obj[name]=safe(obj[name])
//}function eventOfException(event){trackEvent(event);
//if(_eventsQueue.length>0){_eventsQueue[_eventsQueue.length-1].reason=true
//}}function wrapEventRegisteringFunction(obj){var oldRegister=obj.addEventListener;
//var oldUnregister=obj.removeEventListener;
