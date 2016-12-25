
$(function () {
    $(function () {
        $("#datepicker").datepicker();



        var carSelection = function (selected) {
         
            $('.carlist li').each(function () {
                if ($(this).hasClass(selected)) {

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
            
            let selected = $('#model').val();

            if(selected != "")
            {
                console.log('searchbyModel')

                carSelection(selected);
            }
        });

        $('#searchbyManufacturer').click(function () {

            if ($('#manufa').val() != "")
            {
                console.log('searchbyManufacturer')
            }
            
        });

        $('#searchbyDate').click(function () {
            {
                if($('#datepicker').val() != "")
                {
                    console.log('searchbyDate')
                }
            }
            
        });

        $('#freeSearch').click(function () {
            if($('#freeText').val() != "")
            {
                console.log("FreeTextSeach")
            }
        });

    });
});


  

