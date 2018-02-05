
var dealRquestResult = {};

var arrayofDeals = [];

var arrayofCars = [];

var arrayofModels = [];

var closingDate;

var dealtoClose;

var cartoReturn;

var modeltoReturn;

var supposedReturn;


var listofDeals = function () {

    $.getJSON('/Employee/HelpAjax', function (data) {

        dealRquestResult = data;

        console.log(dealRquestResult)

        arrayofDeals = dealRquestResult.AllDeals;

        arrayofModels = dealRquestResult.AllCarModels;

        arrayofCars = dealRquestResult.AllCars;

        $('.column-one').empty();

        var table = document.createElement('table');

        table.className = "table table-striped table-bordered table-hover";

        table.setAttribute("id", "mytable");

        var header = table.createTHead();

        var row = header.insertRow(0);

        row.innerHTML = "<th>ID of Deal</th><th>Start Date</th><th>Supposed Return</th><th>Real Return</th><th>Client ID</th><th>Car ID</th><th>Car Number</th><th>Deal Closing</th>";

        var body = table.createTBody();


        function dealCarNumber(carid) {

         let car = arrayofCars.find(function (x) {return x.ID == carid})

         return car.CarNumber;
        }

        for (var model of  arrayofDeals)
        {
            if (!isNaN(model.RealReturn)) {

                $(body).append("<tr><td>" + model.ID + "</td><td>" + model.StartDate + "</td><td>" + model.SupposedReturn +
                    "</td><td>" + "Car is not returned" + "</td><td>" + model.ClientID + "</td><td>" + model.CarID + "</td><td>" + dealCarNumber(model.CarID) +
                "</td><td><button class ='btn btn-xs btn-warning dealclose' id='" + model.ID + "'>Close the Deal</button></td></tr>")

            }

            else {
                $(body).append("<tr><td>" + model.ID + "</td><td>" + model.StartDate + "</td><td>" + model.SupposedReturn +
                    "</td><td>" + model.RealReturn + "</td><td>" + model.ClientID + "</td><td>" + model.CarID + "</td><td>" + dealCarNumber(model.CarID) +
                "</td><td>Deal is closed</td></tr>")
            }
        }

        $('.column-one').append(table);

        $('#mytable').DataTable();

    });

};


function dateisValid(date) {
    
    // date validation - not in use
    return true;
}



    $(function () {
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
           
            if(dateisValid($("#datepickerClosing").val()))
            {
                $("#dialog").dialog("open");
                return false;
            }
        });

        listofDeals();

        //Closing existing Deal

        $('.column-one').on('click', '.dealclose', function () {
           
                let clickeddID = $(this).attr('id');

                dealtoClose = arrayofDeals.find(function (x) { return x.ID == clickeddID })

                supposedReturn = dealtoClose.SupposedReturn;

                cartoReturn = arrayofCars.find(function (x) { return x.ID == dealtoClose.CarID })

                modeltoReturn = arrayofModels.find(function (x) { return x.ID == cartoReturn.ModelID })

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

                $('#datepickerClosing').datepicker({                   
                    changeYear: true});

            
        })

            var date2;

            $('.column-two').on('change', '#datepickerClosing', function () {

                $('#lateRetrunFine').text("");
               
                let date1 = supposedReturn.split("/");

                let sResturn = new Date(date1[2],date1[1] - 1,date1[0]);

                 date2 = $("#datepickerClosing").val().split("/");

                closingDate = new Date(date2[2], date2[0] - 1, date2[1]);

                let fine;

                if (closingDate > sResturn) {

                    let differenceinDays = closingDate - sResturn;
                    fine = modeltoReturn.LateReturnFine * (differenceinDays / (1000 * 60 * 60 * 24));
                    $('#lateRetrunFine').text("Don't forget to charge the customer for the fine of " + fine + "$");

                }

                else {
                    $('#lateRetrunFine').text("Theris no fine to charge, you can close the deal");
                }
            })


            $('#dialog').on('click', '#confirm', function () {
             
                    let dateString = moment(closingDate).format("M-D-YYYY");
                    $.ajax({
                        type: "GET",
                        data: { dealID: dealtoClose.ID, RealReturn: dateString },
                        url: '/Employee/CloseTheDeal',
                        success: function () {
                            $('#lateRetrunFine').text("");
                            $('.column-two').empty();
                            $("#dialog").dialog("close");
                            listofDeals();
                        }
                    });               
            });


            $('#dialog').on('click', '#cancell', function () {

                $("#dialog").dialog("close");

            });

            $('main').on('click', '#cancelClosing', function () {
                $('.column-two').empty();
            })
        });
    












