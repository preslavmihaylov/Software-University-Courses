﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


struct Object
{
    public int x;
    public int y;
    public char c;
    public ConsoleColor color;
}

class JustCars
{
    static void PrintOnPosition(int x, int y, char c,
        ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }
    static void PrintStringOnPosition(int x, int y, string str,
        ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }

    static void Main()
    {
        double speed = 100.0;
        int playfieldWidth = 5;
        int livesCount = 5;
        Console.BufferHeight = Console.WindowHeight = 20;
        Console.BufferWidth = Console.WindowWidth = 30;

        Object userCar = new Object();
        userCar.x = 2;
        userCar.y = Console.WindowHeight - 1;
        userCar.c = '@';
        userCar.color = ConsoleColor.Yellow;
        Random randomGenerator = new Random();
        List<Object> objects = new List<Object>();

        while (true)
        {
            bool carHit = false;
            {
                int chance = randomGenerator.Next(0, 100);
                if (chance < 10)
                {
                    Object NewObject = new Object();
                    NewObject.color = ConsoleColor.Blue;
                    NewObject.c = '$';
                    NewObject.x = randomGenerator.Next(0, playfieldWidth);
                    NewObject.y = 0;
                    objects.Add(NewObject);
                }
                else if (chance < 20)
                {
                    Object NewObject = new Object();
                    NewObject.color = ConsoleColor.Magenta;
                    NewObject.c = '*';
                    NewObject.x = randomGenerator.Next(0, playfieldWidth);
                    NewObject.y = 0;
                    objects.Add(NewObject);
                }
                else
                {


                    Object newCar = new Object();
                    newCar.color = ConsoleColor.Green;
                    newCar.x = randomGenerator.Next(0, playfieldWidth);
                    newCar.y = 0;
                    newCar.c = '#';
                    objects.Add(newCar);
                }
            }
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (userCar.x - 1 >= 0)
                    {
                        userCar.x = userCar.x - 1;
                    }

                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (userCar.x + 1 < playfieldWidth)
                    {
                        userCar.x = userCar.x + 1;
                    }
                }
            }
            List<Object> newList = new List<Object>();
            for (int i = 0; i < objects.Count; i++)
            {
                Object oldCar = objects[i];
                Object newObject = new Object();
                newObject.x = oldCar.x;
                newObject.y = oldCar.y + 1;
                newObject.c = oldCar.c;
                newObject.color = oldCar.color;
                if (newObject.c == '$' && newObject.y == userCar.y && newObject.x == userCar.x)
                {
                    objects.Clear();
                }
                if (newObject.c == '*' && newObject.y == userCar.y && newObject.x == userCar.x)
                {
                    speed -= 20;
                }
                if (newObject.c == '#' && newObject.y == userCar.y && newObject.x == userCar.x)
                {
                    carHit = true;
                    livesCount--;
                    speed += 50;
                    if (speed > 400)
                    {
                        speed = 400;
                    }
                    if (livesCount <= 0)
                    {
                        PrintStringOnPosition(8, 10, "GAME OVER!", ConsoleColor.Red);
                        PrintStringOnPosition(8, 12, "Press [enter] to exit", ConsoleColor.Red);
                        Console.ReadLine();
                        return;
                    }
                }
                if (newObject.y < Console.WindowHeight)
                {
                    newList.Add(newObject);
                }
            }
            objects = newList;
            Console.Clear();
            foreach (Object car in objects)
            {
                PrintOnPosition(car.x, car.y, car.c, car.color);
            }
            PrintOnPosition(userCar.x, userCar.y, userCar.c, userCar.color);
            if (carHit == true)
            {
                objects.Clear();
                PrintOnPosition(userCar.x, userCar.y, 'X', ConsoleColor.Red);
            }
            // Draw info
            PrintStringOnPosition(8, 4, "Lives: " + livesCount, ConsoleColor.White);
            PrintStringOnPosition(8, 5, "Speed: " + (int)speed, ConsoleColor.Cyan);

            speed += 0.5;
            if (speed > 400)
            {
                speed = 400;
            }

            Thread.Sleep((int)(600 - speed));



        }
    }
}

