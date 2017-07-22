$(function () {
    $("#addClass").click(function () {
        $('#qnimate').addClass('popup-box-on');
        $('.header-bar, .body-content').wrap('<div class="blur-all">');
    });

    $("#removeClass").click(function () {
        $('#qnimate').removeClass('popup-box-on');
        $('.blur-all').removeClass();
    });
})