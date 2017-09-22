using System;
using System.Linq;
using System.Threading.Tasks;

namespace DemoLambda
{
    delegate int MathDelegate(int a, int b);
    delegate void VoidDelegate(int a, int b);

    partial class MainClass
    {
        public static void Main(string[] args)
        {
            var myClass = new MainClass();

            MathDelegate mathDelegate = myClass.SummaryNumbers;
            int result = mathDelegate(1, 1);

            MathDelegate mathDelegate2 = MainClass.MultiplyNumbers;
            int result1 = mathDelegate2(2, 2);
            int result2 = mathDelegate(3, 4) + result;
            int result3 = result + mathDelegate2(4, 4);

            MathDelegate mathDelegate3 = (int a, int b) =>
            {
                //return 0;
                var sum = a + b;
                return sum;
            };
            int result4 = mathDelegate3(1, 1);

            MathDelegate mathDelegate4 = myClass.SummaryNumbers;
            int result5 = mathDelegate4(1, 1);

            MathDelegate mathDelegate5 = mathDelegate;
            int result6 = mathDelegate(2, 2);

            MathDelegate mathDelegate6 = (int a, int b) => myClass.SummaryNumbers(a, b);

            MathDelegate mathDelegate7 = (int a, int b) => myClass.SummaryNumbers(1, 2);

            // -----------------------------------

            VoidDelegate voidDelegate = MainClass.PrintNumbers;
            voidDelegate(6, 6);

            VoidDelegate voidDelegate2 = voidDelegate + voidDelegate;
            voidDelegate2 += (int a, int b) =>
            {
                System.Console.WriteLine("----" + a.ToString() + b.ToString());
            };
            voidDelegate2(7, 7);
            voidDelegate2 -= voidDelegate;
            voidDelegate2(8, 8);

            VoidDelegate voidDelegate3 = (int a, int b) =>
            {
                MainClass.PrintNumbers(myClass.SummaryNumbers(a, b), MainClass.MultiplyNumbers(a, b));
            };
            voidDelegate3 += (int a, int b) =>
            {
                MainClass.PrintNumbers(a, b);
            };
            voidDelegate3(9, 9);

            VoidDelegate voidDelegate4 = (int a, int b) => MainClass.PrintNumbers(0, 0);
            voidDelegate4(10, 10);

            MainClass.compare(mathDelegate, voidDelegate2, voidDelegate3);
            MainClass.compare(mathDelegate, voidDelegate2, mathDelegate);
            MainClass.compare(mathDelegate, voidDelegate2, mathDelegate3);
            MainClass.compare(mathDelegate, voidDelegate2, mathDelegate4);
            MainClass.compare(mathDelegate, voidDelegate2, mathDelegate5);

            System.Console.WriteLine();
        }

        public int SummaryNumbers(int a, int b)
        {
            var sum = a + b;
            return sum;
        }

        static public int MultiplyNumbers(int a, int b)
        {
            var mul = a * b;
            return mul;
        }

        static public void PrintNumbers(int a, int b)
        {
            System.Console.WriteLine(a.ToString() + " " + b.ToString());
        }

        static void compare(MathDelegate voidDelegate1,
                            VoidDelegate voidDelegate2,
                            System.Delegate systemDelegate)
        {
            // Compile-time error.
            //Console.WriteLine(voidDelegate1 == voidDelegate2);

            // OK at compile-time. False if the run-time type of f 
            // is not the same as that of d.
            System.Console.WriteLine(voidDelegate1 == systemDelegate);
        }
    }
}
