﻿

var cartoCalculate = {};

$(function () {

    var result;

    var helperUrl = '/Guest/HelpAjax';

    


    $.getJSON(helperUrl, function (data) {
        async: true;
        result = data;    
        console.log(result);
    });

  
        $("#datepicker1").datepicker();

        $("#datepicker2").datepicker();


        $("#datepicker3").datepicker();

        $("#datepicker4").datepicker();



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

        $(".carlist").on("click", ".calculate", function () {
            $("#dialog").dialog("open");
           
            let carid = $(this).parent().attr('id');

            cartoCalculate = result.AllCarModels.find(function (x) { return x.ID == carid })

            $('#modelName').text(cartoCalculate.NameofModel);

            $('#modelId').val(cartoCalculate.ID);
            
        });



        var carSelection = function (atr,selected) {       
            $('.carlist li').each(function () {
                if ($(this).attr(atr) == selected) {

                    $(this).show();
                }
                else {

                    $(this).hide();
                }
            })
        }



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

            var date1 = Date.parse($('#datepicker1').val());

            var date2 = Date.parse($('#datepicker2').val());
            console.log(date1);

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
            console.log("Reset Clicked")
            $('.carlist li').each(function () {
                $(this).show();
            })
        });


 
        $('#dialog').on('click', '.makeorder', function (event) {

            event.preventDefault();
            //console.log(cartoCalculate)
            $.ajax({
                type: 'POST',
                data: { modelName: cartoCalculate.NameofModel},
                url: '/Customer/GetInfo',
                success: function () {
                    window.location.replace('/Customer/Index');
                    console.log("Success");
                }
            });

        });




        var select = function () {
            priceCal();
        };

        $("#datepickerStart").datepicker(
            {
                onSelect: select,
                onUpdate: select}
        );

      
   
        $("#datepickerEnd").datepicker(
            {
                onSelect: select,
                onUpdate: select
            }
        );

   

   

        function priceCal() {
            //declares
           
            let dayRate = cartoCalculate.DailyPrice;
        

            let dateStart = $('#datepickerStart').datepicker('getDate');
    
            let dateEnd = $('#datepickerEnd').datepicker('getDate');
        

            let totalDays = (dateEnd - dateStart) / 24 / 60 / 60 / 1000; //we get total days
            
            let price = totalDays * dayRate;

            if (price > 0) {
                $('#price').text("Totall price: " + price + "$");
            }
            //more than one day
            console.log("Parked for " + totalDays + " day/s it cost " + (totalDays * dayRate));
       
         
        }










      
});
        
  
     



 


  

