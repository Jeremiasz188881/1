using System;
using System.Collections.Generic;
using System.Drawing;
using static _1.SquareGenerator.SquareInfo;

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
                string mathOperation = predefinedOperations[i % predefinedOperations.Length]; 

              
                int x = random.Next(0, formSize.Width - size);
                int y = random.Next(0, formSize.Height - size);

                Rectangle square = new Rectangle(x, y, size, size);

                
                SquareInfo squareInfo = new SquareInfo(square, mathOperation, mathOperation);

                if (IsSquareOverlapping(squareInfo))
                {
                    i--; 
                }
                else
                {
                    squares.Add(squareInfo);
                }
            }

            if (squares != null)
            {
                foreach (SquareInfo squareInfo in squares)
                {
                    Console.WriteLine($"Square area: {squareInfo.Rectangle}");
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
            public Color BorderColor { get; set; }
            public SquareInfo(Rectangle rectangle, string mathOperation, string twinMathOperation)
            {
                Rectangle = rectangle;
                MathOperation = mathOperation;
                TwinMathOperation = twinMathOperation;
                Position = SquarePosition.Top;
                BorderColor = Color.Black; 
            }

            public enum SquarePosition
            {
                Top,
                Left,
                Bottom,
                Right
            }
        }
        public static SquarePosition SquarePositionFromKey(Keys key)
        {
            switch (key)
            {
                case Keys.W:
                    return SquarePosition.Top;
                case Keys.A:
                    return SquarePosition.Left;
                case Keys.S:
                    return SquarePosition.Bottom;
                case Keys.D:
                    return SquarePosition.Right;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
    }
}
