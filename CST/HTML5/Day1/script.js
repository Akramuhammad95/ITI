const red = document.getElementById('red');
const green = document.getElementById('green');
const blue = document.getElementById('blue');
const outputText = document.getElementById('outputText');

function updateColor() {
  const r = Math.round((red.value / 100) * 255);
  const g = Math.round((green.value / 100) * 255);
  const b = Math.round((blue.value / 100) * 255);

  outputText.style.color = `rgb(${r}, ${g}, ${b})`;
}

red.addEventListener('input', updateColor);
green.addEventListener('input', updateColor);
blue.addEventListener('input', updateColor);

updateColor();  