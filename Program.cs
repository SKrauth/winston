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
                TicTacToe.Start();
            }
        }
    }

    static class TicTacToe 
    {
        static char[,] board = {{'\0', '\0', '\0'}, 
                                {'\0', '\0', '\0'}, 
                                {'\0', '\0', '\0'}};
        static char player;
        static int turn = 0;

        public static void Start(){
            player = DateTime.Now.Millisecond % 2 == 0 ? 'X' : 'O';

            Console.WriteLine("Lets play tic tac toe. You are playing {0} and will go {1}.", player, player == 'X' ? "first" : "second");
            while(!GameOver()){
                DisplayBoard();
                Console.ReadLine();
            }
            
        }

        public static void DisplayBoard(){
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write("{0} {1} ", j == 0 ? "" : "|", board[i, j]);
                }
                Console.WriteLine();
                if(i != board.GetLength(0) - 1){
                    Console.WriteLine("---------");
                } else {
                    Console.WriteLine();
                }
                
            }
        }

        static void Move(char player, string location){
            turn++;
        }

        static bool GameOver(){
            turn++;
            return turn < 9 ? false : true;
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
