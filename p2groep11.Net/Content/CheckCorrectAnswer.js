$(document).ready(function () {
    $(".determinateTable").css('display', 'none');
    $(".tree").css('display', 'none');
    var monthAray = ["Jan", "Feb", "Mrt", "Apr", "Mei", "Jun", "Jul", "Aug", "Sep", "Okt", "Nov", "Dev"];
    function haalAntwoordenOp() {
        var antArray = [];
        var antwoorden = $(".Answer option:selected");
        $.each(antwoorden, function(key, value) {
            antArray.push(value.text);
        });
        return antArray;
    }
    function haalJuisteAntwoordenOp() {
        var antArray = [];
        var antwoorden = $(".invisAnswers");
        $.each(antwoorden, function(key, value) {
            antArray.push(value.textContent);
        });
        return antArray;
    }
    function setWarning(id) {
        console.log(id);
        $(".errorMessage[data-vraag='" + id + "']").append("<p>Fout antwoord</p>");
    }
    function vergelijk(antw, juisteAntw) {
        var vlag = false;
        $(".errorMessage").empty();
        for (i = 0; i < antw.length; i++) {
            if (antw[i] != juisteAntw[i]) { //als het antwoord niet overeenkomt met het juiste antwoord
               
                if (antw[i] != monthAray[juisteAntw[i]-1]) {//als antwoord niet overeenkomt met maand
                    setWarning(i);//fout antwoord ==> foutmelding
                    vlag = true;
                }
                
            }
        }
        return vlag;
    }
    $(".controleerAntwoorden").on("click", function() {
        if (!vergelijk(haalAntwoordenOp(), haalJuisteAntwoordenOp())) {
            $(".succesQuestions").css('display', 'block');
            $(".determinateTable").css('display', 'block');
            $(".tree").css('display', 'block');
        }


    });

})