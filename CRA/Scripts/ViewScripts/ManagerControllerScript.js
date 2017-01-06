


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
           
            $(table).append("<tr><td>" + model.ID + "</td><td>" + model.NameofModel + "</td><td>" + model.DailyPrice + "</td><td>" + model.LateReturnFine +
                "</td><td><span class='editdelete' id=" + model.ID + " ><button class='btn btn-xs btn-primary modelEdit' >Edit model</button><button class='btn btn-xs btn-danger modelDelete'>Delete model</button></span></td></tr>");
        }

        $('.column-one').append(table);
    });


    $('.column-one').on('click', '.modelEdit', function () {

        var id = $(this).parent().attr('id');

       

        $.ajax({
            type: 'GET',
            data: { ManagerAction: 'EditModel', ID: id },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-two').html(data);
                console.log("ModelEdit");
                console.log(id);
            }

        });
    });


    $('.column-one').on('click', '.modelDelete', function () {

        var id = $(this).parent().attr('id');

        console.log("modelDelete");
        console.log(id);
    });


   



    $('#editClient').on('click', function () {

        $('.column-one').empty();

        var table = document.createElement('table');

        table.className = "table table-bordered";

        var row = table.insertRow(0);

        row.innerHTML = "<th>ID of Customer</th><th>Full Name</th><th>Birth Data</th><th>Email</th><th>Password</th>";

        for (var model of  arrayofCustomers)
        {
           
            $(table).append("<tr><td>"+model.ID+"</td><td>" + model.FullName + "</td><td>" + model.BirthData + "</td><td>" + model.Email + "</td><td>" + model.Password +
                "</td><td><span class='editdelete' id=" + model.ID + "><button class='btn btn-xs btn-primary clientEdit'>Edit Customer</button><button class='btn btn-xs btn-danger clientDelete'>Delete Customer</button></span></td></tr>")
        }

        $('.column-one').append(table);


    });




    $('.column-one').on('click', '.clientEdit', function () {

        var id = $(this).parent().attr('id');

        console.log("clientEdit");
        console.log(id);
    });


    $('.column-one').on('click', '.clientDelete', function () {

        var id = $(this).parent().attr('id');

        console.log("clientDelete");
        console.log(id);
    });





    $('#editCar').on('click', function () {

        $('.column-one').empty();

        var table = document.createElement('table');

        table.className = "table table-bordered table-hover";

        var row = table.insertRow(0);

        row.innerHTML = "<th>ID of Car</th><th>Mileage</th><th>CarNumber</th><th>Branch ID</th><th>Model ID</th>";

        for (var model of  arrayofCars)
        {
            
            $(table).append("<tr><td>" + model.ID + "</td><td>" + model.Mileage + "</td><td>" + model.CarNumber + "</td><td>" + model.BranchID + "</td><td>" + model.ModelID +
                "</td><td><span class='editdelete' id=" + model.ID + "><button class='btn btn-xs btn-primary carEdit'>Edit Vehicle</button><button class='btn btn-xs btn-danger carDelete'>Delete Vehicle</button></span></td></tr>");
        }

        $('.column-one').append(table);


    });




    $('.column-one').on('click', '.carEdit', function () {

        var id = $(this).parent().attr('id');

        console.log("carEdit");
        console.log(id);
    });


    $('.column-one').on('click', '.carDelete', function () {

        var id = $(this).parent().attr('id');

        console.log("carDelete");
        console.log(id);
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
                "</td><td><span class='editdelete' id=" + model.ID + "><button class='btn btn-xs btn-primary dealEdit'>Edit Deal</button><button class='btn btn-xs btn-danger dealDelete'>Delete Deal</button></span></td></tr>")
        }

        $('.column-one').append(table);
    });



    $('.column-one').on('click', '.dealEdit', function () {

        var id = $(this).parent().attr('id');

        console.log("dealEdit");
        console.log(id);
    });


    $('.column-one').on('click', '.dealDelete', function () {

        var id = $(this).parent().attr('id');

        console.log("dealDelete");
        console.log(id);
    });





    $('#editManufactorer').on('click', function () {

        $('.column-one').empty();

        var table = document.createElement('table');

        table.className = "table table-bordered table-hover";

        var row = table.insertRow(0);

        row.innerHTML = "<th>ID of Manufactorer</th><th>Name of Manufactorer</th>";

        for (var model of  arrayofManufactorers)
        {
            
            $(table).append("<tr><td>" + model.ID + "</td><td>" + model.manufacturerName
                + "</td><td><span class='editdelete' id=" + model.ID + "><button class='btn btn-xs btn-primary manEdit'>Edit Manufactorer</button><button class='btn btn-xs btn-danger manDelete'>Delete Manufactorer</button></span></td></tr>");
        }

        $('.column-one').append(table);


    });

    $('.column-one').on('click', '.manEdit', function () {

        var id = $(this).parent().attr('id');

        console.log("manEdit");
        console.log(id);
    });


    $('.column-one').on('click', '.manDelete', function () {

        var id = $(this).parent().attr('id');

        console.log("manDelete");
        console.log(id);
    });



  
    });



  



