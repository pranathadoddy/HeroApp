var ProductSearch = function (element) {
    this.Element = element;
};

ProductSearch.prototype = {
    constructor: ProductSearch,
    Register: function () {
        var self = this;

        $("#btn-search").off('click').on('click',
            function (e) {
                e.preventDefault();
                $(".result").html("Loading ...");
                var form = $(this).closest('form');
                var parameter = form.serialize();
                var url = form.data("search-url");
                url += "?"+parameter;

                $.get(url, function (data) {
                    $(".result").html(data);

                    var productList = new ProductList();
                    productList.Register();
                });
            });
    }
};
