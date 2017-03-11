


$(function () {

    var result = {};

    var arrayofModels = [];

    var arrayofCars = [];

    var arrayofManufactorers = [];
 
    var arrayofCustomers = [];

    var arrayofEmployees = [];

    var arrayofDeals = [];


    var dataRequest = function () {      
        $.ajax({
            type: 'GET',
            url: '/Manager/HelpAjax',
            async: false,
            success: function (data) {
             result = data;
             arrayofModels = result.AllCarModels;
             arrayofCars = result.AllCars;
             arrayofManufactorers = result.AllManufacturers;
             arrayofCustomers = result.AllCustomers;
             arrayofEmployees = result.AllEmployees;
             arrayofDeals = result.AllDeals;
            
            }
        })         
    }

    dataRequest();


    $('.column-two').on('click', '.cancel', function () {
        $('.column-two').empty();
    });
   

    $('.column-two').empty();



    ////////////CAR  MODELS//////////////////


    // Requesting form for adding new model

    $('.column-one').on('click', '.addnewModel', function () {
        $('.column-two').empty();
        $.ajax({
            type: "GET",
            data: {ManagerAction : 'AddModel'},
            url: '/Manager/ManagerActions',
            
            success: function (data, textStatus, jqXHR) {
                $('.column-two').html(data);                
            }
        });
    });



    // Creating list of models
    $('#modelList').on('click', function () {
        $('.column-two').empty();
        listofModels();

    });

    function transmission(num) {

        if (num == 0) {
            return "Automatic";
        }

        else if (num == 1) {
            return "Manual";
        }

        else if (num == 2) {
            return "Robotic";
        }

    }

    var listofModels = function () {

        
        $('.column-one').empty();
        
        var table = document.createElement('table');
        table.setAttribute("id", "mytable");
        table.className = "table table-striped table-bordered table-hover";
        var addButton = document.createElement('button');
        addButton.className = "addbutton addnewModel btn btn-success btn-sm";
        addButton.textContent = "Add New Model";
        $('.column-one').prepend(addButton);
        var header = table.createTHead();
        var row = header.insertRow(0);
        row.innerHTML = "<th class='col-xs-1'>ID of Model</th><th class='col-xs-1'>Manufactorer</th><th class='col-xs-1'>Name of Model</th><th class='col-xs-1'>Transmission</th><th class='col-xs-1'>Daily Price</th><th class='col-xs-1'>Late Return Fine</th><th class='col-xs-2'></th>";
        var body = table.createTBody();

        for (var model of arrayofModels)
        {

            $(body).append("<tr><td>" + model.ID + "</td><td>" + model.ManufacturerId + "</td><td>" + model.NameofModel + "</td><td>" + transmission(model.gear) + "</td><td>" + model.DailyPrice + "</td><td>" + model.LateReturnFine +
                "</td><td class='cellwhithbuttons'><span class='editdelete' id=" + model.ID + "><button class='btn btn-xs btn-primary modelEdit' >Edit</button>     <button class='btn btn-xs btn-danger modelDelete'>Delete</button></span></td></tr>");
        }

        $('.column-one').append(table);
        $('#mytable').DataTable();

    }


    // Requesting form for model editing
    $('.column-one').on('click', '.modelEdit', function () {
        var id = $(this).parent().attr('id');
        $('.column-two').empty();
        $.ajax({
            type: 'GET',
            data: { ManagerAction: 'EditModel', ID: id },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-two').html(data);
               
            }
        });
    });


    // Deleting model
    $('.column-one').on('click', '.modelDelete', function () {
        $('.column-two').empty();
        var id = $(this).parent().attr('id');


        var del = confirm("Are you sure that you want to delete this model?");

        if (del) {
            $.ajax({
                type: 'GET',
                data: { ManagerAction: 'DeleteModel', ID: id },
                url: '/Manager/ManagerActions',
                success: function (data, textStatus, jqXHR) {
               
                    dataRequest();
                    listofModels();
                    $('.column-two').empty();
                    $('.column-two').prepend("<h3 class='actionSuccses'>Model Deleted Succesfully</h3>")

                }
            });
        }
    });



    // New model submission
    $('.column-two').on('click', '#submitNewModel', function () {
       
        let manID = $('.ManufacturerId').val();
        let modelName = $('.NameofModel').val();
        let dailyPrice = $('.DailyPrice').val();
        let _gear = $('.Gear').val();
        let lateReturnFine = $('.LateReturnFine').val();

        $.ajax({
            type: 'GET',
            data: { ManufacturerId: manID, NameofModel: modelName, DailyPrice: dailyPrice, LateReturnFine: lateReturnFine, gear: _gear },
            url: '/Manager/SubmitNewModel',
            success: function (data, textStatus, jqXHR) {
                if (data.ActionResult == "Model Added") {
                    $('.column-two').empty();
                    $('.column-two').prepend("<h3 class='actionSuccses'>Model Added Succesfully</h3>")
                    dataRequest();
                    listofModels();
                }

                else {
                    $('.column-two').html(data);
                }
            }         
        })            
    });



    // Model editing submission
    $('.column-two').on('click', '#submitEditModel', function () {
        
        let modelID = $('.modelID').val();
        let manID = $('.ManufacturerId').val();
        let modelName = $('.NameofModel').val();      
        let _gear = $('.Gear').val();
        let dailyPrice = $('.DailyPrice').val();
        let lateReturnFine = $('.LateReturnFine').val();

        $.ajax({
            type: 'GET',
            data: {ID: modelID, ManufacturerId: manID, NameofModel: modelName, DailyPrice: dailyPrice, LateReturnFine: lateReturnFine, gear: _gear },
            url: '/Manager/SubmitEditModel',
            success: function (data, textStatus, jqXHR) {
                if (data.ActionResult == "Model Edited") {
                    $('.column-two').empty();
                    $('.column-two').prepend("<h3 class='actionSuccses'>Model Edited Succesfully</h3>")
                   
                    dataRequest();
                    listofModels();
                }
                else {
                    $('.column-two').html(data);
                }
            }
        })
    });




    ////////// CUSTOMERS ////////////////



    // Requesting form for adding new customer
    $('.column-one').on('click', '.addnewClient', function () {
        $('.column-two').empty();
        $.ajax({
            type: "GET",
            data: {ManagerAction : 'AddCustomer'},
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-two').html(data);                       
            }
        });
    });



    // Creating list of customers
    var listofCustomers = function () {

        $('.column-one').empty();
       
        
        var table = document.createElement('table');
        table.className = "table table-striped table-bordered table-hover";
        var addButton = document.createElement('button');
        addButton.className = "addbutton addnewClient btn btn-success btn-sm";
        addButton.textContent = "Add New Customer";
        $('.column-one').prepend(addButton);
        table.setAttribute("id", "mytable");
        var header = table.createTHead();
        var row = header.insertRow(0);
        row.innerHTML = "<th class='col-xs-1'>ID of Customer</th><th class='col-xs-1'>Full Name</th><th class='col-xs-1'>Birth Data</th><th class='col-xs-1'>Email</th><th class='col-xs-1'>Username</th><th class='col-xs-1'>Password</th><thclass='col-xs-2'>Customers Editing</th>";
        var body = table.createTBody();

        for (var model of  arrayofCustomers)
        {
            $(body).append("<tr><td>" + model.ID + "</td><td>" + model.FullName + "</td><td>" + moment(model.BirthData).format('MM/DD/YYYY') + "</td><td>" + model.Email + "</td><td>" + model.UserName + "</td><td>" + model.Password +
                "</td><td class='cellwhithbuttons'><span class='editdelete' id=" + model.ID + "><button class='btn btn-xs btn-primary clientEdit'>Edit</button>     <button class='btn btn-xs btn-danger clientDelete'>Delete</button></span></td></tr>")
        }

        $('.column-one').append(table);
        $('#mytable').DataTable(
     );
    }





    $('#clientList').on('click', function () {
        $('.column-two').empty();
        listofCustomers();
    });




    // Requesting form for customer editing
    $('.column-one').on('click', '.clientEdit', function () {
        $('.column-two').empty();
        var id = $(this).parent().attr('id');

        $.ajax({
            type: 'GET',
            data: { ManagerAction: 'EditCustomer', ID: id },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-two').html(data);               
            }
        });


    
    });

    // Deleting customer
    $('.column-one').on('click', '.clientDelete', function () {
        $('.column-two').empty();
        var id = $(this).parent().attr('id');

        var del = confirm("Are you sure that you want to delete this customer?");

        if (del) {
            $.ajax({
                type: 'GET',
                data: { ManagerAction: 'DeleteCustomer', ID: id },
                url: '/Manager/ManagerActions',
                success: function (data, textStatus, jqXHR) {
                    $('.column-two').empty();
                    $('.column-two').prepend("<h3 class='actionSuccses'> Customer Deleted Succsesfully</h3>")
                    dataRequest();
                    listofCustomers();
                }
            });
        }
    });

    // New customer submission
    $('.column-two').on('click', '#submitNewCustomer', function () {
      
        let firstName = $('.FirstName').val();
        let gender = $('.Gender').val();
        let lastName = $('.LastName').val();
        let birthDay = $('.BirthData').val();
        let email = $('.Email').val();
        let pass = $('.Password').val();
        let username = $('.Username').val();
        let userRole = $('.Role').val();

        $.ajax({
            type: 'GET',
            data: {  FirstName: firstName, LastName: lastName, role : userRole, gender: gender, BirthData: birthDay, Email: email, UserName : username, Password : pass},
            url: '/Manager/SubmitNewCustomer',
            success: function (data, textStatus, jqXHR) {
                if (data.ActionResult == "New Customer Submitted") {
                    $('.column-two').empty();
                    $('.column-two').prepend("<h3 class='actionSuccses'> Customer Added Succesfully</h3>")
                    dataRequest();
                    listofCustomers();
                }

                else {
                    $('.column-two').html(data);
                }
            }
        })
    });


    // Customer editing submission
    $('.column-two').on('click', '#submitEditCustomer', function () {

        let customerID = $('customerID').val();
        let firstName = $('.FirstName').val();
        let gender = $('.Gender').val();
        let lastName = $('.LastName').val();
        let birthDay = $('.BirthData').val();
        let email = $('.Email').val();
        let pass = $('.Password').val();
        let username = $('.Username').val();
        let userRole = $('.Role').val();

        $.ajax({
            type: 'GET',
            data: { ID: customerID, FirstName: firstName, LastName: lastName, role: userRole, gender: gender, BirthData: birthDay, Email: email, UserName: username, Password: pass },
            url: '/Manager/SubmitEditCustomer',
            success: function (data, textStatus, jqXHR) {
                if (data.ActionResult == "Customer edit submitted") {
                    $('.column-two').empty();
                    $('.column-two').prepend("<h3 class='actionSuccses'> Customer Edited Succesfully</h3>")
                    dataRequest();
                    listofCustomers();
                }
                else {
                    $('.column-two').html(data);
                }
            }
        })
    });
    



 ///////////////////////EMPLOYEES////////////////////////



    // Requesting form for adding new employee
    $('.column-one').on('click', '.addnewEmployee', function () {
        $('.column-two').empty();
        $.ajax({
            type: "GET",
            data: { ManagerAction: 'AddCustomer' },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-two').html(data);
            }
        });
    });



    // Creating list of employees
    var listofEmployees = function () {

        $('.column-one').empty();


        var table = document.createElement('table');
        table.className = "table table-striped table-bordered table-hover";
        var addButton = document.createElement('button');
        addButton.className = "addbutton addnewEmployee btn btn-success btn-sm";
        addButton.textContent = "Add New Employee";
        $('.column-one').prepend(addButton);
        table.setAttribute("id", "mytable");
        var header = table.createTHead();
        var row = header.insertRow(0);
        row.innerHTML = "<th class='col-xs-1'>ID of Employee</th><th class='col-xs-1'>Full Name</th><th class='col-xs-1'>Birth Data</th><th class='col-xs-1'>Email</th><th class='col-xs-1'>Username</th><th class='col-xs-1'>Password</th><th class='col-xs-2'></th>";
        var body = table.createTBody();

        for (var model of arrayofEmployees) {
            $(body).append("<tr><td>" + model.ID + "</td><td>" + model.FullName + "</td><td>" + moment(model.BirthData).format('MM/DD/YYYY') + "</td><td>" + model.Email + "</td><td>" + model.UserName + "</td><td>" + model.Password +
                "</td><td class='cellwhithbuttons'><span class='editdelete' id=" + model.ID + "><button class='btn btn-xs btn-primary employeeEdit'>Edit</button>     <button class='btn btn-xs btn-danger employeeDelete'>Delete</button></span></td></tr>")
        }

        $('.column-one').append(table);
        $('#mytable').DataTable(
        );
    }





    $('#employeesList').on('click', function () {
        $('.column-two').empty();
        listofEmployees();
    });




    // Requesting form for employee editing
    $('.column-one').on('click', '.employeeEdit', function () {
        $('.column-two').empty();
        var id = $(this).parent().attr('id');

        $.ajax({
            type: 'GET',
            data: { ManagerAction: 'EditCustomer', ID: id },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-two').html(data);
            }
        });



    });

    // Deleting customer
    $('.column-one').on('click', '.employeeDelete', function () {
        $('.column-two').empty();
        var id = $(this).parent().attr('id');

        var del = confirm("Are you sure that you want to delete this Employee?");

        if (del) {
            $.ajax({
                type: 'GET',
                data: { ManagerAction: 'DeleteCustomer', ID: id },
                url: '/Manager/ManagerActions',
                success: function (data, textStatus, jqXHR) {
                    $('.column-two').empty();
                    $('.column-two').prepend("<h3 class='actionSuccses'> Employee Deleted Succsesfully</h3>")
                    dataRequest();
                    listofEmployees();
                }
            });
        }
    });

    // New customer submission
    $('.column-two').on('click', '#submitNewCustomer', function () {

        let firstName = $('.FirstName').val();
        let gender = $('.Gender').val();
        let lastName = $('.LastName').val();
        let birthDay = $('.BirthData').val();
        let email = $('.Email').val();
        let pass = $('.Password').val();
        let username = $('.Username').val();
        let userRole = $('.Role').val();

        $.ajax({
            type: 'GET',
            data: { FirstName: firstName, LastName: lastName, role: userRole, gender: gender, BirthData: birthDay, Email: email, UserName: username, Password: pass },
            url: '/Manager/SubmitNewEmployee',
            success: function (data, textStatus, jqXHR) {
                if (data.ActionResult == "New Employee Submitted") {
                    $('.column-two').empty();
                    $('.column-two').prepend("<h3 class='actionSuccses'> Employee Added Succesfully</h3>")
                    dataRequest();
                    listofCustomers();
                }

                else {
                    $('.column-two').html(data);
                }
            }
        })
    });


    // Customer editing submission
    $('.column-two').on('click', '#submitEditCustomer', function () {

        let customerID = $('customerID').val();
        let firstName = $('.FirstName').val();
        let gender = $('.Gender').val();
        let lastName = $('.LastName').val();
        let birthDay = $('.BirthData').val();
        let email = $('.Email').val();
        let pass = $('.Password').val();
        let username = $('.Username').val();
        let userRole = $('.Role').val();

        $.ajax({
            type: 'GET',
            data: { ID: customerID, FirstName: firstName, LastName: lastName, role: userRole, gender: gender, BirthData: birthDay, Email: email, UserName: username, Password: pass },
            url: '/Manager/SubmitEditEmployee',
            success: function (data, textStatus, jqXHR) {
                if (data.ActionResult == "Employee edit submitted") {
                    $('.column-two').empty();
                    $('.column-two').prepend("<h3 class='actionSuccses'> Employee Edited Succesfully</h3>")
                    dataRequest();
                    listofCustomers();
                }
                else {
                    $('.column-two').html(data);
                }
            }
        })
    });







