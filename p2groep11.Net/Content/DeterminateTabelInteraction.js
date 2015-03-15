$(document).ready(function () {
    //Lightbox
    $('.lightbox').click(function () {
        $('.backdrop, .box').animate({ 'opacity': '.50' }, 300, 'linear');
        $('.box').animate({ 'opacity': '1.00' }, 300, 'linear');
        $('.backdrop, .box').css('display', 'block');
    });

    $('.close').click(function () {
        close_box();
    });

    $('.backdrop').click(function () {
        close_box();
    });
    function close_box() {
        $('.backdrop, .box').animate({ 'opacity': '0' }, 300, 'linear', function () {
            $('.backdrop, .box').css('display', 'none');
        });
    }
    function compare(itemsYes) {
        //console.log("Compare word aangeroepen");

        //var detPath = ["TW <= 10", "TJ <= 0", "Koudgematigd klimaat met strenge winter"];
        var detPath = $(".invis");
        var wrightArr = [];
        var found = false;
        $.each(itemsYes, function (key, valueItem) {
            found = false;
            $.each(detPath, function (keyDet, valueDet) {
                //console.log(valueItem.textContent + " = ????? " + valueDet.textContent);
                if ((valueItem.textContent == " " + valueDet.textContent)) {
                    //console.log(valueItem.textContent + " =  " + valueDet.textContent);
                    wrightArr.push(valueItem);
                    found = true;
                }
            });
        });
        return wrightArr;
    }
    function removeClassesFromWrongItems(items) {
        $(".success").empty();
        if (items.length != 0) {
            $(".success").append("<p> Volgende statements zijn juist:</p>");
            $.each(items, function(key, i) {
                $(".success").append("<p>" + $(this).context.textContent + "</p>");
                $(this).removeClass();
                $(this).addClass("AnswerC");
            });
        }
        $.each($(".YesSpanActive"), function(key, i) {
            $(this).removeClass("YesSpanActive");
            $(this).addClass("YesSpan");
        });
        $.each($(".NoSpanActive"), function (key, i) {
            $(this).removeClass("NoSpanActive");
            $(this).addClass("NoSpan");
        });
       
    }

    function concat(y, n) {
        var x = [];
        $.each(y, function(key, val) {
            x.push(val);
        });

        $.each(n, function(key, val) {
            x.push(val);
        });

        return x;
    }
    $(".YesSpan").on("click", function () {
        console.log($(this));
        $(this).toggleClass("YesSpanActive");
    });
    $(".NoSpan").on("click", function() {
        $(this).toggleClass("NoSpanActive");
    });

    $(".testBut").on("click", function () {
        
        var selectedItemsYes = document.getElementsByClassName("YesSpanActive");
        var selectedItemsNo = document.getElementsByClassName("NoSpanActive");
        var yesNo = concat(selectedItemsYes, selectedItemsNo);
        var wrightArr = compare(yesNo);
        removeClassesFromWrongItems(wrightArr);
        console.log($(".AnswerC").length+ "=??????="+ $(".invis").length-1);
        if ($(".AnswerC").length == $(".invis").length-1) {
            console.log("validate bereikt" + $(".invis").length);
           
                var detPath = $(".invis");
              
                $(".success").append("<p>Determineren voltooid! goed gedaan!</p>");
               $(".success").append("<p> Het klimaattype is "+detPath[detPath.length - 1].textContent+"</p>");
               //console.log("Einde bereikt");
           

        }

    });
});