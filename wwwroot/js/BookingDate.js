var BookingDate = function (element) {
    this.Element = element;
};

BookingDate.prototype = {
    constructor: BookingDate,
    Register: function () {
        var self = this;

        $('.datepicker', self.Element).datepicker({
            format: 'mm/dd/yyyy',
            startDate: '-3d'
        });

        var selectedProduct = JSON.parse(localStorage.getItem('selectedProductData'));

        $("#name", self.Element).val(selectedProduct.name);
        $("#description", self.Element).val(selectedProduct.shortdescription);
    }
};