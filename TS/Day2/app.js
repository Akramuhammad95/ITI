import { IdentityClass } from "./IdentityClass.js";
var colors;
(function (colors) {
    colors["red"] = "red";
    colors["green"] = "green";
    colors["blue"] = "blue";
})(colors || (colors = {}));
function printColor(color) {
    console.log(color);
}
printColor(colors.red);
let numIdentity = new IdentityClass();
console.log(numIdentity.identity(5));
let strIdentity = new IdentityClass();
console.log(strIdentity.identity("Hello World"));
