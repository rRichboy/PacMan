using System;

class Program
{
    static int score = 0;

    static char[,] PlayingField =
    {
        { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
        { '#', ' ', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '#' },
        { '#', '.', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '.', '.', '#' },
        { '#', '.', '#', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '.', '#' },
        { '#', '.', '#', '.', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '.', '#', '.', '.', '#' },
        { '#', '.', '#', '.', '#', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '.', '#' },
        { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '.', '#' },
        { '#', '.', '#', '.', '#', '.', '#', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '#' },
        { '#', '.', '#', '.', '#', '.', '#', '.', '#', '#', '#', '.', '#', '#', '#', '#', '#', '#', '.', '#' },
        { '#', '.', '#', '.', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
        { '#', '.', '#', '.', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
        { '#', '.', '#', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
        { '#', '.', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '.', '#' },
        { '#', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '#' },
        { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
    };

    static int pacmanX = 1;
    static int pacmanY = 1;

    static int ghost1X = 6;
    static int ghost1Y = 5;

    static int ghost2X = 10;
    static int ghost2Y = 13;

    static int ghost3X = 9;
    static int ghost3Y = 1;

    static int ghost4X = 5;
    static int ghost4Y = 12;

    static int ghost5X = 7;
    static int ghost5Y = 10;

    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Console.WriteLine("Добро пожаловать в игру Pac - Man!\nДля победы необходимо набрать 75 очков.\nНажмите любую клавишу чтобы начать.");
        Console.ReadKey();
        Console.Clear();

        while (true)
        {
            DisplayPlayingField();

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Move(-1, 0);
                    break;
                case ConsoleKey.DownArrow:
                    Move(1, 0);
                    break;
                case ConsoleKey.LeftArrow:
                    Move(0, -1);
                    break;
                case ConsoleKey.RightArrow:
                    Move(0, 1);
                    break;
            }

            if (pacmanX == ghost1X && pacmanY == ghost1Y || pacmanX == ghost2X && pacmanY == ghost2Y || pacmanX == ghost3X && pacmanY == ghost3Y || pacmanX == ghost4X && pacmanY == ghost4Y || pacmanX == ghost5X && pacmanY == ghost5Y)
            {
                GameOver();
                break;
            }

            if (score == 75)
            {
                Console.Clear();
                Console.WriteLine("Вы выиграли!\nВаш счёт: " + score + "\nНажмите любую клавишу чтобы выйти.");
                Console.ReadKey();
                break;
            }
        }
    }

    static void DisplayPlayingField()
    {
        Console.SetCursorPosition(0, 0);

        for (int i = 0; i < PlayingField.GetLength(0); i++)
        {
            for (int j = 0; j < PlayingField.GetLength(1); j++)
            {
                if (i == pacmanX && j == pacmanY)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write('C');
                }
                else if (i == ghost1X && j == ghost1Y || i == ghost2X && j == ghost2Y || i == ghost3X && j == ghost3Y || i == ghost4X && j == ghost4Y || i == ghost5X && j == ghost5Y)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('G');
                }
                else if (PlayingField[i, j] == '#')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(PlayingField[i, j]);
                }
                else if (PlayingField[i, j] == '.')
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(PlayingField[i, j]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(PlayingField[i, j]);
                }
            }
            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Счёт: " + score);
    }

    static void Move(int deltaX, int deltaY)
    {
        int newX = pacmanX + deltaX;
        int newY = pacmanY + deltaY;

        if (PlayingField[newX, newY] == '.')
        {
            score++;
            PlayingField[newX, newY] = ' ';
        }
        else if (PlayingField[newX, newY] == '#')
        {
            return;
        }

        pacmanX = newX;
        pacmanY = newY;

        MoveGhost(ref ghost1X, ref ghost1Y);
        MoveGhost(ref ghost2X, ref ghost2Y);
        MoveGhost(ref ghost3X, ref ghost3Y);
        MoveGhost(ref ghost4X, ref ghost4Y);
        MoveGhost(ref ghost5X, ref ghost5Y);
    }

    static void MoveGhost(ref int ghostX, ref int ghostY)
    {
        Random random = new Random();
        int route = random.Next(1, 5);

        switch (route)
        {
            case 1:
                if (PlayingField[ghostX - 1, ghostY] != '#')
                {
                    ghostX--;
                }
                break;
            case 2:
                if (PlayingField[ghostX + 1, ghostY] != '#')
                {
                    ghostX++;
                }
                break;
            case 3:
                if (PlayingField[ghostX, ghostY - 1] != '#')
                {
                    ghostY--;
                }
                break;
            case 4:
                if (PlayingField[ghostX, ghostY + 1] != '#')
                {
                    ghostY++;
                }
                break;
        }
    }

    static void GameOver()
    {
        Console.Clear();
        Console.WriteLine("Игра окончена!\nВаш счёт: " + score + "\nНажмите любую клавишу чтобы выйти.");
        Console.ReadKey();
        Environment.Exit(0);
    }
}

