$(function () {

    $('form').each(function (index, item) {



        var settngs = $.data(item, 'validator').settings;
        var oldErrorFunction = settngs.errorPlacement;
        settngs.onkeyup = true;
        settngs.onfocusout = function (element) {
            $(element).valid();
        };
        settngs.errorPlacement = function (error, inputElement) {

            if (error.text() == "") {

                var vv = inputElement.closest('.form-group');
                vv.removeClass('has-error');

            }

            else {
                var vv = inputElement.closest('.form-group');
                vv.addClass('has-error');
                error.addClass('text-danger');
            }
            if (oldErrorFunction && {}.toString.call(oldErrorFunction) === '[object Function]')
                oldErrorFunction.call(item, error, inputElement);

        };

    });

});