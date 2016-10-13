(function($){
	"use strict";

	$(document).on('click', '.caret', function(event) {
	    var target = $(event.target);
        var subMenu = target.next();

        subMenu.addClass('open');
	});

	$(document).on('click', function (event) {
		console.log('Clicked!');

		var target = $(event.target);
        var subMenus = $('.submenu');

        if (!target.hasClass('caret')) {
            subMenus.each(function () {
                if ($(this).hasClass('open')) {
                    $(this).removeClass('open');
                }
            });
        }
	});
	
})(jQuery);
