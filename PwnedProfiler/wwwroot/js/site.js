// Write your JavaScript code.
$(function() {

    var dataClassSelector = "[data-dataclass]";

    var onDataClassClick = function () {
        $(this).parent().children("ul").slideToggle();
    };

    var init = function() {
        $(dataClassSelector).on("click", onDataClassClick);
    };
    
    init();
});

