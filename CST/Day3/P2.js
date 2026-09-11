
let sum = 0;
let number;
do {
    let userInput = prompt("Please enter a number:");
    number = parseInt(userInput);
    sum += number;
    console.log("The sum is: " + sum);

}

while (sum  < 100 && number !== 0);

console.log("The sum is: " + sum);
