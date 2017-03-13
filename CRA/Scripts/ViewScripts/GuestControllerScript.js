

var modeltoCalculate = {};

//Generic function for car filtering

var carSelection = function (atr, selected) {
    $('.carlist li').each(function () {
        if ($(this).attr(atr).toLowerCase() == selected.toLowerCase()) {
            $(this).show();
        }
        else {
            $(this).hide();
        }
    })
}






$(function () {

    var result = {};

    var helperUrl = '/Guest/HelpAjax';

    var selectedCar = {};

    var finalPrice = 0;

    var allValues = [];

    var _gears = ["manual", "automatic", "robotic"];

    var _manufactorers = [];

    var _models = [];

    var dateStart;

    var dateEnd;




    // Price calculation according to dates

    function priceCal() {

        let dayRate = modeltoCalculate.DailyPrice;
        let fine = modeltoCalculate.LateReturnFine;
        dateStart = $('#datepickerStart').datepicker('getDate');
        dateEnd = $('#datepickerEnd').datepicker('getDate');
        let totalDays = (dateEnd - dateStart) / 24 / 60 / 60 / 1000; //we get total days          
        let price = totalDays * dayRate;
        if (price > 0) {
            $('#price').text("Totall price: " + price + "$");
            $('#fine').text("The fine for overdue return is: " + fine + "$ per day");
        }

        else {
            $('#price').text("Interval is Invalid")
        }
        finalPrice = totalDays * dayRate;
    }


    var select = function () {
        priceCal();
    };


  
    // Using of Datepicker Feature : https://jqueryui.com/datepicker/
        $("#datepicker1").datepicker();

        $("#datepicker2").datepicker();

        $("#datepicker3").datepicker();

        $("#datepicker4").datepicker();


        $("#datepickerStart").datepicker(
           {
               onSelect: select,
               onUpdate: select
           }
       );



        $("#datepickerEnd").datepicker(
            {
                onSelect: select,
                onUpdate: select
            }
        );



    // Getting all the data from the server
        $.ajax({
            dataType: "json",
            url: helperUrl,
            success: function (data) {
                result = data;
                console.log(result);
                autocomplete();
            }

        })

///////////////////////////////////////////



    // Autocomplete for freetextsearch - jQuerry UI: https://jqueryui.com/autocomplete/#default

        var autocomplete = function () {
            for(let m of result.AllManufacturers)
            {
                _manufactorers.push(m.manufacturerName.toLowerCase())
            }

            for(let model of result.AllCarModels)
            {
                _models.push(model.NameofModel.toLowerCase())
            }

            allValues = _gears.concat(_manufactorers).concat(_models);

            $('#freeText').autocomplete({
                source: allValues
            });
        }

///////////////////////////////////////////////////////////////


        $("#dialog").dialog({
           autoOpen: false,
           show: {
               effect: "blind",
               duration: 300
           },
           hide: {
               effect: "clip",
               duration: 300
           }
        });


    //Price calculation dialog
        $(".carlist").on("click", ".calculate", function () {

            $("#dialog").dialog("open");

            let clickedCar = $(this).parent();
           
            let modelID = $(this).parent().attr('id');

            let carID = $(this).parent().data('carid');

            selectedCar = result.AllCars.find(function (x) { return x.ID == carID });

            modeltoCalculate = result.AllCarModels.find(function (x) { return x.ID == modelID })

            $('#modelName').text(modeltoCalculate.NameofModel);

            $('#modelId').val(modeltoCalculate.ID);

            $(clickedCar).clone().appendTo('#interested');

          

            
            
        });

    // Price confirmation
        $('#dialog').on('click', '.makeorder', function (event) {

            event.preventDefault();
            let convertedStartDate = moment(dateStart).format("YYYY-M-D").toString();
            let convertedReturnDate = moment(dateEnd).format("YYYY-M-D").toString();

            $.ajax({
                type: 'POST',
                data: { carID: selectedCar.ID, modelID: modeltoCalculate.ID, StartDate: convertedStartDate, SupposedReturn: convertedReturnDate, totallPrice: finalPrice },
                url: '/Customer/GetInfo',
                success: function () {
                    window.location.replace('/Customer/Index');
                    console.log("Success");
                }
            });

        });
   


//Search by transmission
        $('#searchbyTransmission').click(function () {
            $('#failure').empty();
            let selectedGear = $('#gear').find(":selected").text();
            if (selectedGear) {
                
                carSelection("data-gear", selectedGear);
            }
        });


    //Search by Model
        $('#searchbyModel').click(function () {
            $('#failure').empty();
            let selectedModel = $('#model').find(":selected").text();
            if(selectedModel)
            {
               
                carSelection("data-carModel", selectedModel);
            }
        });




        $('#searchbyManufacturer').click(function () {
            $('#failure').empty();
            let selectedManufacturer = $('#manufa').find(":selected").text();
            if (selectedManufacturer)
            {
                console.log('searchbyManufacturer')
                carSelection("data-manufacturer", selectedManufacturer);
            }            
        });


        var dateConvertor = function(cSharpDate)
        {
            return Date.parse(moment(cSharpDate).format('MM/DD/YYYY'));
        }


    //Search by Date
        $('#searchbyDate').click(function () {
            $('#failure').empty();
            $('.alert').remove();

            let date1 = Date.parse($('#datepicker1').val());
            let date2 = Date.parse($('#datepicker2').val());
            console.log(date1);
            console.log(date2);

            if (date2 > date1) {

              
                let cartoRemove = {};

                let deals = result.AllDeals;

                if (date1 || date2) {

                    for (let deal of deals) {

                        if (deal.RealReturn == null) {

                            if (date1 <= dateConvertor(deal.SupposedReturn) && date2 >= dateConvertor(deal.StartDate)) {

                                cartoremove = result.AllCars.find(function (x) { return x.ID == deal.CarID })
                                
                                $('.carlist li').each(function () {
                                    if ($(this).attr("data-carid") !== cartoremove.ID.toString()) {
                                        $(this).show();
                                    }
                                    else {
                                        $(this).hide();
                                    }
                                })
                            }
                        }
                    }
                }

                else {
                    $('.datepicking').prepend("<p class='alert alert-danger'>Please select start and return date</p>");
                }
            }
            else {
                $('.datepicking').prepend("<p class='alert alert-danger'>Time interval is incorrect</p>");

            }
        });

    // Free text search
        $('#freeSearch').click(function () {
            $('#failure').empty();
            let selected = $('#freeText').val();

            selected = selected.trim();

            if( selected != "")
            {
                if (_gears.indexOf(selected.toLowerCase()) > -1)
                {
                    carSelection("data-gear", selected);
                }

                else if (_manufactorers.indexOf(selected.toLowerCase()) > -1)
                {
                    carSelection("data-manufacturer", selected);
                }

                else if (_models.indexOf(selected.toLowerCase()) > -1)
                {
                    carSelection("data-carModel", selected);
                }

                else {

                    $('.carlist li').each(function () {
                        $(this).hide();
                        $('#failure').html("<h3 class='alert alert-dange'>No results !</h3>");
                    })

                }
            }
        });



        $('#reset').click(function () {
            $('#failure').empty();
            $('.alert').remove();
            console.log("Reset Clicked")
            $('.carlist li').each(function () {
                $(this).show();
            })
        });


 
      
     
});
        
  
     



 


  

