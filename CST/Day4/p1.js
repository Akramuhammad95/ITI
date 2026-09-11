// ======================================
// Program 1: Count Character Occurrences
// ======================================
let text = prompt("Please enter the string");
let character = prompt("Please enter the character");
let choice;

while (choice !== "y" && choice !== "n") {
  choice = prompt("Ignoring case..? (y / n)");
}

if (choice === "y") {
  text = text.toLowerCase();
  character = character.toLowerCase();
}

let count = 0;
for (let i = 0; i < text.length; i++) {
  if (text[i] === character) {
    count++;
  }
}

console.log("Character Count:", count);


