

$(function () {

    var result;

    var helperUrl = '/Guest/HelpAjax';

    var cartoCalculate = {};


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


        //$('.orderCar').click(function (e) {
        //    e.preventDefault();
        //    var carid = $(this).attr('id');

        //})



//$( "#slider" ).slider({
//      value:0,
//      min: 0,
//      max: 21,
//      // Here goes dayly price
//      step: 50,
//      slide: function( event, ui ) {
//        $( "#amount" ).val( "$" + ui.value );
//      }
//    });
//    $( "#amount" ).val( "$" + $( "#slider" ).slider( "value" ) );
 


        var select = function () {
            priceCal();
        };

        $("#datepickerStart").datepicker(
            {
                onSelect: select,
                onUpdate: select}
        );

        //$('#datepickerStart').datepicker({
        //    'format': 'm/d/yyyy',
        //    'autoclose': true
        //});
   
        $("#datepickerEnd").datepicker(
            {
                onSelect: select,
                onUpdate: select
            }
        );

        //$(function () {
        //    $('#datepickerEnd').datepicker({
        //        'format': 'm/d/yyyy',
        //        'autoclose': true
        //    });
        //});

   

        function priceCal() {
            //declares
           
            var dayRate = cartoCalculate.DailyPrice;
        

            var dateStart = $('#datepickerStart').datepicker('getDate');
    
            var dateEnd = $('#datepickerEnd').datepicker('getDate');
        

            var totalDays = (dateEnd - dateStart) / 24 / 60 / 60 / 1000; //we get total days
        
            $('#price').text(totalDays * dayRate)
            //more than one day
            console.log("Parked for " + totalDays + " day/s it cost " + (totalDays * dayRate));
       
         
        }










      
});
        
  
     



 


  

