$(function () {
    

    $('footer').addClass('bottomfooter');



    var arrayofDeals = [];


    $.getJSON('/Manager/HelpAjax', function (data) {
        

        arrayofDeals = result.AllDeals;

        console.log(result);
    });

});