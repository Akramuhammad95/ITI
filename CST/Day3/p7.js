var userInput1 = prompt("Please enter a number:");
let number1 = parseInt(userInput);

var userInput2 = prompt("Please enter a number:");
let number2 = parseInt(userInput2);

let min = Math.min(number1, number2);
let max = Math.max(number1, number2);

var input = prompt("Please enter a case:");
switch (input) {
    case "odd":
        for (let i = min; i <= max; i++) {
            if (i % 2 !== 0) {
                console.log(i);
            }
        }
        break;
    case "even":
        for (let i = min; i <= max; i++) {
            if (i % 2 === 0) {
                console.log(i);
            }
        }
        break;
    case "no":
        for (let i = min; i <= max; i++) {
            console.log(i);
        }
        break;
    default:
        console.log("Invalid case");
}