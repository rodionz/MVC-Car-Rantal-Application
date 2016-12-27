$(function () {

    $('#addnewModel').on('select', function () {
        $.ajax({
            type: "GET",
            url: '/ManagerController/AddModel',
            success: function (data, textStatus, jqXHR) {
                $('.column-one').html(data);

                console.log("Success");
            }

        });


    });




















});