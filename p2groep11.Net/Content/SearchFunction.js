$(document).ready(function () {
    $(".targetSearch").keyup(function () {
        var txtSearch = $(".targetSearch").val();
        $(".chartName").each(function (index) {
            if ($(this)[0].innerText.toLowerCase().indexOf(txtSearch.toLowerCase()) > -1 && txtSearch.length !== 0) {
                if (index !== 0) {
                    $(this).parent().css("display", "block");
                }
            } else if (txtSearch.length===0) {
                $(this).parent().css("display", "block");
            } else {
                $(this).parent().css("display", "none");
            }
        });
    });
});