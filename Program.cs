using System;
using System.Threading;

namespace winston
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0){
                Console.WriteLine("Hello, please enter an argument to begin.");
                return;
            }
            
            // TODO: better input val and multi arg support
            if(args[0] == "coffee"){
                Console.WriteLine("Making Coffee");
                Coffee.Make();
            }

            if(args[0] == "ticTacToe"){
                TicTacToe game = new TicTacToe();
                game.Start();
            }
        }
    }

    

    static class Coffee
    {
        public static void Make(){
            Console.WriteLine("Heating Water");
            Wait();
            Wait();
            Wait();
            Console.WriteLine("Grinding Beans");
            Wait();
            Console.WriteLine("Pouring water");
            Wait();
            Wait();
            Console.WriteLine("Coffee is served");
        }

        public static void Wait(){
            int time = 3;

            for (int i = 0; i < time; i++)
            {
                Console.Write('.');
                Thread.Sleep(500);
            }

            Console.WriteLine('.');
        }
    }
}
