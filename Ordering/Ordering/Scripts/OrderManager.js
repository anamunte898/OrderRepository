
$(function () {
    function orderViewModel(id, productName, price, status, numberOfProducts, owner) {
        this.id = id;
        this.productName = ko.observable(productName);
        this.price = ko.observable(price);
        this.status = ko.observable(status);
        this.totalPrice = ko.observable(price * numberOfProducts);
        this.numberOfProducts = ko.observable(numberOfProducts);
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

    function productViewModel(id, name, price, owner) {
        var self = this;
        this.id = id;
        this.name = ko.observable(name);
        this.price = ko.observable(price);
        this.numberOfProducts = 1;
       
        this.addOrder = function () {
            owner.createOrder(this.id, this.numberOfProducts);
        };
    }

    function ordersViewModel() {
        this.hub = $.connection.orderHub;;
        this.orders = ko.observableArray([]);
        var orders = this.orders;
        this.newOrderProductName= ko.observable();
        this.newOrderPrice = ko.observable();
        this.newOrderStatus = ko.observable();
        this.total = ko.observable(0);
        var total = this.total;
        var self = this;
        var notify = true;
        this.products = ko.observableArray([]);
        var products = this.products;
        this.init = function() {
            this.hub.server.getAll();
        };
       

        
        GetProducts();
        function GetProducts() {
            $.ajax({
                type: "GET",
                url: "/Home/GetProducts/",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                   // ko.mapping.fromJS(data, {}, products);
                    var mappedProducts=$.map(data, function (product) {
                        return new productViewModel(product.Id, product.Name, product.Price, self);
                    });
                    products(mappedProducts);
                },
                error: function (error) {
                    alert(error.status + "<--and--> " + error.statusText);
                }
            });
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
            orders.push(new orderViewModel(newOrder.Id, newOrder.Product.Name, newOrder.Product.Price,
                newOrder.Status, newOrder.NumberOfProducts, self));
            total(total() + newOrder.Product.Price * newOrder.NumberOfProducts);
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
        this.createOrder = function (id, numberOfPrducts)
        {
          
            this.hub.server.addOrder(id, numberOfPrducts).done(function () {
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