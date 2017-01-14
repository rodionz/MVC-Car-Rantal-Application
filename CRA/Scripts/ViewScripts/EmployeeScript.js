$(function () {
    
    //$('table').DataTable();
    $('footer').addClass('bottomfooter');


    var result = {};

    var arrayofDeals = [];


    $.getJSON('/Employee/HelpAjax', function (data) {
        
        result = data;

        arrayofDeals = result.AllDeals;

        $('.column-one').empty();

      
         
      

        

        $('table').append("<th>ID of Deal</th><th>Start Date</th><th>Supposed Return</th><th>Real Return</th><th>Client ID</th><th>Car ID</th>");

        for (var model of  arrayofDeals)
        {

            $('table').append("<tr><td>" + model.ID + "</td><td>" + moment(model.StartDate).format('MM/DD/YYYY') + "</td><td>" + moment(model.SupposedReturn).format('MM/DD/YYYY') +
                "</td><td>"
                + moment(model.RealReturn).format('MM/DD/YYYY') + "</td><td>" + model.ClientID + "</td><td>" + model.CarID +
                "</td><td>" + isNaN(model.RealReturn) ?  "<button class ='btn btn-xs btn-warning dealclose'>Close the Deal</button></td></tr>" : "</td></tr>")
        }

        $('.column-one').append('table');

        console.log(result);
    });



  








});