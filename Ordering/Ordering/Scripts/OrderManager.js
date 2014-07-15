
$(function () {
    function orderViewModel(id, productName, price, status,owner) {
        this.id = id;
        this.productName = ko.observable(firstName);
        this.price = ko.observable(lastName);
        this.status = ko.observable(email);
        this.removePerson = function () {
            owner.deletePerson(this.id)
        }

        var self = this;

        this.firstName.subscribe(function (newValue) {
            owner.updatePerson(ko.toJS(self));
        });

        this.lastName.subscribe(function (newValue) {
            owner.updatePerson(ko.toJS(self));
        });

        this.email.subscribe(function (newValue) {
            owner.updatePerson(ko.toJS(self));
        });
    }

    function ordersViewModel() {
        this.hub = $.connection.personHub;
        this.orders = ko.observableArray([]);
        this.newOrderProductName= ko.observable();
        this.newOrderPrice = ko.observable();
        this.newOrderStatus = ko.observable();
        var orders = this.orders;
        var self = this;
        var notify = true;

        this.init = function () {
            this.hub.server.getAll();
        }

        this.hub.client.allOrdersRetrieved = function(allOrders) {
            var mappedOrders = $.map(allOrders, function(order) {
                return new orderViewModel(order.Id, order.FirstName,
                    order.LastName, order.Email, self)
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
        };

        this.hub.client.orderRemoved = function(id) {
            var order = ko.utils.arrayFilter(orders(), function(value) {
                return value.id == id;
            })[0];
            orders.remove(order);
        };

        this.createOrder = function() {
            var order = { productName: this.newOrderProductName(), price: this.newOrderPrice(), status: this.newOrderStatus() };
            this.hub.server.add(order).done(function() {
                console.log('order saved!');
            }).fail(function(error) {
                console.warn(error);
            });
            this.newProductName('');
            this.newProductPrice('');
            this.newProducStatus('');
        };

        this.deleteOrder = function(id) {
            this.hub.server.delete(id);
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