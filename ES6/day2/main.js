import { MinMax } from './MinMax.js';import './ArrayMethods.js';

// numbers array
let arr = [3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5];

let { max, min } = MinMax(arr);

console.log("Array elements:" , arr);

console.log("Max:", max);
console.log("Min:", min);
// fruits array
let fruits = ["apple", "strawberry", "banana", "orange", "mango"];

// a
console.log("All are strings:", fruits.allStrings());

// b
console.log("Some start with 'a':", fruits.someStartWithA());

// c
console.log("Filtered (b or s):", fruits.filteredFruits());

// d
let liked = fruits.likedFruits();
console.log("Liked fruits:", liked);

// e
liked.forEach(item => console.log(item));