let num : number = 10;
let str : string = "Hello, TypeScript!";
let bool : boolean = true;

console.log(num); // Output: 10
console.log(str);
console.log(bool); // Output: true
// Function with type annotations
function add(a: number, b: number): number {
    return a + b;
}
console.log(add(5, 3)); // Output: 8
// Interface example
interface Person {
    name: string;
    age: number;    
}


let person: Person = {
    name: "Alice",
    age: 30
};
//console.log(arr); // Output: [1, 2, 3, 4, 5]
console.log(person); // Output: { name: "Alice", age: 30 }

let x :null = null;

class Animal {
    name: string
    constructor(name: string) {
        this.name = name;
    }
    makeSound() {
        console.log(`${this.name} makes a sound.`);
    }
}
let dog = new Animal("Dog");
dog.makeSound(); // Output: Dog makes a sound.

function greet(name: string): void {
    console.log(`Hello, ${name}!`);
}

function getLength(str: string): number {
    return str.length;
}


interface Ipoint {
    x: number;
    y: number;
}

class Point2D implements Ipoint {
    x: number;
    y: number;

    constructor(x: number, y: number) {
        this.x = x;
        this.y = y;
    }

    getDistance(): number {
        return Math.sqrt(this.x * this.x + this.y * this.y);
    }
}

class Point3D extends Point2D {
    z: number;
    constructor(x: number, y: number, z: number) {
        super(x, y);
        this.z = z;
    }

    getDistance(): number {
        return Math.sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
    }
}

let point2D = new Point2D(3, 4);
console.log(point2D.getDistance()); // Output: 5
let point3D = new Point3D(3, 4, 5);
console.log(point3D.getDistance()); // Output: 7.0710678118654755
