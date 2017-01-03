


$(function () {

    var result;

    var arrayofModels = [];

    var arrayofCars = [];

    var arrayofManufactorers = [];
 
    var arrayofCustomers = [];

    var arrayofDeals = [];


    $.getJSON('/Manager/HelpAjax', function (data) {
         result = data;

         arrayofModels = result.AllCarModels;

         arrayofCars = result.AllCars;

         arrayofManufactorers = result.AllManufacturers;

         arrayofCustomers = result.AllCustomers;

         arrayofDeals = result.AllDeals;

        console.log(result);
    });
   


    $('#addnewModel').on('click', function () {
        $.ajax({
            type: "GET",
            data: {ManagerAction : 'AddModel'},
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-one').html(data);

                console.log("Success");
            }
        });
    });






    $('#addnewClient').on('click', function () {
        $.ajax({
            type: "GET",
            data: {ManagerAction : 'AddCustomer'},
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-one').html(data);

                console.log("Success");
            }
        });
    });



    $('#addnewcar').on('click', function () {
        $.ajax({
            type: "GET",
            data: { ManagerAction: 'AddCar' },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-one').html(data);

                console.log("Success");
            }
        });
    });


    $('#addDeal').on('click', function () {
        $.ajax({
            type: "GET",
            data: { ManagerAction: 'AddDeal' },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-one').html(data);

                console.log("Success");
            }
        });
    });


    $('#addManufatorer').on('click', function () {
        $.ajax({
            type: "GET",
            data: { ManagerAction: 'AddManufacturer' },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-one').html(data);

                console.log("Success");
            }
        });
    });





    //$('#editModel').on('click', function () {
    //    $.ajax({
    //        type: "GET",
    //        data: { ManagerAction: 'EditModel' },
    //        url: '/Manager/ManagerActions',
    //        success: function (data, textStatus, jqXHR) {
    //            $('.column-one').html(data);

    //            console.log("Success");
    //        }
    //    });
    //});



    $('#editModel').on('click', function () {

        var table = document.createElement('table');

        table.className = "table table-bordered table-hover";

        var row = table.insertRow(0);

        row.innerHTML = "<th>ID of Model</th><th>Name of Model</th><th>Dailt Price</th><th>Late Return Fine</th>";

        $('.column-one').append(table);


    });







    $('#editClient').on('click', function () {
        $.ajax({
            type: "GET",
            data: { ManagerAction: 'EditCustomer' },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-one').html(data);

                console.log("Success");
            }
        });
    });



    $('#editCar').on('click', function () {
        $.ajax({
            type: "GET",
            data: { ManagerAction: 'EditCar' },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-one').html(data);

                console.log("Success");
            }
        });
    });


    $('#editDeal').on('click', function () {
        $.ajax({
            type: "GET",
            data: { ManagerAction: 'EditDeal' },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-one').html(data);

                console.log("Success");
            }
        });
    })


    $('#editManufactorer').on('click', function () {
        $.ajax({
            type: "GET",
            data: { ManagerAction: 'EditManufacturer' },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-one').html(data);

                console.log("Success");
            }
        });
    })







  
    });



  



