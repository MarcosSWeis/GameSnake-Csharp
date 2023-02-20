using GameSnake.InConsole.Enums;
using GameSnake.InConsole.Interfaces;


namespace GameSnake.InConsole
{
    public class Board :IBoard
    {
        #region GameBoard
        public int Width = 0;
        public int Height = 0;
        private string _bottomAndTopChar = "-";
        private string _rigthAndLeftChar = "|";
        private readonly int _startPrintGameBoardTop = 0;
        private readonly int _startPrintGameBoardLeft = 0;
        private ConsoleColor ColorGameBoard = ConsoleColor.White;
        #endregion


        #region StatsBoard
        private ConsoleColor ColorStats = ConsoleColor.Yellow;
        #endregion


        public Board(int width,int height)
        {
            Width = width;
            Height = height;
        }
        public Board(int width,int height,string bottomAndTopChar,string rigthAndLeftChar)
        {
            Width = width;
            Height = height;
            _bottomAndTopChar = bottomAndTopChar;
            _rigthAndLeftChar = rigthAndLeftChar;

        }

        public void DrawApple(Apple apple)
        {
            PaintColor(apple.Color);
            DrawPosition(apple.Position.X,apple.Position.Y,apple.CharacterRepresentative);

        }


        public void DrawSnake(Snake snake)
        {

            PaintColor(snake.Color);
            foreach (var position in snake.Queue)
            {
                DrawPosition(position.X,position.Y,snake.CharacterRepresentative,snake);
            }
        }

        public void DrawBoard()
        {
            CreatedBoard(Width,Height,_bottomAndTopChar,_rigthAndLeftChar,ColorGameBoard,_startPrintGameBoardTop,_startPrintGameBoardLeft);
        }
        private void CreatedBoard(int width,int height,string TopBottomCharacter,string leftRigthCharacter,ConsoleColor color,int startPrintBoardTop,int startPrintBoardLeft)
        {
            for (int i = startPrintBoardTop ; i < height ; i++)
            {
                for (int j = startPrintBoardLeft ; j < width ; j++)
                {
                    #region Print Top Side
                    PaintColor(color);
                    DrawPosition(j,startPrintBoardTop,TopBottomCharacter);
                    #endregion
                    #region Print Bottom Side
                    PaintColor(color);
                    DrawPosition(j,height,TopBottomCharacter);
                    #endregion
                }

                #region Print Left Side
                PaintColor(color);
                DrawPosition(startPrintBoardLeft,i,leftRigthCharacter);
                #endregion

                #region Print Rigth Side
                PaintColor(color);
                DrawPosition(width,i,leftRigthCharacter);
                #endregion

            }
        }
        public void DrawStats(Snake snake)
        {
            CreatedBoard(Width + 30,Height - 10,"_","|",ColorStats,0,Width + 10);
            DrawPosition(Width + 11,2,"Puntos");
            DrawPosition(Width + 11,4,$".Vidas : {snake.GetLifes()}");
        }

        private void PaintColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        private void DrawPosition(int x,int y,string character)
        {


            Console.SetCursorPosition(x,y);
            Console.Write(character);




        }
        private void DrawPosition(int x,int y,string character,Snake snake)
        {
            try
            {
                Console.SetCursorPosition(x,y);
                Console.Write(character);

            } catch (ArgumentOutOfRangeException)
            {
                if (snake.Direction == Direction.Left)
                {
                    snake.Direction = Direction.Right;
                } else
                {
                    snake.Direction = Direction.Down;

                }

            }

        }

        public void ClearPosition(Snake snake)
        {
            try
            {
                Console.SetCursorPosition(snake.Queue.Last().X,snake.Queue.Last().Y);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(" ");
            } catch (ArgumentOutOfRangeException)
            {
                if (snake.Direction == Direction.Left)
                {
                    snake.Direction = Direction.Right;
                } else
                {
                    snake.Direction = Direction.Down;

                }

            }
        }
        public void GameOver()
        {
            Console.Clear();
            CreatedBoard(20,20,"#","#",ConsoleColor.Red,0,0);
            DrawPosition(10,10,"Game Over");

        }

    }
}
