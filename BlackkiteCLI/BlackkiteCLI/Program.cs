using BlackkiteCLI.Business;
using BlackkiteCLI.Utils;
using Microsoft.Extensions.Hosting;
using System;

namespace BlackkiteCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BlackkiteProcess process = new BlackkiteProcess();
            process.Start();
            Console.ReadLine();
        }

       
    }
}
