$(document).ready(function() {
    $('.clauseTd').on('click', function () {
        $(this).toggleClass("clauseTdAct");
    });
    $('.resultTd').on('click', function () {
        $(this).toggleClass("resultTdAct");
    });
    $('.testBut').on('click', function() {
            var selectedItems = document.getElementsByClassName('clauseTdAct');
        alert(selectedItems.length);
    });
    
});