let name, PNumber, MNumber, email, color;

/* Name: must be characters (not a number) */
do {
    name = prompt("Enter your name");
    if (!isNaN(name) || name.trim() === "")
        alert("Invalid input. Name must be characters only.");
} while (!isNaN(name) || name.trim() === "");

/* Phone Number: numeric, length = 8 */
do {
    PNumber = prompt("Enter your Phone Number (8 digits)");
    if (isNaN(PNumber) || PNumber.length !== 8)
        alert("Invalid input. Phone number must be 8 digits.");
} while (isNaN(PNumber) || PNumber.length !== 8);

/* Mobile Number: starts with 010 | 011 | 012 | 015 and length = 11 */
let mobileRegex = /^(010|011|012|015)\d{8}$/;
do {
    MNumber = prompt("Enter your Mobile Number");
    if (!mobileRegex.test(MNumber))
        alert("Invalid input. Mobile number must be 11 digits and start with 010, 011, 012, or 015.");
} while (!mobileRegex.test(MNumber));

/* Email validation: abc@123.com */
let emailRegex = /^[a-zA-Z]+@[0-9]+\.com$/;
do {
    email = prompt("Enter your Email (example: abc@123.com)");
    if (!emailRegex.test(email))
        alert("Invalid email format.");
} while (!emailRegex.test(email));

/* Color choice */
do {
    color = prompt("Choose a color: red, green, or blue").toLowerCase();
    if (!(color === "red" || color === "green" || color === "blue"))
        alert("Invalid color choice.");
} while (!(color === "red" || color === "green" || color === "blue"));

/* Display result */
let today = new Date().toDateString();

document.write(`
    <div style="color:${color}">
        <h2>Welcome ${name} 👋</h2>
        <p>Phone Number: ${PNumber} ☎</p>
        <p>Mobile Number: ${MNumber}</p>
        <p>Email: ${email}</p>
        <p>Date: ${today}</p>
    </div>
`);