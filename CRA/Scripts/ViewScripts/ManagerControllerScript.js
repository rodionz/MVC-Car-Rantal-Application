


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
     
        for (var model of arrayofModels)
        {
            row = table.insertRow(-1);
            row.innerHTML = "<td>" + model.ModelID + "</td><td>" + model.NameofModel + "</td><td>" + model.DailyPrice + "</td><td>" + model.LateReturnFine+"</td><td></td>"
        }

        $('.column-one').append(table);
    });







    //$('#editClient').on('click', function () {
    //    $.ajax({
    //        type: "GET",
    //        data: { ManagerAction: 'EditCustomer' },
    //        url: '/Manager/ManagerActions',
    //        success: function (data, textStatus, jqXHR) {
    //            $('.column-one').html(data);

    //            console.log("Success");
    //        }
    //    });
    //});



    $('#editClient').on('click', function () {

        var table = document.createElement('table');

        table.className = "table table-bordered table-hover";

        var row = table.insertRow(0);

        row.innerHTML = "<th>Full Name</th><th>Birth Data</th><th>Email</th><th>Password</th>";

        for (var model of  arrayofCustomers)
        {
            row = table.insertRow(-1);
            row.innerHTML = "<td>" + model.FullName + "</td><td>" + model.BirthData + "</td><td>" + model.Email + "</td><td>" + model.Password + "</td><td></td>"
        }

        $('.column-one').append(table);


    });




    //$('#editCar').on('click', function () {
    //    $.ajax({
    //        type: "GET",
    //        data: { ManagerAction: 'EditCar' },
    //        url: '/Manager/ManagerActions',
    //        success: function (data, textStatus, jqXHR) {
    //            $('.column-one').html(data);

    //            console.log("Success");
    //        }
    //    });
    //});



    $('#editCar').on('click', function () {

        var table = document.createElement('table');

        table.className = "table table-bordered table-hover";

        var row = table.insertRow(0);

        row.innerHTML = "<th>ID of Car</th><th>Mileage</th><th>CarNumber</th><th>BranchID</th><th>ModelID</th>";

        for (var model of  arrayofCars)
        {
            row = table.insertRow(-1);
            row.innerHTML = "<td>" + model.CarID + "</td><td>" + model.Mileage + "</td><td>" + model.CarNumber + "</td><td>" + model.BranchID + "</td><td>" + model.ModelID + "</td><td></td>"
        }

        $('.column-one').append(table);


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



  



