$(document).ready(function () {
    $(".targetSearch").keyup(function () {
        var txtSearch = $(".targetSearch").val();
        $(".chartName").each(function (index) {
            if ($(this)[0].innerText.toLowerCase().indexOf(txtSearch.toLowerCase()) > -1) {
                $(this).parent().css("display", "block");
            } else {
                $(this).parent().css("display", "none");
            }
        });
    });
});