namespace MyMap.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Hash => GetHashCode();
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override int GetHashCode()
        {
            return Name.Length + Age;
        }

        public override bool Equals(object? obj)
        {
            Person person = obj as Person;
            return Name.Equals(person.Name) && Age.Equals(person.Age);
        }

        public override string ToString()
        {
            return $"{Name} - {Age}";
        }
    }
}
