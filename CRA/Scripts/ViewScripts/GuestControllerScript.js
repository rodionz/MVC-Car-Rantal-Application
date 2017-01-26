

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

        $(".carlist").on("click", ".orderCar", function () {
           $("#dialog").dialog("open");
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



$( "#slider" ).slider({
      value:0,
      min: 0,
      max: 21,
      // Here goes dayly price
      step: 50,
      slide: function( event, ui ) {
        $( "#amount" ).val( "$" + ui.value );
      }
    });
    $( "#amount" ).val( "$" + $( "#slider" ).slider( "value" ) );
 


    });


  

