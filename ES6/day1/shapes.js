class Shape {
    constructor(name) {
        if (new.target === Shape) {
            throw new Error("Abstract class");
        }
        this.name = name;
    }

    area() {
        throw new Error("Must implement area()");
    }

    perimeter() {
        throw new Error("Must implement perimeter()");
    }

    toString() {
        return `${this.name} with area ${this.area().toFixed(2)} and perimeter ${this.perimeter().toFixed(2)}`;
    }
}

class Circle extends Shape {
    constructor(radius) {
        super("Circle");

        if (radius <= 0) throw new Error("Invalid radius");

        this.radius = radius;
    }

    area() {
        return Math.PI * this.radius ** 2;
    }

    perimeter() {
        return 2 * Math.PI * this.radius;
    }
}

class Rectangle extends Shape {
    constructor(width, height) {
        super("Rectangle");

        if (width <= 0 || height <= 0)
            throw new Error("Invalid dimensions");

        this.width = width;
        this.height = height;
    }

    area() {
        return this.width * this.height;
    }

    perimeter() {
        return 2 * (this.width + this.height);
    }
}

class Square extends Rectangle {
    constructor(side) {
        super(side, side);
        this.name = "Square";
    }
}

export { Shape, Circle, Rectangle, Square };