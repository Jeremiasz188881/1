using System;
using System.Collections.Generic;
using System.Drawing;

namespace _1

{
    public class SquareGenerator
    {
        private List<Rectangle> squares = new List<Rectangle>();
        private Random random = new Random();

        public List<Rectangle> GenerateRandomSquares(int numberOfSquares, int size, Size formSize)
        {
            squares.Clear();

            for (int i = 0; i < numberOfSquares; i++)
            {
                // Generuj losowe współrzędne dla lewego górnego rogu kwadratu
                int x = random.Next(0, formSize.Width - size);
                int y = random.Next(0, formSize.Height - size);

                Rectangle square = new Rectangle(x, y, size, size);

                // Sprawdź, czy nowy kwadrat nie nachodzi na inne kwadraty
                if (IsSquareOverlapping(square))
                {
                    i--; // Jeśli nachodzi, powtórz próbę dla tego samego indeksu
                }
                else
                {
                    squares.Add(square);
                }
            }

            return squares;
        }

        private bool IsSquareOverlapping(Rectangle newSquare)
        {
            foreach (Rectangle existingSquare in squares)
            {
                if (newSquare.IntersectsWith(existingSquare))
                {
                    return true; // Kwadraty nachodzą na siebie
                }
            }
            return false; // Kwadraty nie nachodzą na siebie
        }
    }
}