// ======================================
//  Area of a Circle
// ======================================
let radius = +prompt("Enter the radius of the circle");

if (radius > 0) {
  alert(`The area of circle is ${(Math.PI * radius ** 2).toFixed(2)}`);
} else {
  alert("Please enter a valid number");
}

// ======================================
// Square Root of a Number
// ======================================
let number = +prompt("Enter a number to calculate its square root");

if (number >= 0) {
  alert(`Square Root: ${Math.sqrt(number)}`);
} else {
  alert("Please enter a valid number");
}

// ======================================
//  Cosine of an Angle
// ======================================
let angle = +prompt("Enter an angle to calculate its cos value");
alert(`Cosine Value: ${Math.cos(angle)}`);
