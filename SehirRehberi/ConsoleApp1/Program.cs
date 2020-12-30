using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = 6;
            int val = 44;
            int[] a = new int[5];
            try
            {
                a[index] = val;
            }
            catch (Exception)
            {

                Console.Write("A");
            }
            Console.Write("Test 2");
        }

        public class Student
        {
            int Id = 1;
            string Name = "Mert";
        }
    }
}
