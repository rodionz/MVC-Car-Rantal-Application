
$(function () {

    $.ajax({
        type: 'GET',
        url: '/Customer/QuantityOfItemsInBusket',
        
        success: function (data) {
            console.log(data);

            if(data > 0)
            {
                $('.cart-item-count').css("color", "red");
                $('.cart-item-count').text(data);

            }
        }
    })
})