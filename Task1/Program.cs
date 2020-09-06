using System;
using System.Collections;
using System.Collections.Generic;

namespace Task1
{

    public static class Ext
    {
        public static IEnumerable<int> ThisDoesntMakeAnySense(this IEnumerable<int> nums,Predicate<int> pred,Func<IEnumerable<int>> method)
        {
            if (nums == null)
                throw new ArgumentNullException("nums");
            if (pred == null)
                throw new ArgumentNullException("predicate");
            if (method == null)
                throw new ArgumentNullException("delegate");


            foreach(int item in nums)
            {
                if (pred(item))
                    return nums;
            }
  
            return method.Invoke();
        }
    }
    class Program
    {
        static IEnumerable<int> getRecord()
        {
            return new int[] { -1 };
        }

        static void Main(string[] args)
        {
            Predicate<int> predicate = n => n % 2 == 0;

            while(true)
            {
                try
                {
                    string input = Console.In.ReadLine();
                    int[] arr = toIntArray(input);
                    IEnumerable<int> newarr = arr.ThisDoesntMakeAnySense(predicate, getRecord);
                    foreach (int item in newarr)
                        Console.Write(item + " ");
                    arr.ThisDoesntMakeAnySense(null, getRecord);
                    arr.ThisDoesntMakeAnySense(predicate, null);
                    Console.WriteLine();
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
        }

        static int[] toIntArray(string source)
        {
            string[] strArr = source.Split(',');
            List<int> dest = new List<int>();
            for (int i =0;i<strArr.Length;i++)
            {
                int j;
                if(int.TryParse(strArr[i],out j))
                {
                    dest.Add(j);
                }
            }

            return dest.ToArray();
        }
    }
}
