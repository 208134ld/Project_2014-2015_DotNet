$(document).ready(function () {

    function haalAntwoordenOp() {
        return $("#item_Answer:selected").textContent;
    }

    $(".controleerAntwoorden").on("click", function() {
        console.log(haalAntwoordenOp());
    });
})