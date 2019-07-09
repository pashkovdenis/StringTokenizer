using System;
using Tokenizer;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            while (true)
            {
                var line = Console.ReadLine(); 
                var tokenizer = new StringTokenEnumerator(line); 
                
                foreach (var token in tokenizer)
                {
                    Console.WriteLine(token); 
                }

            }
             
   
        }
    }
}
