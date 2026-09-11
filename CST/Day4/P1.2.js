// ======================================
// Program 2: Palindrome Check
// ======================================
let word = prompt("Please enter the word");
let ignoreCase = confirm("Ignoring case..?");

if (ignoreCase) {
  word = word.toLowerCase();
}

let isPalindrome = true;

for (let i = 0; i < word.length / 2; i++) {
  if (word[i] !== word[word.length - 1 - i]) {
    isPalindrome = false;
    break;
  }
}

console.log("Is Palindrome:", isPalindrome);