/////////////////////////////////////////////////////////

////////////////////////// CARS /////////////////////////



    // Requesting form for adding new car
    $('.column-one').on('click', '.addnewcar', function () {
        $.ajax({
            type: "GET",
            data: { ManagerAction: 'AddCar' },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-two').html(data);               
            }
        });
    });




    // Creating list of cars

  

        var listofCars = function () {

        $('footer').removeClass('bottomfooter');
        $('.column-one').empty();
        
        var table = document.createElement('table');
        table.className = "table table-striped table-bordered table-hover";
        var addButton = document.createElement('button');
        addButton.className = "addbutton addnewcar btn btn-success btn-sm";
        addButton.textContent = "Add New Car";
        $('.column-one').prepend(addButton);
        table.setAttribute("id", "mytable");
        var header = table.createTHead();
        var row = header.insertRow(0);   
        row.innerHTML = "<th class='col-xs-1'>ID of Car</th><th class='col-xs-1'>Model ID</th><th class='col-xs-1'>Branch ID</th><th class='col-xs-1'>Mileage</th><th class='col-xs-1'>CarNumber</th><th class='col-xs-2'></th>";
        var body = table.createTBody();

        function branch(num) {
            if (num == 1) {
                return "King David";
            }

            else if (num == 2) {
                return "Ramat Aviv";
            }

            else if (num == 3)
            {
                return "Hof ha Carmel";
            }

        }


        for (var model of  arrayofCars)
        {
            $(body).append("<tr><td>" + model.ID + "</td><td>" + model.ModelID + "</td><td>" + branch(model.BranchID) + "</td><td>" + model.Mileage + "</td><td>" + model.CarNumber + "</td><td class='cellwhithbuttons'><span class='editdelete' id=" + model.ID + "><button class='btn btn-xs btn-primary carEdit'>Edit</button>     <button class='btn btn-xs btn-danger carDelete'>Delete</button></span></td></tr>");
        }

        $('.column-one').append(table);
        $('#mytable').DataTable();
    };


        $('#carList').on('click', function () {
            $('.column-two').empty();
            listofCars();
        });




    // Requesting form for car edit

   
    $('.column-one').on('click', '.carEdit', function () {
        $('.column-two').empty();
        var id = $(this).parent().attr('id');

        $.ajax({
            type: 'GET',
            data: { ManagerAction: 'EditCar', ID: id },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-two').html(data);              
            }
        });
       
    });



    // Deleting car
    $('.column-one').on('click', '.carDelete', function () {

        var id = $(this).parent().attr('id');
        var del = confirm("Are you sure that you want to delete this car?");

        if (del) {
            $.ajax({
                type: 'GET',
                data: { ManagerAction: 'DeleteCar', ID: id },
                url: '/Manager/ManagerActions',
                success: function (data, textStatus, jqXHR) {
                    $('.column-two').empty();
                    $('.column-two').prepend("<h3 class='actionSuccses'>Car Deleted Succesfully</h3>");
                    dataRequest();
                    listofCars();
                }
            });
        }
    });



    // New car submission
    $('.column-two').on('click', '#submitNewCar', function () {

        let miles = $('.Mileage').val();
        let carNumber = $('.CarNumber').val();
        let branchID = $('.Branch').val()
        let modelID = $('.Model').val();


        $.ajax({
            type: 'GET',
            data: { Mileage: miles, CarNumber: carNumber, BranchID: branchID, ModelID : modelID },
            url: '/Manager/SubmitNewCar',
            success: function (data, textStatus, jqXHR) {
                if (data.ActionResult == "New car submitted") {
                    $('.column-two').empty();
                    $('.column-two').prepend("<h3 class='actionSuccses'>Car Added Succesfully</h3>");
                    dataRequest();
                    listofCars();
                }
                else {
                    $('.column-two').html(data);
                }
            }
        })
    });


    // Car edit submission
    $('.column-two').on('click', '#submitEditCar', function () {

        let carID = $('.carID').val();
        let miles = $('.Mileage').val();
        let carNumber = $('.CarNumber').val();
        let branchID = $('.Branch').val()
        let modelID = $('.Model').val();

        $.ajax({
            type: 'GET',
            data: {  ID : carID, Mileage: miles, CarNumber: carNumber, BranchID: branchID, ModelID: modelID },
            url: '/Manager/SubmitEditCar',
            success: function (data, textStatus, jqXHR) {
                if (data.ActionResult == "Car edit submitted") {
                    $('.column-two').empty();
                    $('.column-two').prepend("<h3 class='actionSuccses'>Car Edited Succesfully</h3>");
                    dataRequest();
                    listofCars();
                }

                else {
                    $('.column-two').html(data);
                }
            }
        })
    });


