function GetFormattedDate(date) {
    var day = date.getDate().toString().length == 1 ? '0' + date.getDate() : date.getDate();
    var month = (date.getMonth() + 1).toString().length == 1 ? '0' + (date.getMonth() + 1) : date.getMonth() + 1;
    return day + '.' + month;
}

function drawBatchContractsChart() {
    var data = [];
    var mass = ['x'];
    var max = 5;
    var batchChartValues = [JSON.parse($('#jsonHidden').val())];
    $.each(batchChartValues, function () {
        mass.push(this.id);
    });
    data.push(mass);
    var count = batchChartValues[0].mass.length;
    var period = parseInt($('.periodOfBatchChart:checked').val());
    if (period < 3) period = 3;
    if (period > 31) period = 31;
    var i = 31 - period;
    for (; i < count; i++) {
        var date = new Date();
        date.setDate(date.getDate() - count + i + 1);
        var formDate = window.GetFormattedDate(date);
        mass = [formDate];
        $.each(batchChartValues, function () {
            if (this.mass[i] > max) {
                max = this.mass[i];
            }
            mass.push(this.mass[i]);
        });
        data.push(mass);
    }

    var googleData = google.visualization.arrayToDataTable(data);

    var showEvery = period < 7 ? 1 : period < 10 ? 2 : 4;
    // Create and draw the visualization.
    new google.visualization.LineChart(document.getElementById('chart-window')).draw(googleData,
    { //fontSize: 10,
        width: 600,
        height: 300,
        vAxis: { maxValue: max, title: 'Errors' },
        hAxis: { slantedText: false, maxAlternation: 4, showTextEvery: showEvery }
    });
}

function drawTable() {
    $.ajax({
        url: "/Error/GetErrorTable",
        type: "POST",
        data: JSON.stringify({ errorId: $("#errorId").val(), period: parseInt($('.periodOfBatchChart:checked').val()) }),
        contentType: 'application/json; charset=utf-8',
        success: function(html)
        {
            $("#div-for-table").html(html);
        }
    });
}

$(document).ready(function () {
    drawBatchContractsChart();
    drawTable();
    $('.periodOfBatchChart').change(function () {
        drawBatchContractsChart();
        drawTable();
    });
});