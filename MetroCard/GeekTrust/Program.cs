using System;

namespace GeekTrust
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = args[0];
                MetrocardRunner runner = new MetrocardRunner();
                runner.RouteTransaction(filePath);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }

        }
    }
}