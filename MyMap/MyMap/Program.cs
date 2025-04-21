using MyMap.Maps;
using MyMap.Models;

namespace MyMap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleListMap<int, string> simpleListMap = new SimpleListMap<int, string>();
            simpleListMap.Add(new Item<int, string>(1, "Один"));
            simpleListMap.Add(new Item<int, string>(2, "Два"));
            simpleListMap.Add(new Item<int, string>(3, "Три"));
            simpleListMap.Add(new Item<int, string>(4, "Четыре"));
            simpleListMap.Add(new Item<int, string>(5, "Пять"));
            foreach (var item in simpleListMap)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(simpleListMap.Get(3) ?? "Не найдено");
            Console.WriteLine(simpleListMap.Get(7) ?? "Не найдено");
            simpleListMap.Remove(2);
            foreach (var item in simpleListMap)
            {
                Console.WriteLine(item);
            }
            //simpleListMap.Remove(8);

            SimpleArrayMap<int, string> simpleArrayMap = new SimpleArrayMap<int, string>();
            simpleArrayMap.Add(new Item<int, string>(1, "Один"));
            simpleArrayMap.Add(new Item<int, string>(2, "Два"));
            simpleArrayMap.Add(new Item<int, string>(3, "Три"));
            simpleArrayMap.Add(new Item<int, string>(4, "Четыре"));
            simpleArrayMap.Add(new Item<int, string>(5, "Пять"));
            simpleArrayMap.Add(new Item<int, string>(5, "Пять"));
            simpleArrayMap.Add(new Item<int, string>(5, "Шесть"));
            simpleArrayMap.Add(new Item<int, string>(5, "Семь"));

            Console.WriteLine(simpleArrayMap.Get(5));

            foreach (var element in simpleArrayMap)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
            Console.WriteLine(simpleArrayMap.Get(3));
            Console.WriteLine(simpleArrayMap.Get(6));
            simpleArrayMap.Remove(4);
            foreach (var element in simpleArrayMap)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
            simpleArrayMap.Remove(5);
            foreach (var element in simpleArrayMap)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
            Console.WriteLine(simpleArrayMap.Get(5));
            simpleArrayMap.Remove(5);
            foreach (var element in simpleArrayMap)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
            simpleArrayMap.Remove(5);
            foreach (var element in simpleArrayMap)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
            simpleArrayMap.Remove(6);


            SimpleArrayMap<int, Person> simpleArrayMapPerson = new SimpleArrayMap<int, Person>();
            Person firstPerson = new Person("Alex", 19);
            Person secondPerson = new Person("Oleg", 20);
            Person thirdPerson = new Person("Peter", 19);
            Person fourthPerson = new Person("Olga", 18);
            Person fifthPerson = new Person("Maria", 19);
            Person sixthPerson = new Person("Arina", 19);
            simpleArrayMapPerson.Add(new Item<int, Person>(firstPerson.GetHashCode(), firstPerson));
            simpleArrayMapPerson.Add(new Item<int, Person>(secondPerson.GetHashCode(), secondPerson));
            simpleArrayMapPerson.Add(new Item<int, Person>(thirdPerson.GetHashCode(), thirdPerson));
            simpleArrayMapPerson.Add(new Item<int, Person>(fourthPerson.GetHashCode(), fourthPerson));
            simpleArrayMapPerson.Add(new Item<int, Person>(fifthPerson.GetHashCode(), fifthPerson));
            simpleArrayMapPerson.Add(new Item<int, Person>(sixthPerson.GetHashCode(), sixthPerson));
            foreach (var item in simpleArrayMapPerson)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("====================================");

            simpleArrayMapPerson.Remove(new Person("Oleg", 20).GetHashCode());
            foreach (var item in simpleArrayMapPerson)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("====================================");

            simpleArrayMapPerson.Remove(new Person("Peter", 19).GetHashCode());
            foreach (var item in simpleArrayMapPerson)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("====================================");

            simpleArrayMap.Remove(new Person("Maria", 19).GetHashCode());
            foreach (var item in simpleArrayMap)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("====================================");

            simpleArrayMapPerson.Add(new Item<int, Person>(simpleArrayMapPerson.GetHashCode(), secondPerson));
            foreach (var item in simpleArrayMapPerson)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("====================================");

            simpleArrayMapPerson.Add(new Item<int, Person>(thirdPerson.GetHashCode(), thirdPerson));
            Console.WriteLine("====================================");

            foreach (var item in simpleArrayMapPerson)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("====================================");

        }
    }
}