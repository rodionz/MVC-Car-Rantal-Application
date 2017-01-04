


$(function () {

    var result = {};

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







    $('#editModel').on('click', function () {

        $('.column-one').empty();

        var table = document.createElement('table');

        table.className = "table table-bordered";

        var row = table.insertRow(0);

        row.innerHTML = "<th>ID of Model</th><th>Name of Model</th><th>Dailt Price</th><th>Late Return Fine</th>";
     
        for (var model of arrayofModels)
        {
           
            $(table).append("<tr><td>" + model.ModelID + "</td><td>" + model.NameofModel + "</td><td>" + model.DailyPrice + "</td><td>" + model.LateReturnFine +
                "</td><td><span class='editdelete'><button class='btn btn-xs btn-primary'>Edit model</button><button class='btn btn-xs btn-danger'>Delete model</button></span></td></tr>");
        }

        $('.column-one').append(table);
    });







   



    $('#editClient').on('click', function () {

        $('.column-one').empty();

        var table = document.createElement('table');

        table.className = "table table-bordered";

        var row = table.insertRow(0);

        row.innerHTML = "<th>Full Name</th><th>Birth Data</th><th>Email</th><th>Password</th>";

        for (var model of  arrayofCustomers)
        {
           
            $(table).append("<tr><td>" + model.FullName + "</td><td>" + model.BirthData + "</td><td>" + model.Email + "</td><td>" + model.Password +
                "</td><td><span class='editdelete'><button class='btn btn-xs btn-primary'>Edit Customer</button><button class='btn btn-xs btn-danger'>Delete Customer</button></span></td></tr>")
        }

        $('.column-one').append(table);


    });








    $('#editCar').on('click', function () {

        $('.column-one').empty();

        var table = document.createElement('table');

        table.className = "table table-bordered table-hover";

        var row = table.insertRow(0);

        row.innerHTML = "<th>ID of Car</th><th>Mileage</th><th>CarNumber</th><th>Branch ID</th><th>Model ID</th>";

        for (var model of  arrayofCars)
        {
            
            $(table).append("<tr><td>" + model.CarID + "</td><td>" + model.Mileage + "</td><td>" + model.CarNumber + "</td><td>" + model.BranchID + "</td><td>" + model.ModelID +
                "</td><td><span  class='editdelete'><button class='btn btn-xs btn-primary'>Edit Vehicle</button><button class='btn btn-xs btn-danger'>Delete Vehicle</button></span></td></tr>");
        }

        $('.column-one').append(table);


    });






   



    $('#editDeal').on('click', function () {

        $('.column-one').empty();

        var table = document.createElement('table');

        table.className = "table table-bordered table-hover";

        var row = table.insertRow(0);

        row.innerHTML = "<th>ID of Deal</th><th>Start Date</th><th>Supposed Return</th><th>Real Return</th><th>Client ID</th><th>Car ID</th>";

        for (var model of  arrayofDeals)
        {
          
            $(table).append("<tr><td>" + model.ID + "</td><td>" + model.StartDate + "</td><td>" + model.SupposedReturn + "</td><td>" + model.RealReturn + "</td><td>" + model.ClientID + "</td><td>" + model.CarID +
                "</td><td><span  class='editdelete'><button class='btn btn-xs btn-primary'>Edit Deal</button><button class='btn btn-xs btn-danger'>Delete Deal</button></span></td></tr>")
        }

        $('.column-one').append(table);


    });








    $('#editManufactorer').on('click', function () {

        $('.column-one').empty();

        var table = document.createElement('table');

        table.className = "table table-bordered table-hover";

        var row = table.insertRow(0);

        row.innerHTML = "<th>ID of Manufactorer</th><th>Name of Manufactorer</th>";

        for (var model of  arrayofManufactorers)
        {
            
            $(table).append("<tr><td>" + model.ID + "</td><td>" + model.manufacturerName + "</td><td><span class='editdelete'><button class='btn btn-xs btn-primary'>Edit Manufactorer</button><button class='btn btn-xs btn-danger'>Delete Manufactorer</button></span></td></tr>");
        }

        $('.column-one').append(table);


    });




  
    });



  



