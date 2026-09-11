const { expect } = require("chai");
const User = require("../User");

describe("addToCart", () => {

    it("should add product to cart", () => {

        const user = new User("Ahmed", "123");

        const product = {
            name: "Laptop",
            price: 1000
        };

        user.addToCart(product);

        expect(user.cart).to.have.lengthOf(1);
        expect(user.cart[0]).to.deep.equal(product);

    });

});

describe("calculateTotalCartPrice", () => {

    it("should return total cart price", () => {

        const user = new User("Ahmed", "123");

        user.addToCart({
            name: "Laptop",
            price: 1000
        });

        user.addToCart({
            name: "Mouse",
            price: 200
        });

        const total = user.calculateTotalCartPrice();

        expect(total).to.equal(1200);

    });

});