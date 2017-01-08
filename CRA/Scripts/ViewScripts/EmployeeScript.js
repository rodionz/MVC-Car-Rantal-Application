$(function () {
    

    $('footer').addClass('bottomfooter');


    var result = {};

    var arrayofDeals = [];


    $.getJSON('/Employee/HelpAjax', function (data) {
        
        result = data;

        arrayofDeals = result.AllDeals;

        $('.column-one').empty();

        var table = document.createElement('table');

        table.className = "table table-bordered table-hover";

        var row = table.insertRow(0);

        row.innerHTML = "<th>ID of Deal</th><th>Start Date</th><th>Supposed Return</th><th>Real Return</th><th>Client ID</th><th>Car ID</th>";

        for (var model of  arrayofDeals)
        {

            $(table).append("<tr><td>" + model.ID + "</td><td>" + model.StartDate + "</td><td>" + model.SupposedReturn + "</td><td>" + model.RealReturn + "</td><td>" + model.ClientID + "</td><td>" + model.CarID +
                "</td><td><span class='editdelete' id=" + model.ID + "><button class='btn btn-xs btn-primary dealEdit'>Edit Deal</button><button class='btn btn-xs btn-danger dealDelete'>Delete Deal</button></span></td></tr>")
        }

        $('.column-one').append(table);

        console.log(result);
    });



  








});