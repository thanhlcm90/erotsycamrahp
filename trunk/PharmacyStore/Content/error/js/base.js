$(document).ready(function () {
    $('.nav-content').hide();
    $('.nav-content:first').show();
    $('ul.navigation li:first a').addClass('active');
    $('ul.navigation li a').click(function () {
        $('ul.navigation li a').removeClass('active');
        $(this).addClass('active');
        var currentTab = $(this).attr('href');
        $('.nav-content').hide();
        $(currentTab).show();
        return false;
    });
});
