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

// Vergelijkt ItemsYes met het correcte path (detPath)
    function compare(itemsYes) {
        //console.log("Compare word aangeroepen");

        //var detPath = ["TW <= 10", "TJ <= 0", "Koudgematigd klimaat met strenge winter"];
        var detPath = $(".invisC").find(".invis");
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
//deselecteerd foute elementen en duid juiste elementen aan
    function removeClassesFromWrongItems(items) {
        $(".success").empty();
        if (items.length != 0) {
            $(".success").append("<h2 class='succesTitle'> Volgende statements zijn juist:</h2>");
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

    $(".YesSpan").on("click", function() {
        console.log($(this).parents().get(3).children);
        console.log($(this).parents().get(3));
        $(this).toggleClass("YesSpanActive");
    });
    $(".NoSpan").on("click", function() {
        $(this).toggleClass("NoSpanActive");
    });
    
    $(".testBut").on("click", function () {
      
        var selectedItemsYes = $(".main").find(".YesSpanActive");
        var selectedItemsNo = $(".main").find(".NoSpanActive");
        var yesNo = concat(selectedItemsYes, selectedItemsNo);
        
        var wrightArr = compare(yesNo);
        removeClassesFromWrongItems(wrightArr);
        if ($(".AnswerC").length == $(".invisC").find(".invis").length-1) {
           
           
                var detPath = $(".invisC").find(".invis");
              
                $(".success").append("<p>Determineren voltooid! goed gedaan!</p>");
            if (SchoolYear < 3) {
                
                //$(".success").append("<p> Het vegetatietype is " + detPath[detPath.length - 1].textContent + "</p>");
                $(".vegetationImg1steGraad").css("display", "block");
            }
            $(".selectVegetation").css("display", "block");
            $(".ClimateChartDisplay").css("display", "none");
            $(".questionsDiv").css("display", "none");
            $(".determinateTable").css("display", "none");
            $(".tree").css("display", "none");
            
        }

    });
    //VOORBEELD VIEW
    function removeClassesFromWrongItems2(items) {
        $(".success").empty();
        if (items.length != 0) {
            $(".success").append("<p> Volgende statements zijn juist:</p>");
            $.each(items, function (key, i) {
                $(".success").append("<p>" + $(this).context.textContent + "</p>");
                $(this).removeClass();
                $(this).addClass("AnswerV");
            });
        }
        $.each($(".YesSpanActive"), function (key, i) {
            $(this).removeClass("YesSpanActive");
            $(this).addClass("YesSpan");
        });
        $.each($(".NoSpanActive"), function (key, i) {
            $(this).removeClass("NoSpanActive");
            $(this).addClass("NoSpan");
        });

    }
    function compare2(itemsYes) {
        //console.log("Compare word aangeroepen");

        //var detPath = ["TW <= 10", "TJ <= 0", "Koudgematigd klimaat met strenge winter"];
        var detPath = $(".invisVoorbeeld");
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

    $(".testBut2").on("click", function () {
        var selectedItemsYes = $(".voorbeeld").find(".YesSpanActive");
        var selectedItemsNo = $(".voorbeeld").find(".NoSpanActive");
        var yesNo = concat(selectedItemsYes, selectedItemsNo);
      
        var wrightArr = compare2(yesNo);
        removeClassesFromWrongItems2(wrightArr);
        //console.log($(".AnswerC").length+ "=??????="+ $(".invis").length-1);
        if ($(".AnswerV").length == $(".invisVoorbeeld").length - 1) {
            //console.log("validate bereikt" + $(".invis").length);
            var detPath = $(".invisVoorbeeld");
            $(".success").append("<p>Determineren voltooid! goed gedaan!</p>");
            $(".success").append("<p> Het klimaattype is " + detPath[detPath.length - 1].textContent + "</p>");
        }
    });
});