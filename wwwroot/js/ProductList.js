var ProductList = function (element) {
    this.Element = element;
};

ProductList.prototype = {
    constructor: ProductList,
    Register: function () {
        var self = this;

        $(".btn-select").off('click').on('click',
            function (e) {
                e.preventDefault();
                var button = $(this);

                var selectedProductData = {
                    id: button.data("id"),
                    name: button.data("name"),
                    nights: button.data("nights"),
                    shortdescription: button.data("shortdescription")
                }

                localStorage.setItem('selectedProductData', JSON.stringify(selectedProductData));
                window.location = button.data("view-booking-date-url");
            });
    }
};