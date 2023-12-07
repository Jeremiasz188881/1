using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static _1.SquareGenerator;
using static _1.SquareGenerator.SquareInfo;

namespace _1
{
    public class SquareController
    {
        private List<SquareInfo> squares;
        private SquareInfo selectedSquare;
        private Form mainForm;

        private bool drawingLine = false;
        private Point lineStart;
        private Point lineEnd;
        private int lineLength = 50;
        private int lineWidth = 10;

        public List<SquareInfo> Squares
        {
            get { return squares; }
            set { squares = value; }
        }

        public SquareController(Form form, List<SquareInfo> squares)
        {
            mainForm = form;
            this.squares = squares;
        }

        public void HandleMouseClick(Point clickLocation)
        {

            

            if (squares != null)
            {
                foreach (SquareInfo squareInfo in squares)
                {
                    if (squareInfo.Rectangle.Contains(clickLocation))
                    {
                        
                        selectedSquare = squareInfo;

                        
                        selectedSquare.BorderColor = Color.Red;

                        
                        foreach (var otherSquare in squares)
                        {
                            if (otherSquare != selectedSquare)
                            {
                                otherSquare.BorderColor = Color.Black;
                            }
                        }

                        
                        break;
                    }
                }
            }

            
            mainForm.Invalidate();
        }


        public void HandleKeyDown(Keys key)
        {
            if(selectedSquare == null)
                return;

            switch (key)
            {
                case Keys.W:
                case Keys.A:
                case Keys.S:
                case Keys.D:
                    StartDrawingLine(selectedSquare.Rectangle.Left + selectedSquare.Rectangle.Width / 2,
                                      selectedSquare.Rectangle.Top + selectedSquare.Rectangle.Height / 2,
                                      SquarePositionFromKey(key));
                    break;
            }

            mainForm.Invalidate(); 
        }

        private void StartDrawingLine(int startX, int startY, SquarePosition position)
        {
            drawingLine = true;
            selectedSquare.Position = position;
            lineStart = new Point(startX, startY);
            lineEnd = lineStart;
            mainForm.Invalidate();
        }

        public void DrawLine(Graphics graphics)
        {
            Console.WriteLine("DrawLine called!");

            if (drawingLine)
            {
                Pen pen = new Pen(Color.Black, lineWidth);

                switch (selectedSquare.Position)
                {
                    case SquarePosition.Top:
                        lineEnd.Y -= lineLength;
                        break;
                    case SquarePosition.Left:
                        lineEnd.X -= lineLength;
                        break;
                    case SquarePosition.Bottom:
                        lineEnd.Y += lineLength;
                        break;
                    case SquarePosition.Right:
                        lineEnd.X += lineLength;
                        break;
                }

                graphics.DrawLine(pen, lineStart, lineEnd);
            }
        }

        public void EndDrawingLine()
        {
            drawingLine = false;
            mainForm.Invalidate();
        }

        private SquarePosition SquarePositionFromKey(Keys key)
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

        public void UpdateSquares(List<SquareInfo> updatedSquares)
        {
            Console.WriteLine("UpdateSquares called!");
            squares = updatedSquares;

            if (!drawingLine)
            {
                mainForm.Invalidate();
            }
        }

        public void ResetSelectedSquare()
        {
            if (selectedSquare != null)
            {
                
                selectedSquare.BorderColor = Color.Black;
                
                selectedSquare = null;
                
                mainForm.Invalidate();
            }
        }
    }
}
