$(document).ready(() => {

    $("#dropdown").on("mouseenter", function () {
        $("#drop").show();
    });

    $("#dropdown").on("mouseleave", function () {
        $("#drop").hide();
    });




    $("#dropres").on("mouseenter", function () {
        $("#nav-res").show();
    });

    $("#dropres").on("mouseleave", function () {
        $("#nav-res").hide();
    });



    $("#droppet").on("mouseenter", function () {
        $("#nav-pet").show();
    });

    $("#droppet").on("mouseleave", function () {
        $("#nav-pet").hide();
    });


});