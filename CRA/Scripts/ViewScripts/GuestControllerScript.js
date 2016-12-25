
$(function () {
    $(function () {
        $("#datepicker").datepicker();



        


        $('#searchbyTransmission').click(function () {
            console.log('searchbyTransmission')
        });

        $('#searchbyModel').click(function () {
            
            if($('#model').val() != "")
            {
                console.log('searchbyModel')
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


  

