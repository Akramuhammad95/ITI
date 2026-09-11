Array.prototype.allStrings = function () {
    return this.every(item => typeof item === "string");
};

Array.prototype.someStartWithA = function () {
    return this.some(item => item.startsWith("a"));
};

Array.prototype.filteredFruits = function () {
    return this.filter(item => item.startsWith("b") || item.startsWith("s"));
};

Array.prototype.likedFruits = function () {
    return this.map(item => "I like " + item);
};