var BookingDate = function (element) {
    this.Element = element;
};

BookingDate.prototype = {
    constructor: BookingDate,
    Register: function () {
        var self = this;

        var selectedProduct = JSON.parse(localStorage.getItem('selectedProductData'));

        $("#name", self.Element).val(selectedProduct.name);
        $("#description", self.Element).val(selectedProduct.shortdescription);

        $("#submit-btn", self.Element).off('click')
            .on('click', function (e) {

                e.preventDefault();
                var form = $(this).closest('form');

                var profileData = JSON.parse(localStorage.getItem('userProfile'));
                var selectedProductData = JSON.parse(localStorage.getItem('selectedProductData'));
                var dateCheckIn = $("#Date").val() + " " + $("#Hour").val() + ":" + $("#Minute").val() + ":00";

                var data = {
                    BookingName: "",
                    BookingProducts: [{
                        ProductId: selectedProductData.id,
                        PaxIds: [
                            profileData.id
                        ],
                        DateCheckIn: dateCheckIn
                    }]
                };

                $.post(form.data("create-booking-url"), data, function (data) {
                    window.location = form.data("redirect-url");
                });

            });

        self.InitCalendar();
    },
    InitCalendar: function () {
        var calendarEl = document.getElementById('calendar');
        var selectedProductData = JSON.parse(localStorage.getItem('selectedProductData'));

        var date = new Date();
        var firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
        var lastDay = new Date(date.getFullYear(), date.getMonth() + 1, 0);
        var url = calendarEl.getAttribute("data-event-source-url") + "?productId=" + selectedProductData.id;
        url += "&startDateTime=" + firstDay.toDateString();
        url += "&endDateTime=" + lastDay.toDateString();

        var calendar = new FullCalendar.Calendar(calendarEl, {
            headerToolbar: {
                left: 'prev,next today',
                center: 'title',
                right: 'dayGridMonth,timeGridWeek,timeGridDay,listMonth'
            },
            navLinks: true, 
            events: url
        });

        calendar.render();
    }
};