using System;
using C = System.Console;

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
        const int FieldWidth = 20;
        const int FieldHeight = 10;

        static int HeadRow = FieldHeight / 2, HeadColumn = FieldWidth / 2, FoodRow, FoodColumn;
        static Direction[] Dirs = new[] { Direction.Bottom, Direction.Bottom, Direction.Bottom };

        static ItemState[,] FieldState;
        static Direction HeadDir, TailDir, A1, A2, B1, B2;
        static bool GameOver = false;
        static int I1, I2, TailRow, TailColumn;
        static ItemState S, S1, S2;

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
                key = (int)C.ReadKey(true).Key;
                // left, top, right, bottom: 37, 38, 39, 40
                newDir = (key < 37 || key > 40) ? HeadDir : (Direction)(key - 37);
            }
            while (key != 27); // Escape code
        }

        static void Init()
        {
            FieldState = new ItemState[FieldHeight, FieldWidth];

            int i, y = HeadRow, x = HeadColumn;
            Direction dir = Direction.Left;

            FieldState[y, x] = ItemState.Head;
            for (i = 0; i < Dirs.Length - 1; i++)
            {
                dir = Dirs[i];
                if (dir == Direction.Left)
                    x++;
                if (dir == Direction.Right)
                    x--;
                if (dir == Direction.Top)
                    y++;
                if (dir == Direction.Bottom)
                    y--;
                FieldState[y, x] = dir == Direction.Left || dir == Direction.Right ? ItemState.Horizontal : ItemState.Vertical;
            }
            FieldState[y, x] = dir == Direction.Left || dir == Direction.Right ? ItemState.HorizontalTail : ItemState.VerticalTail;

            TailRow = y;
            TailColumn = x;
            HeadDir = Dirs[0];
            TailDir = Dirs[Dirs.Length - 1];

            PlaceFood(); // Remove it
        }

        static void PlaceFood()
        {
            var rand = new Random();
            for (;;)
            {
                FoodRow = rand.Next(FieldHeight);
                FoodColumn = rand.Next(FieldWidth);
                if (FieldState[FoodRow, FoodColumn] == ItemState.Empty)
                {
                    FieldState[FoodRow, FoodColumn] = ItemState.Food;
                    break;
                }
            }
        }

        static void MakeStep(Direction newDir)
        {
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

            FieldState[HeadRow, HeadColumn] = newState;
            int offset = flag ? -1 : 1;
            HeadRow = HeadRow + offset * I1;
            HeadColumn = HeadColumn + offset * I2;

            if (HeadRow < 0 || HeadRow >= FieldHeight || HeadColumn < 0 || HeadColumn >= FieldWidth)
            {
                GameOver = true;
                return;
            }
            if (FieldState[HeadRow, HeadColumn] == ItemState.Food)
            {
                FieldState[HeadRow, HeadColumn] = ItemState.Head;
                PlaceFood();
                return;
            }
            if (FieldState[HeadRow, HeadColumn] != ItemState.Empty)
            {
                GameOver = true;
                return;
            }
            FieldState[HeadRow, HeadColumn] = ItemState.Head;

            FieldState[TailRow, TailColumn] = ItemState.Empty;
            InitDirs(TailDir);

            flag = TailDir == A1;
            offset = flag ? -1 : 1;

            ItemState state = FieldState[TailRow + offset * I1, TailColumn + offset * I2];
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
            FieldState[TailRow + offset * I1, TailColumn + offset * I2] = newTailState;

            // Begin remove

            TailRow = TailRow + offset * I1;
            TailColumn = TailColumn + offset * I2;

            for (int i = 0; i < Dirs.Length - 1; i++)
                Dirs[i + 1] = Dirs[i];
            Dirs[0] = newDir;

            // End remove
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
            var s = new string('/', FieldWidth + 4);
            C.WriteLine(s);

            var stateChars = " |-\\/O\"=*";

            for (I1 = 0; I1 < FieldHeight; I1++)
            {
                C.Write("//");
                for (I2 = 0; I2 < FieldWidth; I2++)
                    C.Write(stateChars[(int)FieldState[I1, I2]].ToString());
                C.WriteLine("//");
            }

            C.WriteLine(s);
        }
    }
}
