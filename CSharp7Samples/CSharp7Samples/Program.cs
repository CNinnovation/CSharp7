using System;
using System.Threading.Tasks;
using CSharp7Samples.Helpers;
using CSharp7Samples.Models;

namespace CSharp7Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            DigitSeparators();
            BinaryLiterals();
            RefLocalsAndRefReturns();
            OutVars();
            FlexibleAwait();
            LocalFunctions();
            ExpressionsEverywhere();
            ThrowExpressions();
            TuplesSample();
            Deconstruction();
            PatternMatching();

            Console.ReadLine();
        }

        private static void PatternMatching()
        {
            Console.WriteLine(nameof(PatternMatching));
            object[] data = { null, 42, new Person("Matthias Nagel"), new Person("Stephanie Nagel") };

            foreach (var item in data)
            {
                IsPattern(item);
            }

            foreach (var item in data)
            {
                SwitchPattern(item);
            }

            Console.WriteLine();
        }

        private static void SwitchPattern(object item)
        {
            switch (item)
            {
                default:
                    break;
                case 42:
                    Console.WriteLine("it's 42, a const pattern");
                    break;
                case null:
                    Console.WriteLine("it's null");
                    break;
                case int i:
                    Console.WriteLine($"it's an int {i}");
                    break;
                case Person p when p.FirstName.StartsWith("Steph"):
                    Console.WriteLine($"it's a person {p.FirstName}");
                    break;
                case Person p1:
                    Console.WriteLine(p1.FirstName);
                    break;
                case var x:
                    Console.WriteLine("it's a var pattern");
                    break;

            }
        }

        private static void IsPattern(object item)
        {
            if (item is null) Console.WriteLine("it's a const pattern - null");

            if (item is 42) Console.WriteLine("it's a const pattern - 42");

            if (item is int i) Console.WriteLine($"it's a type pattern, value: {i}, {i.GetType().Name}");

            if (item is Person p) Console.WriteLine($"it's a person {p.FirstName}");

            if (item is Person p2 && p2.FirstName.StartsWith("Ma")) Console.WriteLine($"it's a Person starting with Ma {p2.FirstName}");

            if (item is var x) Console.WriteLine($"it's the var pattern {x}");
         
        }

        private static void Deconstruction()
        {
            Console.WriteLine(nameof(Deconstruction));
            var b1 = new Book { BookId = 1, Publisher = "Wrox Press", Title = "Professional C# 6" };

            (var id, var title, var publisher) = b1;
            Console.WriteLine($"id: {id}, title: {title}, publisher: {publisher}");

            (_, title, _) = b1;

            Console.WriteLine(title);

            //(var t, var p) = b1;
            //Console.WriteLine($"{title} {publisher}");

            var tuple1 = b1;
            Console.WriteLine(tuple1.Title);

            Console.WriteLine();
        }

        private static void TuplesSample()
        {
            Console.WriteLine(nameof(TuplesSample));
            Tuple<int, string, int> t1 = Tuple.Create(1, "one", 2);
            int i1 = t1.Item1;
            string s1 = t1.Item2;
            int i2 = t1.Item3;

            (var s, var i) = ("magic", 42);
            Console.WriteLine($"{s} {s.GetType().Name}");
            Console.WriteLine($"{i} {i.GetType().Name}");

            (string s, int i) t2 = ("magic", 42);
            Console.WriteLine(t2.s);
            Console.WriteLine(t2.i);
            t2.s = "new string";

            (var result, var remainder) = Divide(9, 2);
            Console.WriteLine($"result: {result}, remainder: {remainder}");

            var t3 = Divide(7, 3);
            Console.WriteLine($"result: {t3.Result}, remainder: {t3.Remainder}");

            Console.WriteLine();
        }

        public static (int Result, int Remainder) Divide(int val1, int val2)
        {
            int result = val1 / val2;
            int remainder = val1 % val2;
            return (result, remainder);
        }

        private static void ThrowExpressions()
        {
            Console.WriteLine(nameof(ThrowExpressions));

            int x = 42;

            //int y = 0;
            //if (x <= 42)
            //{
            //    y = x;
            //}
            //else
            //{
            //    throw new Exception("bad value");
            //}
            int y = x <= 42 ? x : throw new Exception("bad value");

            Console.WriteLine($"y: {y}");

            Console.WriteLine();
        }

        private static void ExpressionsEverywhere()
        {
            Console.WriteLine(nameof(ExpressionsEverywhere));

            var p1 = new Person("Katharina Nagel");
            Console.WriteLine(p1.FirstName);

            Console.WriteLine();
        }

        private static void LocalFunctions()
        {
            Console.WriteLine(nameof(LocalFunctions));

            int z = 3;

            int add(int x, int y) => x + y + z;


            int result = add(1, 2);
            Console.WriteLine(result);

            Console.WriteLine();
        }

        private static async void FlexibleAwait()
        {
            Console.WriteLine(nameof(FlexibleAwait));

            int result = await ReturnsANumber();
            Console.WriteLine(result);

            int result2 = await ReturnsATask();
            Console.WriteLine(result2);

            Console.WriteLine();
        }

        private static ValueTask<int> ReturnsANumber()
        {
            return new ValueTask<int>(42);
        }

        private static ValueTask<int> ReturnsATask()
        {
            var task = Task.Run(async () =>
            {
                Console.WriteLine("running in a task...");
                await Task.Delay(3000);
                return 42;
            });
            return new ValueTask<int>(task);
        }

        private static void OutVars()
        {
            Console.WriteLine(nameof(OutVars));

            Console.WriteLine("enter a number:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out var result))
            {
                Console.WriteLine($"this number: {result}");
            }
            else
            {
                Console.WriteLine("NaN");
            }
            Console.WriteLine();
        }

        private static void OutVars2()
        {
            Console.WriteLine("enter a number:");
            string input = Console.ReadLine();
            int number = GetNumber(input);
            Console.WriteLine(number);
        }

        private static int GetNumber(string input) =>
            int.TryParse(input, out int number).ReturnIfTrue(number);

        private static void RefLocalsAndRefReturns()
        {
            Console.WriteLine(nameof(RefLocalsAndRefReturns));
            int[] data = { 1, 2, 3, 4 };
            ref int a1 = ref GetArrayElement(data, 2);
            Console.WriteLine($"received {a1}");
            a1 = 42;
            Console.WriteLine($"a1: {a1}, data[2]: {data[2]}");
            Console.WriteLine();
        }

        private static ref int GetArrayElement(int[] data, int index)
        {
            ref int x = ref data[index];
            return ref x;
        }

        private static void BinaryLiterals()
        {
            Console.WriteLine(nameof(BinaryLiterals));
            ushort b1 = 0b1111_0000_1010_1010;
            ShowBinary(nameof(b1), b1);
            ushort b2 = 0b0000_1111_0101_1010;
            ShowBinary(nameof(b2), b2);

            int b3 = b1 & b2;
            int b4 = b1 | b2;
            int b5 = b1 ^ b2;
            ShowBinary(nameof(b3), b3);
            ShowBinary(nameof(b4), b4);
            ShowBinary(nameof(b5), b5);
            Console.WriteLine();
        }

        private static void ShowBinary(string name, int x)
        {
            Console.WriteLine($"{name}, hex: {x:X8}, binary: {Convert.ToString(x, 2)}");
        }

        private static void DigitSeparators()
        {
            Console.WriteLine(nameof(DigitSeparators));
            ulong l1 = 0xfedcba9876543210;
            ulong l2 = 0xfedc_ba98_7654_3210;
            ulong l3 = 0xf_ed_cba_9876_54321_0;
            Console.WriteLine($"{l1:X} {l2:X} {l3:X}");

            Console.WriteLine();
        }
    }
}