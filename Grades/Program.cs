using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            GradeBook book = new GradeBook();

            //+= a delegate is multicasting it, so it can hit all methods that reference a name change
            //we also don't have to type out new NameChangedDelegate(OnNameChanged)
            //the compiler figures it out on its own
            book.NameChanged += OnNameChanged;//tells delegate to call OnNameChanged whenever someone invokes this delegate
            book.NameChanged += OnNameChanged2;

            book.Name = "Danzig's Gradebook";
            book.Name = "Guts' Gradebook";
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);//casting to int
            WriteResult("Lowest", stats.LowestGrade);

            Console.Read();

        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Gradebook changing name from {args.ExistingName} to {args.NewName}");
        }

        static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("*********************");
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine($"{description}: {result}");
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result}");
        }
    }
}
