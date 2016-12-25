
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
            
            let selected = $('#model').attr("data-carModel");

            if(selected != "")
            {
                console.log('searchbyModel')

                carSelection("data-carModel",selected);
            }
        });

        $('#searchbyManufacturer').click(function () {

            let selected = $('#manufa').val();

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


  

