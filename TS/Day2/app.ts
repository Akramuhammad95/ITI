import { IdentityClass } from "./IdentityClass.js";

enum colors {
    red = "red",
    green = "green",
    blue = "blue"
}

function printColor(color: colors) {
    console.log(color);
}

printColor(colors.red);




let numIdentity = new IdentityClass<number>();
console.log(numIdentity.identity(5));

let strIdentity = new IdentityClass<string>();
console.log(strIdentity.identity("Hello World"));





