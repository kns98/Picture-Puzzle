/*
using System;

public class Puzzle
{
    private int[,] board;
    private int width;
    private int height;
    private Random random;

    public Puzzle(int width, int height)
    {
        this.width = width;
        this.height = height;
        board = new int[height, width];
        random = new Random();
        Initialize();
    }

    private void Initialize()
    {
        // Fill the board with numbers in increasing order
        int count = 0;
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                board[row, col] = count;
                count++;
            }
        }

        // Shuffle the board by making random moves
        int moves = random.Next(100, 1000);
        for (int i = 0; i < moves; i++)
        {
            MoveRandomly();
        }
    }

    private void MoveRandomly()
    {
        // Find the position of the empty cell (represented by 0)
        int emptyRow = 0;
        int emptyCol = 0;
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (board[row, col] == 0)
                {
                    emptyRow = row;
                    emptyCol = col;
                    break;
                }
            }
        }

        // Find a random adjacent cell to the empty cell
        int[] rowOffsets = { -1, 0, 1, 0 };
        int[] colOffsets = { 0, -1, 0, 1 };
        int randomIndex = random.Next(4);
        int newRow = emptyRow + rowOffsets[randomIndex];
        int newCol = emptyCol + colOffsets[randomIndex];

        // Check if the new position is valid, and swap the cells
        if (newRow >= 0 && newRow < height && newCol >= 0 && newCol < width)
        {
            int temp = board[emptyRow, emptyCol];
            board[emptyRow, emptyCol] = board[newRow, newCol];
            board[newRow, newCol] = temp;
        }
    }

    public void Print()
    {
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                Console.Write("{0,3}", board[row, col]);
            }
            Console.WriteLine();
        }
    }
}

public class Program
{
    public static void Main()
    {
        Puzzle puzzle = new Puzzle(3, 3);
        puzzle.Print();
    }
}
*/