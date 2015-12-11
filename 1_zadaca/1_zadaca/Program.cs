using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _1_zadaca
{
    class Program
    {
        static void Main(string[] args)
        {
            IIntegerList intList = new IntegerList();
            ListExample(intList);

            IGenericList<string> stringList = new GenericList<string>();
            StringListExample(stringList);

            IGenericList<double> doubList = new GenericList<double>();
            doubList.Add(0.2);
            doubList.Add(0.7);
            Console.WriteLine(doubList.Count);

            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
        }
        public static void ListExample(IIntegerList listOfIntegers)
        {
            listOfIntegers.Add(1);
            listOfIntegers.Add(2);
            listOfIntegers.Add(3);
            listOfIntegers.Add(4);
            listOfIntegers.Add(5);
            //lista je [1,2,3,4,5]

            //mičemo prvi element liste
            listOfIntegers.RemoveAt(0);
            //lista je [2,3,4,5]

            //mičemo element liste čija je vrijednost 5
            listOfIntegers.Remove(5);
            //lista je [2,3,4]

            Console.WriteLine(listOfIntegers.Count);
            //3

            Console.WriteLine(listOfIntegers.Remove(100));
            //false

            Console.WriteLine(listOfIntegers.RemoveAt(5));
            //false

            //brišemo sa sadržaj liste
            listOfIntegers.Clear();

            Console.WriteLine(listOfIntegers.Count);
            //0
        }

       public static void StringListExample(IGenericList<string> stringList)
        {
            stringList.Add("Hello");
            stringList.Add("from");
            stringList.Add("the other");
            stringList.Add("side");

            Console.WriteLine(stringList.Count); //3
            Console.WriteLine(stringList.Contains("Hello")); //true
            Console.WriteLine(stringList.IndexOf("Hello")); //0
            Console.WriteLine(stringList.GetElement(1)); //from
            //Console.WriteLine(stringList.GetElement(8)); //Exception

            stringList.Remove("from");
            stringList.RemoveAt(1);
            stringList.RemoveAt(1); //Hello
            stringList.Add("it's me");
            Console.WriteLine(stringList.Count); //2
        }
    }
}
