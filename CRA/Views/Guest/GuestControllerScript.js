
$(function () {
    $("#datepicker").datepicker();
    var helperUrl = '@Url.Action("HelpAjax","Guest")';

    var result;

    $.getJSON(helperUrl, function (data) {
        result = data;
        console.log(result);
    });

   
});


  

