public class Pet
{

    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Breed { get; set; }

    public Pet(string name, int age, string breed)
    {
        Name = name;
        Age = age;
        Breed = breed;
    }
}