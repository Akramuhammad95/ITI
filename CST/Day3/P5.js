 do
 {var userInput1 = prompt("Please enter a number:");
    number1 = parseInt(userInput1);

    var userInput2 = prompt("Please enter a number:");
    number2 = parseInt(userInput2);
}
while(number1>= number2);

Array1 = [];
Array2 = [];
var sum = 0;
for (let i = number1; i <= number2; i++)
{
    if (i%3 === 0)
        {
        sum += i;
        Array1.push(i);
        }   
    
    if (i%5 === 0)
            {
                sum += i;
                Array2.push(i);
            }
}

console.log("The numbers between " + number2 + " and " + number1 + " that are divisible by 3 are: " + Array1);
console.log("The numbers between " + number2 + " and " + number1 + " that are divisible by 5 are: " + Array2);

console.log("The sum of all numbers divisible by 3 and 5 is: " + sum);
