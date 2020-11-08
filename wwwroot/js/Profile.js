var Profile = function (element) {
    this.Element = element;

};

Profile.prototype = {
    constructor: Profile,
    Register: function () {
        var self = this;

        $("#submit-btn").off('click').on('click',
            function (e) {
                e.preventDefault();
                var form = $(this).closest('form');

                var data = JSON.parse(form.serializeArray());

                localStorage.setItem('userProfile', data);

                window.location = form.data("redirect-url");
            });

    }
};
