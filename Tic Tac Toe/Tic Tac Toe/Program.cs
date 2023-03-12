using System;

class Program
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static char currentPlayer = 'X';

    static void Main()
    {
        PrintBoard();
        while (!IsGameOver())
        {
            TakeTurn();
            PrintBoard();
        }
        Console.WriteLine(GetWinner() + " wins!");
        Console.ReadLine();
    }

    static void PrintBoard()
    {
        Console.Clear();
        Console.WriteLine(" " + board[0] + " | " + board[1] + " | " + board[2]);
        Console.WriteLine("---|---|---");
        Console.WriteLine(" " + board[3] + " | " + board[4] + " | " + board[5]);
        Console.WriteLine("---|---|---");
        Console.WriteLine(" " + board[6] + " | " + board[7] + " | " + board[8]);
    }

    static void TakeTurn()
    {
        Console.WriteLine(currentPlayer + "'s turn.");
        Console.Write("Enter a number between 1 and 9: ");
        int choice = int.Parse(Console.ReadLine()) - 1;
        if (board[choice] == 'X' || board[choice] == 'O')
        {
            Console.WriteLine("That cell is already occupied. Try again.");
            TakeTurn();
        }
        else
        {
            board[choice] = currentPlayer;
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        }
    }

    static bool IsGameOver()
    {
        return GetWinner() != ' ' || IsBoardFull();
    }

    static bool IsBoardFull()
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[i] != 'X' && board[i] != 'O')
            {
                return false;
            }
        }
        return true;
    }

    static char GetWinner()
    {
        if (board[0] == board[1] && board[1] == board[2])
        {
            return board[0];
        }
        if (board[3] == board[4] && board[4] == board[5])
        {
            return board[3];
        }
        if (board[6] == board[7] && board[7] == board[8])
        {
            return board[6];
        }
        if (board[0] == board[3] && board[3] == board[6])
        {
            return board[0];
        }
        if (board[1] == board[4] && board[4] == board[7])
        {
            return board[1];
        }
        if (board[2] == board[5] && board[5] == board[8])
        {
            return board[2];
        }
        if (board[0] == board[4] && board[4] == board[8])
        {
            return board[0];
        }
        if (board[2] == board[4] && board[4] == board[6])
        {
            return board[2];
        }
        return ' ';
    }
}

