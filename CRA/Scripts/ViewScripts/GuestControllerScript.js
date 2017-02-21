

var modeltoCalculate = {};

//Generic function for car filtering

var carSelection = function (atr, selected) {
    $('.carlist li').each(function () {
        if ($(this).attr(atr) == selected) {
            $(this).show();
        }
        else {
            $(this).hide();
        }
    })
}


// Price calculation according to dates
function priceCal() {

    let dayRate = modeltoCalculate.DailyPrice;
    dateStart = $('#datepickerStart').datepicker('getDate');
    dateEnd = $('#datepickerEnd').datepicker('getDate');
    let totalDays = (dateEnd - dateStart) / 24 / 60 / 60 / 1000; //we get total days          
    let price = totalDays * dayRate;
    if (price > 0) {
        $('#price').text("Totall price: " + price + "$");
    }
    finalPrice = totalDays * dayRate;
}


var select = function () {
    priceCal();
};


$(function () {

    var result;

    var helperUrl = '/Guest/HelpAjax';

    var selectedCar = {};

    var finalPrice = 0;

    var dateStart;

    var dateEnd;
    


    $.getJSON(helperUrl, function (data) {
        async: true;
        result = data;    
        console.log(result);
    });

  
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
           
            let modelID = $(this).parent().attr('id');

            let carID = $(this).parent().data('carid');

            selectedCar = result.AllCars.find(function (x) { return x.ID == carID });

            modeltoCalculate = result.AllCarModels.find(function (x) { return x.ID == modelID })

            $('#modelName').text(modeltoCalculate.NameofModel);

            $('#modelId').val(modeltoCalculate.ID);
            
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
   



        $('#searchbyTransmission').click(function () {
            let selectedGear = $('#gear').find(":selected").text();
            if (selectedGear) {
                console.log("Select Gear");
                carSelection("data-gear", selectedGear);
            }
        });



        $('#searchbyModel').click(function () {
                     
            let selectedModel = $('#model').find(":selected").text();
            if(selectedModel)
            {
                console.log('searchbyModel')
                carSelection("data-carModel", selectedModel);
            }
        });




        $('#searchbyManufacturer').click(function () {
            let selectedManufacturer = $('#manufa').find(":selected").text();
            if (selectedManufacturer)
            {
                console.log('searchbyManufacturer')
                carSelection("data-manufacturer", selectedManufacturer);
            }            
        });




        $('#searchbyDate').click(function () {

            $('.alert').remove();

            let date1 = Date.parse($('#datepicker1').val());
            let date2 = Date.parse($('#datepicker2').val());
            console.log(date1);
            console.log(date2);

            let deals = result.AllDeals;

            if (date1 || date2) {

                for (let deal of deals) {


                }

            }

            else {
                $('.datepicking').prepend("<p class='alert alert-danger'>Please select start and return date</p>");
            }
        });


        $('#freeSearch').click(function () {
            let selected = $('#freeText').val();
            if( selected != "")
            {
                console.log("FreeTextSeach")
                carSelection(selected);
            }
        });



        $('#reset').click(function () {
            $('.alert').remove();
            console.log("Reset Clicked")
            $('.carlist li').each(function () {
                $(this).show();
            })
        });


 
      
     
});
        
  
     



 


  

