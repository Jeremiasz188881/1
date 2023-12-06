using System;
using System.Collections.Generic;
using System.Drawing;

namespace _1
{
    public class SquareGenerator
    {
        private List<SquareInfo> squares = new List<SquareInfo>();
        private Random random = new Random();

        public List<SquareInfo> GeneratePredefinedSquares(int size, Size formSize)
        {
            squares.Clear();

            string[] predefinedOperations = MathOperations.GetPredefinedOperations();
            int numberOfSquares = predefinedOperations.Length;

            for (int i = 0; i < numberOfSquares; i++)
            {
                string mathOperation = predefinedOperations[i % predefinedOperations.Length]; // Cykliczne pobieranie działań

                // Generuj losowe współrzędne dla lewego górnego rogu kwadratu
                int x = random.Next(0, formSize.Width - size);
                int y = random.Next(0, formSize.Height - size);

                Rectangle square = new Rectangle(x, y, size, size);

                // Stwórz obiekt SquareInfo, aby przechować informacje o kwadracie
                SquareInfo squareInfo = new SquareInfo(square, mathOperation, mathOperation);

                // Sprawdź, czy nowy kwadrat nie nachodzi na inne kwadraty
                if (IsSquareOverlapping(squareInfo))
                {
                    i--; // Jeśli nachodzi, powtórz próbę dla tego samego indeksu
                }
                else
                {
                    squares.Add(squareInfo);
                }
            }

            return squares;
        }

        private bool IsSquareOverlapping(SquareInfo newSquareInfo)
        {
            foreach (SquareInfo existingSquareInfo in squares)
            {
                if (newSquareInfo.Rectangle.IntersectsWith(existingSquareInfo.Rectangle))
                {
                    return true;
                }
            }
            return false;
        }

        public class SquareInfo
        {
            public Rectangle Rectangle { get; set; }
            public string MathOperation { get; }
            public string TwinMathOperation { get; }
            public SquarePosition Position { get; set; }

            public SquareInfo(Rectangle rectangle, string mathOperation, string twinMathOperation)
            {
                Rectangle = rectangle;
                MathOperation = mathOperation;
                TwinMathOperation = twinMathOperation;
                Position = SquarePosition.Top;
            }

            public enum SquarePosition
            {
                Top,
                Left,
                Bottom,
                Right
            }
        }
    }
}
