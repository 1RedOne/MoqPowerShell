using System;

namespace MoqPowerShell
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            try
            {
                throw new Exception("hi");
            }
            catch (Exception ex) when (ExceptionFilter(ex))
            {
                Console.WriteLine("CATCH BODY - I should not be triggered");
            }
            finally
            {
                Console.WriteLine("FINALLY - we should get here");
            }
        }

        private static bool ExceptionFilter(Exception ex)
        {
            Console.WriteLine("CATCHFILTER - I should be processing, but also the exception gets thrown");
            return false;
        }
    }
}
