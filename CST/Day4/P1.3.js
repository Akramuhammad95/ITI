
// ======================================
// Program 3: Longest Word in a Sentence
// ======================================
let message = prompt('please enter the phrase')

function getLongestWord(x) {
  let word = x.split(" ");

  let longestWord = "";

  for (let w = 0; w < word.length; w++) {
    if (word[w].length > longestWord.length) {
      longestWord = word[w];
    }
  }
  return longestWord;
}
var a = getLongestWord(message)

console.log(a);
