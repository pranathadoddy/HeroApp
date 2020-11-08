var Profile = function (element) {
    this.Element = element;
};

Profile.prototype = {
    constructor: Profile,
    Register: function () {
        var self = this;

        $("#submit-btn", self.Element).off('click').on('click',
            function (e) {
                e.preventDefault();
                var form = $(this).closest('form');

                var data = getFormData(form);

                $.post(form.data("create-profile-url"), data, function (data) {
                     localStorage.setItem('userProfile', JSON.stringify(data.response));
                     window.location = form.data("redirect-url");
                });
                
            });

        function getFormData($form){
            var unindexed_array = $form.serializeArray();
            var indexed_array = {};

            $.map(unindexed_array, function (n, i) {
                indexed_array[n['name']] = n['value'];
            });

            return indexed_array;
        }
    }
};
