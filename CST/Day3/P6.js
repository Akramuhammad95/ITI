 let userInput = prompt("Please enter a number:");
number = parseInt(userInput);
for (let i = 1; i <= number; i++) {

    var line = "";
    for (let j = 1; j <= i; j++) {
        line += "*";
    }
    console.log(line);
}