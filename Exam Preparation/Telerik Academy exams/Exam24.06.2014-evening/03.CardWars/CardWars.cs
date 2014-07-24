using System;
using System.Collections.Generic;
using System.Numerics;

class CardWars
{
    static bool cardXdrawn1 = false;
    static bool cardXdrawn2 = false;
    static bool endGame = false;

    static BigInteger player1Score = 0;
    static BigInteger player2Score = 0;

    static void Main()
    {
        BigInteger gamesCount = BigInteger.Parse(Console.ReadLine());
        
        BigInteger player1Games = 0;
        BigInteger player2Games = 0;

        for (BigInteger index = 0; index < gamesCount; index++)
        {
            BigInteger player1CurrentScore = 0;
            BigInteger player2CurrentScore = 0;

            for (BigInteger card = 0; card < 3; card++)
            {
                string player1Card = Console.ReadLine();
                player1CurrentScore = CheckCard(player1Card, player1CurrentScore, "player1");
            }

            for (BigInteger card = 0; card < 3; card++)
            {
                string player2Card = Console.ReadLine();
                player2CurrentScore = CheckCard(player2Card, player2CurrentScore, "player2");
            }

            if (cardXdrawn1 && cardXdrawn2)
            {
                player1Score += 50;
                player2Score += 50;
                cardXdrawn1 = false;
                cardXdrawn2 = false;
            }

            if (cardXdrawn1 && !cardXdrawn2 && !endGame)
            {
                endGame = true;
                Console.WriteLine("X card drawn! Player one wins the match!");
            }
            else if (!cardXdrawn1 && cardXdrawn2 && !endGame)
            {
                endGame = true;
                Console.WriteLine("X card drawn! Player two wins the match!");
            }
            else if (player1CurrentScore > player2CurrentScore)
            {
                player1Games++;
                player1Score += player1CurrentScore;
            }
            else if (player2CurrentScore > player1CurrentScore)
            {
                player2Games++;
                player2Score += player2CurrentScore;
            }
        }

        if (!endGame)
        {
            if (player1Score > player2Score)
            {
                Console.WriteLine("First player wins!");
                Console.WriteLine("Score: {0}", player1Score);
                Console.WriteLine("Games won: {0}", player1Games);
            }
            else if (player1Score < player2Score)
            {
                Console.WriteLine("Second player wins!");
                Console.WriteLine("Score: {0}", player2Score);
                Console.WriteLine("Games won: {0}", player2Games);
            }
            else
            {
                Console.WriteLine("It's a tie!");
                Console.WriteLine("Score: {0}", player1Score);
            }
        }
    }

    private static BigInteger CheckCard(string playerCard, BigInteger currentScore, string player)
    {
        switch (playerCard)
        {
            case "2":
                currentScore += 10;
                break;
            case "3":
                currentScore += 9;
                break;
            case "4":
                currentScore += 8;
                break;
            case "5":
                currentScore += 7;
                break;
            case "6":
                currentScore += 6;
                break;
            case "7":
                currentScore += 5;
                break;
            case "8":
                currentScore += 4;
                break;
            case "9":
                currentScore += 3;
                break;
            case "10":
                currentScore += 2;
                break;
            case "A":
                currentScore += 1;
                break;
            case "J":
                currentScore += 11;
                break;
            case "Q":
                currentScore += 12;
                break;
            case "K":
                currentScore += 13;
                break;
            case "Z":
                if (player == "player1")
                {
                    player1Score *= 2;
                }
                else
                {
                    player2Score *= 2;
                }
                break;
            case "Y":
                if (player == "player1")
                {
                    player1Score -= 200;
                }
                else
                {
                    player2Score -= 200;
                }
                break;
            case "X":
                if (player == "player1")
                {
                    cardXdrawn1 = true;
                }
                else
                {
                    cardXdrawn2 = true;
                }
                break;
        }

        return currentScore;
    }
}
