

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


  

