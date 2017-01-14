$(function () {
    
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

        var row = table.insertRow(0);

        row.innerHTML = "<th>ID of Deal</th><th>Start Date</th><th>Supposed Return</th><th>Real Return</th><th>Client ID</th><th>Car ID</th>";

        for (var model of  arrayofDeals)
        {
            if (!isNaN(model.RealReturn)) {

                $(table).append("<tr><td>" + model.ID + "</td><td>" + moment(model.StartDate).format('MM/DD/YYYY') + "</td><td>" + moment(model.SupposedReturn).format('MM/DD/YYYY') +
                    "</td><td>" + "Car is not returned" + "</td><td>" + model.ClientID + "</td><td>" + model.CarID +
                "</td><td><button class ='btn btn-xs btn-warning dealclose'>Close the Deal</button></td></tr>")
            
            }

            else {
                      $(table).append("<tr><td>" + model.ID + "</td><td>" + moment(model.StartDate).format('MM/DD/YYYY') + "</td><td>" + moment(model.SupposedReturn).format('MM/DD/YYYY') +
                      "</td><td>" + moment(model.RealReturn).format('MM/DD/YYYY') + "</td><td>" + model.ClientID + "</td><td>" + model.CarID +
                      "</td></tr>")

                }

        }

        $('.column-one').append(table);

        console.log(result);
    });



  








});