/////////////////// DEALS ////////////////////////////




    // Requesting form for adding new deal
    $('.column-one').on('click', '.addDeal', function () {
        $('.column-two').empty();
        $.ajax({
            type: "GET",
            data: { ManagerAction: 'AddDeal' },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-two').html(data);          
            }
        });
    });

    // Creating list of deals
    var creatinglistOfDeals = function () {
        $('.column-one').empty();
        
        var table = document.createElement('table');
        table.className = "table table-striped table-bordered table-hover";
        var addButton = document.createElement('button');
        addButton.className = "addbutton addDeal btn btn-success btn-sm";
        addButton.textContent = "Add New Deal";
        $('.column-one').prepend(addButton);
        table.setAttribute("id", "mytable");
        var header = table.createTHead();
        var row = header.insertRow(0);
        row.innerHTML = "<th class='col-xs-1'>ID of Deal</th><th class='col-xs-1'>Start Date</th><th class='col-xs-1'>Supposed Return</th><th class='col-xs-1'>Real Return</th><th class='col-xs-1'>Client ID</th><th class='col-xs-1'>Car ID</th><th class='col-xs-2'></th>";
        var body = table.createTBody();

        let returnDate;

        for (var model of  arrayofDeals)
        {
          
            if (model.RealReturn === null) {
                returnDate = "Car is not returned"
            }

            else {
                returnDate = model.RealReturn;
            }

            $(body).append("<tr><td>" + model.ID + "</td><td>" + model.StartDate + "</td><td>" + model.SupposedReturn + "</td><td>" + returnDate + "</td><td>" + model.ClientID + "</td><td>" + model.CarID +
                "</td><td class='cellwhithbuttons'><span class='editdelete' id=" + model.ID + "><button class='btn btn-xs btn-primary dealEdit'>Edit</button>     <button class='btn btn-xs btn-danger dealDelete'>Delete</button></span></td></tr>")
        }

        $('.column-one').append(table);
        $('#mytable').DataTable();
    }



    $('#dealList').on('click', function () {
        $('.column-two').empty();
        creatinglistOfDeals();
    });


    // Requesting form for deal edit
    $('.column-one').on('click', '.dealEdit', function () {
        $('.column-two').empty();
        var id = $(this).parent().attr('id');

        $.ajax({
            type: 'GET',
            data: { ManagerAction: 'EditDeal', ID: id },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-two').html(data);               
            }
        });
    });

    // Deleting deal
    $('.column-one').on('click', '.dealDelete', function () {
        $('.column-two').empty();
        var id = $(this).parent().attr('id');
        var del = confirm("Are you sure that you want to delete this deal?");

        if (del) {
            $.ajax({
                type: 'GET',
                data: { ManagerAction: 'DeleteDeal', ID: id },
                url: '/Manager/ManagerActions',
                success: function (data, textStatus, jqXHR) {
                    $('.column-two').empty();
                    $('.column-two').prepend("<h3 class='actionSuccses'> Deal Deleted Succesfully</h3>")
                    dataRequest();
                    creatinglistOfDeals();
                }
            });
        }       
    });


    // New deal submission
    $('.column-two').on('click', '#submitNewDeal', function () {
     
        let startDate = $('.StartDate').val();
        let returnDate = $('.sreturn ').val();
        let realReturn = $('.rreturn').val();
        let clientID = $('.Client').val();
        let carID = $('.Car').val();

        $.ajax({
            type: 'GET',
            data: { StartDate: startDate, SupposedReturn: returnDate, RealReturn: realReturn, ClientID: parseInt(clientID), CarID : parseInt(carID)},
            url: '/Manager/SubmitNewDeal',
            success: function (data, textStatus, jqXHR) {
                if (data.ActionResult == "New deal submitted") {
                    $('.column-two').empty();                   
                    dataRequest();
                    creatinglistOfDeals();
                    $('.column-two').prepend("<h3 class='actionSuccses'> Deal Added Succesfully</h3>")
                }
                else {
                    $('.column-two').html(data);
                }
            }
        })
    });


    //Deal edit submission
    $('.column-two').on('click', '#submitEditDeal', function () {
        
        let dealID = $('.dealID').val();
        let startDate = $('.StartDate').val();
        let returnDate = $('.sreturn ').val();
        let realReturn = $('.rreturn').val();
        let clientID = $('.Client').val();
        let carID = $('.Car').val();

        $.ajax({
            type: 'GET',
            data: {ID: dealID, StartDate: startDate, SupposedReturn: returnDate, RealReturn: realReturn, ClientID: parseInt(clientID), CarID: parseInt(carID) },
            url: '/Manager/SubmitEditDeal',
            success: function (data, textStatus, jqXHR) {
                if (data.ActionResult == "Deal edit submitted") {
                    $('.column-two').empty();
                    $('.column-two').prepend("<h3 class='actionSuccses'> Deal Edited Succesfully</h3>")
                    dataRequest();
                    creatinglistOfDeals();
                }

                else {
                    $('.column-two').html(data);
                }
            }
        })

    });


    //////////////////// MANUFACTORERS ///////////////////



    // Requesting form for adding new manufactorer
    $('.column-one').on('click', '.addManufatorer', function () {
        $('.column-two').empty();
        $.ajax({
            type: "GET",
            data: { ManagerAction: 'AddManufacturer' },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-two').html(data);               
            }
        });
    });



    // Creating list of manufactorers

    var listofManufactorers = function () {

        $('.column-one').empty();
        
        var table = document.createElement('table');
        var addButton = document.createElement('button');
        addButton.className = "addbutton addManufatorer btn btn-success btn-sm";
        addButton.textContent = "Add New Manufactorer";
        $('.column-one').prepend(addButton);
        table.className = "table table-striped table-bordered table-hover";
        table.setAttribute("id", "mytable");
        var header = table.createTHead();
        var row = header.insertRow(0);
        row.innerHTML = "<th class='col-xs-1'>ID of Manufactorer</th><th class='col-xs-1'>Name of Manufactorer</th><th class='col-xs-2'>Edit Manufactorers</th>";
        var body = table.createTBody();

        for (var model of  arrayofManufactorers)
        {
            $(table).append("<tr><td>" + model.ID + "</td><td>" + model.manufacturerName
                + "</td><td class='cellwhithbuttons'><span class='editdelete' id=" + model.ID + "><button class='btn btn-xs btn-primary manEdit'>Edit</button>     <button class='btn btn-xs btn-danger manDelete'>Delete</button></span></td></tr>");
        }

        $('.column-one').append(table);
        $('#mytable').DataTable();
    }




    $('#manufactorerList').on('click', function () {
        $('.column-two').empty();
        listofManufactorers();    
    });



    // Requesting form for manufacturer edit
    $('.column-one').on('click', '.manEdit', function () {
        $('.column-two').empty();
        var id = $(this).parent().attr('id');

        $.ajax({
            type: 'GET',
            data: { ManagerAction: 'EditManufactorer', ID: id },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-two').html(data);           
            }
        });
    });




    // Deleting manufactorer
    $('.column-one').on('click', '.manDelete', function () {
        $('.column-two').empty();
        var id = $(this).parent().attr('id');
        var del = confirm("Are you sure that you want to delete this manufactorer?");

        if (del) {
            $.ajax({
                type: 'GET',
                data: { ManagerAction: 'DeleteManufactorer', ID: id },
                url: '/Manager/ManagerActions',
                success: function (data, textStatus, jqXHR) {
                    $('.column-two').empty();
                    $('.column-two').prepend("<h3 class='actionSuccses'> Manufactorer Deleted Succesfully</h3>")
                    dataRequest();
                    listofManufactorers();
                }
            });
        }
    });


    $('.column-two').on('click', '#submitNewManuf', function () {
       
        let manufacName = $('.manname').val();

        $.ajax({
            type: 'GET',
            data: { manufacturerName: manufacName },
            url: '/Manager/SubmitNewManufacturer',
            success: function (data, textStatus, jqXHR) {
                if (data.ActionResult == "New manufactorer submitted") {
                    $('.column-two').empty();
                    $('.column-two').prepend("<h3 class='actionSuccses'> Manufactorer Added Succesfully</h3>")
                    dataRequest();
                    listofManufactorers();
                }
                else {
                    $('.column-two').html(data);
                }
            }
        })
    });




    $('.column-two').on('click', '#submitEditManuf', function () {
      
        let manID = $('.manID').val();
        let manufacName = $('.manname').val();

        $.ajax({
            type: 'GET',
            data: {ID: manID, manufacturerName: manufacName },
            url: '/Manager/SubmitEditManufactorer',
            success: function (data, textStatus, jqXHR) {
                if (data.ActionResult == "Manufactorer edit submitted") {
                    $('.column-two').prepend("<h3 class='actionSuccses'>Manufactorer Edited Succesfully</h3>")
                   
                    dataRequest();
                    listofManufactorers();
                }
                else {
                    $('.column-two').html(data);
                }
            }
        })
    });


  

    creatinglistOfDeals();



    });



  



