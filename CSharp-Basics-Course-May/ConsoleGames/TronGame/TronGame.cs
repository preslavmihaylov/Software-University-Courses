﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
	
struct Position
{
	public int x;
	public int y;
	public Position(int x, int y)
	{
	    this.x=x;
	    this.y=y;
	}
}
class TronGame
{
	// values

	static int playField = 3;
	
	static int down = 0;
	static int up = 1;
	static int right = 2;
	static int left = 3;
	
	static byte scoreP1 = 0;
	static byte scoreP2 = 0;
	
	static int directionP1 = right;
	static int directionP2 = left;
	
	static Queue<Position> player1 = new Queue<Position>();
	static Queue<Position> player2 = new Queue<Position>();
	static Position[] directions = new Position[]
	    {
	        new Position(0, 1), // down
	        new Position(0,-1), // up
	        new Position(1,0), // right
	        new Position(-1,0),  // left
	    };
	
	static Position player1newhead = new Position();
	static Position player2newhead = new Position();
	
	static Position player1head = new Position();
	static Position NextDirectionP1 = new Position();
	
	static Position player2head = new Position();
	static Position NextDirectionP2 = new Position();
	
	static void PrintStringOnPosition(int col, int row, string str,
	    ConsoleColor color = ConsoleColor.Gray)
	{
	    Console.SetCursorPosition(col, row);
	    Console.ForegroundColor = color;
	    Console.Write(str);
	}
	
	static void SetGameField()
	{
	    Console.CursorVisible = false;
	    Console.BufferHeight = Console.WindowHeight = 35;
	    Console.BufferWidth = Console.WindowWidth = 80;
	    for (int i = 0; i < Console.BufferWidth; i++)
	    {
	        PrintStringOnPosition(i, playField, "_", ConsoleColor.White);
	    }
	
	    PrintStringOnPosition(7, 1, "Player 1:", ConsoleColor.Magenta);
	    PrintStringOnPosition(56, 1, "Player 2:", ConsoleColor.Magenta);
	
	    for (int i = 0; i < 4; i++)
	    {
	        player1.Enqueue(new Position(i, 15));
	    }
	
	    foreach (Position element in player1)
	    {
	        PrintStringOnPosition(element.x, element.y, "*", ConsoleColor.Green);
	    }
	
	    for (int i = 1; i < 5; i++)
	    {
	        player2.Enqueue(new Position(Console.BufferWidth - i, 15));
	    }
	    foreach (Position element in player2)
	    {
	        PrintStringOnPosition(element.x, element.y, "*", ConsoleColor.Yellow);
	
	    }
	    PlayerMovement();
	}
	
	static void ChangePlayersDirection(ConsoleKeyInfo playersInput)
	{
	    //player 1
	    if (playersInput.Key == ConsoleKey.A && directionP1 != right)
	    {
	        directionP1 = left;
	    }
	    if (playersInput.Key == ConsoleKey.D && directionP1 != left)
	    {
	        directionP1 = right;
	    }
	    if (playersInput.Key == ConsoleKey.S && directionP1 != up)
	    {
	        directionP1 = down;
	    }
	    if (playersInput.Key == ConsoleKey.W && directionP1 != down)
	    {
	        directionP1 = up;
	    }
	
	    //player 2
	    if (playersInput.Key == ConsoleKey.LeftArrow && directionP2 != right)
	    {
	        directionP2 = left;
	    }
	    if (playersInput.Key == ConsoleKey.RightArrow && directionP2 != left)
	    {
	        directionP2 = right;
	    }
	    if (playersInput.Key == ConsoleKey.DownArrow && directionP2 != up)
	    {
	        directionP2 = down;
	    }
	    if (playersInput.Key == ConsoleKey.UpArrow && directionP2 != down)
	    {
	        directionP2 = up;
	    }
	}
	
