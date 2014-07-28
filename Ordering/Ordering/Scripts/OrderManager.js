
$(function () {
    function orderViewModel(id, productName, price, status,owner) {
        this.id = id;
        this.productName = ko.observable(productName);
        this.price = ko.observable(price);
        this.status = ko.observable(status);
        this.removeOrder = function() {
            owner.deleteOrder(this.id);
        };

        this.processOrder = function () {
            owner.prepareOrder(this.id);
        };

        var self = this;

        this.productName.subscribe(function (newValue) {
            owner.updateOrder(ko.toJS(self));
        });

        this.status.subscribe(function (newValue) {
            owner.updateOrder(ko.toJS(self));
        });

        this.price.subscribe(function (newValue) {
            owner.updateOrder(ko.toJS(self));
        });
    }

    function ordersViewModel() {
        this.hub = $.connection.orderHub;;
        this.orders = ko.observableArray([]);
        this.newOrderProductName= ko.observable();
        this.newOrderPrice = ko.observable();
        this.newOrderStatus = ko.observable();
        this.total = ko.observable(0);
        var orders = this.orders;
        var total = this.total;
        var self = this;
        var notify = true;

        this.init = function() {
            this.hub.server.getAll();
        };


        this.hub.client.allOrdersRetrieved = function(allOrders) {
            var mappedOrders = $.map(allOrders, function(order) {
                return new orderViewModel(order.Id, order.FirstName,
                    order.LastName, order.Email, self);
            });

            orders(mappedOrders);
        };

        this.hub.client.orderUpdated = function (updatedOrder) {
            var order = ko.utils.arrayFilter(orders(),
                function (value) {
                    return value.id == updatedOrder.Id;
                })[0];
            notify = false;
            order.productName(updatedOrder.ProductName);
            order.price(updatedOrder.Price);
            order.status(updatedOrder.Status);
            notify = true;
        };


       

        this.hub.client.raiseError = function(error) {
            $("#error").text(error);
        };

        this.hub.client.orderCreated = function (newOrder) {
            orders.push(new orderViewModel(newOrder.Id, newOrder.ProductName, newOrder.Price,
                newOrder.Status, self));
            total(total() + newOrder.Price);
        };

        this.hub.client.orderRemoved = function(id) {
            var order = ko.utils.arrayFilter(orders(), function(value) {
                return value.id == id;
            })[0];
            orders.remove(order);
        };
        this.hub.client.orderProcessed = function (id) {
            var order = ko.utils.arrayFilter(orders(), function (value) {
                return value.id == id;
            })[0];
            order.status('Processed');
        };
        this.createOrder = function() {
            var order = { productName: this.newOrderProductName(), price: this.newOrderPrice()};
            this.hub.server.addOrder(order).done(function () {
                console.log('order saved!');
            }).fail(function(error) {
                console.warn(error);
            });
            this.newOrderProductName('');
            this.newOrderPrice('');
            this.newOrderStatus('');
        };
       
        this.deleteOrder = function(id) {
            this.hub.server.removeOrder(id);
        };

        this.prepareOrder = function (id) {
            this.hub.server.processOrder(id);
        };

        this.updateOrder = function(order) {
            if (notify) {
                this.hub.server.update(order);
            }
        };
    }

    var viewModel = new ordersViewModel();
    ko.applyBindings(viewModel);

    $.connection.hub.start(function () {
        viewModel.init();
    });
});