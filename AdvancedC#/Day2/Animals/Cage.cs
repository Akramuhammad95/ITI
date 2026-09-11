using Day2.Animals;

public class Cage<T> where T : Animal
{
    private T _animal;

    public T Retrieve()
    {
        if (_animal == null) throw new InvalidOperationException("Cage is empty");
        return _animal;
    }

    public void Arrive(T animal)
    {
        if (animal.Age > 8) throw new InvalidAgeException("Age must be smaller than 8 years");
        if (animal.Age < 0) throw new InvalidAgeException("Age must be positive");

        if (_animal != null) throw new InvalidOperationException("Cage is already occupied");

        _animal = animal;
    }

    public string GetInfo()
    {
        if (_animal == null) return "Cage is empty";
        return $"Name: {_animal.Name}, Age: {_animal.Age}";
    }

    public void Empty()
    {
        _animal = null;
    }
}