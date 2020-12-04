using System;

class TicTacToe 
{
    public char[,] board;
    public char player;
    public int turn;
    public char activePlayer;

    public TicTacToe(){
        board = new char[,] {{'\0', '\0', '\0'}, 
                {'\0', '\0', '\0'}, 
                {'\0', '\0', '\0'}};
        turn = 0;
        activePlayer = 'O';
    }
    
    public void Start(){
        player = DateTime.Now.Millisecond % 2 == 0 ? 'X' : 'O';

        Console.WriteLine("Lets play tic tac toe. You are playing {0} and will go {1}.", player, player == 'X' ? "first" : "second");
        while(!GameOver()){
            activePlayer = activePlayer == 'X' ? 'O' : 'X';
            DisplayBoard();
            Move();
        }
        
        DisplayBoard();

        if(turn > 9){
            Console.WriteLine("Tied Game");
        } else if(player == activePlayer) {
            System.Console.WriteLine("Congrats {0}, you won!", player);
        } else {
            System.Console.WriteLine("winston wins! No luck for {0}.", player);
        }
    }

    public void DisplayBoard(){
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

    void Move(){
        int[] location = new int[] {-1, -1};
        if(player == activePlayer){
            System.Console.Write("Input your move (row, col): ");
            // player move logic
            do {
                try{
                    location = Array.ConvertAll(Console.ReadLine().Split(","), s => int.Parse(s));
                } catch (Exception ex){
                    Console.WriteLine("Invalid Move");
                    Console.WriteLine(ex.Message);
                }
            } while (!ValidMove(location));
        } else {
            Console.WriteLine("Winston's Move.");
            // winston move logic
            if(board[1, 1] == '\0'){
                location = new int[] {1, 1};
            } else {
                do {
                    //TODO: more intelligent winstin move order
                    location = new int[] {DateTime.Now.Millisecond % 3, DateTime.Now.Second % 3};
                } while (!ValidMove(location));
            }
        }

        board[location[0], location[1]] = activePlayer;
        turn++;
    }

    bool ValidMove(int[] location){
        return location.Length == 2 && 
                location[0] >= 0 && location[0] <= board.GetLength(0) && 
                location[1] >= 0 && location[1] <= board.GetLength(1) && 
                board[location[0], location[1]] == '\0';
    }

    bool GameOver(){
        if(turn == 0){
            return false;
        }
        if(!(turn < 9)){
            return true;
        } else {
            bool winner = false;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                if(!winner){
                    winner = board[i, 0] == activePlayer && 
                            board[i, 1] == activePlayer && 
                            board[i, 2] == activePlayer;
                }
            }

            for (int i = 0; i < board.GetLength(1); i++)
            {
                if(!winner){
                    winner = board[0, i] == activePlayer && 
                            board[1, i] == activePlayer &&
                            board[2, i] == activePlayer;
                }
            }

            if(!winner){
                winner = board[0,0] == activePlayer && 
                        board[1,1] == activePlayer && 
                        board[2,2] == activePlayer;
            }

            if(!winner){
                winner = board[2,0] == activePlayer && 
                        board[1,1] == activePlayer && 
                        board[2,0] == activePlayer;
            }

            return winner;
        }
    }
}