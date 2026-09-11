const form = document.getElementById("userForm");
const output = document.getElementById("output");
const message = document.getElementById("message");
const genderImage = document.getElementById("genderImage");

// Restore last name if exists
const savedName = localStorage.getItem("lastUserName");
if (savedName) {
  document.getElementById("name").value = savedName;
}

form.addEventListener("submit", function(e) {
  e.preventDefault();

  const name = document.getElementById("name").value.trim();
  const age = document.getElementById("age").value;
  const color = document.getElementById("color").value;
  const selectedGender = document.querySelector('input[name="gender"]:checked');

  if (!selectedGender) {
    alert("Please select gender");
    return;
  }

  const gender = selectedGender.value;

  // Update visit count for this user
  let visits = localStorage.getItem(name); // get visit count
  visits = visits ? Number(visits) + 1 : 1; // increment or start from 1

  // Save back to localStorage
  localStorage.setItem(name, visits);
  localStorage.setItem("lastUserName", name); // optional

  // Hide form
  form.style.display = "none";

  // Set gender image
  genderImage.src = gender === "male" ? "./male.jpg" : "./female.jpg";
  genderImage.alt = gender;

  // Show message
  message.innerHTML = `
    Welcome <span style="color:${color}">${name}</span>,
    you have visited site <span style="color:${color}">${visits}</span> times
  `;

  output.style.display = "flex";
}); 