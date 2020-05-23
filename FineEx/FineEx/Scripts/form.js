$(document).ready(function () {

    $('.form-control').focus(function () {
        $(this).parent().find(".label-txt").addClass('label-active');
    });

    $(".form-control").focusout(function () {
        if ($(this).val() === '') {
            $(this).parent().find(".label-txt").removeClass('label-active');
        };
    });

});
