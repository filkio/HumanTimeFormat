using System;

namespace HumanTimeFormatSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input duration in seconds to format:");
            if (UInt32.TryParse(Console.ReadLine(), out uint toFormat))
            {
                Console.WriteLine(HumanTimeFormat.formatDuration((int)toFormat));
            }
            else
            {
                Console.WriteLine("try again, dude.");
            }

        }
    }
}
