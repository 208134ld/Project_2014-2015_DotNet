//Statements that execute when document is loaded

$(".showVegetationPicture").hide();
$(".imageVegetationHide").hide();


//Listeners

$(".selectvegetationButton").click(function() {
    //haalt het geselecteerde vegetatietype uit de form
    var selectedOption = $(".selectVegetationList option:selected").text();

    //vergelijkt de vegetatietypes
    if (selectedOption === CorrectVegetation) {
        $(".vegetationSuccess").css("display", "block");
        $(".success").css("display", "none");
        $(".vegetationFail").css("display", "none");
    } else {
        $(".vegetationFail").css("display", "block");
        $(".vegetationSuccess").css("display", "none");
        $(".showVegetationPicture").show();
        if (SchoolYear == 3) {
            $(".imageVegetationHide").show();
            goToByScroll("imageVegetationHide");
        }
    }
    return false;
});

//laat de foto van het vegetatietype verschijnen en scrollt er naartoe
$('.showVegetationPicture').click(function () {
    $('.imageVegetationHide').show();
    goToByScroll("imageVegetationHide");
});



//functions

//functie om naar bepaalde class te scrollen (werkt enkel bij unieke classes, die 1 keer gebruikt worden)
function goToByScroll(id) {
    // Remove "link" from the ID
    id = id.replace("link", "");
    // Scroll
    $('html,body').animate({
        scrollTop: $("." + id).offset().top
    },
        'slow');
}