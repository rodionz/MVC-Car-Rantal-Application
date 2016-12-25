
$(function () {
    $(function () {
        $("#datepicker").datepicker();



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
            console.log('searchbyTransmission')
        });



        $('#searchbyModel').click(function () {
            
            let selectedVal = parseInt($('#model').val()) + 1;

            let selectedModel = result.carModels[selectedVal].NameofModel;


            if(selectedModel)
            {
                console.log('searchbyModel')

                carSelection("data-carModel", selectedModel);
            }
        });




        $('#searchbyManufacturer').click(function () {

            let selectedVal = parseInt($('#manufa').val()) + 1;

            let selectedManufacturer = result.carManufacturers[selectedVal].manufacturerName;

            if ( selected != "")
            {
                console.log('searchbyManufacturer')
                carSelection(selected);
            }
            
        });

        $('#searchbyDate').click(function () {
            {
                let selected = $('#datepicker').val();


                if( selected != "")
                {
                    console.log('searchbyDate')
                    carSelection(selected);
                }
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

    });
});


  

