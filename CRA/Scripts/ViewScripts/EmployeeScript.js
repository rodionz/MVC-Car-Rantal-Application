﻿$(function () {
    
    //$('table').DataTable();
    $('footer').addClass('bottomfooter');


    var result = {};

    var arrayofDeals = [];


    $.getJSON('/Employee/HelpAjax', function (data) {
        
        result = data;

        arrayofDeals = result.AllDeals;

        $('.column-one').empty();

        var table = document.createElement('table');

        table.className = "table";

        var header = table.createTHead();

        var row = header.insertRow(0);

        row.innerHTML = "<th>ID of Deal</th><th>Start Date</th><th>Supposed Return</th><th>Real Return</th><th>Client ID</th><th>Car ID</th><th>Deal Closing</th>";

        var body = table.createTBody();

        for (var model of  arrayofDeals)
        {
            if (!isNaN(model.RealReturn)) {

                $(body).append("<tr><td>" + model.ID + "</td><td>" + moment(model.StartDate).format('MM/DD/YYYY') + "</td><td>" + moment(model.SupposedReturn).format('MM/DD/YYYY') +
                    "</td><td>" + "Car is not returned" + "</td><td>" + model.ClientID + "</td><td>" + model.CarID +
                "</td><td><button class ='btn btn-xs btn-warning dealclose'>Close the Deal</button></td></tr>")
            
            }

            else {
                      $(body).append("<tr><td>" + model.ID + "</td><td>" + moment(model.StartDate).format('MM/DD/YYYY') + "</td><td>" + moment(model.SupposedReturn).format('MM/DD/YYYY') +
                      "</td><td>" + moment(model.RealReturn).format('MM/DD/YYYY') + "</td><td>" + model.ClientID + "</td><td>" + model.CarID +
                      "</td><td>Deal is closed</td></tr>")

                }

        }
        $(table).DataTable();
        $('.column-one').append(table);

        console.log(result);
    });



  








});