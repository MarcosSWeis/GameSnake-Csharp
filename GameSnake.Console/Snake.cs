using GameSnake.InConsole.Enums;


namespace GameSnake.InConsole
{
    public class Snake
    {


        public string CharacterRepresentative = "x";

        public Direction Direction { get; set; } = Direction.Down;

        public ConsoleColor Color = ConsoleColor.Green;

        private int _lifes = 3;

        public int GetLifes()
        {
            return _lifes;
        }

        public List<Position> Queue { get; set; } = new List<Position>();

        public Snake(Board board)
        {
            Queue.Add(InitializerPosition.Initializer(board.Width,board.Height));
        }
        public Apple EatAppel(Apple apple,Board board)
        {
            if (apple.Position.X == Queue.First().X && apple.Position.Y == Queue.First().Y)
            {
                AddElementToQueue();
                return new Apple(InitializerPosition.Initializer(board.Width,board.Height));
            } else
            {
                return apple;
            }
        }
        private void AddElementToQueue()
        {
            // ExchangePosition();
            Queue.Add(CheckAndAddPosition());
        }
        public void DetectMovements()
        {

            if (Console.KeyAvailable)
            {
                var movement = Console.ReadKey().Key;
                if (movement == ConsoleKey.UpArrow && Direction != Direction.Up)
                {
                    Direction = Direction.Up;
                    //Dependiendo del  moviemiento cada elemento deve ocupara el lugar del anterior


                } else if (movement == ConsoleKey.DownArrow && Direction != Direction.Down)
                {
                    Direction = Direction.Down;


                } else if (movement == ConsoleKey.LeftArrow && Direction != Direction.Left)
                {
                    Direction = Direction.Left;


                } else if (movement == ConsoleKey.RightArrow && Direction != Direction.Right)
                {
                    Direction = Direction.Right;


                }
            }
        }

        public void Dead(Board board)
        {
            if (Queue[0].X == board.Width || Queue[0].Y == board.Height)
            {
                if (Direction == Direction.Down)
                {
                    Direction = Direction.Up;
                } else
                {
                    Direction = Direction.Left;

                }

            }

            if (Queue.Count > 3)
            {
                for (int i = 0 ; i < Queue.Count ; i++)
                {
                    if (i != 0)
                    {
                        if (Queue[0].X == Queue[i].X && Queue[0].Y == Queue[i].Y)
                        {
                            _lifes--;
                        }

                    }
                }
            }


        }

        private Position CheckAndAddPosition()
        {
            if (Direction == Direction.Up)
            {
                return new Position(Queue.Last().X,Queue.Last().Y + 1);

            } else if (Direction == Direction.Down)
            {
                return new Position(Queue.Last().X,Queue.Last().Y - 1);

            } else if (Direction == Direction.Left)
            {
                return new Position(Queue.Last().X + 1,Queue.Last().Y);
            } else
            {
                return new Position(Queue.Last().X - 1,Queue.Last().Y);
            }
        }
        //Creo que la onda seria mover todos e imprimirlos despues

        private void ChangeCoordinates()
        {
            List<Position> tempQueue = new List<Position>();
            foreach (var position in Queue)
            {
                tempQueue.Add(new Position(position.X,position.Y));
            }

            AddFirstElement();
            for (int i = 0 ; i < tempQueue.Count - 1 ; i++)
            {
                Queue[i + 1] = tempQueue[i];
            }
        }


        private void AddFirstElement()
        {
            switch (Direction)
            {
                case Direction.Up:
                    Queue[0].Y--;
                    break;
                case Direction.Down:
                    Queue[0].Y++;
                    break;
                case Direction.Left:
                    Queue[0].X--;
                    break;
                case Direction.Right:
                    Queue[0].X++;
                    break;
                default:
                    break;
            }
        }

        public void Move()
        {
            DetectMovements();
            ChangeCoordinates();

        }




    }
}
