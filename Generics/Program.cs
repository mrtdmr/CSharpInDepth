using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 4, 87, 44, 75 };
            //Console.WriteLine(string.Join(", ", CopyAtMost<int>(numbers, 2)));
            //Console.WriteLine(AreEqual(1,1));
            GenericCounter<string>.Increment();
            GenericCounter<string>.Increment();
            GenericCounter<string>.Display();
            GenericCounter<int>.Display();
            GenericCounter<int>.Increment();
            GenericCounter<int>.Display();
            //Value types can not be null. Nullable<int> or int? can be used for this.
            int? number1=null;
            int number2 = 100;
            //number1.GetValueOrDefault();
            //number1.GetValueOrDefault(5);
            if (number1.HasValue)
            {
                number2 *= (int)number1;
            }
            Nullable<int> noValue = new Nullable<int>();
            //Console.WriteLine(noValue.GetType()); // null reference exception.
            Nullable<int> noValue2 = new Nullable<int>(5);
            Console.WriteLine(noValue2.GetType());
        }
        static StringCollection GenerateNames()
        {
            StringCollection names = new StringCollection();
            names.Add("Gemma");
            names.Add("Jonas");
            names.Add("John");
            return names;
        }
        static void PrintNames(StringCollection names) {
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
        static List<string> GenerateNames2()
        {
            List<string> names = new List<string>();
            names.Add("Gemma");
            names.Add("Jonas");
            names.Add("John");
            return names;
        }

        static List<T> CopyAtMost<T>(List<T> input,int maxElements) {
            int actualCount = Math.Min(input.Count, maxElements);
            List<T> ret = new List<T>();
            for (int i = 0; i < actualCount; i++)
            {
                ret.Add(input[i]);
            }
            return ret;
        }
        static void PrintItems<T>(List<T> items) where T:IFormattable {
            CultureInfo culture = CultureInfo.InvariantCulture;
            foreach (T item in items)
            {
                Console.WriteLine(item.ToString(null, culture));
            }
        }
        static TResult Method<TArg, TResult>(TArg input) where TArg:IComparable<TArg> where TResult:class,new() {
            //TArg number = (TArg)Convert.ChangeType(144, typeof(TArg));
            TArg arg = default(TArg);
            input.CompareTo(arg);
            return (TResult)Convert.ChangeType("Murat", typeof(TResult));
        }
        static bool AreEqual<T>(T item1, T item2)where T:IComparable<T> {
            return item1.CompareTo(item2) == 0;
        }
    }
    class GenericCounter<T>
    {
        private static int value;
        static GenericCounter()
        {
            Console.WriteLine($"Initializing counter for {typeof(T)}");
        }
        public static void Increment()
        {
            value++;
        }
        public static void Display()
        {
            Console.WriteLine($"Counter for {typeof(T)}:{value}");
        }
    }
}
