

namespace GameSnake.InConsole
{
    public class Position :IEquatable<Position>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Character { get; set; } = ".";



        public Position(int x,int y)
        {
            X = x;
            Y = y;


        }

        public Position(int x,int y,string character)
        {
            X = x;
            Y = y;
            Character = character;

        }




        public bool Equals(Position? other)
        {
            if (this.X == other?.X && this.Y == other.Y
            && this.Character == other.Character)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
