using System;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var nipote = new Person(6, "Luca", "Santillio");
            var nonno = new Person(75, "Aristide", "Bianchi");

            var comparator = new PersonComparator();

            Person[] listAge = comparator.Compare(nipote, nonno, new AgeComparator());
            Console.WriteLine("La persona più giovane è :"+listAge[0].name);//Luca

            Person[] listName = comparator.Compare(nipote, nonno, new NameComparator());
            Console.WriteLine("La prima persona in ordine alfabetico è :"+listName[0].name);//Aristide


            Person[] listName = comparator.Compare(nipote, nonno, new Surname());
            Console.WriteLine("La prima persona in ordine alfabetico è :"+listName[0].name);//Aristide

            Console.ReadLine();
        }
    }

    class AgeComparator : IPersonStrategy
    {
        public Person[] Sort(Person p1, Person p2)
        {
            Person[] result = new Person[2];

            if(p1.age > p2.age){
                result[0] = p2;
                result[1] = p1;
            }else{
                result[0] = p1;
                result[1] = p2;
            }

            return result;
        }
    }

    class NameComparator : IPersonStrategy
    {
        public Person[] Sort(Person p1, Person p2)
        {
            Person[] result = new Person[2];

            if(p1.name.CompareTo(p2.name) > 0){
                result[0] = p2;
                result[1] = p1;
            }else{
                result[0] = p1;
                result[1] = p2;
            }

            return result;
        }
    }

    class Surname : IPersonStrategy
    {
        public Person[] Sort(Person p1, Person p2)
        {
            Person[] result = new Person[2];

            if(p1.cognome.CompareTo(p2.cognome) > 0){
                result[0] = p2;
                result[1] = p1;
            }else{
                result[0] = p1;
                result[1] = p2;
            }

            return result;
        }
    }

    interface IPersonStrategy
    {
        Person[] Sort(Person p1, Person p2);
    }

    class PersonComparator
    {
        public Person[] Compare(Person p1, Person p2, IPersonStrategy strategy){
            Person[] pArray;

            pArray = strategy.Sort(p1, p2);

            return pArray;

        }
    }

    class Person
    {
        public int age;
        public string name;
        public string cognome;

        public Person(int a, string n, string c)
        {
            age = a;
            name = n;
            this.cognome = c;
        }
    }
}