	static void PlayerMovement()
	{
	    player1head = player1.Last();
	    NextDirectionP1 = directions[directionP1];
	    player1newhead = new Position(player1head.x + NextDirectionP1.x, player1head.y + NextDirectionP1.y);
	
	    player2head = player2.Last();
	    NextDirectionP2 = directions[directionP2];
	    player2newhead = new Position(player2head.x + NextDirectionP2.x, player2head.y + NextDirectionP2.y);
	}
	
	static void ResetGame()
	{
	    foreach (Position element in player1)
	    {
	        PrintStringOnPosition(element.x, element.y, " ", ConsoleColor.Green);
	    }
	    foreach (Position element in player2)
	    {
	        PrintStringOnPosition(element.x, element.y, " ", ConsoleColor.Yellow);
	    }
	    player1.Clear();
	    player2.Clear();
	    directionP1 = right;
	    directionP2 = left;
	    PrintStringOnPosition(30, 0, @"             ", ConsoleColor.White);
	    SetGameField();
	}
	
	static void GameOver()
	{
	    PrintStringOnPosition(15, 1, "" + (int)scoreP1, ConsoleColor.Cyan);
	    PrintStringOnPosition(67, 1, "" + (int)scoreP2, ConsoleColor.Cyan);
	    PrintStringOnPosition(30, 0, "GAME OVER!", ConsoleColor.Red);
	    PrintStringOnPosition(30, 1, "Player 1 Wins", ConsoleColor.Red);
	    PrintStringOnPosition(30, 2, "the game!", ConsoleColor.Red);
	    Console.ReadKey(true);
	    return;
	}
	
	static void EndCurrentGame()
	{
	    if (player1.Contains(player2newhead) && player2.Contains(player1newhead))
	    {
	        PrintStringOnPosition(player1head.x, player1head.y, "O", ConsoleColor.Blue);
	        PrintStringOnPosition(37, 0, "Draw!", ConsoleColor.Red);
	        Console.ReadKey(true);
	        ResetGame();
	    }
	
	    if (player2.Contains(player2newhead) ||
	            player1.Contains(player2newhead) ||
	            player2newhead.x < 0 || player2newhead.x > Console.WindowWidth - 1 ||
	            player2newhead.y <= 3 || player2newhead.y > Console.WindowHeight - 1)
	    {
	        scoreP1++;
	        if (scoreP1 == 5)
	        {
	            GameOver();
	        }
	        PrintStringOnPosition(30, 0, "Player 1 Wins", ConsoleColor.Red);
	        Console.ReadKey();
	        ResetGame();
	    }
	
	    if (player1.Contains(player1newhead) ||
	        player2.Contains(player1newhead) ||
	        player1newhead.x < 0 || player1newhead.x > Console.WindowWidth - 1 ||
	        player1newhead.y <= 3 || player1newhead.y > Console.WindowHeight - 1)
	    {
	        scoreP2++;
	        if (scoreP2 == 5)
	        {
	            GameOver();
	        }
	        PrintStringOnPosition(30, 0, "Player 2 Wins", ConsoleColor.Red);
	        Console.ReadKey(true);
	        ResetGame();
	    }
	}
	static void Main()
	{
        
        Console.ReadLine();

	    SetGameField();
	
	    while (true)
	    {
	        if (Console.KeyAvailable)
	        {
	            ConsoleKeyInfo playersInput = Console.ReadKey(true);
	            ChangePlayersDirection(playersInput);
	
	        }
	
	        PlayerMovement();
	
	        EndCurrentGame();
	
	        player1.Enqueue(player1newhead);
	        player2.Enqueue(player2newhead);
	
	        PrintStringOnPosition(player1newhead.x, player1newhead.y, "*", ConsoleColor.Green);
	        PrintStringOnPosition(player2newhead.x, player2newhead.y, "*", ConsoleColor.Yellow);
	                
	        PrintStringOnPosition(17, 1, "" + (int)scoreP1, ConsoleColor.Cyan);
	        PrintStringOnPosition(66, 1, "" + (int)scoreP2, ConsoleColor.Cyan);
	        Thread.Sleep(100);
	    }
	
	}
	
}
	

