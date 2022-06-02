$(document).ready(function () {
    $('.addToCart').off('click').on('click', function (e) {
        e.preventDefault();
        var id = parseInt($(this).data('id'));
        $.ajax({
            url: "/ShoppingCart/AddtoCart?id=" + id,
            data: id,
            type: "POST",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            success: function (response) {
                if (response.result) {
                    toastr.success(response.message, 'Success');
                } else {
                    toastr.error(response.message, 'Error');
                }
            }
        });
    });
});