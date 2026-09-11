using Day1;
using Day1.Shape;

Phonebook phonebook = new Phonebook();

phonebook["akram"] = "01278984548";
Console.WriteLine(phonebook);


_1SideShape square = new Square(5);
Console.WriteLine($"Area = {square.CalculateArea()}");