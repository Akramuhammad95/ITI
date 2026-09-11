 let userInput1 = prompt("Please enter a number:");
    number1 = parseInt(userInput1);
 let userInput2 = prompt("Please enter a number:");
    number2 = parseInt(userInput2);

 let userInput3 = prompt("Please enter a number:");
    number3 = parseInt(userInput3);

if (number1%number2 === 0 && number1%number3 === 0)
    console.log("The number " + number1 + " is divisible by both " + number2 + " and " + number3);
else if (number1%number2 === 0)
    console.log("The number " + number1 + " is divisible by " + number2);
else if (number1%number3 === 0)
    console.log("The number " + number1 + " is divisible by " + number3);
else
    console.log("The number " + number1 + " is not divisible by either " + number2 + " or " + number3);
