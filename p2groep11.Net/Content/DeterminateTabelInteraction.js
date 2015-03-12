$(document).ready(function () {

    function compare(itemsYes, itemsNo) {
        //console.log("Compare word aangeroepen");
       
        //var detPath = ["TW <= 10", "TJ <= 0", "Koudgematigd klimaat met strenge winter"];
        var detPath = $(".invis");
        var wrongItems = [];
        var found = false;
        $.each(itemsYes, function(key, valueItem) {
            found = false;
            $.each(detPath, function (keyDet, valueDet) {
                //console.log(valueItem.textContent + " = ????? " + valueDet.textContent);
                if ((valueItem.textContent == valueDet.textContent)) {
                    //console.log(valueItem.textContent + " =  " + valueDet.textContent);
                    found = true;
                }
                if (keyDet == detPath.length - 1) {
                    if (!found) {
                        wrongItems.push(valueItem);
                    }
                }
            });
        });
        return wrongItems;
    }

    function removeClassesFromWrongItems(items) {
        $(".warning").empty();
        if (items.length != 0) {
            $(".warning").append("<p> Volgende statements zijn fout:</p>");
            $.each(items, function(key, i) {
                $(".warning").append("<p>" + $(this).context.textContent + "</p>");
                $(this).removeClass();
                $(this).addClass("wrongAnswer");
            });
        }
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

    function validate(ar) {
        var detPath = $(".invis");
        var bool = false;
        if (ar.length == detPath.length) {
            for (var prop in detPath) {
                bool = false;
                for (var a in ar) {

                    if (ar[a].textContent == detPath[prop].textContent) {
                        bool = true;
                        break;
                    }

                }
                if (!bool) {
                    break;
                }

            }

        } else {
            return false;
        }
        return bool;


    }
    $(".YesSpan").on("click", function() {
        $(this).toggleClass("YesSpanActive");
        var ar  = compare($(this));
        removeClassesFromWrongItems(ar);
    });
    $(".NoSpan").on("click", function() {
        $(this).toggleClass("NoSpanActive");
    });

    $(".testBut").on("click", function () {
        
        var selectedItemsYes = document.getElementsByClassName("YesSpanActive");
        var selectedItemsNo = document.getElementsByClassName("NoSpanActive");
        var yesNo = concat(selectedItemsYes, selectedItemsNo);

        var wrongItems = compare(yesNo);
        if (wrongItems.length == 0) {
            //console.log("validate bereikt");
            if (validate(yesNo)) {
                var detPath = $(".invis");
                
               $(".success").append("<p>"+detPath[detPath.length - 1]+"</p>");
               //console.log("Einde bereikt");
           }

        } else {
            removeClassesFromWrongItems(wrongItems);
        }

    });
});