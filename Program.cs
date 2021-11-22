using System;
using Arraylist;

namespace Arraylist
{
    class Program
    {
        static void Main(string[] args)
        {
            _ArrayList arrayList = new _ArrayList();
            _ArrayList arrayListOfInts = new _ArrayList();

            arrayList.Add("Happy");
            arrayList.Add(2021);

            arrayList.Insert(1, "new");
            arrayList.Insert(2, "year");

            foreach (var item in arrayList)
            {
                Console.Write($" {item}");
            }

            Console.WriteLine();

            arrayListOfInts.Add(4);
            arrayListOfInts.Add(10);
            arrayListOfInts.Add(12);
            arrayListOfInts.Add(3);

            int sum = 0;
            foreach (var item in arrayListOfInts)
            {
                sum += (int)item;
            }

            Console.WriteLine($"The sum of arrayListOfInts is: {sum}");
        }
    }
}
