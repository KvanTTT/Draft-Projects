﻿using System;

namespace Snake
{
    enum ItemState
    {
        Empty = 0,
        Vertical = 1,
        Horizontal = 2,
        TopLeftBottomRightBend = 3,
        TopRightBottomLeftBend = 4,
        Head = 5,
        VerticalTail = 6,
        HorizontalTail = 7,
        Food = 8
    }

    enum Direction
    {
        Left = 0,
        Top = 1,
        Right = 2,
        Bottom = 3
    }

    class Program
    {
        const int FieldWidth = 10;
        const int FieldHeight = 10;

        static ItemState[,] FieldState = new ItemState[FieldHeight, FieldWidth];

        static Direction HeadDir = Direction.Bottom, TailDir = Direction.Bottom, A1, A2, B1, B2;
        static bool GameOver = false;
        static int I1, I2;
        static ItemState S, S1, S2;

        static int Head = (FieldHeight / 2) * FieldWidth + FieldWidth / 2;
        static Direction[] Dirs = new[] { Direction.Top, Direction.Top };

        static void Main(string[] args)
        {
            int key;
            Direction newDir = Direction.Bottom;

            Init();
            do
            {
                MakeStep(newDir);
                if (GameOver)
                {
                    break;
                }
                PrintField();
                key = (int)Console.ReadKey(true).Key;
                // left, top, right, bottom: 37, 38, 39, 40
                newDir = (key < 37 || key > 40) ? HeadDir : (Direction)(key - 37);
            }
            while (key != 27); // Escape code
        }

        static void Init()
        {
            FieldState = new ItemState[FieldHeight, FieldWidth];

            int i, y = Head / FieldWidth, x = Head % FieldHeight;
            Direction dir = Direction.Left;

            FieldState[y, x] = ItemState.Head;
            for (i = 0; i < Dirs.Length; i++)
            {
                dir = Dirs[i];
                if (dir == Direction.Left)
                    x--;
                if (dir == Direction.Right)
                    x++;
                if (dir == Direction.Top)
                    y--;
                if (dir == Direction.Bottom)
                    y++;
                FieldState[y, x] = dir == Direction.Left || dir == Direction.Right ? ItemState.Horizontal : ItemState.Vertical;
            }
            FieldState[y, x] = dir == Direction.Left || dir == Direction.Right ? ItemState.HorizontalTail : ItemState.VerticalTail;
        }

        static void PlaceFood()
        {
            var rand = new Random();
            while (true)
            {
                var row = rand.Next(FieldHeight);
                var column = rand.Next(FieldWidth);
                if (FieldState[row, column] == ItemState.Empty)
                {
                    FieldState[row, column] = ItemState.Food;
                    break;
                }
            }
        }

        static void MakeStep(Direction newDir)
        {
            int headRow = 0, headColumn = 0, tailRow = 0, tailColumn = 0;

            ItemState state;
            for (int i = 0; i < FieldHeight; i++)
                for (int j = 0; j < FieldWidth; j++)
                {
                    state = FieldState[i, j];
                    if (state == ItemState.Head)
                    {
                        headRow = i;
                        headColumn = j;
                    }
                    if (state == ItemState.HorizontalTail || state == ItemState.VerticalTail)
                    {
                        tailRow = i;
                        tailColumn = j;
                    }
                }

            InitDirs(newDir);

            ItemState newState;
            bool flag = newDir == A1;
            if (HeadDir == B1)
                newState = flag ? ItemState.TopLeftBottomRightBend : ItemState.TopRightBottomLeftBend;
            else if (HeadDir == B2)
                newState = flag ? ItemState.TopRightBottomLeftBend : ItemState.TopLeftBottomRightBend;
            else
                newState = S;

            if ((newDir != A1 || HeadDir != A2) && (newDir != A2 || HeadDir != A1))
                HeadDir = newDir;
            else
                flag = HeadDir == A1;

            FieldState[headRow, headColumn] = newState;
            int offset = flag ? -1 : 1;
            int rowOffset = headRow + offset * I1;
            int columnOffset = headColumn + offset * I2;

            if (rowOffset < 0 || rowOffset >= FieldHeight || columnOffset < 0 || columnOffset >= FieldWidth)
            {
                GameOver = true;
                return;
            }
            if (FieldState[rowOffset, columnOffset] == ItemState.Food)
            {
                FieldState[rowOffset, columnOffset] = ItemState.Head;
                PlaceFood();
                return;
            }
            if (FieldState[rowOffset, columnOffset] != ItemState.Empty)
            {
                GameOver = true;
                return;
            }
            FieldState[rowOffset, columnOffset] = ItemState.Head;

            FieldState[tailRow, tailColumn] = ItemState.Empty;
            InitDirs(TailDir);

            flag = TailDir == A1;
            offset = flag ? -1 : 1;

            state = FieldState[tailRow + offset * I1, tailColumn + offset * I2];
            var newTailState = ItemState.Empty;
            if (state == S)
            {
                newTailState = S1;
                TailDir = flag ? A1 : A2;
            }
            if (state == ItemState.TopLeftBottomRightBend)
            {
                newTailState = S2;
                TailDir = flag ? B1 : B2;
            }
            if (state == ItemState.TopRightBottomLeftBend)
            {
                newTailState = S2;
                TailDir = flag ? B2 : B1;
            }
            FieldState[tailRow + offset * I1, tailColumn + offset * I2] = newTailState;
        }

        static void InitDirs(Direction dir)
        {
            if (dir == Direction.Left || dir == Direction.Right)
            {
                A1 = Direction.Left;
                A2 = Direction.Right;
                B1 = Direction.Top;
                B2 = Direction.Bottom;
                S = ItemState.Horizontal;
                I1 = 0;
                I2 = 1;
                S1 = ItemState.HorizontalTail;
                S2 = ItemState.VerticalTail;
            }
            else
            {
                A1 = Direction.Top;
                A2 = Direction.Bottom;
                B1 = Direction.Left;
                B2 = Direction.Right;
                S = ItemState.Vertical;
                I1 = 1;
                I2 = 0;
                S1 = ItemState.VerticalTail;
                S2 = ItemState.HorizontalTail;
            }
        }

        static void PrintField()
        {
            var twoSlash = "//";
            Write(twoSlash + new string('/', FieldWidth) + twoSlash, 1);
            var stateChars = " |-\\/O\"=*";

            for (int i = 0; i < FieldHeight; i++)
            {
                Write(twoSlash);
                for (int j = 0; j < FieldWidth; j++)
                    Write(stateChars[(int)FieldState[i, j]].ToString());
                Write(twoSlash, 1);
            }

            Write(twoSlash + new string('/', FieldWidth) + twoSlash);
        }

        static void Write(string str, int newLine = 0)
        {
            Console.Write(str + (newLine == 1 ? Environment.NewLine : ""));
        }
    }
}
