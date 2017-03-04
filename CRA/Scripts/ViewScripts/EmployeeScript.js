﻿$(function () {
    
   
    

    $("#dialog").dialog({
        autoOpen: false,
        show: {
            effect: "blind",
            duration: 1000
        },
        hide: {
            effect: "clip",
            duration: 1000
        }
    });

    $(".column-two").on("click", "#submitClosing", function () {
        $("#dialog").dialog("open");
        return false;
    });









    var result = {};

    var arrayofDeals = [];

    var supposedReturn;

    var realReturn;


    $.getJSON('/Employee/HelpAjax', function (data) {
        
        result = data;

        arrayofDeals = result.AllDeals;

        $('.column-one').empty();

        var table = document.createElement('table');
        
        table.className = "table table-striped table-bordered table-hover";

        table.setAttribute("id", "mytable");

        var header = table.createTHead();

        var row = header.insertRow(0);

        row.innerHTML = "<th>ID of Deal</th><th>Start Date</th><th>Supposed Return</th><th>Real Return</th><th>Client ID</th><th>Car ID</th><th>Deal Closing</th>";

        var body = table.createTBody();

        for (var model of  arrayofDeals)
        {
            if (!isNaN(model.RealReturn)) {

                $(body).append("<tr><td>" + model.ID + "</td><td>" + moment(model.StartDate).format('MM/DD/YYYY') + "</td><td>" + moment(model.SupposedReturn).format('MM/DD/YYYY') +
                    "</td><td>" + "Car is not returned" + "</td><td>" + model.ClientID + "</td><td>" + model.CarID +
                "</td><td><button class ='btn btn-xs btn-warning dealclose' id='"+model.ID+"'>Close the Deal</button></td></tr>")
            
            }

            else {
                      $(body).append("<tr><td>" + model.ID + "</td><td>" + moment(model.StartDate).format('MM/DD/YYYY') + "</td><td>" + moment(model.SupposedReturn).format('MM/DD/YYYY') +
                      "</td><td>" + moment(model.RealReturn).format('MM/DD/YYYY') + "</td><td>" + model.ClientID + "</td><td>" + model.CarID +
                      "</td><td>Deal is closed</td></tr>")

                }

        }
     
        $('.column-one').append(table);

        $('#mytable').DataTable();




        //Closing existing Deal

        $('.column-one').on('click', '.dealclose', function () {

            let clickeddID= $(this).attr('id');
          
            let dealtoClose = arrayofDeals.find(function (x) { return x.ID == clickeddID })

            supposedReturn = dealtoClose.SupposedReturn;
          

            let header = "<h2>Editing deal #" + dealtoClose.ID + "</h2><br /><br />";

            let dealClosingForm = document.createElement("form");
         
            let dateinput = document.createElement("input");
            
            dateinput.type = "text";

            $(dateinput).addClass("form-control col-md-2");

            dateinput.id = "datepickerClosing";

            //dateinput.placeholder = "Please enter today's date";

            let datelabel = document.createElement("Label");

            datelabel.setAttribute('for', 'datepickerClosing')

            datelabel.innerHTML = 'Plese select date of return';
           



            $(dealClosingForm).append(datelabel);

            $(dealClosingForm).append(dateinput);

            $(dealClosingForm).append("<br/> <br/> <br/> <button class='btn btn-primary' id='submitClosing'>Confirm</button>    ")

            $(dealClosingForm).append("<button class='btn btn-warning' id='cancelClosing'>Cancell</button>")

            $('.column-two').append(header);

            $('.column-two').append(dealClosingForm);

            $('#datepickerClosing').datepicker();





            $("#datepickerClosing").change(function () {

                let sResturn = Date.parse(moment(supposedReturn).format('YYYY-MM-DD'));

                let closingDate = Date.parse(moment($("#datepickerClosing").val()).format('YYYY-MM-DD'));

                if (closingDate = sResturn)
                {

                }

                else if (closingDate > sResturn) {
                    //late return
                }

                else {
                    // early return
                }

                console.log(closingDate);

                console.log(sResturn);
            })

        });

        

      


    });



  








});