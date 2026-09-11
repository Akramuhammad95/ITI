import swap from './swap.js';  
let n1 = 1;
let n2 = 2;

console.log(`Before swap: n1 = ${n1}, n2 = ${n2}`); 

[n1, n2] = swap(n1, n2);    

console.log(`After swap: n1 = ${n1}, n2 = ${n2}`);


import { Circle, Rectangle, Square } from './shapes.js';


// Circle
let c = new Circle(5);

// Rectangle
let r = new Rectangle(4, 6);


// Square
let s = new Square(4);


console.log(c.toString());
console.log(r.toString());
console.log(s.toString());

