


$(function () {

    var result = {};

    var arrayofModels = [];

    var arrayofCars = [];

    var arrayofManufactorers = [];
 
    var arrayofCustomers = [];

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
             arrayofDeals = result.AllDeals;
             console.log(result);
            }
        })         
    }

    dataRequest();


    $('.column-two').on('click', '.cancel', function () {
        $('.column-two').empty();
    });
   





    ////////////CAR  MODELS//////////////////


    // Requesting form for adding new model

    $('.column-one').on('click', '.addnewModel', function () {
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

        listofModels();

    });

    var listofModels = function () {

        $('footer').removeClass('bottomfooter');
        $('.column-one').empty();
        $('.column-two').empty();
        var table = document.createElement('table');
        table.setAttribute("id", "mytable");
        table.className = "table table-striped table-bordered table-hover";
        var addButton = document.createElement('button');
        addButton.className = "addbutton addnewModel btn btn-success";
        addButton.textContent = "Add New Model";
        $('.column-one').prepend(addButton);
        var header = table.createTHead();
        var row = header.insertRow(0);
        row.innerHTML = "<th>ID of Model</th><th>Name of Model</th><th>Dailt Price</th><th>Late Return Fine</th><th></th>";
        var body = table.createTBody();

        for (var model of arrayofModels)
        {

            $(body).append("<tr><td>" + model.ID + "</td><td>" + model.NameofModel + "</td><td>" + model.DailyPrice + "</td><td>" + model.LateReturnFine +
                "</td><td class='cellwhithbuttons'><span class='editdelete' id=" + model.ID + "><button class='btn btn-sm btn-primary modelEdit' >Edit</button>     <button class='btn btn-sm btn-danger modelDelete'>Delete</button></span></td></tr>");
        }

        $('.column-one').append(table);
        $('#mytable').DataTable();

    }


    // Requesting form for model editing
    $('.column-one').on('click', '.modelEdit', function () {
        var id = $(this).parent().attr('id');

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

        var id = $(this).parent().attr('id');


        var del = confirm("Are you sure that you want to delete this model");

        if (del) {
            $.ajax({
                type: 'GET',
                data: { ManagerAction: 'DeleteModel', ID: id },
                url: '/Manager/ManagerActions',
                success: function (data, textStatus, jqXHR) {
               
                    dataRequest();
                    listofModels();
                    $(".actionSuccses").text("Model Deleted Succesfully");

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
                    $(".actionSuccses").text("Model Deleted Succesfully");
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
        let gear = $('.Gear').val();
        let dailyPrice = $('.DailyPrice').val();
        let lateReturnFine = $('.LateReturnFine').val();

        $.ajax({
            type: 'GET',
            data: {ID: modelID, ManufacturerId: manID, NameofModel: modelName, DailyPrice: dailyPrice, LateReturnFine: lateReturnFine, gear: _gear },
            url: '/Manager/SubmitEditModel',
            success: function () {
                $(".actionSuccses").text("Model Edited Succesfully");
                dataRequest();
                listofModels();
            }
        })
    });




    ////////// CUSTOMERS ////////////////



    // Requesting form for adding new customer
    $('.column-one').on('click', '.addnewClient', function () {
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
        $('.column-two').empty();
        
        var table = document.createElement('table');
        table.className = "table table-striped table-bordered table-hover";
        var addButton = document.createElement('button');
        addButton.className = "addbutton addnewClient btn btn-success";
        addButton.textContent = "Add New Customer";
        $('.column-one').prepend(addButton);
        table.setAttribute("id", "mytable");
        var header = table.createTHead();
        var row = header.insertRow(0);
        row.innerHTML = "<th>ID of Customer</th><th>Full Name</th><th>Birth Data</th><th>Email</th><th>Password</th><th>Customers Editing</th>";
        var body = table.createTBody();

        for (var model of  arrayofCustomers)
        {
            $(body).append("<tr><td>" + model.ID + "</td><td>" + model.FullName + "</td><td>" + moment(model.BirthData).format('MM/DD/YYYY') + "</td><td>" + model.Email + "</td><td>" + model.Password +
                "</td><td class='cellwhithbuttons'><span class='editdelete' id=" + model.ID + "><button class='btn btn-sm btn-primary clientEdit'>Edit</button>     <button class='btn btn-sm btn-danger clientDelete'>Delete</button></span></td></tr>")
        }

        $('.column-one').append(table);
        $('#mytable').DataTable(
     );
    }





    $('#clientList').on('click', function () {
        listofCustomers();
    });




    // Requesting form for customer editing
    $('.column-one').on('click', '.clientEdit', function () {

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

        var id = $(this).parent().attr('id');

        var del = confirm("Are you sure that you want to delete this customer?");

        if (del) {
            $.ajax({
                type: 'GET',
                data: { ManagerAction: 'DeleteCustomer', ID: id },
                url: '/Manager/ManagerActions',
                success: function (data, textStatus, jqXHR) {                                    
                    $(".actionSuccses").text("Customer Deleted Succesfully");
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
        let lastName = $('LastName').val();
        let birthDay = $('BirthData').val();
        let email = $('.Email').val();
        let pass = $('.Password').val();

        $.ajax({
            type: 'GET',
            data: {  FirstName: firstName, LastName: lastName, gender: gender, BirthData: birthDay, Email: email, Password : pass},
            url: '/Manager/SubmitNewCustomer',
            success: function () {
                $(".actionSuccses").text("Customer Added Succesfully");
                dataRequest();
                listofCustomers();
            }
        })
    });


    // Customer editing submission
    $('.column-two').on('click', '#submitEditCustomer', function () {

        let customerID = $('customerID').val();
        let firstName = $('.FirstName').val();
        let gender = $('.Gender').val();
        let lastName = $('LastName').val();
        let birthDay = $('BirthData').val();
        let email = $('.Email').val();
        let pass = $('.Password').val();

        $.ajax({
            type: 'GET',
            data: { ID: customerID, FirstName: firstName, LastName: lastName, gender: gender, BirthData: birthDay, Email: email, Password: pass },
            url: '/Manager/SubmitEditCustomer',
            success: function () {
                $(".actionSuccses").text("Customer Edited Succesfully");
                dataRequest();
                listofCustomers();
            }
        })
    });
    


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
    $('#carList').on('click', function () {

        $('footer').removeClass('bottomfooter');
        $('.column-one').empty();
        $('.column-two').empty();
        var table = document.createElement('table');
        table.className = "table table-striped table-bordered table-hover";
        var addButton = document.createElement('button');
        addButton.className = "addbutton addnewcar btn btn-success";
        addButton.textContent = "Add New Car";
        $('.column-one').prepend(addButton);
        table.setAttribute("id", "mytable");
        var header = table.createTHead();
        var row = header.insertRow(0);   
        row.innerHTML = "<th>ID of Car</th><th>Mileage</th><th>CarNumber</th><th>Branch ID</th><th>Model ID</th><th>Edit Car</th>";
        var body = table.createTBody();

        for (var model of  arrayofCars)
        {
            $(body).append("<tr><td>" + model.ID + "</td><td>" + model.Mileage + "</td><td>" + model.CarNumber + "</td><td>" + model.BranchID + "</td><td>" + model.ModelID +
                "</td><td class='cellwhithbuttons'><span class='editdelete' id=" + model.ID + "><button class='btn btn-sm btn-primary carEdit'>Edit</button>     <button class='btn btn-sm btn-danger carDelete'>Delete</button></span></td></tr>");
        }

        $('.column-one').append(table);
        $('#mytable').DataTable();
    });






    // Requesting form for car edit

    var listofCars = function () {

        var id = $(this).parent().attr('id');

        $.ajax({
            type: 'GET',
            data: { ManagerAction: 'EditCar', ID: id },
            url: '/Manager/ManagerActions',
            success: function (data, textStatus, jqXHR) {
                $('.column-two').html(data);
                console.log("Client Edit");
                console.log(id);
            }
        });
    }



    $('.column-one').on('click', '.carEdit', function () {

        listofCars();
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
                    $(".actionSuccses").text("Car Deleted Succesfully");
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
            success: function () {
                $(".actionSuccses").text("Car Submitted Succesfully");
                dataRequest();
                listofCars();
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
            success: function () {
                $(".actionSuccses").text("Car Edited Succesfully");
                dataRequest();
                listofCars();
            }
        })
    });


/////////////////// DEALS ////////////////////////////




    // Requesting form for adding new deal
    $('.column-one').on('click', '.addDeal', function () {
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
        $('.column-two').empty();
        var table = document.createElement('table');
        table.className = "table table-striped table-bordered table-hover";
        var addButton = document.createElement('button');
        addButton.className = "addbutton addDeal btn btn-success";
        addButton.textContent = "Add New Deal";
        $('.column-one').prepend(addButton);
        table.setAttribute("id", "mytable");
        var header = table.createTHead();
        var row = header.insertRow(0);
        row.innerHTML = "<th>ID of Deal</th><th>Start Date</th><th>Supposed Return</th><th>Real Return</th><th>Client ID</th><th>Car ID</th><th>Edit Deal</th>";
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
                "</td><td class='cellwhithbuttons'><span class='editdelete' id=" + model.ID + "><button class='btn btn-sm btn-primary dealEdit'>Edit</button>     <button class='btn btn-sm btn-danger dealDelete'>Delete</button></span></td></tr>")
        }

        $('.column-one').append(table);
        $('#mytable').DataTable();
    }



    $('#dealList').on('click', function () {
        creatinglistOfDeals();
    });


    // Requesting form for deal edit
    $('.column-one').on('click', '.dealEdit', function () {

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

        var id = $(this).parent().attr('id');
        var del = confirm("Are you sure that you want to delete this deal?");

        if (del) {
            $.ajax({
                type: 'GET',
                data: { ManagerAction: 'DeleteDeal', ID: id },
                url: '/Manager/ManagerActions',
                success: function (data, textStatus, jqXHR) {
                 
                    $(".actionSuccses").text("Deal Deleted Succesfully");
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
            data: { StartDate: startDate, SupposedReturn: returnDate, RealReturn: realReturn, ClientID: clientID, CarID : carID},
            url: '/Manager/SubmitNewDeal',
            success: function () {
                $(".actionSuccses").text("Deal Submitted Succesfully");
                dataRequest();
                creatinglistOfDeals();
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
            data: {ID: dealID, StartDate: startDate, SupposedReturn: returnDate, RealReturn: realReturn, ClientID: clientID, CarID: carID },
            url: '/Manager/SubmitEditDeal',
            success: function () {
                $(".actionSuccses").text("Deal Edited Succesfully");
                dataRequest();
                creatinglistOfDeals();
            }
        })

    });


    //////////////////// MANUFACTORERS ///////////////////



    // Requesting form for adding new manufactorer
    $('.column-one').on('click', '.addManufatorer', function () {
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
        $('.column-two').empty();
        var table = document.createElement('table');
        var addButton = document.createElement('button');
        addButton.className = "addbutton addManufatorer btn btn-success";
        addButton.textContent = "Add New Manufactorer";
        $('.column-one').prepend(addButton);
        table.className = "table table-striped table-bordered table-hover";
        table.setAttribute("id", "mytable");
        var header = table.createTHead();
        var row = header.insertRow(0);
        row.innerHTML = "<th>ID of Manufactorer</th><th>Name of Manufactorer</th><th>Edit Manufactorers</th>";
        var body = table.createTBody();

        for (var model of  arrayofManufactorers)
        {
            $(table).append("<tr><td>" + model.ID + "</td><td>" + model.manufacturerName
                + "</td><td class='cellwhithbuttons'><span class='editdelete' id=" + model.ID + "><button class='btn btn-sm btn-primary manEdit'>Edit</button>     <button class='btn btn-sm btn-danger manDelete'>Delete</button></span></td></tr>");
        }

        $('.column-one').append(table);
        $('#mytable').DataTable();
    }




    $('#manufactorerList').on('click', function () {
        listofManufactorers();    
    });



    // Requesting form for manufacturer edit
    $('.column-one').on('click', '.manEdit', function () {

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

        var id = $(this).parent().attr('id');
        var del = confirm("Are you sure that you want to delete this manufactorer?");

        if (del) {
            $.ajax({
                type: 'GET',
                data: { ManagerAction: 'DeleteManufactorer', ID: id },
                url: '/Manager/ManagerActions',
                success: function (data, textStatus, jqXHR) {
                
                    $(".actionSuccses").text("Manufactorer Deleted Succesfully");
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
            success: function () {
                $(".actionSuccses").text("Manufactorer Submitted Succesfully");
                dataRequest();
                listofManufactorers();
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
            success: function () {
                $(".actionSuccses").text("Manufactorer Edited Succesfully");
                dataRequest();
                listofManufactorers();
            }
        })
    });


  

    creatinglistOfDeals();



    });



  



