$(function () {

    $('#addnewModel').on('click', function () {
        $.ajax({
            type: "GET",
            url: '/Manager/ AddNewModel',
            success: function (data, textStatus, jqXHR) {
                $('.column-one').html(data);

                console.log("Success");
            }

        });


    });

    $('.test').click(function () {

        console.log("It Works!!!")
    });



















});