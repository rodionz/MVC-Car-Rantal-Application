$(function () {

    $('#addnewModel').on('click', function () {
        $.ajax({
            type: "GET",
            url: '/Manager/AddNewModel',
            success: function (data, textStatus, jqXHR) {
                $('.column-one').html(data);

                console.log("Success");
            }
        });
    });



    $('#addnewClient').on('click', function () {
        $.ajax({
            type: "GET",
            url: '/Manager/AddClient',
            success: function (data, textStatus, jqXHR) {
                $('.column-one').html(data);

                console.log("Success");
            }
        });
    });



    $('#addnewcar').on('click', function () {
        $.ajax({
            type: "GET",
            url: '/Manager/AddCar',
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