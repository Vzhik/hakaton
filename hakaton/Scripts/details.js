$(document).ready(function () {
    $('.typeCheckbox').change(function () {
        var types = new Array();
        $.each($('.typeCheckbox:checked'), function () {
            types.push($(this).attr('id'));
        });
        if (types.length == 0) {
            $(this).click();
            return;
        }

        $.each($('.features-table .eventType'), function () {
            if ($.inArray($(this).text(), types) != -1) {
                $(this).parents("tr").show();
            }
            else {
                $(this).parents("tr").hide();
            }
        });
    });

    $('.showValue').click(function () {
        $(this).siblings(".dialog").dialog({width:1000, title:'More details', resizable:true});
    });
});